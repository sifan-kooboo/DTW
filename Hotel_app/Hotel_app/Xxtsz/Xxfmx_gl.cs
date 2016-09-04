using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_gl : Form
    {
        public string get_sel_cond = "";//最终获取的查询条件
        public Xxfmx_gl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            Cursor.Current = Cursors.Default;

        }
        private void gl()
        {
            int istj = 0;
            if (Cb_is_tj_kc.Checked)
            {
                istj = 1;
 
            }
            string sel_cond = " and is_tj_kc='" + istj + "'";
            
            if (tB_mxbh.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and mxbh like'%" + tB_mxbh.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_xfdr.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xfdr like'%" + tB_xfdr.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_xfxr.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xfxr like'%" + tB_xfxr.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_xfmx.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xfmx like'%" + tB_xfmx.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_xfje.Text.Trim().Replace("'", "-") != "")
            {
                if ((Maticsoft.Common.PageValidate.IsDecimal(tB_xfje.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_xfje.Text.Trim())) == false)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的进价金额不是有效数字！");
                    tB_xfje.Focus();

                }
                else
                {
                    sel_cond = sel_cond + " and xfje like'%" + tB_xfje.Text.Trim().Replace("'", "-") + "%'";
                }

            }
            if (tB_jjje.Text.Trim().Replace("'", "-") != "")
            {
                if ((Maticsoft.Common.PageValidate.IsDecimal(tB_jjje.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_jjje.Text.Trim())) == false)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的进价金额不是有效数字！");
                    tB_jjje.Focus();

                }
                else
                {
                    sel_cond = sel_cond + " and jjje like'%" + tB_jjje.Text.Trim().Replace("'", "-") + "%'";
                }

            }


            if (tB_zjm.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and zjm like'%" + tB_zjm.Text.Trim().Replace("'", "-") + "%'";

            }

            if (tB_xfcd.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xf_cd like'%" + tB_xfcd.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_xfdw.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xf_dw like'%" + tB_xfdw.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_xftm.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xftm like'%" + tB_xftm.Text.Trim().Replace("'", "-") + "%'";

            }

            //common_file.common_app.Message_box_show(common_file.common_app.message_title, "" + sel_cond + "");
            if (sel_cond != "")
            {
                get_sel_cond = sel_cond;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_xsy_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xxfdr", tB_xfdr);
        }
        private void display_new_commonform_1(string judge_type_0, TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = common_file.common_app.x();
            X_common_one_new.Top = common_file.common_app.y();
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                tB_xfxr.Text = "";
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;

        }

        private void b_xfxr_Click(object sender, EventArgs e)
        {
            display_new_commonform_2("Xxfxr", tB_xfxr);
        }
        private void display_new_commonform_2(string judge_type_0, TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one(tB_xfdr.Text);
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = common_file.common_app.x();
            X_common_one_new.Top = common_file.common_app.y();
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {

                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;

        }

        private void Xxfmx_gl_Load(object sender, EventArgs e)
        {
            this.tB_xftm.Focus();
        }
    }
}