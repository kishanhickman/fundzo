using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using IndustryModel = Fundzo.Core.Models.Industry;

namespace Fundzo.Services.Admin.Industry
{
    public class IndustryService : IIndustryService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public IndustryService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all industries.
        /// </summary>
        /// <returns>All industries.</returns>
        public async Task<List<IndustryModel>> GetAllIndustries()
        {
            return await context.Industries.GetAllAsync();
        }

        /// <summary>
        /// Get industry by id.
        /// </summary>
        /// <param name="id">Industry id.</param>
        /// <returns>The industry with certain id.</returns>
        public async Task<IndustryModel> GetIndustryById(int id)
        {
            return await context.Industries.FindById(id);
        }
    }
}
