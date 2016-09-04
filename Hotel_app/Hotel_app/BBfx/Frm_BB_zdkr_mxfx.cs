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
    public partial class Frm_BB_zdkr_mxfx : Form
    {
        public Frm_BB_zdkr_mxfx(string _loadType)
        {
            InitializeComponent();
            this.LoadType = _loadType;
            if (LoadType == "fjbh")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要显示房价?") == true)
                {
                    LoadType = "fjbh";
                }
                else
                {
                    LoadType = "fjbhWithNoFj";
                }
            }
            if (LoadType == "krly")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要显示房价?") == true)
                {
                    LoadType = "krly_fj";
                }
                else
                {
                    LoadType = "krly_nofj";
                }
            }
            common_file.common_app.get_czsj();
        }

        DataSet ds = null;
        string sel_con_temp = "";
        public   string LoadType = "";//按哪种类型来查看
        public void displayBB(string Time_end)
        {
            common_file.common_app.get_czsj();
            DateTime dt2 = DateTime.Parse(Time_end.Trim().Replace('/', '-') + "  23:59:59");
            sel_con_temp = "";
            sel_con_temp += "   and  lksj<='" + dt2.ToString() + "'   ";

            if (tb_krly.Text.Trim() != "")
            {
                sel_con_temp += "   and  krly like '%" + tb_krly.Text.Trim() + "%' ";
            }
             
            if (tb_lc.Text.Trim() != "")
            {
                sel_con_temp += "  and   jdcs_name  like  '%" + tb_lc.Text.Trim() + "%'  ";

            }
            if (tb_lh.Text.Trim() != "")
            {
                sel_con_temp += "  and   jdlh_name like  '%" + tb_lh.Text.Trim() + "%'  ";
            }
            ds = Get_zdmxData( dt2.ToString(), sel_con_temp, LoadType);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);



                int manTotal = 0;
                int womanTotal = 0;
                int qt=0;
                int total = 0;
                if (LoadType == "krxb")
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["krxb"].ToString() == "男")
                        {
                            manTotal += 1;
                        }
                       else  if (ds.Tables[0].Rows[i]["krxb"].ToString() == "女")
                        {
                            womanTotal += 1;
                        }
                        else
                        {
                            qt += 1;
                        }
                    }
                    total = manTotal + womanTotal + qt;
                }



                if (LoadType == "krly_nofj")
                {
                    BB_zdkr_mxfx myreport = new BB_zdkr_mxfx();
                    common_bb.displayprogress(progressBar1);
                    myreport.SetDataSource(ds.Tables[0]);
                    //myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("qymc", _qymc);
                    myreport.SetParameterValue("address", _address_chinese);
                    myreport.SetParameterValue("Tel", _qydh);
                    myreport.SetParameterValue("Fax", _qycz);
                    crystalReportViewer1.ReportSource = myreport;
                }
                if (LoadType == "krly_fj")
                {
                    BB_zdkr_mxfx_krly_fj myreport = new BB_zdkr_mxfx_krly_fj();
                    common_bb.displayprogress(progressBar1);
                    myreport.SetDataSource(ds.Tables[0]);
                    //myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("qymc", _qymc);
                    myreport.SetParameterValue("address", _address_chinese);
                    myreport.SetParameterValue("Tel", _qydh);
                    myreport.SetParameterValue("Fax", _qycz);
                    crystalReportViewer1.ReportSource = myreport;
                    
                }
                if (LoadType == "fjbh")
                {
                    BB_zdkr_mxfx_fjbh myreport = new BB_zdkr_mxfx_fjbh();
                    common_bb.displayprogress(progressBar1);
                    myreport.SetDataSource(ds.Tables[0]);
                    //myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("qymc", _qymc);
                    myreport.SetParameterValue("address", _address_chinese);
                    myreport.SetParameterValue("Tel", _qydh);
                    myreport.SetParameterValue("Fax", _qycz);
                    crystalReportViewer1.ReportSource = myreport;
                }
                if (LoadType == "fjbhWithNoFj")
                {
                    BB_zdkr_mxfx_fjbh_nofj myreport = new BB_zdkr_mxfx_fjbh_nofj();
                    common_bb.displayprogress(progressBar1);
                    myreport.SetDataSource(ds.Tables[0]);
                    //myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("qymc", _qymc);
                    myreport.SetParameterValue("address", _address_chinese);
                    myreport.SetParameterValue("Tel", _qydh);
                    myreport.SetParameterValue("Fax", _qycz);
                    crystalReportViewer1.ReportSource = myreport;
                }

                if (LoadType == "krxb")
                {
                    BB_zdkr_mxfx_krxb myreport = new BB_zdkr_mxfx_krxb();
                    common_bb.displayprogress(progressBar1);
                    myreport.SetDataSource(ds.Tables[0]);
                    //myreport.SetParameterValue("cssj", Time_begin.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("jssj", Time_end.Trim().Replace('/', '-'));
                    myreport.SetParameterValue("qymc", _qymc);
                    myreport.SetParameterValue("address", _address_chinese);
                    myreport.SetParameterValue("Tel", _qydh);
                    myreport.SetParameterValue("Fax", _qycz);
                    myreport.SetParameterValue("manTotal", manTotal.ToString());
                    myreport.SetParameterValue("womanTotal", womanTotal.ToString());
                    myreport.SetParameterValue("qt", qt.ToString());
                    myreport.SetParameterValue("Total", total.ToString());
                    crystalReportViewer1.ReportSource = myreport;
                }
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有分析数据,请更改查询条件！");
                return;
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void b_search_Click(object sender, EventArgs e)
        {
            displayBB(dtp_jssj.Text.Trim());
        }

        private void b_gl_exit_Click_1(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.Visible = true;
            //dtp_cssj.Text = DateTime.Now.AddDays(1).ToShortDateString();
            dtp_jssj.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }

        private void b_exit_Click_1(object sender, EventArgs e)
        {

        }

        //private void Frm_zdkr_ylfx_Load(object sender, EventArgs e)
        //{
        //    //初始状态显示在店第二天预离的宾客分析
        //    displayBB(DateTime.Now.AddDays(1).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
        //}


        private DataSet Get_zdmxData( string jssj, string sel_cond,string searchType)
        {
            //qymc, yydh,czy_temp, czsj, xxzs
            BLL.Common B_common = new Hotel_app.BLL.Common();
            string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
            object[] args = new object[6];
            args[0] = common_file.common_app.qymc;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.czy;
            args[3] = DateTime.Now.ToString();
            args[4] = common_file.common_app.xxzs;
            args[5] = searchType;
            //object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "get_zzkr_mxfx_app", args);
            Server.BBfx.B_zdkr_mxfx  B_zdkr_mxfx_new=new Hotel_app.Server.BBfx.B_zdkr_mxfx();
            string result = B_zdkr_mxfx_new.Get_zdkr_mxData(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString());
            if (result!=null&&result.ToString() == common_file.common_app.get_suc)
            {
                string select_str = " id>=0    and  czy_temp='" + common_file.common_app.czy + "'";
                if (searchType != "krxb")
                {
                    select_str += " and yydh='" + common_file.common_app.yydh + "'   and  yddj='" + common_file.common_yddj.yddj_dj+ "'    and main_sec='" + common_file.common_app.main_sec_main + "' ";
                }

                if (sel_cond != "")
                {
                    select_str += sel_cond;
                }
                if (LoadType == "fjbh")
                {
                    select_str += "  order by  fjbh ";
                }
                if (LoadType == "krxb")
                {
                    select_str += " order by  jdcs_name  ";
                }
                ds = B_common.GetList(" select * from  View_zdkr_mx_temp  ", select_str);
            }
            return ds;
        }

        public void Frm_BB_zdkr_mxfx_Load(object sender, EventArgs e)
        {
            //初始状态下显示所以在店客人
            sel_con_temp = "";
            tb_krly.Text = "";
            tb_lc.Text = "";
            tb_lh.Text = "";

            //string cssj_temp = "";
            string jssj_temp = "";
            BLL.Common B_common = new Hotel_app.BLL.Common();
            ds = B_common.GetList("select  *  from  Ffjzt ", "id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  zyzt='" + common_file.common_fjzt.zzf + "'  order by lksj  desc");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                jssj_temp = DateTime.Parse(ds.Tables[0].Rows[0]["lksj"].ToString()).ToShortDateString();
                //cssj_temp = DateTime.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["lksj"].ToString()).ToShortDateString();
                displayBB( jssj_temp);
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前没有入住的客人信息");
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
            nameList.Add("main_sec", "主客或者次客");
            nameList.Add("yddj", "预订/登记");
            nameList.Add("shqh", "全含/不全含");
            nameList.Add("fkje", "付款金额");
            common_bb.ExportToExcel(ds, nameList);
            Cursor.Current = Cursors.Default;
        }
    }
}