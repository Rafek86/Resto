using Mapster;
using Resto.Application.Common.Exceptions;
using Resto.Application.Common.Interfaces;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.DTOs;
using Resto.Domain.Enums;


namespace Resto.Infrastructure.Repositories
{
    class ReservationRepository(IApplicationDbContext context) : IReservationRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Reservation> _dbSet = context.Reservations;

        public async Task<ReservationDto> AddAsync(string customerId, int tableNumber, int partySize)
        {
            var existingReservation = await _dbSet
                .FirstOrDefaultAsync(r => r.TableNumber == tableNumber && r.TablesStatus == TablesStatus.Reserved);

            if (existingReservation != null)
            {
                //TODO:://Create a Exception Type
                throw new InvalidOperationException($"Table {tableNumber} is already reserved.");
            }

            var newReservation = new Reservation
            {
                CustomerId = customerId,
                TableNumber = tableNumber,
                PartySize = partySize,
                ReservationDate = DateTime.UtcNow,
                TablesStatus = TablesStatus.Reserved
            };

            await _dbSet.AddAsync(newReservation);
            await _context.SaveChangesAsync();

            return newReservation.Adapt<ReservationDto>();
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
           return await _dbSet
                .ProjectToType<ReservationDto>()
                .ToListAsync();
        }

    public async Task<IEnumerable<ReservationDto>> GetByCustomerIdAsync(string customerId)
    {
        var reservations = await _dbSet
            .Where(r => r.CustomerId == customerId)
            .Include(r => r.Customer)
            .ToListAsync();
    
        return reservations.Adapt<IEnumerable<ReservationDto>>();
    }
     
        
        public async Task<bool> DeleteByIdAsync(string id)
        {
            var reservation = await _dbSet.FindAsync(id);

            if (reservation is null)
                return false;

            _dbSet.Remove(reservation);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<Reservation> GetByIdAsync(string id)
        {
            if (await _dbSet
              .Include(r => r.Customer)
              .FirstOrDefaultAsync(r => r.Id == id) is not { } reservation)
                throw new NotFoundException("Reservation ", id);


            return reservation;
        }

        public async Task<bool> UpdateByIdAsync(string id, ReservationDto reservation)
        {
            var existingReservation = await _dbSet.FindAsync(id);

            if (existingReservation is null)
                return false;

            // Update properties
            existingReservation.TableNumber = reservation.TableNumber;
            existingReservation.PartySize = reservation.PartySize;
            existingReservation.ReservationDate = reservation.ReservationDate;
            existingReservation.CustomerId = reservation.CustomerId;

            _dbSet.Update(existingReservation);
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
