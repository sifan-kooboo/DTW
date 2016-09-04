using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Hotel_app
{
    class common
    {
        public void add_ys()
        {
            if (common_file.common_roles.get_user_qx("B_zwcz_ys", common_file.common_app.user_type) == false)
            { return; }
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Sqs", " qsdate between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，本日已经做过审核了！");
            }
            else
            {
                DS_temp = B_Common.GetList("select * from Qcounter", " shys=1");
                int j_0 = 2;
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {


                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "对不起，好像有人在做审核了！请确认一下是否真的有人在做审核了！如果没有请按“是”后稍等计时对话框出现，按提醒进行操作！") == true)
                    {

                        common_file.Time_count Time_count_new = new Hotel_app.common_file.Time_count();
                        Time_count_new.StartPosition = FormStartPosition.CenterScreen;
                        Time_count_new.ShowDialog();

                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "注意！注意！准备取消审核限制了，请确认一下是否真的没有人在做审核，如果没有再继续操作！") == true)
                        {

                            if (B_Common.ExecuteSql("update Qcounter set shys=0") > 0)
                            {
                                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "注意！注意！已经取消审核限制了，请再次慎重确认一下是否真的没有人在做审核，如果没有就可开始审核！") == true)
                                {
                                    j_0 = 3;
                                }

                            }
                        }
                    }

                }
                else
                {
                    j_0 = 3;
                }
                    //判断是否有团队成员以经入住了,如果有的话,就提醒其删除其它成员,把团体转成登记,再进行夜审操作


                if(j_0==3)
                {



                    string temp = "";

                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要进行审核操作！") == true)
                    {
                        common_file.common_app.get_czsj();
                        string url_temp = common_file.common_app.service_url + "SH/S_ys_app.asmx";
                        object[] args = new object[10];
                        args[0] = common_file.common_app.yydh;
                        args[1] = common_file.common_app.qymc;
                        args[2] = common_file.common_app.czy;
                        args[3] = DateTime.Now;
                        args[4] = common_file.common_app.syzd;
                        args[5] = common_file.common_app.czy_bc;
                        args[6] = common_file.common_fjzt.sh_ds;
                        args[7] = "";
                        args[8] = common_file.common_app.xxzs_zsvalue;
                        args[9] = common_file.common_app.czy_GUID;

                        Hotel_app.Server.SH.S_ys S_ys_services = new Hotel_app.Server.SH.S_ys();
                        string   result=S_ys_services.New_ys(args[0].ToString(), args[1].ToString(), args[2].ToString(), DateTime.Parse(args[3].ToString()), args[4].ToString(), args[5].ToString(),bool.Parse(args[6].ToString()), args[7].ToString(), args[8].ToString(), args[9].ToString());

                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url_temp, "New_ys", args);
                        if (result != null && result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "审核成功！");
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "审核好像出错了！");
                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "审核没进行！ " );
                        return;
                    }
                    Cursor.Current = Cursors.Default;
                }
            }






        }



        //public bool Check(ref string noticeInfo)
        //{
        //    DataSet DS_temp = null;
        //    bool result = true;
        //    BLL.Common B_common = new Hotel_app.BLL.Common();
        //    int i = 1;
        //    DS_temp = B_common.GetList("select * from Qttyd_mainrecord", " yddj='" + common_file.common_yddj.yddj_yd + "'  and ddsj<'" + DateTime.Now.ToShortDateString() + "'");
        //    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
        //    {

        //        for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
        //        {
        //            DataSet DS_temp_0 = B_common.GetList("select * from View_Qskzd", "ddbh='" + DS_temp.Tables[0].Rows[i_0]["ddbh"].ToString() + "' and yydh='" + DS_temp.Tables[0].Rows[i_0]["yydh"].ToString() + "' and yddj='" + common_file.common_yddj.yddj_dj + "'");
        //            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
        //            {
        //                for (int j = 0; j < DS_temp_0.Tables[0].Rows.Count; j++)
        //                {
        //                    noticeInfo += DS_temp.Tables[0].Rows[i_0]["sktt"] + ":" + DS_temp.Tables[0].Rows[i_0]["krxm"].ToString() + "主单当前仍然处于预定状态,但是其中,客人姓名为:" + DS_temp_0.Tables[0].Rows[j]["krxm"].ToString() + "房间编号为:" + DS_temp_0.Tables[0].Rows[j]["fjbh"].ToString() + "的成员以经入住,请手动先删除该团下没有入住的成员,然后将团体主单转成登记,等团体其它成员有入住时,再通过散客登记,对后入住的成员进行入团操作!\t";

        //                }
        //            }
        //            DS_temp_0.Clear();
        //            DS_temp_0.Dispose();
        //        }
        //    }
        //    if (noticeInfo.Length > 0)
        //    {
        //        return false;
        //    }
        //    return result;
        //}
    }
}
