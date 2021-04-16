using ATL;
using MusicExcelOrganizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicExcelOrganizer.Utils
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
            return Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories)
                            .Where(file => extensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
                            .SelectSkipExceptions(file => new MusicFileInfo(new Track(file), new FileInfo(file)))
                            .ToArray();
        }


        /// <summary>
        /// This extension method skips those values which raise an Exception
        /// </summary>
        /// <param name="values"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<MusicFileInfo> SelectSkipExceptions(
            this IEnumerable<string> values, 
            Func<string, MusicFileInfo> selector)
        {
            foreach (var item in values)
            {
                MusicFileInfo output;
                try
                {
                    Console.WriteLine($"Processing {item}");
                    output = selector(item);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Previous file is skipped. Error: {exception.Message}");
                    continue;
                }

                yield return output;
            }
        }
    }
}
