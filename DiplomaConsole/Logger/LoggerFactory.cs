using NLog;

namespace Diploma.Logger
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger<T>()
        {
            return LogManager.GetLogger(typeof(T).FullName);
        }
    }
}