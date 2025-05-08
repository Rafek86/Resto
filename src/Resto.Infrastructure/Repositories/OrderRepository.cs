namespace Resto.Infrastructure.Repositories
{
    class OrderRepository(IApplicationDbContext context) : IOrderRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Order> _dbSet = context.Orders;

        public async Task<string> AddAsync(Order order)
        {
            _dbSet.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<string> DeleteAsync(Order order)
        {
            _dbSet.Update(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
          return  await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Where(o => o.IsDeleted == false)
                .ToListAsync();

        }

        public async Task<Order?> GetByIdAsync(string id)
        {
           return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(string customerId)
        {
           return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Where(o => o.CustomerId == customerId && o.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetPendingOrdersAsync()
        {
          return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Where(o => o.OrderStatus == OrderStatus.Pending && o.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<string> UpdateAsync(Order order)
        {
            _dbSet.Update(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
    }
}
