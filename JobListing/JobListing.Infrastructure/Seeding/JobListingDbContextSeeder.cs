using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Infrastructure.Seeding
{
    public class JobListingDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(JobListingDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger(typeof(JobListingDbContextSeeder));

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            var seeders = new List<ISeeder>
            {
                new RolesSeeder(),
                new UsersSeeder(),
                new UsersToRolesSeeder(),
                new UsersToProfilesSeeder()
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
