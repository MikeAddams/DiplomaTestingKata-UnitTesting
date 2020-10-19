using Diploma.DataProcessing;
using Diploma.Files;
using Diploma.Logger;
using Diploma.Utils;
using Diploma.Validators;
using Diploma.Wrappers;
using SimpleInjector;

namespace Diploma
{
    public static class BootstrapperPackage
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IConsoleWrapper, ConsoleWrapper>();
            container.Register<IMainMenu, MainMenu>();
            container.Register<IConstants, Constants>();
            container.Register<IFileReader, FileReader>();
            container.Register<IExcelWrapper, ExcelWrapper>();
            container.Register<IStudentDataProcessor, StudentDataProcessor>();
            container.Register<IFileWrapper, FileWrapper>();
            container.Register<ICustomMapper, CustomMapper>();
            container.Register<IFileWriter, FileWriter>();
            container.Register<IDocWrapper, DocWrapper>();
            container.Register<IValidator, Validator>();
            container.Register<IStringCreator, StringCreator>();
            container.Register<IDomainWrapper, DomainWrapper>();
            container.RegisterSingleton<ILoggerFactory, LoggerFactory>();
        }
    }
}