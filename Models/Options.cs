using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicExcelOrganizer.Models
{
    /// <summary>
    /// Holds the different options that are made available through the command line
    /// interface.
    /// </summary>
    public class Options
    {
        [Option('c', "category", Required = true, HelpText = "Category of files: [all, audio]")]
        public FileCategory Category { get; set; }

        [Option('d', "directory", Required = true, HelpText = "Directory to be scanned. By default it is set to the directory where program is being executed")]
        public string Directory { get; set; } = Environment.CurrentDirectory;
    }
}
