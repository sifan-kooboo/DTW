using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_gd_xg : Form
    {
        public Szw_gd_xg(string gd_id_app)
        {
            InitializeComponent();
            this.id_app = gd_id_app;
            loadInfo();
        }
        private string id_app = "";
        private DataSet ds_0 = null;
        private BLL.Common B_common = new Hotel_app.BLL.Common();
        private StringBuilder sb;
        private void loadInfo()
        {
            if (id_app.Trim() != "")
            {
                B_common = new Hotel_app.BLL.Common();
                ds_0 = B_common.GetList(" select  *  from sjzmx_gd_temp ", "id>=0 and yydh='" + common_file.common_app.yydh + "' and  id_app='" + id_app + "'");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    tB_xfxm.Text = ds_0.Tables[0].Rows[0]["xfxm"].ToString();
                    tB_xfxm_new. Text = ds_0.Tables[0].Rows[0]["xfxm"].ToString();

                    tB_xfje. Text = ds_0.Tables[0].Rows[0]["sjxfje"].ToString();
                    tB_xfje_new.Text = ds_0.Tables[0].Rows[0]["sjxfje"].ToString();

                    tB_xfzy.Text = ds_0.Tables[0].Rows[0]["xfzy"].ToString();
                    tB_xfzy_new.Text = ds_0.Tables[0].Rows[0]["xfzy"].ToString();

                    tB_xfbz.Text = ds_0.Tables[0].Rows[0]["xfbz"].ToString();
                    tB_xfbz_new.Text = ds_0.Tables[0].Rows[0]["xfbz"].ToString();

                    tB_xfsj.Text = ds_0.Tables[0].Rows[0]["xfsj"].ToString();
                    dT_xfsj_Date.Text = DateTime.Parse(tB_xfsj.Text).ToShortDateString();
                    dT_xfsj_Time.Text = DateTime.Parse(tB_xfsj.Text).ToShortTimeString();
 
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "加载旧消费项目出错.");
                }
                
            }
        }
        private void saveInfo()
        {
            if (tB_xfxm_new.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确填写消费项目!."); return;
            }
            else
            {
                string xfsj_new=dT_xfsj_Date.Text+" "+dT_xfsj_Time.Text.Trim();
                sb = new StringBuilder();
                sb.Append(" update Sjzmx_gd_temp  set xfxm='" + tB_xfxm_new.Text.Trim().Replace("'", "-") + "',xfbz='" + tB_xfbz_new.Text.Trim().Replace("'", "-") + "',xfzy='" + tB_xfzy_new.Text.Trim().Replace("'", "-") + "',xfsj='" + xfsj_new + "',sjxfje='" + tB_xfje_new.Text.Trim() + "' where id>=0 and yydh='" + common_file.common_app.yydh + "' and  id_app='" + id_app + "'");
                if (B_common.ExecuteSql(sb.ToString()) > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "改单成功!.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
 
        }


        private void b_save_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你确定要修改此消费项目嘛?") == true)
            {
                saveInfo();
            }
            else
            {
                this.Close();
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tB_xfje_new_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }



    }
}