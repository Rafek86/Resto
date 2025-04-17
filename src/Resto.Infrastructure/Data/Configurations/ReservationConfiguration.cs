using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resto.Domain.Enums;

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
