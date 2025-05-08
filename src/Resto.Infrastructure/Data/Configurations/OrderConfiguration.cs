namespace Resto.Infrastructure.Data.Configurations
{
   public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderStatus)
                .HasDefaultValue(OrderStatus.Pending)
                .HasConversion(o => o.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

            builder.HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
