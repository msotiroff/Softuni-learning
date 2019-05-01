namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Services.Implementations;
    using SoftUniClone.Services.Models.Courses;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetAllSearchListingAsyncTests : BaseServiceTest
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
        public async Task GetAllSearchListing_ShouldReturnNotNullElements()
        {
            // Act
            var courses = await this.service.GetAllSearchListingAsync("");

            // Assert
            CollectionAssert.AllItemsAreNotNull(courses);
        }

        [Test]
        public async Task GetAllSearchListing_ShouldReturnProperCollectionOfModels()
        {
            // Act
            var courses = await this.service.GetAllSearchListingAsync("");

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(courses, typeof(CourseSearchServiceModel));
        }

        [Test]
        public async Task GetAllSearchListing_ShouldReturnOrderedEntities()
        {
            // Act
            var courses = await this.service.GetAllSearchListingAsync("");
            var expected = courses.OrderByDescending(c => c.StartDate).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, courses);
        }

        [Test]
        [TestCase("20", 1)]
        [TestCase("1", 11)]
        [TestCase("invalid", 0)]
        public async Task GetAllSearchListing_WithSearchToken_ShouldWorkProperly(string searchTerm, int expected)
        {
            // Act
            var courses = await service.GetAllSearchListingAsync(searchTerm);
            var result = courses.Count();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
