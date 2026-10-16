using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using CategoryModel = Fundzo.Core.Models.Category;

namespace Fundzo.Services.Admin.Category
{
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Private database context.
        /// </summary>
        private readonly IUnitOfWork context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">Injected context.</param>
        public CategoryService(IUnitOfWork context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get list of all categories.
        /// </summary>
        /// <returns>All categories.</returns>
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            return await context.Categories.GetAllAsync();
        }

        /// <summary>
        /// Get category by id.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <returns>The category with certain id.</returns>
        public async Task<CategoryModel> GetCategoryById(int id)
        {
            return await context.Categories.FindById(id);
        }
    }
}
