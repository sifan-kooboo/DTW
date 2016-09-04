using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_czjl_ls : Form
    {
        public string sk_tt = "tt";//两个值一个是sk，另一个是tt
        int dg_count_skzd = 0;
        int dg_count_fxfj = 0;
        int dg_count_ttzd = 0;
        //int dg_count_fxfj_tt = 0;
        public string cond_skzd = "";
        public string cond_ttzd = "";
        public string cond_fxfj_sk = "";
        //public string cond_fxfj_tt="";
        string select_s = "";
        string condition = "";
        DataSet DS_skzd;
        DataSet DS_fxfj;
        DataSet DS_ttzd;
        DataSet DS_fxfj_tt;

        BLL.Common B_Common = new Hotel_app.BLL.Common();
        public Q_czjl_ls()
        {

            InitializeComponent();
            show_panel();
            
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void show_panel()
        {
            if (sk_tt == "tt")
            {
                p_fxfj.Height = 250;
                p_fxfj.Dock = DockStyle.Bottom;
                //p_fxfj.Visible = true;
                p_skzd.Dock = DockStyle.Fill;
                p_skzd.Visible = true;
                refresh_fxfj(" and czsj>'" + DateTime.Now.AddDays(-7).ToString() + "' ");
                refresh_skzd(" and czsj>'" + DateTime.Now.AddDays(-7).ToString() + "' ");
                //p_fxfj.Visible = false;
                p_ttzd.Visible = false;
                //sk_tt = "sk";
            }
            else
                if (sk_tt == "sk")
                {
                    p_fxfj.Height = 250;
                    p_fxfj.Dock = DockStyle.Bottom;
                    //p_fxfj.Visible = true;
                    p_ttzd.Dock = DockStyle.Fill;
                    p_ttzd.Visible = true;
                    refresh_fxfj(" and czsj>'" + DateTime.Now.AddDays(-7).ToString() + "' ");
                    refresh_ttzd(" and czsj>'" + DateTime.Now.AddDays(-7).ToString() + "' ");
                    //p_fxfj.Visible = false;
                    p_skzd.Visible = false;
                    //sk_tt = "tt";
                }
        }
        public void refresh_skzd(string sql_0)
        {
            select_s = "select * from Qskyd_mainrecord_temp";
            dg_skzd.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'" +sql_0+ cond_skzd + "  order by czsj desc";
            DS_skzd = B_Common.GetList(select_s, condition);
            bS_skzd.DataSource = DS_skzd.Tables[0];
            dg_count_skzd = DS_skzd.Tables[0].Rows.Count;
        }

        public void refresh_ttzd(string sql_0)
        {
            select_s = "select * from Qttyd_mainrecord_temp";
            dg_ttzd.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sql_0 + cond_ttzd + "  order by czsj desc";
            DS_ttzd = B_Common.GetList(select_s, condition);
            bS_ttzd.DataSource = DS_ttzd.Tables[0];
            dg_count_ttzd = DS_ttzd.Tables[0].Rows.Count;
        }

        public void refresh_fxfj(string sql_0)
        {
            select_s = "select * from Qskyd_fjrb_temp";
            dg_fxfj.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sql_0 + cond_fxfj_sk + "  order by czsj desc";
            DS_fxfj = B_Common.GetList(select_s, condition);
            bS_fxfj.DataSource = DS_fxfj.Tables[0];
            dg_count_fxfj = DS_fxfj.Tables[0].Rows.Count;
        }




        private void b_new_Click(object sender, EventArgs e)
        {
            if (sk_tt == "sk")
            { sk_tt = "tt"; }
            else
                if(sk_tt=="tt")
                { sk_tt = "sk"; }
            show_panel();

        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            cond_skzd = "";
            cond_ttzd = "";
            cond_fxfj_sk = "";
            show_panel();
        }

        private void dg_ttzd_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            if (sk_tt == "sk")
            {
                Qyddj.Q_sktt_gl Q_sktt_gl_new = new Q_sktt_gl("lscz_tt");
                Q_sktt_gl_new.Left = 130;
                Q_sktt_gl_new.Top = 70;
                if (Q_sktt_gl_new.ShowDialog() == DialogResult.OK)
                {
                    cond_ttzd = cond_ttzd+Q_sktt_gl_new.get_sel_cond;
                    cond_fxfj_sk = cond_fxfj_sk + Q_sktt_gl_new.get_sel_cond;
                    if (Q_sktt_gl_new.get_sel_cond != "")
                    {
                        refresh_ttzd("");
                        refresh_fxfj("");
                    }
                }
                Q_sktt_gl_new.Dispose();

            }
            else
                if (sk_tt == "tt")
                {
                    Qyddj.Q_sktt_gl Q_sktt_gl_new = new Q_sktt_gl("lscz_sk");
                    Q_sktt_gl_new.Left = 130;
                    Q_sktt_gl_new.Top = 70;
                    if (Q_sktt_gl_new.ShowDialog() == DialogResult.OK)
                    {
                        cond_skzd = cond_skzd + Q_sktt_gl_new.get_sel_cond;
                        cond_fxfj_sk = cond_fxfj_sk + Q_sktt_gl_new.get_sel_cond;
                        if (Q_sktt_gl_new.get_sel_cond != "")
                        {
                            refresh_skzd("");
                            refresh_fxfj("");
                        }
                    }
                    Q_sktt_gl_new.Dispose();
                }
        }
    }
}