using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xkrrx_add_edit : Form
    {
        #region 自定义成员
        public string Xkrrx_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Xkrrx_browse parent_form;

        #endregion

        #region 自定义方法
        public Xkrrx_add_edit(Xkrrx_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion

        public Xkrrx_add_edit()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            //Cursor.Current = Cursors.WaitCursor;
            if (tB_krrx.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人类型不能为空！");
                tB_krrx.Focus();
            }
            else
                if (tB_zjm.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，助记码不能为空！");
                    tB_zjm.Focus();
                }
                else
                {
                    int judge_save = 3;//3保存，其余不保存
                    judge_save = common_file.common_app.get_judge_repeat("Xkrrx", "krrx", "客人类型已经存在了", tB_krrx.Text, judge_add_edit, Xkrrx_id);
                    if (judge_save == 3)
                    {
                        string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                        string[] args = new string[7];
                        args[0] = Xkrrx_id;
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = tB_krrx.Text.Trim().Replace("'", "-");
                        args[4] = tB_zjm.Text.Trim().Replace("'", "-");
                        args[5] = judge_add_edit;
                        args[6] = common_file.common_app.xxzs;
                        Hotel_app.Server.Xxtsz.Xkrrx Xkrrx_services = new Hotel_app.Server.Xxtsz.Xkrrx();
                        string result = Xkrrx_services.Xkrrx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString());
                       // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xkrrx_add_edit", args);
                        if (result!=null&&result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_krrx.Text = ""; tB_krrx.Focus(); tB_zjm.Text = ""; }
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
            this.Close();
        }
    }
}