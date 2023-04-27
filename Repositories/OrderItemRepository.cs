﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        ShopWebsiteContext _shopWebsiteContext;

        public OrderItemRepository(ShopWebsiteContext shopWebsiteContext)
        {
            _shopWebsiteContext = shopWebsiteContext;
        }
        public async Task<List<OrderItem>> GetOrderItems()
        {
            return await _shopWebsiteContext.OrderItems.Include(orderItem => orderItem.Product).Include(orderItem => orderItem.Order).ToListAsync();

        }
        public async Task<OrderItem> GetOrderItemByOrderId(int orderId)
        {
            return await _shopWebsiteContext.OrderItems.FindAsync(orderId);
            // return await _estyWebApiContext.OrderItems.Include(orderItem => orderItem.Product).Include(orderItem=> orderItem.Order).FindAsync(orderId);
        }
        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            await _shopWebsiteContext.AddAsync(orderItem);
            await _shopWebsiteContext.SaveChangesAsync();
            return orderItem;

        }
    }
}
