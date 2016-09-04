using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_skyd_print_djb : Form
    {
        public Q_skyd_print_djb(string _lsbh,string _sk_tt,string _czy,string _ddbh)
        {
            InitializeComponent();
            lsbh = _lsbh;
            sk_tt = _sk_tt;
            czy = _czy;
            ddbh = _ddbh;
            inital();
        }
        DataSet ds = null;
        public string lsbh = "";
        public string sk_tt = "";
        public string czy = "";
        public string zjhm = "";
        public string ddbh = "";
        public string ysk_tj = "0";
        BLL.Common B_common = new Hotel_app.BLL.Common();

        private void Q_skyd_print_djb_Load(object sender, EventArgs e)
        {
        }

        private void   inital()
        {
            if (lsbh.Trim() != "" && sk_tt.Trim() != "")
            {
                ysk_tj=GetYsk(lsbh);
                if (sk_tt == "sk")
                {
                    ds = B_common.GetList(" SELECT * from  View_skyd_djb  ", "  lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'");
                    if (ds != null&&ds.Tables[0].Rows.Count>0)
                    {


                        try
                        {
                            Q_skyd_djb myreport = new Q_skyd_djb();
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "") 
                                {
                                    ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                }
                                else
                                {
                                    ds.Tables[0].Rows[i]["yxzj"] = ("") as object; 
                                }
                                
                            }
                            myreport.SetDataSource(ds.Tables[0]);
                            crystalReportViewer1.ReportSource = myreport;
                            myreport.SetParameterValue("czy", czy);
                            myreport.SetParameterValue("ysk_tj", ysk_tj);
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }
                        catch
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请正确设置打印机");
                        }

                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前订单没有任何在住客人信息,打印终止!");
                    }
                }
                if (sk_tt == "tt")
                {
                    ds = B_common.GetList(" SELECT  *   from  VIEW_Qttyd_djb  ", "  ddbh='" +ddbh + "'  and yydh='" + common_file.common_app.yydh + "'");
                    if (ds != null&&ds.Tables[0].Rows.Count>0)
                    {
                        try
                        {
                            Q_skyd_djb myreport = new Q_skyd_djb();
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[i]["zjhm"].ToString().Trim() != "")
                                {
                                    ds.Tables[0].Rows[i]["yxzj"] = (ds.Tables[0].Rows[i]["yxzj"].ToString() + ": ") as object;
                                }
                                else
                                {
                                    ds.Tables[0].Rows[i]["yxzj"] = ("") as object;
                                }
                                if(DateTime.Parse(ds.Tables[0].Rows[i]["krsr"].ToString().Trim()).Date.CompareTo(DateTime.Parse(common_file.common_app.cssj))==0)
                                {
                                    ds.Tables[0].Rows[i]["krsr"]="";
                                }

                            }
                            myreport.SetDataSource(ds.Tables[0]);
                            crystalReportViewer1.ReportSource = myreport;
                            myreport.SetParameterValue("czy", czy);
                            myreport.SetParameterValue("ysk_tj", ysk_tj);
                            myreport.PrintToPrinter(1, true, 0, 0);
                        }
                        catch 
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "打印出错,请正确设置打印机");
                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前订单没有任何在住客人信息,打印终止!");
                    }
                }
            }

        }

        private string GetYsk(string lsbh)
        {
            decimal ysk_tj = 0;
            DataSet  ds=null;
            BLL.Szwzd B_szwzd = new Hotel_app.BLL.Szwzd();
            ds = B_szwzd.GetList("  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "' ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ysk_tj = decimal.Parse(ds.Tables[0].Rows[0]["fkje"].ToString());
            }
            else
            {
                ysk_tj = 0;
            }
            return ysk_tj.ToString();
        }
    }
}