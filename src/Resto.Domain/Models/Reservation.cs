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
      
        
        private Reservation() { }

        // Create method
        public static Reservation Create(string customerId, int tableNumber, DateTime reservationDate, int partySize)
        {
            var reservation = new Reservation
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                TableNumber = tableNumber,
                ReservationDate = reservationDate,
                PartySize = partySize,
                TablesStatus = TablesStatus.Reserved
            };

            reservation.AddDomainEvent(new ReservationCreatedEvent
            {
                ReservationId = reservation.Id,
                CustomerId = reservation.CustomerId,
                ReservationDate = reservation.ReservationDate
            });

            return reservation;
        }

        // Update method
        public void Update(DateTime reservationDate, int partySize, TablesStatus tablesStatus)
        {
            ReservationDate = reservationDate;
            PartySize = partySize;
            TablesStatus = tablesStatus;

            //AddDomainEvent(new ReservationCreatedEvent
            //{
            //    ReservationId = Id,
            //    CustomerId = CustomerId,
            //    ReservationDate = ReservationDate
            //});
        }

        // Delete method
        public void Delete()
        {
            TablesStatus = TablesStatus.Cancelled;

            //AddDomainEvent(new ReservationCancelledEvent
            //{
            //    ReservationId = Id,
            //    CustomerId = CustomerId
            //});
        }

    }
}