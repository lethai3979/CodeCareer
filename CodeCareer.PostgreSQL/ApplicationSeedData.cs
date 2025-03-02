using CodeCareer.Domain.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL
{
    public class ApplicationSeedData
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userMananger = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await SeedRolesAsync(roleManager);
            await SeedAdminAsync(userMananger, roleManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = Role.AllRoles;
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdminAsync(UserManager<IdentityUser> userManager, 
                                                RoleManager<IdentityRole> roleManager)
        {
            var users = await userManager.GetUsersInRoleAsync(Role.Admin);
            if (!users.Any())
            {
                var admin = new IdentityUser();
                var adminAccountString = "Admin01@gmail.com";
                admin.Email = admin.UserName = adminAccountString;
                await userManager.CreateAsync(admin, adminAccountString);
                await userManager.AddToRoleAsync(admin, Role.Admin);
            }
        }
    }
}
