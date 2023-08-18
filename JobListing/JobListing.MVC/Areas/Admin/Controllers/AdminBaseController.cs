using JobListing.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Admin.Controllers
{
    [Area(AdminSettings.AreaName)]
    [Authorize(Roles = AdminSettings.RoleName)]
    // [Authorize]
    public class AdminBaseController : Controller
    {

    }
}
