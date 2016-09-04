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
    public class Ssyxfmx_xsy
    {
        public string Ssyxfmx_xsy_UpLoadDS(DataSet DS)
        {

            string s = common_file.common_app.get_failure;

            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@xsy_sl", SqlDbType.Int,4),
					new SqlParameter("@id_app", SqlDbType.VarChar,50)};
                
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = dr[3];
                    parameters[3].Value = true;
                    parameters[4].Value = Convert.ToInt32(dr[5]);
                    parameters[5].Value = dr[6];
                    int rows = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Ssyxfmx_xsy_ADD", parameters);
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
