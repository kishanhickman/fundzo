using Fundzo.Core.Models;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Repositories;

namespace Fundzo.Data.Repositories
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<Currency> GetCurrencyByCode(string id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Code == id);
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
