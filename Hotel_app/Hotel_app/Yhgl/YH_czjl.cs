using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_czjl : Form
    {
        public YH_czjl()
        {
            InitializeComponent();
        }
        DataSet ds_czjl = null;
        string sel_main_sec = "";
        BLL.Common B_common = new Hotel_app.BLL.Common();

        public void refresh_app(string sel_cond_0)
        {
                //dg_skdj.AutoGenerateColumns = false;
                //DS_Qskdj = B_Common.GetList(select_s, condition);
                //bindingSource1.DataSource = DS_Qskdj.Tables[0];
                //dg_count = DS_Qskdj.Tables[0].Rows.Count;
                //(dg_skdj);
                dg_yhczjl.AutoGenerateColumns = false;
                string temp = "id>=0 and yydh='" + common_file.common_app.yydh + "' " + sel_main_sec + sel_cond_0;
                ds_czjl = B_common.GetList("select * from YHczjl", "id>=0 and yydh='" + common_file.common_app.yydh + "' " + sel_main_sec + sel_cond_0+"  order by czsj desc  ");
                bindingSource_yhczjl.DataSource = ds_czjl.Tables[0];
                dg_yhczjl.DataSource = bindingSource_yhczjl;
        }

        private void YH_czjl_Load(object sender, EventArgs e)
        {
            refresh_app("  and  czsj>='" + (DateTime.Now.AddDays(-3)).ToShortDateString()+"' ");
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bindingSource_yhczjl.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bindingSource_yhczjl.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bindingSource_yhczjl.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bindingSource_yhczjl.MoveLast();
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            sel_main_sec = "";
            
            refresh_app("  and  czsj>='" + (DateTime.Now.AddDays(-3)).ToShortDateString() + "' and czsj<='" + DateTime.Now.ToShortDateString() + " 23:59:59  ' ");

        }

        private void b_search_Click(object sender, EventArgs e)
        {
            YH_gl yh_gl_new = new YH_gl("yhczjl");
            if (yh_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_main_sec=yh_gl_new.get_sel_cond;
                refresh_app(sel_main_sec);
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}