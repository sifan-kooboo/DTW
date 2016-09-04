using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_lskr_xf_gl : Form
    {
        public Q_lskr_xf_gl()
        {
            InitializeComponent();
        }
        public string sel_con = "  1=1  ";
        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            if (tB_krxm.Text.Trim() != "")
            {
                sel_con = sel_con + " and krxm like'%" + tB_krxm.Text.Trim() + "%'";
            }
            if (tB_zjhm.Text.Trim() != "")
            {
                sel_con = sel_con + " and zjhm like '%" + tB_zjhm.Text.Trim() + "'%'";
            }
            if (tB_hykh.Text.Trim() != "")
            {
                sel_con = sel_con + " and hykh like'%" + tB_hykh.Text.Trim() + "%'";
            }
            if (tB_krsj.Text.Trim() != "")
            {
                sel_con = sel_con + " and krsj like'%" + tB_krsj.Text.Trim() + "%'";
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}