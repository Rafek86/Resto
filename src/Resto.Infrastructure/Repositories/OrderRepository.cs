using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Infrastructure.Repositories
{
    class OrderRepository : IOrderRepository
    {
        public Task AddOrderAsync(string CustomerId, int TableNumber, string OrderStatus, decimal TotalPrice, List<OrderItemDto> OrderItems)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(OrderDto order)
        {
            throw new NotImplementedException();
        }
    }
}
