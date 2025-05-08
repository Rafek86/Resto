
namespace Resto.Domain.Events
{
    public record IngredientLowStockEvent : IBaseEvent
    {
        public string IngredientId { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public int Unit { get; init; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
