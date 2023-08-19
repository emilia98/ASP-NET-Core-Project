using JobListing.Core.Contracts;
using JobListing.Core.Models.ViewModels.UserProfile;
using JobListing.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly JobListingDbContext dbContext;

        public UserProfileService(JobListingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task GetUserAsync(string id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                // return null;
            }
        }

        public async Task<FullUserProfileViewModel?> GetUserProfileAsync(string id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            var userProfile = await dbContext.UserProfiles
                .Where(up => up.UserId == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (userProfile == null)
            {
                return null;
            }

            var model = new FullUserProfileViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                ImageUrl = userProfile.ImageUrl,
                LinkedInUrl = userProfile.LinkedInUrl,
                IsDeleted = userProfile.IsDeleted
            };

            return model;
        }
    }
}
