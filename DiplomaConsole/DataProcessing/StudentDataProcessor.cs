using Diploma.Files;
using Diploma.Utils;
using Diploma.Validators;

namespace Diploma.DataProcessing

{
    public class StudentDataProcessor : IStudentDataProcessor
    {
        private readonly IFileReader fileReader;
        private readonly ICustomMapper mapper;
        private readonly IFileWriter fileWriter;
        private readonly IValidator validator;

        public StudentDataProcessor(IFileReader fileReader, ICustomMapper mapper, IFileWriter fileWriter, IValidator validator)
        {
            this.fileReader = fileReader;
            this.mapper = mapper;
            this.fileWriter = fileWriter;
            this.validator = validator;
        }

        public void LoadData(string filePath)
        {
            var students = fileReader.ImportData(filePath);
            var finalStudents = mapper.MapToStudent(students);
            foreach (var student in finalStudents)
            {
                if (validator.ValidateStudentRecord(student))
                {
                    var studentDiploma = fileWriter.CreateDiplomas(student);
                    fileWriter.SaveDiploma(studentDiploma, student.FirstName, student.LastName);
                }
            }
        }
    }
}