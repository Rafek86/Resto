using Resto.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Domain.Events
{
    public record UserRegisteredEvent : IBaseEvent
    {
        public string CustomerId { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}
