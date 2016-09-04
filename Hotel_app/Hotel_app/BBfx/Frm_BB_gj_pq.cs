using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_gj_pq : Form
    {
        public Frm_BB_gj_pq()
        {
            InitializeComponent();
        }
        private void M_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            dtp_cssj.Text = common_file.common_app.cssj;
            dtp_jssj.Text = common_file.common_app.cssj;
             
        }
        string ls_cond = "";

        private void M_refresh_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
            ls_cond = "";
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            Getfxsj(dtp_cssj.Text.Trim(), dtp_jssj.Text.Trim());
        }
        DataSet ds = null;

        private void Getfxsj(string Time_begin, string Time_end)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dt1 = DateTime.Parse(Time_begin.Trim().Replace('/', '-'));
            DateTime dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-') + "  23:59:59");
            if (dt2 < dt1)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间早于起始时间,请正确选择结束时间");
                return;
            }
            ds = common_bb.GetData(dt1.ToShortDateString(), dt2.ToString(), common_bb.xsy_krly_xydw_pq, tb_value.Text, "false", "", ls_cond);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                p_gl.Visible = false;
                common_bb.displayprogress(progressBar1);
                BB_syxffx_xsy_xydw myreport = new BB_syxffx_xsy_xydw();
                myreport.SetDataSource(ds.Tables[0]);
                myreport.SetParameterValue("fx_type", "国家");
                myreport.SetParameterValue("fxdr", "国家片区分析");
                myreport.SetParameterValue("cssj", DateTime.Parse(Time_begin.Trim().Replace('/', '-')).Date.ToShortDateString());
                myreport.SetParameterValue("jssj", DateTime.Parse(Time_end.Trim().Replace('/', '-')).Date.ToShortDateString());
                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有分析数据,请更改查询条件！");
                //return;
            }
            Cursor = Cursors.Default;
        }

        private void Frm_BB_gj_pq_Load(object sender, EventArgs e)
        {
            Getfxsj(DateTime.Now.ToShortDateString().Trim(), DateTime.Now.ToShortDateString().Trim());
        }

        private void b_print_Click(object sender, EventArgs e)
        {
            try
            {
                this.crystalReportViewer1.PrintReport();
            }
            catch
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请正确设置打印机");
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowFirstPage();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowPreviousPage();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowNextPage();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowLastPage();
        }

        private void b_outport_Click(object sender, EventArgs e)
        {
            common_bb.ExportMX(ds, "MultiType");
        }

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }
    }
}