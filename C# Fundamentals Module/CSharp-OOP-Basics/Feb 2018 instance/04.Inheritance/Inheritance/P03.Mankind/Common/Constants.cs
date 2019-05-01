namespace P03.Mankind.Common
{
    internal static class Constants
    {
        public static readonly int FirstNameMinLength = 4;
        public static readonly int LastNameMinLength = 3;

        public static readonly int FacultyNumberMinimum = 5;
        public static readonly int FacultyNumberMaximum = 10;

        public static readonly decimal MinWeeklySalary = 10.0m;

        public static readonly int MinDailyWorkHours = 1;
        public static readonly int MaxDailyWorkHours = 12;

        public static readonly string InvalidNameLength = "Expected length at least {0} symbols! Argument: {1}";

        public static readonly string InvalidNameBegining = "Expected upper case letter! Argument: {0}";

        public static readonly string InvalidFacultyNumber = "Invalid faculty number!";

        public static readonly string InvalidExpectedValueForWorker = "Expected value mismatch! Argument: {0}";
    }
}
