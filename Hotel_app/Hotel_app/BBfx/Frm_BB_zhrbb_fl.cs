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
    public partial class Frm_BB_zhrbb_fl : Form
    {
        public Frm_BB_zhrbb_fl()
        {
            InitializeComponent();
            initalApp();
            //GenerateZhrbbFl(dT_cssj.Value.ToString(), dT_jssj.Value.ToString());
        }
        DataSet ds = null;
        string dt_start = "1800-01-01";
        string dt_end = "1800-01-01";
        BLL.Common B_common = new Hotel_app.BLL.Common();
        private void initalApp()
        {
            common_file.common_app.get_czsj();
            this.Text = "综合日报表分录";
            dT_cssj.Text = DateTime.Now.ToShortDateString();
            dT_cssj.Value = DateTime.Now.Date;
            dT_jssj.Text = DateTime.Now.ToShortDateString();
            dT_jssj.Value = DateTime.Now.Date;
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            GenerateZhrbbFl(dT_cssj.Text, dT_jssj.Text);
        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }




        //dataset ds=new dataset(); 
        //DataRow dr = ds.Tables[0].NewRow();
        //dr["Finishdate"] = finishdate;
        //dr["Operator"] =Operator;
        //dr["disp"] =disp;
        //ds.Tables[0].Rows.Add(dr); 

        //生成报表数据
        private void GenerateZhrbbFl(string Time_start, string  Time_end)
        {
            dt_start = Time_start.Replace('/', '-');
            dt_end = Time_end.Replace('/', '-') + "  23:59:59";

            DateTime dt1 = DateTime.Parse(dt_start);
            DateTime dt2 = DateTime.Parse(dt_end);
            if (dt2 < dt1)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "结束时间早于起始时间,请正确选择结束时间");
                return;
            }
            common_bb.displayprogress(progressBar1);
            ds = B_common.GetList(" select * from Bszhrbbfl", "id>=0  and   yydh='" + common_file.common_app.yydh + "' and  bbrq>='" + dt_start + "'  and bbrq<='" + dt_end + "'  order by bbrq  asc");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ds = SummaryRow(ds);
                p_gl.Visible = false;

               string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);


                BB_zhrbb_fl myreport = new BB_zhrbb_fl();
                common_bb.displayprogress(progressBar1);
                myreport.SetDataSource(ds.Tables[0]);
                myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);

                myreport.SetParameterValue("cssj", DateTime.Parse(Time_start.Trim().Replace('/', '-')).Date.ToShortDateString());
                myreport.SetParameterValue("jssj", DateTime.Parse(Time_end.Trim().Replace('/', '-')).Date.ToShortDateString());

                crystalReportViewer1.ReportSource = myreport;
            }
            else
            {
                crystalReportViewer1.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有查到分析数据,请更改查询条件!");
            }
        }


        //对生成的DS加统计行(最后一行)
        private DataSet  SummaryRow(DataSet ds)
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int  RowCount=ds.Tables[0].Rows.Count;
                //计算最后一行的值
                float  zyye=0;//总营业额
                float  zfh=0;//总房费
                float  zfs=0;//总房数
                float  czfs=0;//出租房数
                float pjczl=0;//平均出租率
                float pjfj=0;//平均房价
                float jcb=0;//交叉比
                float sztj=0;//算账合计
                float jztj=0;
                float gztj=0;
                float ljyf=0;//累计预付
                float  yjds=0;//己结代收
                float  wjds=0;//未结代收
                float  ljjz=0;//累计计账
                float ljgz=0;//累计挂账
                float ljwj = 0;//累计未结
                string yydh = ds.Tables[0].Rows[0]["yydh"].ToString();
                string qymc = ds.Tables[0].Rows[0]["qymc"].ToString();


                for (int i = 0; i < RowCount; i++)
                {
                    zyye +=float.Parse(ds.Tables[0].Rows[i]["zyye"].ToString());
                    zfh += float.Parse(ds.Tables[0].Rows[i]["zfh"].ToString());
                    zfs += float.Parse(ds.Tables[0].Rows[i]["zfs"].ToString());
                    czfs += float.Parse(ds.Tables[0].Rows[i]["czfs"].ToString());
                    sztj += float.Parse(ds.Tables[0].Rows[i]["sztj"].ToString());
                    jztj += float.Parse(ds.Tables[0].Rows[i]["jztj"].ToString());
                    gztj += float.Parse(ds.Tables[0].Rows[i]["gztj"].ToString());
                    yjds += float.Parse(ds.Tables[0].Rows[i]["yjds"].ToString());
                    wjds += float.Parse(ds.Tables[0].Rows[i]["wjds"].ToString());
                }
                string  pjczl_temp=(czfs/zfs).ToString();
                pjczl =float.Parse((common_file.common_sswl.Round_sswl(double.Parse(pjczl_temp), 2, common_file.common_sswl.selectMode_normal) * 100).ToString());//其实为百分比
                pjczl_temp =Convert.ToString( pjczl / 100);

                string pjfj_temp = (zfh / czfs).ToString();

                pjfj = float.Parse((common_file.common_sswl.Round_sswl(double.Parse(pjfj_temp), 2, common_file.common_sswl.selectMode_normal).ToString()));
                jcb = float.Parse((common_file.common_sswl.Round_sswl(double.Parse((float.Parse(pjczl_temp) * pjfj).ToString()), 2, common_file.common_sswl.selectMode_normal).ToString()));
                ljyf =float.Parse(ds.Tables[0].Rows[0]["ljyf"].ToString());
                ljjz = float.Parse(ds.Tables[0].Rows[0]["ljjz"].ToString());
                ljgz = float.Parse(ds.Tables[0].Rows[0]["ljgz"].ToString());
                ljwj = float.Parse(ds.Tables[0].Rows[0]["ljwj"].ToString());

                DataRow dr = ds.Tables[0].NewRow();
                dr["yydh"] = yydh;
                dr["qymc"] = qymc;
                dr["zyye"] = zyye;
                dr["zfh"] = zfh;
                dr["zfs"] = zfs;
                dr["czfs"] = czfs;
                dr["sztj"] = sztj;
                dr["jztj"] = jztj;
                dr["gztj"] = gztj;
                dr["yjds"] = yjds;
                dr["wjds"] = wjds;
                dr["pjczl"] = pjczl.ToString()+"%";
                dr["pjfj"] = pjfj;
                dr["jcb"] = jcb;
                dr["ljyf"] = ljyf;
                dr["ljjz"] = ljjz;
                dr["ljgz"] = ljgz;
                dr["ljwj"] = ljwj;
                //dr["bbrq"] = "合计";
                ds.Tables[0].Rows.Add(dr);
            }
            return ds;
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
            //dT_cssj.Text = DateTime.Now.ToShortDateString();
            //dT_jssj.Text = DateTime.Now.ToShortDateString();
        }

        private void M_refresh_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = null;
        }

        private void Frm_BB_zhrbb_fl_Load(object sender, EventArgs e)
        {
            //load时，生成当天的,显示最近七天的数据
            string url = common_file.common_app.service_url + "BBfx/BBfx_app.asmx";
            object[] args = new object[7];
            args[0] = common_file.common_app.yydh;
            args[1] = common_file.common_app.qymc;
            args[2] = DateTime.Parse(DateTime.Now.ToShortDateString());
            args[3] = common_file.common_app.czy;
            args[4] = DateTime.Now;
            args[5] = 4;//生成所有的
            args[6] = common_file.common_app.xxzs;
            Server.BBfx.B_zhrbb B_zhrbb_new = new Hotel_app.Server.BBfx.B_zhrbb();
            object result = B_zhrbb_new.New_zhrbb_app(args[0].ToString(), args[1].ToString(), DateTime.Parse(args[2].ToString()), args[3].ToString(), DateTime.Parse(args[4].ToString()), int.Parse(args[5].ToString()), args[6].ToString());//,args[0])// Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "New_zhrbb_app", args);
            if (result!=null&& result.ToString() == common_file.common_app.get_suc)
            {
                GenerateZhrbbFl(DateTime.Now.AddDays(-7).ToShortDateString(), DateTime.Now.ToShortDateString());
            }
        }

        private void b_exit_Click_1(object sender, EventArgs e)
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
                nameList.Add("zfs", "总房数");
                nameList.Add("zyye", "总营业额");
                nameList.Add("zfh", "总房费");
                nameList.Add("czfs", "出租房数");
                nameList.Add("pjczl", "平均出租率");
                nameList.Add("pjfj", "平均房价");
                nameList.Add("jcb", "交叉比");
                nameList.Add("wjds", "未结代收");
                nameList.Add("gztj", "挂账统计");
                nameList.Add("jztj", "计账统计");
                nameList.Add("sztj", "结账统计");
                nameList.Add("yjds", "已结代收");
                nameList.Add("ljwj", "累计未结");
                nameList.Add("ljyf", "累计预付");
                nameList.Add("ljgz", "累计挂账");
                nameList.Add("ljjz", "累计计账");
                common_bb.ExportToExcel(ds, nameList);
                Cursor.Current = Cursors.Default;
        }
    }
}