using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicExcelOrganizer
{
    /// <summary>
    /// Responsible for handling of fetching the files from a given directory and its
    /// sub-directories
    /// </summary>
    static class FileFetcher
    {
        private static readonly HashSet<string> extensions = new() { ".mp3", ".wma", ".flac", ".m4a", ".aac" };

        /// <summary>
        /// Iterate through given directory and sub directories, to fetch valid
        /// files and convert them to MusicFileInfo.
        /// </summary>
        /// <param name="directory">Directory to search for files.</param>
        /// <returns>MusicFileInfo representation of valid files.</returns>
        public static MusicFileInfo[] GetMusicFiles(string directory)
        {
            return Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories)
                                      .Where(file => extensions.Contains(new FileInfo(file).Extension, StringComparer.OrdinalIgnoreCase))
                                      .Select(file =>
                                      {
                                          TagLib.File tfile = TagLib.File.Create(file);
                                          FileInfo fileInfo = new (file);

                                          return new MusicFileInfo(tfile, fileInfo);
                                      })
                                      .ToArray();
        }
    }
}
