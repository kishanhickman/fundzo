using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IFundraiserStatusService
    {
        Task<List<FundraiserStatus>> GetAllFundraiserStatuses();
        Task<FundraiserStatus> GetFundraiserStatusById(int id);
    }
}
