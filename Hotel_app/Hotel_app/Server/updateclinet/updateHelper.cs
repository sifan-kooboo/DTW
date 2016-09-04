using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

namespace Hotel_app.Server.updateclinet
{
    public class updateHelper
    {
        static string UpdateAppUrl = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/Update/{0}", System.Web.Configuration.WebConfigurationManager.AppSettings["clientAppName"]));
        static string filePath = HttpContext.Current.Server.MapPath("~/App_Data/Update/");


        //生成更新压缩包
        public static string  makeZipFiles()
        {
            string s = common_file.common_app.get_suc;
            try
            {
                GZipCompresser.Compress(filePath, HttpContext.Current.Server.MapPath("~/App_Data/Update.gzip"));

            }
            catch (Exception  ee)
            {
                s = ee.ToString() + common_file.common_app.get_failure;
            }
            return s;
        }


        public static string GetFileVersion(string filePath)
        {
            FileVersionInfo f = FileVersionInfo.GetVersionInfo(filePath);
            return f.FileVersion;
        }

        public static string GetNewVersion(string  yydh,string ClientVerison)
        {
            //比较当前数据库中的版本与更新目录下的版本，如果不等，则生成更新文件
            string updateVersion = GetFileVersion(UpdateAppUrl); //当前版本
            string preVersion = "";                                             //上一次版本
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds = B_common.GetList(" select  *  from  X_update ", " id>=0  and yydh='"+yydh+"' ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                preVersion = ds.Tables[0].Rows[0]["preVersion"].ToString();
                if (preVersion.Trim() != "")
                {
                    if (preVersion != updateVersion)
                    {
                        B_common.ExecuteSql(" update  X_update set preVersion='" + updateVersion + "'  where      Id>=0  and yydh='"+yydh+"' ");
                        makeZipFiles();
                    }
                }
            }
            return updateVersion;

        }

    }
}
