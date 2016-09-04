using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qyddj_skczzd_hz : Form
    {
        public string sktt = "sk";
        public string sktt_bz = "";
        public string lsbh = "";
        public string ddbh = "";
        public string krxm = "";
        public string get_sktt = "";
        public Qyddj_skczzd_hz(string sktt_0, string lsbh_0,string ddbh_0,string krxm_0, string sktt_bz_0)
        {
            sktt = sktt_0;
            lsbh = lsbh_0;
            ddbh = ddbh_0;
            sktt_bz = sktt_bz_0;
            krxm = krxm_0;
            InitializeComponent();
            ini_app();
        }

        public void ini_app()
        {
            if (sktt == "sk")
            {
                b_sk.Visible = true;
                b_cz.Visible = true;
                b_zd.Visible = true;
            }
            else
                if (sktt == "tt")
                {
                    b_tt.Visible = true;
                    b_tt.Top = 23;
                    b_hy.Visible = true;
                    b_hy.Top = 23;

                }
        }

        private void start_hz()
        {
            common_file.common_app.get_czsj();
            if (sktt_bz == get_sktt)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人已经是" + get_sktt + "了！不必再重复转换！");
                return;

            }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要将客人从" + sktt_bz + "转成" + get_sktt + "！") == true)
            { 
                common_file.common_app.get_czsj();
                string url = common_file.common_app.service_url;
                url += "Qyddj/Qyddj_app.asmx";
                object[] args = new object[12];
                args[0] = common_file.common_app.yydh;
                args[1] = common_file.common_app.qymc;
                args[2] = sktt;
                args[3] = lsbh;
                args[4] = krxm;
                args[5] = ddbh;
                args[6] = "";
                args[7] = sktt_bz;
                args[8] = get_sktt;
                args[9] = common_file.common_app.czy;
                args[10] = DateTime.Now;
                args[11] = common_file.common_app.xxzs;
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "sktt_hz", args);
                Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1();
                string result = Qyddj_add_edit_delete_1_services.sktt_hz(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(),DateTime.Parse(args[10].ToString()), args[11].ToString());
                if (result != null && result== common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                    this.Close();
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                
                }
            }
            Cursor.Current = Cursors.Default;

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void b_sk_Click(object sender, EventArgs e)
        {
            get_sktt = common_file.common_sktt.sktt_sk;
            start_hz();
        }

        private void b_cz_Click(object sender, EventArgs e)
        {
            get_sktt = common_file.common_sktt.sktt_cz;
            start_hz();
        }

        private void b_zd_Click(object sender, EventArgs e)
        {
            get_sktt = common_file.common_sktt.sktt_zd;
            start_hz();
        }

        private void b_tt_Click(object sender, EventArgs e)
        {
            get_sktt = common_file.common_sktt.sktt_tt;
            start_hz();
        }

        private void b_hy_Click(object sender, EventArgs e)
        {
            get_sktt = common_file.common_sktt.sktt_hy;
            start_hz();
        }
    }
}