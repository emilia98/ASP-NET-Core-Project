using JobListing.Core.Contracts;
using JobListing.Core.Models.InputModels.Job;
using JobListing.Core.Models.ViewModels.Job;
using JobListing.Core.Models.ViewModels.Technology;
using JobListing.Infrastructure;
using JobListing.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobListing.Core.Services
{
    public class JobService : IJobService
    {
        private readonly JobListingDbContext dbContext;

        public JobService(JobListingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddAsync(int companyId, AddJobInputModel model)
        {
            var job = new Job
            {
                Title = model.Title,
                Description = model.Description,
                CompanyId = companyId
            };

            await dbContext.Jobs.AddAsync(job);
            await dbContext.SaveChangesAsync();

            foreach (var technologyId in model.Technologies)
            {
                var technology = await dbContext.Technologies.FindAsync(technologyId);

                if (technology != null)
                {
                    await dbContext.JobsTechnologies.AddAsync(new JobTechnology
                    {
                        JobId = job.Id,
                        TechnologyId = technologyId
                    });
                }
            }

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<JobViewModel>> GetAllAsync(string companyId)
        {
            var company = await dbContext.Companies.Where(c => c.CompanyUserId == companyId).FirstOrDefaultAsync();

            if (company == null)
            {
                return new List<JobViewModel>();
            }

            var jobs = dbContext.Jobs.AsNoTracking();

            if (companyId != null)
            {
                jobs = jobs.Where(j => j.CompanyId == company.Id);
            }

            foreach(var j in jobs)
            {
                var technologies = j.JobTechnologies.Select(t => new TechnologyViewModel { Id = t.Technology.Id, Name = t.Technology.Name, ImageUrl = t.Technology.ImageUrl });
            }

            return jobs.Select(j => new JobViewModel
                {
                    CompanyName = company.Name,
                    CompanyLogo = company.LogoUrl,
                    CompanyUserId = company.CompanyUserId,
                    Id = j.Id,
                    Title = j.Title,
                    JobTechnologies = j.JobTechnologies.Select(t => new TechnologyViewModel { Id = t.Technology.Id, Name = t.Technology.Name, ImageUrl = t.Technology.ImageUrl }).ToList()
        });
        }
    }
}
