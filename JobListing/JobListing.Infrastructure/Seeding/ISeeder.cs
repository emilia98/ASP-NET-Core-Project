namespace JobListing.Infrastructure.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(JobListingDbContext dbContext, IServiceProvider serviceProvider);
    }
}
