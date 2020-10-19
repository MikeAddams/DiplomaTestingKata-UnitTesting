using CsvHelper.Configuration;
using Diploma.Models;

namespace Diploma.Files
{
    public class StudentRecordMap : ClassMap<StudentRawModel>
    {
        public StudentRecordMap()
        {
            Map(m => m.Nume).Index(0);
            Map(m => m.Prenume).Index(1);
            Map(m => m.Matematica).Index(2);
            Map(m => m.LimbaRomana).Index(3);
            Map(m => m.LimbaEngleza).Index(4);
            Map(m => m.Fizica).Index(5);
            Map(m => m.Chimia).Index(6);
            Map(m => m.Informatica).Index(6);
            Map(m => m.Geografia).Index(6);
            Map(m => m.Istoria).Index(6);
            Map(m => m.Biologia).Index(6);
        }
    }
}