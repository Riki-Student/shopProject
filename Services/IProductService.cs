using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();

        //Task<List<Product>> GetProductByName(string productName);

        Task<IEnumerable<Product>> GetProductBySearch(string? desc, int? minPrice, int? maxPrice);
    }
}