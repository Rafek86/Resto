

namespace Resto.Domain.Events
{
    public record ReservationCancelledEvent : IBaseEvent
    {
        public string ReservationId { get; init; } = string.Empty;
        public string CustomerId { get; init; } = string.Empty;
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
