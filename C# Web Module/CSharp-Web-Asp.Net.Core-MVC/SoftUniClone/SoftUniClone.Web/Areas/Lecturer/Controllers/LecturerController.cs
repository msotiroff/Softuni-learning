namespace SoftUniClone.Web.Areas.Lecturer.Controllers
{
    using SoftUniClone.Models;
    using SoftUniClone.Models.Enums;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Courses;
    using Services.Contracts;
    using Services.Models.Courses;
    using Services.Lecturer.Contracts;
    using Services.Lecturer.Models.Courses;
    using Services.Lecturer.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Models;

    using static Common.Constants;
    using static WebConstants;

    [Area(LecturerArea)]
    [Authorize(Roles = LecturerRole)]
    public class LecturerController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ILecturerService LecturerService;
        private readonly ICourseService courseService;

        public LecturerController(UserManager<User> userManager, ILecturerService LecturerService, ICourseService courseService)
        {
            this.userManager = userManager;
            this.LecturerService = LecturerService;
            this.courseService = courseService;
        }

        public async Task<IActionResult> Index(string searchToken = null, int page = 1)
        {
            string LecturerId = this.userManager.GetUserId(User);

            if (page < 1)
            {
                return RedirectToAction(nameof(Index));
            }

            PagesViewModel<CourseBasicServiceModel> model = new PagesViewModel<CourseBasicServiceModel>
            {
                Elements = await this.LecturerService.GetAllListingByLecturerIdAsync(LecturerId, searchToken, page),
                SearchToken = searchToken,
                Pagination = new PaginationViewModel
                {
                    TotalElements = await this.LecturerService.TotalCountAsync(LecturerId, searchToken),
                    PageSize = CoursePageSize,
                    CurrentPage = page
                }
            };

            if (page > model.Pagination.TotalPages && model.Pagination.TotalPages != 0)
            {
                return RedirectToAction(nameof(Index), new { page = model.Pagination.TotalPages });
            }

            return View(model);
        }

        public async Task<IActionResult> Course(int id)
        {
            string userId = this.userManager.GetUserId(User);

            bool isUserLecturer = await this.LecturerService.IsUserLecturerAsync(id, userId);

            if (!isUserLecturer)
            {
                return BadRequest();
            }

            IEnumerable<StudentInCourseServiceModel> students = await this.LecturerService.GetStudentsInCourseByCourseIdAsync(id);
            CourseBasicServiceModel course = await this.courseService.GetByIdAsync<CourseBasicServiceModel>(id);

            CourseWithStudentsViewModel model = new CourseWithStudentsViewModel
            {
                Students = students,
                Course = course
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssessStudent(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }

            string userId = this.userManager.GetUserId(User);

            bool isUserLecturer = await this.LecturerService.IsUserLecturerAsync(id, userId);

            if (!isUserLecturer)
            {
                return BadRequest();
            }

            bool assessResult = await this.LecturerService.AssessStudentAsync(id, studentId, grade);

            if (!assessResult)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Course), new { id });
        }

        public async Task<IActionResult> DownloadExamSubmission(int id, string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }

            string userId = this.userManager.GetUserId(User);

            bool isUserLecturer = await this.LecturerService.IsUserLecturerAsync(id, userId);

            if (!isUserLecturer)
            {
                return BadRequest();
            }

            byte[] examSubmissionContents = await this.LecturerService.DownloadExamSubmission(id, studentId);

            if (examSubmissionContents == null)
            {
                this.TempData.AddErrorMessage("This student did not upload exam submission yet.");

                return RedirectToAction(nameof(Course), new { id });
            }

            CourseNameWithStudentNameServiceModel model = await this.LecturerService.GetCourseNameAndStudentName(id, studentId);

            if (model == null)
            {
                return BadRequest();
            }

            return File(examSubmissionContents, "application/zip", $"{model.CourseName} - {model.StudentName} - {DateTime.UtcNow.ToString("DD-MM-YYYY")}.zip");
        }
    }
}