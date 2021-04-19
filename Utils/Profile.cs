using MusicExcelOrganizer.Models;
using System;
using System.Collections.Generic;

namespace MusicExcelOrganizer.Utils
{
    public static class Profile
    {
        private static readonly Dictionary<string, HashSet<string>> _extensionsByCategory = new()
        {
            { "audio", new() { ".mp3", ".wma", ".flac", ".m4a", ".aac" } },
            { "all", new() { } }
        };

        private static readonly Dictionary<string, string[]> _titlesByCategory = new()
        {
            { "audio", new[] { "Name", "Title", "Contributing Artists", "Year", "Genre", "Album", "Path", "Album Artists", "Date Modified", "Length", "Type", "Composers" } },
            { "all", new[] { "Name", "Path", "Type",  "Date Created", "Date Accessed", "Date Modified",  } }
        };

        private static readonly Dictionary<string, Func<string, IExcelSerializer>> _mappingByCategory = new()
        {
            { "audio", (file) => new AudioFile(new ATL.Track(file), new System.IO.FileInfo(file)) },
            { "all", (file) => new GeneralFile(new System.IO.FileInfo(file)) },
        };

        public static (HashSet<string>, string[], Func<string, IExcelSerializer>) GetProfile(string category)
        {
            return (_extensionsByCategory[category], 
                    _titlesByCategory[category], 
                    _mappingByCategory[category]);
        }
    }

}
