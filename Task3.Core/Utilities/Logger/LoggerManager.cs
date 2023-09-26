using log4net.Config;
namespace Task3.Core.Utilities.Logger
{
	public class LoggerManager
	{
        public static void ReadConfiguration()
        {
            XmlConfigurator.Configure(new FileInfo("Log.config"));
        }

        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }
    }
}

