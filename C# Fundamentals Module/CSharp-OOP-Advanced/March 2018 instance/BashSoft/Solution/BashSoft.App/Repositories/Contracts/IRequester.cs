namespace BashSoft.App.Repositories.Contracts
{
    using Extensions.CustomCollections.Contracts;
    using Models.Contracts;
    using System.Collections.Generic;

    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string studentName);

        void GetAllStudentsFromCourse(string courseName);

        ISimpleSortedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> comparer);

        ISimpleSortedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> comparer);
    }
}
