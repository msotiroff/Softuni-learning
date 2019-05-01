namespace P04.OnlineRadioDatabase.Exceptions
{
    using System;

    internal class InvalidSongException : Exception
    {
        public override string Message => "Invalid song.";
    }
}
