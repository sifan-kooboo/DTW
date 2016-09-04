using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
namespace jdgl_res_head_service.Xxtsz
{
    public class Yxydw_fjrb
    {
        /// <summary>
        /// 供门店下载网上协议价
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="DS_download"></param>
        /// <returns></returns>
        public string Yxydw_fjrb_download(string yydh, out  DataSet DS_download)
        {
            Model.Yxydw_fjrb M_xydwfjrb=new Model.Yxydw_fjrb();
            BLL.Yxydw_fjrb B_xydwfjrb=new BLL.Yxydw_fjrb();
            string ss = common_file.common_app.get_failure;
            DS_download = null;
            DataSet DS_Yxydw;
    
            DS_Yxydw = B_xydwfjrb.GetList(1000,"yydh='" + yydh + "' and is_xz=0","id");
            if (DS_Yxydw != null)
            {
                DS_download = DS_Yxydw;
                common_file.common_is_select.Updat_is_select02(DS_download, "Yxydw_fjrb");
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }
    }
}
