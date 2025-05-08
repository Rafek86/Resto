using Microsoft.AspNetCore.Builder;
using Resto.Domain.Models.Identity;

namespace Resto.Infrastructure.Data.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await context.Database.MigrateAsync();
            await SeedDatabaseAsync(context, userManager);
        }

        private static async Task SeedDatabaseAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            try
            {
                await SeedUsersAsync(userManager);

                var customers = await SeedCustomersAsync(context, userManager);
                var staff = await SeedStaffAsync(context, userManager);
                var admins = await SeedAdminsAsync(context, userManager);

                await SeedIngredientsAsync(context);
                var menuItems = await SeedMenuItemsAsync(context);

                await SeedNotificationsAsync(context, customers, staff, admins);
                await SeedOrdersAsync(context, customers, menuItems);
                await SeedReservationsAsync(context, customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during database seeding: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if ((await userManager.Users.ToListAsync()).Count == 0)
            {
                foreach (var user in InitialDataSeeder.Users)
                {
                    var existingUser = await userManager.FindByEmailAsync(user.Email);
                    if (existingUser == null)
                    {
                        var result = await userManager.CreateAsync(user, "Password123!");
                        if (!result.Succeeded)
                        {
                            throw new Exception($"Failed to create user {user.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                        }
                    }
                }
            }
        }

        private static async Task<List<Customer>> SeedCustomersAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!await context.Customers.AnyAsync())
            {
                var customers = new List<Customer>();

                foreach (var customerData in InitialDataSeeder.Customers)
                {
                    var user = await userManager.FindByEmailAsync(customerData.Email);
                    if (user == null)
                    {
                        throw new Exception($"No ApplicationUser found for customer with email {customerData.Email}");
                    }

                    var customer = Customer.Create(customerData.Email, customerData.Email);
                    customer.Id = user.Id;
                    customer.UserName = user.UserName;

                    customers.Add(customer);
                }

                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();

                return customers;
            }

            return await context.Customers.ToListAsync();
        }

        private static async Task<List<Staff>> SeedStaffAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!await context.Set<Staff>().AnyAsync())
            {
                var staffMembers = new List<Staff>();

                foreach (var staffData in InitialDataSeeder.staff)
                {
                    var user = await userManager.FindByEmailAsync(staffData.Email);
                    if (user == null)
                    {
                        throw new Exception($"No ApplicationUser found for staff with email {staffData.Email}");
                    }

                    var staff = Staff.Create(staffData.Email, staffData.Email, staffData.StaffRole);
                    staff.Id = user.Id;
                    staff.UserName = user.UserName;

                    staffMembers.Add(staff);
                }

                await context.Set<Staff>().AddRangeAsync(staffMembers);
                await context.SaveChangesAsync();

                return staffMembers;
            }

            return await context.Set<Staff>().ToListAsync();
        }

        private static async Task<List<Admin>> SeedAdminsAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!await context.Set<Admin>().AnyAsync())
            {
                var adminsList = new List<Admin>();

                foreach (var adminData in InitialDataSeeder.Admins)
                {
                    var user = await userManager.FindByEmailAsync(adminData.Email);
                    if (user == null)
                    {
                        throw new Exception($"No ApplicationUser found for admin with email {adminData.Email}");
                    }

                    var admin = Admin.Create(adminData.FullName, adminData.Email);
                    admin.Id = user.Id;
                    admin.UserName = user.UserName;

                    adminsList.Add(admin);
                }

                await context.Set<Admin>().AddRangeAsync(adminsList);
                await context.SaveChangesAsync();

                return adminsList;
            }

            return await context.Set<Admin>().ToListAsync();
        }

        private static async Task SeedIngredientsAsync(ApplicationDbContext context)
        {
            if (!await context.Ingredients.AnyAsync())
            {
                await context.Ingredients.AddRangeAsync(InitialDataSeeder.Ingredients);
                await context.SaveChangesAsync();
            }
        }

        private static async Task<List<MenuItem>> SeedMenuItemsAsync(ApplicationDbContext context)
        {
            if (!await context.MenuItems.AnyAsync())
            {
                var menuItems = InitialDataSeeder.MenuItems.ToList();
                await context.MenuItems.AddRangeAsync(menuItems);
                await context.SaveChangesAsync();

                return menuItems;
            }

            return await context.MenuItems.ToListAsync();
        }

        private static async Task SeedNotificationsAsync(ApplicationDbContext context, List<Customer> customers, List<Staff> staff, List<Admin> admins)
        {
            if (!await context.Notifications.AnyAsync())
            {
                var notifications = InitialDataSeeder.GetNotifications(customers, staff, admins).ToList();
                if (notifications.Any())
                {
                    await context.Notifications.AddRangeAsync(notifications);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static async Task SeedOrdersAsync(ApplicationDbContext context, List<Customer> customers, List<MenuItem> menuItems)
        {
            if (!await context.Orders.AnyAsync())
            {
                var orders = InitialDataSeeder.GetOrdersWithItems(customers, menuItems).ToList();
                if (orders.Any())
                {
                    await context.Orders.AddRangeAsync(orders);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static async Task SeedReservationsAsync(ApplicationDbContext context, List<Customer> customers)
        {
            if (!await context.Reservations.AnyAsync())
            {
                var reservations = InitialDataSeeder.GetReservations(customers).ToList();
                if (reservations.Any())
                {
                    await context.Reservations.AddRangeAsync(reservations);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}