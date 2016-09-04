using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace jdgl_res_head_service.Xxtsz
{
    /// <summary>
    /// Xxtsz_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Xxtsz_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "用于测试中心服务器的webservices是否正常")]
        public int HelloServer()
        {
            return 1;
        }
        
        [WebMethod(Description = "用于企业信息的增删改")]
        public string Xqyxx_add_DS(DataSet DS_Xqyxx, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xqyxx Xqyxx_add_edit_newa = new Xqyxx();
            s = Xqyxx_add_edit_newa.Xqyxx_add_DS(DS_Xqyxx, xx_zs);
            return s;

        }
        [WebMethod(Description = "用于协议单位的传输")]
        public string Yxydw_add_DS(DataSet DS_Yxydw,string xx_zs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Yxydw_add Yxydw_add_new = new Yxydw_add();
            s = Yxydw_add_new.Yxydw_add_DS(DS_Yxydw,xx_zs);
            return s;

        }
        [WebMethod(Description = "用于供门店下载协议单位的传输")]
        public string Yxydw_download(string yydh, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Yxydw_add Yxydw_add_new = new Yxydw_add();
            s = Yxydw_add_new.Yxydw_download(yydh,out csdatetime,out jsdatatime,out DS_download);
            return s;

 
        }
        [WebMethod(Description = "用于供门店下载完更新过程的上传时间")]
        public string Yxydw_scxzsj(string yydh, string jsdatatime)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Yxydw_add Yxydw_add_new = new Yxydw_add();
            s = Yxydw_add_new.Yxydw_scxzsj(yydh,jsdatatime);
            return s;
 
        }
        [WebMethod(Description = "用于供门店自动上传")]
        public string Yxydw_add_DS_01(DataSet DS_Yxydw)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Yxydw_add Yxydw_add_new = new Yxydw_add();
            s = Yxydw_add_new.Yxydw_add_DS_01(DS_Yxydw);
            return s;
 
        }

        //[WebMethod(Description = "用于快速下载其它门店的信息")]
        //public string Yxydw_download_cs(string yydh, out  DataSet DS_download)
        //{
        //    string s = common_file.common_app.get_failure;
        //    Xxtsz.Yxydw_add Yxydw_add_new = new Yxydw_add();
        //    s = Yxydw_add_new.Yxydw_download_cs(yydh,out DS_download);
        //    return s;
 
        //}
    }
}
