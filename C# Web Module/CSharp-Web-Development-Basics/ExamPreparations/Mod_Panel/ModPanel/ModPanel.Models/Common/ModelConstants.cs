namespace ModPanel.Models.Common
{
    public class ModelConstants
    {
        public const int UserUsernameMinLength = 3;

        public const string TitlePattern = "^[A-Z].{2,99}$";
        public const string TitleErrorMessage = "Post title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive)";
    }
}
