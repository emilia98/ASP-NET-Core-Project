using JobListing.Core.Contracts;
using JobListing.Core.Models.InputModels.UserProfile;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IActionResult> Edit(string id)
        {
            var userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction(RedirectUrl);
            }

            var model = await userProfileService.GetUpdateUserProfileModel(id);

            if (model == null)
            { 
                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UpdateUserProfileInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUserId = GetUserId();

            if (currentUserId != id)
            {
                return RedirectToAction(nameof(Index));
            }

            var result = await userProfileService.UpdateUserProfileAsync(id, model);

            if (!result)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("");
        }


    }
}
