using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        private FundzoContext fundzoContext;

        public DonationRepository(FundzoContext context) : base(context)
        {
            fundzoContext = fundzoContext;
        }

        public async Task<List<Donation>> GetByFundraiser(int id)
        {
            return GetAll().Where(x => x.FundraiserId == id).OrderBy(c => c.DateCreated).ToList();
        }

        public async Task<List<Donation>> GetByUser(Guid id)
        {
            return GetAll().Where(x => x.UserId == id).OrderBy(c => c.DateCreated).ToList();
            ;
        }

        public async Task<List<Donation>> GetByUserAndFundraiser(Guid userId, int fundraiserId)
        {
            return GetAll().Where(x => x.UserId == userId && x.FundraiserId == fundraiserId).OrderBy(c => c.DateCreated).ToList();
        }

        public async Task<List<Donation>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
