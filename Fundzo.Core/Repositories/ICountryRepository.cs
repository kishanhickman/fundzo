using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<Country> GetCountryByIdAsync(int id);
        Task<List<Country>> GetAllAsync();
    }
}
