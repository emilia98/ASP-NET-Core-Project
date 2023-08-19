using JobListing.Core.Contracts;
using JobListing.Core.Models.InputModels.Technology;
using JobListing.Core.Models.ViewModels.Technology;
using JobListing.Infrastructure;
using JobListing.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobListing.Core.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly JobListingDbContext dbContext;

        public TechnologyService(JobListingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(TechnologyAddInputModel model)
        {
            var technology = new Technology
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl ?? null
            };
            
            await dbContext.Technologies.AddAsync(technology);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TechnologyViewModel>> GetAllAsync(bool withDeleted = false)
        {
            return await dbContext.Technologies.Where(t => t.IsDeleted == !withDeleted)
                .Select(t => new TechnologyViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    IsDeleted = t.IsDeleted
                }).ToListAsync();
        }
    }
}
