using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szzzwll : Form
    {
        DataSet ds;
        string sec_condition = "";
        BLL.Szwzz_mx B_Szwzz_mx = new Hotel_app.BLL.Szwzz_mx();
        BLL.Common B_common = new Hotel_app.BLL.Common();
        public Szzzwll()
        {
            InitializeComponent(); 
            InitalApp(" and czsj>='"+DateTime.Now.AddDays(-7).ToString()+"'",""); 
        }

        public void InitalApp(string sql_inital,string other_cond)
        {
            this.dg_zzll.AutoGenerateColumns = false;
            ds = B_common.GetList(" select   * from Szwzz_mx", " id>=0  and yydh='" + common_file.common_app.yydh + "' " + sql_inital+other_cond + "   order by id desc ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                bsource.DataSource = ds.Tables[0];
                dg_zzll.DataSource = bsource;
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,没有查询到相关信息");
                bsource.DataSource = null;
            }
        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            sec_condition = "";
            InitalApp(" and czsj>='" + DateTime.Now.AddDays(-7).ToString() + "'","");
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            Szw_gl Szw_gl_0 = new Szw_gl("Szzzwll");
            if (Szw_gl_0.ShowDialog()==DialogResult.OK)
            {
                sec_condition = Szw_gl_0.get_sel_cond;
                InitalApp("", sec_condition);
            }
        }


        private void b_first_Click(object sender, EventArgs e)
        {
            bsource.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bsource.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bsource.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bsource.MoveLast();
        }
    }
}