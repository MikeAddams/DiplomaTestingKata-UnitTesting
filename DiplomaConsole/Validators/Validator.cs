using Diploma.Models;
using System;

namespace Diploma.Validators
{
    public class Validator : IValidator
    {
        public bool ValidateStudentRecord(StudentModel student)
        {
            if (String.IsNullOrEmpty(student.FirstName) || String.IsNullOrEmpty(student.LastName))
            {
                return false;
            }
            foreach (var subject in student.Grades)
            {
                if (String.IsNullOrEmpty(subject.SubjectName) || subject.Grade <= 0 || subject.Grade > 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}