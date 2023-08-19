using JobListing.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JobListing.MVC.Areas.User.Controllers
{
    public class ProfileController : UserBaseController
    {
        private readonly IUserProfileService userProfileService;
        private readonly string RedirectUrl = "User/Home";

        public ProfileController(IUserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        public async Task<IActionResult> Index(string? username)
        {
            if (string.IsNullOrEmpty(username) || username != User?.Identity?.Name)
            {
                return RedirectToAction(RedirectUrl);
            }

            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction(RedirectUrl);
            }

            var model = await userProfileService.GetUserProfileAsync(userId);

            return View(model);
        }


    }
}
