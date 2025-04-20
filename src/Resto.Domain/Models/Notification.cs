using Resto.Domain.Common;
using System;

namespace Resto.Domain.Models
{
    public class Notification : AuditableEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string Message { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}