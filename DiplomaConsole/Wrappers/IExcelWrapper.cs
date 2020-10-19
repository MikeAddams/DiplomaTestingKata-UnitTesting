using OfficeOpenXml;

namespace Diploma.Wrappers
{
    public interface IExcelWrapper
    {
        ExcelPackage GetExcelPackage(string path);
    }
}