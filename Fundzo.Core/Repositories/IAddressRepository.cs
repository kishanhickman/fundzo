using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressByIdAsync(int id);

        Task<List<Address>> GetAllAsync();
    }
}