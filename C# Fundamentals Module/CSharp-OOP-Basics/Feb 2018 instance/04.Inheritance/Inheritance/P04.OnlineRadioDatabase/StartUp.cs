namespace P04.OnlineRadioDatabase
{
    using Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var playList = new HashSet<Song>();

            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                try
                {
                    var songParams = Console.ReadLine()
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    var artist = songParams[0];
                    var title = songParams[1];
                    var duration = songParams[2].Split(':');
                    var songMinutes = int.Parse(duration[0]);
                    var songSeconds = int.Parse(duration[1]);

                    var song = new Song(artist, title, songMinutes, songSeconds);

                    playList.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException)
                {
                    Console.WriteLine(new InvalidSongLengthException().Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().Message);
                }
            }

            var playlistLength = new DateTime();
            playlistLength = playlistLength.AddSeconds(playList.Sum(s => s.SongSeconds));
            playlistLength = playlistLength.AddMinutes(playList.Sum(s => s.SongMinutes));

            Console.WriteLine($"Songs added: {playList.Count}");
            Console.WriteLine("Playlist length: {0}h {1}m {2}s",
                playlistLength.Hour,
                playlistLength.Minute,
                playlistLength.Second);
        }
    }
}
