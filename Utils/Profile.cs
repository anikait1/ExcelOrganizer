using MusicExcelOrganizer.Models;
using System;
using System.Collections.Generic;

namespace MusicExcelOrganizer.Utils
{
    public static class Profile
    {
        private static readonly Dictionary<FileCategory, HashSet<string>> _extensionsByCategory = new()
        {
            { FileCategory.audio, new() { ".mp3", ".wma", ".flac", ".m4a", ".aac" } },
            { FileCategory.all, new() { } }
        };

        private static readonly Dictionary<FileCategory, string[]> _titlesByCategory = new()
        {
            { FileCategory.audio, new[] { "Name", "Title", "Contributing Artists", "Year", "Genre", "Album", "Path", "Album Artists", "Date Modified", "Length", "Type", "Composers" } },
            { FileCategory.all, new[] { "Name", "Path", "Type", "Size", "Date Created", "Date Accessed", "Date Modified", } }
        };

        private static readonly Dictionary<FileCategory, Func<string, IExcelSerializer>> _mappingByCategory = new()
        {
            { FileCategory.audio, (file) => new AudioFile(new ATL.Track(file), new System.IO.FileInfo(file)) },
            { FileCategory.all, (file) => new GeneralFile(new System.IO.FileInfo(file)) },
        };

        public static (HashSet<string>, string[], Func<string, IExcelSerializer>) GetProfile(FileCategory category)
        {
            return (_extensionsByCategory[category], 
                    _titlesByCategory[category], 
                    _mappingByCategory[category]);
        }
    }

}
