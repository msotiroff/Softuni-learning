namespace SoftUniClone.Web.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Services.Models.Users;
    using SoftUniClone.Models;
    using SoftUniClone.Web.Models;
    using System.Threading.Tasks;

    using static Common.Constants;

    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public UsersController(UserManager<User> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        public async Task<ActionResult> Profile(string username, int page = 1)
        {
            User user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            if (page < 1)
            {
                return RedirectToAction(nameof(Profile), new { username });
            }

            PageViewModel<UserProfileServiceModel> model = new PageViewModel<UserProfileServiceModel>
            {
                Element = await this.userService.GetProfileByIdAsync(user.Id, page),
                Pagination = new PaginationViewModel
                {
                    TotalElements = await this.userService.StudentTotalCoursesAsync(user.Id),
                    PageSize = CoursePageSize,
                    CurrentPage = page
                }
            };

            if (page > model.Pagination.TotalPages && model.Pagination.TotalPages != 0)
            {
                return RedirectToAction(nameof(Profile), new { page = model.Pagination.TotalPages });
            }

            return View(model);
        }

        public async Task<IActionResult> EditProfile(string username)
        {
            User user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            UserEditProfileServiceModel model = await this.userService.GetEditProfileByIdAsync(user.Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditProfileServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = await this.userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            bool editProfileResult = await this.userService.EditProfileAsync(user, model.Name, model.Email, model.Birthdate);

            if (!editProfileResult)
            {
                TempData.AddErrorMessage($"Error. Your profile could not be changed. Please try again.");
                return View(model);
            }

            TempData.AddSuccessMessage($"Your profile has been changed.");
            return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
        }

        public async Task<IActionResult> ChangePassword(string username)
        {
            User user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            bool userHasPassword = await this.userManager.HasPasswordAsync(user);

            if (!userHasPassword)
            {
                TempData.AddErrorMessage("You do not have a password. You are using an external login provider.");
                return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
            }

            UserChangePasswordProfileServiceModel model = await this.userService.GetChangePasswordProfileByIdAsync(user.Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordProfileServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = await this.userManager.GetUserAsync(User);

            bool changePasswordResult = await this.userService.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePasswordResult)
            {
                TempData.AddErrorMessage($"Error. Your password could not be changed. Please try again.");
                return View(model);
            }

            TempData.AddSuccessMessage($"Your password has been changed.");
            return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
        }

        [Authorize]
        public async Task<IActionResult> DownloadCertificate(int id)
        {
            string userId = this.userManager.GetUserId(User);

            bool isStudentApplicable = await this.userService.IsStudentApplicable(id, userId);

            if (!isStudentApplicable)
            {
                this.TempData.AddErrorMessage("You do not have certificate from this course.");

                return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
            }

            byte[] certificateContents = await this.userService.GetPdfCertificate(id, userId);

            if (certificateContents == null)
            {
                this.TempData.AddErrorMessage("You do not have certificate from this course.");

                return RedirectToAction(nameof(Profile), new { username = User.Identity.Name });
            }

            return File(certificateContents, "application/pdf", "Certificate.pdf");
        }
    }
}