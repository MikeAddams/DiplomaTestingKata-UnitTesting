using Diploma.Models;
using GemBox.Document;

namespace Diploma.Files
{
    public interface IFileWriter
    {
        DocumentModel CreateDiplomas(StudentModel student);
        void SaveDiploma(DocumentModel studentDiploma, string FirstName, string LastName);
    }
}