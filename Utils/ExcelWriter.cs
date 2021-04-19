using ClosedXML.Excel;
using MusicExcelOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicExcelOrganizer.Utils
{
    /// <summary>
    /// Deals with CRUD operations related to excel file
    /// </summary>
    public static class ExcelWriter
    {
        private static readonly int _titleColumnPadding = 1;
        private static readonly int _dataRowPadding = 2;
        
        public static void WriteToExcelFile(string directory, string[] titles, IExcelSerializer[] data)
        {
            using (XLWorkbook workbook = new())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet 1");

                AddColumnTitles(worksheet, titles);
                AddData(worksheet, data);

                worksheet.Columns(1, titles.Length).AdjustToContents();
                workbook.SaveAs($"{directory}.xlsx");
            }
        }

        /// <summary>
        /// Populate the worksheet with the given array of titles.
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="titles"></param>
        private static void AddColumnTitles(IXLWorksheet worksheet, string[] titles)
        {
            for (int i = 0; i < titles.Length; ++i)
            {
                worksheet.Cell(1, i + _titleColumnPadding).Value = titles[i];
            }
        }

        /// <summary>
        /// Populate the worksheet with the given array of data.
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="data"></param>
        private static void AddData(IXLWorksheet worksheet, IExcelSerializer[] data)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                data[i].WriteToExcelRow(worksheet, i + _dataRowPadding);
            }
        }
    }
}
