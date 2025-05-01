using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Services
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetItemsForOrderAsync(string orderId);
    }
}
