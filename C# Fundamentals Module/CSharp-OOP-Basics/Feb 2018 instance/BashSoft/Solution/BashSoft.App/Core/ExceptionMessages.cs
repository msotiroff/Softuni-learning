namespace BashSoft.App.Core
{
    public class ExceptionMessages
    {
        public const string DataAlreadyInitialized = "Data is already initialized!";

        public const string DataNotInitialized = 
            "The data structure must be initialized first in order to make any operations with it.";

        public const string InexistantCourseInDataBase = 
            "The course you are trying to get does not exist in the data base!";

        public const string InexistantStudentInDataBase = 
            "The user name for the student you are trying to get does not exist!";
        
        public const string UnauthorizedAccess =
            "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes =
            "Files not of equal size, certain mismatch.";
        
        public const string UnableToGoHigherInPartitionHierarchy =
            "Unable to go higher in partition hierarchy";

        public const string InvalidStudentFilter = 
            "The given filter is not one of the following: excellent/average/poor";

        public const string InvalidComparisonQuery = 
            "The comparison query you want, does not exist in the context of the current program!";

        public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";
    }
}
