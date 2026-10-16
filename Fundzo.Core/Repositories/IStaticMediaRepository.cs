using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IStaticMediaRepository : IRepository<StaticMedia>
    {
        Task<StaticMedia> GetStaticMediaByName(string name);

        Task<List<StaticMedia>> GetAllAsync();
    }
}
