using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_pljz : Form
    {
        public Szw_pljz()
        {
            InitializeComponent();
        }

        private DateTime time_startTime = DateTime.Parse("1800-01-01");
        private DateTime time_endTime = DateTime.Parse("1800-01-01");
        private string jzType = "";
        private string lsbh_last_return = "";

        private void b_find_Click(object sender, EventArgs e)
        {
            if (tB_gzdw.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写要结账务的主体（挂账单位名称或者客人姓名");
                return;
            }
            if (cb_pjfs.SelectedItem == null)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择批结方式");
                return;
            }

            if (cb_pjfs.SelectedItem.ToString() == "按时间")
            {
                jzType = "Time";
                time_startTime = DateTime.Parse(dt_start.Value.ToShortDateString());
                time_endTime = DateTime.Parse(dt_end.Value.ToShortDateString() + "  23:59:59");
                if (time_endTime < time_startTime)
                { common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确选择起始时间和结束时间"); return; }
            }
            if (cb_pjfs.SelectedItem.ToString() == "按金额")
            {
                jzType = "Value";
                dt_start.Enabled = false; dt_end.Enabled = false;
                if (((Maticsoft.Common.PageValidate.IsDecimal(tB_xfje.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_xfje.Text.Trim())) == false))
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                    tB_xfje.Focus();
                    tB_xfje.SelectAll();
                    return;
                }
            }
            common_zw_pljz common_zw_pljz_new = new common_zw_pljz();
            common_zw_pljz_new.GetPLJZData(time_startTime, time_endTime, jzType, decimal.Parse(tB_xfje.Text.Trim()), tB_gzdw.Text.Trim(), common_file.common_jzzt.czzt_gz, out  lsbh_last_return);
            Szwcz Frm_Szwcz_new = new Szwcz();
            Frm_Szwcz_new.InitalApp(tB_gzdw.Text.Trim(),"", "","", "Szw_pljz");
            Frm_Szwcz_new.lsbh_last = lsbh_last_return;
            Frm_Szwcz_new.StartPosition = FormStartPosition.CenterScreen;
            //Frm_Szwcz_new.ShowDialog();
            //common_file.common_form.ShowFrm_Szwcz_new(tB_gzdw.Text.Trim(), "", "", "", "Szw_pljz");
            //common_file.common_form.Szwcz_new.lsbh_last = lsbh_last_return;
            if (Frm_Szwcz_new.ShowDialog()== DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                //if (common_file.common_form.Sjjzwll_new != null && common_file.common_form.Sjjzwll_new.IsDisposed == false)
                //{
                //    common_file.common_form.Sjjzwll_new.Inital_app(common_file.common_jzzt.czzt_gz);
                //}
            }
        }

        private void b_krxm_Click(object sender, EventArgs e)
        {
            common_file.common_app.display_new_commonform_1("Yxydw", tB_gzdw,  common_file.common_xydw.xyrx_gzdw);
        }

        private void cb_pjfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_pjfs.SelectedItem.ToString() == "按时间")
            {
                dt_start.Enabled = true; dt_end.Enabled = true;
                tB_xfje.Enabled = false;
            }
            if (cb_pjfs.SelectedItem.ToString() == "按金额")
            {
                dt_start.Enabled = false; dt_end.Enabled = false;
                tB_xfje.Enabled = true;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}