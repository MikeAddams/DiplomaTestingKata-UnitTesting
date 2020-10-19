using Diploma.Models;
using Diploma.Utils;
using Diploma.Wrappers;
using GemBox.Document;
using System.Collections.Generic;

namespace Diploma.Files
{
    public class FileWriter : IFileWriter
    {
        private readonly IDocWrapper pdfWrapper;
        private readonly IStringCreator stringCreator;

        public FileWriter(IDocWrapper pdfWrapper, IStringCreator stringCreator)
        {
            this.pdfWrapper = pdfWrapper;
            this.stringCreator = stringCreator;
        }

        public DocumentModel CreateDiplomas(StudentModel student)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var document = new DocumentModel();
            var firstParagraphText = stringCreator.GetFirstParagraph(student.LastName, student.FirstName);
            var secondParagraphText = stringCreator.GetSecondParagraphText(student.Grades);
            document.Sections.Add(new Section(document, 
                new List<Paragraph>() { new Paragraph(document, firstParagraphText), new Paragraph(document, secondParagraphText) }));
            return document;
        }

        public void SaveDiploma(DocumentModel studentDiploma, string FirstName, string LastName)
        {
            var path = stringCreator.CreatePath(LastName, FirstName);
            pdfWrapper.SaveDocument(studentDiploma, path);
        }
    }
}