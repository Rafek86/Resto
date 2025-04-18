using Resto.Domain.Common;
using System;

namespace Resto.Domain.Models
{
    public class OrderItem : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public Guid MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}