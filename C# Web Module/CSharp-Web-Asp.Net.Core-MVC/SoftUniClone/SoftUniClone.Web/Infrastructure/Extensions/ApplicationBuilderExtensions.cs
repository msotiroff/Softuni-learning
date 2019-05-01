namespace SoftUniClone.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using SoftUniClone.Data;
    using SoftUniClone.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using static Common.Constants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var database = serviceScope.ServiceProvider.GetService<SoftUniCloneDbContext>();
                database.Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                SeedRoles(userManager, roleManager);
                SeedCourses(database);
                SeedUsers(userManager, database);
            }

            return app;
        }

        private static void SeedCourses(SoftUniCloneDbContext dbContext)
        {
            if (!dbContext.Courses.Any())
            {
                var course = new Course
                {
                    Name = "C# MVC Frameworks - ASP.NET Core",
                    StartDate = new DateTime(2018, 7, 1),
                    EndDate = new DateTime(2018, 8, 26),
                    Description = @"The ASP.NET Core course will teach you how to build modern Web applications with Model-View-Controller architecture using HTML5, databases, Entity Framework Core and other technologies.",
                    Lecturer = dbContext.Users.First(u => u.Email == "iordan93@gmail.com")
                };

                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
            }
        }

        private static void SeedUsers(UserManager<User> userManager, SoftUniCloneDbContext dbContext)
        {
            if (dbContext.Users.Count() <= 2)
            {
                var usersList = File.ReadAllText(@"Resourses\SeedFiles\users-list.json");
                var courseId = dbContext.Courses.First().Id;

                var users = JsonConvert.DeserializeObject<User[]>(usersList);

                Task.Run(async () =>
                {
                    foreach (var user in users)
                    {
                        user.Courses.Add(new StudentCourse
                        {
                            CourseId = courseId,
                        });

                        await userManager.CreateAsync(user, "password");
                    }
                })
                .GetAwaiter()
                .GetResult();
            }
        }

        private static void SeedRoles(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            Task.Run(async () =>
            {
                var roleNames = new[]
                {
                        LecturerRole,
                        AdministratorRole
                    };

                foreach (string roleName in roleNames)
                {
                    var isRoleExisting = await roleManager.RoleExistsAsync(roleName);

                    if (!isRoleExisting)
                    {
                        IdentityRole role = new IdentityRole
                        {
                            Name = roleName
                        };

                        await roleManager.CreateAsync(role);
                    }
                }

                var adminUser = await userManager.FindByNameAsync("Admin");

                if (adminUser == null)
                {
                    var user = new User
                    {
                        UserName = "Admin",
                        Email = "admin@admin.com",
                        Name = "Admin Adminov"
                    };

                    await userManager.CreateAsync(user, "admin123");

                    await userManager.AddToRoleAsync(user, AdministratorRole);
                }

                var lecturerUser = await userManager.FindByEmailAsync("iordan93@gmail.com");

                if (lecturerUser == null)
                {
                    var user = new User
                    {
                        UserName = "iordan93",
                        Email = "iordan93@gmail.com",
                        Name = "Yordan Darakchiev"
                    };

                    await userManager.CreateAsync(user, "424242");

                    await userManager.AddToRoleAsync(user, LecturerRole);
                }
            })
                            .GetAwaiter()
                            .GetResult();
        }
    }
}
