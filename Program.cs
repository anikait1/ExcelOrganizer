using MusicExcelOrganizer.Models;
using MusicExcelOrganizer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicExcelOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string currentDirectory = Environment.CurrentDirectory;
                currentDirectory = @"C:\Users\Anikait\Downloads";
                string folderName = currentDirectory.Split('\\').Last();
                string category = "all";

                var profile = Profile.GetProfile(category);
                (HashSet<string> extensions, string[] titles, Func<string, IExcelSerializer> map) = Profile.GetProfile(category);

                var data = FileFetcher.GetFiles(currentDirectory, extensions)
                                      .SelectSkipExceptions(file => map(file))
                                      .ToArray();

                ExcelWriter.WriteToExcelFile(folderName, titles, data);
            } 
            catch (Exception exception)
            {
                Console.WriteLine($"Program encountered an error: ${exception}. Please report the error on Github: https://github.com/anikait1/MusicExcelOrganizer/");
            }
        }
    }

    static class LinqExtensions
    {
        public static IEnumerable<TResult> SelectSkipExceptions<TSource, TResult>(
            this IEnumerable<TSource> values,
            Func<TSource, TResult> selector)
        {
            foreach (var item in values)
            {
                TResult output;
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
