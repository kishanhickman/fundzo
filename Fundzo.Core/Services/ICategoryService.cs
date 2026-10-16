using System.Collections.Generic;
using System.Threading.Tasks;
using Fundzo.Core.Models;

namespace Fundzo.Core.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
    }
}
