using JobListing.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JobListing.Infrastructure.Seeding
{
    internal class UsersToRolesSeeder : ISeeder
    {
        public async Task SeedAsync(JobListingDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedUserToRole(dbContext, userManager, roleManager, "admin", GlobalConstants.AdministratorRoleName);
            await SeedUserToRole(dbContext, userManager, roleManager, "emilia", GlobalConstants.UserRoleName);
            await SeedUserToRole(dbContext, userManager, roleManager, "apple", GlobalConstants.CompanyRoleName);
        }

        private static async Task SeedUserToRole(JobListingDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, string userName, string roleName)
        {
            var user = await userManager.FindByNameAsync(userName);
            var role = await roleManager.FindByNameAsync(roleName);

            if (user == null || role == null)
            {
                return;
            }

            var exists = dbContext.UserRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            var result = await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            });
        }
    }
}
