using Diploma.DataProcessing;
using Diploma.Files;
using Diploma.Utils;
using Diploma.Validators;
using NSubstitute;

namespace Diploma.Tests.Builder
{
    public class StudentDataProcessorBuilder
    {
        private IFileReader fileReader;
        private ICustomMapper mapper;
        private IFileWriter fileWriter;
        private IValidator validator;

        public StudentDataProcessorBuilder()
        {
            this.fileReader = Substitute.For<IFileReader>();
            this.mapper = Substitute.For<ICustomMapper>();
            this.fileWriter = Substitute.For<IFileWriter>();
            this.validator = Substitute.For<IValidator>();
        }

        public StudentDataProcessorBuilder WithFileReader(IFileReader fileReader)
        {
            this.fileReader = fileReader;
            return this;
        }

        public StudentDataProcessorBuilder WithMapper(ICustomMapper mapper)
        {
            this.mapper = mapper;
            return this;
        }

        public StudentDataProcessorBuilder WithFileWritter(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
            return this;
        }

        public StudentDataProcessorBuilder WithValidator(IValidator validator)
        {
            this.validator = validator;
            return this;
        }

        public StudentDataProcessor Build()
        {
            return new StudentDataProcessor(fileReader, mapper, fileWriter, validator);
        }
    }
}