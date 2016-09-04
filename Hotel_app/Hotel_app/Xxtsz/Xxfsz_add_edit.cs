using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfsz_add_edit : Form
    {
        public string Xxfxr_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Xxfsz_browse parent_form;
         #region 自定义方法
        public Xxfsz_add_edit(Xxfsz_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion

        public Xxfsz_add_edit()
        {
            InitializeComponent();
        }
       

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_xrbh.Text == string.Empty)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，消费编号不能为空");
                tB_xrbh.Focus();

            }
           else if (tB_xfdr.Text == string.Empty)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，消费大类不能为空");
                tB_xfdr.Focus();

            }
            else if (tB_xfxr.Text == string.Empty)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，消费小类不能为空");
                tB_xfxr.Focus();

            }
            else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_xfjg.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_xfjg.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的房价有效数字！");
                tB_xfjg.Focus();
            }
            else
            {
                int judge_save = 3;//3保存，其余不保存
                judge_save = common_file.common_app.get_judge_repeat("Xxfxr", "xrbh", "消费编号已经存在了", tB_xrbh.Text, judge_add_edit,Xxfxr_id);
                if (judge_save == 3)
                {

                    judge_save = common_file.common_app.get_judge_repeat("Xxfxr", "xfxr", "对不起，消费小类原来就存在了！", tB_xfxr.Text, judge_add_edit,Xxfxr_id);

                }
                if (judge_save == 3)
                {
                    string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                    object[] args = new object[11];
                    args[0] = Xxfxr_id;
                    args[1] = common_file.common_app.yydh;
                    args[2] = common_file.common_app.qymc;
                    args[3] = GetDrbh(tB_xfdr.Text);
                   
                    args[4] = tB_xfdr.Text.Trim().Replace("'", "-");
                    args[5] = tB_xrbh.Text.Trim().Replace("'", "-");
                    args[6] = tB_xfxr.Text.Trim().Replace("'", "-");
                    args[7] = tB_xfjg.Text.Trim().Replace("'", "-");
                    args[8] = Cb_visible_bb.Checked;
                    args[9] = judge_add_edit;
                    args[10] = common_file.common_app.xxzs;

                    Hotel_app.Server.Xxtsz.Xxfsz Xxfsz_services = new Hotel_app.Server.Xxtsz.Xxfsz();
                    string result = Xxfsz_services.Xxfsz_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(),bool.Parse(args[8].ToString()), args[9].ToString(), args[10].ToString());
                   // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfsz_add_edit", args);
                    if (result== common_file.common_app.get_suc)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                        if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_xfxr.Text = "";  tB_xrbh.Focus(); tB_xrbh.Text = ""; tB_xfjg.Text = ""; }
                        else if (judge_add_edit == common_file.common_app.get_edit) { parent_form.refresh_app(); this.Close(); }

                    }
                    else
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

               
                        //(id, yydh, qymc, drbh, xfdr, xrbh, xfxr, xfje, is_top, is_select, add_edit_delete, xxzs);
 
                }
            }
            Cursor.Current = Cursors.Default;
            
        }

        private void b_xsy_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xxfdr", tB_xfdr.Left +300, tB_xfdr.Top + 150, tB_xfdr);
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
        public string GetDrbh(string xfdr)
        {
            string drbh = "";
            BLL.Xxfdr B_Xxfdr= new BLL.Xxfdr();
            Model.Xxfdr M_Xxfdr = new Model.Xxfdr();
            DataSet ds = B_Xxfdr.GetList("xfdr='"+xfdr+"'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                drbh = ds.Tables[0].Rows[0]["drbh"].ToString();
            }
            else
            {
                drbh = "";
            }

            return drbh;
        }

       
    }
}