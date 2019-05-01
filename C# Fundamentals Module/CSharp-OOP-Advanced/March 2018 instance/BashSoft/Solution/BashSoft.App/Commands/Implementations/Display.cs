namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using Extensions.CustomCollections.Contracts;
    using Extensions.CustomExceptions;
    using Models.Contracts;
    using Repositories.Contracts;
    using System;
    using System.Collections.Generic;

    [Alias("Display", "display")]
    public class Display : BaseCommand
    {
        private IDatabase repository;

        public Display(string[] data)
            : base(data)
        {
        }
        
        public override string Execute()
        {
            var entityToDisplay = this.Data[0];

            if (this.Data.Length < 2)
            {
                throw new InvalidCommandArgumentsException(nameof(Display), 2);
            }

            var sortType = this.Data[1];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<IStudent> studentComparator = this.CreateStudentComparator(sortType);
                ISimpleSortedBag<IStudent> list = this.repository.GetAllStudentsSorted(studentComparator);
                return list.JoinWith(Environment.NewLine);
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<ICourse> courseComparator = this.CreateCourseComparator(sortType);
                ISimpleSortedBag<ICourse> list = this.repository.GetAllCoursesSorted(courseComparator);
                return list.JoinWith(Environment.NewLine);
            }

            return string.Empty;
        }

        private IComparer<ICourse> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((first, second) => first.CompareTo(second));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((first, second) => second.CompareTo(first));
            }

            throw new ArgumentException("Invalid sort type");
        }

        private IComparer<IStudent> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentOne.CompareTo(studentTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentTwo.CompareTo(studentOne));
            }

            throw new ArgumentException("Invalid sort type");
        }
    }
}
