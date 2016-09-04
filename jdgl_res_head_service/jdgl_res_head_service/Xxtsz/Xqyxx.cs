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
    public class Xqyxx
    {
                                                                
       

        public string Xqyxx_add_DS(DataSet DS_Xqyxx, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            string s = common_file.common_app.get_failure;
            BLL.Web_qyxx B_Xqyxx = new BLL.Web_qyxx();
            Model.Web_qyxx M_Xqyxx = new Model.Web_qyxx();


            if (DS_Xqyxx != null && DS_Xqyxx.Tables[0].Rows.Count > 0)
            {
                DbHelperSQL.ExecuteSql("delete from web_qyxx where yydh='" + DS_Xqyxx.Tables[0].Rows[0]["yydh"].ToString()+"'");
     
                foreach (DataRow dr in DS_Xqyxx.Tables[0].Rows)
                {
                   
                    M_Xqyxx.yydh = dr["yydh"].ToString();
                    M_Xqyxx.qymc = dr["qymc"].ToString();
                
                    M_Xqyxx.gj = dr["gj"].ToString();
                    M_Xqyxx.sf = dr["sf"].ToString();
                    M_Xqyxx.sb = dr["sb"].ToString();
                    M_Xqyxx.qybh = dr["qybh"].ToString();
                    M_Xqyxx.qydh = dr["qydh"].ToString();
                    M_Xqyxx.qycz = dr["qycz"].ToString();
                    M_Xqyxx.Email = dr["Email"].ToString();
                    M_Xqyxx.nxr = dr["nxr"].ToString();
                    M_Xqyxx.qydz = dr["qydz"].ToString();
                    M_Xqyxx.xtyysj = DateTime.Parse(dr["xtyysj"].ToString());
                    M_Xqyxx.hyxs = dr["hyxs"].ToString();
                    M_Xqyxx.lx = dr["lx"].ToString();
                 
                
                    if (B_Xqyxx.Add(M_Xqyxx) > 0)
                    {
                        s = common_file.common_app.get_suc;
                    }
              
                }
            }
            return s;
        }
    }
}
