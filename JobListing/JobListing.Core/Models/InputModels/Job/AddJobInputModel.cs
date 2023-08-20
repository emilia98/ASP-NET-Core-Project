using JobListing.Core.Models.ViewModels.Technology;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Models.InputModels.Job
{
    public class AddJobInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public List<TechnologyViewModel> TechnologiesList { get; set; } = new List<TechnologyViewModel>();

        public List<int> Technologies { get; set; } = new List<int>();
    }
}
