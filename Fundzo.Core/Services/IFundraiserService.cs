using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IFundraiserService
    {
        Task<Fundraiser> CreateFundraiser(Fundraiser newFundraiser);
        Task DeleteFundraiser(Fundraiser fundraiser);
        Task<List<Fundraiser>> GetAllFundraisers();
        Task<List<Fundraiser>> GetFundraiserByName(string name);
        Task<Fundraiser> GetFundraiserById(int id);
        Task<Fundraiser> UpdateFundraiser(Fundraiser fundraiser);
    }
}