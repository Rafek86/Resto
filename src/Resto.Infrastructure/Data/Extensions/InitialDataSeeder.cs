using Resto.Infrastructure.Data;

public static class InitialDataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Customers.Any())
        {
            // Seed Customer
            var customerId = Guid.NewGuid();
            var customer = new Customer
            {
                Id = customerId,
                Name = "Ali Hossam",
                Email = "ali.hossam@example.com",
                IdentityId = "user-123" // link to IdentityUser
            };

            // Seed Ingredients
            var ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomato",
                    Unit = 100,
                    RecordThreshold = 20
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheese",
                    Unit = 50,
                    RecordThreshold = 10
                }
            };

            // Seed MenuItems
            var menuItem1 = new MenuItem
            {
                Id = Guid.NewGuid(),
                Name = "Margherita Pizza",
                Description = "Classic cheese and tomato pizza",
                Price = 89.99m,
                Category = "Main Course",
                IsAvailable = true
            };

            var menuItem2 = new MenuItem
            {
                Id = Guid.NewGuid(),
                Name = "Greek Salad",
                Description = "Fresh salad with feta cheese and olives",
                Price = 49.99m,
                Category = "Appetizers",
                IsAvailable = true
            };

            // Seed Order and OrderItems
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                TableNumber = 3,
                OrderStatus = Resto.Domain.Enums.OrderStatus.Completed,
                TotalPrice = 139.98m,
                TimeStamp = DateTime.UtcNow
            };

            var orderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    MenuItemId = menuItem1.Id,
                    Quantity = 1,
                    UnitPrice = menuItem1.Price
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    MenuItemId = menuItem2.Id,
                    Quantity = 1,
                    UnitPrice = menuItem2.Price
                }
            };

            // Seed Reservation
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                TableNumber = 3,
                ReservationDate = DateTime.UtcNow.AddDays(1),
                PartySize = 2,
                TablesStatus = Resto.Domain.Enums.TablesStatus.Reserved
            };

            // Seed Notification
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                Message = "Your table is confirmed for tomorrow at 7 PM.",
                TimeStamp = DateTime.UtcNow
            };

            // Add entities
            context.Customers.Add(customer);
            context.Ingredients.AddRange(ingredients);
            context.MenuItems.AddRange(menuItem1, menuItem2);
            context.Orders.Add(order);
            context.OrderItems.AddRange(orderItems);
            context.Reservations.Add(reservation);
            context.Notifications.Add(notification);

            await context.SaveChangesAsync();
        }
    }
}
