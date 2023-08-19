namespace JobListing.Core.Models.ViewModels.Technology
{
    public class TechnologyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
