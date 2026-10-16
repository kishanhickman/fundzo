using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IIndustryService
    {
        Task<List<Industry>> GetAllIndustries();
        Task<Industry> GetIndustryById(int id);
    }
}
