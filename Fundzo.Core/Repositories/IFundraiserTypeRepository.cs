using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IFundraiserTypeRepository : IRepository<FundraiserType>
    {
        Task<FundraiserType> GetFundraiserTypeByIdAsync(int id);

        Task<FundraiserType> GetFundraiserTypeByName(string name);

        Task<List<FundraiserType>> GetAllAsync();
    }
}