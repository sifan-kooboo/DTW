using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class S_jkzd_add_0 : Form
    {
        string syzd = "";
        DateTime jksj = DateTime.Now;
        public S_jkzd_add_0(string syzd_0, DateTime jksj_0)
        {
            jksj = jksj_0;
            
            syzd = syzd_0;
            InitializeComponent();
            dT_czsj_cs.Value = jksj;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            jksj=dT_czsj_cs.Value;
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要重做" + jksj.ToShortDateString() + "的交款明细？") == true)
            {
                string url = common_file.common_app.service_url;
                url += "Szwgl/Szwgl_app.asmx";
                object[] args = new object[11];
                args[0] = common_file.common_app.yydh;
                args[1] = common_file.common_app.qymc;
                args[2] = common_file.common_app.czy;
                args[3] = common_file.common_app.czy;
                args[4] = "";
                args[5] = jksj;
                args[6] = common_file.common_app.czy;
                args[7] = "";
                args[8] = common_zw.jb_jk_jk;
                args[9] = common_file.common_app.xxzs_zsvalue;
                args[10] = common_file.common_app.czy_GUID;
                Hotel_app.Server.Szwgl.S_jb_jk_fx S_jb_jk_fx_services = new Hotel_app.Server.Szwgl.S_jb_jk_fx();
                string result = S_jb_jk_fx_services.cz_jk_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), DateTime.Parse(args[5].ToString()), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString());

                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "cz_jk_app", args);
                if (result== common_file.common_app.get_suc)
                {
                    common_file.common_app.get_czsj();
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                }
                Cursor.Current = Cursors.Default;
            }

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}