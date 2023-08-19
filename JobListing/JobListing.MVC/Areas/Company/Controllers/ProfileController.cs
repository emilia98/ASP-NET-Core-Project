using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Company.Controllers
{
    public class ProfileController : CompanyBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
