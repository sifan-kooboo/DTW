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
    public partial class Frm_BB_xsymxfx : Form
    {
        //销售员明细/协议单位明细共用此窗体
        public Frm_BB_xsymxfx()
        {
            InitializeComponent();
        }


        public void initalApp(string _loadType)
        {
            this.loadType = _loadType;
            if (loadType == "xsymxfx")
            { this.Text = "销售员销售明细分析"; }
            if (loadType == "xydwmxfx")
            { this.Text = "协议单位消费明细分析"; }
            if (loadType == "krlymxfx")
            { this.Text = "客人来源消费明细分析"; }
            second_selection = "";
            //displayBB(DateTime.Now.AddDays(-6).ToShortDateString(), DateTime.Now.ToShortDateString());

        }

        DataSet  ds=null;
        string second_selection = "";
        string sel_str = "";
        string loadType = "";//明细加载类型
        BLL.Common B_common = new Hotel_app.BLL.Common();
        string Time_begin = "";
        string Time_end = "";

        private void displayBB(string sql_0, string sql_other)
        {
            sel_str="";
            sel_str = " id>=0  and   yydh='" + common_file.common_app.yydh + "' and xfdr!='"+Szwgl.common_zw.dr_ds+"'   "+sql_0+sql_other+ "  order by  xsy , xfsj  Desc ";
             //ds = B_common.GetList(" select krxm,xfxm,fjrb,fjbh,xfsj,sjxfje,xydw,xsy,xfzy,xfbz  from VS_syxfmx_cz  ", sel_str);
             ds = B_common.GetList(" select *  from VS_syxfmx_cz  ", sel_str);
             if (ds != null && ds.Tables[0].Rows.Count > 0)
             {
                 p_gl.Visible = false;
                 common_bb.displayprogress(progressBar1);
                 string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                 common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);
                 if (loadType == "xsymxfx")
                 {
                     BB_syxffx_xsy_xsmxfx myreport = new BB_syxffx_xsy_xsmxfx();
                     myreport.SetDataSource(ds.Tables[0]);
                     myreport.SetParameterValue("fx_type", "销售员销售明细分析");

                     myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                     myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                     myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                     myreport.SetParameterValue("address", _address_chinese);
                     myreport.SetParameterValue("Tel", _qydh);
                     myreport.SetParameterValue("Fax", _qycz);
                     crystalReportViewer1.ReportSource = myreport;
                 }
                 if (loadType == "xydwmxfx")
                 {
                     BB_syxffx_xydwmxfx myreport = new BB_syxffx_xydwmxfx();
                     myreport.SetDataSource(ds.Tables[0]);
                     myreport.SetParameterValue("fx_type", "协议单位消费明细分析");

                     myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                     myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                     myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                     myreport.SetParameterValue("address", _address_chinese);
                     myreport.SetParameterValue("Tel", _qydh);
                     myreport.SetParameterValue("Fax", _qycz);
                     crystalReportViewer1.ReportSource = myreport;
                 }
                 if (loadType == "krlymxfx")
                 {
                     BB_syxffx_krlymxfx myreport = new BB_syxffx_krlymxfx();
                     myreport.SetDataSource(ds.Tables[0]);
                     myreport.SetParameterValue("fx_type", "客人来源消费明细分析");

                     myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                     myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                     myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                     myreport.SetParameterValue("address", _address_chinese);
                     myreport.SetParameterValue("Tel", _qydh);
                     myreport.SetParameterValue("Fax", _qycz);
                     crystalReportViewer1.ReportSource = myreport;
                 }
             }
             else
             {
                 crystalReportViewer1.ReportSource = null;
                 common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前时间段内没有分析数据,您可以更改查询条件来获取其它的分析数据！");
                 //return;
             }
        }

        private void Frm_BB_xsymxfx_Load(object sender, EventArgs e)
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

        private void M_gl_Click(object sender, EventArgs e)
        {
            //p_gl.Visible = true;
            //dtp_cssj.Text = DateTime.Now.ToShortDateString();
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

        private void M_refresh_Click(object sender, EventArgs e)
        {

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
            if(DateTime.Parse(dtp_cssj.Text.Trim())>DateTime.Parse(dtp_jssj.Text.Trim()))
            {
                 common_file.common_app.Message_box_show(common_file.common_app.message_title,"请正确选择消费时间");
                return ;
            }
            second_selection+="  and  xfsj>='"+dtp_cssj.Text.Trim()+"'  and xfsj<='"+dtp_jssj.Text.Trim()+"  23:59:59 "+"' ";

            if(tb_fjbh.Text.Trim()!="")
            {second_selection+=" and  fjbh  like '%"+tb_fjbh.Text.Trim().Replace("'","-")+"%' ";}
            if(tb_krly.Text.Trim()!="")
            {second_selection+="  and  krly like '%"+tb_krly.Text.Trim().Replace("'","-")+"%' ";}
            if(tb_krxm.Text.Trim()!="")
            {second_selection+="  and krxm like '%"+tb_krxm.Text.Trim().Replace("'","-")+"%' ";}
            if(tb_sktt.Text.Trim()!="")
            {second_selection+="  and sktt like '%"+tb_sktt.Text.Trim().Replace("'","-")+"%' ";}
            if(tb_xfbz.Text.Trim()!="")
            { 
                second_selection+="  and xfbz like '%"+tb_xfbz.Text.Trim().Replace("'","-")+"%' ";
            }
            if(tb_xfxm.Text.Trim()!="")
            { 
                second_selection+="  and xfxm like '%"+tb_xfxm.Text.Trim().Replace("'","-")+"%' ";
            }
            if(tb_xfzy.Text.Trim()!="")
            {second_selection+="  and xfzy like '%"+tb_xfzy.Text.Trim().Replace("'","-")+"%' ";}
            if(tb_xsy.Text.Trim()!="")
            {second_selection+="  and xsy like '%"+tb_xsy.Text.Trim().Replace("'","-")+"%' ";}
            if(tb_xydw.Text.Trim()!="")
            {
               second_selection+="  and xydw  like '%"+tb_xydw.Text.Trim().Replace("'","-")+"%' ";  
            }

            displayBB(dtp_cssj.Text.Trim().Replace("/", "-"), dtp_jssj.Text.Trim().Replace("/", "-"));
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
            common_bb.ExportMX(ds, "mx");
        }
    }
}