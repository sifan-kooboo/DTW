using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_zbzd_gl : Form
    {
        public string get_sel_cond = "";//最终获取的查询条件
        public Xxfmx_zbzd_gl()
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
            string istj = common_file.common_app.is_wsh;
            if (Cb_is_tj_kc.Checked)
            {
                istj = common_file.common_app.is_sh;

            }
           string dt_start = dT_rq_cx.Text.Trim().Replace('/', '-');
           
           string sel_cond = " and is_sh='" + istj + "'";

           if (dT_rq_cx.Text.Trim().Replace('/', '-') != "")
           {
               sel_cond = sel_cond + " and zbsj='" + dT_rq_cx.Text.Trim().Replace('/', '-') + "'";

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