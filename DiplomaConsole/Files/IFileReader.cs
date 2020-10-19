using Diploma.Models;
using System.Collections.Generic;

namespace Diploma.Files
{
    public interface IFileReader
    {
        IEnumerable<StudentRawModel> ImportData(string path);
    }
}