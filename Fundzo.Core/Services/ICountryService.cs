using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountryById(int id);
    }
}
