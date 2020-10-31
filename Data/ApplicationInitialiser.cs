using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public static class ApplicationInitialiser
{
    private const string ADMIN_ROLE = "Admin";

    public static async Task Initialise(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // ensure there is a ADMIN_ROLE if not create one
        IdentityRole adminRole = await roleManager.FindByNameAsync(ADMIN_ROLE);

        if (adminRole == null)
        {
            await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
        }

        // Ensure a user named admin@test.com is an Admin
        var user = await userManager.FindByEmailAsync("admin@test.com");

        if (user != null)
        {
            bool userIsAdmin = await userManager.IsInRoleAsync(user, ADMIN_ROLE);

            if (!userIsAdmin)
            {
                await userManager.AddToRoleAsync(user, ADMIN_ROLE);
            }
        }
    }
}