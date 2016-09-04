using System;
using System.Collections.Generic;
using System.Web;
using log4net;
using System.Reflection;

namespace jdgl_res_head_service.log
{
    public class LogHelper
    {
        public static  void WriteLog(string  logInfo)
        {
             ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
             log.Info(logInfo);
        }
    }
}