using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ShopWebsiteContext _shopWebsiteContext;

        public CategoryRepository(ShopWebsiteContext shopWebsiteContext)
        {
            _shopWebsiteContext = shopWebsiteContext;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _shopWebsiteContext.Categories.ToListAsync();

        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _shopWebsiteContext.Categories.FindAsync(id);

        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _shopWebsiteContext.Categories.AddAsync(category);
            await _shopWebsiteContext.SaveChangesAsync();
            return category;

        }
    }
}
