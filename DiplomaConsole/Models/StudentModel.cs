using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Subject> Grades { get; set; }
    }
}
