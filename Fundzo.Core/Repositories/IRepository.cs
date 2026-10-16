using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;



namespace Fundzo.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> FindById(int id);
        Task<TEntity> CreateAsync(TEntity entity, bool saveChanges = true);
        Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true);
        Task Save();
        Task<TEntity> DeleteAsync(int id, bool saveChanges = true);
        Task<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true);
    }
}