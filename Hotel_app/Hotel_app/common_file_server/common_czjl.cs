using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Hotel_app.common_file_server
{
    public static class common_czjl
    {
        public static void add_czjl(string yydh, string qymc, string czy, string cznr, string czzy, string czbz, DateTime czsj)
        {
            BLL.YHczjl B_YHczjl = new Hotel_app.BLL.YHczjl();
            Model.YHczjl M_YHczjl = new Hotel_app.Model.YHczjl();
            M_YHczjl.yydh = yydh; M_YHczjl.qymc = qymc; M_YHczjl.czy = czy; M_YHczjl.cznr = cznr;
            M_YHczjl.czzy = czzy; M_YHczjl.czbz = czbz; M_YHczjl.czsj = czsj; 
            B_YHczjl.Add(M_YHczjl);
        }


        public static void add_errorlog(string errorString,string  errorDetail,string timeInfo)
        {
            string logPath = ConfigurationManager.AppSettings["ErrorLogPath"];
            FileStream filest = new FileStream(logPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(filest);
            sw.WriteLine("******<出错语句如下>******");
            sw.WriteLine(errorString);
            sw.WriteLine("******<具体出错原因如下>**");
            sw.WriteLine(errorDetail);
            sw.WriteLine("********日志记录时间为:"+timeInfo+"*****");
            sw.WriteLine("");
            sw.Close();
            filest.Dispose();
 
        }
    }
}
