namespace P03_StudentSystem.Repositories
{
    using Models;
    using System.Collections.Generic;

    public class StudentRepository
    {
        private Dictionary<string, Student> allStudents;

        public StudentRepository()
        {
            this.AllStudents = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> AllStudents
        {
            get => this.allStudents;
            private set
            {
                this.allStudents = value;
            }
        }
    }
}