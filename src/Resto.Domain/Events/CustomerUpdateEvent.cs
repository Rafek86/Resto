namespace Resto.Domain.Events
{
    public record CustomerUpdateEvent : IBaseEvent
    {
        public string CustomerId { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
