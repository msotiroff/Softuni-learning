namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Data;
    using SoftUniClone.Services.Implementations;
    using System.Linq;
    using System.Threading.Tasks;

    public class SignOutStudentAsyncTests : BaseServiceTest
    {
        private CourseService service;
        private SoftUniCloneDbContext db;

        [SetUp]
        public void Initialize()
        {
            this.db = this.Database;
            DatabaseSeeder.SeedStudentsAndCourses(db);
            this.service = new CourseService(db);
        }

        [TestCase("6", 1)]
        [TestCase("7", 1)]
        [TestCase("8", 1)]
        public async Task SignOutStudent_WithValidData_ShouldRemoveStudentFromCourse(string studentId, int courseId)
        {
            // Act
            var result = await this.service.SignOutStudentAsync(studentId, courseId);
            var isEnrolled = this.db.Courses.Any(c => c.Students.Any(sc => sc.StudentId == studentId && sc.CourseId == courseId));

            // Assert
            Assert.IsFalse(isEnrolled);
        }

        [TestCase("6", 1)]
        [TestCase("7", 1)]
        [TestCase("8", 1)]
        public async Task SignOutStudent_WithEnrolledStudent_ShouldReturnTrue(string studentId, int courseId)
        {
            // Act
            var result = await this.service.SignOutStudentAsync(studentId, courseId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("6", 5)]
        [TestCase("7", 6)]
        [TestCase("11", 7)]
        public async Task SignOutStudent_WithNotEnrolledStudent_ShoultReturnFalse(string studentId, int courseId)
        {
            // Act
            var result = await this.service.SignOutStudentAsync(studentId, courseId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(500)]
        [TestCase(5000)]
        [TestCase(-1)]
        public async Task SignOutStudent_With_InvalidCourse_ShouldReturnFalse(int courseId)
        {
            // Act
            var result = await this.service.SignOutStudentAsync("10", courseId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase("asdf")]
        [TestCase("000")]
        [TestCase(null)]
        public async Task SignoutStudent_With_InvalidStudent_ShouldReturnFalse(string studentId)
        {
            // Act
            var result = await this.service.SignOutStudentAsync(studentId, 1);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
