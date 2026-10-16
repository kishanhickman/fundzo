using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod>
    {
        Task<PaymentMethod> GetPaymentMethodByIdAsync(int id);

        Task<PaymentMethod> GetPaymentMethodByName(string name);

        Task<List<PaymentMethod>> GetAllAsync();
    }
}