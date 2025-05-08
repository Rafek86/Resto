using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultRolesAndRolesClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7bebef86-eb86-403c-a5ff-2783eb0092ce", "a47b96b1-f167-4132-bbac-24bea93478e8", "Customer", "CUSTOMER" },
                    { "b1c5f3a2-4d8e-4b8f-9a7d-6c3e0f1b5c8d", "b1c5f3a2-4d8e-4b8f-9a7d-6c3e0f1b5c8d", "InventoryManager", "INVENTORYMANAGER" },
                    { "e4419a69-dc03-4e19-a1d4-6788d831019e", "624a4579-bf89-4f17-919d-90de7a3b980a", "Admin", "ADMIN" },
                    { "f3b0c5a1-2d4e-4b8f-9a7d-6c3e0f1b5c8d", "f3b0c5a1-2d4e-4b8f-9a7d-6c3e0f1b5c8d", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "roles:read", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 2, "Permission", "roles:create", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 3, "Permission", "roles:update", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 4, "Permission", "roles:delete", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 5, "Permission", "users:read", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 6, "Permission", "users:create", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 7, "Permission", "users:update", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 8, "Permission", "users:delete", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 9, "Permission", "menuitems:read", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 10, "Permission", "menuitems:create", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 11, "Permission", "menuitems:update", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 12, "Permission", "menuitems:delete", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 13, "Permission", "orders:read", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 14, "Permission", "orders:create", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 15, "Permission", "orders:update", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 16, "Permission", "orders:delete", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 17, "Permission", "orders:changestatus", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 18, "Permission", "reservations:read", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 19, "Permission", "reservations:create", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 20, "Permission", "reservations:update", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 21, "Permission", "reservations:delete", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 22, "Permission", "ingredients:read", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 23, "Permission", "ingredients:create", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 24, "Permission", "ingredients:update", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 25, "Permission", "ingredients:delete", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 26, "Permission", "notifications:read", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 27, "Permission", "notifications:create", "e4419a69-dc03-4e19-a1d4-6788d831019e" },
                    { 28, "Permission", "notifications:delete", "e4419a69-dc03-4e19-a1d4-6788d831019e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bebef86-eb86-403c-a5ff-2783eb0092ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1c5f3a2-4d8e-4b8f-9a7d-6c3e0f1b5c8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b0c5a1-2d4e-4b8f-9a7d-6c3e0f1b5c8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4419a69-dc03-4e19-a1d4-6788d831019e");
        }
    }
}
