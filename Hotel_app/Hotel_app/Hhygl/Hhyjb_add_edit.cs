using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyjb_add_edit : Form
    {
        public Hhyjb_browse parent_form;
        public string Hhyjb_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        Model.Hhyjb M_Hhyjb = new Model.Hhyjb();
        BLL.Hhyjb B_Hhyjb = new BLL.Hhyjb();
        public Hhyjb_add_edit()
        {
            InitializeComponent();
        }

         #region 自定义方法
        public Hhyjb_add_edit(Hhyjb_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
        }
        #endregion
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_jbxs.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "系数不能为空");
                tB_jbxs.Focus();
            }
          else  if(tB_hyrx.Text=="")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title,"会员类型不能为空");
                tB_hyrx.Focus();

            }
            else if (tB_dfjf.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "升级积分不能为空");
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
            //id,yydh,qymc,jbxs,hyrx,dfjf,is_top,is_select
            int judge_save = 3;//3保存，其余不保存
            judge_save = common_file.common_app.get_judge_repeat("Hhyjb", "jbxs", "系数已经存在了", tB_jbxs.Text, judge_add_edit,Hhyjb_id);
            judge_save = common_file.common_app.get_judge_repeat("Hhyjb", "hyrx", "会员类型已经存在了", tB_hyrx.Text, judge_add_edit, Hhyjb_id);
            if (judge_save == 3)
            {
                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                object[] args = new object[8];
                args[0] = Hhyjb_id;
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] = tB_jbxs.Text.Trim().Replace("'", "-");
                args[4] = tB_hyrx.Text.Trim().Replace("'", "-");
                args[5] = tB_dfjf.Text.Trim().Replace("'", "-");
                args[6] = judge_add_edit;
                args[7] = common_file.common_app.xxzs;

                Hotel_app.Server.Hhygl.Hhyjb Hhyjb_services = new Hotel_app.Server.Hhygl.Hhyjb();
                string result = Hhyjb_services.Hhyjb_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjb_add_edit", args);
                if (result== common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                    if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_jbxs.Text = ""; tB_jbxs.Focus(); tB_hyrx.Text = ""; tB_dfjf.Text = ""; }
                    else if (judge_add_edit == common_file.common_app.get_edit) 
                    { 
                        parent_form.refresh_app();
                        this.Close();
                    }

                }
                else
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}