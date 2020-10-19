using CsvHelper;
using Diploma.Models;
using Diploma.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;

namespace Diploma.Files
{
    public class FileReader : IFileReader
    {
        private readonly IFileWrapper fileWrapper;

        public FileReader(IFileWrapper fileWrapper)
        {
            this.fileWrapper = fileWrapper;
        }

        public IEnumerable<StudentRawModel> ImportData(string path)
        {
            var students = new List<StudentRawModel>();
            using (TextReader reader = fileWrapper.OpenText(@path))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.TypeConverterCache.RemoveConverter<decimal>();
                csv.Configuration.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "dd.MM.yyyy HH:mm:ss" };
                csv.Configuration.RegisterClassMap<StudentRecordMap>();
                while (csv.Read())
                {
                    var record = csv.GetRecord<StudentRawModel>();
                    students.Add(record);
                }
            }

            return students;
        }
    }
}
