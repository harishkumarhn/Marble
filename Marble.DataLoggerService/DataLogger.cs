using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]


namespace Marble.DataLoggerService
{
    public class DataLogger
    {
        private static readonly ILog datalogger =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public DataLogger()
        {
            string folderpath =  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string configFilePath= Path.Combine(folderpath, "Log4Net.config");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(configFilePath));

            log4net.Repository.ILoggerRepository logRepository = log4net.LogManager.GetRepository();
            var app = logRepository.GetAppenders().Where(x => x.GetType() == typeof(log4net.Appender.RollingFileAppender)).FirstOrDefault();
            if (app != null)
            {
                var appender = app as log4net.Appender.RollingFileAppender;

                string directory = Path.GetDirectoryName(appender.File);
                string filePrefix = Path.GetFileName(appender.File) + "*";
                string[] files = Directory.GetFiles(directory, filePrefix);

                foreach (string file in files)
                {
                    if (appender.File != file)
                    {
                        FileInfo fi = new FileInfo(file);
                        try
                        {
                            if (fi.LastAccessTime < DateTime.Now.AddDays(-20))
                                fi.Delete();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }


        public void LogException(string message,Exception exception)
        {
            datalogger.Error(message, exception);
        }
        //public void LogInfo()
        //{
        //    datalogger.Error(message, exception);
        //}
        //public void LogDebug()
        //{

        //}
        public void Debug(object message)
        {
            datalogger.Debug(message);
        }

        public void Info(object message)
        {
            datalogger.Info(message);
        }

        public void Warn(object message)
        {
            datalogger.Warn(message);
        }

        public void Error(object message, Exception exception)
        {
            datalogger.Error(message, exception);
        }

        public void Error(object message)
        {
            datalogger.Error(message);
        }

        public void Fatal(object message)
        {
            datalogger.Fatal(message);
        }

        public void Log(object message, Exception ex)
        {
            datalogger.Fatal(message, ex);
        }
    }
}
