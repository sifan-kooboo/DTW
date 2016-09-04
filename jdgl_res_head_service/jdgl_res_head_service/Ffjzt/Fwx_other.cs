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
namespace jdgl_res_head_service.Ffjzt
{
    public class Fwx_other
    {
       // id,yydh,qymc,lsbh,fjrb,fjbh,ddsj,lksj,bz,zyzt,czsj,cznr,czy,is_top,is_select,shsc
        public string Fwx_other_UploadDS(DataSet DS_Fwxother)  //Î¬ÐÞ·¿ÉÏ´«
        {
            DbHelperSQLP Helpsql = new DbHelperSQLP();
            string s = common_file.common_app.get_failure;
            BLL.Fwx_other B_Fwx_other = new BLL.Fwx_other();
            Model.Fwx_other M_Fwx_other = new Model.Fwx_other();
            if (DS_Fwxother != null && DS_Fwxother.Tables[0].Rows.Count > 0)
            {
                string dsqymc = DS_Fwxother.Tables[0].Rows[0]["yydh"].ToString();
                DbHelperSQL.ExecuteSql("delete from Fwx_other where yydh='" + dsqymc + "'");
                foreach (DataRow dr in DS_Fwxother.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@bz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = dr[3];
                    parameters[3].Value = dr[4];
                    parameters[4].Value = dr[5];
                    parameters[5].Value = Convert.ToDateTime(dr[6]);
                    parameters[6].Value = Convert.ToDateTime(dr[7]);
                    parameters[7].Value = dr[8];
                    parameters[8].Value = dr[9];
                    parameters[9].Value =  Convert.ToDateTime(dr[10]);
                    parameters[10].Value = dr[11];
                    parameters[11].Value = dr[12];
                    parameters[12].Value = Convert.ToBoolean(dr[13]);
                    parameters[13].Value =  Convert.ToBoolean(dr[14]);
                    parameters[14].Value = true;
                    Helpsql.RunProcedure("Fwx_other_ADD", parameters);
                    s = common_file.common_app.get_suc;
           
                }
            }
            return s;
        }
    }
}
