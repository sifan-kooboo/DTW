using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_lkzd_gl : Form
    {
        public string get_sel_cond = "";//最终获取的查询条件
        public Xxfmx_lkzd_gl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }

        }
        private void gl()
        {
            int istj = 0;
            if (Cb_is_tj_kc.Checked)
            {
                istj = 1;

            }
           string dt_start = dT_rq_cx.Text.Trim().Replace('/', '-');
           
           string sel_cond = " and sh_sh='" + istj + "'";

           if (dT_rq_cx.Text.Trim().Replace('/', '-') != "")
           {
               sel_cond = sel_cond + " and lksj='" + dT_rq_cx.Text.Trim().Replace('/', '-') + "'";

           }

            ////common_file.common_app.Message_box_show(common_file.common_app.message_title, "" + sel_cond + "");
           if (sel_cond != "")
           {
               get_sel_cond = sel_cond;
           }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

    }
}