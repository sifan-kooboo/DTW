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
    public partial class Frm_BB_ds : Form
    {
        public Frm_BB_ds()
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
            second_selection = "";
            if (DateTime.Parse(dtp_cssj.Text.Trim()) > DateTime.Parse(dtp_jssj.Text.Trim()))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确选择消费时间");
                return;
            }
            second_selection += "  and  xfsj>='" + dtp_cssj.Text.Trim() + "'  and xfsj<='" + dtp_jssj.Text.Trim() + "  23:59:59 " + "' ";
            Cursor.Current = Cursors.Default;
            displayBB(dtp_cssj.Text.Trim().Replace("/", "-"), dtp_jssj.Text.Trim().Replace("/", "-"));
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
            //DateTime dt1 = DateTime.Parse(Time_begin.Trim().Replace('/', '-'));
            //DateTime dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-') + "  23:59:59");
            //if (dt2 < dt1)
            //{
             //   common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间早于起始时间,请正确选择结束时间");
             //   return;
           // }

            //url = common_file.common_app.service_url;
            //url += "BBfx/BBfx_app.asmx";
            ////yydh, qymc, cssj, jssj, czsj, czy_temp, xxzs
            //object[] args = new object[7];
            //args[0] = common_file.common_app.yydh;
            //args[1] = common_file.common_app.qymc;
            //args[2] = dt1.ToString();
            //args[3] = dt2.ToString();
            //args[4] = DateTime.Now.ToString();
            //args[5] = common_file.common_app.czy;
            //args[6] = common_file.common_app.xxzs;
            //object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "get_ds_fx", args);
            //if (result.ToString() == common_file.common_app.get_suc)
            //{
                //sel_str = " id>=0  and   yydh='" + common_file.common_app.yydh + "'  and czy_temp='"+common_file.common_app.czy+"' ";
                //ds = B_common.GetList(" select *  from BB_dsfx_temp  ", sel_str);
                sel_str = " id>=0  and  xfdr='" + Szwgl.common_zw.dr_ds + "' and   yydh='" + common_file.common_app.yydh + "' "+ sql_0 + sql_other + "  order by  xsy , xfsj  Desc  ";
                //ds = B_common.GetList(" select krxm,xfxm,fjrb,fjbh,xfsj,sjxfje,xydw,xsy,xfzy,xfbz  from VS_syxfmx_cz  ", sel_str);
                ds = B_common.GetList(" select *  from VS_syxfmx_cz  ", sel_str);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    p_gl.Visible = false;
                    common_bb.displayprogress(progressBar1);
                    string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                    common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);
                    BB_ds myreport = new BB_ds();
                    myreport.SetDataSource(ds.Tables[0]);

                    myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                    myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("TimeInfo", "从" + DateTime.Parse(Time_begin).Date.ToShortDateString() + "到" + DateTime.Parse(Time_end).Date.ToShortDateString());
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
            this.Text = "所有消费分析";
            second_selection = "";
            displayBB(DateTime.Now.AddDays(-6).ToShortDateString(), DateTime.Now.ToShortDateString());
        }

        private void M_gl_Click(object sender, EventArgs e)
        {
            //p_gl.Visible = true;
           // dtp_cssj.Text = DateTime.Now.ToShortDateString();
            //dtp_jssj.Text = DateTime.Now.ToShortDateString();
            Frm_BB_syxffx_gl Frm_bb_syxffx_gl_new = new Frm_BB_syxffx_gl();
            if (Frm_bb_syxffx_gl_new.ShowDialog() == DialogResult.OK)
            {
                second_selection = Frm_bb_syxffx_gl_new.second_selection;
                Time_begin = Frm_bb_syxffx_gl_new.Time_begin;
                Time_end = Frm_bb_syxffx_gl_new.Time_end;
                displayBB("", second_selection);
            }
        }


        private void Frm_BB_ds_Load(object sender, EventArgs e)
        {
            //显示一周之内的销售员消费统计分析
            second_selection = "";
            common_file.common_app.get_czsj();
            Time_begin = DateTime.Now.AddDays(-6).ToShortDateString();
            Time_end = DateTime.Now.ToShortDateString();
            displayBB("  and xfsj>='" + DateTime.Now.AddDays(-6).ToShortDateString() + "'  and xfsj<='" + DateTime.Now.ToString() + "' ", "");
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
    }
}