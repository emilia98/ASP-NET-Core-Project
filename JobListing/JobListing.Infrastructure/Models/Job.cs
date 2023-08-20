using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobListing.Infrastructure.Models
{
    public class Job
    {
        // Id (string)
        public int Id { get; set; }

        // Title [120]
        [Required]
        [MaxLength(120)]
        public string Title { get; set; } = null!;

        // Description [1000]
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        // CompanyId
        [Required]
        public int CompanyId { get; set; }

        // Company
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; } = null!;

        public ICollection<JobTechnology> JobTechnologies { get; set; } = new List<JobTechnology>();
    }
}
