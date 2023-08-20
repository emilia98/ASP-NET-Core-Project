using JobListing.Core.Models.ViewModels.Technology;
using JobListing.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Models.ViewModels.Job
{
    public class JobViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? CompanyLogo { get; set; }

        public string? CompanyUserId { get; set; }

        public List<TechnologyViewModel> JobTechnologies { get; set; } = new List<TechnologyViewModel>();
    }
}
