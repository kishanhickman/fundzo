using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using FundraiserStatusModel = Fundzo.Core.Models.FundraiserStatus;

namespace Fundzo.Services.Fundraiser
{
    public class FundraiserStatusService : IFundraiserStatusService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public FundraiserStatusService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all fundraiser statuses.
        /// </summary>
        /// <returns>All fundraiser statuses.</returns>
        public async Task<List<FundraiserStatusModel>> GetAllFundraiserStatuses()
        {
            return await context.FundraiserStatuses.GetAllAsync();
        }

        /// <summary>
        /// Get fundraiser status by id.
        /// </summary>
        /// <param name="id">Fundraiser status id.</param>
        /// <returns>The fundraiser status with certain id.</returns>
        public async Task<FundraiserStatusModel> GetFundraiserStatusById(int id)
        {
            return await context.FundraiserStatuses.FindById(id);
        }
    }
}
