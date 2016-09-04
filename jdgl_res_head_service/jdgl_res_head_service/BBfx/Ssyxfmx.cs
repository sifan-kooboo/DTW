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
namespace jdgl_res_head_service.BBfx
{
    public class Ssyxfmx
    {
        public string Ssyxfmx_UpLoadDS(DataSet DS)
        {

            string s = common_file.common_app.get_failure;
            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@xfrq", SqlDbType.DateTime),
					new SqlParameter("@xfsj", SqlDbType.DateTime),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@xfdr", SqlDbType.VarChar,50),
					new SqlParameter("@xfrb", SqlDbType.VarChar,50),
					new SqlParameter("@xfxm", SqlDbType.VarChar,50),
					new SqlParameter("@xfbz", SqlDbType.VarChar,50),
					new SqlParameter("@xfzy", SqlDbType.VarChar,50),
					new SqlParameter("@jjje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@sjxfje", SqlDbType.Decimal,9),
					new SqlParameter("@xfsl", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy_bc", SqlDbType.VarChar,50),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@mxbh", SqlDbType.VarChar,50)};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = Convert.ToBoolean(dr[3]);
                    parameters[3].Value = Convert.ToBoolean(dr[4]);
                    parameters[4].Value = dr[5];
                    parameters[5].Value = dr[6];
                    parameters[6].Value = dr[7];
                    parameters[7].Value = dr[8];
                    parameters[8].Value = dr[9];
                    parameters[9].Value = dr[10];
                    parameters[10].Value = dr[11];
                    parameters[11].Value = Convert.ToDateTime(dr[12]);
                    parameters[12].Value = Convert.ToDateTime(dr[13]);
                    parameters[13].Value = dr[14];
                    parameters[14].Value = dr[15];
                    parameters[15].Value = dr[16];
                    parameters[16].Value = dr[17];
                    parameters[17].Value = dr[18];
                    parameters[18].Value = dr[19];
                    parameters[19].Value = Convert.ToDecimal(dr[20]);
                    parameters[20].Value = Convert.ToDecimal(dr[21]);
                    parameters[21].Value = dr[22];
                    parameters[22].Value = Convert.ToDecimal(dr[23]);
                    parameters[23].Value = Convert.ToDecimal(dr[24]);
                    parameters[24].Value = true;
                    parameters[25].Value = dr[26];
                    parameters[26].Value = Convert.ToBoolean(dr[27]);
                    parameters[27].Value = dr[28];
                    int rows = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ssyxfmx_ADD", parameters);
                    if (rows > 0)
                    {
                        s = common_file.common_app.get_suc;

                    }


                }
            }
            return s;
        }
    }
}
