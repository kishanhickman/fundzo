using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using OrganisationModel = Fundzo.Core.Models.Organisation;

namespace Fundzo.Services.Admin.Organisation
{
    public class OrganisationService :IOrganisationService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public OrganisationService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all organisations.
        /// </summary>
        /// <returns>All organisations.</returns>
        public async Task<List<OrganisationModel>> GetAllOrganisations()
        {
            return await context.Organisations.GetAllAsync();
        }

        /// <summary>
        /// Get organisation by id.
        /// </summary>
        /// <param name="id">Organisation id.</param>
        /// <returns>The organisation with certain id.</returns>
        public async Task<OrganisationModel> GetOrganisationById(int id)
        {
            return await context.Organisations.GetOrganisationByIdAsync(id);
        }
    }
}
