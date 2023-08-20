using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobListing.Infrastructure.Models
{
   // [Index(nameof(Bulstat), IsUnique = true)]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(11)]
        public string Bulstat { get; set; } = null!;

        [Required]
        public string CompanyUserId { get; set; } = null!;

        [ForeignKey(nameof(CompanyUserId))]
        public IdentityUser CompanyUser { get; set; } = null!;

        [Required]
        public bool IsApproved { get; set; } = false;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? LogoUrl { get; set; }

        public string? WebsiteUrl { get; set; }

        public string? LinkedInUrl { get; set; }

        public string? FacebookUrl { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
