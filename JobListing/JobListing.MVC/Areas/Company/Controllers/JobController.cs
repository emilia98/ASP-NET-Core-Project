using JobListing.Core.Contracts;
using JobListing.Core.Models.InputModels.Job;
using JobListing.Core.Models.ViewModels.Technology;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Company.Controllers
{
    public class JobController : CompanyBaseController
    {
        private readonly IJobService jobService;
        private readonly ITechnologyService technologyService;
        private readonly ICompanyService companyService;

        public JobController(IJobService jobService, ITechnologyService technologyService, ICompanyService companyService)
        {
            this.jobService = jobService;
            this.technologyService = technologyService;
            this.companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var companyId = GetUserId();
            var jobs = await jobService.GetAllAsync(companyId);
            return View(jobs);
        }

        public async Task<IActionResult> Add()
        {
            var technologies = await technologyService.GetAllAsync(false);
            var model = new AddJobInputModel
            {
                TechnologiesList = (technologies.ToList() ?? new List<TechnologyViewModel>())
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJobInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var technologies = await technologyService.GetAllAsync(false);
                model.TechnologiesList = technologies.ToList();
                return View(model);
            }

            var userId = GetUserId();
            var companyId = await companyService.GetCompanyId(userId);

            if (companyId == null)
            {
                return RedirectToAction(nameof(Index), "Job");
            }

            var result = await jobService.AddAsync(companyId.Value, model);

            return RedirectToAction(nameof(Index), "Job");
        }
    }
}
