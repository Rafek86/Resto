namespace Resto.Infrastructure.Data.Configurations
{
   public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(n=> n.Message)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
