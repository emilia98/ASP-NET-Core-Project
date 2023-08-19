using JobListing.Common;
using JobListing.Infrastructure.Seeding;
using JobListing.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobListing.Infrastructure.Models;

namespace JobListing.Infrastructure.Seeding
{
    internal class UsersToProfilesSeeder : ISeeder
    {
        public async Task SeedAsync(JobListingDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await SeedUserToUserProfile(dbContext, userManager, "admin", "Admin", "Admin");
            await SeedUserToUserProfile(dbContext, userManager, "emilia", "Emilia", "");
            // seed company user profile
        }


        private static async Task SeedUserToUserProfile(JobListingDbContext dbContext, UserManager<IdentityUser> userManager, string userName, string firstName, string lastName)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return;
            }

            var exists = dbContext.UserProfiles.Any(up => up.UserId == user.Id);

            if (exists)
            {
                return;
            }

            var result = await dbContext.UserProfiles.AddAsync(new UserProfile
            {
                FirstName = firstName,
                LastName = lastName,
                ImageUrl = null,
                LinkedInUrl = null,
                IsDeleted = false,
                UserId = user.Id
            });
        }
    }
}