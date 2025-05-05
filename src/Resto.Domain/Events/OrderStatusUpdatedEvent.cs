using Resto.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
