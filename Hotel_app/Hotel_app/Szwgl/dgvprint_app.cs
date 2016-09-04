using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class dgvprint_app : Form
    {
        public dgvprint_app()
        {
            InitializeComponent();
        }
        DataSet ds_print = new DataSet();
        string lsbh = "";
        string sel_con = "";
        string loadType = "";
        public dgvprint_app(string lsbh,string sel_con,string  _loadType,DataSet _ds_print)
        {
            loadType = _loadType;
            this.ds_print = _ds_print;
            this.lsbh = lsbh;
            this.sel_con = sel_con;
            //单张单子打印(保留)
            if (lsbh.Trim() != "" && loadType == "single")
            {
                if (sel_con.Trim() != "")
                {
                    sel_con = " and  " + sel_con + " ";
                }
                BLL.Common B_common = new Hotel_app.BLL.Common();
                ds_print = B_common.GetList(" select * from Szw_temp ", "id>=0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'  and  czy_temp='" + common_file.common_app.czy + "' " + sel_con + "  order by  xfsj  desc");
                //print();
            }
            //区域打印
            if (lsbh.Trim() == "" && loadType == "multi" && ds_print != null && ds_print.Tables[0].Rows.Count > 0)
            {
                print();
            }
            if (lsbh.Trim() != "" && loadType == "jbmx" && ds_print != null && ds_print.Tables[0].Rows.Count > 0)
            {
                print();
            }
            if (lsbh.Trim() != "" && loadType == "jkmx" && ds_print != null && ds_print.Tables[0].Rows.Count > 0)
            {
                print();
            }



        }


        public void print()
        {
            if (ds_print != null && ds_print.Tables[0].Rows.Count > 0)
            {
                try
                {
                    if (loadType == "single")
                    {
                        dgvprint myreport = new dgvprint();
                        myreport.SetDataSource(ds_print.Tables[0]);
                        CrystalDecisions.Windows.Forms.CrystalReportViewer cr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                        cr.ReportSource = myreport;
                        myreport.PrintToPrinter(1, true, 0, 0);
                    }
                    if (loadType == "multi")
                    {
                        //cr_yj_gl_print myreport = new cr_yj_gl_print();
                        //myreport.SetDataSource(ds_print.Tables[0]);
                        //CrystalDecisions.Windows.Forms.CrystalReportViewer cr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                        //myreport.PrintToPrinter(1, true, 0, 0);
                    }
                    if (loadType == "jbmx")
                    {
                        DataSet ds_temp=null;
                        string syzd = ""; string jbren = ""; string jiebren = ""; string jbbc = ""; string scjbsj = ""; string bcjbsj = "";
                        cr_jbmx myreport = new cr_jbmx();
                        myreport.SetDataSource(ds_print.Tables[0]);
                        if (this.lsbh.Trim() != "")
                        {
                            BLL.S_jbzd  B_jbzd=new Hotel_app.BLL.S_jbzd();
                            ds_temp = B_jbzd.GetList(" id>=0 and  lsbh='" + lsbh + "' and  yydh='" + common_file.common_app.yydh + "'");
                            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                            {
                                syzd = ds_temp.Tables[0].Rows[0]["syzd"].ToString();
                                jbren = ds_temp.Tables[0].Rows[0]["czy_jb"].ToString();
                                jiebren = ds_temp.Tables[0].Rows[0]["czy_sb"].ToString();
                                jbbc = ds_temp.Tables[0].Rows[0]["j_s_bc"].ToString();
                                scjbsj = ds_temp.Tables[0].Rows[0]["cssj"].ToString();
                                bcjbsj = ds_temp.Tables[0].Rows[0]["czsj"].ToString();
                            }
 
                        }
                        myreport.SetParameterValue("syzd", syzd);
                        myreport.SetParameterValue("jbren", jbren);

                        myreport.SetParameterValue("jiebren", jiebren);
                        myreport.SetParameterValue("jbbc", jbbc);
                        myreport.SetParameterValue("scjbsj", scjbsj);
                        myreport.SetParameterValue("bcjbsj", bcjbsj);
                        CrystalDecisions.Windows.Forms.CrystalReportViewer cr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                        myreport.PrintToPrinter(1, true, 0, 0);
                    }
                    if (loadType == "jkmx")
                    {
                        DataSet ds_temp = null;
                        string syzd = ""; string bcjksj = "";
                        cr_jkmx myreport = new cr_jkmx();
                        myreport.SetDataSource(ds_print.Tables[0]);
                        if (this.lsbh.Trim() != "")
                        {
                            BLL.S_jbzd B_jbzd = new Hotel_app.BLL.S_jbzd();
                            ds_temp = B_jbzd.GetList(" id>=0 and  lsbh='" + lsbh + "' and  yydh='" + common_file.common_app.yydh + "'");
                            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                            {
                                syzd = ds_temp.Tables[0].Rows[0]["syzd"].ToString();
                                bcjksj = ds_temp.Tables[0].Rows[0]["czsj"].ToString();
                            }
                        }
                        myreport.SetParameterValue("bcjksj", bcjksj);
                        myreport.SetParameterValue("syzd", syzd);
                        myreport.SetParameterValue("czy", common_file.common_app.czy);
                        CrystalDecisions.Windows.Forms.CrystalReportViewer cr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                        myreport.PrintToPrinter(1, true, 0, 0);
                    }
                }
                catch (Exception  ee)
                {

                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请与系统管理员联系!");
                }
            }

        }
    }
}