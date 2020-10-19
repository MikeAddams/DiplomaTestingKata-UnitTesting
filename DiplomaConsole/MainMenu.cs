using Diploma.DataProcessing;
using System;

namespace Diploma
{
    public class MainMenu : IMainMenu
    {
        private readonly IConsoleWrapper consoleWrapper;
        private readonly IConstants constants;
        private readonly IStudentDataProcessor loader;

        public MainMenu(IConsoleWrapper consoleWrapper, IConstants constants, IStudentDataProcessor loader)
        {
            this.consoleWrapper = consoleWrapper;
            this.constants = constants;
            this.loader = loader;
        }

        public void CollectData()
        {
            consoleWrapper.WriteLine(constants.GetHelloText);
            var enteredKey = consoleWrapper.ReadKey();
            if (enteredKey.Key != ConsoleKey.Enter)
            {
                EndProgram();
                return;
            }
            consoleWrapper.WriteLine(constants.GetImportFileText);
            var path = consoleWrapper.ReadLine();
            loader.LoadData(path);
            EndProgram();
        }

        private void EndProgram()
        {
            consoleWrapper.WriteLine(constants.GetExitText);
        }
    }
}