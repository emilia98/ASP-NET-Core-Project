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


        // public async Task<bool> DeleteAsync(int id, bool hardDelete = false)
        public async Task<bool> DeleteAsync(int id)
        {
            var technology = await dbContext.Technologies.FindAsync(id);

            if (technology != null)
            {
                /*
                if (technology.IsDeleted && hardDelete)
                {
                    dbContext.Technologies.Remove(technology);
                }
                else
                {
                    technology.IsDeleted = true;
                }*/

                technology.IsDeleted = !technology.IsDeleted;
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> EditAsync(int id, TechnologyEditInputModel model)
        {
            var technology = await dbContext.Technologies.FindAsync(id);

            if (technology != null && technology.IsDeleted == false)
            {
                technology.Name = model.Name;
                technology.ImageUrl = model.ImageUrl;

                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<TechnologyViewModel>> GetAllAsync(bool withDeleted = false)
        {
            var technologies = dbContext.Technologies.AsNoTracking();

            if (!withDeleted)
            {
                technologies = technologies.Where(t => t.IsDeleted == false);
            }

            return await technologies
                .Select(t => new TechnologyViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    IsDeleted = t.IsDeleted
                }).ToListAsync();
        }

        public async Task<TechnologyViewModel?> GetBtIdAsync(int id, bool withDeleted = false)
        {
            var technologies = dbContext.Technologies.AsNoTracking();

            if (!withDeleted)
            {
                technologies = technologies.Where(t => t.IsDeleted == false);
            }

            return await technologies
                .Where(t => t.Id == id)
                .Select(t => new TechnologyViewModel { Id = t.Id, Name = t.Name, ImageUrl = t.ImageUrl })
                .FirstOrDefaultAsync();
        }

        public async Task<TechnologyEditInputModel?> GetEditModelAsync(int id)
        {
            return await dbContext.Technologies.Where(t => t.IsDeleted == false && t.Id == id)
                .Select(t => new TechnologyEditInputModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
