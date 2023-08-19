using JobListing.Core.Contracts;
using JobListing.Core.Models.InputModels.Company;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Company.Controllers
{
    public class ProfileController : CompanyBaseController
    {
        private readonly ICompanyService companyService;
        private readonly string RedirectUrl = "Company/Home";

        public ProfileController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public async Task<IActionResult> Index(string? username)
        {
            if (username != null && username != User?.Identity?.Name)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            var model = await companyService.GetCompanyProfileAsync(userId);

            if (model == null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId) || userId != id)
            {
                return RedirectToAction();
            }

            var model = await companyService.GetUpdateCompanyProfileAsync(userId);

            if (model == null)
            {
                return RedirectToAction();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UpdateCompanyProfileInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUserId = GetUserId();

            if (currentUserId != id)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            var result = await companyService.UpdateCompanyProfileAsync(id, model);

            if (!result)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            return RedirectToAction(nameof(Index), "Profile", new { id = currentUserId });
        }
    }
}
