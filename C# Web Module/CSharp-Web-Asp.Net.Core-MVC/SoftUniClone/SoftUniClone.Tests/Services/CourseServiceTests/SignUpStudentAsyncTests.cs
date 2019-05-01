namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Data;
    using SoftUniClone.Services.Implementations;
    using System.Linq;
    using System.Threading.Tasks;

    public class SignUpStudentAsyncTests : BaseServiceTest
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
        public async Task SignUpStudent_WithAlreadyEnrolledStudent_ShouldReturnFalse(string studentId, int courseId)
        {
            // Act
            var result = await this.service.SignUpStudentAsync(studentId, courseId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SignUpStudent_ShouldEnrollStudentInCourse()
        {
            // Act
            var result = await this.service.SignUpStudentAsync("6", 5);
            var isEnrolled = this.db.Courses.Any(c => c.Students.Any(sc => sc.StudentId == "6" && sc.CourseId == 5));

            // Assert
            Assert.IsTrue(isEnrolled);
        }

        [TestCase("6", 5)]
        [TestCase("7", 6)]
        [TestCase("11", 7)]
        public async Task SignUpStudent_With_ValidData_ShouldReturnTrue(string studentId, int courseId)
        {
            // Act
            var result = await this.service.SignUpStudentAsync(studentId, courseId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase(500)]
        [TestCase(5000)]
        [TestCase(-1)]
        public async Task SignUpStudent_With_InvalidCourse_ShouldReturnFalse(int courseId)
        {
            // Act
            var result = await this.service.SignUpStudentAsync("10", courseId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase("asdf")]
        [TestCase("000")]
        [TestCase(null)]
        public async Task SignUpStudent_With_InvalidStudent_ShouldReturnFalse(string studentId)
        {
            // Act
            var result = await this.service.SignUpStudentAsync(studentId, 1);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
