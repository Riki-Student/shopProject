using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();

        //Task<List<Product>> GetProductByName(string productName);

        Task<List<Product>> GetProductBySearch(string? desc, int? minPrice, int? maxPrice);
    }
}