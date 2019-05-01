namespace SoftUniClone.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using SoftUniClone.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Courses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static Common.Constants;

    public class CourseService : ICourseService
    {
        private readonly SoftUniCloneDbContext database;

        public CourseService(SoftUniCloneDbContext database)
        {
            this.database = database;
        }

        public async Task<IEnumerable<CourseBasicServiceModel>> GetAllListingAsync(string searchToken, int page)
        {
            IQueryable<Course> courses = this.database.Courses;

            if (!string.IsNullOrWhiteSpace(searchToken))
            {
                courses = courses.Where(c =>
                    c.Name.ToLower().Contains(searchToken.ToLower()) ||
                    c.Description.ToLower().Contains(searchToken.ToLower()));
            }

            return await courses
               .OrderByDescending(c => c.StartDate)
               .Skip((page - 1) * CoursePageSize)
               .Take(CoursePageSize)
               .ProjectTo<CourseBasicServiceModel>()
               .ToListAsync();
        }

        public async Task<IEnumerable<CourseSearchServiceModel>> GetAllSearchListingAsync(string searchToken)
        {
            IQueryable<Course> courses = this.database.Courses;

            if (!string.IsNullOrWhiteSpace(searchToken))
            {
                courses = courses.Where(c =>
                    c.Name.ToLower().Contains(searchToken.ToLower()) ||
                    c.Description.ToLower().Contains(searchToken.ToLower()));
            }

            return await courses
               .OrderByDescending(c => c.StartDate)
               .ProjectTo<CourseSearchServiceModel>()
               .ToListAsync();
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id) where TModel : class
        {
            return await this.database
                .Courses
                .Where(c => c.Id == id)
                .ProjectTo<TModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsUserEnrolledInCourseAsync(string studentId, int courseId)
        {
            return await this.database
                .Courses
                .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == studentId));
        }

        public async Task<bool> SaveExamSubmissionAsync(int courseId, string studentId, byte[] examSubmisionContents)
        {
            StudentCourse studentCourse = await this.database.FindAsync<StudentCourse>(studentId, courseId);

            if (studentCourse == null)
            {
                return false;
            }

            if (examSubmisionContents.Length > SubmissionMaxSize)
            {
                return false;
            }

            studentCourse.ExamSubmission = examSubmisionContents;
            await this.database.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignUpStudentAsync(string studentId, int courseId)
        {
            CourseWithStudentServiceModel model = await this.GetCourseWithStudentInfoAsync(studentId, courseId);

            if (model == null || model.StartDate < DateTime.UtcNow || model.IsStudentEnrolledInCourse)
            {
                return false;
            }

            StudentCourse studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            this.database.Add(studentCourse);
            await this.database.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutStudentAsync(string studentId, int courseId)
        {
            CourseWithStudentServiceModel model = await this.GetCourseWithStudentInfoAsync(studentId, courseId);

            if (model == null || model.StartDate < DateTime.UtcNow || !model.IsStudentEnrolledInCourse)
            {
                return false;
            }
            
            StudentCourse studentCourse = await this.database.FindAsync<StudentCourse>(studentId, courseId);

            this.database.Remove(studentCourse);
            await this.database.SaveChangesAsync();

            return true;
        }

        public Task<int> TotalCountAsync(string searchToken)
        {
            if (string.IsNullOrWhiteSpace(searchToken))
            {
                return this.database.Courses.CountAsync();
            }

            return this.database
                .Courses
                .Where(c => c.Name.ToLower().Contains(searchToken.ToLower()))
                .CountAsync();
        }

        private async Task<CourseWithStudentServiceModel> GetCourseWithStudentInfoAsync(string studentId, int courseId)
        {
            var isStudentExisting = await this.database.Users.AnyAsync(u => u.Id == studentId);
            if (!isStudentExisting)
            {
                return null;
            }

            var studentCourse = await this.database
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new CourseWithStudentServiceModel
                {
                    StartDate = c.StartDate,
                    IsStudentEnrolledInCourse = c.Students.Any(s => s.StudentId == studentId)
                })
                .FirstOrDefaultAsync();

            return studentCourse;
        }
    }
}