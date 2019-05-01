namespace BashSoft.App.Models
{
    using Extensions.CustomExceptions;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private List<Student> students;

        public Course (string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public IReadOnlyList<Student> Students
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

        public void EnrollStudent (Student student)
        {
            if (this.students.Any(st => st.UserName == student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.name);
            }

            this.students.Add(student);
        }
    }
}
