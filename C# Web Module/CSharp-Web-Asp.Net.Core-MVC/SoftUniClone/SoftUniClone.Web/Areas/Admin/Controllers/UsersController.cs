namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;
    using Services.Admin.Contracts;
    using SoftUniClone.Models;
    using SoftUniClone.Web.Infrastructure.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Models;

    using static Common.Constants;

    public class UsersController : BaseAdminController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IAdminUserService adminUserService;

        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IAdminUserService adminUserService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.adminUserService = adminUserService;
        }

        public async Task<IActionResult> Index(string searchToken, int page = 1)
        {
            if (page < 1)
            {
                return RedirectToAction(nameof(Index));
            }

            AdminPagesViewModel model = new AdminPagesViewModel
            {
                Elements = await this.adminUserService.GetAllListingAsync(searchToken, page),
                SearchToken = searchToken,
                Pagination = new PaginationViewModel
                {
                    TotalElements = await this.adminUserService.TotalCountAsync(searchToken),
                    PageSize = UserPageSize,
                    CurrentPage = page
                }
            };

            if (page > model.Pagination.TotalPages && model.Pagination.TotalPages != 0)
            {
                return RedirectToAction(nameof(Index), new { page = model.Pagination.TotalPages });
            }

            IEnumerable<SelectListItem> roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                })
                .ToListAsync();

            model.Roles = roles;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(UserWithRoleFormViewModel model)
        {
            bool isRoleExisting = await this.roleManager.RoleExistsAsync(model.Role);
            bool isUserExisting = await this.userManager.FindByIdAsync(model.UserId) != null;

            if (!isRoleExisting || !isUserExisting)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            User user = await this.userManager.FindByIdAsync(model.UserId);

            IdentityResult addToRoleResult = await this.userManager.AddToRoleAsync(user, model.Role);

            if (!addToRoleResult.Succeeded)
            {
                string errors = string.Join(Environment.NewLine, addToRoleResult.Errors.Select(e => e.Description));

                TempData.AddErrorMessage($"Error. {errors}");

                return RedirectToAction(nameof(Index));
            }

            await this.userManager.UpdateAsync(user);

            TempData.AddSuccessMessage($"User '{user.UserName}' has been added to role '{model.Role}'.");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromRole(UserWithRoleFormViewModel model)
        {
            bool isRoleExisting = await this.roleManager.RoleExistsAsync(model.Role);
            bool isUserExisting = await this.userManager.FindByIdAsync(model.UserId) != null;

            if (!isRoleExisting || !isUserExisting)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            User user = await this.userManager.FindByIdAsync(model.UserId);

            IdentityResult removeFromRoleResult = await this.userManager.RemoveFromRoleAsync(user, model.Role);

            if (!removeFromRoleResult.Succeeded)
            {
                string errors = string.Join(Environment.NewLine, removeFromRoleResult.Errors.Select(e => e.Description));

                TempData.AddErrorMessage($"Error. {errors}");

                return RedirectToAction(nameof(Index));
            }

            await this.userManager.UpdateAsync(user);

            TempData.AddSuccessMessage($"User '{user.UserName}' has been removed from role '{model.Role}'.");

            return RedirectToAction(nameof(Index));
        }
    }
}