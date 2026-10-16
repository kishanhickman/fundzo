using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using AddressModel = Fundzo.Core.Models.Address;

namespace Fundzo.Services.Admin.Address
{
    public class AddressService : IAddressService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public AddressService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all addresses.
        /// </summary>
        /// <returns>All addresses.</returns>
        public async Task<List<AddressModel>> GetAllAddresses()
        {
            return await context.Addresses.GetAllAsync();
        }

        /// <summary>
        /// Get address by id.
        /// </summary>
        /// <param name="id">Address id.</param>
        /// <returns>The address with certain id.</returns>
        public async Task<AddressModel> GetAddressById(int id)
        {
            return await context.Addresses.FindById(id);
        }
    }
}
