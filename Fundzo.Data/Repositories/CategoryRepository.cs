using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core.Models;
using Fundzo.Core.Repositories;


namespace Fundzo.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(FundzoContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}