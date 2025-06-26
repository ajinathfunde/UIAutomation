using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Config;

namespace AutoFrameworkCoreLib.Logger
{
    public sealed class Logger
    {

        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        private static ILog log;

        private Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("Logger\\log4net.config"));
            log = LogManager.GetLogger(typeof(Logger));
        }

        public static Logger Instance => _instance.Value;

        public void Info(string message) => log.Info(message);
        public void Debug(string message) => log.Debug(message);
        public void Error(string message) => log.Error(message);
        public void Warn(string message) => log.Warn(message);
    }
}
