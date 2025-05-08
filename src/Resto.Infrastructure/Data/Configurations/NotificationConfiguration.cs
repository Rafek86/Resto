namespace Resto.Infrastructure.Data.Configurations
{
   public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(n=> n.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(n => n.TargetRole)
                .HasConversion(n=>n.ToString(), dbR =>(UserRole)Enum.Parse(typeof(UserRole), dbR));

            builder.Property(n => n.Type)
                .HasConversion(n => n.ToString(), dbR => (NotificationType)Enum.Parse(typeof(NotificationType), dbR));
        }
    }
}
