using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IPaymentStatusService
    {
        Task<List<PaymentStatus>> GetAllPaymentStatuses();
        Task<PaymentStatus> GetPaymentStatusById(int id);
    }
}
