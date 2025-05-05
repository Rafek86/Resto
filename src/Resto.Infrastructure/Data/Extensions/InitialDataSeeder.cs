using Resto.Domain.Models.Identity;
using Resto.Domain.Enums;

namespace Resto.Infrastructure.Data
{
    public static class InitialDataSeeder
    {
        public static IEnumerable<ApplicationUser> Users => new[]
        {
            new ApplicationUser { UserName = "john.doe@example.com", Email = "john.doe@example.com", EmailConfirmed = true },
            new ApplicationUser { UserName = "jane.smith@example.com", Email = "jane.smith@example.com", EmailConfirmed = true },
            new ApplicationUser { UserName = "alice.johnson@example.com", Email = "alice.johnson@example.com", EmailConfirmed = true },
            new ApplicationUser { UserName = "moataz.doe@example.com", Email = "moataz.doe@example.com", EmailConfirmed = true },
            new ApplicationUser { UserName = "johan.maradona@example.com", Email = "johan.maradona@example.com", EmailConfirmed = true },
            new ApplicationUser { UserName = "mohamed.Mohsen@example.com", Email = "mohamed.Mohsen@example.com", EmailConfirmed = true },
            new ApplicationUser { UserName = "rafek.naim@gmail.com", Email = "rafek.naim@gmail.com", EmailConfirmed = true }
        };

        public static IEnumerable<Customer> Customers => new[]
        {
            Customer.Create("John Doe", "john.doe@example.com"),
            Customer.Create("Jane Smith", "jane.smith@example.com"),
            Customer.Create("Alice Johnson", "alice.johnson@example.com")
        };

        public static IEnumerable<Staff> staff => new[]
        {
            Staff.Create("Moataz Doe", "moataz.doe@example.com", "Chef"),
            Staff.Create("Johan Maradona", "johan.maradona@example.com", "InventoryManager"),
            Staff.Create("Mohamed Mohsen", "mohamed.Mohsen@example.com", "Chef")
        };

        public static IEnumerable<Admin> Admins => new[]
        {
            Admin.Create("Rafek", "rafek.naim@gmail.com")
        };

        public static IEnumerable<Ingredient> Ingredients => new[]
        {
            Ingredient.Create("Tomato", 50, 10),
            Ingredient.Create("Cheese", 30, 5),
            Ingredient.Create("Flour", 100, 20),
            Ingredient.Create("Olive Oil", 40, 8),
            Ingredient.Create("Salt", 80, 15),
            Ingredient.Create("Pepper", 70, 12),
            Ingredient.Create("Garlic", 45, 10)
        };

        public static IEnumerable<MenuItem> MenuItems => new[]
        {
            MenuItem.Create("Margherita Pizza", "Classic pizza with tomato and cheese", 12.99m, "Main Course", true),
            MenuItem.Create("Chocolate Cake", "Rich chocolate dessert", 6.99m, "Dessert", true),
            MenuItem.Create("Caesar Salad", "Fresh salad with Caesar dressing", 8.99m, "Appetizer", true),
            MenuItem.Create("Spaghetti Bolognese", "Pasta with meat sauce", 14.99m, "Main Course", true),
            MenuItem.Create("Tiramisu", "Italian coffee-flavored dessert", 7.99m, "Dessert", true),
            MenuItem.Create("Greek Salad", "Fresh vegetables with feta cheese", 9.99m, "Appetizer", true)
        };

        public static IEnumerable<Notification> GetNotifications(IEnumerable<Customer> savedCustomers, IEnumerable<Staff> savedStaff, IEnumerable<Admin> savedAdmins)
        {
            var customers = savedCustomers.ToArray();
            var staff = savedStaff.ToArray();
            var admins = savedAdmins.ToArray();

            var notifications = new List<Notification>();

            // Add customer notifications
            if (customers.Length >= 2)
            {
                notifications.Add(Notification.Create(customers[0].Id, "Welcome to Resto! Your account is ready."));
                notifications.Add(Notification.Create(customers[1].Id, "Your order has been confirmed."));
            }

            // Add staff notifications
            if (staff.Length >= 2)
            {
                notifications.Add(Notification.Create(staff[0].Id, "New order assigned to you.", NotificationType.General));
                notifications.Add(Notification.Create(staff[1].Id, "Inventory update required.", NotificationType.General));
            }

            // Add admin notifications
            if (admins.Length >= 1)
            {
                notifications.Add(Notification.Create(admins[0].Id, "System report is available.", NotificationType.General));
            }

            // Add role-based notifications
            notifications.Add(Notification.CreateForRole(UserRole.Staff, "New recipe guidelines are available", NotificationType.General));
            notifications.Add(Notification.CreateForRole(UserRole.Staff, "Monthly inventory check required", NotificationType.General));

            return notifications;
        }

        public static IEnumerable<Order> GetOrdersWithItems(IEnumerable<Customer> savedCustomers, IEnumerable<MenuItem> savedMenuItems)
        {
            var customers = savedCustomers.ToArray();
            var menuItems = savedMenuItems.ToArray();

            if (customers.Length < 2 || menuItems.Length < 4) return Array.Empty<Order>();

            var order1Items = new List<OrderItem>
            {
                OrderItem.Create("", menuItems[0].Id, 2, menuItems[0].Price),
                OrderItem.Create("", menuItems[1].Id, 1, menuItems[1].Price)
            };
            var order1 = Order.Create(customers[0].Id, 5, 0, order1Items);
            order1Items.ForEach(item => item.OrderId = order1.Id);

            var order2Items = new List<OrderItem>
            {
                OrderItem.Create("", menuItems[2].Id, 1, menuItems[2].Price),
                OrderItem.Create("", menuItems[3].Id, 1, menuItems[3].Price)
            };
            var order2 = Order.Create(customers[1].Id, 3, 0, order2Items);
            order2Items.ForEach(item => item.OrderId = order2.Id);

            // Add a third order with more items
            if (menuItems.Length >= 6)
            {
                var order3Items = new List<OrderItem>
                {
                    OrderItem.Create("", menuItems[4].Id, 2, menuItems[4].Price),
                    OrderItem.Create("", menuItems[5].Id, 1, menuItems[5].Price),
                    OrderItem.Create("", menuItems[0].Id, 1, menuItems[0].Price)
                };
                var order3 = Order.Create(customers[2].Id, 7, 0, order3Items);
                order3Items.ForEach(item => item.OrderId = order3.Id);

                return new[] { order1, order2, order3 };
            }

            return new[] { order1, order2 };
        }

        public static IEnumerable<Reservation> GetReservations(IEnumerable<Customer> savedCustomers)
        {
            var customers = savedCustomers.ToArray();
            if (customers.Length < 2) return Array.Empty<Reservation>();

            return new[]
            {
                Reservation.Create(customers[0].Id, 5, DateTime.UtcNow.AddDays(1).AddHours(19), 4),
                Reservation.Create(customers[1].Id, 3, DateTime.UtcNow.AddDays(2).AddHours(18), 2),
                Reservation.Create(customers[2].Id, 8, DateTime.UtcNow.AddDays(3).AddHours(20), 6)
            };
        }
    }
}