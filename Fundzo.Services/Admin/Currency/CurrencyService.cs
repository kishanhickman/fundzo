using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using CurrencyModel = Fundzo.Core.Models.Currency;

namespace Fundzo.Services.Admin.Currency
{
    public class CurrencyService : ICurrencyService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public CurrencyService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all currencies.
        /// </summary>
        /// <returns>All currencies.</returns>
        public async Task<List<CurrencyModel>> GetAllCurrencies()
        {
            return await context.Currencies.GetAllAsync();
        }

        /// <summary>
        /// Get currency by id.
        /// </summary>
        /// <param name="id">Currency id.</param>
        /// <returns>The currency with certain id.</returns>
        public async Task<CurrencyModel> GetCurrencyById(int id)
        {
            return await context.Currencies.FindById(id);
        }

    }
}
