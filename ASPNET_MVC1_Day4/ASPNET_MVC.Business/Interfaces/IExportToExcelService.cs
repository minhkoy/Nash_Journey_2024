using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_MVC.Business.Interfaces
{
    public interface IExportToExcelService
    {
        MemoryStream ExportListToExcel<T>(List<T> values, string? worksheetName);
    }
}
