namespace SoftUniClone.Services.Lecturer.Contracts
{
    using Models.Courses;
    using Models.Users;
    using Services.Models.Courses;
    using SoftUniClone.Models.Enums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILecturerService
    {
        Task<IEnumerable<CourseBasicServiceModel>> GetAllListingByLecturerIdAsync(string LecturerId, string searchToken, int page);

        Task<IEnumerable<StudentInCourseServiceModel>> GetStudentsInCourseByCourseIdAsync(int courseId);

        Task<bool> IsUserLecturerAsync(int courseId, string LecturerId);

        Task<bool> AssessStudentAsync(int courseId, string studentId, Grade grade);

        Task<byte[]> DownloadExamSubmission(int courseId, string studentId);

        Task<CourseNameWithStudentNameServiceModel> GetCourseNameAndStudentName(int courseId, string studentId);

        Task<int> TotalCountAsync(string LecturerId, string searchToken);
    }
}