namespace SoftUniClone.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using SoftUniClone.Models;
    using SoftUniClone.Models.Enums;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models.Courses;
    using Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServiceConstants;

    public class UserService : IUserService
    {
        private readonly SoftUniCloneDbContext database;
        private readonly UserManager<User> userManager;
        private readonly IPdfGenerator pdfGenerator;

        public UserService(SoftUniCloneDbContext database, UserManager<User> userManager, IPdfGenerator pdfGenerator)
        {
            this.database = database;
            this.userManager = userManager;
            this.pdfGenerator = pdfGenerator;
        }

        public async Task<IEnumerable<UserSearchServiceModel>> GetAllSearchListingAsync(string searchToken)
        {
            IQueryable<User> users = this.database.Users;

            if (!string.IsNullOrWhiteSpace(searchToken))
            {
                users = users.Where(u =>
                    u.Name.ToLower().Contains(searchToken.ToLower()) ||
                    u.UserName.ToLower().Contains(searchToken.ToLower()));
            }

            return await users
               .OrderBy(u => u.UserName)
               .ProjectTo<UserSearchServiceModel>()
               .ToListAsync();
        }

        public async Task<UserProfileServiceModel> GetProfileByIdAsync(string studentId, int page)
        {
            return await this.database
              .Users
              .Where(u => u.Id == studentId)
              .ProjectTo<UserProfileServiceModel>(new { studentId, page })
              .FirstOrDefaultAsync();
        }

        public async Task<UserEditProfileServiceModel> GetEditProfileByIdAsync(string studentId)
        {
            return await this.database
                 .Users
                 .Where(u => u.Id == studentId)
                 .ProjectTo<UserEditProfileServiceModel>()
                 .FirstOrDefaultAsync();
        }

        public async Task<UserChangePasswordProfileServiceModel> GetChangePasswordProfileByIdAsync(string studentId)
        {
            return await this.database
               .Users
               .Where(u => u.Id == studentId)
               .ProjectTo<UserChangePasswordProfileServiceModel>()
               .FirstOrDefaultAsync();
        }

        public async Task<byte[]> GetPdfCertificate(int courseId, string studentId)
        {
            StudentCourse studentCourse = await this.database.FindAsync<StudentCourse>(studentId, courseId);

            if (studentCourse == null)
            {
                return null;
            }

            CourseCertificateServiceModel certificate = await this.database
                .Courses
                .Where(c => c.Id == courseId)
                .ProjectTo<CourseCertificateServiceModel>(new { studentId })
                .FirstOrDefaultAsync();

            byte[] certificateContents = this.pdfGenerator.GeneratePdfFromHtl(string.Format(
                PdfCertificateFormat,
                certificate.Name,
                certificate.StartDate.ToShortDateString(),
                certificate.EndDate.ToShortDateString(),
                certificate.Student,
                certificate.Grade,
                certificate.Lecturer,
                DateTime.UtcNow.ToShortDateString()));

            return certificateContents;
        }

        public async Task<bool> EditProfileAsync(User user, string name, string email, DateTime birthdate)
        {
            if (user.Name != name)
            {
                user.Name = name;
            }

            if (user.Email != email)
            {
                user.Email = email;
            }

            if (user.Birthdate != birthdate)
            {
                user.Birthdate = birthdate;
            }

            IdentityResult editProfileResult = await this.userManager.UpdateAsync(user);

            return editProfileResult.Succeeded;
        }

        public async Task<bool> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            IdentityResult changePasswordResult = await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            return changePasswordResult.Succeeded;
        }

        public async Task<bool> IsStudentApplicable(int courseId, string studentId)
        {
            StudentCourse studentCourse = await this.database.FindAsync<StudentCourse>(studentId, courseId);

            if (studentCourse == null)
            {
                return false;
            }

            return studentCourse.Grade == Grade.A || studentCourse.Grade == Grade.B || studentCourse.Grade == Grade.C;
        }

        public Task<int> StudentTotalCoursesAsync(string studentId)
        {
            return this.database.Courses.Where(c => c.Students.Any(s => s.StudentId == studentId)).CountAsync();
        }
    }
}