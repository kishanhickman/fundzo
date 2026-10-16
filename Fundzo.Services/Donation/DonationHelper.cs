using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using DonationModel = Fundzo.Core.Models.Donation;
using FundraiserModel = Fundzo.Core.Models.Fundraiser;

namespace Fundzo.Services.Donation
{
    public class DonationHelper
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public DonationHelper(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets payments associated with a donation.
        /// </summary>
        /// <param name="newDonation">Model of the type Donation.</param>
        /// <returns>Payments associated with a donation.</returns>
        public async Task<List<Payment>> GetPaymentsForDontation(DonationModel newDonation)
        {
            var payments= new List<Payment>();

            return payments;
        }

        /// <summary>
        /// Converts donations currency.
        /// </summary>
        /// <param name="newDonation">Model of the type Donation.</param>
        /// <param name="newCurrencyCode">New currency code.</param>
        /// <returns>New donation.</returns>
        public async Task<DonationModel> ConvertDontationCurrency(DonationModel newDonation, string newCurrencyCode)
        {
            //  Performs below functionality:
            //
            //  - code to get payments associated with a Dontation
            //  - code to loop through and perform currency conversion through Xe.com API
            //  - code to update dontations
            //

            return newDonation;
        }

    }
}
