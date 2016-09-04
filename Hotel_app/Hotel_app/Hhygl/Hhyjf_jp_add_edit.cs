using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyjf_jp_add_edit : Form
    {
        public string Hhyjfjp_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Hhyjf_jp_browes parent_form;
        public Hhyjf_jp_add_edit()
        {
            InitializeComponent();
        }
         #region 自定义方法
        public Hhyjf_jp_add_edit(Hhyjf_jp_browes Form_temp)
        {
            InitializeComponent();
        
            this.parent_form = Form_temp;
        }
        #endregion
        private void b_jpclass_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Hhyjf_jp_Class", tB_classname.Left, tB_classname.Top + 50, tB_classname);
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

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_classname.Text.Trim()== "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，奖品类型不能为空。");
                tB_classname.Focus();

            }
          else  if (tB_Title.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，奖品名称不能为空。");
                tB_Title.Focus();

            }
            else if (tB_dfjf.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，奖品积分不能为空。");
                tB_dfjf.Focus();
 
            }
            else if ((Maticsoft.Common.PageValidate.IsDecimal(tB_dfjf.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_dfjf.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的积分不是有效数字！");
                tB_dfjf.Focus();
            }
            else
            {
                Save_new();
 
            }
            Cursor.Current = Cursors.Default;
            
        }
        void Save_new()
        {
           //id, yydh, qymc, classname, title, jpjf, simg, bimg, info, bz, hyjfrx, add_edit_delete, xxzs
                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                object[] args = new object[13];
                args[0] = Hhyjfjp_id;
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] = tB_classname.Text.Trim().Replace("'", "-");
                args[4] = tB_Title.Text.Trim().Replace("'", "-");
                args[5] = tB_dfjf.Text.Trim().Replace("'", "-");
                args[6] = "";
                args[7] = "";
                args[8] = "";
                args[9] = tB_bz.Text.Trim().Replace("'", "-");
                args[10] = common_file.common_app.hyjfrx;
                args[11] = judge_add_edit;
                args[12] = common_file.common_app.xxzs;

                Hotel_app.Server.Hhygl.Hhyjf_jp Hhyjf_jp_services = new Hotel_app.Server.Hhygl.Hhyjf_jp();
                string result = Hhyjf_jp_services.Hhyjfjp_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfjp_add_edit", args);
                if (result== common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                    if (judge_add_edit == common_file.common_app.get_add)
                    { 
                        parent_form.refresh_app(); 
            
                        tB_classname.Focus();
                        tB_dfjf.Text = ""; 
                        tB_Title.Text="";
                        tB_bz.Text = "";
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

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

       
    }
}