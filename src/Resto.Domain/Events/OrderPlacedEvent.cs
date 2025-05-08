
namespace Resto.Domain.Events
{
    public record OrderPlacedEvent : IBaseEvent
    {
        public string OrderId { get; init; } = string.Empty;
        public string CustomerId { get; init; } = string.Empty;
        public decimal TotalPrice { get; init; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
