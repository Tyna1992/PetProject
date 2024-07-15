using Microsoft.AspNetCore.Identity;
using VineyardSite.Data;
using VineyardSite.Model;
using VineyardSite.Model.Address;

namespace VineyardSite.Service.Authentication;

public class AuthSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;

    public AuthSeeder(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ApplicationDbContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }

    public void AddRoles()
    {
        var tAdmin = CreateAdminRole(_roleManager);
        tAdmin.Wait();

        var tUser = CreateUserRole(_roleManager);
        tUser.Wait();
    }

    public void AddAdmin()
    {
        var tAdmin = CreateAdminIfNotExists();
        tAdmin.Wait();
    }
    
    public void AddTestUser()
    {
        var tUser = CreateTestUserIfNotExists();
        tUser.Wait();
    }

    private async Task CreateAdminIfNotExists()
    {
        var adminInDb = await _userManager.FindByEmailAsync("admin@admin.com");
        if (adminInDb == null)
        {
            var admin = new User { UserName = "admin", Email = "admin@admin.com", PrimaryAddress = new PrimaryAddress { City = "City", Street = "Street", ZipCode = "1000", HouseNumber = "1", Country = "Hungary" } };
            var adminCreated = await _userManager.CreateAsync(admin, "admin");

            if (adminCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }

     private async Task CreateTestUserIfNotExists()
        {
            var userInDb = await _userManager.FindByEmailAsync("testUser@testUser.com");
            if (userInDb == null)
            {
                var wineVariants = _context.WineVariants.ToList();
                
                var orderItems1 = new List<OrderItem>
                {
                    new() { WineVariantId = wineVariants[0].Id, Quantity = 1, WineVariant = wineVariants[0] },
                    new() { WineVariantId = wineVariants[1].Id, Quantity = 2, WineVariant = wineVariants[1] }
                };
                
                var totalPrice1 = orderItems1.Sum(oi => oi.WineVariant.Price * oi.Quantity);

                var order1 = new Order
                {
                    OrderItems = orderItems1,
                    TotalPrice = totalPrice1,
                    Date = new DateTime(2024, 07, 10),
                    Address = "City, Street 1",
                    DeliveryType = "Delivery",
                    PaymentType = "Card",
                    Status = "Pending",
                    Notes = "Notes",
                    Email = "testUser@testUser.com",
                };

                var orderItems2 = new List<OrderItem>
                {
                    new() { WineVariantId = wineVariants[2].Id, Quantity = 1, WineVariant = wineVariants[2] },
                    new() { WineVariantId = wineVariants[3].Id, Quantity = 1, WineVariant = wineVariants[3] }
                };

                var totalPrice2 = orderItems2.Sum(oi => oi.WineVariant.Price * oi.Quantity);

                var order2 = new Order
                {
                    OrderItems = orderItems2,
                    TotalPrice = totalPrice2,
                    Date = new DateTime(2023, 12, 10),
                    Address = "City, Street 2",
                    DeliveryType = "Pickup",
                    PaymentType = "Cash",
                    Status = "Completed",
                    Notes = "Second Order Notes",
                    Email = "testUser@testUser.com",
                };

                var user = new User
                {
                    UserName = "testUser",
                    Email = "testUser@testUser.com",
                    PrimaryAddress = new PrimaryAddress
                    {
                        City = "City",
                        Street = "Street",
                        ZipCode = "1000",
                        HouseNumber = "1",
                        Country = "Hungary"
                    },
                    Addresses = new List<Address>
                    {
                        new() { City = "City", Street = "Street", ZipCode = "1000", HouseNumber = "1", Country = "Hungary" }
                    },
                    Orders = new List<Order> { order1, order2 }
                };
                var userCreated = await _userManager.CreateAsync(user, "testUser");
                
                if (userCreated.Succeeded)
                {
                    order1.UserId = user.Id;
                    order2.UserId = user.Id;
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
        }

    private async Task CreateAdminRole(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin")); 
    }

    async Task CreateUserRole(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole("User")); 
    }
}