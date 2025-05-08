

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

        public static Order Create(string customerId, int tableNumber, decimal totalPrice, List<OrderItem> orderItems)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                TableNumber = tableNumber,
                OrderStatus = OrderStatus.Pending,
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

        public void UpdateStatus(OrderStatus newStatus)
        {
            OrderStatus = newStatus;

            //AddDomainEvent(new OrderStatusUpdatedEvent
            //{
            //    OrderId = Id,
            //    NewStatus = newStatus.ToString()
            //});
        }

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
        public void Delete()
        {
            OrderStatus = OrderStatus.Cancelled;

            AddDomainEvent(new OrderStatusUpdatedEvent
            {
                OrderId = Id,
                CustomerId = CustomerId,
                OccurredOn = DateTime.UtcNow,
                NewStatus = "Cancelled"
            });
        }
    }
}