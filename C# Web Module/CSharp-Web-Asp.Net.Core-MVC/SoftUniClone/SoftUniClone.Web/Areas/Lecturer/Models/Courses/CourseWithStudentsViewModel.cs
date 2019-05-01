namespace SoftUniClone.Web.Areas.Lecturer.Models.Courses
{
    using Services.Models.Courses;
    using Services.Lecturer.Models.Users;
    using System.Collections.Generic;

    public class CourseWithStudentsViewModel
    {
        public IEnumerable<StudentInCourseServiceModel> Students { get; set; }

        public CourseBasicServiceModel Course { get; set; }
    }
}