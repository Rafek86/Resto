namespace Resto.Infrastructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            [
            new IdentityRole{
                   Id=DefaultRoles.AdminRoleId,
                   Name =DefaultRoles.Admin,
                   NormalizedName = DefaultRoles.Admin.ToUpper(),
                   ConcurrencyStamp = DefaultRoles.AdminRoleConcurrencyStamp,
                   },
            new IdentityRole{
                     Id = DefaultRoles.CustomerRoleId,
                     Name =DefaultRoles.Customer,
                     NormalizedName = DefaultRoles.Customer.ToUpper(),
                     ConcurrencyStamp=DefaultRoles.CustomerRoleConcurrencyStamp
                   },
            new IdentityRole{
                     Id = DefaultRoles.StaffRoleId,
                     Name =DefaultRoles.Staff,
                     NormalizedName = DefaultRoles.Staff.ToUpper(),
                     ConcurrencyStamp=DefaultRoles.StaffRoleConcurrencyStamp
                   },
            new IdentityRole{
                     Id = DefaultRoles.InventoryManagerRoleId,
                     Name =DefaultRoles.InventoryManager,
                     NormalizedName = DefaultRoles.InventoryManager.ToUpper(),
                     ConcurrencyStamp=DefaultRoles.InventoryManagerRoleConcurrencyStamp
                   }
                   ]
            );
        }
    }

}
