namespace P04.OnlineRadioDatabase.Exceptions
{
    internal class InvalidSongNameException : InvalidSongException
    {
        public override string Message => "Song name should be between 3 and 30 symbols.";
    }
}
