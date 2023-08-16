using System.ComponentModel.DataAnnotations;

namespace JobListing.Infrastructure.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string Flag { get; set; } = null!;

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}
