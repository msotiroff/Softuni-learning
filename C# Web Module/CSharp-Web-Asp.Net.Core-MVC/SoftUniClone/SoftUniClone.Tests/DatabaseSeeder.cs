namespace SoftUniClone.Tests
{
    using SoftUniClone.Data;
    using SoftUniClone.Models;
    using System;
    using System.Collections.Generic;

    public static class DatabaseSeeder
    {
        public static void SeedStudentsAndCourses(SoftUniCloneDbContext dbContext)
        {
            var coursesToSeed = new List<Course>();

            for (int courseId = 1; courseId <= 10; courseId++)
            {
                var courseName = $"Course_{courseId}";
                var course = new Course
                {
                    Id = courseId,
                    Name = courseName,
                    StartDate = DateTime.Now.AddDays(1),
                    Description = $"{courseName} description here!"
                };

                for (int userId = courseId + 5; userId <= courseId + 10; userId++)
                {
                    var user = $"User_{userId}";

                    course.Students.Add(new StudentCourse
                    {
                        Student = new User
                        {
                            Id = $"{userId}",
                            Email = $"{user}@example.com",
                            UserName = user,
                            Name = user,
                            Birthdate = new DateTime(2000, 1, 1),
                        }
                    });
                }

                coursesToSeed.Add(course);
            }

            dbContext.AddRange(coursesToSeed);
            dbContext.SaveChanges();
        }

        public static void SeedCourses(SoftUniCloneDbContext dbContext)
        {
            var coursesToSeed = new List<Course>();

            for (int i = 1; i <= 20; i++)
            {
                var course = $"Course_{i}";
                coursesToSeed.Add(new Course
                {
                    Id = i,
                    Name = course,
                    Description = $"{course} description here!"
                });
            }

            dbContext.AddRange(coursesToSeed);
            dbContext.SaveChanges();
        }

        public static void SeedUsers(SoftUniCloneDbContext dbContext)
        {
            var usersToSeed = new List<User>();

            for (int i = 1; i <= 100; i++)
            {
                var user = $"User_{i}";
                usersToSeed.Add(new User
                {
                    Email = $"{user}@example.com",
                    UserName = user,
                    Name = user,
                    Birthdate = new DateTime(2000, 1, 1),
                });
            }

            dbContext.AddRange(usersToSeed);
            dbContext.SaveChanges();
        }
    }
}
