using OfficeOpenXml.Table;
using OfficeOpenXml;

namespace ISK_Rekrutacja.Services
{
    public class ExportService : IExportService
    {
        public byte[] ExportToExcel<T>(List<T> data, string fileName)
        {
            using ExcelPackage pack = new ExcelPackage();
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add(fileName);
            ws.Cells["A1"].LoadFromCollection(data, true, TableStyles.Light1);
            return pack.GetAsByteArray();
        }
    }
}
