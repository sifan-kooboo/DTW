using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace jdgl_res_head_service.Lskr
{
    /// <summary>
    /// Lskr_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Lskr_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "Qskyd_fjrb_lskr上传")]
        public string Qskyd_fjrb_lskr_UploadDS(DataSet DS)  //上传
        {
            string s = common_file.common_app.get_failure;
            Lskr.Qskyd_fjrb_lskr Qskyd_fjrb_lskr_new = new Qskyd_fjrb_lskr();
            s = Qskyd_fjrb_lskr_new.Qskyd_fjrb_lskr_UploadDS(DS);
            return s;
        }
        [WebMethod(Description = "Qskyd_mainrecord_lskr上传")]
        public string Qskyd_mainrecord_lskr_UploadDS(DataSet DS)  //上传
        {
            string s = common_file.common_app.get_failure;
            Lskr.Qskyd_mainrecord_lskr Qskyd_mainrecord_lskr_new = new Qskyd_mainrecord_lskr();
            s = Qskyd_mainrecord_lskr_new.Qskyd_mainrecord_lskr_UploadDS(DS);
            return s;
 
        }
        [WebMethod(Description = "Qskyd_lskr_delete上传这张表撤消里添加到这张表")]
        public string Qskyd_lskr_delete_UploadDS(DataSet DS)  //上传
        {
            string s = common_file.common_app.get_failure;
            Lskr.Qskyd_lskr_delete Qskyd_lskr_delete_new = new Qskyd_lskr_delete();
            s = Qskyd_lskr_delete_new.Qskyd_lskr_delete_UploadDS(DS);
            return s;
 
        }


        [WebMethod(Description = "Qskyd_fjrb_lskr下载到各门店")]
        public string Qskyd_fjrb_lskr_download(string yydh, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Lskr.Qskyd_fjrb_lskr Qskyd_fjrb_lskr_new = new Qskyd_fjrb_lskr();
            s = Qskyd_fjrb_lskr_new.Qskyd_fjrb_lskr_download(yydh,out DS_download);
            return s;
 
        }
        [WebMethod(Description = "Qskyd_mainrecord_lskr下载到各门店")]
        public string Qskyd_mainrecord_lskr_download(string yydh, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Lskr.Qskyd_mainrecord_lskr Qskyd_mainrecord_lskr_new = new Qskyd_mainrecord_lskr();
            s = Qskyd_mainrecord_lskr_new.Qskyd_mainrecord_lskr_download(yydh, out DS_download);
            return s;
 
        }
        [WebMethod(Description = "Qskyd_lskr_delete下载到各门店这张表撤消里添加到这张表")]
        public string Qskyd_lskr_delete_download(string yydh, out string csdatatime, out string jsdatatime, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Lskr.Qskyd_lskr_delete Qskyd_lskr_delete_new = new Qskyd_lskr_delete();
            s = Qskyd_lskr_delete_new.Qskyd_lskr_delete_download(yydh, out csdatatime, out jsdatatime,out DS_download);
            return s;
 
        }
        [WebMethod(Description = "下载后修改服务中心的上传时间")]
        public string Lskr_scxzsj(string yydh, string jsdatatime)
        {
            string s = common_file.common_app.get_failure;
            Lskr.Qskyd_mainrecord_lskr Qskyd_mainrecord_lskr_new = new Qskyd_mainrecord_lskr();
            s = Qskyd_mainrecord_lskr_new.Lskr_scxzsj(yydh,jsdatatime);
            return s;
 
        }

        //[WebMethod(Description = "用于快速下载其它门店的信息")]
        //public string Qskyd_mainrecord_lskr_download_cs(string yydh, out  DataSet DS_download)
        //{
        //    string s = common_file.common_app.get_failure;
        //    Lskr.Qskyd_mainrecord_lskr Qskyd_mainrecord_lskr_new = new Qskyd_mainrecord_lskr();
        //    s = Qskyd_mainrecord_lskr_new.Qskyd_mainrecord_lskr_download_cs(yydh,out DS_download);
        //    return s;
 
 
        //}
        //[WebMethod(Description = "用于快速下载其它门店的信息")]
        //public string Qskyd_fjrb_lskr_download_cs(string yydh, out  DataSet DS_download)
        //{
        //    string s = common_file.common_app.get_failure;
        //    Lskr.Qskyd_fjrb_lskr Qskyd_fjrb_lskr_new = new Qskyd_fjrb_lskr();
        //    s = Qskyd_fjrb_lskr_new.Qskyd_fjrb_lskr_download_cs(yydh, out DS_download);
        //    return s;


        //}

    }
}
