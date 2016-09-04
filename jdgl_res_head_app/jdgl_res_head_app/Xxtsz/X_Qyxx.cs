using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jdgl_res_head_app.Xxtsz
{
    public partial class X_Qyxx : Form
    {
        public X_Qyxx()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            string strqymc = this.tB_qymc.Text.Trim();
            string stryydh = this.tB_yydh.Text.Trim();
            string strbb = this.tB_bb.Text.Trim();
            if (strqymc != "" && stryydh != "" && strbb != "")
            {
                try
                {
                    common_file.Common.SaveConfig("qymc", strqymc);
                    common_file.Common.SaveConfig("yydh", stryydh);
                    common_file.Common.SaveConfig("appversion", strbb);
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "信息修改成功");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
        }

        private void X_Qyxx_Load(object sender, EventArgs e)
        {
            tB_bb.Text = common_file.Common.ReadXML("add", "appversion");
            tB_qymc.Text = common_file.Common.ReadXML("add", "qymc");
            tB_yydh.Text = common_file.Common.ReadXML("add", "yydh");
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}