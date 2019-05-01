using System;

namespace OnlineRadioDatabase.Exceptions
{
    internal class InvalidSongException : Exception
    {
        public override string Message => "Invalid song.";
    }
}
