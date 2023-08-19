using JobListing.Core.Contracts;
using JobListing.Core.Models.InputModels.Company;
using JobListing.Core.Models.ViewModels.Company;
using JobListing.Core.Models.ViewModels.UserProfile;
using JobListing.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly JobListingDbContext dbContext;

        public CompanyService(JobListingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FullCompanyProfileViewModel?> GetCompanyProfileAsync(string id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            var companyProfile = await dbContext.Companies
                .Where(c => c.CompanyUserId == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (companyProfile == null)
            {
                return null;
            }

            var model = new FullCompanyProfileViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Name = companyProfile.Name,
                Bulstat = companyProfile.Bulstat,
                LogoUrl = companyProfile.LogoUrl,
                FacebookUrl = companyProfile.FacebookUrl,
                WebsiteUrl = companyProfile.WebsiteUrl,
                LinkedInUrl = companyProfile.LinkedInUrl,
                Description = companyProfile.Description,
                IsApproved = companyProfile.IsApproved
            };

            return model;
        }

        public async Task<UpdateCompanyProfileInputModel?> GetUpdateCompanyProfileAsync(string id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            var companyProfile = await dbContext.Companies.Where(c => c.CompanyUserId == user.Id)
                .Select(c => new UpdateCompanyProfileInputModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Name = c.Name,
                    Bulstat = c.Bulstat,
                    Description = c.Description,
                    LogoUrl = c.LogoUrl,
                    FacebookUrl = c.FacebookUrl,
                    WebsiteUrl = c.WebsiteUrl,
                    LinkedInUrl = c.LinkedInUrl,
                    IsApproved = c.IsApproved
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return companyProfile;
        }

        public async Task<bool> UpdateCompanyProfileAsync(string id, UpdateCompanyProfileInputModel model)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            var companyProfile = await dbContext.Companies.Where(c => c.CompanyUserId == id).FirstOrDefaultAsync();

            if (companyProfile == null)
            {
                return false;
            }

            companyProfile.Name = model.Name;
            companyProfile.Bulstat = model.Bulstat;
            companyProfile.Description = model.Description;
            companyProfile.FacebookUrl = model.FacebookUrl;
            companyProfile.LinkedInUrl = model.LinkedInUrl;
            companyProfile.WebsiteUrl = model.WebsiteUrl;
            companyProfile.LogoUrl = model.LogoUrl;
            user.PhoneNumber = model.PhoneNumber;

            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
