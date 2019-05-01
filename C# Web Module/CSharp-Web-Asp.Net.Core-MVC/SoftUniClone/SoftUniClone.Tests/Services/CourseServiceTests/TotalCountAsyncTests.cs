namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Data;
    using SoftUniClone.Services.Implementations;
    using System.Linq;
    using System.Threading.Tasks;

    public class TotalCountAsyncTests : BaseServiceTest
    {
        private CourseService service;
        private SoftUniCloneDbContext db;

        [SetUp]
        public void Initialize()
        {
            this.db = this.Database;
            DatabaseSeeder.SeedCourses(db);
            this.service = new CourseService(db);
        }

        [TestCase("1")]
        [TestCase("10")]
        [TestCase("CouRSe")]
        [TestCase("19")]
        [TestCase(null)]
        [TestCase("")]
        public async Task TotalCount_WithSearchTerm_ShouldReturnCorrectValue(string searchTerm)
        {
            // Arrange
            var testSearchTerm = searchTerm ?? "";
            var expected = this.db.Courses.Count(c => c.Name.ToLower().Contains(testSearchTerm.ToLower()));

            // Act
            var actual = await this.service.TotalCountAsync(searchTerm);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task TotalCount_WithoutSearchTerm_ShouldReturnCorrectValue()
        {
            // Arrange
            var expected = this.db.Courses.Count();

            // Act
            var actual = await this.service.TotalCountAsync(null);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
