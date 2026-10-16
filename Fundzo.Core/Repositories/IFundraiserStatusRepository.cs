using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IFundraiserStatusRepository : IRepository<FundraiserStatus>
    {
        Task<FundraiserStatus> GetFundraiserStatusByIdAsync(int id);

        Task<FundraiserStatus> GetFundraiserStatusByName(string name);

        Task<List<FundraiserStatus>> GetAllAsync();
    }
}