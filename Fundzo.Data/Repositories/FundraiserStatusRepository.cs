using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class FundraiserStatusRepository : Repository<FundraiserStatus>, IFundraiserStatusRepository
    {
        public FundraiserStatusRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<FundraiserStatus> GetFundraiserStatusByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FundraiserStatus> GetFundraiserStatusByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Status == name);
        }

        public async Task<List<FundraiserStatus>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}