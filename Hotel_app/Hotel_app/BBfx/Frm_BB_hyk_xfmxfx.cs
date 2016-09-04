using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_hyk_xfmxfx : Form
    {
        public Frm_BB_hyk_xfmxfx()
        {
            InitializeComponent();
        }

        string cssj = DateTime.Now.ToString();
        string jssj = DateTime.Now.ToString();
        string second_selection = "";
        string TimeInfo = "";
        DataSet ds = null;
        BLL.Common B_common = new Hotel_app.BLL.Common();
        private void M_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            dtp_cssj.Text = common_file.common_app.cssj;
            dtp_jssj.Text = common_file.common_app.cssj;
        }

        private void M_refresh_Click(object sender, EventArgs e)
        {
            second_selection = "";
            TimeInfo = "全部";
            Getfxsj("");
        }
        

        private void Getfxsj(string sql_con)
        {
            common_file.common_app.get_czsj();
            string sql=" id>=0  and  yydh='"+common_file.common_app.yydh+"' ";
            if(sql_con.Trim()!="")
            {
                sql+=sql_con;
            }
            //ds = common_bb.GetDatahy(dt1.ToShortDateString(), dt2.ToString(), common_bb.xsy_krly_xydw_xsy, tb_value.Text, "false", "", "");
            ds = B_common.GetList(" select * From  VS_syxfmx_hyxsy ", sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                p_gl.Visible = false;
                common_bb.displayprogress(progressBar1);
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);
                BB_hykh_mxfx myreport = new BB_hykh_mxfx();
                myreport.SetDataSource(ds.Tables[0]);


                myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                myreport.SetParameterValue("TimeInfo", TimeInfo);
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);
                
                crystalReportViewer1.ReportSource = myreport;
                Cursor.Current = Cursors.Default;

            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有分析数据,请更改查询条件！");
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            if (dtp_cssj.Value > dtp_jssj.Value)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始时间不能大于结束时间,请正确选择过滤时间");
                return;
            }
            if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                second_selection += "  and  xfsj>='" + dtp_cssj.Value.ToShortDateString() + "'  and xfsj<='" + dtp_jssj.Value.ToShortDateString() + " 23:59:59  '";
                cssj = dtp_cssj.Value.ToShortDateString();
                TimeInfo = "从" + DateTime.Parse(cssj).Date.ToShortDateString() + "到" + DateTime.Parse(jssj).Date.ToShortDateString();
            }
            //if (DateTime.Parse(dtp_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            //{
            //    second_selection += "  and  xfsj>='" + dtp_cssj.Value.ToShortDateString() + "'  and xfsj<='" + dtp_jssj.Value.ToShortDateString() + " 23:59:59  '";
            //    jssj = dtp_jssj.Value.ToShortDateString();
            //    TimeInfo += "到" + jssj;
            //}
            if (tb_xsy.Text.Trim() != "")
            { second_selection += " and  xsy  like '%" + tb_xsy.Text.Trim().Replace("'", "-") + "%' "; }
            if (tb_hykh.Text.Trim() != "")
            { second_selection += "  and  hykh_bz  like '%" + tb_hykh.Text.Trim().Replace("'", "-") + "%' "; }
                
            Getfxsj(second_selection);

        }

        private void Frm_BB_xydw_Load(object sender, EventArgs e)
        {
            TimeInfo = "全部";
            second_selection = "";  
            Getfxsj("");
            
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void b_gl_exit_Click_1(object sender, EventArgs e)
        {
            p_gl.Visible = false;
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
            common_bb.ExportMX(ds, "hykxffx");
        }

        private void dtp_cssj_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }
    }
}