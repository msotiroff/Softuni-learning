namespace P04.OnlineRadioDatabase.Exceptions
{
    internal class InvalidSongLengthException : InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }
}
