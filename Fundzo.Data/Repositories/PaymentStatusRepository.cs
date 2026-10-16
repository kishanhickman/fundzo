using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class PaymentStatusRepository : Repository<PaymentStatus>, IPaymentStatusRepository
    {
        public PaymentStatusRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<PaymentStatus> GetPaymentStatusByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PaymentStatus> GetPaymentStatusByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Status == name);
        }

        public async Task<List<PaymentStatus>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
