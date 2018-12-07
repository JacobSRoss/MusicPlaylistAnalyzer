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
                report += "Not available. \r\n";
            }

            report += $"\r\nNumber of Alternative songs: ";
            var alternativeSongs = (from musicStats in musicStatsList where musicStats.Genre == "Alternative" select musicStats).Count();
            report += $"{alternativeSongs}\r\n";

            report += "\r\nNumber of Hip-Hop/Rap songs: ";
            var rapSongs = (from musicStats in musicStatsList where musicStats.Genre == "Hip-Hop/Rap" select musicStats).Count();
            report += $"{rapSongs}\r\n";

            report += "\r\nSongs from the album Welcom to the Fishbowl: ";
            var albumSongs = from musicStats in musicStatsList where musicStats.Album == "Welcom to the Fishbowl" select new { musicStats.Name, musicStats.Artist, musicStats.Album, musicStats.Genre, musicStats.Size, musicStats.Time, musicStats.Year, musicStats.Plays };
            if (albumSongs.Count() > 0)
            {
                foreach (var song in albumSongs)
                {
                    report += "Name: " + song.Name + ", Artist: " + song.Artist + ", Album: " + song.Album + ", Genre: " + song.Genre + ", Size: " + song.Size + ", Time: " + song.Time + ", Year: " + song.Year + ", Plays: " + song.Plays;
                    report += "\r\n";
                }
            } else
            {
                report += "Not available. \r\n";
            }

            report += "\r\nSongs from before 1970: ";
            var songsBeforeTime = from musicStats in musicStatsList where musicStats.Year < 1970 select new { musicStats.Name, musicStats.Artist, musicStats.Album, musicStats.Genre, musicStats.Size, musicStats.Time, musicStats.Year, musicStats.Plays };
            if(songsBeforeTime.Count() > 0)
            {
                foreach (var song in songsBeforeTime)
                {
                    report += "Name: " + song.Name + ", Artist: " + song.Artist + ", Album: " + song.Album + ", Genre: " + song.Genre + ", Size: " + song.Size + ", Time: " + song.Time + ", Year: " + song.Year + ", Plays: " + song.Plays;
                    report += "\r\n";
                }
            } else
            {
                report += "Not Available. \r\n";
            }

            report += "\r\nSong names longer than 85 characters: ";
            var longSongNames = from musicStats in musicStatsList where musicStats.Name.Length > 85 select musicStats;
            if(longSongNames.Count() > 0)
            {
                foreach (var songName in longSongNames)
                {
                    report += songName.Name;
                }
            } else
            {
                report += "Not Available. \r\n";
            }

            report += "\r\nLongest song: ";
            var longSong = from musicStats in musicStatsList orderby musicStats.Time descending select new { musicStats.Name, musicStats.Artist, musicStats.Album, musicStats.Genre, musicStats.Size, musicStats.Time, musicStats.Year, musicStats.Plays };
            if(longSong.Count() > 0)
            {
                foreach (var song in longSong)
                {
                    report += "Name: " + song.Name + ", Artist: " + song.Artist + ", Album: " + song.Album + ", Genre: " + song.Genre + ", Size: " + song.Size + ", Time: " + song.Time + ", Year: " + song.Year + ", Plays: " + song.Plays;
                    report += "\r\n";
                    break;
                }
            } else
            {
                report += "Not Available. \r\n";
            }




            return report;
        }
        
    }
}
