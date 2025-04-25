using Microsoft.EntityFrameworkCore;
using Resto.Application.DTOs;
using Mapster;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces;
using Resto.Application.Common.Pagination;

namespace Resto.Infrastructure.Repositories
{
    public class CustomerRepository(IApplicationDbContext context) : ICustomerRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Customer> _dbSet = context.Customers;

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<PagedResult<Customer>> GetPagedCustomersAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
                throw new ArgumentException("Invalid page number or page size.");

            var totalItems = await _dbSet.CountAsync();
            var items = await _dbSet
                .OrderBy(c => c.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Customer>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        public async Task<string> AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<string> UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<string> DeleteAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}