namespace Resto.Domain.Authorization;

public static class DefaultRoles
{
    public const string Admin = nameof(Admin);
    public const string AdminRoleId = "e4419a69-dc03-4e19-a1d4-6788d831019e";

    public const string Customer = nameof(Customer);
    public const string CustomerRoleId = "7bebef86-eb86-403c-a5ff-2783eb0092ce";

    public const string Staff = nameof(Staff);
    public const string StaffRoleId = "f3b0c5a1-2d4e-4b8f-9a7d-6c3e0f1b5c8d";

    public const string InventoryManager = nameof(InventoryManager);
    public const string InventoryManagerRoleId = "b1c5f3a2-4d8e-4b8f-9a7d-6c3e0f1b5c8d";

    public const string AdminRoleConcurrencyStamp = "624a4579-bf89-4f17-919d-90de7a3b980a";
    public const string CustomerRoleConcurrencyStamp = "a47b96b1-f167-4132-bbac-24bea93478e8";
    public const string StaffRoleConcurrencyStamp = "f3b0c5a1-2d4e-4b8f-9a7d-6c3e0f1b5c8d";
    public const string InventoryManagerRoleConcurrencyStamp = "b1c5f3a2-4d8e-4b8f-9a7d-6c3e0f1b5c8d";
}
