using Diploma.DataProcessing;
using Diploma.Tests.Builder;
using NSubstitute;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using Xunit;

namespace Diploma.Tests.UnitTests
{
    public class MainMenuTests
    {
        [Fact]
        public void CollectData_ReadKeyShouldBeCalled_OneTime_ToGetUserInput()
        {
            // Arange
            var consoleWrapper = Substitute.For<IConsoleWrapper>();
            var mm = new MainMenuBuilder().WithConsoleWrapper(consoleWrapper).Build();

            // Act
            mm.CollectData();

            // Assert
            consoleWrapper.Received(1).ReadKey();
        }

        [Fact]
        public void CollectData_WriteLineShouldBeCalled_WithGetHelloText_ToInformUserWhatToDo()
        {
            // Arange
            string text = "Hello, please import the students file. To import the file, press Enter. To exit the application press any Key.";
            var consoleWrapper = Substitute.For<IConsoleWrapper>();

            var constants = Substitute.For<IConstants>();
            constants.GetHelloText.Returns(text);

            var mm = new MainMenuBuilder().WithConstants(constants).WithConsoleWrapper(consoleWrapper).Build();

            // Act
            mm.CollectData();

            // Assert
            consoleWrapper.Received(1).WriteLine(constants.GetHelloText);
        }

        [Theory]
        [InlineData(true)] // Enter key
        [InlineData(false)] // diffrent key
        public void CollectData_WriteLineFromEndProgramShouldBeCalled_WithGetExitText_OneTime_EvenIfIsEnterKeyOrNot(bool passed)
        {
            // Arange
            string text = "Thank you for work. The program will close.";

            var consoleWrapper = Substitute.For<IConsoleWrapper>();
            consoleWrapper.ReadKey().Returns(enteredKey(passed));

            var constants = Substitute.For<IConstants>();
            constants.GetExitText.Returns(text);

            var mm = new MainMenuBuilder().WithConstants(constants).WithConsoleWrapper(consoleWrapper).Build();

            // Act
            mm.CollectData();

            // Assert
            consoleWrapper.Received(1).WriteLine(constants.GetExitText);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CollectData_WriteLineShouldBeCalled_WithGetImportFileText_OneTime_IfIsEnterKey_ElseNoCalls(bool passed)
        {
            // Arange
            string text = "Insert path for student data Excel file";
            int nTimes = passed ? 1 : 0;

            var consoleWrapper = Substitute.For<IConsoleWrapper>();
            consoleWrapper.ReadKey().Returns(enteredKey(passed));

            var constants = Substitute.For<IConstants>();
            constants.GetImportFileText.Returns(text);

            var mm = new MainMenuBuilder().WithConstants(constants).WithConsoleWrapper(consoleWrapper).Build();

            // Act
            mm.CollectData();

            // Assert
            consoleWrapper.Received(nTimes).WriteLine(constants.GetImportFileText);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CollectData_GetUserPath_IfPassedEnter_ElseNo(bool passed)
        {
            // Arange
            int nTimes = passed ? 1 : 0;

            var consoleWrapper = Substitute.For<IConsoleWrapper>();
            consoleWrapper.ReadKey().Returns(enteredKey(passed));

            var mm = new MainMenuBuilder().WithConsoleWrapper(consoleWrapper).Build();

            // Act
            mm.CollectData();

            // Assert
            consoleWrapper.Received(nTimes).ReadLine();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CollectData_CallsLoadData_IfPassedEnter_ElseNo(bool passed)
        {
            // Arange
            string path = "path";
            int nTimes = passed ? 1 : 0;

            var consoleWrapper = Substitute.For<IConsoleWrapper>();
            consoleWrapper.ReadKey().Returns(enteredKey(passed));
            consoleWrapper.ReadLine().Returns(path);

            var loader = Substitute.For<IStudentDataProcessor>();

            var mm = new MainMenuBuilder().WithConsoleWrapper(consoleWrapper).WithLoader(loader).Build();

            // Act
            mm.CollectData();

            // Assert
            loader.Received(nTimes).LoadData(path);
        }


        private ConsoleKeyInfo enteredKey(bool passStatus)
        {
            if (passStatus)
            {
                return new ConsoleKeyInfo((char)0, ConsoleKey.Enter, false, false, false);
            }

            return new ConsoleKeyInfo((char)0, ConsoleKey.F15, false, false, false);
        }
    }
}
