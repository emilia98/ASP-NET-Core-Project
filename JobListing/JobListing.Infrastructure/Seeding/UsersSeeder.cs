using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JobListing.Infrastructure.Seeding
{
    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(JobListingDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await SeedUserAsync(userManager, "admin", "admin@gmail.com", "Admin.1234");
            await SeedUserAsync(userManager, "emilia", "emilia@emilia.com", "User.1234");
            await SeedUserAsync(userManager, "apple", "apple@apple.com", "Company.1234");
        }

        private static async Task SeedUserAsync(UserManager<IdentityUser> userManager, string username, string email, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                var result = await userManager.CreateAsync(
                    new IdentityUser
                    {
                        UserName = username,
                        Email = email,
                        NormalizedUserName = username.ToUpper(),
                        NormalizedEmail = email.ToUpper(),
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        
                    }, password);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}