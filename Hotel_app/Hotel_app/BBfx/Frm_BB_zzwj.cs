using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_zzwj : Form
    {
        public Frm_BB_zzwj()
        {
            InitializeComponent();
        }



        DataSet ds = null;
        string second_selection = "";
        string sel_str = "";
        string dt_date = "";//显示报表的时间
        string url = common_file.common_app.service_url;
        BLL.Common B_common = new Hotel_app.BLL.Common();

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
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
            p_gl.BringToFront();
            p_gl.Visible = true;
            //second_selection = "";
            if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                dt_date = dtp_cssj.Text.ToString();
                second_selection += "  and  bbrq>='" + dtp_cssj.Text.Trim() + "'  and bbrq<='" + dtp_cssj.Text.Trim() + "  23:59:59 " + "' ";
            }
            Cursor.Current = Cursors.Default;
            displayBB(second_selection,"");
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            //common_file.common_app.get_czsj();
            //second_selection = "";
            //displayBB(DateTime.Now.AddDays(-6).ToShortDateString().Trim(), DateTime.Now.ToShortDateString().Trim());
            //Cursor.Current = Cursors.Default;
            //common_file.common_app.Message_box_show(common_file.common_app.message_title, "提示,此查询会生成大量的数据,初始加载最近三天的在住未结明细,请在查询时务必选择查询的初始时间和结束时间,以提高查询效率");

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
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_bbfx_outPort", common_file.common_app.user_type) == false)
            { return; }

            System.Collections.Hashtable nameList = new System.Collections.Hashtable();
            //生成列的中文对应表
            nameList = new Hashtable();
            nameList.Add("bbrq", "报表日期");
            nameList.Add("ddsj", "到店时间");
            nameList.Add("lksj", "离店时间");
            nameList.Add("krxm", "客人");
            nameList.Add("xydw ", "单位");
            nameList.Add("krly", "来源");
            nameList.Add("fjrb", "房类");
            nameList.Add("fjbh", "房号");
            nameList.Add("sktt", "散客团队");
            nameList.Add("zfh", "房费");
            nameList.Add("ds", "代收");
            nameList.Add("qt", "其它");
            nameList.Add("zyye", "总额");

            common_bb.ExportToExcel(ds, nameList);
            Cursor.Current = Cursors.Default;
        }


        private void displayBB(string cond, string other_cond)
        {
            common_bb.displayprogress(progressBar1);
            ds = B_common.GetList(" select *  from BB_sh_wj  ", "id>=0  and   yydh='" + common_file.common_app.yydh + "'  "+cond+other_cond+ "   order by bbrq  asc");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                p_gl.Visible = false;
                common_bb.displayprogress(progressBar1);
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);
                BBfx_zzwj myreport = new BBfx_zzwj();
                myreport.SetDataSource(ds.Tables[0]);

                myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                myreport.SetParameterValue("cssj", dt_date);
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);
                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前时间段内没有分析数据,您可以更改查询条件来获取其它的分析数据！");
            }
        }

        private void Frm_BB_zzwj_Load(object sender, EventArgs e)
        {
            //显示前一天的未结数据分析
            common_file.common_app.get_czsj();
            second_selection = "";
            dt_date = DateTime.Now.AddDays(-1).ToShortDateString();
            displayBB("   and  bbrq>='" + DateTime.Now.AddDays(-1).ToShortDateString().Trim() + "'   and  bbrq<='" + DateTime.Now.ToShortDateString().Trim() + "' ", "");
            Cursor.Current = Cursors.Default;
            common_file.common_app.Message_box_show(common_file.common_app.message_title, "提示,此查询会生成大量的数据,初始加载最近三天未结明细,请在查询时务必选择查询的初始时间和结束时间,以提高查询效率");
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.BringToFront();
            dtp_cssj.Text = common_file.common_app.cssj;
            if (p_gl.Visible == false)
            {
                p_gl.Visible = true;
            }
            else
            {
                p_gl.Visible = false;
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

    }
}