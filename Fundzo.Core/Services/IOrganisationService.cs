using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IOrganisationService
    {
        Task<List<Organisation>> GetAllOrganisations();
        Task<Organisation> GetOrganisationById(int id);
    }
}
