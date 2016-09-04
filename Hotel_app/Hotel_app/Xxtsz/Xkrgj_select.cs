using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xkrgj_select : Form
    {
        public int dg_count = 0;
        public BLL.Xkrgj B_Xkrgj = new Hotel_app.BLL.Xkrgj();
        public DataSet DS_Xkrgj;
        public string get_krgj = "";

        public Xkrgj_select()
        {
            InitializeComponent();
            InitializeApp("id>=0" + common_file.common_app.yydh_select + " order by pq,krgj");
        }
        public void InitializeApp(string sel_condition)
        {
            DS_Xkrgj = B_Xkrgj.GetList(sel_condition);
            bindingSource1.DataSource = DS_Xkrgj.Tables[0];
            dg_count = DS_Xkrgj.Tables[0].Rows.Count;
            this.dg_gj.AutoGenerateColumns = false;
            
        }

        private void Xgj_select_Load(object sender, EventArgs e)
        {
            
        }

        private void dg_gj_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dg_gj_DoubleClick(object sender, EventArgs e)
        {
            if (dg_count>0 && DS_Xkrgj.Tables[0].Rows[dg_gj.CurrentRow.Index]["krgj"].ToString() != "")
            {
                int i = dg_gj.CurrentRow.Index;
                DataRowView dgr = dg_gj.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xkrgj.Tables[0].Rows.IndexOf(dgr.Row);
                get_krgj = DS_Xkrgj.Tables[0].Rows[i]["krgj"].ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tB_select_TextChanged(object sender, EventArgs e)
        {
            InitializeApp("id>=0" + common_file.common_app.yydh_select + " and (krgj like'%" + tB_select.Text.Trim() + "%' or zjm like'%" + tB_select.Text.Trim() + "%')");
        }

        private void dg_gj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dg_gj_DoubleClick(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { this.Close(); }

        }

        private void Xkrgj_select_Shown(object sender, EventArgs e)
        {
            tB_select.Focus();
        }
    }
}