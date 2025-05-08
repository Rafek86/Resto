

namespace Resto.Domain.Events
{
    public record OrderItemAddedEvent : IBaseEvent
    {
        public string OrderId { get; init; } = string.Empty;
        public int ItemCount { get; init; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
