namespace P04.OnlineRadioDatabase.Exceptions
{
    internal class InvalidSongSecondsException : InvalidSongLengthException
    {
        public override string Message => "Song seconds should be between 0 and 59.";
    }
}
