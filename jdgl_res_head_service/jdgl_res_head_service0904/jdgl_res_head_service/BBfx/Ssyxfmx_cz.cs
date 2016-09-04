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
    public class Ssyxfmx_cz
    {
        public string Ssyxfmx_cz_UpLoadDS(DataSet DS)
        {

            string s = common_file.common_app.get_failure;

            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@id_app", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@gj_sf", SqlDbType.VarChar,50),
					new SqlParameter("@gj_cs", SqlDbType.VarChar,50),
					new SqlParameter("@gj_dq", SqlDbType.VarChar,50),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@is_top", SqlDbType.Bit,1)
					};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = dr[3];
                    parameters[3].Value = dr[4];
                    parameters[4].Value = dr[5];
                    parameters[5].Value = dr[6];
                    parameters[6].Value = dr[7];
                    parameters[7].Value = dr[8];
                    parameters[8].Value = dr[9];
                    parameters[9].Value = dr[10];
                    parameters[10].Value = dr[11]; ;
                    parameters[11].Value = dr[12];
                    parameters[12].Value = dr[13];
                    parameters[13].Value = dr[14];
                    parameters[14].Value = dr[15];
                    parameters[15].Value = dr[16];
                    parameters[16].Value = Convert.ToBoolean(dr[17]);
                    parameters[17].Value = Convert.ToBoolean(dr[18]);
           
                    int rows = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ssyxfmx_cz_ADD", parameters);
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
