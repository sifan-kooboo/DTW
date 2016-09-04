using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyjf_jp_class_add_edit : Form
    {
         public string Hhyjfjpclass_id= "";
        public string judge_add_edit = common_file.common_app.get_add;
        public Hhyjf_jp_class_browes parent_form;
           #region 自定义方法
        public Hhyjf_jp_class_add_edit(Hhyjf_jp_class_browes Form_temp)
        {
            InitializeComponent();
        
            this.parent_form = Form_temp;
        }
        #endregion
        public Hhyjf_jp_class_add_edit()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_title.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，类型名称不能为空。");
                tB_title.Focus();
            }
            else
            {
                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                object[] args = new object[4];
                args[0] = Hhyjfjpclass_id;   
                args[1] = tB_title.Text.Trim().Replace("'", "-");
                args[2] = judge_add_edit;
                args[3] = common_file.common_app.xxzs;

                Hotel_app.Server.Hhygl.Hhyjf_jp_class Hhyjf_jp_class_services = new Hotel_app.Server.Hhygl.Hhyjf_jp_class();
                string result = Hhyjf_jp_class_services.Hhyjfjpclass_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString());

                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfjpclass_add_edit", args);
                if (result== common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                    if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_title.Text = ""; tB_title.Focus(); }
                    else if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        parent_form.refresh_app();
                        this.Close();
                    }

                }
                else
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}