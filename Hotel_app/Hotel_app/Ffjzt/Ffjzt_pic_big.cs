using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_app.common_file;
using Hotel_app.control_user;
using System.Runtime.InteropServices;
using Maticsoft.DBUtility;
using Hotel_app.Szwgl;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjzt_pic_big : Form
    {
        common_file.Common_Hook hook_0 = new Hotel_app.common_file.Common_Hook();
        int dg_count_yd = 0;
        DataSet DS_Qsk;
        DataSet DS_update_fjzt;//用来存储查询时的存储。
        DateTime DT_update_fjzt = DateTime.Now;//用来记录更新的时间
        public string select_update_cond = "";
        public string ft_table = "";//房态表
        public string ft_sel = "";//房态的查询条件，分析房数时用。
        public BLL.Common B_Common = new Hotel_app.BLL.Common();
        public Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_select;//用来存储所选择的的房间
        common_pic cp = new common_pic();
        public int big_horizon_NO = 0;
        public int big_pic_space = 0;
        public int big_pic_height = 0;
        public int big_pic_width = 0;
        public int fj_status_style = 0;
        public Ffjzt_pic_big()
        {
            InitializeComponent();
            set_auto_refresh();//设置是否要自动刷新
            refresh_fjzt_1("Ffjzt", "",true);
        }
        //实现全局热键
        //设置是否要自动刷新
        public void set_auto_refresh()
        {
            timer_update_fjzt.Enabled = false;
            DataSet DS_temp_0 = B_Common.GetList("select * from Qcounter", "id>=0");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["ft_auto_refresh"].ToString() == "True")
                {
                    if (common_file.common_app.ft_sh_ztsx == true)
                    {
                        timer_update_fjzt.Enabled = true;
                    }
                }
            }
        }
        //设置当前房间是否可见
        public  void IsVisibleFj(string cond,Hotel_app.control_user.UC_room_pic_0   tempUC)
        {
            bool IsInList = false;
            if (cond.Equals(""))
            {
                 IsInList = true;
            }
            else
            {
                BLL.Ffjzt B_Ffjzt_temp = new Hotel_app.BLL.Ffjzt();
                List<Model.Ffjzt> fjs = B_Ffjzt_temp.GetModelList("id>=0  " + cond);
                foreach (Model.Ffjzt  temFj in fjs)
                {
                    if (tempUC.MP_roomno.Equals(temFj.fjbh))
                    {
                        IsInList=true;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            tempUC.Visible = IsInList;
        }
        //生成的房态图.（三种:True为全部重新刷新,否为gl显示）
        public void refresh_fjzt_1(string Table_name, string select_cond_0,bool  IsReLoad)
        {
            common_file.common_app.get_czsj();
            IsReLoad = true;
            //如果为刷新,那么直接刷新就可以
            big_horizon_NO = int.Parse(Common_initalSystem.ReadXML("add", "big_horizon_NO"));
            big_pic_space = int.Parse(Common_initalSystem.ReadXML("add", "big_pic_space"));
            big_pic_height = int.Parse(Common_initalSystem.ReadXML("add", "big_pic_height"));
            big_pic_width = int.Parse(Common_initalSystem.ReadXML("add", "big_pic_width"));
            fj_status_style = int.Parse(Common_initalSystem.ReadXML("add", "fj_status_style"));
            ft_table = Table_name;//保存表名 ,用来分析数量时用
            ft_sel = select_cond_0;//房态选择条件,用来分析数量时用
            timer_update_fjzt.Enabled = false;
            DataSet DS_jdlh;
            DataSet DS_jdcs;
            DataSet DS_fjbh;
            int jdlh_i = 0; int jdcs_i = 0; int fjbh_i = 0;
            int pic_top = big_pic_space;
            int fjbh_count = 1;
            int fj_count = 0;//房间总数
            select_update_cond = select_cond_0;
            //DateTime DT_ls_temp = DateTime.Now;//获取一个刷新的截取时间。
            DT_update_fjzt = DateTime.Now;//获取更新时间
            List<string> list_fjs = new List<string>();
            if (IsReLoad)
            {
                p_pic.Controls.Clear();
                //增加信息窗
                p_pic.Controls.Add(p_remind_w);
                //p_pic.Controls.Add(p_info_Two);
                //重新加载
                DS_jdlh = B_Common.GetList("select distinct jdlh from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " order by jdlh desc");
                for (jdlh_i = 0; jdlh_i < DS_jdlh.Tables[0].Rows.Count; jdlh_i++)
                {
                    common_file.common_app.get_czsj();
                    DS_jdcs = B_Common.GetList("select distinct jdcs from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and jdlh='" + DS_jdlh.Tables[0].Rows[jdlh_i]["jdlh"].ToString() + "' order by jdcs desc");
                    for (jdcs_i = 0; jdcs_i < DS_jdcs.Tables[0].Rows.Count; jdcs_i++)
                    {
                        common_file.common_app.get_czsj();
                        DS_fjbh = B_Common.GetList("select * from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and jdlh='" + DS_jdlh.Tables[0].Rows[jdlh_i]["jdlh"].ToString() + "' and jdcs='" + DS_jdcs.Tables[0].Rows[jdcs_i]["jdcs"].ToString() + "'  order by jdcs ,fjbh");
                        if (DS_fjbh != null && DS_fjbh.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_app.get_czsj();
                            double line_i = Math.Ceiling(Convert.ToDouble(DS_fjbh.Tables[0].Rows.Count) / Convert.ToDouble(big_horizon_NO));
                            //列数
                            Panel panel_pic_new = new Panel();
                            panel_pic_new.Name = "Pa" + DS_fjbh.Tables[0].Rows[0]["jdlh"].ToString() + DS_fjbh.Tables[0].Rows[0]["jdcs"].ToString();
                            panel_pic_new.Height = Convert.ToInt32(line_i * (big_pic_height + big_pic_space) + 2 * big_pic_space);
                            panel_pic_new.Dock = DockStyle.Top;
                            panel_pic_new.BackColor = Color.White;
                            panel_pic_new.BorderStyle = BorderStyle.None;
                            panel_pic_new.ContextMenuStrip = cM_setting;
                            panel_pic_new.Tag = "panel_pic";
                            p_pic.Controls.Add(panel_pic_new);
                            fjbh_count = 0;//被循环到的房间数
                            pic_top = big_pic_space;
                            for (int line_j = 0; line_j < Convert.ToInt32(line_i); line_j++)
                            {
                                common_file.common_app.get_czsj();
                                int pic_left = big_pic_space;
                                for (int column_k = 0; column_k < big_horizon_NO; column_k++)
                                {
                                    common_file.common_app.get_czsj();
                                    if (fjbh_count < DS_fjbh.Tables[0].Rows.Count)
                                    {
                                        Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_new = new Hotel_app.control_user.UC_room_pic_0();
                                        UC_room_pic_0_new.Width = big_pic_width;
                                        UC_room_pic_0_new.Height = big_pic_height;
                                        UC_room_pic_0_new.Name = "UC" + DS_fjbh.Tables[0].Rows[fjbh_count]["fjbh"].ToString();
                                        UC_room_pic_0_new.MP_roomno = DS_fjbh.Tables[0].Rows[fjbh_count]["fjbh"].ToString();
                                        UC_room_pic_0_new.MP_room_type = DS_fjbh.Tables[0].Rows[fjbh_count]["fjrb_code"].ToString();
                                        UC_room_pic_0_new.ContextMenuStrip = cM_setting;
                                        common_file.common_room_state.room_state(UC_room_pic_0_new, DS_fjbh, fjbh_count);
                                        UC_room_pic_0_new.Left = pic_left;
                                        UC_room_pic_0_new.Top = pic_top;
                                        //IsVisibleFj(UC_room_pic_0_new.MP_roomno, select_cond_0, UC_room_pic_0_new);
                                        UC_room_pic_0_new.Tag="UC_room_pic_0";
                                        panel_pic_new.Controls.Add(UC_room_pic_0_new);
                                        UC_room_pic_0_new.MouseDown_0 += new Hotel_app.control_user.UC_room_pic_0.MouseDown_0EventHandler(uc_room_pic_mouse_Down);
                                        UC_room_pic_0_new.DoubleClick_0 += new Hotel_app.control_user.UC_room_pic_0.DoubleClick_0EventHandler(uc_room_pic_DoubleClick);
                                        UC_room_pic_0_new.MouseHover_0 += new Hotel_app.control_user.UC_room_pic_0.MouseHover_0EventHandler(uc_room_pic_MouseHover);
                                        UC_room_pic_0_new.MouseLeave_0 += new Hotel_app.control_user.UC_room_pic_0.MouseLeave_0EventHandler(uc_room_pic_MouseLeave);
                                        pic_left = big_pic_space + (column_k + 1) * (big_pic_space + big_pic_width);
                                        fjbh_count = fjbh_count + 1;
                                        fj_count = fj_count + 1;
                                    }
                                    else break;
                                }
                                pic_top = big_pic_space + (line_j + 1) * (big_pic_space + big_pic_height);
                            }

                            Hotel_app.control_user.UC_panel UC_panel_new = new Hotel_app.control_user.UC_panel();
                            UC_panel_new.Name = "UP" + DS_fjbh.Tables[0].Rows[0]["jdlh"].ToString() + DS_fjbh.Tables[0].Rows[0]["jdcs"].ToString();
                            UC_panel_new.MP_title = DS_fjbh.Tables[0].Rows[0]["jdlh"].ToString() + "楼" + DS_fjbh.Tables[0].Rows[0]["jdcs"].ToString() + "层";
                            UC_panel_new.Dock = DockStyle.Top;
                            UC_panel_new.BorderStyle = BorderStyle.None;
                            UC_panel_new.MP_click_pic = 0;
                            UC_panel_new.UC_Panel_Tag = "UC_panel";
                            UC_panel_new.Tag = "UC_panel";
                            p_pic.Controls.Add(UC_panel_new);
                            UC_panel_new.titleclick += new Hotel_app.control_user.UC_panel.titleclickEventHandler(canceal_panel);


                        }
                        DS_fjbh.Clear();
                        DS_fjbh.Dispose();
                    }
                    DS_jdcs.Clear();
                    DS_jdcs.Dispose();
                }
                DS_jdlh.Clear();
                DS_jdlh.Dispose();
            }

            List<Hotel_app.control_user.UC_room_pic_0> list_ucs = new List<UC_room_pic_0>();
            DS(p_pic,list_ucs);
            foreach (Hotel_app.control_user.UC_room_pic_0 tempUc in list_ucs)
            {
                IsVisibleFj(select_cond_0, tempUc);
            }

            //l_fj_count.Text = fj_count.ToString();

            if (IsReLoad)
            {
                getcount(Table_name,"");//生成数量
            }
            common_Ffjzt.add_wx_yd();
            //设置是否启用自动刷新房态
            set_auto_refresh();
            //timer_update_fjzt.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        void DS(Control item, List<Hotel_app.control_user.UC_room_pic_0> list_ucs) 
        { 
            for (int i = 0; i < item.Controls.Count; i++) 
            {
                if (item.Controls[i].Tag != null && item.Controls[i].Tag.ToString().Equals("UC_room_pic_0"))
                {
                    list_ucs.Add((Hotel_app.control_user.UC_room_pic_0)item.Controls[i]);
                }
                else
                {
                    if (item.Controls[i].HasChildren && item.Controls[i].Tag != null && item.Controls[i].Tag.ToString().Equals("panel_pic"))
                    {
                        DS(item.Controls[i],list_ucs);
                    }
                }
            } 
        }
        public void getcount(string Table_name, string select_cond_0)
        {
            DataSet ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and zyzt='" + common_file.common_fjzt.gjf + "'");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_gj.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();
            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and zyzt='" + common_file.common_fjzt.zf + "'");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_zf.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and zyzt='" + common_file.common_fjzt.wxf + "'");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_wx.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and zyzt='" + common_file.common_fjzt.qtf + "'");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_qt.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and zyzt='" + common_file.common_fjzt.zzf + "'");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_zz.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and zyzt_second='" + common_file.common_fjzt.ydf + "'");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_yd.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt='" + common_file.common_fjzt.zf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and zybz='" + common_file.common_fjzt.yjf + "'");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_ds.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt_second='" + common_file.common_fjzt.ydf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and shts=1");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_ts.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt_second='" + common_file.common_fjzt.ydf + "') and (yd_ddsj>='" + DateTime.Now.ToShortDateString() + "' and yd_ddsj<'" + DateTime.Now.Date.AddDays(1).ToShortDateString() + "')");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_drdd.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            string s1 = "select count(*) as sl from " + Table_name + " where id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt='" + common_file.common_fjzt.zzf + "') and (lksj>='" + DateTime.Now.ToShortDateString() + "' and lksj<'" + DateTime.Now.Date.AddDays(1).ToShortTimeString() + "')";
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt='" + common_file.common_fjzt.zzf + "') and (lksj>='" + DateTime.Now.ToShortDateString() + "' and lksj<'" + DateTime.Now.Date.AddDays(1).ToShortDateString() + "')");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_drld.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt_second='" + common_file.common_fjzt.ydf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and shlf=1");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_lz.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }

            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt_second='" + common_file.common_fjzt.ydf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and shvip=1");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_vip.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }

            ds_temp_1 = B_Common.GetList("select count(*) as sl from " + Table_name, "id>=0" + common_file.common_app.yydh_select + select_cond_0 + " and (zyzt='" + common_file.common_fjzt.zzf + "') and ( lksj<'" + DateTime.Now.ToShortDateString() + "')");
            if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
            {
                l_c_cqld.Text = ds_temp_1.Tables[0].Rows[0]["sl"].ToString();

            }
            DataSet ds_fj_sl = B_Common.GetList("select count(*) as sl  from " + Table_name, "id>=0   ");
            {
                l_fj_count.Text = ds_fj_sl.Tables[0].Rows[0]["sl"].ToString();
            }


            ds_temp_1.Clear();
            ds_temp_1.Dispose();

        }
        public void refresh_app(string table_name, string sel_cond0,bool flage)
        {
            common_Ffjzt.add_wx_yd();
            refresh_fjzt(table_name, sel_cond0, flage);
            Cursor.Current = Cursors.Default;
        }
        public void canceal_panel(object sender, EventArgs e)
        {
            Hotel_app.control_user.UC_panel temp = (Hotel_app.control_user.UC_panel)sender;
            foreach (Control temp_control in p_pic.Controls)
            {

                Panel p = new Panel();
                if ((temp_control as Panel) != null)
                {
                    p = (Panel)temp_control;
                    if (p.Name.ToString() == "Pa" + temp.Name.ToString().Remove(0, 2))
                    {
                        if (p.Visible == false) { p.Visible = true; temp.MP_click_pic = 0; }
                        else if (p.Visible == true) { p.Visible = false; temp.MP_click_pic = 1; }
                        break;
                    }
                }
            }
        }
        public void canceal_panel_0(object sender, EventArgs e)
        {
            Hotel_app.control_user.UC_panel temp = (Hotel_app.control_user.UC_panel)sender;
            foreach (Control temp_control in p_button.Controls)
            {

                Panel p = new Panel();
                if ((temp_control as Panel) != null)
                {
                    p = (Panel)temp_control;
                    if (p.Name.ToString() == "Pa" + temp.Name.ToString().Remove(0, 2))
                    {
                        if (p.Visible == false)
                        {
                            p.Visible = true;
                            temp.MP_click_pic = 0;
                            re_set_panel(p, true);
                        }
                        else if (p.Visible == true)
                        {
                            p.Visible = false;
                            temp.MP_click_pic = 1;
                            re_set_panel(p, false);
                        }

                        break;
                    }
                }
            }
        }
        private void re_set_panel(Panel Panel_new, bool is_visible)
        {
            if (is_visible == true)
            {
                if (Panel_new.Name.ToString() == "Pa_remind")
                {
                    //uC_remind.Dock = DockStyle.Top;
                    //Pa_remind.Height = 300;
                    Pa_remind.Dock = DockStyle.Top;



                    uC_jd_tv.Dock = DockStyle.Top;
                    Pa_jd_tv.Visible = false;
                    uC_jd_tv.MP_click_pic = 1;


                    uC_jd_fr.Dock = DockStyle.Top;
                    Pa_jd_fr.Visible = false;
                    uC_jd_fr.MP_click_pic = 1;

                }
                else
                    if (Panel_new.Name.ToString() == "Pa_jd_tv")
                    {
                        uC_remind.Dock = DockStyle.Top;
                        Pa_remind.Visible = false;
                        uC_remind.MP_click_pic = 1;
                        uC_jd_tv.Dock = DockStyle.Top;
                        Pa_jd_tv.Dock = DockStyle.Fill;
                        uC_jd_fr.Dock = DockStyle.Bottom;
                        Pa_jd_fr.Visible = false;
                        uC_jd_fr.MP_click_pic = 1;
                    }
                    else
                        if (Panel_new.Name.ToString() == "Pa_jd_fr")
                        {
                            uC_remind.Dock = DockStyle.Top;
                            Pa_remind.Visible = false;
                            uC_remind.MP_click_pic = 1;
                            uC_jd_tv.Dock = DockStyle.Top;
                            Pa_jd_tv.Visible = false;
                            uC_jd_tv.MP_click_pic = 1;
                            uC_jd_fr.Dock = DockStyle.Top;
                            Pa_jd_fr.Dock = DockStyle.Fill;
                        }
            }
            else
            {
                if (Panel_new.Name.ToString() == "Pa_remind")
                {
                    uC_remind.Dock = DockStyle.Top;
                    //Pa_remind.Dock = DockStyle.Fill;
                    uC_jd_tv.Dock = DockStyle.Top;
                    //Pa_jd_tv.Visible = false;
                    uC_jd_fr.Dock = DockStyle.Top;
                    //Pa_jd_fr.Visible = false;
                }
                else
                    if (Panel_new.Name.ToString() == "Pa_jd_tv")
                    {
                        uC_remind.Dock = DockStyle.Top;
                        //Pa_remind.Dock = DockStyle.Fill;
                        uC_jd_tv.Dock = DockStyle.Top;
                        //Pa_jd_tv.Visible = false;
                        uC_jd_fr.Dock = DockStyle.Top;
                        //Pa_jd_fr.Visible = false;
                    }
            }

        }
        // 实现多选的两个变量     
        List<Hotel_app.control_user.UC_room_pic_0> list_rooms = new List<Hotel_app.control_user.UC_room_pic_0>();
        private void uc_room_pic_mouse_Down(object sender, MouseEventArgs e)
        {
            Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_temp = (Hotel_app.control_user.UC_room_pic_0)sender;
            //实现多选
            //检查list_rooms中是否有,如果有，就检测ctr+D当前是否被按下
            if (e.Button == MouseButtons.Left)
            {
                if (list_rooms.Count > 0)
                {
                    if (UC_room_pic_0_temp != null)
                    {
                        //common_file.common_app.flag_mulit_select = false;
                        //检查当前全局热键是否被按下
                        if (common_file.common_app.flag_mulit_select)//CheckHotKey() 按下
                        {
                            if (!CheckIsContainUserControl(list_rooms, UC_room_pic_0_temp))
                            {
                                list_rooms.Add(UC_room_pic_0_temp);
                                changeColor(UC_room_pic_0_temp, true);
                            }
                            common_file.common_app.flag_mulit_select = false;
                        }
                        else
                        {
                            foreach (UC_room_pic_0 uc_temp in list_rooms)
                            {
                                changeColor(uc_temp, false);
                            }
                            list_rooms.Clear();
                            list_rooms.Add(UC_room_pic_0_temp);
                            changeColor(UC_room_pic_0_temp, true);
                            common_file.common_app.flag_mulit_select = false;
                        }
                    }
                }
                if (list_rooms.Count <= 0)
                {
                    list_rooms.Add(UC_room_pic_0_temp);
                    changeColor(UC_room_pic_0_temp, true);
                    common_file.common_app.flag_mulit_select = false;
                }
            }
            UC_room_pic_0_select = UC_room_pic_0_temp;
            Dispalyfjzw(UC_room_pic_0_select);
        }


        void changeColor(UC_room_pic_0 uc_temp, bool is_Red)
        {
            if (is_Red)
            {
                uc_temp.BackColor = Color.Red;
            }
            else
            {
                uc_temp.BackColor = Color.Black;
            }
        }
        //判断房间是否以经存在于list中
        private bool CheckIsContainUserControl(List<Hotel_app.control_user.UC_room_pic_0> list_rooms, Hotel_app.control_user.UC_room_pic_0 tempControl)
        {
            bool isContains = false;
            foreach (Hotel_app.control_user.UC_room_pic_0 tmp in list_rooms)
            {
                if (tempControl != null)
                {
                    if (tmp.MP_roomno == tempControl.MP_roomno)
                    {
                        isContains = true;
                        list_rooms.Remove(tmp);//在的话再选择就从list中删除
                        changeColor(tempControl, false);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            return isContains;
        }
        private void uc_room_pic_DoubleClick(object sender, EventArgs e)
        {
            Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_temp = (Hotel_app.control_user.UC_room_pic_0)sender;
            if (UC_room_pic_0_temp != null)
            {
                string fjbh_1 = "";
                fjbh_1 = UC_room_pic_0_temp.MP_roomno;
                DataSet ds_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_1 + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    if (ds_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                    {
                        if (ds_temp.Tables[0].Rows.Count > 1)
                        {

                            FQ_yddj_select FQ_yddj_select_new = new FQ_yddj_select("and fjbh='" + fjbh_1 + "' and yddj='" + common_file.common_yddj.yddj_dj + "'");
                            FQ_yddj_select_new.Left = 150;
                            FQ_yddj_select_new.Top = 150;
                            FQ_yddj_select_new.ShowDialog();

                        }
                        else
                        {
                            ds_temp = B_Common.GetList("select * from View_Qskzd", "fjbh='" + fjbh_1 + "' and yddj='" + common_file.common_yddj.yddj_dj + "'");
                            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_form.Qskdj_new_open(ds_temp.Tables[0].Rows[0]["id"].ToString(), ds_temp.Tables[0].Rows[0]["yddj"].ToString(), common_file.common_app.get_edit, common_file.common_app.main_sec_main);
                            }

                        }
                        return;
                    }
                    if (ds_temp.Tables[0].Rows[0]["zyzt_second"].ToString() == common_file.common_fjzt.ydf)
                    {
                        ds_temp = B_Common.GetList("select * from View_Qskzd", "fjbh='" + fjbh_1 + "' and yddj='" + common_file.common_yddj.yddj_yd + "'");
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_form.Qskdj_new_open(ds_temp.Tables[0].Rows[0]["id"].ToString(), ds_temp.Tables[0].Rows[0]["yddj"].ToString(), common_file.common_app.get_edit, common_file.common_app.main_sec_main);
                        }
                        return;
                    }
                    if ((ds_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zf || ds_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.gjf) && ds_temp.Tables[0].Rows[0]["zybz"].ToString() != common_file.common_fjzt.lszy)
                    {
                        common_file.common_form.Qskdj_new_open("", common_file.common_yddj.yddj_dj, common_file.common_app.get_add, common_file.common_app.main_sec_main);
                        common_file.common_form.Qskdj_new.fjbh_pic = ds_temp.Tables[0].Rows[0]["fjbh"].ToString();
                        common_file.common_form.Qskdj_new.fjrb_pic = ds_temp.Tables[0].Rows[0]["fjrb"].ToString();
                    }
                    if (ds_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.wxf)
                    {
                        set_wx_other(common_file.common_fjzt.wxf);
                        return;
                    }
                    if (ds_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.qtf)
                    {
                        set_wx_other(common_file.common_fjzt.qtf);
                        return;
                    }
                }
                ds_temp.Dispose();
            }
        }
        private void add_jd_treeview()
        {
            TreeNode TN = new TreeNode();
            TN.Name = "Tn_qymc";
            TN.Tag = common_file.common_app.yydh;
            TN.Text = common_file.common_app.qymc;
            tV_jd_select.Nodes.Add(TN);
            DataSet DS_temp_1 = B_Common.GetList("select distinct jdlh,jdlh_name from Ffjzt", "id>=0" + common_file.common_app.yydh_select + " order by jdlh");
            if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_1.Tables[0].Rows.Count; i_0++)
                {
                    TN = new TreeNode();
                    TN.Name = "lh" + i_0.ToString();
                    TN.Tag = DS_temp_1.Tables[0].Rows[i_0]["jdlh"].ToString();
                    TN.Text = "楼." + DS_temp_1.Tables[0].Rows[i_0]["jdlh_name"].ToString();
                    tV_jd_select.Nodes["Tn_qymc"].Nodes.Add(TN);
                    DataSet DS_temp_2 = B_Common.GetList("select distinct jdcs,jdcs_name from Ffjzt", "id>=0 and jdlh='" + DS_temp_1.Tables[0].Rows[i_0]["jdlh"].ToString() + "'" + common_file.common_app.yydh_select + " order by jdcs");
                    if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                    {
                        for (int j_0 = 0; j_0 < DS_temp_2.Tables[0].Rows.Count; j_0++)
                        {
                            TN = new TreeNode();
                            TN.Name = "cs" + j_0.ToString();
                            TN.Tag = DS_temp_2.Tables[0].Rows[j_0]["jdcs"].ToString();
                            TN.Text = "层." + DS_temp_2.Tables[0].Rows[j_0]["jdcs_name"].ToString();
                            tV_jd_select.Nodes["Tn_qymc"].Nodes["lh" + i_0.ToString()].Nodes.Add(TN);
                        }
                    }
                }
            }
            tV_jd_select.ExpandAll();
            DS_temp_1.Clear();
            DS_temp_1.Dispose();
        }
        private void add_res_cond()
        {
            DataSet DS_temp_2 = B_Common.GetList("select distinct jdlh,jdlh_name from Ffjzt", "id>=0 order by jdlh");
            if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_2.Tables[0].Rows.Count; i_0++)
                {
                    cB_jdlh.Items.Add(DS_temp_2.Tables[0].Rows[i_0]["jdlh_name"].ToString());
                }
                cB_jdlh.Text = DS_temp_2.Tables[0].Rows[0]["jdlh_name"].ToString();
            }

            DS_temp_2 = B_Common.GetList("select fjrb from Ffjrb", "id>=0 order by fjrb");
            if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_2.Tables[0].Rows.Count; i_0++)
                {
                    cB_fjrb.Items.Add(DS_temp_2.Tables[0].Rows[i_0]["fjrb"].ToString());
                }
            }
            cB_zyzt.Items.Add(common_file.common_fjzt.gjf);
            cB_zyzt.Items.Add(common_file.common_fjzt.zf);
            cB_zyzt.Items.Add(common_file.common_fjzt.zzf);
            cB_zyzt.Items.Add(common_file.common_fjzt.wxf);
            cB_zyzt.Items.Add(common_file.common_fjzt.qtf);
            cB_zyzt.Items.Add(common_file.common_fjzt.ydf);
            DS_temp_2.Clear();
            DS_temp_2.Dispose();

        }
        private void Ffjzt_pic_big_Load(object sender, EventArgs e)
        {
            //this.HorizontalScroll.Enabled = false;
            //p_pic.HorizontalScroll.Enabled = false;
            //Ffjzt.common_form.Ffjzt_pic_big_new = this;
            add_jd_treeview();
            add_res_cond();
            canceal_panel_0(uC_jd_tv, e);//隐藏图形提示
            canceal_panel_0(uC_jd_fr, e);//隐藏图形提示
            this.MouseWheel += new MouseEventHandler(panel_mouseWhell);
        }
        private void MS_set_wx_Click(object sender, EventArgs e)
        {
            set_wx_other(common_file.common_fjzt.wxf);
        }
        /// <summary>
        /// 设置维修和其他房
        /// </summary>
        /// <param name="wx_other"></param>
        public void set_wx_other(string wx_other)
        {
            common_file.common_app.get_czsj();
            if (UC_room_pic_0_select != null)
            {
                string fjbh_temp = UC_room_pic_0_select.MP_roomno;
                DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    common_file.common_app.get_czsj();
                    Ffjzt.Fwx_other_browse Fwx_other_browse_new = new Fwx_other_browse(DS_temp.Tables[0].Rows[0]["fjrb"].ToString(), DS_temp.Tables[0].Rows[0]["fjbh"].ToString());
                    Fwx_other_browse_new.zyzt = wx_other;
                    Fwx_other_browse_new.Left = 100;
                    Fwx_other_browse_new.Top = 150;
                    Fwx_other_browse_new.ShowDialog();
                    Cursor.Current = Cursors.Default;
                }
                DS_temp.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }
        private void b_no_Click(object sender, EventArgs e)
        {
            timer_update_fjzt.Enabled = false;
            this.Close();
            this.Dispose();
        }
        private void MSC_set_wx_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("C_szwxf", common_file.common_app.user_type) == false)
            { return; }
            set_wx_other(common_file.common_fjzt.wxf);
        }
        private void MSC_set_other_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("C_szqtf", common_file.common_app.user_type) == false)
            { return; }
            set_wx_other(common_file.common_fjzt.qtf);
        }
        /// <summary>
        /// 设置干净和脏房
        /// </summary>
        /// <param name="zyzt"></param>
        /// <param name="zyzt_bz"></param>
        private void MSC_set_gj_zf(string zyzt, string zyzt_bz, bool is_judge)
        {
            common_file.common_app.get_czsj();
            for (int i = list_rooms.Count-1; i>=0; i--)
            {
                UC_room_pic_0_select = list_rooms[i];
                if (UC_room_pic_0_select != null)
                {
                    string fjbh_temp = UC_room_pic_0_select.MP_roomno;
                    int i_0 = 4;//判断能否改，不能改值为5；
                    DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        if (is_judge == true)
                        {
                            if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                            {
                                i_0 = 5;
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，在住状态不能直接改成" + zyzt_bz);
                            }
                            else
                                if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.wxf || DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.qtf)
                                {
                                    i_0 = 5;
                                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "您是否真的要把当前维修或其他状态改成" + zyzt_bz + "！") == true)
                                    {
                                        i_0 = 4;
                                    }

                                }
                                else
                                    if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == zyzt_bz)
                                    { i_0 = 5; }
                        }
                        else
                        {
                            i_0 = 5;
                            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "您是否真的要强行清理此房间，清理完房态将被初始成" + zyzt_bz + "！") == true)
                            {
                                i_0 = 4;
                            }
                        }
                        if (i_0 == 4)
                        {
                            common_file.common_app.get_czsj();
                            //string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                            object[] args = new object[8];
                            args[0] = DS_temp.Tables[0].Rows[0]["id"].ToString();
                            args[1] = common_file.common_app.yydh;
                            args[2] = common_file.common_app.qymc;
                            args[3] = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                            args[4] = zyzt;
                            args[5] = common_file.common_app.czy;
                            args[6] = DateTime.Now;
                            args[7] = common_file.common_app.xxzs;

                            string result = common_file.common_app.get_failure;
                            Hotel_app.Server.Ffjzt.Fgj_z_yj_zzzf Fgj_z_yj_zzzf_services = new Hotel_app.Server.Ffjzt.Fgj_z_yj_zzzf();
                            result = Fgj_z_yj_zzzf_services.set_gj_zf_yj_zzzf_qxzz(DS_temp.Tables[0].Rows[0]["id"].ToString(), common_file.common_app.yydh,
                            common_file.common_app.qymc,DS_temp.Tables[0].Rows[0]["fjbh"].ToString(),zyzt,common_file.common_app.czy,
                            DateTime.Now,common_file.common_app.xxzs);
                            if (result != null && result== common_file.common_app.get_suc)
                            {
                                DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                                common_file.common_room_state.room_state(UC_room_pic_0_select, DS_temp, 0);
                                list_rooms.Remove(UC_room_pic_0_select);
                                //恢复本未选中的状态
                                changeColor(UC_room_pic_0_select, false);
                            }

                        }

                    }
                    DS_temp.Dispose();
                }
            }

            Cursor.Current = Cursors.Default;
        }
        private void MSC_set_gj_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("C_szgjf", common_file.common_app.user_type) == false)
            { return; }
            MSC_set_gj_zf("gj", common_file.common_fjzt.gjf, true);

        }
        private void MSC_set_zf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("C_szzf", common_file.common_app.user_type) == false)
            { return; }
            MSC_set_gj_zf("zf", common_file.common_fjzt.zf, true);
        }
        /// <summary>
        /// 设置已洁和在住脏房和临时占用房
        /// </summary>
        /// <param name="yl_zyzt"></param>
        /// <param name="xz_zyzt"></param>
        /// <param name="zyzt_bz"></param>
        private void MSC_set_yj_zzzf(string yl_zyzt, string yl_zybz, string xz_zyzt, string zyzt_bz)
        {
            common_file.common_app.get_czsj();
            foreach (var tmpUc in list_rooms)
            {
                UC_room_pic_0_select = tmpUc;
                #region 设置在住脏房
                if (UC_room_pic_0_select != null)
                {
                    int i_0 = 4;//判断能否改，不能改值为5；
                    string fjbh_temp = UC_room_pic_0_select.MP_roomno;
                    DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        if (xz_zyzt != "lszyf")
                        {
                            if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() != yl_zyzt)
                            {
                                i_0 = 5;
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,房间:" + fjbh_temp + "在非" + yl_zyzt + "状态不能直接改成" + zyzt_bz + "！");
                            }
                        }
                        if (xz_zyzt == "lszyf")
                        {
                            {
                                if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() != common_file.common_fjzt.gjf && DS_temp.Tables[0].Rows[0]["zyzt"].ToString() != common_file.common_fjzt.zf)
                                {
                                    i_0 = 5;
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,房间:" + fjbh_temp + "非" + common_file.common_fjzt.gjf + "或" + common_file.common_fjzt.zf + "状态不能直接改成" + zyzt_bz + "！");
                                }
                            }
                        }
                        if (i_0 == 4)
                        {
                            if (DS_temp.Tables[0].Rows[0]["zybz"].ToString() == yl_zybz)
                            {
                                i_0 = 5;
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房间"+ fjbh_temp + "已经是" + zyzt_bz + "了！");

                            }

                        }
                        if (i_0 == 4)
                        {
                            common_file.common_app.get_czsj();

                            object[] args = new object[8];
                            args[0] = DS_temp.Tables[0].Rows[0]["id"].ToString();
                            args[1] = common_file.common_app.yydh;
                            args[2] = common_file.common_app.qymc;
                            args[3] = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                            args[4] = xz_zyzt;
                            args[5] = common_file.common_app.czy;
                            args[6] = DateTime.Now;
                            args[7] = common_file.common_app.xxzs;

                            string result = common_file.common_app.get_failure;
                            Hotel_app.Server.Ffjzt.Fgj_z_yj_zzzf Fgj_z_yj_zzzf_services = new Hotel_app.Server.Ffjzt.Fgj_z_yj_zzzf();
                            result = Fgj_z_yj_zzzf_services.set_gj_zf_yj_zzzf_qxzz(DS_temp.Tables[0].Rows[0]["id"].ToString(), common_file.common_app.yydh,
                            common_file.common_app.qymc, DS_temp.Tables[0].Rows[0]["fjbh"].ToString(), xz_zyzt, common_file.common_app.czy,
                            DateTime.Now, common_file.common_app.xxzs);

                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "set_gj_zf_yj_zzzf_qxzz", args);
                            if (result == common_file.common_app.get_suc)
                            {
                                DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                                common_file.common_room_state.room_state(UC_room_pic_0_select, DS_temp, 0);
                            }
                        }
                    }
                }
                #endregion
            }



            Cursor.Current = Cursors.Default;
        }
        private void MSC_set_yj_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("C_szyjf", common_file.common_app.user_type) == false)
            { return; }
            MSC_set_yj_zzzf(common_file.common_fjzt.zf, common_file.common_fjzt.yjf, "yj", "已洁房");

        }
        private void MSC_set_zzzf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("C_szzzzf", common_file.common_app.user_type) == false)
            { return; }
            MSC_set_yj_zzzf(common_file.common_fjzt.zzf, common_file.common_fjzt.yjf, "zzzf", "在住脏房");
        }
        private void MSC_set_qx_zzzf_lszy(string xzzt)
        {

            common_file.common_app.get_czsj();
            for (int i = list_rooms.Count-1; i >= 0;i-- )
            {
                UC_room_pic_0_select = list_rooms[i];
                #region 取消在住脏房,设置在住己洁房
                if (UC_room_pic_0_select != null)
                {
                    int i_0 = 4;//判断能否改，不能改值为5；
                    string fjbh_temp = UC_room_pic_0_select.MP_roomno;
                    DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        if (xzzt == "qxlszyf")
                        {
                            if ((DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zf || DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.gjf) && DS_temp.Tables[0].Rows[0]["zybz"].ToString() == common_file.common_fjzt.lszy)
                            {
                                //i_0 = 4; 
                            }
                            else
                            {
                                i_0 = 5;
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，临时占用房才能取消！");
                            }
                        }
                        else
                        {
                            if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zzf && DS_temp.Tables[0].Rows[0]["zybz"].ToString() == common_file.common_fjzt.yjf)
                            {
                                //i_0 = 4; 
                            }
                            else
                            {
                                i_0 = 5;
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，在住房在打扫时才能取消！");
                            }
                        }
                        if (i_0 == 4)
                        {
                            common_file.common_app.get_czsj();
                            //string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                            object[] args = new object[8];
                            args[0] = DS_temp.Tables[0].Rows[0]["id"].ToString();
                            args[1] = common_file.common_app.yydh;
                            args[2] = common_file.common_app.qymc;
                            args[3] = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                            args[4] = xzzt;
                            args[5] = common_file.common_app.czy;
                            args[6] = DateTime.Now;
                            args[7] = common_file.common_app.xxzs;

                            string result = common_file.common_app.get_failure;
                            Hotel_app.Server.Ffjzt.Fgj_z_yj_zzzf Fgj_z_yj_zzzf_services = new Hotel_app.Server.Ffjzt.Fgj_z_yj_zzzf();
                            result = Fgj_z_yj_zzzf_services.set_gj_zf_yj_zzzf_qxzz(DS_temp.Tables[0].Rows[0]["id"].ToString(), common_file.common_app.yydh,
                            common_file.common_app.qymc, DS_temp.Tables[0].Rows[0]["fjbh"].ToString(), xzzt, common_file.common_app.czy,
                            DateTime.Now, common_file.common_app.xxzs);

                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "set_gj_zf_yj_zzzf_qxzz", args);
                            if (result == common_file.common_app.get_suc)
                            {
                                DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                                common_file.common_room_state.room_state(UC_room_pic_0_select, DS_temp, 0);
                            }
                        }


                    }
                }
                #endregion               
                changeColor(list_rooms[i], false);
                list_rooms.Remove(list_rooms[i]);
            }


            Cursor.Current = Cursors.Default;

        }
        private void MSC_qx_zzzf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("MSC_qx_zzzf", common_file.common_app.user_type) == false)
            { return; }
            MSC_set_qx_zzzf_lszy("qxzz");
        }
        private void MS_sxft_Click(object sender, EventArgs e)
        {

            refresh_app("Ffjzt", "",true);

        }
        private void MS_set_lf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("MS_set_lf", common_file.common_app.user_type) == false)
            { return; }
            common_file.common_app.get_czsj();
            if (UC_room_pic_0_select != null)
            {
                string fjbh_temp = UC_room_pic_0_select.MP_roomno;
                string lsbh_temp = "";
                string yddj_temp = "";
                string lfbh_temp = "";
                DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    common_file.common_app.get_czsj();
                    if (DS_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                    {
                        DS_temp = B_Common.GetList("select * from View_Qskzd ", " yddj='" + common_file.common_yddj.yddj_dj + "' and fjbh='" + DS_temp.Tables[0].Rows[0]["fjbh"].ToString() + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_app.get_czsj();
                            lsbh_temp = DS_temp.Tables[0].Rows[0]["lsbh"].ToString();
                            fjbh_temp = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                            yddj_temp = DS_temp.Tables[0].Rows[0]["yddj"].ToString();
                            DS_temp = B_Common.GetList("select * from Flfsz ", "  lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                lfbh_temp = DS_temp.Tables[0].Rows[0]["lfbh"].ToString();
                            }
                            Ffjzt.Flfsz Flfsz_new = new Flfsz(lfbh_temp, lsbh_temp, fjbh_temp, yddj_temp);
                            Flfsz_new.Left = 100;
                            Flfsz_new.Top = 150;
                            Flfsz_new.ShowDialog();
                        }
                        return;
                    }
                    if (DS_temp.Tables[0].Rows[0]["zyzt_second"].ToString() == common_file.common_fjzt.ydf)
                    {
                        DS_temp = B_Common.GetList("select * from View_Qskzd ", " yddj='" + common_file.common_yddj.yddj_yd + "' and fjbh='" + DS_temp.Tables[0].Rows[0]["fjbh"].ToString() + "' and ddsj='" + DS_temp.Tables[0].Rows[0]["yd_ddsj"].ToString() + "' and lksj='" + DS_temp.Tables[0].Rows[0]["yd_lksj"].ToString() + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_app.get_czsj();
                            lsbh_temp = DS_temp.Tables[0].Rows[0]["lsbh"].ToString();
                            fjbh_temp = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                            yddj_temp = DS_temp.Tables[0].Rows[0]["yddj"].ToString();
                            DS_temp = B_Common.GetList("select * from Flfsz ", "  lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                lfbh_temp = DS_temp.Tables[0].Rows[0]["lfbh"].ToString();
                            }
                            Ffjzt.Flfsz Flfsz_new = new Flfsz(lfbh_temp, lsbh_temp, fjbh_temp, yddj_temp);
                            Flfsz_new.Left = 100;
                            Flfsz_new.Top = 150;
                            Flfsz_new.ShowDialog();
                        }
                        return;
                    }

                    Cursor.Current = Cursors.Default;

                }
                DS_temp.Dispose();
            }
            Cursor.Current = Cursors.Default;
        }
        public void get_remind_info_yddj(string zyzt, string zyzt_second,bool  IsVisibleGb_yd,string fjbh_0)
        {
            //int height_add = 0; int height_down = 78; int height_0 = 0;
            DataSet DS_temp_1 = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_0 + "'");
            if (zyzt == common_file.common_fjzt.zzf)
            {
                DS_temp_1 = B_Common.GetList("select * from View_Qskzd", "yddj='" + common_file.common_yddj.yddj_dj + "' and fjbh='" + fjbh_0 + "'");
            }
            if (zyzt == common_file.common_fjzt.ydf)
            {
                DS_temp_1 = B_Common.GetList("select * from View_Qskzd", "yddj='" + common_file.common_yddj.yddj_yd + "' and fjbh='" + fjbh_0 + "'");
            }
            DataSet DS_temp_2 = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_0 + "'");
            if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
            {
                common_file.common_app.get_czsj();

                l_ddsj.Visible = true; l_ddsj.Text = "到时：";
                li_ddsj.Visible = true;
                li_ddsj.Text = DS_temp_1.Tables[0].Rows[0]["ddsj"].ToString().Substring(0, 10).Equals(common_app.cssj) ? "" : DS_temp_1.Tables[0].Rows[0]["ddsj"].ToString();

                l_lksj.Visible = true; l_lksj.Text = "离时：";
                li_lksj.Visible = true;
                li_lksj.Text = DS_temp_1.Tables[0].Rows[0]["lksj"].ToString().Substring(0, 10).Equals(common_app.cssj) ? "" : DS_temp_1.Tables[0].Rows[0]["lksj"].ToString();

                l_fjjg.Visible = true; l_fjjg.Text = "房价：";
                li_fjjg.Visible = true; li_fjjg.Width = 146;
                //li_fjjg.Text = DS_temp_1.Tables[0].Rows[0]["fjjg"].ToString();
                //首先通过房类获取房价
                try
                {
                    li_fjjg.Text = DbHelperSQL.GetSingle(" select  sjjg  from Ffjrb where  fjrb='" + DS_temp_1.Tables[0].Rows[0]["fjrb"].ToString() + "'").ToString();
                }
                catch 
                {
                    li_fjjg.Text = common_app.li_fjjg_dispalyText;
                }




                //通过房号获取Qskyd_fjrb中的房间价格

                if (!DS_temp_1.Tables[0].Rows[0]["lsbh"].ToString().Equals(""))
                {
                    DataSet ds111 = B_Common.GetList("select * from  Qskyd_fjrb "," id>=0  and  lsbh='" + DS_temp_1.Tables[0].Rows[0]["lsbh"].ToString().Equals("") + "'  and  fjbh='" + DS_temp_1.Tables[0].Rows[0]["fjbh"].ToString().Equals("") + "'");
                    if (ds111 != null && ds111.Tables[0].Rows.Count > 0)
                    {
                        li_fjjg.Text = ds111.Tables[0].Rows[0]["fjjg"].ToString();
                    }
                }
                l_krxm.Visible = true;
                li_krxm.Visible = true;
                li_krxm.Text = DS_temp_1.Tables[0].Rows[0]["krxm"].ToString();

                if (zyzt == common_file.common_fjzt.zzf)
                {
                    DS_temp_2 = B_Common.GetList("select * from Qskyd_mainrecord", " lsbh='" + DS_temp_1.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                    {
                        li_krxm.Text = DS_temp_1.Tables[0].Rows[0]["krxm"].ToString();
                        for (int j_0 = 1; j_0 < DS_temp_2.Tables[0].Rows.Count; j_0++)
                        {
                            li_krxm.Text = li_krxm.Text + "/" + DS_temp_2.Tables[0].Rows[j_0]["krxm"].ToString();
                        }

                    }

                    if (DS_temp_1.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_tt || DS_temp_1.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_hy)
                    {
                        // 团体的名称
                        DataSet ds_tt_temp_0 = B_Common.GetList(" select * from View_Qttzd ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  ddbh='" + DS_temp_1.Tables[0].Rows[0]["ddbh"].ToString() + "'");
                        if (ds_tt_temp_0 != null && ds_tt_temp_0.Tables[0].Rows.Count > 0)
                        {

                            li_krxm.Text = "[团名:" + ds_tt_temp_0.Tables[0].Rows[0]["krxm"].ToString() + "]" + li_krxm.Text;
                        }
                    }
                }

                DS_temp_2 = B_Common.GetList("select * from Flfsz", "lfbh in (select lfbh from Flfsz where lsbh='" + DS_temp_1.Tables[0].Rows[0]["lsbh"].ToString() + "') and fjbh<>''");
                if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                {
                    l_lf.Visible = true; tB_lf.Visible = true;
                    tB_lf.Text = DS_temp_2.Tables[0].Rows[0]["fjbh"].ToString();
                    for (int j_0 = 1; j_0 < DS_temp_2.Tables[0].Rows.Count; j_0++)
                    {
                        tB_lf.Text = tB_lf.Text + "/" + DS_temp_2.Tables[0].Rows[j_0]["fjbh"].ToString();
                    }
                }
                DS_temp_2 = B_Common.GetList("select * from Flfsz", "lfbh in (select lfbh from Flfsz where lsbh='" + DS_temp_1.Tables[0].Rows[0]["lsbh"].ToString() + "') and shlz=1 and fjbh<>''");
                if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                {
                    l_lz.Visible = true; tB_lz.Visible = true;
                    tB_lz.Text = DS_temp_2.Tables[0].Rows[0]["fjbh"].ToString();
                    for (int j_0 = 1; j_0 < DS_temp_2.Tables[0].Rows.Count; j_0++)
                    {
                        tB_lz.Text = tB_lz.Text + "/" + DS_temp_2.Tables[0].Rows[j_0]["fjbh"].ToString();
                    }
                }

                if (zyzt_second.Equals(common_fjzt.ydf))
                {
                    DS_temp_1 = B_Common.GetList("select * from View_Qskzd", "yddj='" + common_file.common_yddj.yddj_yd+ "' and fjbh='" + fjbh_0 + "'");
                    bS_yd.DataSource = DS_temp_1.Tables[0];
                }
            }
        }
        public void get_remind_info(string fjbh_0,Hotel_app.control_user.UC_room_pic_0  infoTmpUC)
        {
            //这里分三块显示
            int width_p = 460; int height_p = 125;//显示上部提示信息
            int spanHeigh = 30;
            l_lf.Visible = false; l_lz.Visible = false;
            tB_lf.Visible = false; tB_lz.Visible = false;
            gB_yd.Visible = false;
            DataSet DS_temp_0 = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_0 + "'");
            DataSet DS_temp_2 = null;
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                li_fjbh.Text = DS_temp_0.Tables[0].Rows[0]["fjbh"].ToString();
                li_fjrb.Text = DS_temp_0.Tables[0].Rows[0]["fjrb"].ToString();
                li_fjdh.Text = DS_temp_0.Tables[0].Rows[0]["fjdh"].ToString();
                li_dhfj.Text = DS_temp_0.Tables[0].Rows[0]["dhfj"].ToString();
                li_bz.Text = DS_temp_0.Tables[0].Rows[0]["bz"].ToString();

                //通过房态来增加相应的高度
                //干净房,脏房，修改房，其它房的信息显示
                string fjzt = DS_temp_0.Tables[0].Rows[0]["zyzt"].ToString();
                string fjzt_second = DS_temp_0.Tables[0].Rows[0]["zyzt_second"].ToString();

                if (fjzt.Equals(common_file.common_fjzt.gjf) || fjzt.Equals(common_file.common_fjzt.wxf) || fjzt.Equals(common_file.common_fjzt.zf) || fjzt.Equals(common_file.common_fjzt.qtf))
                {
                    li_krxm.Text = "暂无";
                    li_fjjg.Text = common_app.li_fjjg_dispalyText;
                    l_ddsj.Text = "初始："; l_lksj.Visible = true; l_lksj.Text = "结束：";
                    li_ddsj.Text = ""; li_lksj.Text = "";
                    //显示预订信息
                    if (fjzt_second.Equals(common_file.common_fjzt.ydf))
                    {
                        gB_yd.Visible = true;
                        height_p = height_p + 126;
                        gB_yd.Location = new Point(l_bz.Left, l_bz.Top + spanHeigh);

                    }

                }

                //加一块显示金额的内容
                if(fjzt.Equals(common_file.common_fjzt.zzf)||(!fjzt.Equals(common_file.common_fjzt.zzf)&&fjzt_second.Equals(common_file.common_fjzt.ydf)))
                {
                    height_p += p_info_Two.Height;
                }

                if (fjzt.Equals(common_file.common_fjzt.zzf))
                {
                    //判断是否联房
                    bool shlf = false; bool shlz = false;
                    DS_temp_2 = B_Common.GetList("select * from Qskyd_mainrecord", " lsbh='" + DS_temp_0.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                    if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                    {
                        li_krxm.Text = DS_temp_0.Tables[0].Rows[0]["krxm"].ToString();
                        for (int j_0 = 1; j_0 < DS_temp_2.Tables[0].Rows.Count; j_0++)
                        {
                            li_krxm.Text = li_krxm.Text + "/" + DS_temp_2.Tables[0].Rows[j_0]["krxm"].ToString();
                        }

                    }

                    if (DS_temp_0.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_tt || DS_temp_0.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_hy)
                    {
                        // 团体的名称
                        DataSet ds_tt_temp_0 = B_Common.GetList(" select * from View_Qttzd ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  ddbh='" + DS_temp_2.Tables[0].Rows[0]["ddbh"].ToString() + "'");
                        if (ds_tt_temp_0 != null && ds_tt_temp_0.Tables[0].Rows.Count > 0)
                        {

                            li_krxm.Text = "[" + ds_tt_temp_0.Tables[0].Rows[0]["krxm"].ToString() + "]" + li_krxm.Text;
                        }
                    }


                    DS_temp_2 = B_Common.GetList("select * from Flfsz", "lfbh in (select lfbh from Flfsz where lsbh='" + DS_temp_0.Tables[0].Rows[0]["lsbh"].ToString() + "')    and fjbh<>''");
                    if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                    {
                        tB_lf.Text = "";//清空原来的
                        l_lf.Visible = true; tB_lf.Visible = true; shlf = true;
                        tB_lf.Text = DS_temp_2.Tables[0].Rows[0]["fjbh"].ToString();
                        for (int j_0 = 1; j_0 < DS_temp_2.Tables[0].Rows.Count; j_0++)
                        {
                            if (tB_lf.Text.Trim().Equals(""))
                            { tB_lf.Text =DS_temp_2.Tables[0].Rows[j_0]["fjbh"].ToString(); }
                            else
                            {
                                tB_lf.Text = tB_lf.Text + "/" + DS_temp_2.Tables[0].Rows[j_0]["fjbh"].ToString();
                            }
                        }
                        height_p += spanHeigh;
                    }

                    //判断联房联帐
                    DS_temp_2 = B_Common.GetList("select * from Flfsz", "lfbh in (select lfbh from Flfsz where lsbh='" + DS_temp_0.Tables[0].Rows[0]["lsbh"].ToString() + "') and shlz=1 and fjbh<>''");
                    if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                    {
                        tB_lz.Text = "";
                        l_lz.Visible = true; tB_lz.Visible = true; shlz = true;
                        tB_lz.Text = DS_temp_2.Tables[0].Rows[0]["fjbh"].ToString();
                        for (int j_0 = 1; j_0 < DS_temp_2.Tables[0].Rows.Count; j_0++)
                        {
                            if (tB_lz.Text.Trim().Equals(""))
                            { tB_lz.Text = DS_temp_2.Tables[0].Rows[j_0]["fjbh"].ToString(); }
                            else
                            {
                                tB_lz.Text = tB_lz.Text + "/" + DS_temp_2.Tables[0].Rows[j_0]["fjbh"].ToString();
                            }
                        }
                        height_p += spanHeigh;
                    }
                    if (fjzt_second.Equals(common_file.common_fjzt.ydf))
                    {
                        gB_yd.Visible = true;
                        if (shlz)
                        {
                            gB_yd.Location = new Point(l_lz.Left, l_lz.Top + spanHeigh);
                        }
                        else
                        {
                            if (shlf)
                            {
                                gB_yd.Location = new Point(l_lf.Left, l_lf.Top + spanHeigh);
                            }
                            else
                            {
                                gB_yd.Location = new Point(l_bz.Left, l_bz.Top + spanHeigh);
                            }
                        }
                        height_p += 126;
                    }
                    //if (gB_yd.Visible)
                    //{
                        get_remind_info_yddj(fjzt,fjzt_second,gB_yd.Visible, fjbh_0);
                   // }
                }
                get_remind_info_yddj(fjzt, fjzt_second, gB_yd.Visible, fjbh_0);

                            //这里判断是否要显示金额
            if(fjzt.Equals(common_fjzt.zzf)||(!fjzt.Equals(common_fjzt.zzf)&&fjzt_second.Equals(common_fjzt.ydf)))
            {
                p_info_Two.Visible = true;
                BLL.Szwzd  B_szwzd=new BLL.Szwzd();
                List<Model.Szwzd> list_0;
                Model.Szwzd M_szwzd = null;
                if(fjzt.Equals(common_fjzt.zzf))
                {
                    list_0 = B_szwzd.GetModelList(" id>=0  and  yddj='" + common_yddj.yddj_dj + "' and  fjbh='" + fjbh_0 + "'  and yydh='" + common_app.yydh + "'");
                    if (list_0 != null && list_0.Count > 0)
                    {
                        M_szwzd = list_0[0];
                        btn_ysk.Text = M_szwzd.fkje.ToString();
                        btn_xf.Text = M_szwzd.xfje.ToString();
                        btn_ts.Text = (DateTime.Now - DateTime.Parse(li_ddsj.Text.Trim())).TotalDays < 0.1 ? "刚入住" : common_sswl.Round_sswl((DateTime.Now - DateTime.Parse(li_ddsj.Text.Trim())).TotalDays, 1, common_sswl.selectMode_normal).ToString();
                        try
                        {
                            if (M_szwzd.fkje - M_szwzd.xfje < decimal.Parse(li_fjjg.Text.Trim()))
                            {
                                btn_cy.Text = "建议催押";
                            }
                            else
                            {
                                btn_cy.Text = "不需要";
                            }
                        }
                        catch 
                        {
                            btn_cy.Text = "当前房型没有在fjrb表中配置房价,请检查"; 
                        }

                    }
                }
                else
                {
                    list_0 = B_szwzd.GetModelList(" id>=0  and  yddj='" + common_yddj.yddj_yd + "' and  fjbh='" + fjbh_0 + "'  and yydh='" + common_app.yydh + "'");
                    if (list_0 != null && list_0.Count > 0)
                    {
                        M_szwzd = list_0[0];
                        btn_ysk.Text = M_szwzd.fkje.ToString();
                        btn_xf.Text = M_szwzd.xfje.ToString();
                        btn_ts.Text = "预订态";
                        btn_cy.Text = "预订态";
                    }
                }
            }

            }
            p_remind_w.Width = width_p; p_remind_w.Height = height_p;
            Point p_new =p_in.PointToClient(new Point(common_file.common_app.x(), common_file.common_app.y()));
            p_remind_w.Left = common_file.common_app.x() - this.Left;
            p_remind_w.Top =common_file.common_app.y() - this.Top - 150;


            if (p_remind_w.Top + p_remind_w.Height + 10 > p_pic.Height)
            {
                p_remind_w.Top =p_remind_w.Top - ((p_remind_w.Top + p_remind_w.Height + 10) - p_pic.Height);
            }
            if (p_remind_w.Left + p_remind_w.Width + 10 > p_pic.Width)
            {
                p_remind_w.Left = p_remind_w.Left - ((p_remind_w.Left + p_remind_w.Width+5 ) - p_pic.Width);
            }
            Rectangle rc = new Rectangle(p_remind_w.Location, new Size(p_remind_w.Width, p_remind_w.Height));
            if (rc.Contains(p_new))
            {
                p_remind_w.Left = p_new.X - p_remind_w.Width;
                p_remind_w.Top = p_new.Y - p_remind_w.Height;

                if (p_remind_w.Top < 0)
                {
                    p_remind_w.Left = p_new.X - 450;
                    p_remind_w.Top = p_new.Y + 10;
                }
            }
            p_remind_w.Visible = true;
            p_remind_w.BringToFront();
            if (p_info_Two.Visible)
            { p_info_Two.BringToFront(); }
        }
        private void uc_room_pic_MouseHover(object sender, EventArgs e)
        {
            Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_temp = (Hotel_app.control_user.UC_room_pic_0)sender;
            if (UC_room_pic_0_temp != null)
            {
                get_remind_info(UC_room_pic_0_temp.MP_roomno,UC_room_pic_0_temp);
            }

        }
        private void uc_room_pic_MouseLeave(object sender, EventArgs e)
        {
            p_remind_w.Visible = false;
           // p_info_Two.Visible = false;
        }
        private void dg_yd_DoubleClick(object sender, EventArgs e)
        {

            if (dg_count_yd > 0 && dg_yd.CurrentRow.Index < dg_count_yd && DS_Qsk != null && DS_Qsk.Tables[0].Rows[dg_yd.CurrentRow.Index]["id"].ToString() != "")
            {
                common_file.common_form.Qskdj_new_open(DS_Qsk.Tables[0].Rows[dg_yd.CurrentRow.Index]["id"].ToString(), DS_Qsk.Tables[0].Rows[dg_yd.CurrentRow.Index]["yddj"].ToString(), common_file.common_app.get_edit, common_file.common_app.main_sec_main);

            }
        }
        private void MS_szjcf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("MS_szjcf", common_file.common_app.user_type) == false)
            {
                return;
            }
            MSC_set_yj_zzzf(common_file.common_fjzt.zf + " " + common_file.common_fjzt.gjf, common_file.common_fjzt.lszy, "lszyf", "在住脏房");
        }
        private void MS_qx_jcf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("C_szgjf", common_file.common_app.user_type) == false)
            {
                return;
            }
            MSC_set_qx_zzzf_lszy("qxlszyf");
        }
        private void update_timetick_fjzt()
        {
            DateTime DT_update_fjzt_temp = DateTime.Now;
            timer_update_fjzt.Enabled = false;
            string s_1 = "id>=0" + common_file.common_app.yydh_select + select_update_cond + " and czsj>='" + DT_update_fjzt.ToString() + "' order by jdlh,jdcs,fjbh";
            DS_update_fjzt = B_Common.GetList("select * from Ffjzt", s_1);
            DT_update_fjzt = DT_update_fjzt_temp;
            if (DS_update_fjzt != null && DS_update_fjzt.Tables[0].Rows.Count > 0)
            {
                for (int j_0 = 0; j_0 < DS_update_fjzt.Tables[0].Rows.Count; j_0++)
                {
                    if (p_pic.Controls.Count > 0)
                    {
                        for (int i_0 = 0; i_0 < p_pic.Controls.Count; i_0++)
                        {

                            //if (p_pic.Controls[i_0].Name.ToString() != "p_remind_w" && p_pic.Controls[i_0].Controls.Count > 0 && p_pic.Controls[i_0].Controls.GetType().ToString()=="System.Windows.Forms.Panel")
                            if (p_pic.Controls[i_0].Name.ToString() != "p_remind_w" && p_pic.Controls[i_0].Controls.Count > 0)
                            {
                                for (int k_0 = 0; k_0 < p_pic.Controls[i_0].Controls.Count; k_0++)
                                {
                                    if (p_pic.Controls[i_0].Controls[k_0].Name.ToString() == "UC" + DS_update_fjzt.Tables[0].Rows[j_0]["fjbh"].ToString())
                                    {
                                        common_file.common_room_state.room_state((Hotel_app.control_user.UC_room_pic_0)p_pic.Controls[i_0].Controls[k_0], DS_update_fjzt, j_0);
                                        break;
                                    }
                                }
                            }
                        }

                    }
                }

            }
            getcount("Ffjzt", "");
            timer_update_fjzt.Enabled = true;

        }
        private void timer_update_fjzt_Tick(object sender, EventArgs e)
        {
            timer_update_fjzt.Enabled = false;
            try
            {
                update_timetick_fjzt();
                if (DateTime.Now > DateTime.Parse(DateTime.Now.ToShortDateString()) && DateTime.Now < DateTime.Parse(DateTime.Now.ToShortDateString() + " 00:03:00"))
                {
                    common_Ffjzt.add_wx_yd();
                }
                timer_update_fjzt.Enabled = true;
            }
            catch
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，自动刷新执行不成功，自动刷新已经关闭！请把此窗口关掉再重新打开！");
                this.Close();
            }
        }
        private void p_gj_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and zyzt='" + common_file.common_fjzt.gjf + "'",false);
        }
        private void p_zf_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and zyzt='" + common_file.common_fjzt.zf + "'", false);
        }
        private void p_ls_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and (zyzt='" + common_file.common_fjzt.zf + "' or zyzt='" + common_file.common_fjzt.gjf + "') and zybz='" + common_file.common_fjzt.lszy + "'", false);
        }
        private void p_wx_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and zyzt='" + common_file.common_fjzt.wxf + "'", false);
        }
        private void p_zz_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and zyzt='" + common_file.common_fjzt.zzf + "'", false);

        }
        private void p_yd_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and zyzt_second='" + common_file.common_fjzt.ydf + "'", false);
        }
        private void p_qt_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and zyzt='" + common_file.common_fjzt.qtf + "'", false);
        }
       private void l_fj_count_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", "",false);
            
        }
        private void p_ds_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and (zyzt='" + common_file.common_fjzt.zf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and zybz='" + common_file.common_fjzt.yjf + "'",false);
        }
        private void p_ts_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and (zyzt_second='" + common_file.common_fjzt.ydf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and shts=1",false);
        }
        private void p_drdd_Click(object sender, EventArgs e)
        {
            //if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
            refresh_app("Ffjzt", " and (zyzt_second='" + common_file.common_fjzt.ydf + "') and (yd_ddsj>='" + DateTime.Now.ToShortDateString() + "' and yd_ddsj<'" + DateTime.Now.Date.AddDays(1).ToShortDateString() + "')",false);
        }
        private void p_drld_Click(object sender, EventArgs e)
        {
            //if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString()) < DateTime.Now.Date.AddDays(1))
            refresh_app("Ffjzt", " and (zyzt='" + common_file.common_fjzt.zzf + "') and (lksj>='" + DateTime.Now.ToShortDateString() + "' and lksj<'" + DateTime.Now.Date.AddDays(1).ToShortDateString() + "')",false);
        }
        private void p_lz_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and (zyzt_second='" + common_file.common_fjzt.ydf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and shlf=1", false);
        }
        private void p_vip_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and (zyzt_second='" + common_file.common_fjzt.ydf + "' or zyzt='" + common_file.common_fjzt.zzf + "') and shvip=1", false);
        }
        private void p_cqld_Click(object sender, EventArgs e)
        {
            refresh_app("Ffjzt", " and (zyzt='" + common_file.common_fjzt.zzf + "') and ( lksj<'" + DateTime.Now.ToShortDateString() + "')", false);
        }
        private void tV_jd_select_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tV_jd_select.SelectedNode.Level == 0)
            {
                refresh_app("Ffjzt", "", false);
            }
            else
                if (tV_jd_select.SelectedNode.Level == 1)
                {
                    refresh_app("Ffjzt", " and jdlh='" + tV_jd_select.SelectedNode.Tag + "'" + common_file.common_app.yydh_select, false);
                }
                else
                    if (tV_jd_select.SelectedNode.Level == 2)
                    {
                        refresh_app("Ffjzt", " and jdlh='" + tV_jd_select.SelectedNode.Parent.Tag + "' and jdcs='" + tV_jd_select.SelectedNode.Tag + "'" + common_file.common_app.yydh_select, false);
                    }
        }
        private void MS_dl_fj_Click(object sender, EventArgs e)
        {
            if (UC_room_pic_0_select != null)
            {
                uc_room_pic_DoubleClick(UC_room_pic_0_select, e);
            }
        }
        private void MS_dl_tt_Click(object sender, EventArgs e)
        {
            Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_temp = UC_room_pic_0_select;
            if (UC_room_pic_0_temp != null)
            {
                string fjbh_1 = "";
                fjbh_1 = UC_room_pic_0_temp.MP_roomno;
                DataSet ds_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_1 + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    if (ds_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                    {
                        ds_temp = B_Common.GetList("select ddbh from View_Qskzd", "fjbh='" + fjbh_1 + "' and yddj='" + common_file.common_yddj.yddj_dj + "' and main_sec='" + common_file.common_app.main_sec_main + "'" + common_file.common_app.yydh_select);
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            ds_temp = B_Common.GetList("select id,yddj from Qttyd_mainrecord", "ddbh='" + ds_temp.Tables[0].Rows[0]["ddbh"].ToString() + "'");
                            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_form.Qttdj_new_open(ds_temp.Tables[0].Rows[0]["id"].ToString(), ds_temp.Tables[0].Rows[0]["yddj"].ToString(), common_file.common_app.get_edit, true);
                            }
                        }
                    }
                }
                ds_temp.Clear();
                ds_temp.Dispose();
            }
        }
        private void MSC_clear_fj_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("MSC_clear_fj", common_file.common_app.user_type) == false)
            { return; }
            MSC_set_gj_zf("gj", common_file.common_fjzt.gjf, false);
        }
        private void MSC_set_bz_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("MSC_set_bz", common_file.common_app.user_type) == false)
            { return; }
            common_file.common_app.get_czsj();
            if (UC_room_pic_0_select != null)
            {
                string fjbh_temp = UC_room_pic_0_select.MP_roomno;
                DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_temp + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    string fjbz = "";
                    Qyddj.Q_bz_input Q_bz_input_new = new Qyddj.Q_bz_input();
                    Q_bz_input_new.Text = "请输入房间备注";
                    Q_bz_input_new.Left = 170;
                    Q_bz_input_new.Top = 150;
                    Q_bz_input_new.tB_bz.Text = DS_temp.Tables[0].Rows[0]["bz"].ToString();
                    if (Q_bz_input_new.ShowDialog() == DialogResult.OK)
                    {
                        fjbz = Q_bz_input_new.get_bz;
                    }
                    if (fjbz != "")
                    {
                        common_file.common_app.get_czsj();

                        if (B_Common.ExecuteSql("update Ffjzt set bz='" + fjbz + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh_temp + "'") > 0)
                        {
                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "增加房间备注", fjbh_temp, fjbz, DateTime.Now);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "备注设置成功！");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
        private void ms_kslz_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("C_ksrz", common_file.common_app.user_type) == false)
            { return; }
            string fjbh_temp = "";
            string fjrb_temp = "";
            if (UC_room_pic_0_select != null)
            {
                fjbh_temp = UC_room_pic_0_select.MP_roomno;
                if (UC_room_pic_0_select.MP_room_state == 11 || UC_room_pic_0_select.MP_room_state == 21)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,当前此房间有预订存在,请先检查预订,否则会造成当前房间的预订无法转登记,如果当前的预订不要,请先删除预订,然后再进行快速登记,在没有处理当前房间预订时暂时不能快速入住！");
                    return;
                }
                if (UC_room_pic_0_select.MP_room_state == 1 || UC_room_pic_0_select.MP_room_state == 2)
                {
                    int i = 2;
                    if (UC_room_pic_0_select.MP_room_state == 2)
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "当前房间为脏房,是否能要快速入住?"))
                        {
                            i = 3;
                        }
                    }
                    else
                    {
                        i = 3;
                    }
                    if (i == 3)
                    {
                        DataSet ds_temp_0 = B_Common.GetList("  select  * from Ffjzt ", " yydh='" + common_file.common_app.yydh + "'  and  fjbh='" + fjbh_temp + "'");
                        if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                        {
                            fjrb_temp = ds_temp_0.Tables[0].Rows[0]["fjrb"].ToString();
                            com_ft com_ft_new = new com_ft();
                            com_ft_new.New_fast_skyd(fjrb_temp, fjbh_temp, DateTime.Now);
                            UC_room_pic_0_select.p_range.BackColor = Color.MediumPurple;
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "快速登记出错！");
                        }
                        ds_temp_0.Clear();
                        ds_temp_0.Dispose();
                    }

                }

            }

            Cursor.Current = Cursors.Default;
        }
        //用于前厅临时取消入住的功能补充
        private void MS_qxrz_Click(object sender, EventArgs e)
        {
            Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_temp = UC_room_pic_0_select;
            if (UC_room_pic_0_temp != null)
            {
                string fjbh_1 = "";
                fjbh_1 = UC_room_pic_0_temp.MP_roomno;
                DataSet ds_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_1 + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    if (ds_temp.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                    {
                        ds_temp = B_Common.GetList("select lsbh from View_Qskzd", "fjbh='" + fjbh_1 + "' and yddj='" + common_file.common_yddj.yddj_dj + "' and main_sec='" + common_file.common_app.main_sec_main + "'" + common_file.common_app.yydh_select);
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            com_lsqxrz com_lsqxrz = new com_lsqxrz();
                            com_lsqxrz.lsqxrz(ds_temp.Tables[0].Rows[0]["lsbh"].ToString(), DateTime.Now.ToString());
                        }
                    }
                }
                ds_temp.Clear();
                ds_temp.Dispose();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            getcount(ft_table, ft_sel);
        }
        private void cB_jdcs_DropDown(object sender, EventArgs e)
        {
            cB_jdcs.Items.Clear();
            if (cB_jdlh.Text.Trim() != "")
            {
                DataSet DS_temp_2 = B_Common.GetList("select distinct jdcs,jdcs_name from Ffjzt", "id>=0 and jdlh_name='" + cB_jdlh.Text.Trim() + "' order by jdcs");
                if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                {
                    for (int i_0 = 0; i_0 < DS_temp_2.Tables[0].Rows.Count; i_0++)
                    {
                        cB_jdcs.Items.Add(DS_temp_2.Tables[0].Rows[i_0]["jdcs_name"].ToString());
                    }
                }
                DS_temp_2.Clear();
                DS_temp_2.Dispose();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sel_con_ls = "";
            if (cB_jdlh.Text.Trim() != "")
            {
                sel_con_ls = sel_con_ls + "and jdlh_name='" + cB_jdlh.Text.Trim() + "' ";
                if (cB_jdcs.Text.Trim() != "")
                {
                    sel_con_ls = sel_con_ls + "and jdcs_name='" + cB_jdcs.Text.Trim() + "' ";
                }
            }
            if (cB_fjrb.Text.Trim() != "")
            {
                sel_con_ls = sel_con_ls + "and fjrb='" + cB_fjrb.Text.Trim() + "' ";
            }
            if (cB_zyzt.Text.Trim() != "")
            {
                if (cB_zyzt.Text.Trim() == common_file.common_fjzt.ydf)
                {
                    sel_con_ls = sel_con_ls + "and zyzt_second='" + cB_zyzt.Text.Trim() + "' ";
                }
                else
                {
                    sel_con_ls = sel_con_ls + "and zyzt='" + cB_zyzt.Text.Trim() + "' ";
                }
            }
            if (sel_con_ls != "")
            {
                refresh_app("Ffjzt", sel_con_ls, false);
            }

        }
        void panel_mouseWhell(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            mousePoint.Offset(this.Location.X, this.Location.Y);

            if (p_pic.RectangleToScreen(p_pic.DisplayRectangle).Contains(mousePoint))
            {
                p_pic.AutoScrollPosition = new Point(0, p_pic.VerticalScroll.Value - e.Delta);
            }

        }
        private void MS_ydzdj_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_sk_yd_ydzdj", common_file.common_app.user_type) == false)
            { return; }
            string fjbh_temp = "";
            string fjrb_temp = "";
            if (UC_room_pic_0_select != null)
            {
                fjbh_temp = UC_room_pic_0_select.MP_roomno;
            }
            common_file.common_app.get_czsj();
            DataSet ds_temp_0 = B_Common.GetList("  select  * from Ffjzt ", " yydh='" + common_file.common_app.yydh + "'  and  fjbh='" + fjbh_temp + "' and zyzt_second='" + common_file.common_fjzt.ydf + "' and (zyzt='" + common_file.common_fjzt.gjf + "' or zyzt='" + common_file.common_fjzt.zf + "')");
            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
            {
                ds_temp_0 = B_Common.GetList("select * from View_Qskzd", " fjbh='" + fjbh_temp + "' and fjrb='" + ds_temp_0.Tables[0].Rows[0]["fjrb"].ToString() + "' and ddsj='" + ds_temp_0.Tables[0].Rows[0]["yd_ddsj"].ToString() + "' and lksj='" + ds_temp_0.Tables[0].Rows[0]["yd_lksj"].ToString() + "'  and yddj='" + common_file.common_yddj.yddj_yd + "'");
                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                {
                    common_file.common_app.get_czsj();
                    Qyddj.Qyddj_ydzdj Qyddj_ydzdj_new = new Qyddj.Qyddj_ydzdj();
                    if (Qyddj_ydzdj_new.ydzdj(ds_temp_0.Tables[0].Rows[0]["lsbh"].ToString(), ds_temp_0.Tables[0].Rows[0]["fjbh"].ToString(), ds_temp_0.Tables[0].Rows[0]["ddbh"].ToString(), "sk") == true)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "预订转登记成功！");


                    }
                }

            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请确认是否有符合条件的房间转换！");
            }
            ds_temp_0.Clear();
            ds_temp_0.Dispose();
            Cursor.Current = Cursors.Default;

        }
        //更新于20012-11-29  Am 8:32(此按纽只用来管理用，不开放给除管理员的其它员工)
        //补充一个方法，用于管理员来清除由于自动刷新而产生的错误的预定房态
        private void MSC_Set_qzqcyd_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("MSC_Set_qzqcyd", common_file.common_app.user_type) == false)
            { return; }
            Hotel_app.control_user.UC_room_pic_0 UC_room_pic_0_temp = UC_room_pic_0_select;
            if (UC_room_pic_0_temp != null)
            {
                string fjbh_1 = "";
                fjbh_1 = UC_room_pic_0_temp.MP_roomno;
                DataSet ds_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_1 + "'  and   yydh='" + common_file.common_app.yydh + "'  ");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    if (ds_temp.Tables[0].Rows[0]["zyzt_second"].ToString() == common_file.common_fjzt.ydf)
                    {
                        ds_temp = B_Common.GetList("select lsbh from View_Qskzd", "fjbh='" + fjbh_1 + "' and yddj='" + common_file.common_yddj.yddj_yd + "' and main_sec='" + common_file.common_app.main_sec_main + "'" + common_file.common_app.yydh_select);
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前确实有预订信息存在,不能强制清除,请先检查当前预订是否正确");
                            return;
                        }
                        else//执行清除
                        {
                            Model.Ffjzt M_Ffjzt = new Hotel_app.Model.Ffjzt();
                            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
                            List<Model.Ffjzt> list = new List<Hotel_app.Model.Ffjzt>();
                            list = B_Ffjzt.GetModelList("  yydh='" + common_file.common_app.yydh + "' and  fjbh='" + fjbh_1 + "' ");
                            if (list != null && list.Count > 0)
                            {
                                M_Ffjzt = list[0];
                                M_Ffjzt.zyzt_second = "";
                                M_Ffjzt.yd_ddsj = DateTime.Parse(common_file.common_app.cssj);
                                M_Ffjzt.yd_lksj = DateTime.Parse(common_file.common_app.cssj);
                                M_Ffjzt.lsbh = "";
                                M_Ffjzt.czsj = DateTime.Now;
                                M_Ffjzt.cznr = "强制清除错误的预订";
                                M_Ffjzt.czy = common_file.common_app.czy;
                                if (B_Ffjzt.Update(M_Ffjzt))
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "强制清除成功,房态即将自动刷新,请单击确定!");
                                    refresh_app("Ffjzt", "",true);
                                }
                            }
                        }
                    }
                }
                ds_temp.Clear();
                ds_temp.Dispose();
            }

            Cursor.Current = Cursors.Default;
        }
        private void b_zhcx_Click(object sender, EventArgs e)
        {
            string sel_con_ls = "";
            if (cB_jdlh.Text.Trim() != "")
            {
                sel_con_ls = sel_con_ls + "and jdlh_name='" + cB_jdlh.Text.Trim() + "' ";
                if (cB_jdcs.Text.Trim() != "")
                {
                    sel_con_ls = sel_con_ls + "and jdcs_name='" + cB_jdcs.Text.Trim() + "' ";
                }
            }
            if (cB_fjrb.Text.Trim() != "")
            {
                sel_con_ls = sel_con_ls + "and fjrb='" + cB_fjrb.Text.Trim() + "' ";
            }
            if (cB_zyzt.Text.Trim() != "")
            {
                if (cB_zyzt.Text.Trim() == common_file.common_fjzt.ydf)
                {
                    sel_con_ls = sel_con_ls + "and zyzt_second='" + cB_zyzt.Text.Trim() + "' ";
                }
                else
                {
                    sel_con_ls = sel_con_ls + "and zyzt='" + cB_zyzt.Text.Trim() + "' ";
                }
            }
            if (sel_con_ls != "")
            {
                refresh_app("Ffjzt", sel_con_ls, false);
            }
        }

        //用于加载点击加载的消费
        private void Dispalyfjzw(UC_room_pic_0 UC_room_pic_0_select)
        {
            if (UC_room_pic_0_select != null && (UC_room_pic_0_select.MP_room_state == 5 || UC_room_pic_0_select.MP_room_state == 51))
            {
                //找到Lsbh加载账务
                BLL.Ffjzt B_ffjzt = new Hotel_app.BLL.Ffjzt();
                List<Model.Ffjzt> list_fj = B_ffjzt.GetModelList(" id>=0 and  zyzt='" + common_fjzt.zzf + "' and  fjbh='" + UC_room_pic_0_select.MP_roomno + "'");
                if (list_fj != null && list_fj.Count > 0)
                {
                    Model.Ffjzt M_Ffjzt = list_fj[0];
                    string templsbh = M_Ffjzt.lsbh;
                    DataSet ds_zwmx = null;
                    DataSet ds_xfxm = null;
                    Bind_zwmx.DataSource = null;
                    Hotel_app.Szwgl.SzwclHelper SzwclHelper_new = new Hotel_app.Szwgl.SzwclHelper();
                    ds_zwmx = SzwclHelper_new.Zzwcl_Search(templsbh, "sk", common_app.czy_GUID);
                    if (ds_zwmx != null && ds_zwmx.Tables[0].Rows.Count > 0)
                    {
                        Bind_zwmx.DataSource = ds_zwmx.Tables[0];
                    }
                    dgv_zwmx.AutoGenerateColumns = false;
                    dgv_zwmx.DataSource = Bind_zwmx;
                    //右下角两个统计框赋值
                    decimal xf = 0;
                    decimal fk = 0;

                    for (int i = 0; i < ds_zwmx.Tables[0].Rows.Count; i++)
                    {
                        if (ds_zwmx.Tables[0].Rows[i]["xfdr"].ToString() == common_file.common_app.fkdr)
                        {
                            fk += decimal.Parse(ds_zwmx.Tables[0].Rows[i]["sjxfje"].ToString());
                        }
                        else
                        {
                            xf += decimal.Parse(ds_zwmx.Tables[0].Rows[i]["sjxfje"].ToString());
                        }
                    }
                    //这里更改成为行值来计算　　

                    button12.Text = Math.Abs(xf).ToString();
                    button11.Text = Math.Abs(fk).ToString();
                }
            }
            else
            {
                dgv_zwmx.DataSource = null; 
                button12.Text = "0.00"; 
                button11.Text = "0.00";
            }
        }

        private void MS_ysk_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcl_yjcz", common_file.common_app.user_type) == false)
            { return; }

            if (list_rooms.Count == 1&&list_rooms[0].MP_room_state.ToString().Substring(0,1).Equals("5"))
            {
                Szwgl.Syjcz Frm_Syjcz = new Syjcz();
                string fjbh = list_rooms[0].MP_roomno;
                List<Model.Qskyd_fjrb> list_qfs = new List<Hotel_app.Model.Qskyd_fjrb>();
                BLL.Qskyd_fjrb B_qf = new Hotel_app.BLL.Qskyd_fjrb();
                list_qfs = B_qf.GetModelList(" id>=0  and   fjbh='" + fjbh + "'         ");
                if (list_qfs.Count > 0)
                {
                    Frm_Syjcz.openfrom = "Szwcl";
                    Frm_Syjcz.sk_tt = "sk";//注意,这里就是针对单个房间加收预收款的
                    Frm_Syjcz.lsbh = list_qfs[0].lsbh;
                    Frm_Syjcz.StartPosition = FormStartPosition.CenterScreen;
                    if (Frm_Syjcz.ShowDialog() == DialogResult.OK)
                    {
                        common_app.Message_box_show(common_app.message_title, "加收预收款成功");
                        MouseEventArgs  MyE=new MouseEventArgs(MouseButtons,0,0,0,0);
                        uc_room_pic_mouse_Down(list_rooms[0], MyE);
                    }
                }
            }
        }

        public void refresh_fjzt(string ss1, string ss2, bool IsReLoad)
        {
            string ss = "";
            if (ss2.Equals("")&&IsReLoad)
            {
                foreach (Control item in p_pic.Controls)
                {
                    //如果是房间,那么，设置房间的状态
                    common_app.get_czsj();
                    if (item != null && item.Tag.Equals("panel_pic"))
                        foreach (Control item1 in item.Controls)
                        {
                            if (item1.Tag != null && item1.Tag.Equals("UC_room_pic_0"))
                            {
                                Hotel_app.control_user.UC_room_pic_0 tmpRoom = (Hotel_app.control_user.UC_room_pic_0)item1;
                                string fjbh_refresh = tmpRoom.MP_roomno;
                                DataSet ds_ls = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh_refresh + "'");
                                if (ds_ls != null && ds_ls.Tables.Count > 0 && ds_ls.Tables[0].Rows.Count > 0)
                                {
                                    common_file.common_room_state.room_state(tmpRoom, ds_ls, 0);
                                    //ss += item1.Name + "\n";
                                }
                            }
                        }
                }
            }
            else
            {
                List<Hotel_app.control_user.UC_room_pic_0> list_ucs = new List<UC_room_pic_0>();
                DS(p_pic, list_ucs);
                foreach (Hotel_app.control_user.UC_room_pic_0 tempUc in list_ucs)
                {
                    IsVisibleFj(ss2, tempUc);
                }
            }
            
            //左边快速查询栏的记数
            getcount("Ffjzt", "");
        }

        private void Ffjzt_pic_big_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MS_sxft_Click(sender, e);
            }
        }

        private void Ffjzt_pic_big_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
               // if (list_rooms.Count > 0)
               // {
               //     foreach (var UC_room_pic_0_temp in list_rooms)
               //     {
               //         changeColor(UC_room_pic_0_temp, false);
               //     }
               // }
               //list_rooms.Clear();
               //if (UC_room_pic_0_select != null)
               //{
               //    list_rooms.Add(UC_room_pic_0_select);
               //    changeColor(UC_room_pic_0_select, true);
               //}
              common_file.common_app.flag_mulit_select = false;
            }
        }
    }
}