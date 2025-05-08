namespace Resto.Infrastructure.Data.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasMaxLength(100);    

            builder.Property(c=> c.Email)
                 .IsRequired()
                 .HasMaxLength(100);    

            builder.HasMany(o => o.Orders)
                          .WithOne(c => c.Customer)
                          .HasForeignKey(f => f.CustomerId);

            builder.HasMany(o => o.Reservations)
                          .WithOne(c => c.Customer)
                          .HasForeignKey(f => f.CustomerId);

            builder.ToTable("Customers");

        }
    }
}
