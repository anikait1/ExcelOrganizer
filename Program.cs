using CommandLine;
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
                Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
                {
                    Console.WriteLine($"\nRunning with following configuration. Category: {options.Category}, Directory: {options.Directory}\n");
                    
                    string filename = options.Directory.Split('\\').Last();
                    (HashSet<string> extensions, string[] titles, Func<string, IExcelSerializer> map) = Profile.GetProfile(options.Category);

                    IExcelSerializer[] data = FileFetcher.GetFiles(options.Directory, extensions)
                                                         .SelectSkipExceptions(map)
                                                         .ToArray();
                    ExcelWriter.WriteToExcelFile(filename, titles, data);
                    Console.WriteLine($"\nFile Saved: {Path.Combine(options.Directory, filename)}\n");
                });
            } 
            catch (Exception exception)
            {
                Console.WriteLine($"Program encountered an error: ${exception}. Please report the error on Github: https://github.com/anikait1/MusicExcelOrganizer/");
            }
        }
    }

}
