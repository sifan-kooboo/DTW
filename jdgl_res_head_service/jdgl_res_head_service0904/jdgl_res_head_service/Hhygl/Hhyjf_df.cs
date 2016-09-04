using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace jdgl_res_head_service.Hhygl
{
    public class Hhyjf_df
    {
        public string Hhyjfdf_UploadDS(DataSet DS_Hhyjfdf)  //上传积分兑换
        {
            //id,yydh,qymc,lsbh_df,hykh,hykh_bz,krxm,dfjf,dfxm,dfsl,xfsj,shsc,scsj,is_top,is_select,shqx
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_df B_Hhyjf_df = new BLL.Hhyjf_df();
            Model.Hhyjf_df M_Hhyjf_df= new Model.Hhyjf_df();
            if (DS_Hhyjfdf != null && DS_Hhyjfdf.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS_Hhyjfdf.Tables[0].Rows)
                {
                    string hykh_service = dr["lsbh_df"].ToString();


                    M_Hhyjf_df.yydh = dr["yydh"].ToString();
                    M_Hhyjf_df.lsbh_df = dr["lsbh_df"].ToString();
                    M_Hhyjf_df.qymc = dr["qymc"].ToString();
                    M_Hhyjf_df.hykh = dr["hykh"].ToString();
                    M_Hhyjf_df.hykh_bz = dr["hykh_bz"].ToString();
                    M_Hhyjf_df.krxm = dr["krxm"].ToString();
                    M_Hhyjf_df.dfjf = Convert.ToDecimal(dr["dfjf"].ToString());
                    M_Hhyjf_df.dfxm = dr["dfxm"].ToString();
                    M_Hhyjf_df.dfsl = Convert.ToDecimal(dr["dfsl"].ToString());
                    M_Hhyjf_df.xfsj = Convert.ToDateTime(dr["xfsj"].ToString());
                    M_Hhyjf_df.shsc = true;
                    M_Hhyjf_df.scsj = DateTime.Now;
                    M_Hhyjf_df.shqx = Convert.ToBoolean(dr["shqx"].ToString());
                    M_Hhyjf_df.xfrq = Convert.ToDateTime(dr["xfrq"].ToString());

                    DataSet DS_Hhyglservice = new DataSet();
                    DS_Hhyglservice = B_Hhyjf_df.GetList("lsbh_df='" + hykh_service + "'");
                    //根据Lsbh_df查询出有没有相同的记录，如果有先删除在加。
                    if (DS_Hhyglservice != null && DS_Hhyglservice.Tables[0].Rows.Count > 0)
                    {
                        int strid = Convert.ToInt32(DS_Hhyglservice.Tables[0].Rows[0]["id"].ToString());
                        if (B_Hhyjf_df.Delete(strid))
                        {
                            s = common_file.common_app.get_suc;
                        }


                    }

                    B_Hhyjf_df.Add(M_Hhyjf_df);
                    s = common_file.common_app.get_suc;

                }
            }
            return s;
        }

        //会员兑换信息下载，供特定门店下载返回dataset
        public DataSet DSHhyjfdf_download(string yydh, out  int rows, out string csdatatime, out string jsdatatime)
        {
            BLL.Hhyjf_df B_Hhyjf_df = new BLL.Hhyjf_df();
            Model.Hhyjf_df M_Hhyjf_df = new Model.Hhyjf_df();
            Model.Hhy_sc_xz_sj M_Hhyscsj = new Model.Hhy_sc_xz_sj();
            BLL.Hhy_sc_xz_sj B_Hhyscsj = new BLL.Hhy_sc_xz_sj();

            //查询出上次上传时间
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            if (yydh != "" && yydh != null)
            {
                M_Hhyscsj = B_Hhyscsj.GetModelList("yydh='" + yydh + "'")[0];
                cstime = M_Hhyscsj.hy_scsj;

            }
            string jstime = DateTime.Now.ToString();
            DataSet DS_Hhyjf_df = new DataSet();
            rows = 0;
            jsdatatime = jstime;
            csdatatime = cstime.ToString();
            //status = false;
            //msg = "没有查到要下载的数据信息或者远程服务器出错";
            DS_Hhyjf_df = B_Hhyjf_df.GetList("yydh<>'" + yydh + "' and scsj>='" + cstime + "' and scsj<'" + jstime + "'");

            if (DS_Hhyjf_df != null)
            {
                rows = DS_Hhyjf_df.Tables[0].Rows.Count;
                jsdatatime = jstime;
                csdatatime = cstime.ToString();
                //status = true;
                //msg = "查询成功";

            }

            return DS_Hhyjf_df;
        }

        //供门店下载网上兑换记录
        public string Hhyjfdf_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;
            rows = 0;
            //status = false;
            DS_download = null;
            DataSet DS_Hhyjf_df;
            //msg = "没有查到要下载的数据信息或者远程服务器出错,webservice";
            jsdatatime = "1800-01-01";   //结束时间
            csdatetime = "1800-01-01";   //初始时间
            DS_Hhyjf_df = DSHhyjfdf_download(yydh, out rows, out csdatetime, out jsdatatime);
            //if (DS_Hhyjf_df != null && rows > 0)
            //{
                DS_download = DS_Hhyjf_df;
                ss = common_file.common_app.get_suc;
            //}
            return ss;
        }
    }
}
