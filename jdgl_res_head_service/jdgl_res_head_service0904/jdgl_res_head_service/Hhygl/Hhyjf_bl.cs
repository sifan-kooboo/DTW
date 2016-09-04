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
    public class Hhyjf_bl
    {
        public string Hhyjfbl_add_DS(DataSet DS_Hhyjfbl, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            //id,yydh,qymc,krly,hyrx,jfbl,hyjfrx,is_top,is_select
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_bl B_Hhyjfbl = new BLL.Hhyjf_bl();
            Model.Hhyjf_bl M_Hhyjfbl = new Model.Hhyjf_bl();
            string dsqymc = "";

            if (DS_Hhyjfbl != null && DS_Hhyjfbl.Tables[0].Rows.Count > 0)
            {

                dsqymc = DS_Hhyjfbl.Tables[0].Rows[0]["qymc"].ToString();
                DbHelperSQL.ExecuteSql("delete from Hhyjf_bl where qymc='" + dsqymc + "'");
                foreach (DataRow dr in DS_Hhyjfbl.Tables[0].Rows)
                {

                    M_Hhyjfbl.yydh = dr["yydh"].ToString();
                    M_Hhyjfbl.qymc = dr["qymc"].ToString();
                    M_Hhyjfbl.krly = dr["krly"].ToString();
                    M_Hhyjfbl.jfbl = Convert.ToDecimal(dr["jfbl"].ToString());
                    M_Hhyjfbl.hyrx = dr["hyrx"].ToString();
                    M_Hhyjfbl.hyjfrx = dr["hyjfrx"].ToString();

                    M_Hhyjfbl.is_select = Convert.ToBoolean(dr["is_select"].ToString());
                    M_Hhyjfbl.is_top = Convert.ToBoolean(dr["is_top"].ToString());

                    if (B_Hhyjfbl.Add(M_Hhyjfbl) > 0)
                    {
                        s = common_file.common_app.get_suc;
                    }

                }
            }
            return s;
        }
    }
}
