using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Services;
using FundraiserModel = Fundzo.Core.Models.Fundraiser;


namespace Fundzo.Services.Fundraiser
{
    public class FundraiserService : IFundraiserService
    {
        private readonly IUnitOfWork context;
        public FundraiserService(IUnitOfWork context)
        {
            this.context = context;
        }

        public async Task<FundraiserModel> CreateFundraiser(FundraiserModel newFundraiser)
        {
            await context.Fundraisers.CreateAsync(newFundraiser);
            await context.CommitAsync();                    
            
            return newFundraiser;
        }   

        public async Task DeleteFundraiser(FundraiserModel fundraiser)
        {
            await context.Fundraisers.DeleteAsync(fundraiser);
            await context.CommitAsync();
        }

        public async Task<List<FundraiserModel>> GetAllFundraisers()
        {
            return await context.Fundraisers.GetAllFundraisers();
        }

        public async Task<List<FundraiserModel>> GetFundraiserByName(string name)
        {
            return await context.Fundraisers.FindByName(name);
        }

        public async Task<FundraiserModel> GetFundraiserById(int id)
        {
            return await context.Fundraisers.FindById(id);
        }

        public async Task<FundraiserModel> UpdateFundraiser(FundraiserModel fundraiser)
        {
            await context.Fundraisers.UpdateAsync(fundraiser);
            await context.CommitAsync();

            return fundraiser;
        }

    }
}
