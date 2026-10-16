using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Payment> GetPaymentByDonation(int donationId)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.DonationId == donationId);
        }

        public async Task<Payment> GetPaymentByUser(Guid userId)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
