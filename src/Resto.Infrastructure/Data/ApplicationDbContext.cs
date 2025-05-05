using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resto.Application.Common.Interfaces;
using Resto.Domain.Common;
using Resto.Domain.Models;
using Resto.Domain.Models.Identity;
using System.Reflection.Emit;


namespace Resto.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser, IdentityRole, string>(options) ,IApplicationDbContext
    {
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }  
        public DbSet<Notification> Notifications { get; set; }      
        public DbSet<Order> Orders { get; set; }    
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<IBaseEvent>();
            builder.Ignore<ApplicationUser>();


            builder.Entity<Staff>().ToTable(nameof(Staff)).UseTpcMappingStrategy();
            builder.Entity<Admin>().ToTable(nameof(Admin)).UseTpcMappingStrategy();
            

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }

}
