using ClosedXML.Excel;
using MyPlaylistExam.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam
{
    public class ToExel
    {
        DataSet dataSet = new DataSet();
        static public void WriteToExcel()
        {
            EFContext _context = new EFContext();
            var list = _context.Tracks.ToList();
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("DataWorksheet");
            PropertyInfo[] properties = list.First().GetType().GetProperties();
            List<string> headerNames = properties.Select(prop => prop.Name).ToList();
            for (int i = 0; i < headerNames.Count; i++)
            {
                ws.Cell(1, i + 1).Value = headerNames[i];
            }
            ws.Cell(2, 1).InsertData(list);
            wb.SaveAs(@"Tracks.xlsx");
        }
    }
}
