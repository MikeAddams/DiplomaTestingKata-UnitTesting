using Castle.DynamicProxy.Generators;
using Diploma.DataProcessing;
using Diploma.Files;
using Diploma.Models;
using Diploma.Tests.Builder;
using Diploma.Utils;
using Diploma.Validators;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace Diploma.Tests.UnitTests
{
    public class StudentDataProcessorTests
    {
        [Fact]
        public void LoadData_CallsImportData_OneTimeWithPath()
        {
            // Arange
            string path = "path";
            var fileReader = Substitute.For<IFileReader>();
            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).Build();

            // Act
            sut.LoadData(path);

            // Assert
            fileReader.Received(1).ImportData(path);
        }

        [Fact]
        public void LoadData_CallsMapToStudent_WithStudentsFromImportData()
        {
            // Arrange
            string path = "path";
            var students = new List<StudentRawModel>() { new StudentRawModel() };
            var fileReader = Substitute.For<IFileReader>();
            fileReader.ImportData(path).Returns(students);

            var mapper = Substitute.For<ICustomMapper>();
            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).WithMapper(mapper).Build();

            // Act
            sut.LoadData(path);

            // Assert
            mapper.Received(1).MapToStudent(students);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void LoadData_CallsValidateStudentRecord_ForNTimes(int n)
        {
            //Arange
            string path = "path";
            var student = new StudentModel();
            var studentsList = new List<StudentModel>();
            var rowStudentsList = new List<StudentRawModel> { new StudentRawModel() };

            for (int i = 0; i < n; i++)
            {
                studentsList.Add(student);
            }

            var fileReader = Substitute.For<IFileReader>();
            fileReader.ImportData(path).Returns(rowStudentsList);

            var mapper = Substitute.For<ICustomMapper>();
            mapper.MapToStudent(rowStudentsList).Returns(studentsList);

            var validator = Substitute.For<IValidator>();

            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).WithMapper(mapper).WithValidator(validator).Build();

            // Act
            sut.LoadData(path);

            // Assert
            validator.Received(n).ValidateStudentRecord(student);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoadData_CallsCreateDiplomasAndSaveDiploma_OneTime_IfValidatorPassed_Else_NoCalls(bool validation)
        {
            // Arange
            int nTimes = 0;
            string path = "path";
            var student = new StudentModel();
            var studentsList = new List<StudentModel>() { student };
            var rowStudentsList = new List<StudentRawModel> { new StudentRawModel() };

            var fileReader = Substitute.For<IFileReader>();
            fileReader.ImportData(path).Returns(rowStudentsList);

            var mapper = Substitute.For<ICustomMapper>();
            mapper.MapToStudent(rowStudentsList).Returns(studentsList);

            var validator = Substitute.For<IValidator>();
            validator.ValidateStudentRecord(student).Returns(validation);

            var fileWritter = Substitute.For<IFileWriter>();

            var sdp = new StudentDataProcessorBuilder().WithMapper(mapper).WithFileWritter(fileWritter).WithFileReader(fileReader).WithValidator(validator).Build();

            // Act
            sdp.LoadData(path);

            // Assert
            if (validation)
            {
                nTimes = 1;
            }  

            fileWritter.Received(nTimes).CreateDiplomas(student);
            fileWritter.Received(nTimes).SaveDiploma(fileWritter.CreateDiplomas(student), student.FirstName, student.LastName);
        }

    }
}



/* // for Validator tests
    var s1 = new StudentModel()
    {
        FirstName = "Florin",
        LastName = "Turcanu",
        Grades = new List<Subject>()
        { 
            new Subject() { SubjectName = "LimbaRomana", Grade = 7 } ,
            new Subject() { SubjectName = "Limba ENgleza", Grade = 7 },
            new Subject() { SubjectName = "Matematica", Grade = 7},
            new Subject() { SubjectName = "Fizica", Grade = 7},
            new Subject() { SubjectName = "Chimia", Grade = 7},
            new Subject() { SubjectName = "Informatica", Grade = 7},
            new Subject() { SubjectName = "Geografia", Grade = 7},
            new Subject() { SubjectName = "Istoria", Grade = 7},
            new Subject() { SubjectName = "Biologia", Grade = 7}
        }
    };
*/