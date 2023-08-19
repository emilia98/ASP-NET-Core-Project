using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Models.InputModels.UserProfile
{
    public class UpdateUserProfileInputModel
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        [StringLength(150)]
        [Url]
        public string? ImageUrl { get; set; }

        [StringLength(150)]
        [Url]
        public string? LinkedInUrl { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}