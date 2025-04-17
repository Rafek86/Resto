namespace Resto.Infrastructure.Data.Configurations
{
    class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                 .IsRequired()
                 .HasMaxLength(256);

            builder.HasMany(m => m.OrderItems)
                .WithOne(m => m.MenuItem)
                .HasForeignKey(m => m.MenuItemId);
        }
    }

}
