using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
