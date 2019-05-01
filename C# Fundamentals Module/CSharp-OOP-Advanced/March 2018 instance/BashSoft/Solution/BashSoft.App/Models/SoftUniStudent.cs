namespace BashSoft.App.Models
{
    using Contracts;
    using Extensions.CustomExceptions;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniStudent : IStudent
    {
        private string userName;
        private List<ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;
        
        public SoftUniStudent (string username)
        {
            this.UserName = username;
            this.enrolledCourses = new List<ICourse>();
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

        public IReadOnlyList<ICourse> EnrolledCourses
        {
            get => this.enrolledCourses;
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get => this.marksByCourseName;
        }

        public int CompareTo(IStudent other) => this.UserName.CompareTo(other.UserName);

        public void EnrollInCourse (ICourse course)
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

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        public override string ToString() => this.UserName;

        private double CalculateMark(int[] scores)
        {
            double relativeValueOfSolvedTasks = scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);

            double mark = relativeValueOfSolvedTasks * 4 + 2;

            return mark;
        }
    }
}
