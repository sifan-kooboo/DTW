using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_app.common_file;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_j_g_fx : Form
    {
        public Frm_BB_j_g_fx()
        {
            InitializeComponent();
            
            //initalApp(loadType);
        }
        
        private string loadType = "";//common_bb中的值
        private string sel_cond = "";
        private string fx_type = "";//设置分析类别
        private string fxdr = "";//获取分析大类
        private string zgz_zjz = "";//记转挂
        private DataSet ds = null;

        DateTime dt1 = DateTime.Parse(common_file.common_app.cssj);
        DateTime dt2 = DateTime.Parse(common_file.common_app.cssj);
        public void initalApp(string _loadType)
        {
            int i = 0;
            if(!this.loadType.Equals(_loadType)&&this.loadType!="")
            {
                 i=1;
            }
            this.loadType = _loadType;
            tb_value.Text= "";
            sel_cond = "";
            if (loadType == common_bb.gz_type)
            { this.Text = "挂账收款统计";
            lbl_dw.Text = "挂账单位";
            fx_type = "挂账分析";
            fxdr = "挂账单位";
            zgz_zjz = "挂转记";
            }
            if (loadType == common_bb.jz_type)
            {
                this.Text = "记账收款统计"; fxdr = "记账客人"; zgz_zjz = "记转挂"; fx_type = "记账分析"; lbl_dw.Text = "记账客人";
            }
            if(i>0)
            {
            displayBB(DateTime.Now.AddDays(-29).ToShortDateString(), DateTime.Now.ToShortDateString());
            }
        }

        private  void   displayBB(string Time_begin,string Time_end)
        {
            common_file.common_app.get_czsj();
            //DateTime dt1 = DateTime.Parse(Time_begin.Trim().Replace('/', '-'));
            //DateTime dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-') + "  23:59:59");
            if (dt2 < dt1)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间早于起始时间,请正确选择时间");
                return;
            }
            ds = common_bb.GetFXData_j_g(common_file.common_app.yydh, common_file.common_app.qymc,dt1.ToString(),dt2.ToString(), sel_cond, loadType, common_file.common_app.czy, DateTime.Now.ToString(), common_file.common_app.xxzs);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                p_gl.Visible = false;
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);

                BB_g_j_skTj myreport = new BB_g_j_skTj();
                myreport.SetDataSource(ds.Tables[0]);
                common_bb.displayprogress(progressBar1);
                myreport.SetParameterValue("fx_type", fx_type);
                myreport.SetParameterValue("fxdr", fxdr);
                myreport.SetParameterValue("zgz_zjz", zgz_zjz);
                myreport.SetParameterValue("cssj",DateTime.Parse( Time_begin.Trim().Replace('/', '-')).Date.ToShortDateString());
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

        private void Frm_BB_j_g_fx_Load(object sender, EventArgs e)
        {
            //加载当前时间30天内的数据
            dt1 = DateTime.Now.AddDays(-29).Date;
            dt2 = DateTime.Now;
            tb_value.Text = "";
            sel_cond = "";
            displayBB(dt1.ToString(), dt2.ToString());
            //displayBB(DateTime.Now.AddDays(-7).ToShortDateString(), DateTime.Now.ToShortDateString());
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {

        }

        private void b_first_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowFirstPage();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {

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
            //common_file.common_app.get_czsj();
            //if (tb_value.Text.Trim() != "")
            //{
            //    sel_cond = "  and jzzt like '%" + tb_value.Text.Trim().Replace("'", "-") + "%'     ";
            //}
            //else
            //{
            //    sel_cond = "";
            //}
            //common_file.common_app.get_czsj();
            //displayBB(dtp_cssj.Text.Trim(), dtp_jssj.Text.Trim());
            //Cursor.Current = Cursors.Default;


            common_file.common_app.get_czsj();
            if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dtp_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                dt1 = dtp_cssj.Value.Date;
                dt2 = dtp_jssj.Value.Date.AddDays(1);
            }
            if (tb_value.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = " and  jzzt like '%" + tb_value.Text.Trim().Replace("'", "-") + "%'";
            }
            displayBB(dt1.ToString(), dt2.ToString());
        }

        private void b_gl_exit_Click_1(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            dtp_cssj.Value = DateTime.Parse(common_file.common_app.cssj);
            dtp_jssj.Value = DateTime.Parse(common_file.common_app.cssj);
            if (tb_value.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = tb_value.Text.Trim().Replace("'", "-");
            }
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
           common_bb.ExportMX(ds, "jzgzfx");
        }

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            common_app.GetCurrentTime(sender, e);
        }
    }
}