using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IOrganisationRepository : IRepository<Organisation>
    {
        Task<Organisation> GetOrganisationByIdAsync(int id);

        Task<Organisation> GetOrganisationByName(string name);

        Task<List<Organisation>> GetAllAsync();
    }
}