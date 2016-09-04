using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyfj_add_edit : Form
    {
        public string Hhyfj_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Hhyfj_browse parent_form;//传递父窗体
        public Hhyfj_add_edit()
        {
            InitializeComponent();
            common_file.common_hy.Bindhyrx(cB_hyrx);
        }
        public Hhyfj_add_edit(Hhyfj_browse F_temp)
        {
            InitializeComponent();
            common_file.common_hy.Bindhyrx(cB_hyrx);
            parent_form = F_temp;
        }
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (cB_hyrx.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，会员类型不能为空");
                cB_hyrx.Focus();
            }
         else if (tB_fjrb.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房间类型不能为空");
                tB_fjrb.Focus();
            }
            else if (tB_hyfj.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，房价不能为空");
                tB_hyfj.Focus();
 
            }
            else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_hyfj.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_hyfj.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的价格不是有效数值！");
                tB_hyfj.Focus();

            }
            else
            {
                if (save_new() == common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功");
                    if (judge_add_edit == common_file.common_app.get_add)
                    {
                        parent_form.refresh_app();

          
                        tB_hyfj.Text = "";
                
                    }
                    else if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        parent_form.refresh_app();
                        this.Close();
                    }

                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                }
 
            }
            Cursor.Current = Cursors.Default;

        }
       public string save_new()
        {
            //id,yydh,qymc,hyrx,fjrb,hyfj,bz,shsc,is_top,is_select
            string s = common_file.common_app.get_failure;
            string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
            object[] args = new object[9];
            args[0] = Hhyfj_id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = cB_hyrx.Text.Trim().Replace("'","-");
            args[4] = tB_fjrb.Text.Trim().Replace("'", "-");
            args[5] = tB_hyfj.Text.Trim().Replace("'", "-");
            args[6] = "";
            args[7] = judge_add_edit;
            args[8] = common_file.common_app.xxzs;
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyfj_add_edit", args);
            Hotel_app.Server.Hhygl.Hhyfj Hhyfj_services = new Hotel_app.Server.Hhygl.Hhyfj();
            string   result= Hhyfj_services.Hhyfj_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());
            if (result== common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        private void b_dfxm_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Ffjrb", tB_fjrb.Left, tB_fjrb.Top + 50, tB_fjrb);
        }
        private void display_new_commonform_1(string judge_type_0, int left_0, int top_0, TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = left_0;
            X_common_one_new.Top = top_0;
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       
    }
}