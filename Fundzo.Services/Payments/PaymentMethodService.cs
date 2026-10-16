using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using PaymentMethod = Fundzo.Core.Models.PaymentMethod;

namespace Fundzo.Services.Payments
{
    public class PaymentMethodService : IPaymentMethodService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public PaymentMethodService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all payment methods.
        /// </summary>
        /// <returns>All payment methods.</returns>
        public async Task<List<PaymentMethod>> GetAllPaymentMethods()
        {
            return await context.PaymentMethods.GetAllAsync();
        }

        /// <summary>
        /// Get payment method by id.
        /// </summary>
        /// <param name="id">Payment method id.</param>
        /// <returns>The payment method with certain id.</returns>
        public async Task<PaymentMethod> GetPaymentMethodById(int id)
        {
            return await context.PaymentMethods.FindById(id);
        }
    }
}
