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
using System.Collections.Generic;
using jdgl_res_head_service.log;
namespace jdgl_res_head_service.Lskr
{
    public class Qskyd_mainrecord_lskr
    {
        public string Qskyd_mainrecord_lskr_UploadDS(DataSet DS)  //上传
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
					new SqlParameter("@ddbh", SqlDbType.VarChar,100),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@hykh", SqlDbType.VarChar,50),
					new SqlParameter("@hyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krxm", SqlDbType.VarChar,50),
					new SqlParameter("@tlkr", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@krmz", SqlDbType.VarChar,50),
					new SqlParameter("@yxzj", SqlDbType.VarChar,50),
					new SqlParameter("@zjhm", SqlDbType.VarChar,50),
					new SqlParameter("@krxb", SqlDbType.VarChar,50),
					new SqlParameter("@krsr", SqlDbType.DateTime),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krsj", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,50),
					new SqlParameter("@krjg", SqlDbType.VarChar,50),
					new SqlParameter("@krdw", SqlDbType.VarChar,50),
					new SqlParameter("@krzy", SqlDbType.VarChar,50),
					new SqlParameter("@cxmd", SqlDbType.VarChar,50),
					new SqlParameter("@qzrx", SqlDbType.VarChar,50),
					new SqlParameter("@qzhm", SqlDbType.VarChar,50),
					new SqlParameter("@zjyxq", SqlDbType.DateTime),
					new SqlParameter("@tlyxq", SqlDbType.DateTime),
					new SqlParameter("@tjrq", SqlDbType.DateTime),
					new SqlParameter("@lzka", SqlDbType.VarChar,50),
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@ddrx", SqlDbType.VarChar,50),
					new SqlParameter("@ddwz", SqlDbType.VarChar,50),
					new SqlParameter("@zyzt", SqlDbType.VarChar,50),
					new SqlParameter("@krrx", SqlDbType.VarChar,50),
					new SqlParameter("@kr_children", SqlDbType.Int,4),
					new SqlParameter("@ddsj", SqlDbType.DateTime),
					new SqlParameter("@ddyy", SqlDbType.VarChar,200),
					new SqlParameter("@lzts", SqlDbType.Int,4),
					new SqlParameter("@lksj", SqlDbType.DateTime),
					new SqlParameter("@qtyq", SqlDbType.VarChar,800),
					new SqlParameter("@czy", SqlDbType.VarChar,50),
					new SqlParameter("@czsj", SqlDbType.DateTime),
					new SqlParameter("@cznr", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@sktt", SqlDbType.VarChar,50),
					new SqlParameter("@yddj", SqlDbType.VarChar,50),
					new SqlParameter("@ffshys", SqlDbType.Bit,1),
					new SqlParameter("@ffzf", SqlDbType.Bit,1),
					new SqlParameter("@main_sec", SqlDbType.VarChar,50),
					new SqlParameter("@sdcz", SqlDbType.Bit,1),
					new SqlParameter("@syzd", SqlDbType.VarChar,50),
					new SqlParameter("@vip_type", SqlDbType.VarChar,100),
					new SqlParameter("@tsyq", SqlDbType.VarChar,800),
					new SqlParameter("@is_visible", SqlDbType.Bit,1),
					new SqlParameter("@ddly", SqlDbType.VarChar,50),
					new SqlParameter("@hykh_bz", SqlDbType.VarChar,50)};
              
                    parameters[0].Value = dr["yydh"];
                    parameters[1].Value = dr["qymc"];
                    parameters[2].Value = dr["jzbh"];
                    parameters[3].Value = dr["lsbh"];
                    parameters[4].Value = dr["ddbh"];
                    parameters[5].Value = dr["is_top"];
                    parameters[6].Value = dr["is_select"];
                    parameters[7].Value = dr["hykh"];
                    parameters[8].Value = dr["hyrx"];
                    parameters[9].Value = dr["krxm"];
                    parameters[10].Value = dr["tlkr"];
                    parameters[11].Value = dr["krgj"];
                    parameters[12].Value = dr["krmz"];
                    parameters[13].Value = dr["yxzj"];
                    parameters[14].Value = dr["zjhm"];
                    parameters[15].Value = dr["krxb"];
                    parameters[16].Value = Convert.ToDateTime(dr["krsr"]);
                    parameters[17].Value = dr["krdh"];
                    parameters[18].Value = dr["krsj"];
                    parameters[19].Value = dr["krEmail"];
                    parameters[20].Value = dr["krdz"];
                    parameters[21].Value = dr["krjg"];
                    parameters[22].Value = dr["krdw"];
                    parameters[23].Value = dr["krzy"];
                    parameters[24].Value = dr["cxmd"];
                    parameters[25].Value = dr["qzrx"];
                    parameters[26].Value = dr["qzhm"];
                    parameters[27].Value = Convert.ToDateTime(dr["zjyxq"]);
                    parameters[28].Value = Convert.ToDateTime(dr["tlyxq"]);
                    parameters[29].Value = Convert.ToDateTime(dr["tjrq"]);
                    parameters[30].Value = dr["lzka"];
                    parameters[31].Value = dr["krly"];
                    parameters[32].Value = dr["xyh"];
                    parameters[33].Value = dr["xydw"];
                    parameters[34].Value = dr["xsy"];
                    parameters[35].Value = dr["ddrx"];
                    parameters[36].Value = dr["ddwz"];
                    parameters[37].Value = dr["zyzt"];
                    parameters[38].Value = dr["krrx"];
                    parameters[39].Value = Convert.ToInt32(dr["kr_children"]);
                    parameters[40].Value = Convert.ToDateTime(dr["ddsj"]);
                    parameters[41].Value = dr["ddyy"];
                    parameters[42].Value = Convert.ToInt32(dr["lzts"]);
                    parameters[43].Value = Convert.ToDateTime(dr["lksj"]);
                    parameters[44].Value = dr["qtyq"];
                    parameters[45].Value = dr["czy"];
                    parameters[46].Value = DateTime.Now;
                    parameters[47].Value = dr["cznr"];
                    parameters[48].Value = true;
                    parameters[49].Value = dr["sktt"];
                    parameters[50].Value = dr["yddj"];
                    parameters[51].Value = Convert.ToBoolean(dr["ffshys"]);
                    parameters[52].Value = Convert.ToBoolean(dr["ffzf"]);
                    parameters[53].Value = dr["main_sec"];
                    parameters[54].Value = Convert.ToBoolean(dr["sdcz"]);
                    parameters[55].Value = dr["syzd"];
                    parameters[56].Value = dr["vip_type"];
                    parameters[57].Value = dr["tsyq"];
                    parameters[58].Value = false;
                    parameters[59].Value = dr["ddly"];
                    parameters[60].Value = dr["hykh_bz"];

                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_mainrecord_lskr_ADD", parameters);


                }
                s = common_file.common_app.get_suc;
            }
            return s;
        }
        //Qskyd_fjrb_lskr信息下载，供特定门店下载返回dataset
        public DataSet Qskyd_mainrecord_lskr_download_DS(string yydh)
        {
           
            BLL.Qskyd_mainrecord_lskr B_Qskyd_mainrecord_lskr = new BLL.Qskyd_mainrecord_lskr();
            Model.Qskyd_mainrecord_lskr M_Qskyd_mainrecord_lskr = new Model.Qskyd_mainrecord_lskr();
            Model.Lskr_sc_xz_sj M_Lskrscsj = new Model.Lskr_sc_xz_sj();
            BLL.Lskr_sc_xz_sj B_Lskrscsj = new BLL.Lskr_sc_xz_sj();
            string jstime = DateTime.Now.ToString();
            DataSet DS_Qskyd_mainrecord_lskr = new DataSet();

            //查询出上次上传时间
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            if (yydh != "" && yydh != null)
            {
                List<Model.Lskr_sc_xz_sj> listlskr = B_Lskrscsj.GetModelList("yydh='" + yydh + "'");
                if (listlskr.Count > 0)
                {
                    M_Lskrscsj = listlskr[0];
                    cstime = M_Lskrscsj.scsj;

                    DS_Qskyd_mainrecord_lskr = B_Qskyd_mainrecord_lskr.GetList(2000, "yydh<>'" + yydh + "' and czsj>='" + cstime + "' and czsj<'" + jstime + "'", "id");
                }
                else
                {
                    LogHelper.WriteLog("中心服务器表Lskr_sc_xz_sj里没有配置yydh为:" + yydh + "的门店初始下载的记录信息,请先配置信息");
                    DS_Qskyd_mainrecord_lskr = null;
                }
            }
            return DS_Qskyd_mainrecord_lskr;
        }
        //供门店下载Qskyd_mainrecord_lskr
        public string Qskyd_mainrecord_lskr_download(string yydh, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;

            DS_download = null;
            DataSet DS_Qskyd_mainrecord;
            DS_Qskyd_mainrecord = Qskyd_mainrecord_lskr_download_DS(yydh);
            if (DS_Qskyd_mainrecord != null)
            {
                DS_download = DS_Qskyd_mainrecord;
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }
        //下载好后更新服务器的上传时间
        public string Lskr_scxzsj(string yydh, string jsdatatime)
        {
            string s = common_file.common_app.get_failure;

            string strsql = "update Lskr_sc_xz_sj set scsj='" + jsdatatime + "' where yydh='" + yydh + "'";
            int i = DbHelperSQL.ExecuteSql(strsql);

            if (i > 0)
            {

                s = common_file.common_app.get_suc;
            }
            return s;
        }

        ////供门店下载初始别家数据
        //public string Qskyd_mainrecord_lskr_download_cs(string yydh, out  DataSet DS_download)
        //{
        //    string ss = common_file.common_app.get_failure;
        //    DS_download = null;
        //    DataSet DS_Qskyd_mainrecord_lskr;
        //    BLL.Qskyd_mainrecord_lskr B_Qskyd_mainrecord_lskr = new BLL.Qskyd_mainrecord_lskr();
        //    DS_Qskyd_mainrecord_lskr = B_Qskyd_mainrecord_lskr.GetList(1000, "yydh<>'" + yydh + "' and shsc=1", "id");
        //    if (DS_Qskyd_mainrecord_lskr != null)
        //    {
        //        DS_download = DS_Qskyd_mainrecord_lskr;
        //        common_file.common_is_select.Updat_is_select(DS_Qskyd_mainrecord_lskr, "Qskyd_mainrecord_lskr");//is_select=1;
        //        ss = common_file.common_app.get_suc;
        //    }
        //    else
        //    {    //全部下载完后shsc要修改为1
        //        string strsql = "update Qskyd_mainrecord_lskr set shsc=1 ";
        //        DbHelperSQL.ExecuteSql(strsql);

        //    }
        //    return ss;
        //}
    }
}
