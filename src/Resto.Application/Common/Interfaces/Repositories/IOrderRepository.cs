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
        Task<Order?> GetByIdAsync(string id);
        Task<string> AddAsync(Order order);
        Task<string> UpdateAsync(Order order);
        Task<string> DeleteAsync(Order order);

        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId);
        Task<IEnumerable<Order>> GetPendingOrdersAsync();
    }
}
