using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<Payment> GetPaymentByIdAsync(int id);

        Task<Payment> GetPaymentByDonation(int donationId);

        Task<Payment> GetPaymentByUser(Guid userId);

        Task<List<Payment>> GetAllAsync();
    }
}