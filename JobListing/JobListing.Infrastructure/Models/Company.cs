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
    }
}
