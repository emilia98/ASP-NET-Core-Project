using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Models.ViewModels.Company
{
    public class FullCompanyProfileViewModel
    {
        public string Id { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Bulstat { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? LogoUrl { get; set; }

        public string? LinkedInUrl { get; set; }

        public string? WebsiteUrl { get; set; }

        public string? FacebookUrl { get; set; }

        public string? Description { get; set; }

        public bool IsApproved { get; set; }
    }
}






