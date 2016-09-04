using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace jdgl_res_head_service.Hhygl
{
    /// <summary>
    /// Hhygl_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Hhygl_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "会员级别的传输")]
        public string Hhyjb_add_DS(DataSet DS_Hhyjb, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjb Hhyjb_add_edit_new = new Hhyjb();
            s = Hhyjb_add_edit_new.Hhyjb_add_DS(DS_Hhyjb, xx_zs);
            return s;
        }
        [WebMethod(Description = "会员比率的传输")]
        public string Hhyjfbl_add_DS(DataSet DS_Hhyjfbl, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {   
            
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_bl Hhyjfbl_add_edit_new = new Hhyjf_bl();
            s = Hhyjfbl_add_edit_new.Hhyjfbl_add_DS(DS_Hhyjfbl, xx_zs);
            return s;
        }
        [WebMethod(Description = "会员房价的传输")]
        public string Hhyfj_add_DS(DataSet DS_Hhyfj, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyfj Hhyfj_add_edit_new = new Hhyfj();
            s = Hhyfj_add_edit_new.Hhyfj_add_DS(DS_Hhyfj, xx_zs);
            return s;
        }
        [WebMethod(Description = "会员信息的传输")]
        public string Hhygl_add_DS(DataSet DS_Hhygl, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhygl_ad_ed Hhygl_add_edit_new = new Hhygl_ad_ed();
            s = Hhygl_add_edit_new.Hhygl_add_DS(DS_Hhygl, xx_zs);
            return s;
        }
        //[WebMethod(Description = "会员信息的下载")]
        //public string Hhygl_download(DataSet DS_Hhygl_downloadData)
        //{
        //    string s = common_file.common_app.get_failure;
        //    Hhygl.Hhygl_ad_ed Hhygl_add_edit_new = new Hhygl_ad_ed();
        //    s = Hhygl_add_edit_new.Hhygl_download(DS_Hhygl_downloadData);
        //    return s;
 
        //}
        [WebMethod(Description = "会员信息供门店的下载")]
        public string Hhygl_download(string yydh, out  int rows, out string csdatatime, out string jsdatatime, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhygl_ad_ed Hhygl_add_edit_new = new Hhygl_ad_ed();
            s = Hhygl_add_edit_new.Hhygl_download(yydh, out rows, out csdatatime, out jsdatatime, out DS_download);
            return s;
        }
        [WebMethod(Description = "会员信息供门店的下载后修改服务中心的上传时间")]
        public string Hhy_scxzsj(string yydh, string jsdatatime)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhygl_ad_ed Hhygl_add_edit_new = new Hhygl_ad_ed();
            s = Hhygl_add_edit_new.Hhy_scxzsj(yydh, jsdatatime);
            return s;
        }
        [WebMethod(Description = "会员下载完后shsc=1")]
        public string UDshsc(DataSet DS_Hhygl)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhygl_ad_ed Hhygl_add_edit_new = new Hhygl_ad_ed();
            s = Hhygl_add_edit_new.UDshsc(DS_Hhygl);
            return s;
        }

        [WebMethod(Description = "上传积分兑换")]
        public string Hhyjfdf_UploadDS(DataSet DS_Hhyjfdf)  //上传积分兑换
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_df Hhyjf_df_add_new = new Hhyjf_df();
            s = Hhyjf_df_add_new.Hhyjfdf_UploadDS(DS_Hhyjfdf);
            return s;
        }

        [WebMethod(Description = "上传积分消费记录")]
        public string Hhyjfxfjl_UploadDS(DataSet DS_Hhyjfxfjl)  //上传积分消费记录
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_xfjl Hhyjf_xfjl_add_new = new Hhyjf_xfjl();
            s = Hhyjf_xfjl_add_new.Hhyjfxfjl_UploadDS(DS_Hhyjfxfjl);
            return s;
        }

        [WebMethod(Description = "积分兑换供门店的下载")]
        public string Hhyjfdf_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_df Hhyjf_df_add_new = new Hhyjf_df();
            s = Hhyjf_df_add_new.Hhyjfdf_download(yydh,out rows,out csdatetime,out jsdatatime,out DS_download);
            return s;

 
        }
        [WebMethod(Description = "查询远程服务的初始时间")]
        public string GetSCtime(string yydh,out string cstime)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhygl_ad_ed Hhygl_add_new = new Hhygl_ad_ed();
            s = Hhygl_add_new.GetSCtime(yydh,out cstime);
            return s;
        }
        [WebMethod(Description = "积分消费记录供门店的下载")]
        public string Hhyjfxfjl_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_xfjl Hhyjf_xfjl_add_new =new Hhyjf_xfjl();
            s = Hhyjf_xfjl_add_new.Hhyjfxfjl_download(yydh, out rows, out csdatetime, out jsdatatime,out DS_download);
            return s;
        }
        [WebMethod(Description = "积分奖品供门店的下载")]
        public string Hhyjfjp_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            Hhygl.Hhyjf_jp Hhyjf_jp_new = new Hhyjf_jp();
            s = Hhyjf_jp_new.Hhyjfjp_download(yydh, out rows, out csdatetime, out jsdatatime, out DS_download);
            return s;
 
        }

    }
}
