using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;

namespace Fundzo.Data.Repositories
{
    public class FundraiserRepository : Repository<Fundraiser>, IFundraiserRepository
    {
        private FundzoContext fundzoContext;

        public FundraiserRepository(FundzoContext context) : base(context)
        {
            fundzoContext = context;
        }
        public async Task<List<Fundraiser>> GetAllFundraisers()
        {
            return await GetAll().Include(ca => ca.Category).Include(cu => cu.Currency).Include(s => s.Status).Include(t => t.Type).Include(o => o.Organisation).Include(x => x.FundraiserMedias).ThenInclude(a => a.StaticMedia).ToListAsync();
        }
        public async Task<List<Fundraiser>> FindByName(string name)
        {
            return await GetAll().Where(x => x.Name == name).OrderBy(c => c.Name).Include(ca => ca.Category).Include(cu => cu.Currency).Include(s => s.Status).Include(t => t.Type).Include(o => o.Organisation).Include(x => x.FundraiserMedias).ThenInclude(a => a.StaticMedia).ToListAsync();
        }
        public async Task<List<Fundraiser>> FindByOwner(Guid userId)
        {
            return await GetAll().Where(x => x.UserId == userId).ToListAsync(); 
        }
        public async Task<bool> Exists(string name)
        {
            return await GetAll().Where(x => x.Name == name).FirstAsync() != null;
        }
        public async Task UpdateDateLastModified(int id)
        {
            Fundraiser fundraiser = await FindById(id);

            if (fundraiser == null)
                throw new Exception("Fundraiser not found");

            fundraiser.DateLastUpdated = DateTime.Now;
            fundzoContext.Update(fundraiser);
            fundzoContext.SaveChanges();
        }
    }
}
