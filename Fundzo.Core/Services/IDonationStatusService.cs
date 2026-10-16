using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IDonationStatusService
    {
        Task<List<DonationStatus>> GetAllDonationStatuses();
        Task<DonationStatus> GetDonationStatusById(int id);
    }
}
