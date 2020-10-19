using System.Collections.Generic;
using Diploma.Models;

namespace Diploma.Utils
{
    public interface ICustomMapper
    {
        IEnumerable<StudentModel> MapToStudent(IEnumerable<StudentRawModel> rawModels);
    }
}