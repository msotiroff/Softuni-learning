namespace P03_StudentSystem.Core
{
    using Models;
    using Repositories;
    using System;

    public class CommandParser
    {
        private StudentRepository studentRepository;

        public CommandParser(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public string ParseCommand(params string[] args) 
        {
            string command = args[0];

            if (command == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);
                if (!studentRepository.AllStudents.ContainsKey(name))
                {
                    var student = new Student(name, age, grade);
                    studentRepository.AllStudents[name] = student;
                }
            }
            else if (command == "Show")
            {
                var name = args[1];
                if (studentRepository.AllStudents.ContainsKey(name))
                {
                    var student = studentRepository.AllStudents[name];
                    return student.ToString();
                }

            }
            else if (command == "Exit")
            {
                Environment.Exit(0);
            }

            return string.Empty;
        }
    }
}
