namespace SoftUniClone.Services.Contracts
{
    using Models.Courses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICourseService
    {
        Task<IEnumerable<CourseBasicServiceModel>> GetAllListingAsync(string searchToken, int page);

        Task<IEnumerable<CourseSearchServiceModel>> GetAllSearchListingAsync(string searchToken);

        Task<TModel> GetByIdAsync<TModel>(int id)
            where TModel : class;

        Task<bool> IsUserEnrolledInCourseAsync(string studentId, int courseId);

        Task<bool> SaveExamSubmissionAsync(int courseId, string studentId, byte[] examSubmisionContents);

        Task<bool> SignUpStudentAsync(string studentId, int courseId);

        Task<bool> SignOutStudentAsync(string studentId, int courseId);

        Task<int> TotalCountAsync(string searchToken);
    }
}