using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Hotel_app.Yhgl
{
    public partial class YH_login : Form
    {
        string zc_zx = "zc";//两个值，一个是正常登录“zc”，另一个是注销“zx”
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        DataSet DS_temp;
        DataSet DS_user;
        int dg_user_count = 0;
        //string syzd = "";

        //实现拖动
        Point mouse_offset = new Point();


        public YH_login(string zc_zx0)
        {
            zc_zx = zc_zx0;
            InitializeComponent();

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YH_login_Load(object sender, EventArgs e)
        {

                DS_temp = B_Common.GetList("select syzd from Xsyzd", "id>=0 order by id");
                if (DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DS_temp.Tables[0].Rows.Count; i++)
                    {
                        cB_syzd.Items.Add(DS_temp.Tables[0].Rows[i]["syzd"].ToString());
                    }
                }
        }

        private void tB_yhbh_TextChanged(object sender, EventArgs e)
        {
            if (DG_user.Visible == false)
            {
                DG_user.Visible = true;
                DG_user.Left = 62;
                DG_user.Top = 66;
            }
            get_user("yhbh like '%" + tB_yhbh.Text + "%' or yhxm like '%" + tB_yhbh.Text + "%' order by yhbh");
        }

        public void get_user(string cond_0)
        {
            dg_user_count = 0;
            if (tB_yhbh.Text.Trim() == "")
            {
                cond_0 = " id>=0 order by yhbh";
            }
            DS_user = B_Common.GetList("select yhbh,yhbm,yhxm from YH_user", cond_0);
            dg_user_count = DS_user.Tables[0].Rows.Count;
            bS_user.DataSource = DS_user.Tables[0];

        }
        private void b_yxzj_Click(object sender, EventArgs e)
        {
            if (DG_user.Visible == false)
            {
                get_user("id>=0 order by yhbh");
            }
            DG_user.Visible = true;
            DG_user.Left = b_yxzj.Right + 5;
            DG_user.Top = b_yxzj.Top;
        }

        private void tB_yhbh_Leave(object sender, EventArgs e)
        {
            //DG_user.Visible = false;
        }

        private void db_click()
        {
            tB_yhxm.Text = ""; tB_yhbm.Text = "";
            if (DS_user.Tables[0].Rows.Count > 0 && DG_user.CurrentRow.Index < dg_user_count)
            {
                tB_yhbh.Text = DS_user.Tables[0].Rows[DG_user.CurrentRow.Index]["yhbh"].ToString();
                tB_yhxm.Text = DS_user.Tables[0].Rows[DG_user.CurrentRow.Index]["yhxm"].ToString();
                tB_yhbm.Text = DS_user.Tables[0].Rows[DG_user.CurrentRow.Index]["yhbm"].ToString();
                tB_yhmm.Focus();
            }
            DG_user.Visible = false;

        }
        private void DG_user_DoubleClick(object sender, EventArgs e)
        {
            db_click();

        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "System_path", Application.StartupPath);
            if (cB_syzd.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择营业站点！");
                cB_syzd.Focus();
            }
            else
            {
                if (tB_yhxm.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请输入正确的用户编号！");
                    tB_yhxm.Focus();
                }
                else
                {
                    if (tB_yhmm.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请输入正确的用户密码！");
                        tB_yhmm.Focus();
                    }
                    else
                    {
                        DS_temp = B_Common.GetList("select * from Xqyxx", "id>=0");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_app.yydh = DS_temp.Tables[0].Rows[0]["yydh"].ToString();
                            common_file.common_app.qymc = DS_temp.Tables[0].Rows[0]["qymc"].ToString();
                            common_file.common_app.qybh = DS_temp.Tables[0].Rows[0]["qybh"].ToString();
                            common_file.common_app.hyjfrx = DS_temp.Tables[0].Rows[0]["hyjfrx"].ToString();
                            common_file.common_app.SoftName = DS_temp.Tables[0].Rows[0]["Softname"].ToString();
                        }

                        DS_temp = B_Common.GetList("select * from YH_user", "yydh='" + common_file.common_app.yydh + "' and yhbh='" + tB_yhbh.Text.Trim() + "' and yhmm='" + tB_yhmm.Text.Trim() + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            DateTime login_time0 = DateTime.Now;

                            if (zc_zx == "zx")
                            {
                                common_file.common_app.add_lo_ex_re(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.syzd, common_file.common_app.userNo, common_file.common_app.czy, common_file.common_app.lo_ex_ex, common_file.common_app.login_time, login_time0);
                            }

                            common_file.common_app.syzd = cB_syzd.Text.Trim();
                            common_file.common_app.user_type = DS_temp.Tables[0].Rows[0]["R_lsbh"].ToString();
                            common_file.common_app.czy = DS_temp.Tables[0].Rows[0]["yhxm"].ToString();
                            //生成用户的GUID,用于标识账务
                            common_file.common_app.czy_GUID = System.Guid.NewGuid().ToString();
                            common_file.common_app.userNo = DS_temp.Tables[0].Rows[0]["yhbh"].ToString();
                            
                            DateTime login_time_yl = common_file.common_app.login_time;
                            common_file.common_app.login_time = login_time0;


                            if (zc_zx == "zx")
                            {
                                common_file.common_app.add_lo_ex_re(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.syzd, DS_temp.Tables[0].Rows[0]["yhbh"].ToString(), DS_temp.Tables[0].Rows[0]["yhxm"].ToString(), common_file.common_app.lo_ex_qf, common_file.common_app.login_time, login_time0);
                                common_file.common_app.add_lo_ex_re_current(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.syzd, DS_temp.Tables[0].Rows[0]["yhbh"].ToString(), DS_temp.Tables[0].Rows[0]["yhxm"].ToString(), common_file.common_app.lo_ex_qf, common_file.common_app.login_time, login_time_yl);

                            }
                            else
                            {
                                common_file.common_app.add_lo_ex_re(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.syzd, DS_temp.Tables[0].Rows[0]["yhbh"].ToString(), DS_temp.Tables[0].Rows[0]["yhxm"].ToString(), common_file.common_app.lo_ex_lo, common_file.common_app.login_time, login_time0);
                                common_file.common_app.add_lo_ex_re_current(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.syzd, DS_temp.Tables[0].Rows[0]["yhbh"].ToString(), DS_temp.Tables[0].Rows[0]["yhxm"].ToString(), common_file.common_app.lo_ex_qf, common_file.common_app.login_time, login_time_yl);
                            }
                            common_file.common_sjtb.SetDate();
                            DS_temp = B_Common.GetList("select * from YH_Roles", "yydh='" + common_file.common_app.yydh + "' and R_lsbh='" + common_file.common_app.user_type + "'");
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.user_ts = int.Parse(DS_temp.Tables[0].Rows[0]["R_ts"].ToString());
                            }

                            //#region 进行注册检查
                            //Cursor.Current = Cursors.WaitCursor;
                            //if (common_file.Common_initalSystem.CheckSoftEnableIsOk())
                            //{
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            //}
                            //else
                            //{
                            //    Application.Exit();
                            //}
                            //#endregion
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "密码错误！");
                            tB_yhmm.Text = "";
                        }
                    }

                }

            }



        }

        private void cB_syzd_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.return_KeyPress(sender, e);
        }

        private void cB_syzd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                b_save_Click(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { b_exit_Click(sender, e); }
        }

        private void DG_user_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            db_click();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void b_save_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void b_save_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void b_contactUs_Click(object sender, EventArgs e)
        {
            ContactUs frm_cu = new ContactUs();
            frm_cu.StartPosition = FormStartPosition.CenterScreen;
            frm_cu.ShowDialog();
            frm_cu.TopMost = true;
        }

        private void b_help_Click(object sender, EventArgs e)
        {

            Help.ShowHelp(new Control(), "http://www.moton.com.cn/hms.aspx");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 frm_about = new AboutBox1();
            frm_about.StartPosition = FormStartPosition.CenterScreen;
            frm_about.ShowDialog();
            frm_about.TopMost = true;
        }

        private void b_CheckUpdate_Click(object sender, EventArgs e)
        {
            //BLL.Qcounter B_QC = new Hotel_app.BLL.Qcounter();
            //List<Model.Qcounter> list = new List<Hotel_app.Model.Qcounter>();
            //list = B_QC.GetModelList(" id>=0   ");
            //if (list != null && list.Count > 0)
            //{
            //    Model.Qcounter M_qc = new Hotel_app.Model.Qcounter();
            //    M_qc = list[0];
            //    if (M_qc != null && M_qc.VersionType.Equals(common_file.common_app.xxzs_zs))//正式版
            //    {
            //        //启动更新程序
            //    }
            //    else
            //    {
            //        ContactUs Frm_cu = new ContactUs();
            //        Frm_cu.StartPosition = FormStartPosition.CenterScreen;
            //        Frm_cu.ShowDialog();
            //    }
                
            //}
            updateFrm f = new updateFrm();
            f.StartPosition = FormStartPosition.CenterScreen;
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void YH_login_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void YH_login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { Point mousePos = Control.MousePosition; mousePos.Offset(mouse_offset.X, mouse_offset.Y); Location = mousePos; }
        }
    }
}