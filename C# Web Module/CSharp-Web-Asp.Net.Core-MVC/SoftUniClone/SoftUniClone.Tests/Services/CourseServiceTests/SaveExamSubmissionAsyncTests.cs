namespace SoftUniClone.Tests.Services.CourseServiceTests
{
    using NUnit.Framework;
    using SoftUniClone.Data;
    using SoftUniClone.Services.Implementations;
    using System.Linq;
    using System.Threading.Tasks;
    using static Common.Constants;

    public class SaveExamSubmissionAsyncTests : BaseServiceTest
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

        [Test]
        public async Task SaveExamSubmission_WithTooLargeSubmissionFile_ShouldReturnFalse()
        {
            // Arrange
            var size = SubmissionMaxSize * 2;
            var submission = new byte[size];

            // Actv
            var result = await this.service.SaveExamSubmissionAsync(1, "6", submission);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SaveExamSubmission_ShouldReturnFalse()
        {
            // Arrange
            var size = SubmissionMaxSize - 10;
            var submission = new byte[size];

            // Act
            var result = await service.SaveExamSubmissionAsync(1, "invalidUserId", submission);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SaveExamSubmission_ShouldReturnTrue()
        {
            // Arrange
            var size = SubmissionMaxSize - 10;
            var submission = new byte[size];

            // Act
            var result = await service.SaveExamSubmissionAsync(1, "6", submission);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task SaveExamSubmission_ShouldSaveSubmissionCorrectly()
        {
            // Arrange
            var size = SubmissionMaxSize - 10;
            var submission = new byte[size];
            
            // Act
            var result = await service.SaveExamSubmissionAsync(1, "6", submission);

            var dbSubmission = this.db.Courses
                .FirstOrDefault(c => c.Students.Any(sc => sc.StudentId == "6" && sc.CourseId == 1))
                ?.Students.FirstOrDefault(s => s.StudentId == "6")
                .ExamSubmission;
            
            //Assert
            Assert.AreEqual(submission, dbSubmission);
            Assert.IsTrue(result);
        }
    }
}
