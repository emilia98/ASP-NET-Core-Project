using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
