namespace SoftUniClone.Services.Models.Courses
{
    using System;

    public class CourseWithStudentServiceModel
    {
        public DateTime StartDate { get; set; }

        public bool IsStudentEnrolledInCourse { get; set; }
    }
}