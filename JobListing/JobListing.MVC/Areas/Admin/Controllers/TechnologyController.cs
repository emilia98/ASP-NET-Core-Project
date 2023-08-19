using JobListing.Core.Contracts;
using JobListing.Core.Models.InputModels.Technology;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Admin.Controllers
{
    public class TechnologyController : AdminBaseController
    {
        private readonly ITechnologyService technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            this.technologyService = technologyService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await technologyService.GetAllAsync(true);
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new TechnologyAddInputModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TechnologyAddInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await technologyService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var technology = await technologyService.GetEditModelAsync(id);

            if (technology == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(technology);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TechnologyEditInputModel model)
        {
            var technology = await technologyService.GetBtIdAsync(id, false);

            if (technology == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await technologyService.EditAsync(id, model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var technology = await technologyService.GetBtIdAsync(id, true);

            if (technology == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var result = await technologyService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
