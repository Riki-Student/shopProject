using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        ShopWebsiteContext _shopWebsiteContext;

        public OrderRepository(ShopWebsiteContext shopWebsiteContext)
        {
            _shopWebsiteContext = shopWebsiteContext;
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _shopWebsiteContext.Orders.Include(order => order.User).ToListAsync();

        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _shopWebsiteContext.Orders.FindAsync(id);
            // return await _estyWebApiContext.Products.Include(product => product.Category).FindAsync(id);
        }
        public async Task<Order> CreateOrder(Order order)
        {
            //await _shopWebsiteContext.AddAsync(order);
            await _shopWebsiteContext.Orders.AddAsync(order);
            await _shopWebsiteContext.SaveChangesAsync();
            return order;

        }
    }
}
