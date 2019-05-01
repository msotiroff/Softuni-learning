namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Courses;
    using Services.Admin.Contracts;
    using Services.Admin.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CoursesController : BaseAdminController
    {
        private readonly IAdminCourseService adminCourseService;
        private readonly IAdminUserService adminUserService;

        public CoursesController(IAdminCourseService adminCourseService, IAdminUserService adminUserService)
        {
            this.adminCourseService = adminCourseService;
            this.adminUserService = adminUserService;
        }

        public async Task<IActionResult> Create()
        {
            CourseFormViewModel model = new CourseFormViewModel();

            model.StartDate = DateTime.UtcNow;
            model.EndDate = DateTime.UtcNow.AddMonths(1);
            model.Lecturers = await this.GetAllUsersAsSelectItems();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Lecturers = await this.GetAllUsersAsSelectItems();
                return View(model);
            }

            await this.adminCourseService.CreateAsync(model.Name, model.Description, model.StartDate, model.EndDate, model.LecturerId);

            TempData.AddSuccessMessage($"Course '{model.Name}' has been successfully created.");

            return RedirectToAction(nameof(Web.Controllers.CoursesController.Index), "Courses", new { area = string.Empty });
        }

        private async Task<IEnumerable<SelectListItem>> GetAllUsersAsSelectItems()
        {
            IEnumerable<AdminUserIdAndNameServiceModel> users = await this.adminUserService.GetAllUserIdsAndNamesAsync();

            return users
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.Name
                })
                .ToList();
        }
    }
}