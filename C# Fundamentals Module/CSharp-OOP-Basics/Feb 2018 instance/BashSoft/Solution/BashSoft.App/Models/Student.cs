namespace BashSoft.App.Models
{
    using Extensions.CustomExceptions;
    using Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string userName;
        private List<Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;
        
        public Student (string username)
        {
            this.UserName = username;
            this.enrolledCourses = new List<Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get => this.userName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        public IReadOnlyList<Course> EnrolledCourses
        {
            get => this.enrolledCourses;
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get => this.marksByCourseName;
        }

        public void EnrollInCourse (Course course)
        {
            if (this.enrolledCourses.Any(c => c.Name == course.Name))
            {
                throw new DuplicateEntryInStructureException(this.userName, course.Name);
            }

            this.enrolledCourses.Add(course);
        }

        public void SetMarksInCourse (string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.Any(c => c.Name == courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double relativeValueOfSolvedTasks = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);

            double mark = relativeValueOfSolvedTasks * 4 + 2;

            return mark;
        }
    }
}
