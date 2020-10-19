using System.IO;

namespace Diploma.Wrappers
{
    public class FileWrapper : IFileWrapper
    {
        public TextReader OpenText(string path)
        {
            return File.OpenText(path);
        }
    }
}