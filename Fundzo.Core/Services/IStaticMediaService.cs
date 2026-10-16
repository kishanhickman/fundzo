using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface IStaticMediaService
    {
        Task<List<StaticMedia>> GetAllStaticMedias();
        Task<StaticMedia> GetStaticMediaById(int id);
        Task<StaticMedia> GetStaticMediaByName(string name);
        Task<StaticMedia> CreateStaticMedia(StaticMedia staticMedia);
        Task DeleteStaticMedia(StaticMedia staticMedia);
        Task<StaticMedia> UpdateStaticMedia(StaticMedia staticMedia);
    }
}
