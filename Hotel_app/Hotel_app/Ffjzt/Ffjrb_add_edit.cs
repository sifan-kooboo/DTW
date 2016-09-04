using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjrb_add_edit : Form
    {
        public Ffjrb_browse parent_form;//传递父窗体
        public Ffjrb_add_edit(Ffjrb_browse F_temp)
        {
            InitializeComponent();
            parent_form = F_temp;
        }

        public Ffjrb_add_edit()
        {
            InitializeComponent();
        }

        public string judge_add_edit = common_file.common_app.get_add;
        public string Ffjrb_id = "";
        public BLL.Common B_Common = new Hotel_app.BLL.Common();



        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_fjrb_code.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，代码不能为空！");
                tB_fjrb_code.Focus();
            }
            else
                if (tB_fjrb.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房型不能为空！");
                    tB_fjrb.Focus();
                }
                else
                    if (tB_sjjg.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房价不能为空！");
                        tB_sjjg.Focus();
                    }
                    else
                        if (Maticsoft.Common.PageValidate.IsNumber(tB_sjjg.Text.Trim()) == false && Maticsoft.Common.PageValidate.IsDecimal(tB_sjjg.Text.Trim()) == false)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的房价不是有效数字！");
                            tB_sjjg.Focus();
                        }
                        else
                            if (tB_zyrs.Text.Trim() == "")
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，预占人数不能为空！");
                                tB_zyrs.Focus();
                            }
                        else
                                if (Maticsoft.Common.PageValidate.IsNumber(tB_zyrs.Text.Trim()) == false && Maticsoft.Common.PageValidate.IsDecimal(tB_zyrs.Text.Trim()) == false)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，预占人数不是有效数字！");
                                tB_zyrs.Focus();
                            }
                    else
                    {
                        int judge_save = 3;//3保存，其余不保存

                        judge_save = common_file.common_app.get_judge_repeat("Ffjrb", "fjrb_code", "对不起，代码原来就存在了！", tB_fjrb_code.Text, judge_add_edit, Ffjrb_id);


                        if (judge_save == 3)
                        {

                            judge_save = common_file.common_app.get_judge_repeat("Ffjrb", "fjrb", "对不起，房型原来就存在了！", tB_fjrb.Text, judge_add_edit, Ffjrb_id);

                        }
                        if (judge_save == 3)
                        {
                            string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                            string[] args = new string[9];
                            args[0] = Ffjrb_id;
                            args[1] = common_file.common_app.yydh;
                            args[2] = common_file.common_app.qymc;
                            args[3] = tB_fjrb_code.Text.Trim().Replace("'", "//");
                            args[4] = tB_fjrb.Text.Trim().Replace("'", "//");
                            args[5] = tB_sjjg.Text.Trim().Replace("'", "//");
                            args[6] = tB_zyrs.Text.Trim().Replace("'", "//");
                            args[7] = judge_add_edit;
                            args[8] = common_file.common_app.xxzs;

                            Hotel_app.Server.Ffjzt.Ffjzt_app  Ffjzt_app_services=new Hotel_app.Server.Ffjzt.Ffjzt_app();
                            string result = Ffjzt_app_services.Ffjrb_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(),
 args[8].ToString());

                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Ffjrb_add_edit", args);
                            if (result== common_file.common_app.get_suc)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                                if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_fjrb_code.Text = ""; tB_fjrb_code.Focus(); tB_fjrb.Text = ""; tB_sjjg.Text = "0"; tB_zyrs.Text = "1"; }
                                else if (judge_add_edit == common_file.common_app.get_edit) { parent_form.refresh_app(); this.Close(); }
                            
                            }
                            else
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                        }

                    }

            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void tB_sjjg_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void tB_fjrb_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                b_save_Click(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { b_exit_Click(sender, e); }
        }

        private void tB_zyrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }
    }
}