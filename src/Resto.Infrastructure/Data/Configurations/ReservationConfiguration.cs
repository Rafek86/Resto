namespace Resto.Infrastructure.Data.Configurations
{
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.TablesStatus)
                  .HasConversion(r => r.ToString(),
                  dbR => (TablesStatus)Enum.Parse(typeof(TablesStatus), dbR));
        }
    }
}
