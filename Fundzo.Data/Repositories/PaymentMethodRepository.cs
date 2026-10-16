using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;

using Fundzo.Data;

namespace Fundzo.Data.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<PaymentMethod> GetPaymentMethodByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PaymentMethod> GetPaymentMethodByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Method == name);
        }

        public async Task<List<PaymentMethod>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
