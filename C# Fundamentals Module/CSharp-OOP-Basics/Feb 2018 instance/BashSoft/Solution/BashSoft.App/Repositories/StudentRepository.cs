namespace BashSoft.App.Repositories
{
    using Core;
    using Extensions;
    using Extensions.CustomExceptions;
    using IO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Core.SessionData;

    public class StudentRepository
    {
        private bool isDataInitialized;
        private RepositoryFilter filterManager;
        private RepositorySorter orderManager;

        public StudentRepository()
        {
            this.isDataInitialized = allCourses != null;
            this.filterManager = new RepositoryFilter();
            this.orderManager = new RepositorySorter();
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitialized);
                return false;
            }

            if (!allCourses.ContainsKey(courseName))
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistantCourseInDataBase);
                return false;
            }

            return true;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if (IsQueryForCoursePossible(courseName)
                && allCourses[courseName].Students.Any(st => st.UserName == studentName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistantStudentInDataBase);
                return false;
            }
        }

        internal void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitialized);
            }

            this.isDataInitialized = false;
            allCourses = null;
            allStudents = null;
        }

        internal void LoadData(string fileName)
        {
            if (!this.isDataInitialized)
            {
                allCourses = new Dictionary<string, Course>();
                allStudents = new Dictionary<string, Student>();
                OutputWriter.WriteMessageOnNewLine(Constants.ReadingData);
                ReadData(fileName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitialized);
            }
        }

        private void ReadData(string fileName)
        {
            var inputPattern = @"^(?<Course>[A-Z][A-Za-z\+\#]*_[A-Z][a-z]{2}_20\d{2})\s+(?<UserName>[A-Z][A-Za-z]{3,}\d{2}_\d{2,4})\s+(?<Scores>(100|\d{1,2}\s*)+)$";

            var inputValidator = new Regex(inputPattern);

            try
            {
                var input = File.ReadAllLines(currentPath + "\\" + fileName);

                for (int line = 0; line < input.Length; line++)
                {
                    var studentParams = input[line].Split();

                    var match = inputValidator.Match(input[line]);

                    if (match.Success)
                    {
                        var courseName = match.Groups["Course"].Value;
                        var studentName = match.Groups["UserName"].Value;
                        var studentScores = match.Groups["Scores"].Value
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

                        if (studentScores.Length > Course.NumberOfTasksOnExam)
                        {
                            OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                            continue;
                        }


                        if (!allCourses.ContainsKey(courseName))
                        {
                            allCourses[courseName] = new Course(courseName);
                        }
                        if (!allStudents.ContainsKey(studentName))
                        {
                            allStudents.Add(studentName, new Student(studentName));
                        }

                        var student = allStudents[studentName];
                        var course = allCourses[courseName];

                        student.EnrollInCourse(course);
                        student.SetMarksInCourse(courseName, studentScores);

                        course.EnrollStudent(student);
                    }
                }

                isDataInitialized = true;

                OutputWriter.WriteMessageOnNewLine(Constants.DataRead);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException();
            }
        }

        internal void GetStudentScoresFromCourse(string courseName, string studentName)
        {
            if (IsQueryForStudentPossible(courseName, studentName))
            {
                var score = allStudents[studentName].MarksByCourseName[courseName];
                var student = new KeyValuePair<string, double>(studentName, score);

                OutputWriter.PrintStudent(student);
            }
        }

        internal void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}.");

                allCourses[courseName].Students
                    .ForEach(st => OutputWriter
                        .PrintStudent(new KeyValuePair<string, double>(st.UserName, st.MarksByCourseName[courseName])));
            }
        }

        internal void ShowWantedData(params string[] args)
        {
            var courseName = args[0];

            if (args.Length == 1)
            {
                GetAllStudentsFromCourse(courseName);
            }
            else
            {
                var studentName = args[1];

                GetStudentScoresFromCourse(courseName, studentName);
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, string studentsCount)
        {
            int.TryParse(studentsCount, out int studentsToTake);

            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsCount == "all")
                {
                    studentsToTake = allCourses[courseName].Students.Count;
                }

                var studentsWithMarks = allCourses[courseName]
                    .Students
                    .ToDictionary(x => x.UserName, x => x.MarksByCourseName[courseName]);

                filterManager.FilterAndTake(studentsWithMarks, givenFilter, studentsToTake);
            }
        }

        public void OrderAndTake(string courseName, string comparison, string studentsCount)
        {
            int.TryParse(studentsCount, out int studentsToTake);

            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsCount == "all")
                {
                    studentsToTake = allCourses[courseName].Students.Count;
                }

                var studentsWithMarks = allCourses[courseName]
                    .Students
                    .ToDictionary(x => x.UserName, x => x.MarksByCourseName[courseName]);

                orderManager.OrderAndTake(studentsWithMarks, comparison, studentsToTake);
            }
        }
    }
}
