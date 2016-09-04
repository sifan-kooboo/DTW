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
namespace jdgl_res_head_service.Lskr
{
   
    public class Qskyd_fjrb_lskr
    {
        public string Qskyd_fjrb_lskr_UploadDS(DataSet DS)  //上传
        {
           
            string s = common_file.common_app.get_failure;
     
            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@jzbh", SqlDbType.VarChar,100),
					new SqlParameter("@lsbh", SqlDbType.VarChar,100),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@fjrb", SqlDbType.VarChar,50),
					new SqlParameter("@fjbh", SqlDbType.VarChar,50),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@shqh", SqlDbType.VarChar,50),
					new SqlParameter("@fjjg", SqlDbType.Decimal,9),
					new SqlParameter("@sjfjjg", SqlDbType.Decimal,9),
					new SqlParameter("@yh", SqlDbType.VarChar,50),
					new SqlParameter("@yhbl", SqlDbType.Decimal,9),
					new SqlParameter("@bz", SqlDbType.VarChar,200),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@fjbm", SqlDbType.VarChar,50),
					new SqlParameter("@jcje", SqlDbType.Decimal,9)};
                    parameters[0].Value = dr["yydh"];
                    parameters[1].Value = dr["qymc"];
                    parameters[2].Value =dr["jzbh"];
                    parameters[3].Value = dr["lsbh"];
                    parameters[4].Value = dr["krxm"];
                    parameters[5].Value = dr["sktt"];
                    parameters[6].Value = dr["yddj"];
                    parameters[7].Value = dr["fjrb"];
                    parameters[8].Value = dr["fjbh"];
                    parameters[9].Value = Convert.ToDateTime(dr["ddsj"]);
                    parameters[10].Value = Convert.ToDateTime(dr["lksj"]);
                    parameters[11].Value = Convert.ToDecimal(dr["lzfs"]);
                    parameters[12].Value = dr["shqh"];
                    parameters[13].Value = Convert.ToDecimal(dr["fjjg"]);
                    parameters[14].Value = Convert.ToDecimal(dr["sjfjjg"]);
                    parameters[15].Value = dr["yh"];
                    parameters[16].Value = Convert.ToDecimal(dr["yhbl"]);
                    parameters[17].Value = dr["bz"];
                    parameters[18].Value = Convert.ToBoolean(dr["is_top"]);
                    parameters[19].Value = Convert.ToBoolean(dr["is_select"]);
                    parameters[20].Value = true;
                    parameters[21].Value = dr["czy"];
                    parameters[22].Value = DateTime.Now;
                    parameters[23].Value = dr["cznr"];
                    parameters[24].Value = Convert.ToBoolean(dr["sdcz"]);
                    parameters[25].Value = false;
                    parameters[26].Value = dr["fjbm"];
                    parameters[27].Value = Convert.ToDecimal(dr["jcje"]);

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_fjrb_lskr_ADD", parameters);
                   

                }
                s = common_file.common_app.get_suc;
            }
            return s;
        }


        //Qskyd_fjrb_lskr信息下载，供特定门店下载返回dataset
        public DataSet Qskyd_fjrb_lskr_download_Ds(string yydh)
        {
            
            BLL.Qskyd_fjrb_lskr B_Qskyd_fjrb_lskr = new BLL.Qskyd_fjrb_lskr();
            Model.Qskyd_fjrb_lskr M_Qskyd_fjrb_lskr = new Model.Qskyd_fjrb_lskr();
            Model.Lskr_sc_xz_sj M_Lskrscsj = new Model.Lskr_sc_xz_sj();
            BLL.Lskr_sc_xz_sj B_Lskrscsj = new BLL.Lskr_sc_xz_sj();

            //查询出上次上传时间
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            if (yydh != "" && yydh != null)
            {
                M_Lskrscsj = B_Lskrscsj.GetModelList("yydh='" + yydh + "'")[0];
                cstime = M_Lskrscsj.scsj;

            }
            string jstime = DateTime.Now.ToString();
            DataSet DS_Qskyd_fjrb_lskr = new DataSet();
            DS_Qskyd_fjrb_lskr = B_Qskyd_fjrb_lskr.GetList(2000,"yydh<>'" + yydh + "' and czsj>='" + cstime + "' and czsj<'" + jstime + "'","id");
            return DS_Qskyd_fjrb_lskr;
        }
        //供门店下载网上兑换记录
        public string Qskyd_fjrb_lskr_download(string yydh,out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;
          
            DS_download = null;
            DataSet DS_Qskyd_fjrb_lskr;

            DS_Qskyd_fjrb_lskr = Qskyd_fjrb_lskr_download_Ds(yydh);
            if (DS_Qskyd_fjrb_lskr != null)
            {
                DS_download = DS_Qskyd_fjrb_lskr;
               ss = common_file.common_app.get_suc;
            }
            return ss;
        }
        ////供门店下载初始别家数据
        //public string Qskyd_fjrb_lskr_download_cs(string yydh, out  DataSet DS_download)
        //{
        //    string ss = common_file.common_app.get_failure;
        //    DS_download = null;
        //    DataSet DS_Qskyd_fjrb_lskr;
        //    BLL.Qskyd_fjrb_lskr B_Qskyd_fjrb_lskr = new BLL.Qskyd_fjrb_lskr();
        //    DS_Qskyd_fjrb_lskr = B_Qskyd_fjrb_lskr.GetList(1000, "yydh<>'" + yydh + "' and shsc=1", "id");
        //    if (DS_Qskyd_fjrb_lskr != null)
        //    {
        //        DS_download = DS_Qskyd_fjrb_lskr;
        //        common_file.common_is_select.Updat_is_select(DS_Qskyd_fjrb_lskr, "Qskyd_fjrb_lskr");//is_select=1;
        //        ss = common_file.common_app.get_suc;
        //    }
        //    else
        //    {    //全部下载完后shsc要修改为1
        //        string strsql = "update Qskyd_fjrb_lskr set shsc=1 ";
        //        DbHelperSQL.ExecuteSql(strsql);

        //    }
        //    return ss;
        //}




    }
}
