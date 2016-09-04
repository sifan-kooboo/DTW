using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_yd_wx_remind : Form
    {
        DataSet DS_sk;
        DataSet DS_tt;
        DataSet DS_wx;
        string select_s = "";
        int dg_count_sk = 0;
        int dg_count_tt = 0;
        int dg_count_wx = 0;
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        public Q_yd_wx_remind()
        {
            InitializeComponent();
            refresh_sk(); refresh_tt(); refresh_wx();

        }
        public void refresh_sk()
        {
            select_s = "select * from View_Qskzd";
            dG_sk.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj<'" + DateTime.Now.ToShortDateString() + "' and sktt<>'" + common_file.common_sktt.sktt_tt + "' and sktt<>'" + common_file.common_sktt.sktt_hy+ "' order by fjbh";
            DS_sk = B_Common.GetList(select_s, condition);
            bS_sk.DataSource = DS_sk.Tables[0];
            dg_count_sk = DS_sk.Tables[0].Rows.Count;
        }
        public void refresh_tt()
        {
            select_s = "select * from Qttyd_mainrecord";
            dG_tt.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   yddj='" + common_file.common_yddj.yddj_yd + "'and ddsj<'" + DateTime.Now.ToShortDateString() + "'order by id ";
            DS_tt = B_Common.GetList(select_s, condition);
            bS_tt.DataSource = DS_tt.Tables[0];
            dg_count_tt = DS_tt.Tables[0].Rows.Count;
        }

        public void refresh_wx()
        {
            select_s = "select * from Fwx_other";
            dG_wx.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and    lksj<'" + DateTime.Now.ToShortDateString() + "'order by id ";
            DS_wx = B_Common.GetList(select_s, condition);
            bS_wx.DataSource = DS_wx.Tables[0];
            dg_count_wx = DS_tt.Tables[0].Rows.Count;
        }

        private void b_exit_0_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_exit_1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}