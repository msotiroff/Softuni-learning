namespace BashSoft.App.Core
{
    using Models;
    using System.Collections.Generic;
    using System.IO;

    public static class SessionData
    {
        public static Dictionary<string, Course> allCourses;
        public static Dictionary<string, Student> allStudents;

        public static string currentPath = Directory.GetCurrentDirectory();
    }
}
