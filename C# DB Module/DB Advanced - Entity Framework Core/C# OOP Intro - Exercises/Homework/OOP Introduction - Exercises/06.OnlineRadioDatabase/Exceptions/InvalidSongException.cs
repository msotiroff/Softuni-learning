namespace _06.OnlineRadioDatabase
{
    using System;

    public class InvalidSongException : Exception
    {
        public override string Message => "Invalid song.";
    }
}
