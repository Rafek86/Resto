using Resto.Domain.Enums;
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
       OrderStatus OrderStatus,
       decimal TotalPrice,
       List<OrderItemDto> OrderItems
       );
}
