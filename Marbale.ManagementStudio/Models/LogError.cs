using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace MarbaleManagementStudio.Models
{
    public class LogError
    {
        private LogError()
        {
        }
        public static LogError instance = null;

        public static LogError Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogError();
                }
                return instance;
            }
        }

        public void LogException(string MethodName, Exception ex)
        {
            string strPath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
            //string strPath = @"F:\MarbleProject\Marble - Copy\LogException\Log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }
    }
}