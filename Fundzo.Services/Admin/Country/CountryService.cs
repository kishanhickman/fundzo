using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using CountryModel = Fundzo.Core.Models.Country;

namespace Fundzo.Services.Admin.Country
{
    public class CountryService : ICountryService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public CountryService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all countries.
        /// </summary>
        /// <returns>All countries.</returns>
        public async Task<List<CountryModel>> GetAllCountries()
        {
            return await context.Countries.GetAllAsync();
        }

        /// <summary>
        /// Get country by id.
        /// </summary>
        /// <param name="id">Country id.</param>
        /// <returns>The country with certain id.</returns>
        public async Task<CountryModel> GetCountryById(int id)
        {
            return await context.Countries.FindById(id);
        }
    }
}
