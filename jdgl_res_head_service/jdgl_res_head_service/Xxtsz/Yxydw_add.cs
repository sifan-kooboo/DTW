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
using jdgl_res_head_service.common_file;
namespace jdgl_res_head_service.Xxtsz
{
    public class Yxydw_add
    {
        /// <summary>
        /// 用于门店协议单位在中心服务器上的初始化
        /// </summary>
        /// <param name="DS_Yxydw_yy">传过来的协议单位的DS</param>
        /// <param name="qymc">企业名称</param>
        /// <returns></returns>
        public string Yxydw_add_DS(DataSet DS_Yxydw,string xx_zs)
        {
            string s = common_file.common_app.get_failure;

            BLL.Web_Yxydw B_Yxydw = new BLL.Web_Yxydw();
            Model.Web_Yxydw M_Yxydw = new Model.Web_Yxydw();
            if (DS_Yxydw != null && DS_Yxydw.Tables[0].Rows.Count > 0)
            {

                DbHelperSQL.ExecuteSql("delete from Web_Yxydw where yydh='" + DS_Yxydw.Tables[0].Rows[0]["yydh"].ToString() + "'");
                foreach (DataRow dr in DS_Yxydw.Tables[0].Rows)
                {

                    SqlParameter[] parameters = {
					new SqlParameter("@krly", SqlDbType.VarChar,50),
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@xyrx", SqlDbType.VarChar,50),
					new SqlParameter("@krgj", SqlDbType.VarChar,50),
					new SqlParameter("@pq", SqlDbType.VarChar,50),
					new SqlParameter("@xyh", SqlDbType.VarChar,50),
					new SqlParameter("@xyh_inner", SqlDbType.VarChar,50),
					new SqlParameter("@rx", SqlDbType.VarChar,50),
					new SqlParameter("@xydw", SqlDbType.VarChar,50),
					new SqlParameter("@zjm", SqlDbType.VarChar,50),
					new SqlParameter("@nxr", SqlDbType.VarChar,50),
					new SqlParameter("@krdh", SqlDbType.VarChar,50),
					new SqlParameter("@krcz", SqlDbType.VarChar,50),
					new SqlParameter("@krEmail", SqlDbType.VarChar,50),
					new SqlParameter("@krdz", SqlDbType.VarChar,200),
					new SqlParameter("@xsy", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@bz", SqlDbType.VarChar,300),
					new SqlParameter("@lzfs", SqlDbType.Decimal,9),
					new SqlParameter("@fkje", SqlDbType.Decimal,9),
					new SqlParameter("@xfje", SqlDbType.Decimal,9),
					new SqlParameter("@clsj", SqlDbType.DateTime),
					new SqlParameter("@xzxg", SqlDbType.VarChar,50),
					new SqlParameter("@is_top", SqlDbType.Bit,1),
					new SqlParameter("@is_select", SqlDbType.Bit,1),
					new SqlParameter("@shsh", SqlDbType.Bit,1),
					new SqlParameter("@sign_image", SqlDbType.Image)};
                    parameters[0].Value = dr["krly"].ToString();
                    parameters[1].Value = dr["yydh"].ToString();
                    parameters[2].Value = dr["qymc"].ToString();
                    parameters[3].Value = dr["xyrx"].ToString();
                    parameters[4].Value = dr["krgj"].ToString();
                    parameters[5].Value = dr["pq"].ToString();
                    parameters[6].Value = dr["xyh"].ToString();
                    parameters[7].Value = dr["xyh_inner"].ToString();
                    parameters[8].Value = dr["rx"].ToString();
                    parameters[9].Value = dr["xydw"].ToString();
                    parameters[10].Value = dr["zjm"].ToString();
                    parameters[11].Value = dr["nxr"].ToString();
                    parameters[12].Value = dr["krdh"].ToString();
                    parameters[13].Value = dr["krcz"].ToString();
                    parameters[14].Value = dr["kremail"].ToString();
                    parameters[15].Value = dr["krdz"].ToString();
                    parameters[16].Value = dr["xsy"].ToString();
                    parameters[17].Value = true;
                    parameters[18].Value = dr["bz"].ToString();
                    parameters[19].Value = Convert.ToDecimal(dr["lzfs"].ToString());
                    parameters[20].Value = Convert.ToDecimal(dr["fkje"].ToString());
                    parameters[21].Value = Convert.ToDecimal(dr["xfje"].ToString());
                    parameters[22].Value = DateTime.Now;
                    parameters[23].Value = dr["xzxg"].ToString();
                    parameters[24].Value = Convert.ToBoolean(dr["is_top"].ToString());
                    parameters[25].Value = Convert.ToBoolean(dr["is_select"].ToString());
                    parameters[26].Value = Convert.ToBoolean(dr["shsh"].ToString());
                    parameters[27].Value = (byte[])(dr["sign_image"]);

                   int stryxydwa=SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Web_Yxydw_ADD", parameters);
                   if (stryxydwa > 0)
                    {
                        s = common_file.common_app.get_suc;

                    }
                }
            }
            return s;
        }

        /// <summary>
        /// 用于门店向中心服务器数据上传
        /// </summary>
        /// <param name="DS_Yxydw"></param>
        /// <returns></returns>
        public string Yxydw_add_DS_01(DataSet DS_Yxydw)
        {
            string s = common_file.common_app.get_failure;
            BLL.Web_Yxydw B_Yxydw = new BLL.Web_Yxydw();
            Model.Web_Yxydw M_Yxydw = new Model.Web_Yxydw();
            if (DS_Yxydw != null && DS_Yxydw.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS_Yxydw.Tables[0].Rows)
                {
                    string strXyh = dr["xyh"].ToString();
                    M_Yxydw.qymc = dr["qymc"].ToString();
                    M_Yxydw.yydh = dr["yydh"].ToString();
                    M_Yxydw.zjm = dr["zjm"].ToString();
                    M_Yxydw.xzxg = dr["xzxg"].ToString();
                    M_Yxydw.xyrx = dr["xyrx"].ToString();
                    M_Yxydw.xyh_inner = dr["xyh_inner"].ToString();
                    M_Yxydw.xyh = dr["xyh"].ToString();
                    M_Yxydw.xydw = dr["xydw"].ToString();
                    M_Yxydw.xsy = dr["xsy"].ToString();
                    M_Yxydw.xfje = Convert.ToDecimal(dr["xfje"].ToString());
                    M_Yxydw.sign_image = (byte[])(dr["sign_image"]);
                    M_Yxydw.shsh = Convert.ToBoolean(dr["shsh"].ToString());
                    M_Yxydw.shsc = true;
                    M_Yxydw.rx = dr["rx"].ToString();
                    M_Yxydw.pq = dr["pq"].ToString();
                    M_Yxydw.nxr = dr["nxr"].ToString();
                    M_Yxydw.lzfs = Convert.ToDecimal(dr["lzfs"].ToString());
                    M_Yxydw.krly = dr["krly"].ToString();
                    M_Yxydw.krgj = dr["krgj"].ToString();
                    M_Yxydw.krEmail = dr["kremail"].ToString();
                    M_Yxydw.krdz = dr["krdz"].ToString();
                    M_Yxydw.krdh = dr["krdh"].ToString();
                    M_Yxydw.krcz = dr["krcz"].ToString();
                    M_Yxydw.is_top = Convert.ToBoolean(dr["is_top"].ToString());
                    M_Yxydw.is_select = Convert.ToBoolean(dr["is_select"].ToString());
                    M_Yxydw.bz = dr["bz"].ToString();
                    M_Yxydw.clsj = DateTime.Now;
                    M_Yxydw.fkje = Convert.ToDecimal(dr["fkje"].ToString());
                    M_Yxydw.xzxg = "xz";
                    DataSet DS_Xydwservice = new DataSet();
                    DS_Xydwservice = B_Yxydw.GetList("xyh='" +strXyh + "'");
                    if (DS_Xydwservice != null && DS_Xydwservice.Tables[0].Rows.Count > 0)
                    {
                        M_Yxydw.id = Convert.ToInt32(DS_Xydwservice.Tables[0].Rows[0]["id"].ToString());
                        if (B_Yxydw.Update(M_Yxydw))
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                    else
                    {
                        if (B_Yxydw.Add(M_Yxydw) > 0)
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                }
            }
            return s;
        }

        //协议单位信息下载，供特定门店下载返回dataset
        public DataSet DSYxydw_download(string yydh,out string csdatatime, out string jsdatatime)
        {
            BLL.Web_Yxydw B_Yxydw = new BLL.Web_Yxydw();
            Model.Web_Yxydw M_Yxydw = new Model.Web_Yxydw();
            Model.Yxy_sc_xz_sj M_scsj = new Model.Yxy_sc_xz_sj();
            BLL.Yxy_sc_xz_sj B_scsj = new BLL.Yxy_sc_xz_sj();

            //查询出上次上传时间
            DateTime cstime = DateTime.Parse(common_app.cssj);
            if (yydh != "" && yydh != null)
            {
                List<Model.Yxy_sc_xz_sj> listModels = B_scsj.GetModelList("yydh='" + yydh + "'");
                if (listModels.Count > 0)
                {
                    M_scsj = listModels[0];
                    cstime = M_scsj.scsj;
                }
                else
                {
                    log.LogHelper.WriteLog("出错,中心服务器找不到yydh为:"+yydh+"配置的初始下载时间记录,");
                    csdatatime = "";
                    jsdatatime = "";
                    return null;
                }
            }
            string jstime = DateTime.Now.ToString();
            DataSet DS_Yxydw = new DataSet();
            jsdatatime = jstime;
            csdatatime = cstime.ToString();
            DS_Yxydw = B_Yxydw.GetList(2000,"yydh<>'" + yydh + "' and (clsj>='" + cstime + "' and clsj<'" + jstime + "' and rx='协议单位') or xzxg='xg'","id");
            if (DS_Yxydw != null)
            {
                jsdatatime = jstime;
                csdatatime = cstime.ToString();
            }
            return DS_Yxydw;
        }

        /// <summary>
        /// 供门店下载网上协议单位调用
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="csdatetime"></param>
        /// <param name="jsdatatime"></param>
        /// <param name="DS_download"></param>
        /// <returns></returns>
        public string Yxydw_download(string yydh,out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;
            DS_download = null;
            DataSet DS_Yxydw;
            jsdatatime = "1800-01-01";   //结束时间
            csdatetime = "1800-01-01";   //初始时间
            DS_Yxydw = DSYxydw_download(yydh,out csdatetime, out jsdatatime);
            if (DS_Yxydw != null)
            {
                DS_download = DS_Yxydw;
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }

        /// <summary>
        /// 供门店下载数据成功后调用更新服务器中记录的下载时间
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="jsdatatime">scsj='" + jsdatatime + "'</param>
        /// <returns></returns>
        public string Yxydw_scxzsj(string yydh, string jsdatatime)
        {
            string s = common_file.common_app.get_failure;
            string strsql = "update Yxy_sc_xz_sj set scsj='" + jsdatatime + "' where yydh='" + yydh + "'";
            int i = DbHelperSQL.ExecuteSql(strsql);
            if (i > 0)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }


        ////供门店下载初始别家协议单位
        //public string Yxydw_download_cs(string yydh,out  DataSet DS_download)
        //{
        //    string ss = common_file.common_app.get_failure;
        //    DS_download = null;
        //    DataSet DS_Yxydw;
        //    BLL.Web_Yxydw B_Yxydw = new BLL.Web_Yxydw();
        //    DS_Yxydw = B_Yxydw.GetList(1000, "yydh<>'" + yydh + "' and shsc=1", "id");
        //    if (DS_Yxydw != null)
        //    {
        //        DS_download = DS_Yxydw;
        //        common_file.common_is_select.Updat_is_select(DS_Yxydw, "Web_Yxydw");//is_select=1;
        //        ss = common_file.common_app.get_suc;
        //    }
        //    else
        //    {    //全部下载完后shsc要修改为1
        //        string strsql = "update Web_yxydw set shsc=1 ";
        //        DbHelperSQL.ExecuteSql(strsql);
 
        //    }
        //    return ss;
        //}

    }
}
