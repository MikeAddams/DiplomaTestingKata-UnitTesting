using NLog;

namespace Diploma.Logger
{
    public interface ILoggerFactory
    {
        ILogger GetLogger<T>();
    }
}