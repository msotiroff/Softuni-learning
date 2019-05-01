namespace _06.OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            List<Song> allValidSongs = new List<Song>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputParams = Console.ReadLine().Split(';');

                try
                {
                    string artistName = inputParams[0];
                    string songName = inputParams[1];
                    string[] songLenghtParams = inputParams[2].Split(':');
                    int songMinutes = int.Parse(songLenghtParams[0]);
                    int songSeconds = int.Parse(songLenghtParams[1]);

                    Song currentSong = new Song(artistName, songName, songMinutes, songSeconds);

                    allValidSongs.Add(currentSong);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);                    
                }
                catch (FormatException)
                {
                    Console.WriteLine(new InvalidSongLengthException().Message);
                }
            }

            int allMinutes = allValidSongs.Sum(s => s.Minutes);
            int allSeconds = allValidSongs.Sum(s => s.Seconds);
            int allTimeInSeconds = (allMinutes * 60) + allSeconds;

            DateTime time = new DateTime();
            time = time.AddSeconds(allTimeInSeconds);

            string playlistLenght = $"{time.Hour}h {time.Minute}m {time.Second}s";

            Console.WriteLine($"Songs added: {allValidSongs.Count}");
            Console.WriteLine($"Playlist length: {playlistLenght}");
        }
    }
}
