using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using DonationModel = Fundzo.Core.Models.Donation;
using FundraiserModel = Fundzo.Core.Models.Fundraiser;

namespace Fundzo.Services.Donation
{
    public class DonationService : IDonationService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public DonationService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new donation.
        /// </summary>
        /// <param name="newDonation">Model of the type Donation.</param>
        /// <returns>The new donation.</returns>
        public async Task<DonationModel> CreateDonation(DonationModel newDonation)
        {
            await context.Donations.CreateAsync(newDonation);
            await context.CommitAsync();                    
            
            return newDonation;
        }   

        /// <summary>
        /// Delete a donation.
        /// </summary>
        /// <param name="donation">Model of the type donation.</param>
        /// <returns></returns>
        public async Task DeleteDonation(DonationModel donation)
        {
            await context.Donations.DeleteAsync(donation);
            await context.CommitAsync();
        }

        /// <summary>
        /// Get list of all donations.
        /// </summary>
        /// <returns>All donations.</returns>
        public async Task<List<DonationModel>> GetAllDonations()
        {
            return await context.Donations.GetAllAsync();
        }

        /// <summary>
        /// Get donation by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The donations for certain user.</returns>
        public async Task<List<DonationModel>> GetDonationsByUser(Guid user)
        {
            return await context.Donations.GetByUser(user);
        }

        /// <summary>
        /// Get donation by fundraiser.
        /// </summary>
        /// <param name="fundraiser">Model of the type fundraiser.</param>
        /// <returns>The donations for certain fundraiser.</returns>
        public async Task<List<DonationModel>> GetDonationsByFundraiser(FundraiserModel fundraiser)
        {
            return await context.Donations.GetByFundraiser(fundraiser.Id);
        }

        /// <summary>
        /// Get donation by id.
        /// </summary>
        /// <param name="id">Donation id.</param>
        /// <returns>The donation with certain id.</returns>
        public async Task<DonationModel> GetDonationById(int id)
        {
            return await context.Donations.FindById(id);
        }

        /// <summary>
        /// Updated donation information.
        /// </summary>
        /// <param name="donation">Model of the type donation.</param>
        /// <returns>The updated donation.</returns>
        public async Task<DonationModel> UpdateDonation(DonationModel donation)
        {
            await context.Donations.UpdateAsync(donation);
            await context.CommitAsync();

            return donation;
        }
    }
}
