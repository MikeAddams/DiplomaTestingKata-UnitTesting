using System.IO;

namespace Diploma.Wrappers
{
    public interface IFileWrapper
    {
        TextReader OpenText(string path);
    }
}