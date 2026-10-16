using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;

namespace Fundzo.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address> GetAddressByPostcodeAsync(string postCode)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.PostCode == postCode);
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}