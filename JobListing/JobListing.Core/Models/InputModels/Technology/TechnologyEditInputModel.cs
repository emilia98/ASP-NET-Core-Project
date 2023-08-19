using System.ComponentModel.DataAnnotations;

namespace JobListing.Core.Models.InputModels.Technology
{
    public class TechnologyEditInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Url]
        public string? ImageUrl { get; set; }
    }
}
