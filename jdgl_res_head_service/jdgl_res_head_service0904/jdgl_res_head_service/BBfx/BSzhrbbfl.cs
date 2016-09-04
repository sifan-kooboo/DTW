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
    public class BSzhrbbfl
    {
        public string BSzhrbbfl_UpLoadDS(DataSet DS)
        {
            DbHelperSQLP helper = new DbHelperSQLP();
            string s = common_file.common_app.get_failure;
            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@zfs", SqlDbType.Float,8),
					new SqlParameter("@zyye", SqlDbType.Float,8),
					new SqlParameter("@zfh", SqlDbType.Float,8),
					new SqlParameter("@czfs", SqlDbType.Float,8),
					new SqlParameter("@pjczl", SqlDbType.VarChar,53),
					new SqlParameter("@pjfj", SqlDbType.Float,8),
					new SqlParameter("@jcb", SqlDbType.Float,8),
					new SqlParameter("@wjds", SqlDbType.Float,8),
					new SqlParameter("@gztj", SqlDbType.Float,8),
					new SqlParameter("@jztj", SqlDbType.Float,8),
					new SqlParameter("@sztj", SqlDbType.Float,8),
					new SqlParameter("@yjds", SqlDbType.Float,8),
					new SqlParameter("@ljwj", SqlDbType.Float,8),
					new SqlParameter("@ljyf", SqlDbType.Float,8),
					new SqlParameter("@ljgz", SqlDbType.Float,8),
					new SqlParameter("@ljjz", SqlDbType.Float,8),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = Convert.ToDateTime(dr[3]);
                    parameters[3].Value = Convert.ToDecimal(dr[4]);
                    parameters[4].Value = Convert.ToDecimal(dr[5]);
                    parameters[5].Value = Convert.ToDecimal(dr[6]);
                    parameters[6].Value = Convert.ToDecimal(dr[7]);
                    parameters[7].Value = dr[8];
                    parameters[8].Value = Convert.ToDecimal(dr[9]);
                    parameters[9].Value = Convert.ToDecimal(dr[10]);
                    parameters[10].Value = Convert.ToDecimal(dr[11]);
                    parameters[11].Value = Convert.ToDecimal(dr[12]);
                    parameters[12].Value = Convert.ToDecimal(dr[13]);
                    parameters[13].Value = Convert.ToDecimal(dr[14]);
                    parameters[14].Value = Convert.ToDecimal(dr[15]);
                    parameters[15].Value = Convert.ToDecimal(dr[16]);
                    parameters[16].Value = Convert.ToDecimal(dr[17]);
                    parameters[17].Value = Convert.ToDecimal(dr[18]);
                    parameters[18].Value = Convert.ToDecimal(dr[19]);
                    parameters[19].Value = false;
                    helper.RunProcedure("BSzhrbbfl_ADD", parameters);
                    s = common_file.common_app.get_suc;

                }
            }
            return s;
        }
    }
}
