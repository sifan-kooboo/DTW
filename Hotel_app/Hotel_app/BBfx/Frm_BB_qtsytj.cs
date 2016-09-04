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
    public partial class Frm_BB_qtsytj : Form
    {
        public Frm_BB_qtsytj()
        {
            InitializeComponent();
        }
        string Time_begin = "";
        string Time_end = "";

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

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //生成查询条件
            p_gl.BringToFront();
            p_gl.Visible = true;
            //second_selection = "";
            if (DateTime.Parse(dtp_cssj.Text.Trim()) > DateTime.Parse(dtp_jssj.Text.Trim()))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确选择消费时间");
                return;
            }
            if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dtp_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                second_selection += "  and  czsj>='" + dtp_cssj.Value.ToShortDateString() + "'  and czsj<='" + dtp_jssj.Value.ToShortDateString() + " 23:59:59  '";
                Time_begin = dtp_cssj.Value.ToShortDateString();
                Time_end = dtp_jssj.Value.ToShortDateString();
            }
             if (tb_czy.Text.Trim() != "")
                {
                    second_selection += "  and  czy  like'%" + tb_czy.Text.Trim().Replace("'", "-") + "%'  ";
                }
            Cursor.Current = Cursors.Default;
            displayBB("",second_selection);
        }



        /// <summary>
        /// 参数
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        ///         
        DataSet ds = null;
        string second_selection = "";
        string sel_str = "";
        string url = common_file.common_app.service_url;
        BLL.Common B_common = new Hotel_app.BLL.Common();

        private void displayBB(string sql_0, string sql_other)
        {
            common_file.common_app.get_czsj();
                sel_str = "";
                sel_str = " id>=0   and   yydh='" + common_file.common_app.yydh + "' " + sql_0 + sql_other + "  group by czy,fkfs  order by czy   ";
                ds = B_common.GetList("  select czy,fkfs,-sum(sjxfje)  from VIEW_S_jz_fkfs  ",  sel_str);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    p_gl.Visible = false;
                    common_bb.displayprogress(progressBar1);
                    string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                    common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);
                    BB_qtsytj myreport = new BB_qtsytj();
                    myreport.SetDataSource(ds.Tables[0]);

                    myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                    myreport.SetParameterValue("cssj", DateTime.Parse(Time_begin.Trim().Replace('/', '-')).Date.ToShortDateString());
                    myreport.SetParameterValue("jssj", DateTime.Parse(Time_end.Trim().Replace('/', '-')).Date.ToShortDateString());
                    myreport.SetParameterValue("address", _address_chinese);
                    myreport.SetParameterValue("Tel", _qydh);
                    myreport.SetParameterValue("Fax", _qycz);
                    crystalReportViewer1.ReportSource = myreport;
                }
                else
                {
                    crystalReportViewer1.ReportSource = null;
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前时间段内没有分析数据,您可以更改查询条件来获取其它的分析数据！");
                    //return;
                }
            //}
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


        public void initalApp()
        {
            this.Text = "冲(补)账分析";
            second_selection = "";
            displayBB(DateTime.Now.AddDays(-6).ToShortDateString(), DateTime.Now.ToShortDateString());
        }

        private void M_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            dtp_cssj.Text = common_file.common_app.cssj;
            dtp_jssj.Text = common_file.common_app.cssj;
        }


        private void Frm_BB_ds_Load(object sender, EventArgs e)
        {
            //显示一周之内的销售员消费统计分析
            second_selection = "";
            common_file.common_app.get_czsj();
            Time_begin = DateTime.Now.AddDays(-6).ToShortDateString();
            Time_end = DateTime.Now.ToShortDateString();
            displayBB("  and czsj>='" + DateTime.Now.AddDays(-6).ToShortDateString() + "'  and czsj<='" + DateTime.Now.ToString() + "' ", "    ");
            Cursor.Current = Cursors.Default;
            common_file.common_app.Message_box_show(common_file.common_app.message_title, "提示,此查询会生成大量的数据,初始加载最近一周的消费明细,请在查询时务必选择查询的初始时间和结束时间,以提高查询效率");
        }

        private void b_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_outport_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_bbfx_outPort", common_file.common_app.user_type) == false)
            { return; }

            System.Collections.Hashtable  nameList=new System.Collections.Hashtable();
            //生成列的中文对应表
            nameList = new Hashtable();
            nameList.Add("qymc", "企业名称");
            nameList.Add("yydh", "营业代号");
            nameList.Add("krxm","客人姓名");
            nameList.Add("fjrb","房间类别");
            nameList.Add("fjbh", "房间编号");
            nameList.Add("sktt","散客团体");
            nameList.Add("xfrq","消费日期");
            nameList.Add("xfsj","消费时间");
            nameList.Add("xfdr","消费大类");
            nameList.Add("xfrb","消费小类");
            nameList.Add("xfxm","消费项目");
            nameList.Add("jjje","进价金额");
            nameList.Add("sjxfje","实际价格");
            nameList.Add("xfsl","消费数量");
            nameList.Add("mxbh","明细编号");
            nameList.Add("zjhm","证件号码");
            nameList.Add("yxzj","有效证件");
            nameList.Add("krly","客人来源");
            nameList.Add("xydw","协议单位");
             nameList.Add("xyh","协议号");
            nameList.Add("krsj","会员卡号");
            nameList.Add("krgj","客人国家");
            nameList.Add("pq","片区");
            nameList.Add("gj_sf","省份");
            nameList.Add("gj_cs","城市");
            nameList.Add("gj_dq","地区");
             nameList.Add("xfzy","消费摘要");
            nameList.Add("xfbz","消费备注");
            nameList.Add("xsy","销售员");
            nameList.Add("czy","操作员");
            common_bb.ExportToExcel(ds, nameList);
            Cursor.Current = Cursors.Default;
        }

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void dtp_jssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);

        }
    }
}