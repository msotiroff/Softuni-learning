namespace SoftUniClone.Services.Lecturer.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Lecturer.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.Courses;
    using Models.Users;
    using Services.Models.Courses;
    using SoftUniClone.Models;
    using SoftUniClone.Models.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static Common.Constants;

    public class LecturerService : ILecturerService
    {
        private readonly SoftUniCloneDbContext database;

        public LecturerService(SoftUniCloneDbContext database)
        {
            this.database = database;
        }

        public async Task<IEnumerable<CourseBasicServiceModel>> GetAllListingByLecturerIdAsync(string LecturerId, string searchToken, int page)
        {
            IQueryable<Course> courses = this.database.Courses;

            if (!string.IsNullOrWhiteSpace(searchToken))
            {
                courses = courses.Where(c => c.Name.ToLower().Contains(searchToken.ToLower()));
            }

            return await courses
               .Where(c => c.LecturerId == LecturerId)
               .OrderByDescending(c => c.StartDate)
               .Skip((page - 1) * CoursePageSize)
               .Take(CoursePageSize)
               .ProjectTo<CourseBasicServiceModel>()
               .ToListAsync();
        }

        public async Task<IEnumerable<StudentInCourseServiceModel>> GetStudentsInCourseByCourseIdAsync(int courseId)
        {
            return await this.database
                .Courses
                .Where(c => c.Id == courseId)
                .SelectMany(c => c.Students.Select(s => s.Student))
                .ProjectTo<StudentInCourseServiceModel>(new { courseId })
                .ToListAsync();
        }

        public async Task<bool> IsUserLecturerAsync(int courseId, string LecturerId)
        {
            return await this.database
                .Courses
                .AnyAsync(c => c.Id == courseId && c.LecturerId == LecturerId);
        }

        public async Task<bool> AssessStudentAsync(int courseId, string studentId, Grade grade)
        {
            StudentCourse studentCourse = await this.database.FindAsync<StudentCourse>(studentId, courseId);

            if (studentCourse == null)
            {
                return false;
            }

            studentCourse.Grade = grade;

            await this.database.SaveChangesAsync();

            return true;
        }

        public async Task<byte[]> DownloadExamSubmission(int courseId, string studentId)
        {
            StudentCourse studentCourse = await this.database.FindAsync<StudentCourse>(studentId, courseId);

            if (studentCourse == null)
            {
                return null;
            }

            return studentCourse.ExamSubmission;
        }

        public async Task<CourseNameWithStudentNameServiceModel> GetCourseNameAndStudentName(int courseId, string studentId)
        {
            string courseName = await this.database
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();

            if (courseName == null)
            {
                return null;
            }

            string studentName = await this.database
                .Users
                .Where(u => u.Id == studentId)
                .Select(u => u.Name)
                .FirstOrDefaultAsync();

            if (studentName == null)
            {
                return null;
            }

            CourseNameWithStudentNameServiceModel model = new CourseNameWithStudentNameServiceModel
            {
                CourseName = courseName,
                StudentName = studentName
            };

            return model;
        }

        public async Task<int> TotalCountAsync(string LecturerId, string searchToken)
        {
            if (string.IsNullOrWhiteSpace(searchToken))
            {
                return await this.database.Courses.Where(c => c.LecturerId == LecturerId).CountAsync();
            }

            return await this.database
              .Courses
              .Where(c => c.LecturerId == LecturerId && c.Name.ToLower().Contains(searchToken.ToLower()))
              .CountAsync();
        }
    }
}