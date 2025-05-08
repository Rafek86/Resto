namespace Resto.Infrastructure.Repositories
{
    class ReservationRepository(IApplicationDbContext context) : IReservationRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Reservation> _dbSet = context.Reservations;

        public async Task<string> AddAsync(Reservation reservation)
        { 
            await _dbSet.AddAsync(reservation);
            await _context.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
           return await _dbSet
                .ToListAsync();
        }

    public async Task<IEnumerable<Reservation>> GetByCustomerIdAsync(string customerId)
    {
        var reservations = await _dbSet
            .Where(r => r.CustomerId == customerId)
            .OrderBy(x=> x.ReservationDate)
            .Include(r => r.Customer)
            .ToListAsync();
    
        return reservations;
    }
     
        
        public async Task<string> DeleteByIdAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation.Id;
        }



        public async Task<Reservation> GetByIdAsync(string id)
        {
          return await _dbSet
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<string> UpdateByIdAsync(Reservation reservation)
        {
            _dbSet.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation.Id;
        }


    }
}
