namespace Resto.Domain.Authorization
{
    public static class Permissions
    {
        public static string Type => "Permission";  

        public const string RolesRead = "roles:read";
        public const string RolesCreate = "roles:create";
        public const string RolesUpdate = "roles:update";
        public const string RolesDelete = "roles:delete";

        public const string UsersRead = "users:read";
        public const string UsersCreate = "users:create";
        public const string UsersUpdate = "users:update";
        public const string UsersDelete = "users:delete";

        public const string MenuItemsRead = "menuitems:read";
        public const string MenuItemsCreate = "menuitems:create";
        public const string MenuItemsUpdate = "menuitems:update";
        public const string MenuItemsDelete = "menuitems:delete";

        public const string OrdersRead = "orders:read";
        public const string OrdersCreate = "orders:create";
        public const string OrdersUpdate = "orders:update";
        public const string OrdersDelete = "orders:delete";
        public const string OrdersChangeStatus = "orders:changestatus";


        public const string ReservationsRead = "reservations:read";
        public const string ReservationsCreate = "reservations:create";
        public const string ReservationsUpdate = "reservations:update";
        public const string ReservationsDelete = "reservations:delete";


        public const string IngredientsRead = "ingredients:read";
        public const string IngredientsCreate = "ingredients:create";
        public const string IngredientsUpdate = "ingredients:update";
        public const string IngredientsDelete = "ingredients:delete";

        public const string NotificationsRead = "notifications:read";
        public const string NotificationsCreate = "notifications:create";
        public const string NotificationsDelete = "notifications:delete";

        public static List<string> GetAllPermissions()
        {
            return new List<string>
            {
                RolesRead, RolesCreate, RolesUpdate, RolesDelete,
                UsersRead, UsersCreate, UsersUpdate, UsersDelete,
                MenuItemsRead, MenuItemsCreate, MenuItemsUpdate, MenuItemsDelete,
                OrdersRead, OrdersCreate, OrdersUpdate, OrdersDelete, OrdersChangeStatus,
                ReservationsRead, ReservationsCreate, ReservationsUpdate, ReservationsDelete,
                IngredientsRead, IngredientsCreate, IngredientsUpdate, IngredientsDelete,
                NotificationsRead, NotificationsCreate, NotificationsDelete
            };
        }

        public static Dictionary<string, List<string>> GetDefaultRolePermissions()
        {
            return new Dictionary<string, List<string>>
            {
            
                ["Admin"] = GetAllPermissions(),

                ["Customer"] = new List<string>
                {
                    MenuItemsRead,
                    OrdersRead, OrdersCreate,
                    ReservationsRead, ReservationsCreate, ReservationsUpdate, ReservationsDelete
                },

                ["Staff"] = new List<string>
                {
                    MenuItemsRead,MenuItemsUpdate,
                    OrdersRead,OrdersCreate, OrdersUpdate, OrdersChangeStatus,
                    IngredientsRead
                },

                ["InventoryManager"] = new List<string>
                {
                    IngredientsRead, IngredientsCreate, IngredientsUpdate, IngredientsDelete,
                    MenuItemsRead
                }
            };
        }
    }
}
