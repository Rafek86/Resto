using Resto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customers { get;}
        public DbSet<Ingredient> Ingredients { get; }
        public DbSet<MenuItem> MenuItems { get; }
        public DbSet<Notification> Notifications { get; }
        public DbSet<Order> Orders { get; }
        public DbSet<OrderItem> OrderItems { get; }
        public DbSet<Reservation> Reservations { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
