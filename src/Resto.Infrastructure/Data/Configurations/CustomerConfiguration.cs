using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resto.Domain.Models;
using Resto.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Infrastructure.Data.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasMaxLength(100);    

            builder.Property(c=> c.Email)
                 .IsRequired()
                 .HasMaxLength(100);    

            builder.HasIndex(c => c.IdentityId)
                 .IsUnique();

            builder.Property(c => c.IdentityId)
                .IsRequired();


            builder.HasOne<ApplicationUser>()
                   .WithOne(au => au.Customer) 
                   .HasForeignKey<Customer>(c => c.IdentityId);

            builder.HasMany(o => o.Orders)
                          .WithOne(c => c.Customer)
                          .HasForeignKey(f => f.CustomerId);

            builder.HasMany(o => o.Reservations)
                          .WithOne(c => c.Customer)
                          .HasForeignKey(f => f.CustomerId);

            builder.HasMany(o => o.Notifications)
                          .WithOne(c => c.Customer)
                          .HasForeignKey(f => f.CustomerId);


        }
    }
}
