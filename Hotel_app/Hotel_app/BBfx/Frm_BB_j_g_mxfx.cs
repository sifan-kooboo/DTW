using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_j_g_mxfx : Form
    {
        public Frm_BB_j_g_mxfx()
        {
            InitializeComponent();
        }

        private string loadType = "";//common_bb中的值
        private string sel_cond = "";
        private string g_j_Type = "";//设置统计分析类别
        private string fx_Type = "";
        private DataSet ds = null;
        public void initalApp(string loadType)
        {
            this.loadType = loadType;
            if (loadType == common_bb.gz_type)
            {
                this.Text = "挂账明细统计分析";
                lbl_dw.Text = "挂账单位";
                fx_Type = "挂账明细分析";
                g_j_Type = "挂账单位";
            }
            if (loadType == common_bb.jz_type)
            {
                this.Text = "记账明细统计分析";
                lbl_dw.Text = "记账客人";
                fx_Type = "记账明细分析";
                g_j_Type = "记账客人";
            }
            displayBB(DateTime.Now.AddDays(-6).ToShortDateString(), DateTime.Now.ToShortDateString());
        } 

        private void Frm_BB_j_g_mxfx_Load(object sender, EventArgs e)
        {
            displayBB(DateTime.Now.AddDays(-29).ToShortDateString(), DateTime.Now.ToShortDateString());
        }

        private void displayBB(string Time_begin, string Time_end)
        {
            DateTime dt1 = DateTime.Parse(Time_begin.Trim().Replace('/', '-'));
            DateTime dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-') + "  23:59:59");
            if (dt2 < dt1)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间早于起始时间,请正确选择时间");
                return;
            }
            ds = common_bb.GetFxData_j_g_mx(common_file.common_app.yydh, common_file.common_app.qymc, dt1.ToString(), dt2.ToString(), sel_cond, loadType, common_file.common_app.czy,tb_value.Text.Trim(),DateTime.Now.ToString(), common_file.common_app.xxzs);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);

                BB_g_j_mxfx myreport = new BB_g_j_mxfx();
                myreport.SetDataSource(ds.Tables[0]);
                myreport.SetParameterValue("g_j_Type", g_j_Type);
                myreport.SetParameterValue("fx_Type", fx_Type);
                //myreport.SetParameterValue("zgz_zjz", zgz_zjz);
                myreport.SetParameterValue("cssj", DateTime.Parse( Time_begin.Trim().Replace('/', '-')).Date.ToShortDateString());
                myreport.SetParameterValue("jssj", DateTime.Parse(Time_end.Trim().Replace('/', '-')).Date.ToShortDateString());
                myreport.SetParameterValue("qymc", _qymc);
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);
                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有分析数据,请更改查询条件！");
                return;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            p_gl.Visible = false;

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

        private void b_search_Click(object sender, EventArgs e)
        {
            if (tb_value.Text.Trim() != "")
            {
                sel_cond = "  and jzzt like '%" + tb_value.Text.Trim().Replace("'", "-") + "%'     ";
            }
            else
            {
                sel_cond = "";
            }
            displayBB(dtp_cssj.Text.Trim(), dtp_jssj.Text.Trim());
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            if (loadType == common_bb.jz_type)
            { lbl_dw.Text = "记账客人";
            }
            if (loadType == common_bb.gz_type)
            { lbl_dw.Text = "挂账单位"; }
            dtp_cssj.Text = DateTime.Now.ToShortDateString();
            dtp_jssj.Text = DateTime.Now.ToShortDateString();
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

        private void b_outport_Click(object sender, EventArgs e)
        {
            common_bb.ExportMX(ds, "jzgztj");
        }
    }
}