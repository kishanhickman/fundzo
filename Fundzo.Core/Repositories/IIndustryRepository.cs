using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;


namespace Fundzo.Core.Repositories
{
    public interface IIndustryRepository : IRepository<Industry>
    {
        Task<Industry> GetIndustryByIdAsync(int id);

        Task<List<Industry>> GetAllAsync();
    }
}
