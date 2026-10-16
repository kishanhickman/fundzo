using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethod>> GetAllPaymentMethods();
        Task<PaymentMethod> GetPaymentMethodById(int id);
    }
}
