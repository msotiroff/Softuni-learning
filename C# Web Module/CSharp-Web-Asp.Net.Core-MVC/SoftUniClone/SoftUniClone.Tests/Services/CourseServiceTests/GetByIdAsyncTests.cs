namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Services.Implementations;
    using SoftUniClone.Services.Models.Courses;
    using System;
    using System.Threading.Tasks;

    public class GetByIdAsyncTests : BaseServiceTest
    {
        private CourseService service;

        [SetUp]
        public void Initialize()
        {
            var db = this.Database;
            DatabaseSeeder.SeedCourses(db);
            this.service = new CourseService(db);
        }

        [Test]
        public void GetByIdAsync_WithInvalidMappingType_ShouldThrowException()
        {
            // Assert
            Assert.That(() => this.service.GetByIdAsync<string>(5).Result, Throws.Exception);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Act
            var course = await this.service.GetByIdAsync<CourseBasicServiceModel>(0);

            // Assert
            Assert.IsNull(course);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnBasicModel()
        {
            // Act
            var course = await this.service.GetByIdAsync<CourseBasicServiceModel>(1);

            // Assert
            Assert.IsAssignableFrom(typeof(CourseBasicServiceModel), course);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnDetailsModel()
        {
            // Act
            var course = await this.service.GetByIdAsync<CourseDetailsServiceModel>(1);

            // Assert
            Assert.IsAssignableFrom(typeof(CourseDetailsServiceModel), course);
        }
    }
}
