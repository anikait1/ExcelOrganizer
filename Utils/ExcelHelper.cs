using ClosedXML.Excel;
using MusicExcelOrganizer.Models;

namespace MusicExcelOrganizer.Utils
{
    /// <summary>
    /// Deals with CRUD operations related to excel file
    /// </summary>
    public static class ExcelHelper
    {
        private static readonly string[] titles = { "Name", "Title", "Contributing Artists", "Year", "Genre", "Album", "Path", "Album Artists", "Date Modified", "Length", "Type", "Composers" };

        /// <summary>
        /// Creates the Excel file, writes content and adjusts the column width.
        /// </summary>
        /// <param name="musicFileInfos">The array to be written to file.</param>
        public static void WriteToExcelFile(MusicFileInfo[] musicFileInfos, string directory)
        {
            using (XLWorkbook workbook = new ())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet 1");

                AddColumnTitles(worksheet);
                AddMusicData(worksheet, musicFileInfos);

                worksheet.Columns(1, 12).AdjustToContents();
                workbook.SaveAs($"{directory}.xlsx");
            }
        }

        /// <summary>
        /// Write the titles to the first row of the Excel Worksheet.
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="titles"></param>
        private static void AddColumnTitles(IXLWorksheet worksheet)
        {
            for (int i = 0, row = 1; i < titles.Length; ++i)
            {
                worksheet.Cell(row, i + 1).Value = titles[i];
            }
        }

        /// <summary>
        /// Write the given array of MusicFileInfo to the Excel Worksheet.
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="musicFileInfos"></param>
        private static void AddMusicData(IXLWorksheet worksheet, MusicFileInfo[] musicFileInfos)
        {
            for (int i = 0, row = 2, col = 1; i < musicFileInfos.Length; ++i, col = 1)
            {
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Name;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Title;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].ContributingArtists;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Year;

                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Genre;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Album;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Path;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].AlbumArtists;

                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].DateModified;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Length;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Type;
                worksheet.Cell(row + i, col++).Value = musicFileInfos[i].Composers;
            }
        }
    }
}
