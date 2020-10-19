namespace Diploma
{
    public class Constants : IConstants
    {
        private const string _helloText = 
            "Hello, please import the students file. To import the file, press Enter. To exit the application press any Key.";

        private const string _exitText = "Thank you for work. The program will close.";
        private const string _importText = "Insert path for student data Excel file";
        private const string _docxExtension = ".docx";
        private const string _diplomNameText = "Diploma \n\n Studii Medii";

        public string GetHelloText { get => _helloText; }
        public string GetExitText { get => _exitText; }

        public string GetImportFileText { get => _importText;  }

        public string GetExtension { get => _docxExtension; }
        public string GetDiplomNameText { get => _diplomNameText; }
    }
}