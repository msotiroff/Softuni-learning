namespace P04.OnlineRadioDatabase.Exceptions
{
    internal class InvalidSongMinutesException : InvalidSongLengthException
    {
        public override string Message => "Song minutes should be between 0 and 14.";
    }
}
