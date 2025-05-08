

namespace Resto.Domain.Events
{
    public record OrderStatusUpdatedEvent : IBaseEvent
    {
        public string OrderId { get; init; } = string.Empty;
        public string CustomerId { get; init; } = string.Empty;
        public string NewStatus { get; init; } = string.Empty;
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
