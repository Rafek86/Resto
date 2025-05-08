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
            //builder.Ignore<ApplicationUser>();

            builder.Entity<ApplicationUser>().UseTpcMappingStrategy();

            builder.Entity<Staff>().ToTable(nameof(Staff));
            builder.Entity<Admin>().ToTable(nameof(Admin));
            

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }

}
