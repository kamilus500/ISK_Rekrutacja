using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace ISK_Rekrutacja.Services
{
    public interface IExportService
    {
        public byte[] ExportToExcel<T>(List<T> data, string fileName);
    }
}
