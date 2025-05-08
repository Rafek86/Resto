using Resto.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
    public class OrderStatusUpdateRequest
    {
        public OrderStatus OrderStatus { get; set; }
    }
}
