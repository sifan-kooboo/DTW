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
    public partial class Frm_BB_zdkr_ylfx : Form
    {
        public Frm_BB_zdkr_ylfx()
        {
            InitializeComponent();
        }
        DataSet ds = null;
        string sel_con_temp = "";
        private void displayBB(string Time_begin, string Time_end)
        {
            sel_con_temp="";
            DateTime dt1 = DateTime.Parse(Time_begin.Trim().Replace('/', '-'));
            DateTime dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-') + "  23:59:59");
            if (dt1 < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "预离日期不能早于当前时间,请正确选择预离日期");
                return;
            }
            if (tb_lc.Text.Trim() != "")
            {
                sel_con_temp += "  and   jdcs_name  like  '%" + tb_lc.Text.Trim() + "%'  ";

            }
            if (tb_lh.Text.Trim() != "")
            {
                sel_con_temp += "  and   jdlh_name like  '%" + tb_lh.Text.Trim() + "%'  ";
            }
            ds=Get_zdylData(dt1.ToString(),dt2.ToString(),sel_con_temp);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);

                BB_zdkr_ylfx   myreport = new BB_zdkr_ylfx();
                common_bb.displayprogress(progressBar1);
                myreport.SetDataSource(ds.Tables[0]);
                myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
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
            displayBB(dtp_jssj.Text.Trim(), dtp_jssj.Text.Trim());
        }

        private void b_gl_exit_Click_1(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            dtp_jssj.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }

        private void b_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_zdkr_ylfx_Load(object sender, EventArgs e)
        {
            //初始状态显示当天预离的宾客分析
            displayBB(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());
        }


        private DataSet Get_zdylData(string cssj, string jssj,string  sel_cond)
        {
            //qymc, yydh, cssj, jssj, czy_temp, czsj, xxzs
            DataSet ds = null;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
            object[] args = new object[7];
            args[0] = common_file.common_app.qymc;
            args[1] = common_file.common_app.yydh;
            args[2] = cssj.ToString();
            args[3] = jssj.ToString();
            args[4] = common_file.common_app.czy;
            args[5] = DateTime.Now.ToString();
            args[6] = common_file.common_app.xxzs;
            //object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "get_zzkr_ylfx_app", args);
            Server.BBfx.B_zdkr_ylfx B_zdkr_ylfx_new = new Hotel_app.Server.BBfx.B_zdkr_ylfx();
            string result = B_zdkr_ylfx_new.Get_zdkr_ylData(args[0].ToString(), args[1].ToString(),
                args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString());

            if (result != null && result.ToString() == common_file.common_app.get_suc)
            {
                string  select_str=" id>=0  and yydh='" + common_file.common_app.yydh + "'  and  lksj>='" + cssj + "'  and  lksj<='" + jssj + "'  and main_sec='" + common_file.common_app.main_sec_main + "'    and  czy_temp='"+common_file.common_app.czy+"'";
                if (sel_cond != "")
                {
                    select_str += sel_cond;
                }
                ds = B_common.GetList(" select * from  View_zdkr_ylfx_temp  ", select_str);
            }
            return ds; 
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
            nameList.Add("krxm", "客人姓名");
            nameList.Add("zjhm", "证件号码");
            nameList.Add("krly", "客人来源");
            nameList.Add("xydw", "协议单位");
            nameList.Add("xsy", "销售员");
            nameList.Add("ddsj", "到店时间");
            nameList.Add("lksj", "离店时间");
            nameList.Add("sktt", "散客团队");
            nameList.Add("fjrb", "房间类别");
            nameList.Add("fjbh", "房间编号");
            nameList.Add("jdlh_name", "酒店楼号");
            nameList.Add("jdcs_name", "酒店层数");
            nameList.Add("sjfjjg", "实际房间价格");
            nameList.Add("lzrs", "入住人数");
            nameList.Add("lzfs", "入住房数");
            nameList.Add("ylrq", "预离日期");
            nameList.Add("main_sec", "主客或者次客");
            common_bb.ExportToExcel(ds, nameList);
            Cursor.Current = Cursors.Default;

        }
    }
}