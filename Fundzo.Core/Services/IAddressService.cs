using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IAddressService
    {
        Task<List<Address>> GetAllAddresses();
        Task<Address> GetAddressById(int id);
    }
}
