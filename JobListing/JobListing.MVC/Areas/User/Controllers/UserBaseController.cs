using JobListing.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.User.Controllers
{
    [Area(UserSettings.AreaName)]
    [Authorize(Roles = UserSettings.RoleName)]
    public class UserBaseController : Controller
    {
    }
}
