using System.ComponentModel.DataAnnotations.Schema;

namespace JobListing.Infrastructure.Models
{
    public class JobTechnology
    {
        public int JobId { get; set; }

        [ForeignKey(nameof(JobId))]
        public Job Job { get; set; } = null!;

        public int TechnologyId { get; set; }

        [ForeignKey(nameof(TechnologyId))]
        public Technology Technology { get; set; } = null!;

    }
}
