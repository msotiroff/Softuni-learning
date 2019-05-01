using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackDownloader
{
    class TrackDownloader
    {
        static void Main(string[] args)
        {
            List<string> blackListed = Console.ReadLine().Split(' ').ToList();

            string currentTrack = Console.ReadLine();
           

            List<string> downloadedTracks = new List<string>();

            while (currentTrack != "end")
            {
                for (int i = 0; i < blackListed.Count; i++)
                {
                    if (!currentTrack.Contains(blackListed[i]))
                    {
                        if (i == blackListed.Count - 1)
                        {
                            downloadedTracks.Add(string.Join(" ", currentTrack));
                        }
                    }
                    else
                    {
                        break;
                    }
                   
                }
                currentTrack = Console.ReadLine();
            }

            downloadedTracks.Sort();

            foreach (var tracks in downloadedTracks)
            {
                Console.WriteLine(tracks);
            }
        }
    }
}
