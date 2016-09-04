using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public static class common_yddj
    {
        public static string yddj_yd = "预订";
        public static string yddj_qryd = "确认预订";
        public static string yddj_dj = "登记";
        public static string yddj_ydzdj = "预订转登记";
        public static string yddj_qx = "取消";
        public static string yddj_wd = "未到";
        //用于识别网上预定类型
        public static string yddj_wlyd = "网上预定中心";




        /// <summary>
        /// 判断要转入住的房间是否有被占用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fjbh"></param>
        /// <returns></returns>
        public static bool judge_ydzdj_sk(string fjbh, string lsbh)
        {
            bool result_0 = true;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Qskyd_mainrecord", "lsbh='" + lsbh + "' and yddj='" + common_file.common_yddj.yddj_yd + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {


                if (fjbh != "")
                {
                    DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_fjzt.zzf || DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_fjzt.wxf || DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_fjzt.qtf)
                        {
                            common_app.Message_box_show(common_app.message_title, "对不起，" + fjbh + "处于" + DS_temp.Tables[0].Rows[0]["zyzt"].ToString() + "状态，不能转为入住房！如确实要转入住，请先清理房间！");
                            result_0 = false;
                        }
                        else
                            if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_fjzt.gjf || DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_fjzt.zf)
                            {
                                if (DS_temp.Tables[0].Rows[0]["zybz"].ToString() == common_fjzt.lszy)
                                {
                                    common_app.Message_box_show(common_app.message_title, "对不起，" + fjbh + "处于" + DS_temp.Tables[0].Rows[0]["zybz"].ToString() + "状态，不能转为入住房！如确实要转入住，请先清理房间！");
                                    result_0 = false;
                                }

                            }
                    }
                }
                if (result_0 == true)
                {
                    DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "lsbh='" + lsbh + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp.Tables[0].Rows.Count > 1)
                        {
                            result_0 = false;
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，" + DS_temp.Tables[0].Rows[0]["krxm"].ToString() + "有不只一条的初始房类记录，请把多余的预订记录取消掉！");
                        }

                    }

                }
            }
            DS_temp.Dispose();
            return result_0;
        }

        /// <summary>
        /// 判断要转入住房间是否被占用，包括联房
        /// </summary>
        /// <param name="lsbh"></param>
        /// <param name="fjbh"></param>
        /// <returns></returns>
        public static bool judge_lf_sk(string lsbh, string fjbh,bool shlf)
        {
            bool result_0 = true;
            string lfbh = "";
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            DataSet DS_temp = B_Common.GetList("select lfbh from Flfsz", "lsbh='" + lsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                lfbh = DS_temp.Tables[0].Rows[0]["lfbh"].ToString();
                if (lfbh != "")
                {
                    if (shlf == true)
                    {
                        DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "lsbh in (select lsbh from Flfsz where lfbh='" + lfbh + "')");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            for (int i_temp_1 = 0; i_temp_1 < DS_temp.Tables[0].Rows.Count; i_temp_1++)
                            {
                                if (DS_temp.Tables[0].Rows[i_temp_1]["fjbh"].ToString() != "")
                                {
                                    result_0 = judge_ydzdj_sk(DS_temp.Tables[0].Rows[i_temp_1]["fjbh"].ToString(), DS_temp.Tables[0].Rows[i_temp_1]["lsbh"].ToString());
                                    if (result_0 == false)
                                    { break; }
                                }
                            }
                        }
                    }
                    else
                    { lfbh = ""; }
                }
            }
            if (lfbh == "")
            {
                result_0=judge_ydzdj_sk(fjbh, lsbh);
            }
            DS_temp.Dispose();
            return result_0;
        }


        /// <summary>
        /// 团队排房改房间的判断是否有被占用
        /// </summary>
        /// <param name="ddbh"></param>
        /// <returns></returns>
        public static bool judge_ydzdj_tt(string ddbh)
        {
            bool result_0 = true;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from View_Qskzd", "ddbh='" + ddbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_temp_1 = 0; i_temp_1 < DS_temp.Tables[0].Rows.Count; i_temp_1++)
                {
                    result_0 = judge_ydzdj_sk(DS_temp.Tables[0].Rows[i_temp_1]["fjbh"].ToString(), DS_temp.Tables[0].Rows[i_temp_1]["lsbh"].ToString());
                    if (result_0 == false)
                    { break; }
                }

            }
            DS_temp.Dispose();
            return result_0;
        }


        //用于网络预定（更新于0702)
        public static void GetData_wlyd(DataSet ds)
        {
             
        }



    }
}
