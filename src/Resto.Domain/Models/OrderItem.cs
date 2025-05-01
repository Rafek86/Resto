using Resto.Domain.Common;
using Resto.Domain.Events;
using System;

namespace Resto.Domain.Models
{
    public class OrderItem : AuditableEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public string MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; } = false;


        private OrderItem() { }

        // Create method
        public static OrderItem Create(string orderId, string menuItemId, int quantity, decimal unitPrice)
        {
            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid().ToString(),
                OrderId = orderId,
                MenuItemId = menuItemId,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            orderItem.AddDomainEvent(new OrderItemAddedEvent
            {
                OrderId = orderItem.OrderId,
                ItemCount = 1
            });

            return orderItem;
        }

        // Update method
        public void Update(int quantity, decimal unitPrice)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;

            AddDomainEvent(new OrderItemUpdatedEvent
            {
                OrderId = OrderId,
                UpdatedQuantity = Quantity
            });
        }

        // Delete method
        public void Delete()
        {
            IsDeleted = true;
        }

    }
}