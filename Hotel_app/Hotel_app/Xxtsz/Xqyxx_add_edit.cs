using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xqyxx_add_edit : Form
    {
        #region 自定义成员
        public string Xqyxx_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Xqyxx_browse parent_form;

        #endregion

        #region 自定义方法
        public Xqyxx_add_edit(Xqyxx_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion

        public Xqyxx_add_edit()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            //Cursor.Current = Cursors.WaitCursor;
          
            if (tB_qymc.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人类型不能为空！");
                tB_qymc.Focus();
            }
            else
                if (tB_qybh.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，助记码不能为空！");
                    tB_qybh.Focus();
                }
                else
                {
                    int judge_save = 3;//3保存，其余不保存
                    judge_save = common_file.common_app.get_judge_repeat("Xqyxx", "qymc", "客人类型已经存在了", tB_qymc.Text, judge_add_edit, Xqyxx_id);
                    if (judge_save == 3)
                    {
                        string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                        string[] args = new string[12];
                        args[0] = Xqyxx_id;
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = tB_zjm.Text.Trim().Replace("'", "-");
                        args[4] = tB_qybh.Text.Trim().Replace("'", "-");
                        args[5] = tB_qydh.Text.Trim().Replace("'", "-");
                        args[6] = tB_qycz.Text.Trim().Replace("'", "-");
                        args[7] = tB_Email.Text.Trim().Replace("'", "-");
                        args[8] = tB_nxr.Text.Trim().Replace("'", "-");
                        args[9] = tB_qydz.Text.Trim().Replace("'", "-");
                        args[10] = judge_add_edit;
                        args[11] = common_file.common_app.xxzs;

                        Hotel_app.Server.Xxtsz.Xqyxx Xqyxx_services = new Hotel_app.Server.Xxtsz.Xqyxx();
                        string result = Xqyxx_services.Xqyxx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString());                  
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xqyxx_add_edit", args);
                        if (result == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_qymc.Text = ""; tB_qymc.Focus(); tB_qybh.Text = ""; }
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