using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_zzkrdqtj : Form
    {
        public Frm_BB_zzkrdqtj()
        {
            InitializeComponent();
        }
        BLL.Common B_common = new Hotel_app.BLL.Common();
        string timeSpan = "";
        string kr_jn = "0";
        string kr_jw = "0";
        string kr_wz = "0";
        string second_selection = "";
        private void Frm_xsy_xsmxfx_Load(object sender, EventArgs e)
        {
            //dtp_cssj.Text = DateTime.Now.ToString();
            timeSpan = "一段时间";
            displayBB("  and ddsj>'" + DateTime.Now.Date.AddDays(-10) + "'  and ddsj<'" + DateTime.Now.Date + "' ","");
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //Getfxsj(dtp_cssj.Text.Trim(), dtp_jssj.Text.Trim());
            if (dtp_cssj.Value > dtp_jssj.Value)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始时间不能大于结束时间,请正确选择过滤时间");
                return;
            }
            if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dtp_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                second_selection += "  and  ddsj>='" + dtp_cssj.Value.ToShortDateString() + "'  and ddsj<='" + dtp_jssj.Value.ToShortDateString() + " 23:59:59  '";
                timeSpan += "从" + dtp_cssj.Value.ToShortDateString() + "到" + dtp_jssj.Value.AddDays(1).ToShortDateString();
                displayBB(second_selection,"");
            }
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

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataSet ds = null;

        private void displayBB(string sql_0, string sql_other)
        {
            string  sel_str = "";
            sel_str = " id>=0   and   yydh='" + common_file.common_app.yydh + "' " + sql_0 + sql_other + "   ";
            ds = B_common.GetList("  select krxm,krxb,yxzj,zjhm,krgj,ddsj,czsj as '离店时间' from  Qskyd_mainrecord_lskr   ", sel_str);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                //这一部分计算人数
                //境内的人数(国家为中国或者yxzj为身份证都为境内)
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if(ds.Tables[0].Rows[i]["yxzj"].ToString().Equals(common_file.common_app.yxzj_sfz))
                    {
                        ds.Tables[0].Rows[i]["krgj"]= common_file.common_app.krgj_zg;
                    }
                }

                int kr_jn_tj = 0;
                int kr_jw_tj = 0;
                int kr_wz_tj = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if(ds.Tables[0].Rows[i]["krgj"].ToString().Equals(common_file.common_app.krgj_zg))
                    {
                        kr_jn_tj++;
                    }
                    if (ds.Tables[0].Rows[i]["krgj"].ToString() != null && ds.Tables[0].Rows[i]["krgj"].ToString() != "" && ds.Tables[0].Rows[i]["krgj"].ToString() != common_file.common_app.krgj_zg)
                    {
                        kr_jw_tj++;
                    }
                    if (ds.Tables[0].Rows[i]["krgj"].ToString() != null && ds.Tables[0].Rows[i]["krgj"].ToString() == "" && ds.Tables[0].Rows[i]["yxzj"].ToString() != common_file.common_app.yxzj_sfz)
                   {
                        kr_wz_tj++;
                    }
                }
                kr_jn = kr_jn_tj.ToString();
                kr_jw = kr_jw_tj.ToString();
                kr_wz = kr_wz_tj.ToString();

                p_gl.Visible = false;
                common_bb.displayprogress(progressBar1);
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);
                BB_zzkrdqtj myreport = new BB_zzkrdqtj();
                myreport.SetDataSource(ds.Tables[0]);

                myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                //myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                //myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);

                myreport.SetParameterValue("kr_jn", kr_jn);
                myreport.SetParameterValue("kr_jw", kr_jw);
                myreport.SetParameterValue("kr_wz", kr_wz);
                myreport.SetParameterValue("TimeSpan", timeSpan);

                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前时间段内没有分析数据,您可以更改查询条件来获取其它的分析数据！");
            }
        }





        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            dtp_cssj.Text = common_file.common_app.cssj;
            dtp_jssj.Text = common_file.common_app.cssj;
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
            common_bb.ExportMX(ds, "zdkrdqtj");
        }

        private void dtp_jssj_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }
    }
}