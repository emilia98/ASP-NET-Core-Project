using JobListing.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.Company.Controllers
{
    [Area(CompanySettings.AreaName)]
    [Authorize(Roles = CompanySettings.RoleName)]
    public class CompanyBaseController : Controller
    {
    }
}
