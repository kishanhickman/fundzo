using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<Currency> GetCurrencyByCode(string currencyCode);
        Task<List<Currency>> GetAllAsync();
    }
}
