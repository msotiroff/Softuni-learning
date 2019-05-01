namespace SoftUniClone.Services.Contracts
{
    using SoftUniClone.Models;
    using Models.Users;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IUserService
    {
        Task<IEnumerable<UserSearchServiceModel>> GetAllSearchListingAsync(string searchToken);

        Task<UserProfileServiceModel> GetProfileByIdAsync(string studentId, int page);

        Task<UserEditProfileServiceModel> GetEditProfileByIdAsync(string studentId);

        Task<UserChangePasswordProfileServiceModel> GetChangePasswordProfileByIdAsync(string studentId);

        Task<byte[]> GetPdfCertificate(int courseId, string studentId);

        Task<bool> EditProfileAsync(User user, string name, string email, DateTime birthdate);

        Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<bool> IsStudentApplicable(int courseId, string studentId);

        Task<int> StudentTotalCoursesAsync(string studentId);
    }
}