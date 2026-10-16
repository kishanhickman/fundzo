using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using StaticMediaModel = Fundzo.Core.Models.StaticMedia;

namespace Fundzo.Services.StaticMedia
{
    public class StaticMediaService : IStaticMediaService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public StaticMediaService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all static medias.
        /// </summary>
        /// <returns>All static medias.</returns>
        public async Task<List<StaticMediaModel>> GetAllStaticMedias()
        {
            return await context.StaticMedias.GetAllAsync();
        }

        /// <summary>
        /// Get static media by id.
        /// </summary>
        /// <param name="id">Static media id.</param>
        /// <returns>The static media with certain id.</returns>
        public async Task<StaticMediaModel> GetStaticMediaById(int id)
        {
            return await context.StaticMedias.FindById(id);
        }

        /// <summary>
        /// Get static media by name.
        /// </summary>
        /// <param name="name">Static media name.</param>
        /// <returns>The static media with certain name.</returns>
        public async Task<StaticMediaModel> GetStaticMediaByName(string name)
        {
            return await context.StaticMedias.GetStaticMediaByName(name);
        }

        /// <summary>
        /// Creates a new static media.
        /// </summary>
        /// <param name="newStaticMedia">Model of the type Static Media</param>
        /// <returns>The new static media.</returns>
        public async Task<StaticMediaModel> CreateStaticMedia(StaticMediaModel newStaticMedia)
        {
            await context.StaticMedias.CreateAsync(newStaticMedia);
            await context.CommitAsync();

            return newStaticMedia;
        }

        /// <summary>
        /// Delete a static media.
        /// </summary>
        /// <param name="staticMedia">Model of the type static media.</param>
        /// <returns></returns>
        public async Task DeleteStaticMedia(StaticMediaModel staticMedia)
        {
            await context.StaticMedias.DeleteAsync(staticMedia);
            await context.CommitAsync();
        }

        /// <summary>
        /// Updated static media information.
        /// </summary>
        /// <param name="staticMedia">Model of the type static media.</param>
        /// <returns>The updated static media.</returns>
        public async Task<StaticMediaModel> UpdateStaticMedia(StaticMediaModel staticMedia)
        {
            await context.StaticMedias.UpdateAsync(staticMedia);
            await context.CommitAsync();

            return staticMedia;
        }
    }
}
