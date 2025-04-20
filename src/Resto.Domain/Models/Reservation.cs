using Resto.Domain.Common;
using Resto.Domain.Enums;

namespace Resto.Domain.Models
{
    public class Reservation : AuditableEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int TableNumber { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public int PartySize { get; set; }
        public TablesStatus TablesStatus { get; set; }
    }
}