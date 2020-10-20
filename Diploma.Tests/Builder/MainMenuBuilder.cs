using Diploma.DataProcessing;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Tests.Builder
{
    class MainMenuBuilder
    {
        private IConsoleWrapper consoleWrapper;
        private IConstants constants;
        private IStudentDataProcessor loader;

        public MainMenuBuilder()
        {
            this.consoleWrapper = Substitute.For<IConsoleWrapper>();
            this.constants = Substitute.For<IConstants>();
            this.loader = Substitute.For<IStudentDataProcessor>();
        }

        public MainMenuBuilder WithConsoleWrapper(IConsoleWrapper _consoleWrapper)
        {
            consoleWrapper = _consoleWrapper;
            return this;
        }

        public MainMenuBuilder WithConstants(IConstants _constants)
        {
            constants = _constants;
            return this;
        }

        public MainMenuBuilder WithLoader(IStudentDataProcessor _loader)
        {
            loader = _loader;
            return this;
        }

        public MainMenu Build()
        {
            return new MainMenu(consoleWrapper, constants, loader);
        }
    }
}
