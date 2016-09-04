using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_j_g_yefx : Form
    {
        public Frm_BB_j_g_yefx()
        {
            InitializeComponent();
            
            //initalApp(loadType);
        }
        
        private string loadType = "";//common_bb中的值
        private string sel_cond = "";
        private string fx_type = "";//设置分析类别
        private string fxdr = "";//获取分析大类
        private string TimeSpanInfo = "全部";
        //private string zgz_zjz = "";//记转挂
        private DataSet ds = null;

        public void initalApp(string loadType)
        {
            this.loadType = loadType;
            tb_value.Text= "";
            sel_cond = "";
            if (loadType == common_bb.gz_type)
            { this.Text = "挂账收款余额统计";
            lbl_dw.Text = "挂账单位";
            fx_type = "挂账余额统计分析";
            fxdr = "挂账单位";
            }
            if (loadType == common_bb.jz_type)
            {
                this.Text = "记账收款余额统计"; fxdr = "记账客人";
                fx_type = "余额统计分析";
                lbl_dw.Text = "记账客人";
            }
            TimeSpanInfo = "全部";
            displayBB(DateTime.Parse(common_file.common_app.cssj).ToShortDateString(), DateTime.Now.ToShortDateString());
        }

        private  void   displayBB(string Time_begin,string Time_end)
        {
            common_file.common_app.get_czsj();
            DateTime dt1 = DateTime.Parse(Time_begin.Trim().Replace('/', '-'));
            DateTime dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-') + "  23:59:59");

            //if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dtp_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            //{
            //    dt1 = DateTime.Parse(Time_begin.Trim().Replace('/', '-'));
            //}
            //if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dtp_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            //{
            //    dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-'));
            //}
            if (tb_value.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond += "  and  jzzt  like '%" + tb_value.Text.Trim().Replace("'", "-") + "%'";
            }

            ds = common_bb.GetFXData_j_g_ye(common_file.common_app.yydh, common_file.common_app.qymc, loadType, common_file.common_app.czy, sel_cond, DateTime.Now.ToString(), common_file.common_app.xxzs);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);

                BB_g_j_yeTj myreport = new BB_g_j_yeTj();
                myreport.SetDataSource(ds.Tables[0]);
                myreport.SetParameterValue("fx_type", fx_type);
                myreport.SetParameterValue("fxdr", fxdr);
                myreport.SetParameterValue("qymc", _qymc);
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);
                myreport.SetParameterValue("TimeSpanInfo", TimeSpanInfo);
                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有分析数据,请更改查询条件！");
                return;
            }
            Cursor.Current = Cursors.Default;
        }

        private void Frm_BB_j_g_fx_Load(object sender, EventArgs e)
        {
            //加载当前时间30天内的数据
            sel_cond = "";
            tb_value.Text = "";
            displayBB(DateTime.Parse(common_file.common_app.cssj).ToShortDateString(), DateTime.Now.ToShortDateString());
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
            common_file.common_app.get_czsj();
            if (tb_value.Text.Trim() != "")
            {
                sel_cond = "  and jzzt like '%" + tb_value.Text.Trim().Replace("'", "-") + "%'     ";
            }
            else
            {
                sel_cond = "";
            }
            common_file.common_app.get_czsj();
            displayBB(DateTime.Parse(common_file.common_app.cssj).ToShortDateString(), DateTime.Now.ToShortDateString());
            Cursor.Current = Cursors.Default;
        }

        private void b_gl_exit_Click_1(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            tb_value.Text = "";
        }

        private void b_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
           common_bb.ExportMX(ds, "jzgzyefx");
        }
    }
}