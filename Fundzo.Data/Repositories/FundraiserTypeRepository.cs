using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class FundraiserTypeRepository : Repository<FundraiserType>, IFundraiserTypeRepository
    {
        public FundraiserTypeRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<FundraiserType> GetFundraiserTypeByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FundraiserType> GetFundraiserTypeByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Type == name);
        }

        public async Task<List<FundraiserType>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}