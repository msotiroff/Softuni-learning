using System;

namespace P01_StudentSystemDbInitializer
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data;
    using P01_StudentSystemDbInitializer.Generators;

    public class DatabaseInitializer
    {
        private static Random rnd = new Random();

        public static void ResetDatabase()
        {
            using (var db = new StudentSystemContext())
            {
                db.Database.EnsureDeleted();

                db.Database.Migrate();

                InitialSeed(db);
            }
        }

        public static void InitialSeed(StudentSystemContext db)
        {
            SeedStudents(db, 100);

            SeedCourses(db, 30);

            SeedStudentsCourses(db, 120);

            SeedHomeworks(db, 150);

            SeedResources(db);
        }

        private static void SeedStudentsCourses(StudentSystemContext db, int count)
        {
            StudentsCoursesGenerator.InitialStudentCoursesSeed(db, count);
        }

        private static void SeedResources(StudentSystemContext db)
        {
            ResouceGenerator.InitialResourseSeed(db);
        }

        private static void SeedHomeworks(StudentSystemContext db, int count)
        {
            HomeworkGenerator.InitialHomeworkSeed(db, count);
        }

        private static void SeedCourses(StudentSystemContext db, int count)
        {
            CourseGenerator.InitialCourseSeed(db, count);
        }

        private static void SeedStudents(StudentSystemContext db, int count)
        {
            StudentGenetaror.InitialStudentSeed(db, count);
        }
    }
}
