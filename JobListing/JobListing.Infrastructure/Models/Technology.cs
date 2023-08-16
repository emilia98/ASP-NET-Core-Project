using System.ComponentModel.DataAnnotations;

namespace JobListing.Infrastructure.Models
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}
