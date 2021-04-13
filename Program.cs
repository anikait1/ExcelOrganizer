using System;

namespace MusicExcelOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Environment.CurrentDirectory;
            MusicFileInfo[] musicFileInfos = FileFetcher.GetMusicFiles(currentDirectory);

            ExcelOperations.WriteToExcelFile(musicFileInfos);
        }
    }
}
