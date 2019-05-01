namespace BashSoft.App.Repositories
{
    using BashSoft.App.Extensions;
    using Core;
    using IO;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class StudentRepository
    {
        private static bool isDataInitialized = false;

        // --------------------- <CourseName<StudentName, Grades>>
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitialized);
                return false;
            }

            if (!studentsByCourse.ContainsKey(courseName))
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistantCourseInDataBase);
                return false;
            }

            return true;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistantStudentInDataBase);
                return false;
            }


        }

        internal static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine(Constants.ReadingData);
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialized);
            }
        }

        private static void ReadData(string fileName)
        {
            var inputPattern = @"^(?<Course>[A-Z][A-Za-z\+\#]*_[A-Z][a-z]{2}_20\d{2})\s+(?<UserName>[A-Z][a-z]{3,}\d{2}_\d{2,4})\s+(?<Score>100|\d{1,2})$";

            var inputValidator = new Regex(inputPattern);

            try
            {
                var input = File.ReadAllLines(SessionData.currentPath + "\\" + fileName); //File.ReadAllLines(Constants.StudentsDataFilePath);

                for (int line = 0; line < input.Length; line++)
                {
                    // var studentParams = input[line].Split();

                    var match = inputValidator.Match(input[line]);

                    if (match.Success)
                    {
                        var course = match.Groups["Course"].Value;
                        var name = match.Groups["UserName"].Value;
                        var mark = int.Parse(match.Groups["Score"].Value);

                        if (!studentsByCourse.ContainsKey(course))
                        {
                            studentsByCourse[course] = new Dictionary<string, List<int>>();
                        }
                        if (!studentsByCourse[course].ContainsKey(name))
                        {
                            studentsByCourse[course][name] = new List<int>();
                        }

                        studentsByCourse[course][name].Add(mark);
                    }
                }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine(Constants.DataRead);
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        internal static void GetStudentScoresFromCourse(string courseName, string studentName)
        {
            if (IsQueryForStudentPossible(courseName, studentName))
            {
                var student = new KeyValuePair<string, List<int>>(studentName, studentsByCourse[courseName][studentName]);
                OutputWriter.PrintStudent(student);
            }
        }

        internal static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}.");

                studentsByCourse[courseName]
                    .ForEach(st => OutputWriter.PrintStudent(st));
            }
        }

        internal static void ShowWantedData(params string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidCommandParams);
            }
            else
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
        }

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }
    }
}
