using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.BBfx
{
    //按客人来源分类显示在店客人明细情况

    public class B_zdkr_mxfx
    {
        //public string Get_zdkr_mxData(string qymc, string yydh, string cssj, string jssj, string czy_temp, string czsj, string xxzs)
        public string Get_zdkr_mxData(string qymc, string yydh,string czy_temp, string czsj, string xxzs,string SearchType)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_temp_0 = null;
            DataSet ds_temp_1 = null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            B_common.ExecuteSql(" delete from  BB_zdkr_mx_temp  where id>=0  and  yydh='" + yydh + "' and czy_temp='" + czy_temp + "'");
            
            sb = new System.Text.StringBuilder();
            sb.Append("  insert into  BB_zdkr_mx_temp(qymc,yydh,lsbh,krxm,krly,xydw,xsy,ddsj,lksj,czy,sktt,fjrb,fjbh,lzrs,lzfs,dqff,ddbh,zjhm,bz,czy_temp,main_sec,krxb)");
            sb.Append(" select  qymc,yydh,lsbh,krxm,krly,xydw,xsy,ddsj,lksj,czy,sktt,fjrb,fjbh,1,1,xfje,ddbh,zjhm,bz,'" + czy_temp + "',main_sec,krxb  from  VIEW_Qskzd  ");
            if (SearchType!="krxb")
            {
                sb.Append(" where  id>=0  and yydh='" + yydh + "'   and  yddj='"+common_file.common_yddj.yddj_dj+"'  and main_sec='" + common_file.common_app.main_sec_main + "' ");
            }
            else
            {
                sb.Append(" where  id>=0  and yydh='" + yydh + "'    and  yddj='" + common_file.common_yddj.yddj_dj + "'   ");
            }
            B_common.ExecuteSql(sb.ToString());

            if (SearchType != "krxb")
            {
                //更新人数
                //ds_temp_0 = B_common.GetList(" select * from BB_zdkr_mx_temp ", " id>=0  and yydh='" + yydh + "'  and  ddsj>='" + cssj + "'  and  lksj<='" + jssj + "'  and main_sec='" + common_file.common_app.main_sec_main + "' ");
                ds_temp_0 = B_common.GetList(" select * from BB_zdkr_mx_temp ", " id>=0  and yydh='" + yydh + "'  and main_sec='" + common_file.common_app.main_sec_main + "'  and  czy_temp='" + czy_temp + "' ");
                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_temp_0.Tables[0].Rows.Count; i++)
                    {
                        string fjbh_temp = ds_temp_0.Tables[0].Rows[i]["fjbh"].ToString();
                        string lsbh_temp = ds_temp_0.Tables[0].Rows[i]["lsbh"].ToString();
                        string ddbh_temp = ds_temp_0.Tables[0].Rows[i]["ddbh"].ToString();
                        float tlkr_sl = 0;
                        //ds_temp_1 = B_common.GetList("  select count(lsbh)   as  tlkr_sl   from  View_Qskzd ", " id>=0  and yydh='" + yydh + "'  and  ddsj>='" + cssj + "'  and  lksj<='" + jssj + "'  and main_sec='" + common_file.common_app.main_sec_sec + "'  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "' and ddbh='" + ddbh_temp + "'");
                        ds_temp_1 = B_common.GetList("  select count(lsbh)   as  tlkr_sl   from  View_Qskzd ", " id>=0  and yydh='" + yydh + "'    and main_sec='" + common_file.common_app.main_sec_sec + "'  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "' and ddbh='" + ddbh_temp + "'");

                        if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
                        {
                            tlkr_sl = float.Parse(ds_temp_1.Tables[0].Rows[0]["tlkr_sl"].ToString());
                        }
                        //B_common.ExecuteSql("  update    BB_zdkr_mx_temp  set  lzrs=lzrs+" + tlkr_sl + "  where  id>=0  and yydh='" + yydh + "'  and  ddsj>='" + cssj + "'  and  lksj<='" + jssj + "'  and main_sec='" + common_file.common_app.main_sec_main + "'  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "' and ddbh='" + ddbh_temp + "'  and  czy_temp='" + czy_temp + "'");
                        B_common.ExecuteSql("  update    BB_zdkr_mx_temp  set  lzrs=lzrs+" + tlkr_sl + "  where  id>=0  and yydh='" + yydh + "'  and main_sec='" + common_file.common_app.main_sec_main + "'  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "' and ddbh='" + ddbh_temp + "'  and  czy_temp='" + czy_temp + "'");
                    }
                    ds_temp_0.Dispose();
                    ds_temp_1.Dispose();
                }
            }
            s = common_file.common_app.get_suc;
            return s;
        }
    }
}
