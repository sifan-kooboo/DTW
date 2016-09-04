using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_tt_krlb_print : Form
    {

        public Q_tt_krlb_print(string _lsbh, string _ddbh,DataSet _ds,string _tt_name,string _isdisplay_fjjg)
        {
            InitializeComponent();
            lsbh = _lsbh;
            ddbh = _ddbh;
            ds = _ds;
            tt_name = _tt_name;
            isdisplay_fjjg = _isdisplay_fjjg;
            print_krlb();
        }
        DataSet ds = null;
        private string tt_name = "";
        private string lsbh = "";
        private string ddbh = "";
        private string isdisplay_fjjg = "";
        private string Total_rs = "";
        BLL.Common B_common = new Hotel_app.BLL.Common();

        private void print_krlb()
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Q_tt_krlb myreport = new Q_tt_krlb();
                if (!bool.Parse(isdisplay_fjjg))
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["sjfjjg"] = "xxxx" as object;
                    }
                }
                //统计人数
                DataSet ds_temp0 = B_common.GetList(" SELECT count(*)  as Total_rs   FROM  View_tt_krlb ", " yydh='" + common_file.common_app.yydh + "' and  ddbh='" + ddbh + "'");
                Total_rs = ds_temp0.Tables[0].Rows[0]["Total_rs"].ToString();
                try
                {
                    myreport.SetDataSource(ds.Tables[0]);
                    crystalReportViewer1.ReportSource = myreport;
                    if (bool.Parse(isdisplay_fjjg))
                    {
                        isdisplay_fjjg = "是"; 
                    }
                    else
                    {
                        isdisplay_fjjg = "否"; 
                    }
                    myreport.SetParameterValue("TotalRs", Total_rs);
                    myreport.SetParameterValue("tt_name", tt_name);
                    myreport.PrintToPrinter(1, true, 0, 0);

                }
                catch (Exception  eee)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, eee.ToString());
                }

            }

        }
    }
}