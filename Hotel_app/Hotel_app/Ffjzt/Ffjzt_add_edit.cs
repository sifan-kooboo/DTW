using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjzt_add_edit : Form
    {
        public string judge_add_edit = common_file.common_app.get_add;
        public string get_fjrb_code = "";
        public string Ffjzt_id = "";

        public Ffjzt_browse parent_form;//传递父窗体
        public Ffjzt_add_edit(Ffjzt_browse F_temp)
        {
            InitializeComponent();
            parent_form = F_temp;
        }

        public Ffjzt_add_edit()
        {
            InitializeComponent();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_jdlh.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，楼号不能为空！");
                tB_jdlh.Focus();
            }
            else
                if (tB_jdlh_name.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，楼名不能为空！");
                    tB_jdlh_name.Focus();
                }
            else 
            if (tB_jdcs.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，层数不能为空！");
                tB_jdcs.Focus();
            }
            else
                if (tB_jdcs_name.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，层数不能为空！");
                    tB_jdcs_name.Focus();
                }
                else
                if (tB_fjrb.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房态不能为空！");
                    tB_fjrb.Focus();
                }
                else
                    if (tB_fjbh.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房号不能为空！");
                        tB_fjbh.Focus();
                    }
                    else 
                    {
                       int judge_save = 3;

                        if (judge_add_edit == common_file.common_app.get_add)//新增 
                        { 
                            BLL.Common B_Common = new Hotel_app.BLL.Common();
                            DataSet DS_temp = B_Common.GetList("select id from Ffjzt","fjbh='"+tB_fjbh.Text+"'"+ common_file.common_app.yydh_select);
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                judge_save = 4;
                                common_file.common_app.Message_box_show(common_file.common_app.message_title,"对不起，您设置的房号已经存在了");
                            }
                            DS_temp.Dispose();
                        }


                        if (judge_save==3)
                        {
                            string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                            string[] args = new string[15];
                            args[0] = Ffjzt_id;
                            args[1] = common_file.common_app.yydh;
                            args[2] = common_file.common_app.qymc;
                            args[3] = tB_jdlh.Text.Trim().Replace("'", "//");
                            args[4] = tB_jdlh_name.Text.Trim().Replace("'", "//");
                            args[5] = tB_jdcs.Text.Trim().Replace("'", "//");
                            args[6] = tB_jdcs_name.Text.Trim().Replace("'", "//");
                            args[7] = tB_fjrb.Text.Trim().Replace("'", "//");
                            args[8] = get_fjrb_code;
                            args[9] = tB_fjbh.Text.Trim().Replace("'", "//");
                            args[10] = tB_fjdh.Text.Trim().Replace("'", "//");
                            args[11] = tB_dhfj.Text.Trim().Replace("'", "//");
                            args[12] = tB_bz.Text.Trim().Replace("'", "//");
                            args[13] = judge_add_edit;
                            args[14] =  common_file.common_app.xxzs;

                            Hotel_app.Server.Ffjzt.Ffjzt_app Ffjzt_app_services = new Hotel_app.Server.Ffjzt.Ffjzt_app();
                          string result=  Ffjzt_app_services.Ffjzt_add_edit_delete(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString());
                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Ffjzt_add_edit_delete", args);
                            if (result== common_file.common_app.get_suc)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                                if (judge_add_edit == common_file.common_app.get_add) 
                                { 
                                    parent_form.refresh_app();  
                                    tB_fjbh.Focus(); tB_fjbh.Text = ""; tB_fjdh.Text = ""; tB_dhfj.Text = ""; tB_bz.Text = ""; 
                                }
                                else if (judge_add_edit == common_file.common_app.get_edit) 
                                { 
                                    parent_form.refresh_app(); 
                                    this.Close(); 
                                }

                            }
                            else
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                        }

                        //tB_bz.Text = judge_add_edit;
                    }

            Cursor.Current = Cursors.Default;
        }

        private void B_gj_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Ffjzt.Ffjrb_select Ffjrb_select_new = new Ffjrb_select();
           
            Ffjrb_select_new.Left = common_file.common_app.x() - 100;
            Ffjrb_select_new.Top = common_file.common_app.y() - 100;
            if (Ffjrb_select_new.ShowDialog() == DialogResult.OK)
            {
                get_fjrb_code = Ffjrb_select_new.get_fjrb_code;
                tB_fjrb.Text = Ffjrb_select_new.get_fjrb;
            }
            Ffjrb_select_new.Dispose();
            tB_fjrb.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void Ffjzt_add_edit_Load(object sender, EventArgs e)
        {
            if (judge_add_edit == common_file.common_app.get_edit)
            { tB_fjbh.ReadOnly = true; tB_fjbh.BackColor = Color.LimeGreen; }
            else { tB_fjbh.ReadOnly = false; tB_fjbh.BackColor = Color.White; }
        }

        private void tB_jdlh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                b_save_Click(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { b_exit_Click(sender, e); }
        }

        private void tB_fjrb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                b_save_Click(sender, e);
            }
                else 
                if(e.KeyCode ==Keys.Down)
                {
                    B_gj_Click(sender, e);
                }
            else
                if (e.KeyCode == Keys.Escape) { b_exit_Click(sender, e); }
        }
    }
}