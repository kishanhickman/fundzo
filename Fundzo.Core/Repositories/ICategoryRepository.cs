using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByIdAsync(int id);

        Task<Category> GetCategoryByName(string name);

        Task<List<Category>> GetAllAsync();
    }
}