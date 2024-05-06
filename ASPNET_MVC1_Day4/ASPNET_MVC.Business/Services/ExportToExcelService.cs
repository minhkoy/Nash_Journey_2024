using ASPNET_MVC.Business.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_MVC.Business.Services
{
    public class ExportToExcelService : IExportToExcelService
    {

        public MemoryStream ExportListToExcel<T>(List<T> values, string? worksheetName)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add(worksheetName ?? "Sheet1");;
                ws.Cells.AutoFitColumns();
                var stream = new MemoryStream();
                pck.SaveAs(stream);

                return stream;                
            }
            throw new NotImplementedException();
        }
    }
}
