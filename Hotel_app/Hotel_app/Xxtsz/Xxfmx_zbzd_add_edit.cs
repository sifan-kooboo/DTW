using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_zbzd_add_edit : Form
    {
        public string Xxfxr_id = "";
        public String strlsbh = "";
        public string strissh = common_file.common_app.is_wsh;
        public string judge_add_edit = common_file.common_app.get_add;
        Model.Xxfmx_zbzd M_zbzd = new Model.Xxfmx_zbzd();
        BLL.Xxfmx_zbzd B_zbzd = new BLL.Xxfmx_zbzd();

        public Xxfmx_zbzd_browse parent_form;
         #region 自定义方法
        public Xxfmx_zbzd_add_edit(Xxfmx_zbzd_browse Form_temp)
        {
            InitializeComponent();
            this.parent_form = Form_temp;
            if (judge_add_edit == common_file.common_app.get_add)
            {
                this.Cb_is_tj_kc.Visible = false;
            }
        }
        #endregion

        public Xxfmx_zbzd_add_edit()
        {

            InitializeComponent();
        }

       
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (strissh == common_file.common_app.is_sh)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，审核通过就不能修改！");
                return;
            }
            else
            {
                SaveNew_xfmx();
            }
            Cursor.Current = Cursors.Default;
            
        }
         // 保存主单
        private void SaveNew_xfmx()
        {
            // id, yydh, qymc, lsbh, czy, zbsj, is_sh,zbnr, bz, sh_czy, add_edit_delete, xxzs

            if (judge_add_edit == common_file.common_app.get_add)
            {
                strlsbh = common_file.common_ddbh.ddbh("lkzd", "lsbhdate", "lsbhcounter", 6);
            }
            else
            {
                M_zbzd = B_zbzd.GetModel(int.Parse(Xxfxr_id));
                strlsbh = M_zbzd.lsbh;
            }

            bool f = Cb_is_tj_kc.Checked;
            if (f)
            {
                strissh = common_file.common_app.is_sh;
 
            }
            string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
            object[] args = new object[12];
            args[0] = Xxfxr_id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = strlsbh;
            args[4] = common_file.common_app.czy;
            args[5] = DateTime.Now.ToShortDateString();
            args[6] = strissh;
            args[7] = tB_zbnr.Text.Trim().Replace("'", "_");
            args[8] = tB_bz.Text.Trim().Replace("'", "_");
            if (f)
            {
                args[9] = common_file.common_app.czy;
            }
            else
            {
                args[9] = "";
            }
           
            args[10] = judge_add_edit;
            args[11] = common_file.common_app.xxzs;

            Hotel_app.Server.Xxtsz.Xxfmx_zbzd Xxfmx_zbzd_services = new Hotel_app.Server.Xxtsz.Xxfmx_zbzd();
            string result = Xxfmx_zbzd_services.Xxfmx_zbzd_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfmx_zbzd_add_edit", args);
            if (result== common_file.common_app.get_suc)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                if (judge_add_edit == common_file.common_app.get_add)
                {
                    parent_form.InitializeApp(); 
                    tB_bz.Text = "";
                    tB_zbnr.Text = "";

                }
                else if (judge_add_edit == common_file.common_app.get_edit) 
                {
                    parent_form.InitializeApp(); 
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