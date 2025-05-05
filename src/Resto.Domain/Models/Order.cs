using Resto.Domain.Common;
using Resto.Domain.Enums;
using Resto.Domain.Events;
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
        public bool IsDeleted { get; set; } = false;

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



        private Order() { }

        // Create method
        public static Order Create(string customerId, int tableNumber, decimal totalPrice, List<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                TableNumber = tableNumber,
                OrderStatus = OrderStatus.Pending, // Default status
                TotalPrice = orderItems.Sum(item => item.UnitPrice * item.Quantity),
                TimeStamp = DateTime.UtcNow,
                OrderItems = orderItems
            };

            order.AddDomainEvent(new OrderPlacedEvent
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                TotalPrice = order.TotalPrice
            });

            return order;
        }

        // Update method for status
        public void UpdateStatus(OrderStatus newStatus)
        {
            OrderStatus = newStatus;

            AddDomainEvent(new OrderStatusUpdatedEvent
            {
                OrderId = Id,
                NewStatus = newStatus.ToString()
            });
        }

        // Update method for order items
        public void UpdateOrderItems(List<OrderItem> newOrderItems)
        {
            OrderItems = newOrderItems;
            TotalPrice = OrderItems.Sum(item => item.UnitPrice * item.Quantity);

            AddDomainEvent(new OrderItemAddedEvent
            {
                OrderId = Id,
                ItemCount = newOrderItems.Count
            });
        }

        // Delete method
        public void Delete()
        {
            IsDeleted = true;
            AddDomainEvent(new OrderStatusUpdatedEvent
            {
                OrderId = Id,
                NewStatus = "Cancelled"
            });
        }
    }
}