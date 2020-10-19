using Diploma.Models;
using Diploma.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Utils
{
    public class StringCreator : IStringCreator
    {
        private readonly IConstants constants;
        private readonly IDomainWrapper domainWrapper;

        public StringCreator(IConstants constants, IDomainWrapper domainWrapper)
        {
            this.constants = constants;
            this.domainWrapper = domainWrapper;
        }

        public string CreatePath(string name, string surname)
        {
            var directory = domainWrapper.GetRoothDirectory();
            return directory + name + surname + constants.GetExtension;
        }

        public string GetFirstParagraph(string name, string surname)
        {
            var initialText = constants.GetDiplomNameText;

            return initialText + "\n" + name + " " + surname;
        }

        public string GetSecondParagraphText(IEnumerable<Subject> grades)
        {
            var sb = new StringBuilder();
            foreach (var record in grades)
            {
                sb.Append(record.SubjectName + " " + record.Grade + "\n");
            }
            return sb.ToString();
        }
    }
}