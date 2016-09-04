using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Frm_txftsz : Form
    {
        public Frm_txftsz()
        {
            InitializeComponent();
            loadInital();
        }

        //精简: w_s:52  h_s:58   详细：w_l:86  h:92
        string  fx_hor = "";//水平房数
        string fj_jj = ""; //房间间距
        int fx_height = 0;//高度
        int fx_width =0;//宽度

        string ft_old = "";
        string ft_new = "";
        public bool isNeedRefresh = false;
        string web_server = "";
        string app_Version = "";
        //打开加载当前
        private void loadInital()
        {
            fx_hor = common_file.Common_initalSystem.ReadXML("add", "big_horizon_NO");
            fj_jj = common_file.Common_initalSystem.ReadXML("add", "big_pic_space");
            fx_height =int.Parse(common_file.Common_initalSystem.ReadXML("add", "big_pic_height").ToString());
            fx_width = int.Parse(common_file.Common_initalSystem.ReadXML("add", "big_pic_width").ToString());
            web_server=common_file.Common_initalSystem.ReadXML("add","webServer");
            app_Version =System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\hotel_app.exe").ProductVersion;
            if (fx_height < 80)
            {
                cb_ft.SelectedIndex = 0;
                ft_old = "simple";
            }
            else
            {
                cb_ft.SelectedIndex = 1;
                ft_old = "detail";
            }
            tB_ft_sl.Text = fx_hor;
            tB_ft_distance.Text = fj_jj;
            //tB_ft_height.Text = fx_height;
            //tB_ft_width.Text = fx_width;
            tb_webserver.Text = web_server;
            tb_SysteVersion.Text = app_Version;
        }

        private void Save()
        {
            common_file.common_app.get_czsj();
            if (Maticsoft.Common.PageValidate.IsNumber(tB_ft_sl.Text.Trim())== false)
            {
                common_file.common_app.get_czsj();
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的值不是有效整数值！");
                tB_ft_sl.Focus();
                tB_ft_sl.SelectAll(); return;
            }
            if (Maticsoft.Common.PageValidate.IsNumber(tB_ft_distance.Text.Trim()) == false)
            {
                common_file.common_app.get_czsj();
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的值不是有效整数值！");
                tB_ft_distance.Focus();
                tB_ft_distance.SelectAll(); return;
            }
            //if (Maticsoft.Common.PageValidate.IsNumber(tB_ft_height.Text.Trim()) == false)
            //{
            //    common_file.common_app.get_czsj();
            //    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的值不是有效整数值！");
            //    //tB_ft_height.Focus();
            //   // tB_ft_height.SelectAll(); return;
            //}
            //if (Maticsoft.Common.PageValidate.IsNumber(tB_ft_width.Text.Trim()) == false)
            //{
            //    common_file.common_app.get_czsj();
            //    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的值不是有效整数值！");
            //    //tB_ft_width.Focus();
            //    //tB_ft_width.SelectAll(); return;
            //}
            if (tb_webserver.Text.Trim().Equals(""))
            {
                common_file.common_app.get_czsj();
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,请输入服务端地址！以http://开头，并以/结尾。");
                tb_webserver.Focus();
                tb_webserver.SelectAll(); return;
            }
            if(cb_ft.Text=="精简房态")
            {
                ft_new="simple";
                fx_width = 64;
                fx_height = 64;
            }
            else
	{
        ft_new = "detail"; fx_width = 86;
        fx_height = 92;
	}

            if (!ft_new.Equals(ft_old))
            {
                isNeedRefresh = true;
            }
            try
            {
                common_file.common_app.get_czsj();
                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "big_horizon_NO", tB_ft_sl.Text.Trim());
                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "big_pic_space", tB_ft_distance.Text.Trim());
                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "big_pic_height",fx_height.ToString());
                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "big_pic_width", fx_width.ToString());
                common_file.Common_initalSystem.SaveConfig("XmlSystemInfo.xml", "webServer", tb_webserver.Text.Trim());
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，保存出错.");
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void tb_qymc_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_TestServer_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            string url = common_file.common_app.service_url + "Service1.asmx";
            object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "HelloServer", null);
            if (result != null && result.ToString() == common_file.common_app.get_suc)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "恭喜您,连接远程服务端成程,您的服务端配置正确,请及时点击保存按钮进行设置的保存!");
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "服务端配置不正确,请确认URL地址");
                return;
            }
            Cursor.Current = Cursors.Default;
        }

        private void Frm_txftsz_Load(object sender, EventArgs e)
        {

        }
    }
}
