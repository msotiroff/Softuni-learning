﻿namespace BashSoft.App.Core
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

        public const string InvalidPath = 
            "The folder/file you are trying to access at the current address, does not exist.";

        public const string UnauthorizedAccess =
            "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes =
            "Files not of equal size, certain mismatch.";

        public const string ForbiddenSymbolsContainedInName =
            "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public const string UnableToGoHigherInPartitionHierarchy =
            "Unable to go higher in partition hierarchy";

        public const string InvalidCommand = "Invalid command";

        public const string InvalidCommandParams = "Invalid command parameters";

        public const string InvalidStudentFilter = 
            "The given filter is not one of the following: excellent/average/poor";

        public const string InvalidComparisonQuery = 
            "The comparison query you want, does not exist in the context of the current program!";
    }
}
