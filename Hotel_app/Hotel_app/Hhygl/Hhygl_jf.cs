using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhygl_jf : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        Model.Hhygl M_Hhygl = new Model.Hhygl();
        BLL.Hhygl B_Hhygl = new BLL.Hhygl();
        public string hyid_0;
        public string hykh = "";
        public Hhygl_jf()
        {
            InitializeComponent();
            
        }
        
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            string strhykh = this.tB_hykh.Text.Trim();
            string strgetdate = DateTime.Now.ToShortDateString();
           
               common_file.common_app.get_czsj();
               string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";

               //状态为空的时候(为新增记录),生成临时编号

              // Hhyjf_gc_app_news(hykh, yydh, qymc, id_app, lsbh, sjxfje, czy);
               string stryydh = common_file.common_app.yydh;
               string strqymc = common_file.common_app.qymc;
               string[] args = new string[6];
               args[0] = hykh;
               args[1] = stryydh;
               args[2] = strqymc;
               args[3] = hykh;
               args[4] = tB_zg.Text.Trim().Replace("'", "-");
               args[5] = common_file.common_app.czy;
               Hotel_app.Server.Hhygl.Hhyjf_xfjl Hhyjf_xfjl_services = new Hotel_app.Server.Hhygl.Hhyjf_xfjl();
               string result = Hhyjf_xfjl_services.Hhyjf_gc_app_news(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString());
             //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjf_gc_app_news", args);
             if (result== common_file.common_app.get_suc)
             {
                 common_file.common_app.Message_box_show(common_file.common_app.message_title, "增补积分成功！");
                 common_file.common_hy.Hhygl_browse_new.refresh_app();
                 common_file.common_hy.Hhygl_browse_new.open_record();
                 this.Close();
             }
             else
             {
                 common_file.common_app.Message_box_show(common_file.common_app.message_title, "增补积分出错！");
 
             }
             Cursor.Current = Cursors.Default;
    
           
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}