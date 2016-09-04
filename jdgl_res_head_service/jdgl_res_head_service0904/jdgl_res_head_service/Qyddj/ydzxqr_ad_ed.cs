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
namespace jdgl_res_head_service.Qyddj
{
    public class ydzxqr_ad_ed
    {
        //门店下载网上预定确定后添加到该表
        public string Qyqskyd_ydzxqr_ad(DataSet DS_Qyqskyd_ydzxqr_downloadData)
        {
            string ss = common_file.common_app.get_failure;

            BLL.Qyqskyd_ydzxqr B_Qyqskyd_ydzxqr = new BLL.Qyqskyd_ydzxqr();
            Model.Qyqskyd_ydzxqr M_Qyqskyd_ydzxqr = new Model.Qyqskyd_ydzxqr();
            foreach (DataRow dr in DS_Qyqskyd_ydzxqr_downloadData.Tables[0].Rows)
            {
                SqlParameter[] parameters = {
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@qrzt", SqlDbType.VarChar,50),
					new SqlParameter("@qrsj", SqlDbType.DateTime),
					new SqlParameter("@qryy", SqlDbType.VarChar,200),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime),
                    new SqlParameter("@fjrb", SqlDbType.VarChar,50),
                    new SqlParameter("@qymc", SqlDbType.VarChar,50),
                    new SqlParameter("@yydh", SqlDbType.VarChar,50)
                };
                parameters[0].Value = dr["lsbh"];
                parameters[1].Value = dr["qrzt"];
                parameters[2].Value = Convert.ToDateTime(dr["qrsj"]);
                parameters[3].Value = dr["qryy"];
                parameters[4].Value = dr["czy"];
                parameters[5].Value = true;
                parameters[6].Value = Convert.ToDateTime(dr["scsj"]);
                parameters[7].Value = dr["fjrb"];
                parameters[8].Value = dr["qymc"];
                parameters[9].Value = dr["yydh"];


               int result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qyqskyd_ydzxqr_ADD", parameters);
                //成功继续
                if (result > 0)
                {
                    ss = common_file.common_app.get_suc;
                    continue;
                }
                //否则中断
                else
                {
                    ss = common_file.common_app.get_failure;
                    break;
                }
            }
            return ss;
        }


        //门店下载网上预定确定后转入住明细添加到该表
        public string Qyqskyd_ydzlzmx_ad(DataSet DS_Qyqskyd_ydzlzmx_downloadData)
        {
            string ss = common_file.common_app.get_failure;

            BLL.Qyqskyd_ydzlzmx B_Qyqskyd_ydzlzmx = new BLL.Qyqskyd_ydzlzmx();
            Model.Qyqskyd_ydzlzmx M_Qyqskyd_ydzlzmx = new Model.Qyqskyd_ydzlzmx();
            foreach (DataRow dr in DS_Qyqskyd_ydzlzmx_downloadData.Tables[0].Rows)
            {
                SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@sjjg", SqlDbType.Decimal,9),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@ddrq", SqlDbType.DateTime),
					new SqlParameter("@lkrq", SqlDbType.DateTime),
					new SqlParameter("@lzrx", SqlDbType.VarChar,50),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@scsj", SqlDbType.DateTime)};
                parameters[0].Value = dr["yydh"];
                parameters[1].Value = dr["qymc"];
                parameters[2].Value = dr["lsbh"];
                parameters[3].Value = dr["fjrb"];
                parameters[4].Value = dr["fjbh"];
                parameters[5].Value = Convert.ToDecimal(dr["sjje"]);
                parameters[6].Value = Convert.ToDateTime(dr["ddsj"]);
                parameters[7].Value = Convert.ToDateTime(dr["lksj"]);
                parameters[8].Value = Convert.ToDateTime(dr["ddrq"]);
                parameters[9].Value = Convert.ToDateTime(dr["lkrq"]);
                parameters[10].Value = dr["lzrx"];
                parameters[11].Value = Convert.ToDecimal(dr["lzfs"]);
                parameters[12].Value = true;
                parameters[13].Value = Convert.ToDateTime(dr["scsj"]);


                int result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qyqskyd_ydzlzmx_ADD", parameters);
                //成功继续
                if (result > 0)
                {
                    ss = common_file.common_app.get_suc;
                    continue;
                }
                //否则中断
                else
                {
                    ss = common_file.common_app.get_failure;
                    break;
                }
            }
            return ss;
        }

    }
}
