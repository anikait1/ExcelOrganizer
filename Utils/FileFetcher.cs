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
    public static class FileFetcher
    {
        /// <summary>
        /// Enumerate all the files in the given directory and its sub-directories and
        /// only filter out the ones which belong to the given category.
        /// </summary>
        /// <param name="category">Category of files to filter</param>
        /// <param name="directory">Directory to enumerate in</param>
        /// <returns></returns>
        public static IEnumerable<string> GetFiles(string directory, HashSet<string> extensions)
        {
            IEnumerable<string> query = Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories);

            if (extensions.Count != 0)
            {
                query = query.Where(file => extensions.Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase));
            }

            return query;
        }


        /// <summary>
        /// This extension method skips those values which raise an Exception
        /// </summary>
        /// <param name="values"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        /**/
    }
}
