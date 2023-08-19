using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobListing.Infrastructure.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = null!;

        [StringLength(150)]
        public string? ImageUrl { get; set; }

        [StringLength(150)]
        public string? LinkedInUrl { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
