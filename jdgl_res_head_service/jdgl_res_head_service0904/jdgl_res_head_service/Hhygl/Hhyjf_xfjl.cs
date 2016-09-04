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
    public class Hhyjf_xfjl
    {
        public string Hhyjfxfjl_UploadDS(DataSet DS_Hhyjfxfjl)  //上传积分消费记录
        {
            //id,qymc,yydh,lsbh_df,hykh,hykh_bz,krxm,id_app,lsbh,fjrb,fjbh,xfsj,hyjf,bz,xfdr,xfrb,xfxm,sjxmje,shsc,scsj,is_top,is_select,shqx
            string s = common_file.common_app.get_failure;
            BLL.Hhyjf_xfjl B_Hhyjf_xfjl = new BLL.Hhyjf_xfjl();
            Model.Hhyjf_xfjl M_Hhyjf_xfjl = new Model.Hhyjf_xfjl();
            if (DS_Hhyjfxfjl != null && DS_Hhyjfxfjl.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS_Hhyjfxfjl.Tables[0].Rows)
                {
                    string hykh_service = dr["lsbh_df"].ToString();

                    M_Hhyjf_xfjl.qymc = dr["qymc"].ToString();
                    M_Hhyjf_xfjl.yydh = dr["yydh"].ToString();
                    M_Hhyjf_xfjl.lsbh_df = dr["lsbh_df"].ToString();
                    M_Hhyjf_xfjl.hykh = dr["hykh"].ToString();
                    M_Hhyjf_xfjl.hykh_bz = dr["hykh_bz"].ToString();
                    M_Hhyjf_xfjl.krxm = dr["krxm"].ToString();
                    M_Hhyjf_xfjl.id_app = dr["id_app"].ToString();
                    M_Hhyjf_xfjl.lsbh = dr["lsbh"].ToString();
                    M_Hhyjf_xfjl.fjrb = dr["fjrb"].ToString();
                    M_Hhyjf_xfjl.fjbh = dr["fjbh"].ToString();
                    M_Hhyjf_xfjl.xfsj = Convert.ToDateTime(dr["xfsj"].ToString());
                    M_Hhyjf_xfjl.hyjf = Convert.ToDecimal(dr["hyjf"].ToString());
                    M_Hhyjf_xfjl.bz = dr["bz"].ToString();
                    M_Hhyjf_xfjl.xfdr = dr["xfdr"].ToString();
                    M_Hhyjf_xfjl.xfrb = dr["xfrb"].ToString();
                    M_Hhyjf_xfjl.xfxm = dr["xfxm"].ToString();
                    M_Hhyjf_xfjl.sjxfje = Convert.ToDecimal(dr["sjxfje"].ToString());
                    M_Hhyjf_xfjl.shsc = true;
                    M_Hhyjf_xfjl.scsj = DateTime.Now;
                    M_Hhyjf_xfjl.shqx = Convert.ToBoolean(dr["shqx"].ToString());
                    M_Hhyjf_xfjl.xfrq = Convert.ToDateTime(dr["xfrq"].ToString());
                    M_Hhyjf_xfjl.parent_hykh = dr["parent_hykh"].ToString();

                    DataSet DS_Hhyglservice = new DataSet();
                    DS_Hhyglservice = B_Hhyjf_xfjl.GetList("lsbh_df='" + hykh_service + "'");
                    if (DS_Hhyglservice != null && DS_Hhyglservice.Tables[0].Rows.Count > 0)
                    {
                        int strid = Convert.ToInt32(DS_Hhyglservice.Tables[0].Rows[0]["id"].ToString());
                        if (B_Hhyjf_xfjl.Delete(strid))
                        {
                            s = common_file.common_app.get_suc;
                        }


                    }
                    
                        B_Hhyjf_xfjl.Add(M_Hhyjf_xfjl);
                        s = common_file.common_app.get_suc;
                 

                }
            }
            return s;
        }


        //会员消费记录信息下载，供特定门店下载返回dataset
        public DataSet DSHhyjfxfjl_download(string yydh, out  int rows, out string csdatatime, out string jsdatatime)
        {
            BLL.Hhyjf_xfjl B_Hhyjf_xfjl = new BLL.Hhyjf_xfjl();
            Model.Hhyjf_xfjl M_Hhyjf_xfjl = new Model.Hhyjf_xfjl();
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
            DataSet DS_Hhyjf_xfjl = new DataSet();
            rows = 0;
            jsdatatime = jstime;
            csdatatime = cstime.ToString();
    
            DS_Hhyjf_xfjl = B_Hhyjf_xfjl.GetList("yydh<>'" + yydh + "' and scsj>='" + cstime + "' and scsj<'" + jstime + "'");

            if (DS_Hhyjf_xfjl != null)
            {
                rows = DS_Hhyjf_xfjl.Tables[0].Rows.Count;
                jsdatatime = jstime;
                csdatatime = cstime.ToString();
                //status = true;
                //msg = "查询成功";

            }

            return DS_Hhyjf_xfjl;
        }



        //供门店下载积分消费记录
        public string Hhyjfxfjl_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;
            rows = 0;
            //status = false;
            DS_download = null;
            DataSet DS_Hhyjf_xfjl;
            //msg = "没有查到要下载的数据信息或者远程服务器出错,webservice";
            jsdatatime = "1800-01-01";   //结束时间
            csdatetime = "1800-01-01";   //初始时间
            DS_Hhyjf_xfjl = DSHhyjfxfjl_download(yydh, out rows, out csdatetime, out jsdatatime);
            if (DS_Hhyjf_xfjl != null && rows > 0)
            {
                DS_download = DS_Hhyjf_xfjl;
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }
    }
}
