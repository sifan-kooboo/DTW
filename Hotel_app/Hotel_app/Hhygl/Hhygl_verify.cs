using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhygl_verify :Form
    {
        public Hhygl_verify(string  _phoneNo)
        {
            InitializeComponent();
            this.phoneNo = _phoneNo;
            txt_code.Enabled = false;
            b_confirm.Enabled = false;
            b_getCode.Text = "点击获取验证码";

        }

        public int i = 120;
        private string phoneNo = "";

        private void b_getCode_Click(object sender, EventArgs e)
        {
            Hotel_app.Server.Hhygl.Hhygl_verifyCode Hhygl_verifyCode = new Hotel_app.Server.Hhygl.Hhygl_verifyCode();
            if ((Hhygl_verifyCode.generateVerifyCode(phoneNo, "Test", "", common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.xxzs)).Equals(common_file.common_app.get_suc))
            {
                timer1.Enabled = true;
                timer1.Interval = 1000;
                b_getCode.Enabled = false;
                txt_code.Enabled = true;
                b_confirm.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b_getCode.Text = i.ToString() + "秒后点击重发";
            i = i - 1;
            if (i < 0)
            {
                timer1.Enabled = false;
                txt_code.Enabled = false;
                b_getCode.Enabled = true;
                b_getCode.Text = "重新获取验证码";
            }
        }

        private void b_confirm_Click(object sender, EventArgs e)
        {
            //Hotel_app.Server.Hhygl_app Hhygl_app_services_new = new Hotel_app.Server.Hhygl_app();
            //Hhygl_app_services_new.Url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
            Hotel_app.Server.Hhygl.Hhygl_verifyCode Hhygl_verifyCode_services = new Hotel_app.Server.Hhygl.Hhygl_verifyCode();

            string result = Hhygl_verifyCode_services.CheckVerifyCode(phoneNo, txt_code.Text, common_file.common_app.yydh, common_file.common_app.qymc, "", "", common_file.common_app.xxzs);
            if(result.Equals(common_file.common_app.get_suc))
            {
                this.DialogResult=DialogResult.OK;
                common_file.common_app.Message_box_show(common_file.common_app.message_title,"恭喜,验证成功");
            }
            else
	{
                txt_code.SelectAll();
                common_file.common_app.Message_box_show(common_file.common_app.message_title,"对不起,验证码不正确,请重新输入!");
	}
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}