using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistAnalyzer
{
    class MusicStatsReport
    {
        public static string GenerateText(List<MusicStats> musicStatsList)
        {
            string report = "Music Playlist Analyzer Report \r\n\r\n";

            if (musicStatsList.Count() < 1)
            {
                Console.WriteLine("musicStatsList.Count: " + musicStatsList.Count());
                report += "No data is available.\r\n";

                return report;
            }

            report += $"Songs that received 200 or more plays: \r\n";
            var amountOfPlays = from musicStats in musicStatsList where musicStats.Plays > 200 select new { musicStats.Name, musicStats.Artist, musicStats.Album, musicStats.Genre, musicStats.Size, musicStats.Time, musicStats.Year, musicStats.Plays };
            if (amountOfPlays.Count() > 0)
            {
                foreach (var song in amountOfPlays)
                {
                    report += "Name: " + song.Name + ", Artist: " + song.Artist + ", Album: " + song.Album + ", Genre: " + song.Genre + ", Size: " + song.Size + ", Time: " + song.Time + ", Year: " + song.Year + ", Plays: " + song.Plays;
                    report += "\r\n";
                }
            } else
            {
                report += "Not available. \n";
            }
            





            return report;
        }
        
    }
}
