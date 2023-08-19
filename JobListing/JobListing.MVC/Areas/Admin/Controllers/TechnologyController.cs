using JobListing.Core.Models.InputModels.Technology;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Admin.Controllers
{
    public class TechnologyController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = new TechnologyAddInputModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TechnologyAddInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
