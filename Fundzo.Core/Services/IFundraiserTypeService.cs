using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IFundraiserTypeService
    {
        Task<List<FundraiserType>> GetAllFundraiserTypes();
        Task<FundraiserType> GetFundraiserTypeById(int id);
    }
}
