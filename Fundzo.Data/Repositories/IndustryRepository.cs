using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class IndustryRepository : Repository<Industry>, IIndustryRepository
    {
        public IndustryRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<Industry> GetIndustryByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Industry>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
