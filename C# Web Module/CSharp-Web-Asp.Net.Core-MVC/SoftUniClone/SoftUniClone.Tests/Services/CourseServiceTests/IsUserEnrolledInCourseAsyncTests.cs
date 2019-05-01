namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Services.Implementations;
    using System.Threading.Tasks;

    public class IsUserEnrolledInCourseAsyncTests : BaseServiceTest
    {
        private CourseService service;

        [SetUp]
        public void Initialize()
        {
            var db = this.Database;
            DatabaseSeeder.SeedStudentsAndCourses(db);
            this.service = new CourseService(db);
        }

        [Test]
        public async Task IsUserEnrolledInCourse_ShouldReturnFalse()
        {
            // Act
            var result = await this.service.IsUserEnrolledInCourseAsync("6", 2);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsUserEnrolledInCourse_WithInvalidCourseId_ShouldReturnFalse()
        {
            // Act
            var result = await this.service.IsUserEnrolledInCourseAsync("1", 5000);

            //Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public async Task IsUserEnrolledInCourse_WithInvalidUserId_ShouldReturnFalse()
        {
            // Act
            var result = await this.service.IsUserEnrolledInCourseAsync("invalidId", 1);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsUserEnrolledInCourse_ShouldReturnTrue()
        {
            // Act
            var result = await this.service.IsUserEnrolledInCourseAsync("6", 1);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
