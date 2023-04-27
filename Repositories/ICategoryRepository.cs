using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
    }
}