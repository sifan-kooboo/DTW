using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_cy : Form
    {
        public Frm_BB_cy()
        {
            InitializeComponent();
        }

        DataSet ds = null;
        string second_selection = "";
        string sel_str = "";
        string dt_date = "";//显示报表的时间
        string url = common_file.common_app.service_url;
        BLL.Common B_common = new Hotel_app.BLL.Common();
        object[] args = new object[6];

        private void Frm_BB_cy_Load(object sender, EventArgs e)
        {
            //显示前一天的未结数据分析
            common_file.common_app.get_czsj();
            cb_bl.SelectedIndex = 0;
            renew_cy();
            Cursor.Current = Cursors.Default;
        }

        public void renew_cy()//string yydh, string qymc, string czy, string cybl, DateTime czsj, string xxzs)
        {
            url = common_file.common_app.service_url;
            url += "Qyddj/Qyddj_app.asmx";
            args[0] = common_file.common_app.yydh;
            args[1] = common_file.common_app.qymc;
            args[2] = common_file.common_app.czy;
            args[3] = cb_bl.Text.Trim();
            args[4] = DateTime.Now;
            args[5] = common_file.common_app.xxzs;//生成所有的


            Server.Qyddj.Q_cy Q_cy_new = new Hotel_app.Server.Qyddj.Q_cy();
            string result = Q_cy_new.cy_app(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, cb_bl.Text.Trim(), DateTime.Now, common_file.common_app.xxzs);
            //object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "cy_app", args);
            if (result != null && result == common_file.common_app.get_suc)
            {
                DisplayBB();
                p_gl.Visible = false;
            }
        }
        public void DisplayBB()
        {
            ds = B_common.GetList(" select * from BB_ysk_cy", "id>=0  and   yydh='" + common_file.common_app.yydh + "'   and   czy='" + common_file.common_app.czy + "'      order by  krxm,lzbh  asc ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                p_gl.Visible = false;
                common_bb.displayprogress(progressBar1);
                common_bb.displayprogress(progressBar1);
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);

                BB_ysk_cy myreport = new BB_ysk_cy();
                myreport.SetDataSource(ds.Tables[0]);
                myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);
                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有查到分析数据,请更改查询条件!");
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

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.BringToFront();
            if (p_gl.Visible == false)
            {
                p_gl.Visible = true;
                cb_bl.SelectedItem = 1;
                cb_bl.Text = "1";
            }
            else
            {
                p_gl.Visible = false;
            }
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
            common_bb.ExportMX(ds, "cy");
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            renew_cy();
        }
    }
}