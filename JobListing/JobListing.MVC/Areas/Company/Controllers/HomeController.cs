using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Company.Controllers
{
    public class HomeController : CompanyBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
