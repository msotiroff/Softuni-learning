namespace P04.OnlineRadioDatabase
{
    using Exceptions;

    internal class Song
    {
        private string artist;
        private string title;
        private int songMinutes;
        private int songSeconds;

        public Song(string artist, string title, int songMinutes, int songSeconds)
        {
            this.Artist = artist;
            this.Title = title;
            this.SongMinutes = songMinutes;
            this.SongSeconds = songSeconds;
        }

        public int SongSeconds
        {
            get => this.songSeconds;

            private set
            {
                // Song seconds should be between 0 and 59.
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.songSeconds = value;
            }
        }

        public int SongMinutes
        {
            get => this.songMinutes;

            private set
            {
                // Song minutes should be between 0 and 14.
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.songMinutes = value;

            }
        }

        public string Title
        {
            get => this.title;

            private set
            {
                // Song name should be between 3 and 30 symbols.
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.title = value;
            }
        }

        public string Artist
        {
            get => this.artist;

            private set
            {
                // Artist name should be between 3 and 20 symbols.
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artist = value;
            }
        }
    }
}