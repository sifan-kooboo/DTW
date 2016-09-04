using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_tfInfo : Form
    {
        string lsbh = "";//传当前帐务的lsbh
        string sk_tt = "";//是团体类型的帐务还是散客帐务
        DataSet ds = null;
        DataSet ds_temp = null;

        BLL.Sjzzd B_sjzzd = new Hotel_app.BLL.Sjzzd();
        BLL.Common B_common = new Hotel_app.BLL.Common();

        public Szw_tfInfo()
        {
            InitializeComponent();
            InitalApp(lsbh, sk_tt);
            this.Text = "退房房间明细";
        }

        public void InitalApp(string _lsbh, string _sk_tt)
        {
            dg_tfinfo.AutoGenerateColumns = false;
            lsbh = _lsbh;
            sk_tt = _sk_tt;
            //否则,明细去相应主单的bak里面找
            ds = B_sjzzd.GetList("  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (sk_tt == "sk")
                {
                    BLL.Qskyd_fjrb_bak B_Qskyd_fjrb_bak = new Hotel_app.BLL.Qskyd_fjrb_bak();
                    ds_temp = B_Qskyd_fjrb_bak.GetList(" lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        objsource.DataSource = ds_temp.Tables[0];
                        dg_tfinfo.DataSource = objsource;
                    }
                }
                if (sk_tt == "tt")
                {
                    BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();
                    ds_temp = B_Qttyd_mainrecord_bak.GetList("  lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'");
                    if (ds_temp != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string ddbh = ds_temp.Tables[0].Rows[0]["ddbh"].ToString();
                        ds_temp = B_common.GetList(" select  *  from  Qskyd_fjrb_bak ", " id>=0 and  yydh='" + common_file.common_app.yydh + "'  and  fjbh!=''  and    lsbh in  (select  lsbh   from  Qskyd_mainrecord_bak  where  id>=0  and yydh='" + common_file.common_app.yydh + "'  and   ddbh='" + ddbh + "')");
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            objsource.DataSource = ds_temp.Tables[0];
                            dg_tfinfo.DataSource = objsource;
                        }
                    }
                }
 
            }
            else//如果当前的lshb在sjzzd里面找不到,就说明是在住或者预定的类型
            {
                if (sk_tt == "sk")
                {
                    BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
                    ds_temp = B_Qskyd_fjrb.GetList(" lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        objsource.DataSource = ds_temp.Tables[0];
                        dg_tfinfo.DataSource = objsource;
                    }
                }
                if (sk_tt == "tt")
                {
                    BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
                    ds_temp = B_Qttyd_mainrecord.GetList("  lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'");
                    if (ds_temp != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string ddbh = ds_temp.Tables[0].Rows[0]["ddbh"].ToString();
                        BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
                        ds_temp = B_Qskyd_fjrb.GetList(" ddbh='" + ddbh + "'  and  yydh='" + common_file.common_app.yydh + "'");
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            objsource.DataSource = ds_temp.Tables[0];
                            dg_tfinfo.DataSource = objsource;
                        }
                    }
                }
            }
        }
    }
}