﻿namespace _06.OnlineRadioDatabase
{
    public class InvalidArtistNameException : InvalidSongException
    {
        public override string Message => "Artist name should be between 3 and 20 symbols.";
    }
}
