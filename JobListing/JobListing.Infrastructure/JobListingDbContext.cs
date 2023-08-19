using JobListing.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobListing.Infrastructure
{
    public class JobListingDbContext : IdentityDbContext<IdentityUser>
    {
        public JobListingDbContext(DbContextOptions<JobListingDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Technology> Technologies { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
