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
    public partial class Frm_BB_zhrbb : Form
    {
        public Frm_BB_zhrbb()
        {
            InitializeComponent();
        }
        DataSet ds = null;
        string dt_start = "1800-01-01";
        string dt_end = "1800-01-01";
        string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
        //object[] args = new object[7];

        BLL.Common B_common = new Hotel_app.BLL.Common();
        private void initalApp()
        {
            dT_rq_cx.Text = "1800-01-01";
            dT_rq_cx.Value = DateTime.Parse(dT_rq_cx.Text);
            //dT_rq_cx.Text = "1800-01-01";
            //dT_rq_cx.Value = DateTime.Parse(dT_rq_cx.Text);
        }

        private void b_search_Click(object sender, EventArgs e)
        {

            dt_start = dT_rq_cx.Text.Trim().Replace('/', '-');
            dt_end = dT_rq_cx.Text.Trim().Replace('/', '-') + "  23:59:59";

            DateTime dt1 = DateTime.Parse(dt_start);
            DateTime dt2 = DateTime.Parse(dt_end);
            if (dt2 < dt1)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间早于起始时间,请正确选择结束时间");
                return;
            }
            GetData(dt1.ToString(), dt2.ToString());
            p_gl.Visible = false;
        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void M_gl_Click(object sender, EventArgs e)
        {
            p_gl.BringToFront();
            if (p_gl.Visible == false)
            {
                p_gl.Visible = true;
            }
            else
            {
                p_gl.Visible = false;
            }
        }

        private void M_refresh_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            GetData(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString()+"  23:59:59");
        }


        private void GetData(string _dt_start, string _dt_end)
        {
            ds = B_common.GetList(" select * from Bszhrbb", "id>=0  and   yydh='" + common_file.common_app.yydh + "' and  bbrq>='" + _dt_start + "'  and bbrq<='" + _dt_end + "' order by id");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                p_gl.Visible = false;
                common_bb.displayprogress(progressBar1);
                BB_zhrbb myreport = new BB_zhrbb();
                myreport.SetDataSource(ds.Tables[0]);
                myreport.SetParameterValue("czy", common_file.common_app.czy);
                myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                
                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                 crystalReportViewer1.ReportSource=null;
                 common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有查到分析数据,请更改查询条件!");
            }
        }

        public void renew_bb(DateTime rq, int judge_rx,bool sh_ts,string bz)
        {
            //args[0] = common_file.common_app.yydh;
            //args[1] = common_file.common_app.qymc;
            //args[2] = rq;
            //args[3] = common_file.common_app.czy;
            //args[4] = DateTime.Now;
            //args[5] = judge_rx;//生成所有的
            //args[6] = common_file.common_app.xxzs;
            //object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "New_zhrbb_app", args);
            Server.BBfx.B_zhrbb B_zhrbb_new = new Hotel_app.Server.BBfx.B_zhrbb();
            string result = B_zhrbb_new.New_zhrbb_app(common_file.common_app.yydh, common_file.common_app.qymc, rq, common_file.common_app.czy, DateTime.Now, judge_rx, common_file.common_app.xxzs);
            if (result!=null&&result== common_file.common_app.get_suc)
            {
                if(sh_ts==true)
                {
                   common_file.common_app.Message_box_show(common_file.common_app.message_title,bz);
                }

                GetData(rq.ToShortDateString(), rq.ToShortDateString() + "  23:59:59");
                p_gl.Visible = false;
            }
        }

        private void Frm_BB_zhrbb_Load(object sender, EventArgs e)
        {
            //重新生成当天的
            renew_bb(DateTime.Parse(DateTime.Now.ToShortDateString()), 4,false,"");
        }

        private void b_exit_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zhrbb_czsr", common_file.common_app.user_type) == false)
            { return; }

            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title,"是否确定要重新生成收入呢！") == true)
            {
                common_file.common_app.get_czsj();
                renew_bb( DateTime.Parse(dT_rq_cx.Value.ToShortDateString()), 1, true, "收入及报表生成成功！");
            }
            Cursor.Current = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zhrbb_czzw", common_file.common_app.user_type) == false)
            { return; }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要重新生成账务呢！") == true)
            {
                common_file.common_app.get_czsj();
                renew_bb(DateTime.Parse(dT_rq_cx.Value.ToShortDateString()), 2, true, "账务及报表生成成功！");
            }
            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zhrbb_czwj", common_file.common_app.user_type) == false)
            { return; }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要重新生成未结账务呢！") == true)
            {
                common_file.common_app.get_czsj();
                renew_bb(DateTime.Parse(dT_rq_cx.Value.ToShortDateString()), 3, true, "未结账务及报表生成成功！"); Cursor.Current = Cursors.Default;

            } 
            Cursor.Current = Cursors.Default;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zhrbb_czzt", common_file.common_app.user_type) == false)
            { return; }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要重新日报表呢！") == true)
            {
                common_file.common_app.get_czsj();
                renew_bb(DateTime.Parse(dT_rq_cx.Value.ToShortDateString()), 4, true, "日报表生成成功！");
            }
            Cursor.Current = Cursors.Default;
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
               if (common_file.common_roles.get_user_qx("B_bbfx_outPort", common_file.common_app.user_type) ==false)
               { return; }

                System.Collections.Hashtable nameList = new System.Collections.Hashtable();
                //生成列的中文对应表
                nameList = new Hashtable();
                nameList.Add("qymc", "企业名称");
                nameList.Add("yydh", "营业代号");
                nameList.Add("bbrq", "报表日期");
                nameList.Add("rbxm", "类别项目");
                nameList.Add("brrj", "项目值");
                nameList.Add("byrj", "累计值");
                nameList.Add("rbxm0", "类别项目");
                nameList.Add("brrj0", "项目值");
                nameList.Add("byrj0", "累计值");

                common_bb.ExportToExcel(ds, nameList);
                Cursor.Current = Cursors.Default;


        }
    }
}