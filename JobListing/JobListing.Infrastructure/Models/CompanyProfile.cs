using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobListing.Infrastructure.Models
{
    public class CompanyProfile
    {
        [Key]
        public int Id { get; set; }

        

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; } = null!;
    }
}
