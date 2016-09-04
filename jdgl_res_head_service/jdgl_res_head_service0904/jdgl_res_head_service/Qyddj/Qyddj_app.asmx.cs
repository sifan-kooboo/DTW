using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace jdgl_res_head_service.Qyddj
{
    /// <summary>
    /// Qyddj_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Qyddj_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "供门店下载网上的预订信息")]
        public string yddj_download_DS(string qymc, out  int rows, out  bool status, out DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            rows = 0;
            status = false;
            DS_download = null;
            DataSet ds_skyd;
            web_skyd web_skyd_new=new web_skyd();
            ds_skyd = web_skyd_new.yddj_download_DS(qymc,out rows,out status);
            if (ds_skyd != null && rows > 0)
            {
                DS_download = ds_skyd;
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        [WebMethod(Description = "供门店下载预定房间房型的信息")]
        public string WebQskyd_fjrb_DS(string qymc,string lsbh,out int rows, out DataSet DS_download)
        {
            string s = common_file.common_app.get_failure;
            rows = 0;
            DS_download = null;
            DataSet ds_web_Qskyd_fjrb;
            web_skyd web_skyd_new = new web_skyd();
            ds_web_Qskyd_fjrb = web_skyd_new.WebQskyd_fjrb_DS(qymc,lsbh,out rows);
            if (ds_web_Qskyd_fjrb != null && rows > 0)
            {
                DS_download = ds_web_Qskyd_fjrb;
                s = common_file.common_app.get_suc;
            }
            return s;
 
        }
         //向InsertToQyddjlsbhbg_yy添加数据
        [WebMethod(Description = "向InsertToQyddjlsbhbg_yy添加数据")]
        public string InsertToQyddjlsbhbg_yy(string yclsbh, string bdlsbh, string bdyydh)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.web_skyd web_skyd_new = new web_skyd();
            s = web_skyd_new.InsertToQyddjlsbhbg_yy(yclsbh, bdlsbh, bdyydh);
            return s;
 
        }
        [WebMethod(Description = "门店下载网上预定数据后，修改订单状态")]
        public string yddj_ydownloadDataStatus(DataSet DS_yddj_downloadData)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.web_skyd web_skyd_new = new web_skyd();
            s = web_skyd_new.yddj_ydownloadDataStatus(DS_yddj_downloadData);
            return s;
        }
        [WebMethod(Description = "门店下载网上预定数据后，修改Web_Qskyd_fjrb表中shsc=1")]
        public string Web_Qskyd_fjrb_Updateshsc(int id)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.web_skyd web_skyd_new = new web_skyd();
            s = web_skyd_new.Web_Qskyd_fjrb_Updateshsc(id);
            return s;
 
        }
        [WebMethod(Description = "门店下载网上预定确认后添加到该表")]
        public string Qyqskyd_ydzxqr_ad(DataSet DS_Qyqskyd_ydzxqr_downloadData)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.ydzxqr_ad_ed ydzxqr_ad_ed_new = new ydzxqr_ad_ed();
            s = ydzxqr_ad_ed_new.Qyqskyd_ydzxqr_ad(DS_Qyqskyd_ydzxqr_downloadData);
            return s;
 
        }
        [WebMethod(Description = "门店下载预定确定后转入住明细添加到该表")]
        public string Qyqskyd_ydzlzmx_ad(DataSet DS_Qyqskyd_ydzlzmx_downloadData)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.ydzxqr_ad_ed ydzxqr_ad_ed_new = new ydzxqr_ad_ed();
            s = ydzxqr_ad_ed_new.Qyqskyd_ydzlzmx_ad(DS_Qyqskyd_ydzlzmx_downloadData);
            return s;
 
        }

        
    }
}
