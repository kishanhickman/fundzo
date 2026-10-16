using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IFundraiserMediaRepository : IRepository<FundraiserMedia>
    {
        Task<List<FundraiserMedia>> GetAllAsync();
    }
}
