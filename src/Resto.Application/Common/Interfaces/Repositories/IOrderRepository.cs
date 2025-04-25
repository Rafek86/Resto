using Resto.Application.DTOs;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderDto> GetByIdAsync(string Id);
        Task AddOrderAsync(string CustomerId,int TableNumber,string OrderStatus,decimal TotalPrice,List<OrderItemDto> OrderItems);
        Task<bool> UpdateAsync(OrderDto order);
        Task<bool> RemoveAsync(string Id);
    }
}
