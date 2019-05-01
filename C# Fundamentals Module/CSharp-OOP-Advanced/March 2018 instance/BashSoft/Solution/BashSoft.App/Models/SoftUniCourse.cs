namespace BashSoft.App.Models
{
    using Extensions.CustomExceptions;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private List<IStudent> students;

        public SoftUniCourse (string name)
        {
            this.Name = name;
            this.students = new List<IStudent>();
        }
        
        public IReadOnlyList<IStudent> Students
        {
            get => this.students;
        }
        
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);

        public void EnrollStudent (IStudent student)
        {
            if (this.students.Any(st => st.UserName == student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.name);
            }

            this.students.Add(student);
        }

        public override string ToString() => this.Name;
    }
}
