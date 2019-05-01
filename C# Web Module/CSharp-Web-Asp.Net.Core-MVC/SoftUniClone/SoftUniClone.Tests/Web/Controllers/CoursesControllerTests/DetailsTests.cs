namespace SoftUniClone.Tests.Web.Controllers.CoursesControllerTests
{
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using SoftUniClone.Services.Models.Courses;
    using SoftUniClone.Web.Models.Courses;
    using System.Threading.Tasks;

    public class DetailsTests : BaseCoursesControllerTest
    {
        [Test]
        public async Task Details_ShouldReturnViewWithCorrectModel()
        {
            // Arrange
            this.CourseService
                .Setup(c => c.GetByIdAsync<CourseDetailsServiceModel>(1))
                .ReturnsAsync(new CourseDetailsServiceModel());

            base.AddClaimsPrincipal();

            // Act
            var result = await this.Controller.Details(1, "") as ViewResult;
            var model = result.ViewData.Model as CourseDetailsViewModel;

            // Assert
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Course != null);
            Assert.IsFalse(model.IsStudentEnrolledInCourse);
        }

        [Test]
        public async Task Details_ShouldReturnView()
        {
            // Arrange
            this.CourseService
                .Setup(c => c.GetByIdAsync<CourseDetailsServiceModel>(1))
                .ReturnsAsync(new CourseDetailsServiceModel());

            base.AddClaimsPrincipal();

            // Act
            var result = await this.Controller.Details(1, "");

            // Assert
            Assert.IsAssignableFrom(typeof(ViewResult), result);
        }

        [Test]
        public async Task Details_WithUnexistantCourse_ShouldReturnNotFound()
        {
            // Act
            var result = await this.Controller.Details(-1, "");

            // Assert
            Assert.IsAssignableFrom(typeof(NotFoundResult), result);
        }
    }
}
