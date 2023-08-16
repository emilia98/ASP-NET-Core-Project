using JobListing.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobListing.Infrastructure
{
    public class JobListingDbContext : DbContext
    {
        public JobListingDbContext(DbContextOptions<JobListingDbContext> options)
            : base(options)
        { }

        public DbSet<Technology> Technologies { get; set; }

        public DbSet<Language> Languages { get; set; }
    }
}
