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
namespace jdgl_res_head_service.Hhygl
{
    public class Hhyfj
    {
        public string Hhyfj_add_DS(DataSet DS_Hhyfj, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            	//id,yydh,qymc,hyrx,fjrb,hyfj,bz,shsc,is_top,is_select
            string s = common_file.common_app.get_failure;
            BLL.Hhyfj B_Hhyfj = new BLL.Hhyfj();
            Model.Hhyfj M_Hhyfj = new Model.Hhyfj();
            string dsqymc = "";

            if (DS_Hhyfj != null && DS_Hhyfj.Tables[0].Rows.Count > 0)
            {
                dsqymc = DS_Hhyfj.Tables[0].Rows[0]["yydh"].ToString();
                DbHelperSQL.ExecuteSql("delete from Hhyfj where yydh='" + dsqymc + "'");
                foreach (DataRow dr in DS_Hhyfj.Tables[0].Rows)
                {

                    M_Hhyfj.yydh = dr["yydh"].ToString();
                    M_Hhyfj.qymc = dr["qymc"].ToString();
                    M_Hhyfj.fjrb = dr["fjrb"].ToString();
                    M_Hhyfj.bz = dr["bz"].ToString();
                    M_Hhyfj.hyfj = Convert.ToDecimal(dr["hyfj"].ToString());
                    M_Hhyfj.hyrx = dr["hyrx"].ToString();
                    M_Hhyfj.shsc = true;
                    if (B_Hhyfj.Add(M_Hhyfj) > 0)
                    {
                        s = common_file.common_app.get_suc;
                    }

                }
            }
            return s;
        }
    }
}
