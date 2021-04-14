using MusicExcelOrganizer.Models;
using MusicExcelOrganizer.Utils;
using System;
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
                string folderName = currentDirectory.Split('\\').Last();

                MusicFileInfo[] musicFileInfos = FileFetcher.GetMusicFiles(currentDirectory);
                ExcelHelper.WriteToExcelFile(musicFileInfos, folderName);
            } 
            catch (Exception exception)
            {
                Console.WriteLine($"Program encountered an error: ${exception}. Please report the error on Github: https://github.com/anikait1/MusicExcelOrganizer/");
            }
        }
    }
}
