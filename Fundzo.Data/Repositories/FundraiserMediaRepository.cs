using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;

namespace Fundzo.Data.Repositories
{
    public class FundraiserMediaRepository : Repository<FundraiserMedia>, IFundraiserMediaRepository
    {
        public FundraiserMediaRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<List<FundraiserMedia>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
