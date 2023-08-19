using JobListing.Core.Models.InputModels.UserProfile;
using JobListing.Core.Models.ViewModels.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Contracts
{
    public interface IUserProfileService
    {
        // Update User Profile
        Task<UpdateUserProfileInputModel?> GetUpdateUserProfileModel(string id);

        Task<bool> UpdateUserProfileAsync(string id, UpdateUserProfileInputModel model);

        // List User Profile
        Task<FullUserProfileViewModel?> GetUserProfileAsync(string id);

        // List User Files

        // Upload a user file

        // List all User Applications

        // List all User Saved Items

        // Delete User Account
    }
}
