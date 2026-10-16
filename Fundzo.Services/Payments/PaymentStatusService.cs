using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using PaymentStatus = Fundzo.Core.Models.PaymentStatus;

namespace Fundzo.Services.Payments
{
    public class PaymentStatusService : IPaymentStatusService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public PaymentStatusService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all payment statuses.
        /// </summary>
        /// <returns>All payment statuses.</returns>
        public async Task<List<PaymentStatus>> GetAllPaymentStatuses()
        {
            return await context.PaymentStatuses.GetAllAsync();
        }

        /// <summary>
        /// Get payment status by id.
        /// </summary>
        /// <param name="id">Payment status id.</param>
        /// <returns>The payment status with certain id.</returns>
        public async Task<PaymentStatus> GetPaymentStatusById(int id)
        {
            return await context.PaymentStatuses.FindById(id);
        }
    }
}
