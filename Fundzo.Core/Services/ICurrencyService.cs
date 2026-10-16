using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetAllCurrencies();
        Task<Currency> GetCurrencyById(int id);
    }
}
