using System.Collections.Generic;
using Diploma.Models;

namespace Diploma.Utils
{
    public interface IStringCreator
    {
        string CreatePath(string name, string surname);
        string GetFirstParagraph(string nume, string prenume);
        string GetSecondParagraphText(IEnumerable<Subject> grades);
    }
}