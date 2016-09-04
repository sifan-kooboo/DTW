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
namespace jdgl_res_head_service.Hhygl
{
    
    public class Hhygl_ad_ed
    {
       


        //查询远程服务的初始时间
        public string GetSCtime(string yydh,out string cstime)
        {
           string s = common_file.common_app.get_failure;
           string strsql = "select hy_scsj from Hhy_sc_xz_sj where yydh='" + yydh + "'";
           string  strcstime=DbHelperSQL.GetSingle(strsql).ToString();
           cstime = "1800-01-01";
           if (strcstime != "" && strcstime != null)
           {
               cstime = strcstime;
               s = common_file.common_app.get_suc;
 
           }
           return s;
 
        }


        //修改本地会员信息表shsc=1
        public int UpdatHhyglshsc(DataSet DS_Hhygl)
        {
            string Local_lsbh = "";
            //用于接收执行存储过程后的值（通用变量）
            int temp_result = 0;
            int i = 0;
            foreach (DataRow dr in DS_Hhygl.Tables[0].Rows)
            {
                Local_lsbh = dr["hykh"].ToString();
                DbHelperSQLP helper = new DbHelperSQLP();
                SqlParameter[] para = new SqlParameter[]{
                                new SqlParameter("@hykh",Local_lsbh)
                            };
                helper.RunProcedure("HhyglStatus", para, out temp_result);
                if (temp_result > 0)
                {
                    i++;

                    continue;
                }
                else
                {

                    break;
                }
            }
            return i;
        }

        public string UDshsc(DataSet DS_Hhygl)
        {
            string ss = common_file.common_app.get_failure;
            if (DS_Hhygl != null && DS_Hhygl.Tables[0].Rows.Count > 0)
            {
                ss = common_file.common_app.get_suc;
 
            }
            return ss;

        }

        //会员信息下载，供特定门店下载返回dataset
        public DataSet DSHhygl_download(string yydh, out  int rows, out string csdatatime, out string jsdatatime)
        {
            BLL.Web_Hhygl B_Hhygl = new BLL.Web_Hhygl();
            Model.Web_Hhygl M_Hhygl = new Model.Web_Hhygl();
            Model.Hhy_sc_xz_sj M_Hhyscsj = new Model.Hhy_sc_xz_sj();
            BLL.Hhy_sc_xz_sj B_Hhyscsj = new BLL.Hhy_sc_xz_sj();

            //查询出上次上传时间
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            if (yydh != ""&&yydh!=null)
            {
                M_Hhyscsj = B_Hhyscsj.GetModelList("yydh='" + yydh + "'")[0];
                cstime = M_Hhyscsj.hy_scsj;
                
            }
            string jstime = DateTime.Now.ToString();
            DataSet DS_Hhygl= new DataSet();
            rows = 0;
            jsdatatime = jstime;
            csdatatime = cstime.ToString();
            //status = false;
            //msg = "没有查到要下载的数据信息或者远程服务器出错";
            DS_Hhygl = B_Hhygl.GetList("yydh<>'" + yydh + "' and scsj>='" + cstime + "' and scsj<'"+jstime+"'");
            if (DS_Hhygl != null)
            {
                rows = DS_Hhygl.Tables[0].Rows.Count;
                jsdatatime = jstime;
                csdatatime = cstime.ToString();
                //status = true;
                //msg = "查询成功";

            }
           
            return DS_Hhygl;
        }

       //供门店下载网上的会员信息
        public string Hhygl_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;
            rows = 0;
            //status = false;
            DS_download = null;
            DataSet DS_Hhygl;
            //msg = "没有查到要下载的数据信息或者远程服务器出错,webservice";
            jsdatatime = "1800-01-01";   //结束时间
            csdatetime = "1800-01-01";   //初始时间
            DS_Hhygl = DSHhygl_download(yydh, out rows, out csdatetime, out jsdatatime);
            if (DS_Hhygl != null && rows > 0)
            {
                DS_download = DS_Hhygl;
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }

        //下载好后更新服务器的上传时间
        public string Hhy_scxzsj(string yydh, string jsdatatime)
        {
            string s = common_file.common_app.get_failure;
        
            string strsql = "update Hhy_sc_xz_sj set hy_scsj='"+jsdatatime+"' where yydh='" + yydh + "'";
            int i=DbHelperSQL.ExecuteSql(strsql);

            if (i>0)
            {
                
                s = common_file.common_app.get_suc;
            }
            return s;
        }
      

        public int GetHhykh(string hykh_service)
        {
            BLL.Web_Hhygl B_Hhygl = new BLL.Web_Hhygl();
            Model.Web_Hhygl M_Hhygl = new Model.Web_Hhygl();
            M_Hhygl = B_Hhygl.GetModelList("hykh='" + hykh_service + "'")[0];
            return M_Hhygl.id;

 
        }
        public string Hhygl_add_DS(DataSet DS_Hhygl, string xx_zs)//带两个不同参数,其中一个是DATASET,另一个是string,返回string;
        {
            //id,yydh,qymc,hyrx,fjrb,hyfj,bz,shsc,is_top,is_select
            string s = common_file.common_app.get_failure;
            BLL.Web_Hhygl B_Hhygl = new BLL.Web_Hhygl();
            Model.Web_Hhygl M_Hhygl = new Model.Web_Hhygl();
            string dsqymc = "";
            string hykh = "";

            if (DS_Hhygl != null && DS_Hhygl.Tables[0].Rows.Count > 0)
            {

              
                foreach (DataRow dr in DS_Hhygl.Tables[0].Rows)
                {
                    string hykh_service = dr["hykh"].ToString();
                    M_Hhygl.yydh = dr["yydh"].ToString();
                    M_Hhygl.qymc = dr["qymc"].ToString();
                    M_Hhygl.hyrx = dr["hyrx"].ToString();
                    M_Hhygl.hykh = dr["hykh"].ToString();
                    M_Hhygl.hykh_bz = dr["hykh_bz"].ToString();
                    M_Hhygl.krxm = dr["krxm"].ToString();
                    M_Hhygl.krgj = dr["krgj"].ToString();
                    M_Hhygl.krmz = dr["krmz"].ToString();
                    M_Hhygl.yxzj = dr["yxzj"].ToString();
                    M_Hhygl.zjhm = dr["zjhm"].ToString();
                    M_Hhygl.krsr = Convert.ToDateTime(dr["krsr"].ToString());
                    M_Hhygl.krxb = dr["krxb"].ToString();
                    M_Hhygl.krdh = dr["krdh"].ToString();
                    M_Hhygl.krsj = dr["krsj"].ToString();
                    M_Hhygl.krEmail = dr["krEmail"].ToString();
                    M_Hhygl.krdz = dr["krdz"].ToString();
                    M_Hhygl.krzy = dr["krzy"].ToString();
                    M_Hhygl.krdw = dr["krdw"].ToString();
                    M_Hhygl.qzrx = dr["qzrx"].ToString();
                    M_Hhygl.qzhm = dr["qzhm"].ToString();
                    M_Hhygl.zjyxq = Convert.ToDateTime(dr["zjyxq"].ToString());
                    M_Hhygl.tlyxq = Convert.ToDateTime(dr["tlyxq"].ToString());
                    M_Hhygl.tjrq = Convert.ToDateTime(dr["tjrq"].ToString());
                    M_Hhygl.lzka = dr["lzka"].ToString();
                    M_Hhygl.bz = dr["bz"].ToString();
                    M_Hhygl.djsj = Convert.ToDateTime(dr["djsj"].ToString());
                    M_Hhygl.hyjf = Convert.ToDecimal(dr["hyjf"].ToString());
                    M_Hhygl.shsc = true;
                    M_Hhygl.scsj = DateTime.Now;
                    M_Hhygl.xgsj = Convert.ToDateTime(dr["xgsj"].ToString());
                    M_Hhygl.shxg = Convert.ToBoolean(dr["shxg"].ToString());
                    M_Hhygl.shqr = true;
                    M_Hhygl.is_top = Convert.ToBoolean(dr["is_top"].ToString());
                    M_Hhygl.is_select = Convert.ToBoolean(dr["is_select"].ToString());
                    M_Hhygl.fkje = Convert.ToDecimal(dr["fkje"].ToString());
                    M_Hhygl.parent_hykh = dr["parent_hykh"].ToString();
                    M_Hhygl.hymm = dr["hymm"].ToString();


                    DataSet DS_Hhyglservice = new DataSet();
                    DS_Hhyglservice = B_Hhygl.GetList("hykh='" + hykh_service + "'");
                    if (DS_Hhyglservice != null && DS_Hhyglservice.Tables[0].Rows.Count > 0)
                    {
                        M_Hhygl.id = Convert.ToInt32(DS_Hhyglservice.Tables[0].Rows[0]["id"].ToString());
                        if (B_Hhygl.Update(M_Hhygl))
                        {
                            s = common_file.common_app.get_suc;
                        }


                    }
                    else
                    {
                        if (B_Hhygl.Add(M_Hhygl) > 0)
                        {
                            s = common_file.common_app.get_suc;
                        }

                    }
                   

                }
            }
            return s;
        }
    }
}
