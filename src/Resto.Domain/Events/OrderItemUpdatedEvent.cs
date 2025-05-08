
namespace Resto.Domain.Events
{
    public record OrderItemUpdatedEvent : IBaseEvent
    {
        public string OrderId { get; init; } = string.Empty;
        public int UpdatedQuantity { get; init; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
