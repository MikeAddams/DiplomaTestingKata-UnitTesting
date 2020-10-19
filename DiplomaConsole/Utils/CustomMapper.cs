using Diploma.Models;
using System.Collections.Generic;

namespace Diploma.Utils
{
    public class CustomMapper : ICustomMapper
    {
        public IEnumerable<StudentModel> MapToStudent(IEnumerable<StudentRawModel> rawModels)
        {
            var finalStudents = new List<StudentModel>();
            foreach (var studentRecord in rawModels)
            {
                var grades = new List<Subject>();
                var student = new StudentModel() { FirstName = studentRecord.Prenume, LastName = studentRecord.Nume };
                grades.Add(new Subject() { SubjectName = nameof(studentRecord.LimbaRomana), Grade = studentRecord.LimbaRomana });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.LimbaEngleza), Grade = studentRecord.LimbaEngleza });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.Matematica), Grade = studentRecord.Matematica });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.Fizica), Grade = studentRecord.Fizica });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.Chimia), Grade = studentRecord.Chimia });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.Informatica), Grade = studentRecord.Informatica });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.Geografia), Grade = studentRecord.Geografia });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.Istoria), Grade = studentRecord.Istoria });
                grades.Add(new Subject(){ SubjectName = nameof(studentRecord.Biologia), Grade = studentRecord.Biologia });
                student.Grades = grades;
                finalStudents.Add(student);
            }
            return finalStudents;
        }
    }
}