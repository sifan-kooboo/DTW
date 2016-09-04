using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class s_bz : Form
    {
        public s_bz(string zd_id)
        {
            InitializeComponent();
            jzzd_id = int.Parse(zd_id);
        }
        private int jzzd_id = 0;
        Model.Sjzzd M_Sjzzd;
        BLL.Sjzzd B_sjzzd = new Hotel_app.BLL.Sjzzd();

        private void s_bz_Load(object sender, EventArgs e)
        {
            if (jzzd_id > 0)
            {
                M_Sjzzd = B_sjzzd.GetModel(jzzd_id);
                if (M_Sjzzd != null)
                {
                    tB_fpcs.Text = M_Sjzzd.fp_print.ToString();
                    tB_fpbz.Text = M_Sjzzd.bz;
                }
            }

        }

        private void b_save_Click(object sender, EventArgs e)
        {
            M_Sjzzd = B_sjzzd.GetModel(jzzd_id);
            if (M_Sjzzd != null)
            {
                M_Sjzzd.fp_print = int.Parse(tB_fpcs.Text.Trim());
                M_Sjzzd.bz = tB_fpbz.Text.Trim();
                if (B_sjzzd.Update(M_Sjzzd))
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功");
                    //p_fp.Visible = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
        }

        private void tB_fpcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void b_exit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}