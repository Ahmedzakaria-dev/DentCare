using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Utility
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider service)
        {
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(SD.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(SD.Admin));
            }

            if (!await roleManager.RoleExistsAsync(SD.Doctor))
            {
                await roleManager.CreateAsync(new IdentityRole(SD.Doctor));
            }

            if (!await roleManager.RoleExistsAsync(SD.Patient))
            {
                await roleManager.CreateAsync(new IdentityRole(SD.Patient));
            }
        }
    }
}