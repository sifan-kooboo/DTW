using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xckcx_gl : Form
    {
        public Xckcx_gl()
        {
            InitializeComponent();
        }
        public string second_selection = "";
        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (!dtp_cssj.Value.ToShortDateString().Trim().Equals("1800-1-1") || !dtp_jssj.Value.ToShortDateString().Trim().Equals("1800-1-1"))
            {
                second_selection += "  and  xfsj>='" + dtp_cssj.Value.ToShortDateString() + "'  and xfsj<='" + dtp_jssj.Value.ToShortDateString() + " 23:59:59  '";
            }
            if (tb_krxm.Text.Trim() != "")
            {
                second_selection += " and  krxm  like '%" + tb_krxm.Text.Trim().Replace("'", "-") + "%' "; 
            }
             if (tb_fjbh.Text.Trim() != "")
             { second_selection += " and  fjbh  like '%" + tb_fjbh.Text.Trim().Replace("'", "-") + "%' "; }
             if (tb_sktt.Text.Trim() != "")
             { second_selection += "  and sktt like '%" + tb_sktt.Text.Trim().Replace("'", "-") + "%' "; }
             if (tb_xfbz.Text.Trim() != "")
             {
                 second_selection += "  and xfbz like '%" + tb_xfbz.Text.Trim().Replace("'", "-") + "%' ";
             }
             if (tB_xfrb.Text.Trim() != "")
             {
                 second_selection += "  and xfrb like '%" + tB_xfrb.Text.Trim().Replace("'", "-") + "%' ";
             }
             if (tb_xfxm.Text.Trim() != "")
             {
                 second_selection += "  and xfxm like '%" + tb_xfxm.Text.Trim().Replace("'", "-") + "%' ";
             }
             if (tb_xfzy.Text.Trim() != "")
             { second_selection += "  and xfzy like '%" + tb_xfzy.Text.Trim().Replace("'", "-") + "%' "; }
             if (tb_xsy.Text.Trim() != "")
             { second_selection += "  and czy  like '%" + tb_xsy.Text.Trim().Replace("'", "-") + "%' "; }
             if (second_selection.Trim() != "")
             {
                 this.DialogResult = DialogResult.OK;
             }
             Cursor.Current = Cursors.Default;
        }

        private void Xckcx_gl_Load(object sender, EventArgs e)
        {
            dtp_cssj.Text = "1800-01-01";
            dtp_jssj.Text = "1800-01-01";
        }

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            dtp_cssj.Value = DateTime.Now;
        }

        private void dtp_jssj_Enter(object sender, EventArgs e)
        {
            dtp_jssj.Value = DateTime.Now;
        }
    }
}