using GemBox.Document;

namespace Diploma.Wrappers
{
    public class DocWrapper : IDocWrapper
    {
        public void SaveDocument(DocumentModel doc, string name)
        {
            doc.Save(name);
        }
    }
}