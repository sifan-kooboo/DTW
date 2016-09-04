using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public class com_ft
    {

        public void New_fast_skyd(string fjrb, string fjbh, DateTime czsj)
        {
            common_file.common_app.get_czsj();
            string url = common_file.common_app.service_url;
            string sql_0 = "";
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_temp = B_common.GetList("select * from Ffjzt", " yydh='" + common_file.common_app.yydh + "' and fjbh='" + fjbh + "'");
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {

                if (ds_temp.Tables[0].Rows[0]["zyzt"].ToString() != common_file.common_fjzt.gjf && ds_temp.Tables[0].Rows[0]["zyzt"].ToString() != common_file.common_fjzt.zf)
                {
                    common_file.common_app.get_czsj();
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，非干净房或者脏房不能快速入住！");
                }
                else
                {
                    common_file.common_app.get_czsj();
                    if(common_file.common_app.message_box_show_select(common_file.common_app.message_title,"您是否确认要快速登记？"))
                    {                    
                        common_file.common_app.get_czsj();
                        string lsbh_new = common_file.common_ddbh.ddbh("skdj", "skdjdate", "skdjcounter", 6);
                        string ddbh_new = common_file.common_ddbh.ddbh("skdj", "skdjdate", "skdjcounter", 6);
                        Hotel_app.Server.Qyddj.Qyddj_add_edit_delete Qskdj_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();

                        string result = Qskdj_add_edit_delete_services.Qskdj_add_edit_delete( "0",common_file.common_app.yydh,common_file.common_app.qymc,
                        lsbh_new,ddbh_new,"","",lsbh_new,lsbh_new,common_file.common_app.krgj_zg,"",common_file.common_app.yxzj_sfz,"","",
                         "1800-01-01","","","","","","","", "", "", "", "1800-01-01", "1800-01-01","1800-01-01","","","","",common_file.common_app.czy,"","",
                        common_file.common_yddj.yddj_dj,"","0",czsj.ToString(),"0",czsj.AddDays(1).ToString(),"",common_file.common_app.czy,
                        DateTime.Now.ToString(),"快速登记",common_file.common_sktt.sktt_sk,common_file.common_yddj.yddj_dj,common_file.common_app.main_sec_main,
                        common_file.common_yddj.yddj_dj,common_file.common_app.syzd,"","",common_file.common_app.get_add,
                        common_file.common_app.xxzs,"旅游","");

                        if (result != null && result == common_file.common_app.get_suc)
                        {

                            string sjfjjg_0 = common_file.common_get_fjjg.get_fjjg(fjrb, "", "", czsj, czsj.AddDays(1), "", "");

                            sql_0 = "";
                            sql_0 = "  update  Qskyd_fjrb set sjfjjg='" + sjfjjg_0 + "',fjjg='" + sjfjjg_0 + "',fjbh='" + fjbh + "',fjrb='" + fjrb + "'  where  lsbh='" + lsbh_new + "'  and  yydh='" + common_file.common_app.yydh + "'";
                            B_common.ExecuteSql(sql_0);
                            sql_0 = "";
                            sql_0 = "update Ffjzt set zyzt='" + common_file.common_fjzt.zzf + "',ddsj='" + czsj.ToString() + "',lksj='" + czsj.AddDays(1).ToString() + "',czsj='" + DateTime.Now.ToString() + "',sktt='" + common_file.common_sktt.sktt_sk+ "',lsbh='"+lsbh_new+"'      where fjbh='" + fjbh + "' and (zyzt='" + common_file.common_fjzt.gjf + "'  or  zyzt='"+common_file.common_fjzt.zf+"')";
                            if (B_common.ExecuteSql(sql_0) > 0)
                            {

                            }
                            else
                            {
                                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "当前为脏房,您是否确认仍然要快速登记？"))
                                {
                                    sql_0 = "update Ffjzt set zyzt='" + common_file.common_fjzt.zzf + "',ddsj='" + czsj.ToString() + "',lksj='" + czsj.AddDays(1).ToString() + "',zybz='" + common_file.common_fjzt.yjf + "',czsj='" + DateTime.Now.ToString() + "',sktt='" + common_file.common_sktt.sktt_sk + "' where fjbh='" + fjbh + "' and zyzt='" + common_file.common_fjzt.zf + "'";
                                    B_common.ExecuteSql(sql_0);
                                }
                            }
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "快速入住成功！");
 
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "快速入住失败,请与系统管理员联系！");

                        }
                    }
                }
            }
        }


    }
}
