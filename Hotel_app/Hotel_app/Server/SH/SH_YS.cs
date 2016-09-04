using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.SH
{
    public class SH_YS
    {
        public void delete_all_trash(string yydh,string qymc,string czy,DateTime czsj,string xxzs)
        {

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_ss = "";

            //sql_ss = "backup database Hotel_data to  disk='D:\\1.bak'";
            //B_Common.ExecuteSql(sql_ss);


            string sql_s = "delete from BBfx_jzmx";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BBfx_jzmx_bak";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from Ssyxfmx_bb_ls";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BQ_syxfmx_ls";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BS_jzmx_ls";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BS_jzmx_bak_ls";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from Qskyd_fjrb_temp where fjbh is null";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from Qskyd_mainrecord_temp where krxm is null";
            B_Common.ExecuteSql(sql_s);

            //清除一百天后的操作记录
            sql_s = "delete from YHczjl where czsj<'"+czsj.AddDays(-100).ToShortDateString()+"'";
            B_Common.ExecuteSql(sql_s);
            DataSet DS_temp = B_Common.GetList("select * from Qskyd_mainrecord", " yddj='" + common_file.common_yddj.yddj_yd + "' and main_sec='" + common_file.common_app.main_sec_main + "' and ddsj<'" + DateTime.Now.ToShortDateString() + "' and (sktt='" + common_file.common_sktt.sktt_sk + "' or sktt='" + common_file.common_sktt.sktt_cz + "' or sktt='" + common_file.common_sktt.sktt_zd + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                string[] id_arg = new string[DS_temp.Tables[0].Rows.Count];
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    id_arg[i_0] = DS_temp.Tables[0].Rows[i_0]["id"].ToString();
                }

                Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Qyddj.Qyddj_add_edit_delete();
                 Qyddj_add_edit_delete_new.delete_sk_multi(id_arg, "sc", common_file.common_yddj.yddj_wd, "预订未到被取消", "", czy, czsj.ToString(), xxzs);
            }

            DS_temp = B_Common.GetList("select * from Qttyd_mainrecord", " yddj='" + common_file.common_yddj.yddj_yd + "'  and ddsj<'" + DateTime.Now.ToShortDateString() + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_mainrecord", "ddbh='" + DS_temp.Tables[0].Rows[i_0]["ddbh"].ToString() + "' and yydh='" + DS_temp.Tables[0].Rows[i_0]["yydh"].ToString() + "' and yddj='" + common_file.common_yddj.yddj_dj + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    { }
                    else
                    {
                        Qyddj.Qttyd_add_edit_delete Qttyd_add_edit_delete_new = new Qyddj.Qttyd_add_edit_delete();
                        Qttyd_add_edit_delete_new.Qttyd_add_edit_delete_app(DS_temp.Tables[0].Rows[i_0]["id"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "预订未到被取消", "", "", "", czy, common_file.common_yddj.yddj_wd, czsj.ToString(), "", "", common_file.common_app.get_delete, xxzs, "");
                    }
                    DS_temp_0.Clear();
                    DS_temp_0.Dispose();
                }
            }

            //离开时间续住
            DateTime dt_temp = czsj;
            DS_temp = B_Common.GetList("select * from Qttyd_mainrecord", " yddj='" + common_file.common_yddj.yddj_dj + "' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
               
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if(DS_temp.Tables[0].Rows[i_0]["lksj"].ToString()!="")
                    {
                        if (DateTime.Parse(DateTime.Parse(DS_temp.Tables[0].Rows[i_0]["lksj"].ToString()).ToShortDateString()) < DateTime.Parse(czsj.ToShortDateString()))
                        {
                            dt_temp = DateTime.Parse(czsj.ToShortDateString() + " " + DateTime.Parse(DS_temp.Tables[0].Rows[i_0]["lksj"].ToString()).ToShortTimeString());
                            //dt_temp = dt_temp.AddDays(1);
                            B_Common.ExecuteSql("update Qttyd_mainrecord set lksj='" + dt_temp.ToString() + "' where lsbh='" + DS_temp.Tables[0].Rows[i_0]["lsbh"].ToString() + "'");
                           
                        }
                    
                    }


                }
            }






            DS_temp = B_Common.GetList("select * from View_Qskzd", " yddj='" + common_file.common_yddj.yddj_dj + "' and main_sec='"+common_file.common_app.main_sec_main+"' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                dt_temp = czsj;
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["lksj"].ToString() != "")
                    {
                        if (DateTime.Parse(DateTime.Parse(DS_temp.Tables[0].Rows[i_0]["lksj"].ToString()).ToShortDateString()) < DateTime.Parse(czsj.ToShortDateString()))
                        {
                            dt_temp =DateTime.Parse(czsj.ToShortDateString()+" " +DateTime.Parse(DS_temp.Tables[0].Rows[i_0]["lksj"].ToString()).ToShortTimeString());
                            //dt_temp = dt_temp.AddDays(1);
                            B_Common.ExecuteSql("update Qskyd_mainrecord set lksj='" + dt_temp.ToString() + "' where lsbh='" + DS_temp.Tables[0].Rows[i_0]["lsbh"].ToString() + "'");
                            B_Common.ExecuteSql("update Ffjzt set lksj='" + dt_temp.ToString() + "',czsj='"+DateTime.Now.ToString()+"' where lsbh='" + DS_temp.Tables[0].Rows[i_0]["lsbh"].ToString() + "'");
                        }

                    }


                }
            }








            DS_temp.Clear();
            DS_temp.Dispose();

            sql_s = "delete from Q_sfz_temp where czsj<'"+DateTime.Now.ToShortDateString()+"'";
            B_Common.ExecuteSql(sql_s);

            //sql_s = "DUMP TRANSACTION hotel_data WITH NO_LOG";
            //B_Common.ExecuteSql(sql_s);


        }
    }
}
