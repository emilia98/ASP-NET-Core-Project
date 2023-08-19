using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Models.ViewModels.Technology
{
    public class TechnologyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
