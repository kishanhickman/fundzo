using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using FundraiserTypeModel = Fundzo.Core.Models.FundraiserType;

namespace Fundzo.Services.Fundraiser
{
    public class FundraiserTypeService : IFundraiserTypeService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public FundraiserTypeService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all fundraiser types.
        /// </summary>
        /// <returns>All fundraiser types.</returns>
        public async Task<List<FundraiserTypeModel>> GetAllFundraiserTypes()
        {
            return await context.FundraiserTypes.GetAllAsync();
        }

        /// <summary>
        /// Get fundraiser type by id.
        /// </summary>
        /// <param name="id">Fundraiser type id.</param>
        /// <returns>The fundraiser type with certain id.</returns>
        public async Task<FundraiserTypeModel> GetFundraiserTypeById(int id)
        {
            return await context.FundraiserTypes.FindById(id);
        }
    }
}
