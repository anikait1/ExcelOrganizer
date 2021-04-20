using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicExcelOrganizer.Models
{
    public class GeneralFile : IExcelSerializer
    {
        #region File Properties
        public string Name { get; init; }
        public string Path { get; init; }
        public string Type { get; init; }
        public long Size { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateAccessed { get; set; }
        public DateTime DateModified { get; init; }
        #endregion

        public GeneralFile(FileInfo file)
        {
            Name = file.Name;
            Path = file.FullName;
            Type = file.Extension;
            Size = file.Length;

            DateCreated = file.CreationTime;
            DateAccessed = file.LastAccessTime;
            DateModified = file.LastWriteTime;
        }

        public void WriteToExcelRow(IXLWorksheet worksheet, int row)
        {
            worksheet.Cell(row, 1).Value = Name;
            worksheet.Cell(row, 2).Value = Path;
            worksheet.Cell(row, 3).Value = Type;
            worksheet.Cell(row, 4).Value = Size;

            worksheet.Cell(row, 5).Value = DateCreated;
            worksheet.Cell(row, 6).Value = DateAccessed;
            worksheet.Cell(row, 7).Value = DateModified;
        }
    }
}
