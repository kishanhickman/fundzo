using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class DonationStatusRepository : Repository<DonationStatus>, IDonationStatusRepository
    {
        public DonationStatusRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<DonationStatus> GetDonationStatusByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DonationStatus> GetDonationStatusByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Status == name);
        }

        public async Task<List<DonationStatus>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}