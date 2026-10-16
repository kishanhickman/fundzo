using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IDonationStatusRepository : IRepository<DonationStatus>
    {
        Task<DonationStatus> GetDonationStatusByIdAsync(int id);

        Task<DonationStatus> GetDonationStatusByName(string name);

        Task<List<DonationStatus>> GetAllAsync();
    }
}
