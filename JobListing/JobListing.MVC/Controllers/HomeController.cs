using JobListing.Core.Contracts;
using JobListing.Core.Services;
using JobListing.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace JobListing.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService jobService;

        public HomeController(ILogger<HomeController> logger, IJobService jobService)
        {
            _logger = logger;
            this.jobService = jobService;
        }

        protected string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }

        public async Task<IActionResult> Index()
        {
            var companyId = GetUserId();
            var jobs = await jobService.GetAllAsync(companyId);
            ViewData["CurrentUserId"] = companyId;
            return View(jobs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}