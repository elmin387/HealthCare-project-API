using HealthCare.Domain.Common;
using HealthCare.Domain.ValueObjects;
using HealthCare.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Persistance
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedData(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,
            SeedAdminModel seedAdminModel, ApplicationDbContext dbContext)
        {
            await SeedDefaultUser(userManager, roleManager, seedAdminModel);
        }

        public static async Task SeedDefaultUser(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SeedAdminModel seedAdminModel)
        {
            foreach(var role in Role.Roles)
            {
                if (roleManager.Roles.All(r => r.Name != role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            if (seedAdminModel != null
                && seedAdminModel.Super != null
                && seedAdminModel.Super.Any()
                )
            {
                foreach (string item in seedAdminModel.Super)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var superAdmin = new ApplicationUser
                        {
                            UserName = item,
                            Email = item,
                            EmailConfirmed = true,
                            RegistrationDateTime = DateTime.Now
                        };

                        if (userManager.Users.All(u => u.UserName != superAdmin.UserName))
                        {
                            await userManager.CreateAsync(superAdmin, "Password1!");
                            await userManager.AddToRolesAsync(
                                superAdmin, new[] { Role.SuperAdministrator });
                        }
                    }
                }
            }
        }
    }
}
