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
using jdgl_res_head_service.common_file;
namespace jdgl_res_head_service.Ffjzt
{
    public class Ffjrb
    {
        public string Ffjrb_UpLoadDS(DataSet DS, string operate)
        { 
            string s = common_file.common_app.get_failure;
            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {
                web_Fjrb_delete(DS.Tables[0].Rows[0]["yydh"].ToString(), DS.Tables[0].Rows[0]["qymc"].ToString());
                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    SqlParameter[] sp = {
						new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@fjrx", SqlDbType.VarChar,50),
					new SqlParameter("@xy", SqlDbType.VarChar,50),
					new SqlParameter("@fxdj", SqlDbType.Decimal,9),
					new SqlParameter("@fxmsj", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,250),
					new SqlParameter("@wlfs", SqlDbType.VarChar,50),
					new SqlParameter("@mdblf", SqlDbType.Int,4)};
                    sp[0].Value = dr[1];
                    sp[1].Value = dr[2];
                    sp[2].Value = dr[4];
                    sp[3].Value = "网络房价";
                    sp[4].Value = Convert.ToDecimal(dr[5]);
                    sp[5].Value = Convert.ToDecimal(dr[5]);
                    sp[6].Value = "网络房价";
                    sp[7].Value = "5";
                    sp[8].Value = 10;
                    int rows = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Web_Fjrb_ADD", sp);
                    if (rows > 0)
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
            }
            #region  初始化ffjzt
            if (s == common_file.common_app.get_suc)
            {
                if (string.Equals(operate, common_app.Inital, StringComparison.OrdinalIgnoreCase))
                {
                    s = common_app.get_failure;
                    if (DS.Tables[1].Rows.Count > 0)
                    {
                        DataSet ds0 = new DataSet();
                        DataTable dt = DS.Tables[1].Copy();
                        ds0.Tables.Add(dt);
                        Ffjzt.Web_Ffjzt Web_Ffjzt_new = new Web_Ffjzt();
                        s = Web_Ffjzt_new.Ffjzt_UpLoadDS(ds0);
                    }
                    else
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
            }
#endregion
            return s;
        }
        public static void web_Fjrb_delete(string yydh, string qymc)
        {
            SqlParameter[] sp = {
						new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50)};
                    sp[0].Value = yydh;
                    sp[1].Value =qymc;
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Web_Fjrb_Deleate", sp);
 
        }
    }
}
