using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using PaymentModel = Fundzo.Core.Models.Payment;

namespace Fundzo.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public PaymentService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all payments.
        /// </summary>
        /// <returns>All payments.</returns>
        public async Task<List<PaymentModel>> GetAllPayments()
        {
            return await context.Payments.GetAllAsync();
        }

        /// <summary>
        /// Get payment by id.
        /// </summary>
        /// <param name="id">Payment id.</param>
        /// <returns>The payment with certain id.</returns>
        public async Task<PaymentModel> GetPaymentById(int id)
        {
            return await context.Payments.FindById(id);
        }

        /// <summary>
        /// Creates a new payment.
        /// </summary>
        /// <param name="newPayment">Model of the type Payment.</param>
        /// <returns>The new payment.</returns>
        public async Task<PaymentModel> CreatePayment(PaymentModel newPayment)
        {
            await context.Payments.CreateAsync(newPayment);
            await context.CommitAsync();

            return newPayment;
        }

        /// <summary>
        /// Delete a payment.
        /// </summary>
        /// <param name="payment">Model of the type payment.</param>
        /// <returns></returns>
        public async Task DeletePayment(PaymentModel payment)
        {
            await context.Payments.DeleteAsync(payment);
            await context.CommitAsync();
        }

        /// <summary>
        /// Updated payment information.
        /// </summary>
        /// <param name="payment">Model of the type payment.</param>
        /// <returns>The updated payment.</returns>
        public async Task<PaymentModel> UpdatePayment(PaymentModel payment)
        {
            await context.Payments.UpdateAsync(payment);
            await context.CommitAsync();

            return payment;
        }
    }
}
