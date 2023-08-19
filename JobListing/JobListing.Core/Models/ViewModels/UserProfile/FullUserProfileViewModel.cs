namespace JobListing.Core.Models.ViewModels.UserProfile
{
    public class FullUserProfileViewModel
    {
        public string Id { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? LinkedInUrl { get; set; }

        public string? ImageUrl { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}