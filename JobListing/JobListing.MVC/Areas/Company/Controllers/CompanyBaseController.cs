using JobListing.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobListing.MVC.Areas.Company.Controllers
{
    [Area(CompanySettings.AreaName)]
    [Authorize(Roles = CompanySettings.RoleName)]
    public class CompanyBaseController : Controller
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
