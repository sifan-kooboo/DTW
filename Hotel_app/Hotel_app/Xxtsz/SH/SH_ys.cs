using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.SH
{
    public partial class SH_ys : Form
    {
        public int dg_count_skdj = 0;
        public int dg_count_ys_fy_gz = 0;
        public int dg_count_czjl = 0;
        BLL.Common B_Common=new Hotel_app.BLL.Common();
        public DataSet DS_skdj;
        public DataSet DS_ys_fy_gz;
        public DataSet DS_czjl;

        string select_s = "";
        public SH_ys()
        {
            InitializeComponent();
            refresh_ys_fy_gz_app();
        }


        public void refresh_skdj_app()
        {
            string condition = "";

            select_s = "select * from View_Qskzd";
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and main_sec='" + common_file.common_app.main_sec_main + "' and yddj='" + common_file.common_yddj.yddj_dj + "' and fjrb<>'' and fjbh<>'' and lsbh not in(select lsbh from S_ys_fy_gz where (czsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() +" 23:59:59"+ "')) order by id Desc";
            dG_skdj.AutoGenerateColumns = false;
            DS_skdj = B_Common.GetList(select_s, condition);
            bS_skdj.DataSource = DS_skdj.Tables[0];
            dg_count_skdj = DS_skdj.Tables[0].Rows.Count;
        }

        public void refresh_ys_fy_gz_app()
        {
            string condition = "";
            select_s = "select * from S_ys_fy_gz";
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and (czsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "') order by id Desc";
            dG_ys_fy_gz.AutoGenerateColumns = false;
            DS_ys_fy_gz = B_Common.GetList(select_s, condition);
            bS_ys_fy_gz.DataSource = DS_ys_fy_gz.Tables[0];
            dg_count_ys_fy_gz = DS_ys_fy_gz.Tables[0].Rows.Count;
        }

        public void refresh_czjl_app()
        {
            string condition = "";
            select_s = "select * from YHczjl";
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and (czsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "') and cznr='" + "Õý³£ÉóºË" + "' order by id Desc";
            dG_czjl.AutoGenerateColumns = false;
            DS_czjl = B_Common.GetList(select_s, condition);
            bS_czjl.DataSource = DS_czjl.Tables[0];
            dg_count_czjl = DS_czjl.Tables[0].Rows.Count;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            { refresh_ys_fy_gz_app(); }
            else
                if (tabControl1.SelectedIndex == 1)
                { refresh_skdj_app(); }
                else
                    if (tabControl1.SelectedIndex == 2)
                    { refresh_czjl_app(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            common common_new = new common();
            common_new.add_ys();
            if (tabControl1.SelectedIndex == 0)
            { refresh_ys_fy_gz_app(); }
            else
                if (tabControl1.SelectedIndex == 1)
                { refresh_skdj_app(); }
                else
                    if (tabControl1.SelectedIndex == 2)
                    { refresh_czjl_app(); }
        }

        private void b_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }






    }
}