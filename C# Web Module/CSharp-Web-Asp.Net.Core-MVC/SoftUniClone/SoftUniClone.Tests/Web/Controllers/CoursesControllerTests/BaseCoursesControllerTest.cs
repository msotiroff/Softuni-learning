namespace SoftUniClone.Tests.Web.Controllers.CoursesControllerTests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using SoftUniClone.Models;
    using SoftUniClone.Services.Contracts;
    using SoftUniClone.Services.Lecturer.Contracts;
    using SoftUniClone.Tests.Web.IdentityMocks;
    using SoftUniClone.Web.Controllers;
    using System.Security.Claims;
    using System.Threading;

    public abstract class BaseCoursesControllerTest : BaseControllerTest
    {
        protected BaseCoursesControllerTest()
        {
            this.UserManager = UserManagerMock.Instance();
            this.CourseService = new Mock<ICourseService>();
            this.LecturerService = new Mock<ILecturerService>();

            this.Controller = new CoursesController(this.UserManager.Object, this.CourseService.Object, this.LecturerService.Object);
        }

        public CoursesController Controller { get; set; }

        public Mock<UserManager<User>> UserManager { get; set; }

        public Mock<ICourseService> CourseService { get; set; }

        public Mock<ILecturerService> LecturerService { get; set; }

        protected void AddClaimsPrincipal()
        {
            this.Controller.ControllerContext = base.ControllerContext;
        }
    }
}
