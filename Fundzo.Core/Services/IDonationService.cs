using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IDonationService
    {
        Task<Donation> CreateDonation(Donation newDonation);
        Task DeleteDonation(Donation donation);
        Task<List<Donation>> GetAllDonations();
        Task<List<Donation>> GetDonationsByUser(Guid user);
        Task<Donation> GetDonationById(int id);
        Task<Donation> UpdateDonation(Donation donation);
    }
}