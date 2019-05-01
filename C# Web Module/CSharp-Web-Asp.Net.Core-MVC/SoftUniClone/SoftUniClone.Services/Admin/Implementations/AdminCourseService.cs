namespace SoftUniClone.Services.Admin.Implementations
{
    using Contracts;
    using Data;
    using SoftUniClone.Models;
    using System;
    using System.Threading.Tasks;

    public class AdminCourseService : IAdminCourseService
    {
        private readonly SoftUniCloneDbContext database;

        public AdminCourseService(SoftUniCloneDbContext database)
        {
            this.database = database;
        }

        public async Task CreateAsync(string name, string description, DateTime startDate, DateTime endDate, string LecturerId)
        {
            Course course = new Course
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate.AddDays(1),
                LecturerId = LecturerId
            };

            await this.database.Courses.AddAsync(course);
            await this.database.SaveChangesAsync();
        }
    }
}