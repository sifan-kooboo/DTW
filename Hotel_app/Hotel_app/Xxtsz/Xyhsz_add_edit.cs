using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xyhsz_add_edit : Form
    {
        #region 自定义成员
        public string Xyhsz_id= "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Xyhsz_browse parent_form;

        #endregion

        #region 自定义方法
        public Xyhsz_add_edit(Xyhsz_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion

        public Xyhsz_add_edit()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            //Cursor.Current = Cursors.WaitCursor;
            if (tB_yhbl.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，优惠比例不能为空！");
                tB_yhbl.Focus();
            }
            else
                if (tB_yh.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，优惠不能为空！");
                    tB_yh.Focus();
                }
                else
                {
                    int judge_save = 3;//3保存，其余不保存
                    judge_save = common_file.common_app.get_judge_repeat("Xyhsz", "yh", "优惠已经存在了", tB_yh.Text, judge_add_edit, Xyhsz_id);
                    if (judge_save == 3)
                    {
                        string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                        object[] args = new object[7];
                        args[0] = Xyhsz_id;
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = tB_yhbl.Text.Trim().Replace("'", "-");
                        args[4] = tB_yh.Text.Trim().Replace("'", "-");

                        args[5] = judge_add_edit;
                        args[6] = common_file.common_app.xxzs;

                        Hotel_app.Server.Xxtsz.Xyhsz Xyhsz_services = new Hotel_app.Server.Xxtsz.Xyhsz();
                        string result = Xyhsz_services.Xyhsz_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xyhsz_add_edit", args);
                        if (result!=null&&result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_yhbl.Text = ""; tB_yhbl.Focus(); tB_yh.Text = ""; }
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