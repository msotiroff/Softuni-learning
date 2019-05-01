namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Services.Implementations;
    using System.Linq;
    using Common;
    using System.Threading.Tasks;
    using System;
    using SoftUniClone.Services.Models.Courses;

    public class GetAllListingAsyncTests : BaseServiceTest
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
        public async Task GetAllListing_ShouldReturnNotNullElements()
        {
            // Act
            var courses = await this.service.GetAllListingAsync("", 1);

            // Assert
            CollectionAssert.AllItemsAreNotNull(courses);
        }

        [Test]
        public async Task GetAllListing_ShouldReturnProperCollectionOfModels()
        {
            // Act
            var courses = await this.service.GetAllListingAsync("", 1);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(courses, typeof(CourseBasicServiceModel));
        }

        [Test]
        public async Task GetAllListing_ShouldReturnOrderedEntities()
        {
            // Act
            var courses = await this.service.GetAllListingAsync("", 1);
            var expected = courses.OrderByDescending(c => c.StartDate).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, courses);
        }

        [Test]
        [TestCase("20", 1)]
        [TestCase("1", 11)]
        [TestCase("invalid", 0)]
        public async Task GetAllListing_WithSearchToken_ShouldWorkProperly(string searchTerm, int expected)
        {
            // Act
            var courses = await service.GetAllListingAsync(searchTerm, default(int));
            var result = courses.Count();

            // Assert
            Assert.AreEqual(Math.Min(expected, Constants.CoursePageSize), result);
        }

        [Test]
        public async Task GetAllListing_ShouldReturnRightPageSize()
        {
            // Act
            var courses = await service.GetAllListingAsync("", 1);
            var result = courses.Count();
            var expected = Constants.CoursePageSize;

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
