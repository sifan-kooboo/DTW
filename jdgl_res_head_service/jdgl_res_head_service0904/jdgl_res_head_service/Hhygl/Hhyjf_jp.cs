using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace jdgl_res_head_service.Hhygl
{
    public class Hhyjf_jp
    {

        //奖品奖励信息下载，供特定门店下载返回dataset
        public DataSet DSHhyjfjp_download(string yydh, out  int rows, out string csdatatime, out string jsdatatime)
        {
            BLL.Hhyjf_jp B_Hhyjf_jp = new BLL.Hhyjf_jp();
            Model.Hhyjf_jp M_Hhyjf_jp = new Model.Hhyjf_jp();
            Model.Hhy_sc_xz_sj M_Hhyscsj = new Model.Hhy_sc_xz_sj();
            BLL.Hhy_sc_xz_sj B_Hhyscsj = new BLL.Hhy_sc_xz_sj();

            //查询出上次上传时间
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            if (yydh != "" && yydh != null)
            {
                M_Hhyscsj = B_Hhyscsj.GetModelList("yydh='" + yydh + "'")[0];
                cstime = M_Hhyscsj.hy_scsj;

            }
            string jstime = DateTime.Now.ToString();
            DataSet DS_Hhyjf_jp = new DataSet();
            rows = 0;
            jsdatatime = jstime;
            csdatatime = cstime.ToString();
            //status = false;
            //msg = "没有查到要下载的数据信息或者远程服务器出错";
            DS_Hhyjf_jp = B_Hhyjf_jp.GetList(200, "yydh='" + yydh + "'", "id");

            if (DS_Hhyjf_jp != null)
            {
                rows = DS_Hhyjf_jp.Tables[0].Rows.Count;
                jsdatatime = jstime;
                csdatatime = cstime.ToString();
                //status = true;
                //msg = "查询成功";

            }

            return DS_Hhyjf_jp;
        }

        //供门店下载网上奖品奖励
        public string Hhyjfjp_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;
            rows = 0;
            //status = false;
            DS_download = null;
            DataSet DS_Hhyjf_jp;
            //msg = "没有查到要下载的数据信息或者远程服务器出错,webservice";
            jsdatatime = "1800-01-01";   //结束时间
            csdatetime = "1800-01-01";   //初始时间
            DS_Hhyjf_jp = DSHhyjfjp_download(yydh, out rows, out csdatetime, out jsdatatime);
            if (DS_Hhyjf_jp != null && rows > 0)
            {
                DS_download = DS_Hhyjf_jp;
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }
    }
}
