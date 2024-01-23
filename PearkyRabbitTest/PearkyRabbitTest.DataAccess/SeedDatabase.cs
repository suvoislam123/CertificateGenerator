using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PearkyRabbitTest.Models.Auth;
using PearkyRabbitTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.DataAccess
{
    public class SeedDatabase
    {
        public static async Task InitializeDbAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            EnsereDbMigrationAndUpdate(context);

            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager, context);
        }

        private static void EnsereDbMigrationAndUpdate(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(SD.Role_Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
            }
            
            if (!await roleManager.RoleExistsAsync(SD.Role_User))
            {
                await roleManager.CreateAsync(new IdentityRole(SD.Role_User));
            }
        }

        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            try
            {
                var admin = await userManager.GetUsersInRoleAsync(SD.Role_Admin);
                if (admin.Count == 0)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        UserName = "suvoislam123",
                        Email = "suvoislam753@gmail.com",
                        FullName = "Shuvo Islam",
                        PhoneNumber = "01309099327",
                       
                    };
                    await userManager.CreateAsync(newAdmin, "@ImsoAdmin123#");
                    await userManager.AddToRoleAsync(newAdmin, SD.Role_Admin);

                    
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
