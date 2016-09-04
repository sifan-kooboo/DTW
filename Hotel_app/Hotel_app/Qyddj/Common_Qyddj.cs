using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Hotel_app.Qyddj
{
    public static class Common_Qyddj
    {
        //public static StringBuilder szName = new StringBuilder();
        //public static StringBuilder szSex = new StringBuilder();
        //public static StringBuilder szNation = new StringBuilder();

        //public static StringBuilder szBirthday = new StringBuilder();

        //public static StringBuilder szAddress = new StringBuilder();
        //public static StringBuilder szID = new StringBuilder();
        //public static StringBuilder szDepartment = new StringBuilder();
        //public static StringBuilder szStartDate = new StringBuilder();
        //public static StringBuilder szEndDate = new StringBuilder();
        //2935219wSf
        /// <summary>
        /// 弹出提醒
        /// </summary>
        /// <param name="lsbh"></param>

        public static string s = "98";

        public static void htk(string lsbh)//回头客
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,krrx from Qskyd_mainrecord", "(krrx='" + common_file.common_app.krrx_htk + "') and lsbh='"+lsbh+"'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qskdj_new != null)
                {
                    if (common_file.common_form.Qskdj_new.M_Qskyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qskdj_new.tB_krrx.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "注意，该房间有第二次入住的客人！");
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        public static void hmd(string lsbh)//黑名单
        {

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,krrx from Qskyd_mainrecord", "(krrx='" + common_file.common_app.krrx_hmd + "') and lsbh='" + lsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qskdj_new != null)
                {
                    if (common_file.common_form.Qskdj_new.M_Qskyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qskdj_new.tB_krrx.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "注意，该房间有黑名单客人入住！");
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        public static void tsyq(string lsbh)//特殊要求
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,tsyq from Qskyd_mainrecord", "(tsyq<>'') and lsbh='" + lsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qskdj_new != null)
                {
                    if (common_file.common_form.Qskdj_new.M_Qskyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qskdj_new.tB_krxm.ForeColor = Color.Red;
                        common_file.common_form.Qskdj_new.tB_tsyq.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, DS_temp.Tables[0].Rows[0]["tsyq"].ToString());

            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        public static void tt_tsyq(string lsbh)//特殊要求
        {

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,tsyq from Qttyd_mainrecord", "(tsyq<>'') and lsbh='" + lsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qttdj_new != null)
                {
                    if (common_file.common_form.Qttdj_new.M_Qttyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qttdj_new.tB_krxm.ForeColor = Color.Red;
                        common_file.common_form.Qttdj_new.tB_tsyq.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, DS_temp.Tables[0].Rows[0]["tsyq"].ToString());
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        public static void qtyq(string lsbh)//其他要求
        {

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,qtyq from Qskyd_mainrecord", "(qtyq<>'') and lsbh='" + lsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qskdj_new != null)
                {
                    if (common_file.common_form.Qskdj_new.M_Qskyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qskdj_new.tB_qtyq.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, DS_temp.Tables[0].Rows[0]["qtyq"].ToString());
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        public static void tt_qtyq(string lsbh)//其他要求
        {

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,qtyq from Qttyd_mainrecord", "(qtyq<>'') and lsbh='" + lsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qttdj_new != null)
                {
                    if (common_file.common_form.Qttdj_new.M_Qttyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qttdj_new.tB_qtyq.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, DS_temp.Tables[0].Rows[0]["qtyq"].ToString());
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        public static void fjbm(string lsbh)//房价保密
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,fjbm from Qskyd_fjrb", "(fjbm='" + common_file.common_app.fjbm_bm + "') and lsbh='" + lsbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qskdj_new != null)
                {
                    if (common_file.common_form.Qskdj_new.M_Qskyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qskdj_new.tB_krxm.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "客人要求房价保密！");
            }
            DS_temp.Clear();
            DS_temp.Dispose();

        }

        public static void tt_fjbm(string lsbh)//房价保密
        {

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id,fjbm from Qskyd_fjrb", "((fjbm='" + common_file.common_app.fjbm_bm + "') and lsbh='" + lsbh + "' and fjbh='') or ((fjbm='" + common_file.common_app.fjbm_bm + "') and fjbh<>'' and lsbh in (select lsbh  from Qskyd_mainrecord  where ddbh=(select ddbh from Qttyd_mainrecord where lsbh='"+lsbh+"')))");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_form.Qttdj_new != null)
                {
                    if (common_file.common_form.Qttdj_new.M_Qttyd_mainrecord.lsbh == lsbh)
                    {
                        common_file.common_form.Qttdj_new.tB_krxm.ForeColor = Color.Red;
                    }
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "客人要求房价保密！");
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }
        /// <summary>
        /// 散客登录提醒
        /// </summary>
        /// <param name="lsbh"></param>
        public static void Qskyd_remind(string lsbh)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Qyd' and judge_type='krrx' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    htk(lsbh);
                    hmd(lsbh);
                }

            }
            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Qyd'  and judge_type='fjbm' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    fjbm(lsbh);
                }
            }

            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Qyd'  and judge_type='tsyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tsyq(lsbh);
                }
            }
            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Qyd'  and judge_type='qtyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    qtyq(lsbh);
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }
        /// <summary>
        /// 散客账务提醒
        /// </summary>
        /// <param name="lsbh"></param>
        public static void Qskzw_remind(string lsbh)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Syd' and judge_type='krrx' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    htk(lsbh);
                    hmd(lsbh);
                }

            }
            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Syd' and judge_type='fjbm' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    fjbm(lsbh);
                }
            }

            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Syd' and judge_type='tsyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tsyq(lsbh);
                }
            }
            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Syd' and judge_type='qtyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    qtyq(lsbh);
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        /// <summary>
        /// 团体登录提醒
        /// </summary>
        /// <param name="lsbh"></param>
        public static void Qttyd_remind(string lsbh)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Qyd' and judge_type='fjbm' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tt_fjbm(lsbh);
                }
            }

            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Qyd' and judge_type='tsyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tt_tsyq(lsbh);
                }
            }
            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Qyd' and judge_type='qtyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tt_qtyq(lsbh);
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }
        /// <summary>
        /// 团体账务提醒
        /// </summary>
        /// <param name="lsbh"></param>
        public static void Qttzw_remind(string lsbh)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            DataSet DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Syd'  and judge_type='fjbm' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tt_fjbm(lsbh);
                }
            }

            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Syd'  and judge_type='tsyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tt_tsyq(lsbh);
                }
            }
            DS_temp = B_Common.GetList("select * from X_judge_remind", "judge_ym='Syd'  and judge_type='qtyq' and judge_value=1");
            {
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tt_qtyq(lsbh);
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        ///<summary>
        ///检查是否是会员预订，短信提醒,如果有那么返回房类的信息和预订的时间信息
        ///
        public static void hy_yd_dx_tx(string lsbh,string fr_sl,string fr,bool flage,string  fjrb_id_temp)
        {
            //首先查询是否启用会员短信提醒功能
            if (!common_file.common_hyAction.hygl_shqr_add(common_file.common_app.yydh))
            {
                return ;
            }
            BLL.Common B_common = new Hotel_app.BLL.Common();
            //修改成不检查是否是会员，只检查是否有填写手机号
            DataSet ds_1 = B_common.GetList(" select  *  from   View_Qskzd  ", " lsbh='" + lsbh + "'  and    yddj='" + common_file.common_yddj.yddj_yd + "'  and    krsj!=''    and   main_sec='" + common_file.common_app.main_sec_main + "'   ");
            string phoneNo = "";
            bool sh_sendDX = false;

            if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
            {
                phoneNo = ds_1.Tables[0].Rows[0]["krsj"].ToString();
                bool check = System.Text.RegularExpressions.Regex.IsMatch(phoneNo, @"^[1]+[3,4,5,6,8]+\d{9}");
                if (check)
                {
                    DataSet ds_2 = B_common.GetList(" select * from  Qskyd_fjrb ", " lsbh='" + lsbh + "'  and   yddj='" + common_file.common_yddj.yddj_yd + "' ");
                    {
                        string ss = ""; sh_sendDX = false;
                        //判断是否要发短信（有房类信息就可以）
                        for (int i = 0; i < ds_2.Tables[0].Rows.Count; i++)
                        {
                            ss = ds_2.Tables[0].Rows[i]["fjrb"].ToString();
                            if (ss.Equals(""))
                            {
                                continue;
                            }
                            else
                            {
                                sh_sendDX = true;
                                break;
                            }
                        }
                    }
                    if (sh_sendDX)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("[" + common_file.common_app.qymc + "]");
                        for (int i = 0; i < ds_2.Tables[0].Rows.Count; i++)
                        {
                            if (ds_2.Tables[0].Rows[i]["fjrb"].ToString().Length > 0)
                            {
                                if (sb.ToString().Length > 0)
                                { sb.Append(","); }
                                sb.Append(DateTime.Parse(ds_2.Tables[0].Rows[i]["ddsj"].ToString()).ToShortDateString() + ds_2.Tables[0].Rows[i]["fjrb"].ToString() + ds_2.Tables[0].Rows[i]["lzfs"].ToString() + "间");
                            }
                        }
                        //Hotel_app.Hhygl_app.Hhygl_app Hhygl_app_services_new = new Hotel_app.Hhygl_app.Hhygl_app();
                        //Hhygl_app_services_new.Url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                        //string ss=Hhygl_app_services_new.Hhygl_SendMsm(phoneNo, sb.ToString(), common_file.common_app.yydh, "", common_file.common_hyAction.hy_Action_ydxg, "", "", "", "", "", "", common_file.common_app.xxzs);
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "系统修改当前会员的预订单成功,并以经自动将房型及房数以短信告知客人！");
                    }
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "系统修改当前会员的预订单成功,但当前客人的手机号位数不正确,短信暂时玩法发送请先检查手机号再次尝试发送！");
                }

            }
            else
            {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "系统修改当前会员的预订单成功,但当前客人的手机号为空或者格式不正确,短信暂时玩法发送请先检查手机号再次尝试发送！");
            }
 
        }
    }
}
