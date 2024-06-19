using Microsoft.AspNetCore.Identity;
using VineyardSite.Model;
using VineyardSite.Model.Address;

namespace VineyardSite.Service.Authentication;

public class AuthSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> userManager;

    public AuthSeeder(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        this._roleManager = roleManager;
        this.userManager = userManager;
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

    private async Task CreateAdminIfNotExists()
    {
        var adminInDb = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminInDb == null)
        {
            var admin = new User { UserName = "admin", Email = "admin@admin.com", PrimaryAddress = new PrimaryAddress { City = "City", Street = "Street", ZipCode = "1000", HouseNumber = "1", Country = "Hungary" } };
            var adminCreated = await userManager.CreateAsync(admin, "admin");

            if (adminCreated.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
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