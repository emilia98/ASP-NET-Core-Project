using JobListing.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobListing.MVC.Areas.User.Controllers
{
    [Area(UserSettings.AreaName)]
    [Authorize(Roles = UserSettings.RoleName)]
    public class UserBaseController : Controller
    {
        protected string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }
    }
}
