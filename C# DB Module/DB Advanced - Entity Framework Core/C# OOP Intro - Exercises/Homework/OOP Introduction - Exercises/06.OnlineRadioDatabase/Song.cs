namespace _06.OnlineRadioDatabase
{
    public class Song
    {
        private string songName;
        private string artistName;
        private int minutes;
        private int seconds;

        public Song(string artist, string track, int minutes, int seconds)
        {
            this.SongName = track;
            this.ArtistName = artist;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public int Seconds
        {
            get { return this.seconds; }
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }


        public int Minutes
        {
            get { return this.minutes; }
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }


        public string ArtistName
        {
            get { return this.artistName; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }


        public string SongName
        {
            get { return this.songName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

    }
}
