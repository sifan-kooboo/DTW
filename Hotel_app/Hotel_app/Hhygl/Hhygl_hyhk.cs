using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhygl_hyhk : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        Model.Hhygl M_Hhygl = new Model.Hhygl();
        BLL.Hhygl B_Hhygl = new BLL.Hhygl();
        public string hyid_0;
        public string hykh = "";
        public Hhygl_hyhk()
        {
            InitializeComponent();
        }
        
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
           string strnewhykh = this.tB_newkh.Text.Trim();
           string stroldkh = this.tB_hykh.Text.Trim();
           if (strnewhykh != "")
           {
               string strgetdate = DateTime.Now.ToShortDateString();
               int judge_save = 3;//3保存，其余不保存
               judge_save = common_file.common_app.get_judge_repeat("Hhygl", "hykh_bz", "会员卡号已经存在了", strnewhykh, common_file.common_app.get_add, hyid_0);
               if (judge_save == 3)
               {
                   int isudok = B_Common.ExecuteSql("update Hhygl set hykh_bz='" + strnewhykh + "',shxg=1,xgsj=getdate()  where hykh='" + hykh + "' " + common_file.common_app.yydh_select);
                   if (isudok > 0)
                   {
                       common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "会员换卡", "" + strnewhykh + "", "旧的卡号" + stroldkh + "新的卡号:" + strnewhykh + "", DateTime.Now);

                       if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要写到卡里面，如果要请把会员卡放在读卡器上") == true)
                       {
                           H_hygl_k H_hygl_k_NEW = new H_hygl_k();
                           H_hygl_k_NEW.write_hykh(tB_newkh.Text.Trim());
                       }
                       common_file.common_app.Message_box_show(common_file.common_app.message_title, "换卡成功！");
                       common_file.common_hy.Hhygl_browse_new.refresh_app();
                       common_file.common_hy.Hhygl_browse_new.open_record();

                   }
                   else
                   {
                       common_file.common_app.Message_box_show(common_file.common_app.message_title, "换卡不成功！");
                   }
               }
           }
           Cursor.Current = Cursors.Default;
           
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_dk_Click(object sender, EventArgs e)
        {
            Hhygl.H_hygl_k H_hygl_k_new = new Hotel_app.Hhygl.H_hygl_k();
            H_hygl_k_new.add_hy_info_02("", true, ref tB_newkh);
        }
    }
}