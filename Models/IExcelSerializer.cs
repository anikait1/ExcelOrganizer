using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicExcelOrganizer.Models
{
    /// <summary>
    /// Classes implementing this interface can be serialized to an Excel worksheet
    /// </summary>
    public interface IExcelSerializer
    {
        public void WriteToExcelRow(ClosedXML.Excel.IXLWorksheet worksheet, int row);
    }
}
