using GemBox.Document;

namespace Diploma.Wrappers
{
    public interface IDocWrapper
    {
        void SaveDocument(DocumentModel doc, string name);
    }
}