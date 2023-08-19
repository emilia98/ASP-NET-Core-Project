using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Models.InputModels.Company
{
    public class UpdateCompanyProfileInputModel
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(11)]
        public string Bulstat { get; set; } = null!;

        [Required]
        public bool IsApproved { get; set; } = false;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Url]
        public string? LogoUrl { get; set; }

        [Url]
        public string? WebsiteUrl { get; set; }

        [Url]
        public string? LinkedInUrl { get; set; }

        [Url]
        public string? FacebookUrl { get; set; }
    }
}