namespace BashSoft.App.Models.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IStudent : IComparable<IStudent>
    {
        string UserName { get; }

        IReadOnlyList<ICourse> EnrolledCourses { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        void EnrollInCourse(ICourse course);

        void SetMarksInCourse(string courseName, params int[] scores);
    }
}
