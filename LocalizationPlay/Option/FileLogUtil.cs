using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Option
{
    public class FileLogUtil
    {
        private static string LOGSPACE_PATH;
        private static log4net.ILog errorlog = null;

        public static void WriteErrorLog(String step_txt)
        {
            if (errorlog == null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\log.xml";
                log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
                errorlog = log4net.LogManager.GetLogger("Error");
            }

            errorlog.Error(step_txt);
        }

    }
}
