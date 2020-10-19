using Diploma.Models;

namespace Diploma.Validators
{
    public interface IValidator
    {
        bool ValidateStudentRecord(StudentModel student);
    }
}