using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(Category category);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
    }
}