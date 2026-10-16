using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using DonationStatus = Fundzo.Core.Models.DonationStatus;

namespace Fundzo.Services.Donation
{
    public class DonationStatusService : IDonationStatusService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public DonationStatusService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all donation statuses.
        /// </summary>
        /// <returns>All donation statuses.</returns>
        public async Task<List<DonationStatus>> GetAllDonationStatuses()
        {
            return await context.DonationStatuses.GetAllAsync();
        }

        /// <summary>
        /// Get donation status by id.
        /// </summary>
        /// <param name="id">Donation status id.</param>
        /// <returns>The donation status with certain id.</returns>
        public async Task<DonationStatus> GetDonationStatusById(int id)
        {
            return await context.DonationStatuses.FindById(id);
        }
    }
}
