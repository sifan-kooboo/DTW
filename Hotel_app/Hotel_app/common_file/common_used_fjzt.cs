using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public static class common_used_fjzt
    {
        /// <summary>///用来判断哪些房间已经被真实的占用了，获得冲突房
        /// 
        /// </summary>
        /// <param name="DS_wx_other"></param>
        /// <param name="DS_yddj"></param>
        /// <param name="wx_dj"></param>////四种状态,一种是维修和其他房，一种是预订和登记房,一种是预订和登记房。
        /// <param name="ddsj_temp"></param>
        /// <param name="lksj_temp"></param>
        /// <param name="fjrb_temp"></param>
        /// <param name="fjbh_temp"></param>
        /// <param name="record_id"></param>////如果是修改，要把自己排除掉。
        /// <param name="is_contain_wx"></param>////TRUE可用（在预订时有时可用），FALSE不可用。调用common_app里的is_contain_wx
        /// <returns></returns>
        public static bool get_dataset_usedfjzt(string wx_dj, DateTime ddsj_temp, DateTime lksj_temp, string fjrb_temp, string fjbh_old, string fjbh_temp, string record_id, bool is_contain_wx)
        {
            DataSet DS_wx_other;
            DataSet DS_yddj;
            bool result_0 = false;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string ddsj_temp_0 = ddsj_temp.ToShortDateString();
            string lksj_temp_0 = lksj_temp.ToShortDateString() + " " + "23:59:59";
            string fjrb_fjbh_select = "";
            if (fjrb_temp.Trim() != "")
                fjrb_fjbh_select = " and (fjrb='" + fjrb_temp + "'";
            if (fjbh_temp.Trim() != "")
                fjrb_fjbh_select = fjrb_fjbh_select + " and fjbh='" + fjbh_temp + "')";
            string wx_select_condition = " and ((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "') or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";
            string dj_select_condition = wx_select_condition;
            if (wx_dj == common_yddj.yddj_yd)
                if (is_contain_wx == true)
                {//直接在Fwx_other排除掉维修
                    wx_select_condition = wx_select_condition + " and (zyzt<>'" + common_file.common_fjzt.wxf + "')";
                }
            if (wx_dj == common_yddj.yddj_dj || wx_dj == common_yddj.yddj_yd)
            {
                if (ddsj_temp.ToShortDateString() != lksj_temp.ToShortDateString())
                {
                    lksj_temp = lksj_temp.AddDays(-1);
                }
                ddsj_temp_0 = ddsj_temp.ToShortDateString();
                string ddsj_temp_1 = ddsj_temp.AddDays(1).ToShortDateString();
                lksj_temp_0 = lksj_temp.ToShortDateString() + " " + "23:59:59";
                dj_select_condition = " and ((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "') or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";

            }
            string wx_id_condition = "";
            string dj_id_condition = "";
            if (record_id.Trim() != "")//如果是修改，要把自己排除掉。 
            {
                //if (fjbh_old == fjbh_temp)//在没有更改房号的情况下要把自己排除掉，但如果房号有变更就要进行判断了
                {
                    if (wx_dj == common_fjzt.wxf || wx_dj == common_fjzt.qtf)
                        wx_id_condition = " and (id<>'" + record_id + "')";
                    if (wx_dj == common_yddj.yddj_dj || wx_dj == common_yddj.yddj_yd)
                    {
                        dj_id_condition = " and (id<>'" + record_id + "')";


                        DS_yddj = B_Common.GetList("select id,ddsj,lksj from Qskyd_fjrb", "id='" + record_id + "'");
                        string ddsj_yy_0 = ""; string lksj_yy_0 = "";
                        if (DS_yddj != null && DS_yddj.Tables[0].Rows.Count > 0)
                        {
                            ddsj_yy_0 = DS_yddj.Tables[0].Rows[0]["ddsj"].ToString();
                            lksj_yy_0 = DS_yddj.Tables[0].Rows[0]["lksj"].ToString();

                        }
                        if (ddsj_yy_0 != "" && lksj_yy_0 != "")
                        {
                            DS_yddj = B_Common.GetList("select id,lsbh,ddsj,lksj from Qskyd_fjrb", "id!='" + record_id + "' and fjbh='" + fjbh_temp + "' and ddsj='" + ddsj_yy_0 + "' and lksj='" + lksj_yy_0 + "'");
                            {
                                if (DS_yddj != null && DS_yddj.Tables[0].Rows.Count > 0)
                                {
                                    record_id = DS_yddj.Tables[0].Rows[0]["id"].ToString();
                                    dj_id_condition = dj_id_condition + " and (id<>'" + record_id + "')";
                                }

                            }

                        }

                    }
                }

            }

            DS_wx_other = B_Common.GetList("select * from Fwx_other", "(id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select + wx_id_condition + " order by ddsj");
            if (DS_wx_other != null && DS_wx_other.Tables[0].Rows.Count > 0)
            {
                result_0 = true;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，该时间段内已经有人设置维修房或其他房了！明细请看以下的提示：");
                Ffjzt.Ffjzt_wx_other_remind Ffjzt_wx_other_remind_new = new Ffjzt.Ffjzt_wx_other_remind(DS_wx_other);
                Ffjzt_wx_other_remind_new.ShowDialog();
            }
            DS_yddj = B_Common.GetList("select * from Qskyd_fjrb", "(id>=0 " + common_app.yydh_select + ")" + dj_select_condition + fjrb_fjbh_select + dj_id_condition + " order by ddsj");
            if (DS_yddj != null && DS_yddj.Tables[0].Rows.Count > 0)
            {
                result_0 = true;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，该时间段内已经有人做预订或登记了！明细请看以下的提示：");
                Ffjzt.Fyddj_remind Fyddj_remind_new = new Ffjzt.Fyddj_remind(DS_yddj);
                Fyddj_remind_new.ShowDialog();

            }
            DS_wx_other.Dispose();
            DS_yddj.Dispose();
            return result_0;
        }


        /// <summary>获得可用房
        /// 
        /// </summary>
        /// <param name="DS_fjzt"></param>
        /// <param name="yd_dj"></param>
        /// <param name="ddsj_temp"></param>
        /// <param name="lksj_temp"></param>
        /// <param name="fjrb_temp"></param>
        /// <param name="is_lksj"></param>//是否包含离开时间包含true就不要排除当日预离房，如果不包含false就排除当日预离房
        ///<param name="is_contain_wx"></param>//是否包含维修（就是说维修时还可排给预订房，但在维修房绝对不能排给登记）TRUE维修房可用，FALSE维修房不能用 

        public static void get_dataset_fjzt_canused(out DataSet DS_fjzt, string yd_dj, DateTime ddsj_temp, DateTime lksj_temp, string fjrb_temp, bool is_lksj, bool is_contain_wx)
        {
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            string select_strwhere = "(1=1)  ";
            string ddsj_temp_0 = ddsj_temp.ToShortDateString();
            string lksj_temp_0 = lksj_temp.ToShortDateString() + " " + "23:59:59";
            string fjrb_fjbh_select = ""; string fjrb_fjbh_select_qtf = ""; string fjrb_fjbh = "";
            if (fjrb_temp.Trim() != "")
            {
                fjrb_fjbh = " and (fjrb='" + fjrb_temp + "')";
                fjrb_fjbh_select = " and (fjrb='" + fjrb_temp + "'  and  Zyzt ='" + common_file.common_fjzt.wxf + " ')";//用于维修房
                fjrb_fjbh_select_qtf = "  and (fjrb='" + fjrb_temp + "' and  Zyzt='" + common_file.common_fjzt.qtf + "')";//用于其它房（其它房不管是在预订还是在登记的时候都要排除掉)
            }
            string wx_select_condition = " and ((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";

            if (is_lksj == false)//false 时离开时间也是不可用，但TRUE时离开那一天可用
            {
                if (is_contain_wx == false)//不可用的时候都加上这一条件
                {
                    select_strwhere = " (fjbh not in(select fjbh  from Fwx_other where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select + " ))  and   ";
                    select_strwhere += "(fjbh not in(select fjbh from Qskyd_fjrb where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh + " ))";
                    if (yd_dj == common_file.common_yddj.yddj_dj)
                    {
                        select_strwhere += "and (zyzt!='" + common_file.common_fjzt.zzf + "')";
                    }
                }
                else
                {
                    if (yd_dj == common_file.common_yddj.yddj_dj)
                    {
                        select_strwhere = " (fjbh not in(select fjbh  from Fwx_other where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select + " ))  and   ";
                        select_strwhere += "(fjbh not in(select fjbh from Qskyd_fjrb where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh + " ))";
                        select_strwhere += "and (zyzt<>'" + common_file.common_fjzt.zzf + "' and zyzt<>'" + common_file.common_fjzt.wxf + "' and zyzt<>'" + common_file.common_fjzt.qtf + "' and zybz<>'" + common_file.common_fjzt.lszy + "')";
                    }
                    else
                    {
                        select_strwhere += "  and  (fjbh not in(select fjbh from Qskyd_fjrb where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh + " ))";
                    }

                }
                select_strwhere += "  and   (fjbh not in(select fjbh from Fwx_other  Where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select_qtf + "))";
                if (fjrb_temp != "")
                {
                    select_strwhere += "  and  (fjrb='" + fjrb_temp + "')";
                }
                select_strwhere += "  order by zyzt , fjrb,fjbh";
                DS_fjzt = B_Ffjzt.GetList(select_strwhere);
                return;
            }
            else//if (is_lksj == false)//false 时离开时间也是不可用，但TRUE时离开那一天可用
            {
                string dj_select_condition = "";
                //
                //dj_select_condition = " and ((CONVERT(varchar(10),ddsj, 120)  between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (CONVERT(varchar(10),ddsj, 120) <'" + ddsj_temp_0 + "' and  CONVERT(varchar(10),lksj, 120)>'" + lksj_temp_0 + "') or (CONVERT(varchar(10),lksj, 120) between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";
                string ddsj_cs = ddsj_temp.ToShortDateString();
                string ddsj_js = ddsj_temp.ToShortDateString() + " " + "23:59:59";
                string lksj_cs = lksj_temp.ToShortDateString();
                string lksj_js = lksj_temp.ToShortDateString() + " " + "23:59:59";
                if (ddsj_temp.ToShortDateString() != lksj_temp.ToShortDateString())
                {
                    dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "') or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where (ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "') ))         )";
                }
                else
                {
                    //dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "') or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where ((ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "'))   and  (CONVERT(varchar(10),ddsj, 120)=CONVERT(varchar(10),lksj, 120))  ))       )";
                    dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "') or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where ((ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "'))     ))       )";

                }
                //是否排除维修房
                if (is_contain_wx == false) //维修房不可用
                {
                    select_strwhere = " (fjbh not in(select fjbh  from Fwx_other where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select + " ))";
                    select_strwhere += "  and (fjbh not in(select fjbh from Qskyd_fjrb where (id>=0" + common_app.yydh_select + ")" + dj_select_condition + fjrb_fjbh + " ))";
                    if (yd_dj == common_file.common_yddj.yddj_dj)
                    {
                        select_strwhere += "and (zyzt<>'" + common_file.common_fjzt.zzf + "')";
                    }
                }
                else
                {
                    if (yd_dj == common_file.common_yddj.yddj_dj)
                    {
                        select_strwhere = " (fjbh not in(select fjbh  from Fwx_other where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select + " ))";
                        select_strwhere += "  and (fjbh not in(select fjbh from Qskyd_fjrb where (id>=0" + common_app.yydh_select + ")" + dj_select_condition + fjrb_fjbh + " ))";
                        select_strwhere += "and (zyzt<>'" + common_file.common_fjzt.zzf + "' and zyzt<>'" + common_file.common_fjzt.wxf + "' and zyzt<>'" + common_file.common_fjzt.qtf + "' and zybz<>'" + common_file.common_fjzt.lszy + "')";
                    }
                    else
                    {
                        select_strwhere += "  and (fjbh not in(select fjbh from Qskyd_fjrb where (id>=0" + common_app.yydh_select + ")" + dj_select_condition + fjrb_fjbh + " ))";
                    }

                }
                select_strwhere += "  and   (fjbh not in(select fjbh from Fwx_other  Where (id>=0" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select_qtf + "))";
                if (fjrb_temp != "")
                {
                    select_strwhere += "  and  (fjrb='" + fjrb_temp + "')";
                }
                select_strwhere += "  order by  zyzt, fjrb,fjbh";
                DS_fjzt = B_Ffjzt.GetList(select_strwhere);
                return;
            }
        }

        /// <summary>获得可用房数量，预订登记时的判断
        /// 
        /// </summary>
        /// <param name="yd_dj"></param>
        /// <param name="ddsj_temp"></param>
        /// <param name="lksj_temp"></param>
        /// <param name="fjrb_temp"></param>
        /// <param name="is_lksj"></param>//是否包含离开时间包含就不要排除当日预离房，如果不包含就排除当日预离房
        ///<param name="is_contain_wx"></param>//是否包含维修（就是说维修时还可排给预订房，但在维修房绝对不能排给登记）TRUE维修房可用，FALSE维修房不能用 
        /// <param name="ylsl"></param>//如果是修改要把原来的数量输入到这边，如果新增这个值就为0
        /// <param name="xzsl"></param>//现在要预订或入住的数量。
        /// <returns></returns>

        public static float get_fjzt_sl_canused(string yd_dj, DateTime ddsj_temp, DateTime lksj_temp, string fjrb_temp, bool is_lksj, bool is_contain_wx, float ylsl, float xzsl)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string select_strwhere = "(1=1)  ";
            string ddsj_temp_0 = ddsj_temp.ToShortDateString();
            string lksj_temp_0 = lksj_temp.ToShortDateString() + " " + "23:59:59";
            DataSet DS_temp;
            if (fjrb_temp.Trim() != "")
            {
                DS_temp = B_Common.GetList("select count(*) as fs from Ffjzt", "fjrb='" + fjrb_temp + "'" + common_app.yydh_select);
            }
            else
            {
                DS_temp = B_Common.GetList("select count(*) as fs from Ffjzt", "id>=0" + common_app.yydh_select);
            }

            float zfs = 0; float zysl = 0; float kyfs = 0;

            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs = int.Parse(DS_temp.Tables[0].Rows[0]["fs"].ToString());

            }
            string fjrb_fjbh_select = ""; string fjrb_fjbh = "";

            if (fjrb_temp.Trim() != "")
            {
                fjrb_fjbh = " and (fjrb='" + fjrb_temp + "')";

            }

            if (is_contain_wx == false)
                fjrb_fjbh_select = fjrb_fjbh + "  and  (Zyzt ='" + common_file.common_fjzt.wxf + " 'and  Zyzt='" + common_file.common_fjzt.qtf + "')";//用于维修房
            else
                fjrb_fjbh_select = fjrb_fjbh + " and  (Zyzt='" + common_file.common_fjzt.qtf + "')";//用于其它房（其它房不管是在预订还是在登记的时候都要排除掉)

            string wx_select_condition = " and ((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";

            if (is_lksj == false)//false 时离开时间也是不可用，但TRUE时离开那一天可用
            {

                select_strwhere = " (id>=0 and fjrb<>''" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select;
                DS_temp = B_Common.GetList("select count(*) as sl from Fwx_other", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }
                select_strwhere = " (id>=0 and lzfs>0 and fjrb<>''" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh;
                DS_temp = B_Common.GetList("select sum(lzfs) as sl from VIEW_Qfjrb_fs_tj", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = zysl + float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }

            }
            else//if (is_lksj == false)//false 时离开时间也是不可用，但TRUE时离开那一天可用
            {

                select_strwhere = "  (id>=0 and fjrb<>''" + common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select;

                DS_temp = B_Common.GetList("select count(*) as sl from Fwx_other", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }
                string dj_select_condition = "";
                //
                //dj_select_condition = " and ((CONVERT(varchar(10),ddsj, 120)  between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (CONVERT(varchar(10),ddsj, 120) <'" + ddsj_temp_0 + "' and  CONVERT(varchar(10),lksj, 120)>'" + lksj_temp_0 + "') or (CONVERT(varchar(10),lksj, 120) between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";

                string ddsj_cs = ddsj_temp.ToShortDateString();
                string ddsj_js = ddsj_temp.ToShortDateString() + " " + "23:59:59";
                string lksj_cs = lksj_temp.ToShortDateString();
                string lksj_js = lksj_temp.ToShortDateString() + " " + "23:59:59";
                if (ddsj_temp.ToShortDateString() != lksj_temp.ToShortDateString())
                {
                    dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where (ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "') ))         )";
                }
                else
                {
                    //dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where ((ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "'))   and  (CONVERT(varchar(10),ddsj, 120)=CONVERT(varchar(10),lksj, 120))  ))       )";
                    dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where ((ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "'))           ))       )";
                }
                //dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "') or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and ((lsbh not in(select lsbh from VIEW_Qfjrb_fs_tj where ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "')) and ((lsbh not in(select lsbh from VIEW_Qfjrb_fs_tj where lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "')))))";


                select_strwhere = "  (id>=0 and lzfs>0 and fjrb<>'' " + common_app.yydh_select + ")" + dj_select_condition + fjrb_fjbh;

                DS_temp = B_Common.GetList("select sum(lzfs) as sl from VIEW_Qfjrb_fs_tj", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = zysl + float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }

            }
            kyfs = zfs + ylsl - xzsl - zysl;
            DS_temp.Dispose();
            return kyfs;


        }



        /// <summary>
        /// 在房间类别和登记页面进行判断,获取可用房的情况
        /// </summary>
        /// <param name="judge_add_edit"></param>
        /// <param name="yddj"></param>
        /// <param name="xzfs_tb"></param>现在房数
        /// <param name="ylfs_temp"></param>原来房数
        /// <param name="fjrb_old"></param>//如果房型有变动时,要把ylfs_temp赋0；
        /// <param name="fjrb_tb"></param>现在房型
        /// <param name="ddsj"></param>
        /// <param name="lksj"></param>
        /// <param name="krxm_0"></param>
        /// <param name="fjbh_0"></param>
        /// <param name="lsbh_0"></param>
        /// <param name="bz_0"></param>
        /// <returns></returns>
        public static bool judge_kyfs(string judge_add_edit, string yddj, string xzfs_tb, float ylfs_temp, string fjrb_old, string fjrb_tb, DateTime ddsj, DateTime lksj, string krxm_0, string fjbh_0, string lsbh_0, string bz_0)
        {
            bool get_result = false;
            float ylfs = 0; float xzfs = 0;
            if (judge_add_edit == common_file.common_app.get_add)
            {
                if (xzfs_tb != "")
                    if (float.Parse(xzfs_tb) > 0)
                    {
                        xzfs = float.Parse(xzfs_tb);
                    }
            }
            else
                if (judge_add_edit == common_file.common_app.get_edit)
                {


                    if (fjrb_old == fjrb_tb)
                    {
                        ylfs = ylfs_temp;
                    }
                    if (xzfs_tb != "")
                        if (float.Parse(xzfs_tb) > 0)
                        {
                            xzfs = float.Parse(xzfs_tb);
                        }
                }
            if (xzfs == 0)
            {
                get_result = true;
            }
            else
            {
                if (ylfs != xzfs)
                {
                    xzfs = common_file.common_used_fjzt.get_fjzt_sl_canused(yddj, ddsj, lksj, fjrb_tb, true, common_file.common_app.is_contain_wx, ylfs, xzfs);
                    if (xzfs < 0)
                    {
                        xzfs = -xzfs;
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "对不起，房数已经超用" + xzfs.ToString() + "间！是否仍要强行排房！") == true)
                        {
                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_app.czy, "超" + xzfs.ToString() + "间排房", krxm_0 + lsbh_0, fjrb_tb + "_" + fjbh_0 + bz_0, DateTime.Now);
                            get_result = true;
                        }
                    }
                    else { get_result = true; }
                }
                else
                {
                    get_result = true;
                }
            }
            return get_result;

        }


        /// <summary>
        /// 获取用来分析的可用房的数量
        /// </summary>
        /// <param name="fjrb"></param>房型
        /// <param name="fx_rq"></param>查询日期
        /// <param name="is_contain_wx"></param>可用房是否包含维修房
        /// <param name="yd_zz_zy"></param>预订在住人数
        /// <param name="is_get_rs"></param>是否要获得预订在住人数
        /// <param name="yd_zz_rs"></param>预订在住人数
        /// <param name="wx_other_zy"></param>维修其他占用
        /// <param name="zfs"></param>总房数
        /// <param name="kyfs"></param>可用房数
        public static void get_zyfs_fx(string fjrb, DateTime fx_rq, bool is_contain_wx, ref float yd_zz_zy, bool is_get_rs, ref float yd_zz_rs, ref float wx_other_zy, ref float zfs, ref float kyfs)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            string fjrb_sel = "";
            zfs = 0; float zyfs = 0; kyfs = 0; wx_other_zy = 0; yd_zz_zy = 0; yd_zz_rs = 0;
            if (fjrb != "")
            {
                fjrb_sel = "and fjrb='" + fjrb + "'";
            }
            DataSet DS_temp = B_Common.GetList("select count(id) as zfs from Ffjzt", "id>=0" + fjrb_sel);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs = float.Parse(DS_temp.Tables[0].Rows[0]["zfs"].ToString());
            }
            fx_rq = DateTime.Parse(fx_rq.ToShortDateString());

            if (is_contain_wx == true)
            {
                DS_temp = B_Common.GetList("select count(id) as zyfs from Fwx_other", "id>=0 and zyzt<>'" + common_fjzt.wxf + "' and (lksj>='" + fx_rq.ToShortDateString() + "' and ddsj<'" + fx_rq.ToShortDateString() + " 23:59:59" + "')" + fjrb_sel);
            }
            else
            {
                DS_temp = B_Common.GetList("select count(id) as zyfs from Fwx_other", "id>=0 and (lksj>='" + fx_rq.ToShortDateString() + "' and ddsj<'" + fx_rq.ToShortDateString() + " 23:59:59" + "')" + fjrb_sel);
            }
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zyfs = float.Parse(DS_temp.Tables[0].Rows[0]["zyfs"].ToString());
                wx_other_zy = zyfs;
            }

            //and (CONVERT(varchar(10),lksj, 120)> CONVERT(varchar(10)
            DS_temp = B_Common.GetList("select sum(lzfs) as zyfs from Qskyd_fjrb", "id>=0 and fjrb<>'' and lzfs>0 and (lksj>='" + fx_rq.AddDays(1).ToShortDateString() + "' and ddsj<'" + fx_rq.ToShortDateString() + " 23:59:59" + "')" + fjrb_sel);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["zyfs"].ToString() != "")
                {
                    yd_zz_zy = float.Parse(DS_temp.Tables[0].Rows[0]["zyfs"].ToString());
                    zyfs = zyfs + float.Parse(DS_temp.Tables[0].Rows[0]["zyfs"].ToString());
                }

            }
            if (is_get_rs == true)
            {
                DS_temp = B_Common.GetList("select count(id) as zyrs from View_Qskzd", "id>=0 and yddj='" + common_yddj.yddj_dj + "' and (lksj>='" + fx_rq.AddDays(1).ToShortDateString() + "' and ddsj<'" + fx_rq.ToShortDateString() + " 23:59:59" + "')" + fjrb_sel);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    yd_zz_rs = float.Parse(DS_temp.Tables[0].Rows[0]["zyrs"].ToString());
                }

                DS_temp = B_Common.GetList("select fjrb,sum(lzfs) as lzfs  from Qskyd_fjrb", "id>=0 and fjrb<>'' and lzfs>0 and yddj='"+common_yddj.yddj_yd+"' and (lksj>='" + fx_rq.AddDays(1).ToShortDateString() + "' and ddsj<'" + fx_rq.ToShortDateString() + " 23:59:59" + "')" + fjrb_sel+" group by fjrb");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                    {
                        float yd_zz_rs_0 = 0;
                        for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                        {
                            yd_zz_rs_0 = float.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString());
                            DataSet DS_temp_0 = B_Common.GetList("select zyrs from Ffjrb", "fjrb='" + DS_temp.Tables[0].Rows[i_0]["fjrb"].ToString() + "'");
                            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            {
                                yd_zz_rs_0 = float.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString()) * float.Parse(DS_temp_0.Tables[0].Rows[0]["zyrs"].ToString());
                            }
                            yd_zz_rs = yd_zz_rs + yd_zz_rs_0;
                            DS_temp_0.Clear();
                            DS_temp_0.Dispose();
                        }
                    }
                }
                //bool is_get_rs,ref float yd_zz_rs,
            }
            kyfs = zfs - zyfs;
            DS_temp.Clear();
            DS_temp.Dispose();

            //return kyfs;
        }
    }
}
