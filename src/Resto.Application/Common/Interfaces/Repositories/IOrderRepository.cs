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
        Task<string> AddOrderAsync(string customerName, string orderDetails, decimal totalAmount);
        Task<string> UpdateOrderAsync(int orderId, string orderDetails, decimal totalAmount);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
