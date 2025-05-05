using Resto.Application.Common.Interfaces.Services;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Services
{
  public  class OrderItemService : IOrderItemService
    {
        public Task<List<OrderItem>> GetItemsForOrderAsync(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
