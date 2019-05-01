namespace BashSoft.App.Repositories
{
    using Contracts;
    using Extensions;
    using Extensions.CustomCollections;
    using Extensions.CustomCollections.Contracts;
    using Extensions.CustomExceptions;
    using IO;
    using Models;
    using Models.Contracts;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StudentRepository : IStudentRepository, IDatabase
    {
        private IDictionary<string, ICourse> allCourses;
        private IDictionary<string, IStudent> allStudents;

        private bool isDataInitialized;
        private IDataFilter dataFilter;
        private IDataSorter dataSorter;

        public StudentRepository(IDataFilter dataFilter, IDataSorter dataSorter)
        {
            this.allCourses = new Dictionary<string, ICourse>();
            this.allStudents = new Dictionary<string, IStudent>();
            this.dataFilter = dataFilter;
            this.dataSorter = dataSorter;
        }

        public StudentRepository(
            IDictionary<string, ICourse> courses, 
            IDictionary<string, IStudent> students, 
            IDataFilter dataFilter, 
            IDataSorter dataSorter)
        {
            this.allCourses = courses;
            this.allStudents = students;
            this.dataFilter = dataFilter;
            this.dataSorter = dataSorter;
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitialized);
            }

            this.isDataInitialized = false;
            allCourses = null;
            allStudents = null;
        }

        public void LoadData(string fileName)
        {
            if (!this.isDataInitialized)
            {
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
                var input = File.ReadAllLines(SessionData.currentPath + "\\" + fileName);

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

                        if (studentScores.Length > SoftUniCourse.NumberOfTasksOnExam)
                        {
                            OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                            continue;
                        }


                        if (!allCourses.ContainsKey(courseName))
                        {
                            allCourses[courseName] = new SoftUniCourse(courseName);
                        }
                        if (!allStudents.ContainsKey(studentName))
                        {
                            allStudents.Add(studentName, new SoftUniStudent(studentName));
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

        public void GetStudentScoresFromCourse(string courseName, string studentName)
        {
            if (IsQueryForStudentPossible(courseName, studentName))
            {
                var score = allStudents[studentName].MarksByCourseName[courseName];
                var student = new KeyValuePair<string, double>(studentName, score);

                OutputWriter.PrintStudent(student);
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}.");

                allCourses[courseName].Students
                    .ForEach(st => OutputWriter
                        .PrintStudent(new KeyValuePair<string, double>(st.UserName, st.MarksByCourseName[courseName])));
            }
        }

        public void ShowData(string courseName, string studentName)
        {
            if (studentName == null)
            {
                this.GetAllStudentsFromCourse(courseName);
            }
            else
            {
                this.GetStudentScoresFromCourse(courseName, studentName);
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

                dataFilter.FilterAndTake(studentsWithMarks, givenFilter, studentsToTake);
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

                dataSorter.OrderAndTake(studentsWithMarks, comparison, studentsToTake);
            }
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

        public ISimpleSortedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> comparer)
        {
            var sortedCourses = new SimpleSortedList<ICourse>(comparer);

            sortedCourses.AddAll(allCourses.Values);

            return sortedCourses;
        }

        public ISimpleSortedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> comparer)
        {
            var sortedStudents = new SimpleSortedList<IStudent>(comparer);
            
            sortedStudents.AddAll(allStudents.Values);

            return sortedStudents;
        }
    }
}
