namespace SoftUniClone.Web.Models.Courses
{
    using Services.Models.Courses;

    public class CourseDetailsViewModel
    {
        public CourseDetailsServiceModel Course { get; set; }

        public bool IsStudentEnrolledInCourse { get; set; }
    }
}