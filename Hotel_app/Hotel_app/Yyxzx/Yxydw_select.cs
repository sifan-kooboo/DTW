using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yyxzx
{
    public partial class Yxydw_select : Form
    {
        public int dg_count = 0;
        public BLL.Yxydw B_Yxydw = new Hotel_app.BLL.Yxydw();
        public DataSet DS_Yxydw;
        public string get_xyh = "";
        public string get_xydw = "";
        public string get_krly = "";
        public string get_xsy = "";

        public Yxydw_select()
        {
            InitializeComponent();
            //InitializeApp("id>=0"+common_file.common_app.yydh_select+" order by xyh");
            InitializeApp("id>=0" + "  and rx='" +common_file.common_xydw.krly_xydw + "'  " + " order by xyh");
 
        }

        public void InitializeApp(string sel_condition)
        {
            DS_Yxydw = B_Yxydw.GetList(sel_condition);
            bindingSource1.DataSource = DS_Yxydw.Tables[0];
            dg_count = DS_Yxydw.Tables[0].Rows.Count;
            this.dg_xydw.AutoGenerateColumns = false;
        }

        private void tB_select_TextChanged(object sender, EventArgs e)
        {
            InitializeApp("id>=0" + " and rx='" + common_file.common_xydw.krly_xydw + "' " + " and (xyh like'%" + tB_select.Text.Trim() + "%' or xyh_inner like'%" + tB_select.Text.Trim() + "%' or xydw like'%" + tB_select.Text.Trim() + "%' or zjm like'%" + tB_select.Text.Trim() + "%')");
        }

        private void dg_xydw_DoubleClick(object sender, EventArgs e)
        {
            if (dg_count > 0 &&dg_xydw.CurrentRow.Index<dg_count&& DS_Yxydw.Tables[0].Rows[dg_xydw.CurrentRow.Index]["xydw"].ToString() != "")
            {
                get_xyh = DS_Yxydw.Tables[0].Rows[dg_xydw.CurrentRow.Index]["xyh"].ToString();
                get_xydw = DS_Yxydw.Tables[0].Rows[dg_xydw.CurrentRow.Index]["xydw"].ToString();
                get_krly = DS_Yxydw.Tables[0].Rows[dg_xydw.CurrentRow.Index]["krly"].ToString();
                get_xsy = DS_Yxydw.Tables[0].Rows[dg_xydw.CurrentRow.Index]["xsy"].ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dg_xydw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dg_xydw_DoubleClick(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

        private void Yxydw_select_Shown(object sender, EventArgs e)
        {
            tB_select.Focus();
        }

    }
}