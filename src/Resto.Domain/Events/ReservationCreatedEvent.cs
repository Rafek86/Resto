﻿
namespace Resto.Domain.Events
{
    public record ReservationCreatedEvent : IBaseEvent
    {
        public string ReservationId { get; init; } = string.Empty;
        public string CustomerId { get; init; } = string.Empty;
        public int TableNumber { get; init; }
        public DateTime ReservationDate { get; init; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
