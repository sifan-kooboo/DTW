using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Hotel_app.common_file;
using DevExpress.XtraEditors;
namespace Hotel_app
{
    public partial class Fmain : DevExpress.XtraEditors.XtraForm
    {
        public  bool Qskyd_www_open = true;
        public Fmain()
        {
            InitializeComponent();
            //this.skinEngine1.SkinFile = Application.StartupPath + "\\skin\\MP10.ssk";// "MP10.ssk";
            //启用无焦点时仍处理按键
            this.KeyPreview = true;
            //注册热键
            bool success = common_file.Common_Hook.RegisterHotKey(this.Handle, 100, Hotel_app.common_file.Common_Hook.KeyModifiers.Control, Keys.S);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            int tem = m.Msg;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    //MessageBox.Show("CTR+d");
                    common_file.common_app.flag_mulit_select = true;
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }


        #region 登记
        private void M_skdj_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qskdj_new_open("", common_file.common_yddj.yddj_dj, common_file.common_app.get_add, common_file.common_app.main_sec_main);
        }

        //登记查询
        private void M_skcx_Click(object sender, EventArgs e)
        {
            if (M_skcx.Enabled == true)
            {
                common_file.common_form.Qskdj_browse_new_open(common_file.common_yddj.yddj_dj);
            }
        }

        #endregion

        #region 预订

        private void 新增散客预订ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qskdj_new_open("", common_file.common_yddj.yddj_yd, common_file.common_app.get_add, common_file.common_app.main_sec_main);
        }


        #endregion


        private void 新增团体预订ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qttdj_new_open("", common_file.common_yddj.yddj_yd, common_file.common_app.get_add, false);
        }



        private void 新增团体登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qttdj_new_open("", common_file.common_yddj.yddj_dj, common_file.common_app.get_add, false);
        }



        private void M_Ffjzt_Click(object sender, EventArgs e)
        {
            Ffjzt.common_form.Ffjzt_browse_new_open();
        }

        public void M_ftll_Click(object sender, EventArgs e)
        {
            if (M_fttx.Enabled == true )
            {
                Ffjzt.common_form.Ffjzt_pic_big_new_open();
            }
        }

        private void M_gjsz_Click(object sender, EventArgs e)
        {

            Xxtsz.Xkrgj_browse Xkrgj_browse_new = new Hotel_app.Xxtsz.Xkrgj_browse();
            Xkrgj_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Xkrgj_browse_new.ShowDialog();


        }

        private void M_xfdr_Click(object sender, EventArgs e)
        {

            Xxtsz.Xxfdr_browse Xxfdr_browse_new = new Hotel_app.Xxtsz.Xxfdr_browse();
            common_app.setPosition(Xxfdr_browse_new);
            Xxfdr_browse_new.ShowDialog();
        }

        private void M_xfxr_Click(object sender, EventArgs e)
        {
            Xxtsz.Xxfsz_browse Xxfsz_browse_new = new Hotel_app.Xxtsz.Xxfsz_browse();
            //Xxfsz_browse_new.ShowDialog();
            common_app.setPosition(Xxfsz_browse_new);



        }

        private void M_xfxm_Click(object sender, EventArgs e)
        {

            if (common_file.common_form.Xxfmx_browse_new == null || common_file.common_form.Xxfmx_browse_new.IsDisposed)
            {
                common_file.common_form.Xxfmx_browse_new = new Hotel_app.Xxtsz.Xxfmx_browse();
                common_file.common_form.Xxfmx_browse_new.MdiParent = this;
                common_file.common_form.Xxfmx_browse_new.Show();
            }
            common_file.common_form.Xxfmx_browse_new.Activate();
            common_file.common_form.Xxfmx_browse_new.Show();
        }

        private void M_qzrx_Click(object sender, EventArgs e)
        {

            Xxtsz.Xqzrx_browse Xqzrx_browse_new = new Hotel_app.Xxtsz.Xqzrx_browse();
            Xqzrx_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Xqzrx_browse_new.ShowDialog();
        }

        private void M_krrx_Click(object sender, EventArgs e)
        {

            Xxtsz.Xkrrx_browse Xkrrx_browse_new = new Hotel_app.Xxtsz.Xkrrx_browse();
            Xkrrx_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Xkrrx_browse_new.ShowDialog();
        }

        private void M_krly_Click(object sender, EventArgs e)
        {

            Xxtsz.Xkrly_browse Xkrly_browse_new = new Hotel_app.Xxtsz.Xkrly_browse();
            Xkrly_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Xkrly_browse_new.ShowDialog();
        }

        private void M_yxzj_Click(object sender, EventArgs e)
        {

            Xxtsz.Xyxzj_browse Xyxzj_browse_new = new Hotel_app.Xxtsz.Xyxzj_browse();
            Xyxzj_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Xyxzj_browse_new.ShowDialog();

        }

        private void M_mzsz_Click(object sender, EventArgs e)
        {
            Xxtsz.Xkrmz_browse Xkrmz_browse_new = new Hotel_app.Xxtsz.Xkrmz_browse();
            Xkrmz_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Xkrmz_browse_new.ShowDialog();

        }

        private void M_fkfs_Click(object sender, EventArgs e)
        {

            Xxtsz.Xfkfs_browse Xfkfs_browse_new = new Hotel_app.Xxtsz.Xfkfs_browse();
            Xfkfs_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Xfkfs_browse_new.ShowDialog();
        }

        private void M_xsrygl_Click(object sender, EventArgs e)
        {
            Yyxzx.Yxsy_browse Yxsy_browse_new = new Hotel_app.Yyxzx.Yxsy_browse();
            Yxsy_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Yxsy_browse_new.ShowDialog();
        }

        private void M_xydwgl_Click(object sender, EventArgs e)
        {
            common_file.common_form.Yxydw_browse_new_open(common_file.common_xydw.krly_xydw);
       }

        private void M_yhsz_Click(object sender, EventArgs e)
        {
            Xxtsz.Xyhsz_browse Xyhsz_browse_new = new Hotel_app.Xxtsz.Xyhsz_browse();

            Xyhsz_browse_new.ShowDialog();
        }

        private void M_gzdwgl_Click(object sender, EventArgs e)
        {
            common_file.common_form.Yxydw_browse_new_open(common_file.common_xydw.xyrx_gzdw);
        }
        /// <summary>
        /// 设置状态栏
        /// </summary>
        public void set_tsl()
        {
            TSL_syzd.Text = "营业点:" + common_file.common_app.syzd;
            TSL_czy.Text =  "操作员:"+common_file.common_app.czy;
            TSL_czsj.Text = "登录时间:" + string.Format("{0:yyyy-MM-dd  HH:mm:ss}", common_file.common_app.czsj.ToString());
            TSL_qyxx.Text = common_file.common_app.qymc;
            this.Text = common_app.SoftName + "酒店管理系统(摩通科技专供版)";
        }
        private void Fmain_Load(object sender, EventArgs e)
        {
            xtraTabbedMdiManager1.MdiParent = true ? this : null;
            common_form.Fmain_new = this;
            Qskyd_www_open = common_file.common_app.Qskyd_www_open;
            this.Visible = false;
           
            #region 写入系统启动目录，并进行验证检查
            string MThtPath = Application.StartupPath;
            try
            {
                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "System_path","aaa");
                    Yhgl.YH_login YH_login_new = new Hotel_app.Yhgl.YH_login("zc");
                    if (YH_login_new.ShowDialog() == DialogResult.OK)
                    {
                        this.Visible = true;
                        //common_file.common_form.Fmain_new = this;
                        M_ftll_Click(sender, e);
                        set_tsl();
                        common_file.common_roles.set_menu_is_visible(menuStrip1, common_file.common_app.user_type);
                        if (Qskyd_www_open == true)
                        {
                            this.timer_GetYdzxData.Enabled = true;
                            this.timer_GetYdzxData.Interval = 1000 * 60 * int.Parse(Common_initalSystem.ReadNameValueSectionValue("qyinfo", "ydzxPopTime"));
                        }
                    }
                    else
                    {
                        this.Close();
                    }
            }
            catch (Exception  ee)
            {
                MessageBox.Show(ee.ToString()); 
            }

            #endregion
        }

        private void M_jzzwgl_Click(object sender, EventArgs e)
        {
            if (M_jzzwgl.Enabled == true )
            {
                common_file.common_form.ShowFrm_Sjjzwll_new(common_file.common_jzzt.czzt_jz);
            }
        }

        private void M_gzzwgl_Click(object sender, EventArgs e)
        {
            if (M_gzzwgl.Enabled == true )
            {
                common_file.common_form.ShowFrm_Sjjzwll_new(common_file.common_jzzt.czzt_gz);
            }
        }

        private void M_szzwgl_Click(object sender, EventArgs e)
        {
            if (M_szzwgl.Enabled == true )
            {
                common_file.common_form.ShowFrm_Sjjzwll_new(common_file.common_jzzt.czzt_sz);
            }
        }

        private void MS_hygl_Click(object sender, EventArgs e)
        {
            common_file.common_hy.Form_hygl_browse(this);
        }

        private void MS_hydjgl_Click(object sender, EventArgs e)
        {
            Hotel_app.Hhygl.Hhyjb_browse Hhyjb_browse_new = new Hotel_app.Hhygl.Hhyjb_browse();
            Hhyjb_browse_new.Left = 200;
            Hhyjb_browse_new.Top = 150;
            Hhyjb_browse_new.ShowDialog();

        }

        private void MS_jfblgl_Click(object sender, EventArgs e)
        {
            Hotel_app.Hhygl.Hhyjf_bl_browse Hhyjfbl_browse_new = new Hotel_app.Hhygl.Hhyjf_bl_browse();
            Hhyjfbl_browse_new.Left = 200;
            Hhyjfbl_browse_new.Top = 150;
            Hhyjfbl_browse_new.ShowDialog();

        }

        private void MS_hyfjsz_Click(object sender, EventArgs e)
        {
            Hotel_app.Hhygl.Hhyfj_browse Hhyfj_browse_new = new Hotel_app.Hhygl.Hhyfj_browse();
            Hhyfj_browse_new.Left = 200;
            Hhyfj_browse_new.Top = 150;
            Hhyfj_browse_new.ShowDialog();

        }

        private void MS_jfjlgl_Click(object sender, EventArgs e)
        {
            Hotel_app.Hhygl.Hhyjf_jp_browes Hhyjfjp_browse_new = new Hotel_app.Hhygl.Hhyjf_jp_browes();
            Hhyjfjp_browse_new.Left = 200;
            Hhyjfjp_browse_new.Top = 150;
            Hhyjfjp_browse_new.ShowDialog();
        }

        private void MS_jlrxsz_Click(object sender, EventArgs e)
        {
            Hotel_app.Hhygl.Hhyjf_jp_class_browes Hhyjfjpclass_browse_new = new Hotel_app.Hhygl.Hhyjf_jp_class_browes();
            Hhyjfjpclass_browse_new.Left = 200;
            Hhyjfjpclass_browse_new.Top = 150;
            Hhyjfjpclass_browse_new.ShowDialog();
        }

        private void M_ff_xyxf_Click(object sender, EventArgs e)
        {
            Qyddj.Q_ff_xyxf Q_ff_xyxf_new = new Hotel_app.Qyddj.Q_ff_xyxf();
            Q_ff_xyxf_new.Left = 150;
            Q_ff_xyxf_new.Top = 150;
            Q_ff_xyxf_new.ShowDialog();
        }

        private void M_lscckr_Click(object sender, EventArgs e)
        {
            Qyddj.Q_sfz_temp Q_sfz_temp_new = new Hotel_app.Qyddj.Q_sfz_temp(" and shcl=0");
            Q_sfz_temp_new.Left = 150;
            Q_sfz_temp_new.Top = 150;
            Q_sfz_temp_new.ShowDialog();
        }

        private void M_lskrgl_Click(object sender, EventArgs e)
        {
            common_file.common_form.Q_lskr_new_open();
        }

        private void M_lsczgz_Click(object sender, EventArgs e)
        {
            common_file.common_form.Q_czjl_ls_new_open();
        }

        private void M_skydqx_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qskyd_qx_new_open();
        }

        private void M_ttydqx_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qttyd_qx_new_open();
        }

        private void M_ytskcx_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qskdj_browse_new_open(common_file.common_app.get_his);
        }

        private void M_ytttcx_Click(object sender, EventArgs e)
        {
            common_file.common_form.Qttdj_browse_new_open(common_file.common_app.get_his);
        }

        private void M_frgl_Click(object sender, EventArgs e)
        {
            Ffjzt.Ffjrb_browse Ffjrb_browse_new = new Hotel_app.Ffjzt.Ffjrb_browse();
            Ffjrb_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Ffjrb_browse_new.ShowDialog();
        }

        private void M_lyfjgl_Click(object sender, EventArgs e)
        {
            Ffjzt.Ffjrb_krly_browse Ffjrb_krly_browse_new = new Hotel_app.Ffjzt.Ffjrb_krly_browse();
            Ffjrb_krly_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Ffjrb_krly_browse_new.ShowDialog();
        }

        private void M_xyfjgl_Click(object sender, EventArgs e)
        {
            Yyxzx.Yxydw_fjrb_browse Yxydw_fjrb_browse_new = new Hotel_app.Yyxzx.Yxydw_fjrb_browse();
            Hotel_app.Hhygl.Hhyfj_browse Hhyfj_browse_new = new Hotel_app.Hhygl.Hhyfj_browse();
            Yxydw_fjrb_browse_new.StartPosition = FormStartPosition.CenterScreen;
            Yxydw_fjrb_browse_new.ShowDialog();
        }

        private void M_yhgl_Click(object sender, EventArgs e)
        {
            Yhgl.YH_User_browse YH_User_browse_new = new Hotel_app.Yhgl.YH_User_browse();
            YH_User_browse_new.StartPosition = FormStartPosition.CenterScreen;
            YH_User_browse_new.ShowDialog();
        }

        private void M_jsgl_Click(object sender, EventArgs e)
        {
            Yhgl.YH_Roles_browse H_Roles_browse_new = new Hotel_app.Yhgl.YH_Roles_browse();
            H_Roles_browse_new.StartPosition = FormStartPosition.CenterScreen;
            H_Roles_browse_new.ShowDialog();
        }

        private void M_mmxg_Click(object sender, EventArgs e)
        {
            Yhgl.YH_UpdatePassWord YH_UpdatePassWord_new = new Hotel_app.Yhgl.YH_UpdatePassWord();
            YH_UpdatePassWord_new.StartPosition = FormStartPosition.CenterScreen;
            YH_UpdatePassWord_new.ShowDialog();

        }

        private void Fmain_SizeChanged(object sender, EventArgs e)
        {
            b_exit.Left = toolStrip1.Width - 50;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要退出系统？") == true)
            {
                common_file.common_app.add_lo_ex_re(common_file.common_app.yydh, common_file.common_app.qymc,common_file.common_app.syzd, common_file.common_app.userNo, common_file.common_app.czy, common_file.common_app.lo_ex_ex, common_file.common_app.login_time, DateTime.Now);
                Application.Exit();
            }

        }

        private void M_ttdjcx_Click(object sender, EventArgs e)
        {
            if (M_ttdjcx.Enabled == true )
            {
                common_file.common_form.Qttdj_browse_new_open(common_file.common_yddj.yddj_dj);
            }
        }

        private void M_skydcx_Click(object sender, EventArgs e)
        {
            if (M_skydcx.Enabled == true )
            {
                common_file.common_form.Qskdj_browse_new_open(common_file.common_yddj.yddj_yd);
            }
        }

        private void M_ttydcx_Click(object sender, EventArgs e)
        {
           if (M_ttydcx.Enabled == true )
            { 
                common_file.common_form.Qttdj_browse_new_open(common_file.common_yddj.yddj_yd);
            }
        }

        private void M_ftfx_Click(object sender, EventArgs e)
        {
            if (M_ftfx.Enabled == true )
            {
                Ffjzt.common_form.Fftfx_new_open();
            }
        }

        private void M_kfxsfx_Click(object sender, EventArgs e)
        {
            Ffjzt.common_form.Fkfxsfx_app_new_open();
        }
        private void M_qfyh_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要重新登录系统？") == true)
            {
                if (M_qfyh.Enabled == true)
                {

                    Yhgl.YH_login YH_login_new = new Hotel_app.Yhgl.YH_login("zx");
                    YH_login_new.cB_syzd.Text = common_file.common_app.syzd;
                    YH_login_new.cB_syzd.Enabled = false;
                    if (YH_login_new.ShowDialog() == DialogResult.OK)
                    {
                        set_tsl();//设置状态栏
                        common_file.common_roles.set_menu_is_visible(menuStrip1, common_file.common_app.user_type);
                    }
                }
            }
            else
            {
                //this.Close();
            }
        }

        private void M_yskxgl_Click(object sender, EventArgs e)
        {
            Szwgl.common_form.Syjll_new_open();
        }

        private void M_zzmxll_Click(object sender, EventArgs e)
        {
            Szwgl.common_form.Szzzwll_new_open();
        }



        //以下为报表部分
        #region 报表部分
        private void M_zhrbb_fl_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_zhrbb_fl_new_open();
        }

        private void M_zhrbb_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_zhrbb_new_open();
        }

        private void M_xsrytj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_xsy_new_open();
        }

        private void M_xsry_xydw_tj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_syxffx_xsy_xydw_new_open();
        }

        private void M_xsy_mxck_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_xsymxfx_new_open("xsymxfx");
        }

        private void M_krly_dw_tj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_syxffx_krly_xydw_new_open();
        }

        private void M_xydwtj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_xydw_new_open();
        }

        private void M_gjdqfx_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_gj_pq_new_open();
        }

        private void M_sfdqfx_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_sf_cs_new_open();
        }

        private void M_gztj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_fx_new_open(BBfx.common_bb.gz_type);
        }

        private void M_jztj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_fx_new_open(BBfx.common_bb.jz_type);
        }

        private void M_zdkrylfx_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_zdkr_ylfx_new_open();
        }

        private void M_krlytj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_krly_new_open();
        }

        private void M_xydw_mxck_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_xsymxfx_new_open("xydwmxfx");

        }

        private void M_gz_mxck_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_mxfx_new_open(BBfx.common_bb.gz_type);
        }

        private void M_gz_mxck_xx_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_mxfx_xx_new_open(BBfx.common_bb.gz_type);
        }

        private void M_jz_mxck_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_mxfx_new_open(BBfx.common_bb.jz_type);
        }

        private void M_jz_mx_xxck_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_mxfx_xx_new_open(BBfx.common_bb.jz_type);
        }

        private void M_zdkrmxfx_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_zdkr_mxfx_new_open("krly");
        }

        private void M_krly_mxck_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_xsymxfx_new_open("krlymxfx");
        }

        private void M_syxffx_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_syxffx_mx_new_open();
        }
        private void M_ds_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_ds_new_open();
        }
        private void M_zdkrmxfx_ByFjbh_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_zdkr_mxfx_new_open("fjbh");
        }
        private void M_zdkrmxfx_Byxb_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_zdkr_mxfx_new_open("krxb");
        }

        private void M_zzwj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_zzwj_new_open();
        }

        private void M_czOrbz_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_czOrbz_new_open();
        }

        private void M_qtsytj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_qtsytj_new_open();
        }

        private void M_sh_wj_gj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_wj_gj_new_open();
        }

        private void M_kfcy_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_cy_new_open();
        }

        private void M_zzkrdqtj_Click(object sender, EventArgs e)
        {
            //BBfx.common_form.Frm_BB_zzkrdqtj_new_open();
        }

        private void M_gzyetj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_ye_fx_new_open(BBfx.common_bb.gz_type);
        }

        private void M_jzyetj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_j_g_ye_fx_new_open(BBfx.common_bb.jz_type);
        }

        private void M_hykxftj_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_hyk_xsy();
        }

        private void M_hykmxfx_Click(object sender, EventArgs e)
        {
            BBfx.common_form.Frm_BB_hyk_xftj();
        }
        #endregion



        //交班
        private void M_jbgl_Click(object sender, EventArgs e)
        {
            Szwgl.common_form.S_jbzd_ll_new_open();
        }

        private void M_xtjbsz_Click(object sender, EventArgs e)
        {
            Yhgl.Frm_initalSystem Frm_initalSystem_new = new Hotel_app.Yhgl.Frm_initalSystem();
            Frm_initalSystem_new.StartPosition = FormStartPosition.CenterScreen;
            Frm_initalSystem_new.ShowDialog();
        }

        private void M_reboot_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要重启系统嘛？") == true)
            {
                common_file.common_form.Fmain_new.Close();
                string systemPath = common_file.Common_initalSystem.ReadXML("add", "System_path") + "\\Hotel_app.exe"; //common_file.Common_initalSystem.ReadNameValueSectionValue("qyinfo", "systemPath");
                try
                {
                    Process.Start(systemPath);
                }
                catch (Exception ee)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "重启失败,请手动重启.");
                }

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SH.SH_ys SH_ys_new = new Hotel_app.SH.SH_ys();
            SH_ys_new.StartPosition = FormStartPosition.CenterScreen;
            SH_ys_new.ShowDialog();
        }

        private void X_lkzd_Click(object sender, EventArgs e)
        {
            common_file.common_form.Xxfmx_lkzd_browse_new_open();
        }

        private void M_jkgl_Click(object sender, EventArgs e)
        {
            Szwgl.common_form.S_jkzd_ll_new_open();
        }



        private void M_rssh_Click(object sender, EventArgs e)
        {button9_Click( sender, e);
        }

        private void M_yhczjlcx_Click(object sender, EventArgs e)
        {
            common_file.common_form.Yh_czjl_new_open();
        }

        private void M_tx_Click(object sender, EventArgs e)
        {
            Qyddj.Q_notice Q_notice_new = new Hotel_app.Qyddj.Q_notice();
            Q_notice_new.StartPosition = FormStartPosition.CenterScreen;
            Q_notice_new.ShowDialog();
        }

        private void M_ckmxcx_Click(object sender, EventArgs e)
        {
            common_file.common_form.Frm_Xxtsz_ckmxcx_new_open();
        }

        private void timer_GetYdzxData_Tick(object sender, EventArgs e)
        {
            DataSet ds_0 = null;
            DataSet ds_1 = null;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            ds_0 = B_common.GetList(" select * from  View_Qskzd", " id>=0  and  ddyy='" + common_file.common_app.ydzx_flag + "' and  yddj='" + common_file.common_yddj.yddj_yd + "' and shsc=1 ");
            ds_1 = B_common.GetList(" select * from  View_Qttzd", " id>=0  and  ddyy='" + common_file.common_app.ydzx_flag + "' and  yddj='" + common_file.common_yddj.yddj_yd + "' and shsc=1 ");
            string url=common_app.service_url;
            string clinetAppVersion = "";
            //弹出预订中心的订单
            if ((ds_0 != null && ds_0.Tables[0].Rows.Count > 0) || (ds_1 != null && ds_1.Tables[0].Rows.Count > 0))
            {
                fmain_new mainhelper = new fmain_new();
                Qyddj.Q_ydzx_noticeBar taskbarNotifier = new Hotel_app.Qyddj.Q_ydzx_noticeBar();
                string path = Application.StartupPath;
                string fileName = path + "\\image\\" + "skin2.bmp";
                string fileName1 = path + "\\image\\" + "close2.bmp";

                taskbarNotifier.SetBackgroundBitmap(fileName, Color.FromArgb(255, 0, 255));
                taskbarNotifier.SetCloseBitmap(fileName1, Color.FromArgb(255, 0, 255), new Point(300, 74));
                taskbarNotifier.TitleRectangle = new Rectangle(123, 80, 176, 16);
                taskbarNotifier.ContentRectangle = new Rectangle(116, 97, 197, 22);
                taskbarNotifier.TitleClick += new EventHandler(mainhelper.TitleClick);
                taskbarNotifier.ContentClick += new EventHandler(mainhelper.ContentClick);
                taskbarNotifier.CloseClick += new EventHandler(mainhelper.CloseClick);

                taskbarNotifier.CloseClickable = true;// checkBoxCloseClickable.Checked;
                taskbarNotifier.TitleClickable = true;//  checkBoxTitleClickable.Checked;
                taskbarNotifier.ContentClickable = true;//  checkBoxContentClickable.Checked;
                taskbarNotifier.EnableSelectionRectangle = true;//  checkBoxSelectionRectangle.Checked;
                taskbarNotifier.KeepVisibleOnMousOver = true;//  checkBoxKeepVisibleOnMouseOver.Checked;	// Added Rev 002
                taskbarNotifier.ReShowOnMouseOver = true;//  checkBoxReShowOnMouseOver.Checked;			// Added Rev 002
                taskbarNotifier.Show("网站订单提醒", "你有新的订单信息，点击查看详细", 10000, 10000, 0);
            }
            //查询新版本
            clinetAppVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\hotel_app.exe").ProductVersion;
            url +="update.asmx";
            object[] args = new object[2];
            args[0]=common_file.common_app.yydh;
            args[1] = clinetAppVersion;
            object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "GetUpdate", args);
            if (result != null && result.ToString() != "")
            {
                fmain_new mainhelper = new fmain_new();
                //mainhelper.Fmain = this;
                Qyddj.Q_ydzx_noticeBar taskbarNotifier = new Hotel_app.Qyddj.Q_ydzx_noticeBar();
                string path = Application.StartupPath;
                string fileName = path + "\\image\\" + "skin.bmp";
                string fileName1 = path + "\\image\\" + "close2.bmp";

                taskbarNotifier.SetBackgroundBitmap(fileName, Color.FromArgb(255, 0, 255));
                taskbarNotifier.SetCloseBitmap(fileName1, Color.FromArgb(255, 0, 255), new Point(300, 74));
                taskbarNotifier.TitleRectangle = new Rectangle(123, 80, 176, 16);
                taskbarNotifier.ContentRectangle = new Rectangle(116, 97, 197, 22);
                taskbarNotifier.TitleClick += new EventHandler(mainhelper.TitleClick);
                taskbarNotifier.ContentClick += new EventHandler(mainhelper.ContentClick_GetNewVersion);
                taskbarNotifier.CloseClick += new EventHandler(mainhelper.CloseClick);

                taskbarNotifier.CloseClickable = true;// checkBoxCloseClickable.Checked;
                taskbarNotifier.TitleClickable = true;//  checkBoxTitleClickable.Checked;
                taskbarNotifier.ContentClickable = true;//  checkBoxContentClickable.Checked;
                taskbarNotifier.EnableSelectionRectangle = true;//  checkBoxSelectionRectangle.Checked;
                taskbarNotifier.KeepVisibleOnMousOver = true;//  checkBoxKeepVisibleOnMouseOver.Checked;	// Added Rev 002
                taskbarNotifier.ReShowOnMouseOver = true;//  checkBoxReShowOnMouseOver.Checked;			// Added Rev 002
                taskbarNotifier.Show("版本检查", "有新的版本产生，点击更新", 10000, 10000, 0);
            }
             
            //检查钟点房
            BLL.Qskyd_fjrb   bll=new Hotel_app.BLL.Qskyd_fjrb();
            List<Model.Qskyd_fjrb> lists = bll.GetModelList(" yydh='"+common_file.common_app.yydh+"'  and   yddj='"+common_file.common_yddj.yddj_dj+"'  and   sktt='"+common_file.common_sktt.sktt_zd+"'  and  lksj<'"+DateTime.Now+"' ");
            if (lists != null && lists.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("以下钟点房超时,请确认加收钟点房费:");
                foreach (var item in lists)
                {
                    sb.Append("[房号:" + item.fjbh + "]" + "\r\t");
                }

                fmain_new mainhelper = new fmain_new();
                Qyddj.Q_ydzx_noticeBar taskbarNotifier = new Hotel_app.Qyddj.Q_ydzx_noticeBar();
                string path = Application.StartupPath;
                string fileName = path + "\\image\\" + "skin2.bmp";
                string fileName1 = path + "\\image\\" + "close2.bmp";

                taskbarNotifier.SetBackgroundBitmap(fileName, Color.FromArgb(255, 0, 255));
                taskbarNotifier.SetCloseBitmap(fileName1, Color.FromArgb(255, 0, 255), new Point(300, 74));
                taskbarNotifier.TitleRectangle = new Rectangle(123, 80, 176, 16);
                taskbarNotifier.ContentRectangle = new Rectangle(116, 97, 197, 22);
                taskbarNotifier.TitleClick += new EventHandler(mainhelper.TitleClick);
                //taskbarNotifier.ContentClick += new EventHandler(mainhelper.ContentClick_GetNewVersion);
                taskbarNotifier.CloseClick += new EventHandler(mainhelper.CloseClick);

                taskbarNotifier.CloseClickable = true;// checkBoxCloseClickable.Checked;
                taskbarNotifier.TitleClickable = true;//  checkBoxTitleClickable.Checked;
                taskbarNotifier.ContentClickable = true;//  checkBoxContentClickable.Checked;
                taskbarNotifier.EnableSelectionRectangle = true;//  checkBoxSelectionRectangle.Checked;
                taskbarNotifier.KeepVisibleOnMousOver = true;//  checkBoxKeepVisibleOnMouseOver.Checked;	// Added Rev 002
                taskbarNotifier.ReShowOnMouseOver = true;//  checkBoxReShowOnMouseOver.Checked;			// Added Rev 002
                taskbarNotifier.Show("钟点房超时提醒", sb.ToString(), 10000, 10000, 0);
            }
        }





        private void M_ydzxddcx_Click(object sender, EventArgs e)
        {
            Qyddj.Q_ydzx_notice Q_ydzx_notice_new = new Hotel_app.Qyddj.Q_ydzx_notice();
            Q_ydzx_notice_new.ShowDialog();
        }



        private void M_checkUpdate_Click(object sender, EventArgs e)
        {
            updateFrm f = new updateFrm(this);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void M_txftsz_Click(object sender, EventArgs e)
        {
            Xxtsz.Frm_txftsz Frm_txftsz_new = new Hotel_app.Xxtsz.Frm_txftsz();
            //Yhgl.Frm_initalSystem Frm_initalSystem_new = new Hotel_app.Yhgl.Frm_initalSystem();
            Frm_txftsz_new.StartPosition = FormStartPosition.CenterScreen;
            if (Frm_txftsz_new.ShowDialog() == DialogResult.OK)
            {
                if (Ffjzt.common_form.Ffjzt_pic_big_new != null)
                {
                    Ffjzt.common_form.Ffjzt_pic_big_new.refresh_fjzt("Ffjzt", "",true);
                }
            }
        }

        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            //去掉右上角子窗体的关掉，还原，最大化，最小化按纽";
            if (e.Item.Text.Length == 0 || e.Item.Text == "还原(&R)" || e.Item.Text == "最小化(&N)")//||e.Item.Text=="关闭(&C)")
            {
                e.Item.Visible = false;
            }
        }

        private void Fmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("您确定要关闭酒店管理系统嘛？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //    e.Cancel = true;
        }

        private void M_txczsm_Click(object sender, EventArgs e)
        {
            Xxtsz.Ｘ_ftsm frm_ftsm = new Hotel_app.Xxtsz.Ｘ_ftsm();
            frm_ftsm.StartPosition = FormStartPosition.CenterScreen;
            frm_ftsm.ShowDialog();
        }
    }
}