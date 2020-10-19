using OfficeOpenXml;
using System.IO;

namespace Diploma.Wrappers
{
    public class ExcelWrapper : IExcelWrapper
    {
        public ExcelPackage GetExcelPackage(string path)
        {
            return new ExcelPackage(new FileInfo(path));
        }
    }
}