namespace P03_StudentSystem.Models
{
    public class Student
    {
        private string name;
        private int age;
        private double grade;

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public double Grade
        {
            get { return grade; }
            private set { grade = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public override string ToString()
        {
            string view = $"{this.Name} is {this.Age} years old.";

            if (this.Grade >= 5.00)
            {
                view += " Excellent student.";
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                view += " Average student.";
            }
            else
            {
                view += " Very nice person.";
            }

            return view;
        }
    }
}