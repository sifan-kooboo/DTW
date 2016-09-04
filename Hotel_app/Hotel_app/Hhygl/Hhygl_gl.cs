using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhygl_gl : Form
    {
        public string get_sel_cond = "";//最终获取的查询条件
        string sel_cond = "";
        public Hhygl_gl()
        {
            InitializeComponent();
            common_file.common_hy.Bindhyrx(cB_hyrx); //会员类型邦定
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void gl()
        {

             //sel_cond = "";
            if (tB_qymc.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and qymc like'%" + tB_qymc.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_hykh_bz.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and hykh_bz like'%" + tB_hykh_bz.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_krxm.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%'";

            }
            if (cB_hyrx.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and hyrx like'%" + cB_hyrx.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_krsj.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and krsj like'%" + tB_krsj.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_zjhm.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and zjhm like'%" + tB_zjhm.Text.Trim().Replace("'", "-") + "%'";

            }


            if (dT_krsr.Text.Trim().Replace("'", "-") != "" && DateTime.Parse(dT_krsr.Value.ToShortDateString())!= DateTime.Parse(common_file.common_app.cssj))
            {
                sel_cond = sel_cond + " and krsr like'%" + dT_krsr.Text.Trim().Replace("'", "-") + "%'";

            }
            if (dtp_djsj_ks.Text.Trim().Replace("'", "-") != "" && DateTime.Parse(dtp_djsj_ks.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                sel_cond = sel_cond + " and djsj>='" + dtp_djsj_ks.Text.Trim().Replace("'", "-") + "'    ";
            }
            if (dtp_djsj_js.Text.Trim().Replace("'", "-") != "" && DateTime.Parse(dtp_djsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                sel_cond = sel_cond + " and djsj<='" + dtp_djsj_js.Text.Trim().Replace("'", "-") + "'    ";
            }

            if (tB_krdz.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and krdz like'%" + tB_krdz.Text.Trim().Replace("'", "-") + "%'";

            }


            if (tB_xsy.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xsy like'%" + tB_xsy.Text.Trim().Replace("'", "-") + "%'";

            }


            if (sel_cond != "")
            {
                get_sel_cond = sel_cond;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Hhygl_gl_Load(object sender, EventArgs e)
        {
            dT_krsr.Text = common_file.common_app.cssj;
            dtp_djsj_ks.Text = common_file.common_app.cssj;
            dtp_djsj_js.Text = common_file.common_app.cssj;
        }

        private void dtp_djsj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }
        
    }
}