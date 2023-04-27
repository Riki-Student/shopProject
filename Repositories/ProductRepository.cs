using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ShopWebsiteContext _shopWebsiteContext;

        public ProductRepository(ShopWebsiteContext shopWebsiteContext)
        {
            _shopWebsiteContext = shopWebsiteContext;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _shopWebsiteContext.Products.Include(product => product.Category).ToListAsync();

        }
        public async Task<Product> GetProductById(int id)
        {
            return await _shopWebsiteContext.Products.FindAsync(id);
            // return await _estyWebApiContext.Products.Include(product => product.Category).FindAsync(id);
        }


        //public async Task<List<Product>> GetProductByName(string productName)
        //{
        //    return await _shopWebsiteContext.Products.Where(product => product.Name.Contains(productName)).ToListAsync();

        //    //students = students.Where(s => s.LastName.Contains(searchString)
        //    //               || s.FirstMidName.Contains(searchString));
        //}

        public async Task<List<Product>> GetProductBySearch(string? desc, int? minPrice=null, int? maxPrice=null)
        {
            var query = _shopWebsiteContext.Products.Where(product =>

                (desc == null ? (true) : product.Name.Contains(desc))
                    &&
                    (minPrice == null ? (true) : product.Price > minPrice)
                    &&
                    (maxPrice == null ? (true) : product.Price < maxPrice)
        ).OrderBy(product => product.Price);

            return await query.ToListAsync();
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _shopWebsiteContext.Products.AddAsync(product);
            await _shopWebsiteContext.SaveChangesAsync();
            return product;

        }
    }
}
