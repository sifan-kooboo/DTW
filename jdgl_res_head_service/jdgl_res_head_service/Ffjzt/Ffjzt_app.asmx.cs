using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace jdgl_res_head_service.Ffjzt
{
    /// <summary>
    /// Ffjzt_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Ffjzt_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "维修房上传")]
        public string Fwx_other_UploadDS(DataSet DS_Fwxother)  //维修房上传
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Fwx_other Fwxother_new = new Fwx_other();
            s = Fwxother_new.Fwx_other_UploadDS(DS_Fwxother);
            return s;
        }
        [WebMethod(Description = "预定登记房间类型上传")]
        public string Qskyd_fjrb_UploadDS(DataSet DS_Qskydfjrb)  //上传房间使用情况
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Qskyd_Ffjrb Qskydfjrb_new = new Qskyd_Ffjrb();
            s = Qskydfjrb_new.Qskyd_fjrb_UploadDS(DS_Qskydfjrb);
            return s;
        }
        //[WebMethod(Description = "先把Qskydfjrb和Fwxother上传添加到远程的对应表然后添加到Q_zb_fs_fx表里")]
        //public string Q_ZB_FS_FX_add(DataSet DS_Fwxother, DataSet DS_Qskydfjrb)
        //{
        //    string s = common_file.common_app.get_failure;
        //    Ffjzt.Qskyd_Ffjrb Qskydfjrb_new = new Qskyd_Ffjrb();
        //    s = Qskydfjrb_new.Q_ZB_FS_FX_add(DS_Fwxother, DS_Qskydfjrb);
        //    return s;
 
        //}

        [WebMethod(Description = "初始房间")]
        public string fjrb_UpLoadDS(DataSet DS,string operate)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Ffjrb Ffjrb_new = new Ffjrb();
            s = Ffjrb_new.Ffjrb_UpLoadDS(DS,operate);
            return s;

        }
        [WebMethod(Description = "房间状态上传")]
        public string Ffjzt_UpLoadDS(DataSet DS)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Web_Ffjzt Web_Ffjzt_new = new Web_Ffjzt();
            s = Web_Ffjzt_new.Ffjzt_UpLoadDS(DS);
            return s;

 
        }
        [WebMethod(Description = "先把Qskydfjrb和Fwxother上传添加到远程的对应表")]
        public string Qskyd_fjrb_temp_ADD(DataSet DS_Fwxother, DataSet DS_Qskydfjrb)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Qskyd_Ffjrb Qskydfjrb_new = new Qskyd_Ffjrb();
            s = Qskydfjrb_new.Qskyd_fjrb_temp_ADD(DS_Fwxother, DS_Qskydfjrb);
            return s;
 
        }
        [WebMethod(Description = "房间状态上传新的")]
        public string Ffjzt_upload(DataSet DS_Fjzt, string yydh)
        {
            string s = common_file.common_app.get_failure;
            Ffjzt.Web_Ffjzt Web_Ffjzt_new = new Web_Ffjzt();
            s = Web_Ffjzt_new.Ffjzt_upload(DS_Fjzt, yydh);
            return s;
 
        }
    }
}
