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
    public class BSzhrbb
    {

        DbHelperSQLP helper = new DbHelperSQLP();
        /// <summary>
        /// 删除远程服务器上，时间为DS中记录中的数据
        /// </summary>
        /// <param name="qymc">企业名称</param>
        /// <param name="ds">记录传过来的时间的DS</param>
        /// <returns></returns>
        public string BSzhrbb_Delete(string yydh, DataSet ds)
        {
            string ss = common_file.common_app.get_failure;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DateTime dt = Convert.ToDateTime(dr[0].ToString());
                    SqlParameter[] sp ={new SqlParameter("@yydh",SqlDbType.VarChar),
                        new SqlParameter("@time",SqlDbType.DateTime)
                    };
                    sp[0].Value = yydh;
                    sp[1].Value = dt;
                    helper.RunProcedure("BBzhrbb_Delete", sp);
                    ss = common_file.common_app.get_suc;
                }
            }
            return ss;
        }

        public string BSzhrbb_UpLoadDS(DataSet DS)
        {

            string s = common_file.common_app.get_failure;
            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    
                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@bbrq", SqlDbType.DateTime),
					new SqlParameter("@rbxm", SqlDbType.VarChar,50),
					new SqlParameter("@brrj", SqlDbType.VarChar,50),
					new SqlParameter("@byrj", SqlDbType.VarChar,50),
					new SqlParameter("@rbxm0", SqlDbType.VarChar,50),
					new SqlParameter("@brrj0", SqlDbType.VarChar,50),
					new SqlParameter("@byrj0", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1)};
                    parameters[0].Value = dr[1];
                    parameters[1].Value = dr[2];
                    parameters[2].Value = Convert.ToDateTime(dr[3]);
                    parameters[3].Value = dr[4];
                    parameters[4].Value = dr[5];
                    parameters[5].Value = dr[6];
                    parameters[6].Value = dr[7];
                    parameters[7].Value = dr[8];
                    parameters[8].Value = dr[9];
                    parameters[9].Value = true;
                    helper.RunProcedure("BSzhrbb_ADD", parameters);
                    s = common_file.common_app.get_suc;
                   
                }
            }
            return s;
        }
    }
}
