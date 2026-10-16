using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(int id);
        Task<Payment> CreatePayment(Payment newPayment);
        Task DeletePayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
    }
}
