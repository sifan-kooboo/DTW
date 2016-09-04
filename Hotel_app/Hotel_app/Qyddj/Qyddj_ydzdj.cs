using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public class Qyddj_ydzdj
    {
        /// <summary>
        /// 两个值一个sk代表散客、长住、钟点； tt代表团体、会议
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sktt"></param>两个值一个sk代表散客、长住、钟点； tt代表团体、会议
        /// <param name="ddbh"></param>如果是团体要输ddbh，如果不是放空
        ///  <param name="fjbh"></param>如果是房间要输fjbh，如果不是放空
        public bool ydzdj(string lsbh, string fjbh, string ddbh, string sktt)
        {
            bool get_result = false;
            string url = common_file.common_app.service_url;
            url += "Qyddj/Qyddj_app.asmx";
            bool shlf = false;

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (sktt == "sk")
            {
                if (fjbh != "")
                {

                    //这一部分修改于：2012-11-1(门店提出这种提示容易造成转入住错误，故取消这个提示"

                    //string s_0 = "select * from Qskyd_mainrecord where yddj='"+common_file.common_yddj.yddj_yd+"' and lsbh in(select lsbh from Flfsz where lfbh=(select lfbh from Flfsz where lsbh='"+lsbh+"'))";
                    //DataSet ds_temp = B_Common.GetList("select * from Flfsz", "lfbh in(select lfbh from Flfsz where lsbh='" + lsbh + "')");
                    DataSet ds_temp = B_Common.GetList("select id,lsbh from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_yd + "' and sktt<>'" + common_file.common_sktt.sktt_tt + "'  and sktt<>'" + common_file.common_sktt.sktt_hy + "'  and lsbh in(select lsbh from Flfsz where lfbh=(select lfbh from Flfsz where lsbh='" + lsbh + "'))");
                    //if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 1)
                    //{
                     //   if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "有查到该房间有与其他房间联房，是否要一起转成入住呢") == true)
                      //  {
                    //        shlf = true;
                    //    }
                   // }
                    if (common_file.common_yddj.judge_lf_sk(lsbh, fjbh,shlf) == true)
                    {
                        object[] args = new object[10];
                        args[0] = common_file.common_app.yydh;
                        args[1] = common_file.common_app.qymc;
                        args[2] = lsbh;
                        args[3] = sktt;
                        args[4] = ddbh;
                        args[5] = shlf;
                        args[6] = common_file.common_app.czy;
                        args[7] = "预订转登记-散客";
                        args[8] = DateTime.Now;
                        args[9] = common_file.common_app.xxzs;
                        Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1();
                        string result = Qyddj_add_edit_delete_1_services.ydzdj_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(),bool.Parse(args[5].ToString()), args[6].ToString(), args[7].ToString(), DateTime.Parse(args[8].ToString()), args[9].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "ydzdj_app", args);
                        if (result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                            get_result = true;
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                        }

                    }
                    ds_temp.Dispose();
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，没有安排房间，无需转入住！");
                
                }


            }
            else
                if (sktt == "tt")
                {
                    DataSet ds_temp = B_Common.GetList("select * from Qskyd_mainrecord", "ddbh='" + ddbh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        if (common_file.common_yddj.judge_ydzdj_tt(ddbh) == true)
                        {
                            object[] args = new object[10];
                            args[0] = common_file.common_app.yydh;
                            args[1] = common_file.common_app.qymc;
                            args[2] = lsbh;
                            args[3] = sktt;
                            args[4] = ddbh;
                            args[5] = shlf;
                            args[6] = common_file.common_app.czy;
                            args[7] = "预订转登记-团体";
                            args[8] = DateTime.Now;
                            args[9] = common_file.common_app.xxzs;

                            Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_Services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1();
                            string result = Qyddj_add_edit_delete_1_Services.ydzdj_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(),bool.Parse(args[5].ToString()), args[6].ToString(), args[7].ToString(),DateTime.Parse(args[8].ToString()), args[9].ToString());
                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "ydzdj_app", args);
                            if (result== common_file.common_app.get_suc)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                                get_result = true;
                            }
                            else
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                            }
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,当前主单不能转入登记,请根据前面弹出框的提示先处理不能转登记的房间再执行团体主单转登记的操作！");
                        }
                    }

                }
            return get_result;
        }
    }
}
