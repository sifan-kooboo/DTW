using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_notice : Form
    {
        public Q_notice()
        {
            InitializeComponent();
        }
        string select_s = "";
        string condition = "";
        BLL.Common B_common = new Hotel_app.BLL.Common();
        public void GetData()
        {
            select_s = "select krxm,krsr,krxb,fjrb,fjbh,fjjg,DATEDIFF(day,ddsj,getdate()) as lzts from View_Qskzd";
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and   yddj='" + common_file.common_yddj.yddj_dj + "' ";
            int  sr_month=DateTime.Now.Month;
            int  sr_day=DateTime.Now.Day;
            if (tabControl1.SelectedIndex != null)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    select_s = "select  *  from  View_Qskzd ";
                    condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and   yddj='" + common_file.common_yddj.yddj_dj + "' ";
                    condition += "  and  datepart(mm,krsr)=" + sr_month + " and datepart(dd,krsr)=" + sr_day + "   and  krsr!='1800-01-01' and krsr!='1800-1-1' and krsr!='1800-01-1'  and krsr!='1800-1-01' ";
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    select_s = "select krxm,krsr,krxb,fjrb,fjbh,fjjg,DATEDIFF(day,ddsj,getdate())  'lzts'  from View_Qskzd";
                    condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and   yddj='" + common_file.common_yddj.yddj_dj + "' ";
                    condition += "  and     DATEDIFF(day,ddsj,getdate())>=4  ";

                }
            }
            DataSet ds = B_common.GetList(select_s, condition);
            bindingSource_tx.DataSource = ds.Tables[0];
            if (tabControl1.SelectedIndex == 1)
            {
                dg_tx_krsr.AutoGenerateColumns = false;
                dg_tx_krsr.DataSource = bindingSource_tx;
            }
            if (tabControl1.SelectedIndex ==0)
            {
                dg_tx_thirdDays.AutoGenerateColumns = false;
                dg_tx_thirdDays.DataSource = bindingSource_tx;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                GetData();
            }
            if (tabControl1.SelectedIndex == 0)
            {
                GetData();
            }

        }

        private void Q_notice_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            GetData();
        }
    }
}