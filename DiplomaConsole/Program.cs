namespace Diploma
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var container = new SimpleInjector.Container();
            BootstrapperPackage.RegisterServices(container);
            var menu = container.GetInstance<IMainMenu>();
            menu.CollectData();
        }
    }
}