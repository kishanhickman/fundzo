using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        public OrganisationRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<Organisation> GetOrganisationByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Organisation> GetOrganisationByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Organisation>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}