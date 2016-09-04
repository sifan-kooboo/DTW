using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfdr_add_edit : Form
    {
        public string Xxfxr_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Xxfdr_browse parent_form;
         #region 自定义方法
        public Xxfdr_add_edit(Xxfdr_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion

        public Xxfdr_add_edit()
        {
            InitializeComponent();
        }
       

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_drbh.Text == string.Empty)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，消费编号不能为空");
                tB_drbh.Focus();

            }
           else if (tB_xfdr.Text == string.Empty)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，消费大类不能为空");
                tB_xfdr.Focus();

            }
            
           else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_xfjg.Text.Trim())||Maticsoft.Common.PageValidate.IsNumber(tB_xfjg.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的房价有效数字！");
                tB_xfjg.Focus();
            }
            else
            {
                int judge_save = 3;//3保存，其余不保存
                judge_save = common_file.common_app.get_judge_repeat("Xxfdr", "drbh", "消费编号已经存在了", tB_drbh.Text, judge_add_edit,Xxfxr_id);
                if (judge_save == 3)
                {

                    judge_save = common_file.common_app.get_judge_repeat("Xxfdr", "xfdr", "对不起，消费大类原来就存在了！", tB_xfdr.Text, judge_add_edit,Xxfxr_id);

                }
                if (judge_save == 3)
                {

                    string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                    object[] args = new object[9];
                    args[0] = Xxfxr_id;
                    args[1] = common_file.common_app.yydh;
                    args[2] = common_file.common_app.qymc;

                    args[3] = tB_drbh.Text.Trim().Replace("'", "-");
                    args[4] = tB_xfdr.Text.Trim().Replace("'", "-");
                    args[5] = tB_xfjg.Text.Trim().Replace("'", "-");
                    args[6] = Cb_visible_bb.Checked;
                    args[7] = judge_add_edit;
                    args[8] = common_file.common_app.xxzs;
                    Hotel_app.Server.Xxtsz.Xxfdr Xxfdr_services = new Hotel_app.Server.Xxtsz.Xxfdr();
                    string result = Xxfdr_services.Xxfdr_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(),bool.Parse(args[6].ToString()), args[7].ToString(), args[8].ToString());
                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfdr_add_edit", args);
                    if (result== common_file.common_app.get_suc)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                        if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app();tB_xfdr.Text = ""; tB_drbh.Focus(); tB_drbh.Text = ""; tB_xfjg.Text = ""; }
                        else if (judge_add_edit == common_file.common_app.get_edit) { parent_form.refresh_app(); this.Close(); }

                    }
                    else
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

               
                        //(id, yydh, qymc, drbh, xfdr, xrbh, xfxr, xfje, is_top, is_select, add_edit_delete, xxzs);
 
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