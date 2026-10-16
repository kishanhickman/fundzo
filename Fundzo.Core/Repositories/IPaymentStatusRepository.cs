using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IPaymentStatusRepository : IRepository<PaymentStatus>
    {
        Task<PaymentStatus> GetPaymentStatusByIdAsync(int id);

        Task<PaymentStatus> GetPaymentStatusByName(string name);

        Task<List<PaymentStatus>> GetAllAsync();
    }
}