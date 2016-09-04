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
    public class Hhyjb
    {
        public string Hhyjb_add_DS(DataSet DS_Hhyjb, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            string s = common_file.common_app.get_failure;
            BLL.Hhyjb B_Hhyjb = new BLL.Hhyjb();
            Model.Hhyjb M_Hhyjb = new Model.Hhyjb();
            string dsqymc = "";
            if (DS_Hhyjb != null && DS_Hhyjb.Tables[0].Rows.Count > 0)
            {
                dsqymc = DS_Hhyjb.Tables[0].Rows[0]["qymc"].ToString();
                DbHelperSQL.ExecuteSql("delete from Hhyjb where qymc='"+dsqymc+"'");
                foreach (DataRow dr in DS_Hhyjb.Tables[0].Rows)
                {
                    
                    M_Hhyjb.yydh = dr["yydh"].ToString();
                    M_Hhyjb.qymc = dr["qymc"].ToString();
                    M_Hhyjb.dfjf = Convert.ToDecimal(dr["dfjf"].ToString());
                    M_Hhyjb.hyrx = dr["hyrx"].ToString();
                    M_Hhyjb.is_select = Convert.ToBoolean(dr["is_select"].ToString());
                    M_Hhyjb.is_top = Convert.ToBoolean(dr["is_top"].ToString());
                    M_Hhyjb.jbxs = Convert.ToInt32(dr["jbxs"].ToString());
                    if (B_Hhyjb.Add(M_Hhyjb) > 0)
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
            }
            return s;
        }
    }
}
