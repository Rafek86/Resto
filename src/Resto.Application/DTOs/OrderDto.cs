using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
   public record OrderDto(
       string Id,
       string CustomerId,
       int TableNumber,
       string OrderStatus,
       decimal TotalPrice,
       List<OrderItemDto> OrderItems
       );
}
