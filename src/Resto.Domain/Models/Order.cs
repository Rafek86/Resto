using Resto.Domain.Common;
using Resto.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Resto.Domain.Models
{
    public class Order : AuditableEntity
    {
        public string CustomerId { get; set; } 
        public Customer Customer { get; set; } = null!;
        public int TableNumber { get; set; }
        public OrderStatus OrderStatus { get; set; } 
        public decimal TotalPrice { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}