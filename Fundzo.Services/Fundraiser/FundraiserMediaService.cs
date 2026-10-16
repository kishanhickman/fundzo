using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using FundraiserMediaModel = Fundzo.Core.Models.FundraiserMedia;

namespace Fundzo.Services.Fundraiser
{
    public class FundraiserMediaService : IFundraiserMediaService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public FundraiserMediaService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all fundraiser medias.
        /// </summary>
        /// <returns>All fundraiser medias.</returns>
        public async Task<List<FundraiserMediaModel>> GetAllFundraiserMedias()
        {
            return await context.FundraiserMedias.GetAllAsync();
        }

        /// <summary>
        /// Get fundraiser media by id.
        /// </summary>
        /// <param name="id">Fundraiser media id.</param>
        /// <returns>The fundraiser media with certain id.</returns>
        public async Task<FundraiserMediaModel> GetFundraiserMediaById(int id)
        {
            return await context.FundraiserMedias.FindById(id);
        }

        /// <summary>
        /// Creates a new fundraiser media.
        /// </summary>
        /// <param name="newStaticMedia">Model of the type Fundraiser Media</param>
        /// <returns>The new fundraiser media.</returns>
        public async Task<FundraiserMediaModel> CreateFundraiserMedia(FundraiserMediaModel newFundraiserMedia)
        {
            await context.FundraiserMedias.CreateAsync(newFundraiserMedia);
            await context.CommitAsync();

            return newFundraiserMedia;
        }

        /// <summary>
        /// Updated fundraiser media information.
        /// </summary>
        /// <param name="fundraiserMedia">Model of the type fundraiser media.</param>
        /// <returns>The updated fundraiser media.</returns>
        public async Task<FundraiserMediaModel> UpdateFundraiserMedia(FundraiserMediaModel fundraiserMedia)
        {
            await context.FundraiserMedias.UpdateAsync(fundraiserMedia);
            await context.CommitAsync();

            return fundraiserMedia;
        }
    }
}
