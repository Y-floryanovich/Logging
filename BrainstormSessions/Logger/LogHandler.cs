using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace BrainstormSessions.Logger
{
    public static class LogHandler
    {
        private static readonly ILog LogValue = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static ILog Log => LogValue;

        public static void InitLogger()
        {
            var repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
            var fileInfo = new FileInfo(@"log4net.config");

            XmlConfigurator.Configure(repository, fileInfo);
        }

    }
}
