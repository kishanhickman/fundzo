using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;

namespace Fundzo.Data.Repositories
{
    public class StaticMediaRepository : Repository<StaticMedia>, IStaticMediaRepository
    {
        public StaticMediaRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<StaticMedia> GetStaticMediaByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<StaticMedia>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
