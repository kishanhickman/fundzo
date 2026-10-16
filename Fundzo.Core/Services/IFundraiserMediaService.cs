using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IFundraiserMediaService
    {
        Task<List<FundraiserMedia>> GetAllFundraiserMedias();
        Task<FundraiserMedia> GetFundraiserMediaById(int id);
        Task<FundraiserMedia> CreateFundraiserMedia(FundraiserMedia fundraiserMedia);
        Task<FundraiserMedia> UpdateFundraiserMedia(FundraiserMedia fundraiserMedia);
    }
}
