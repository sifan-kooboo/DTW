using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_gd_zd : Form
    {//"",lsbh_gd,sktt,zd_fjbh,zd_krxm_lz,zd_fjbh_lz,"zz"
        public Szw_gd_zd(string gd_jzbh, string gd_lsbh, string sktt,string gd_fjbh,string gd_krxm_lz,string gd_fjbh_lz,string gd_ddsj, string gd_Type)
        {
            InitializeComponent();
            this.zd_jzbh = gd_jzbh;
            this.zd_lsbh = gd_lsbh;
            this.zd_sktt = sktt;
            zd_fjbh=gd_fjbh;
            zd_krxm_lz=gd_krxm_lz;
            zd_fjbh_lz=gd_fjbh_lz;
            zd_ddsj = gd_ddsj;
            this.gd_Type = gd_Type;
            loadInfo();
        }
        public string zd_krxm = "";
        public string zd_fjbh="";
        public string zd_krxm_lz="";
        public string zd_fjbh_lz="";
        public string zd_ddsj = "";


        public string zd_jzbh = "";
        public string zd_lsbh = "";
        public string zd_sktt = "";//注意,zd_lsbh和sktt是一起用的,在住类型的改单
        public string gd_Type = "";
        StringBuilder sb = new StringBuilder();
        BLL.Common B_common;
        public void loadInfo()
        {
            if(gd_Type=="jz")
            {
            if (this.zd_jzbh.Trim() != "")
            {
                //读取原始结账主单的数据
                Model.Sjzzd M_sjzzd;
                BLL.Sjzzd B_sjzzd = new Hotel_app.BLL.Sjzzd();
                List<Model.Sjzzd> lists = new List<Hotel_app.Model.Sjzzd>();
                lists = B_sjzzd.GetModelList(" id>=0  and yydh='" + common_file.common_app.yydh + "'  and jzbh='" + zd_jzbh + "'");
                if (lists.Count > 0)
                {
                    M_sjzzd = lists[0];
                    tB_krxm.Text = M_sjzzd.krxm_lz;
                    tb_fjbh.Text = M_sjzzd.fjbh_lz;
                    dT_ddsj_date.Text = M_sjzzd.ddsj.Date.ToShortDateString();
                    dT_ddsj_time.Text = M_sjzzd.ddsj.TimeOfDay.ToString();
                    dT_lksj_date.Text = M_sjzzd.tfsj.ToShortDateString();
                    dT_lksj_time.Text = M_sjzzd.tfsj.TimeOfDay.ToString();
                    dT_jzsj_date.Text = M_sjzzd.tfsj.ToShortDateString();
                    dT_jzsj_Time.Text = M_sjzzd.tfsj.TimeOfDay.ToString();
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "读取原始主单出错!");
                    return;
                }
            }
            }
            if (gd_Type == "zz")
            {
                if (zd_lsbh.Trim() != "" && zd_sktt != "")
                {
                    if (zd_sktt == "sk")
                    { tb_fjbh.Text = zd_fjbh_lz; }
                    if (zd_sktt == "tt")
                    { tb_fjbh.Text = ""; }
                    tB_krxm.Text = zd_krxm_lz;

                    dT_ddsj_date.Text = DateTime.Parse(zd_ddsj).Date.ToShortDateString();
                    dT_ddsj_time.Text = DateTime.Parse(zd_ddsj).TimeOfDay.ToString();
                    dT_lksj_date.Text = DateTime.Now.ToShortDateString();
                    dT_lksj_time.Text = DateTime.Now.TimeOfDay.ToString();
                    dT_jzsj_date.Text = DateTime.Now.ToShortDateString();
                    dT_jzsj_Time.Text = DateTime.Now.TimeOfDay.ToString();
 
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "读取原始主单出错!");
                    return;
                }

 
            }

 
        }

        public void saveToGdTemp()
        {

            string zd_krxm = tB_krxm.Text.Replace("'", "-").Trim();
            string zd_fjbh = tb_fjbh.Text.Replace("'", "-").Trim();
            string zd_ddsj = DateTime.Parse(dT_ddsj_date.Text +" "+ dT_ddsj_time.Text).ToString();
            string zd_lksj = DateTime.Parse(dT_lksj_date.Text + " " + dT_lksj_time.Text).ToString();
            string zd_jzsj = DateTime.Parse(dT_jzsj_date.Text + " " + dT_jzsj_Time.Text).ToString();
            sb = new StringBuilder();
            if (gd_Type == "jz")
            {
                sb.Append(" update Sjzmx_gd_temp set zd_krxm_lz='" + zd_krxm + "',zd_fjbh='" + zd_fjbh + "', zd_fjbh_lz='" + zd_fjbh + "',zd_ddsj='" + zd_ddsj + "',zd_tfsj='" + zd_lksj + "'  where jzbh='" + zd_jzbh + "' and czy_temp='" + common_file.common_app.czy_GUID + "'");
            }
            if (gd_Type == "zz")
            {
                sb.Append(" update Sjzmx_gd_temp set zd_krxm_lz='" + zd_krxm + "',zd_fjbh='" + zd_fjbh + "', zd_fjbh_lz='" + zd_fjbh + "',zd_ddsj='" + zd_ddsj + "',zd_tfsj='" + zd_lksj + "'  where   czy_temp='" + common_file.common_app.czy_GUID + "'");
            }
            B_common = new Hotel_app.BLL.Common();
            if (B_common.ExecuteSql(sb.ToString()) > 0)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "主单修改成功");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
 
        }



        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Szw_gd_zd_Load(object sender, EventArgs e)
        {

        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你确定要修改此笔账的主单信息嘛?") == true)
            {
                saveToGdTemp();
            }
            else
            {
                this.Close();
            }

        }
    }
}