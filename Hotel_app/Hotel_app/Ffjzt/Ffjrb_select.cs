using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjrb_select : Form
    {
        public int dg_count = 0;
        public BLL.Ffjrb B_Ffjrb = new Hotel_app.BLL.Ffjrb();
        public DataSet DS_Ffjrb;
        public string get_fjrb = "";
        public string get_fjrb_code = "";

        public Ffjrb_select()
        {
            InitializeComponent();
            InitializeApp();
        }

        public void InitializeApp()
        {
            DS_Ffjrb = B_Ffjrb.GetList("id>=0" + common_file.common_app.yydh_select + " order by fjrb");
            bindingSource1.DataSource = DS_Ffjrb.Tables[0];
            dg_count = DS_Ffjrb.Tables[0].Rows.Count;
            this.dg_fjrb.AutoGenerateColumns = false;

        }
        private void dataGridViewSummary1_DoubleClick(object sender, EventArgs e)
        {
            if (dg_fjrb.CurrentRow != null)
            {
                DataRowView dgr = dg_fjrb.CurrentRow.DataBoundItem as DataRowView;
                int i_0 = DS_Ffjrb.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Ffjrb.Tables[0].Rows[i_0]["fjrb"].ToString() != "")
                {
                    get_fjrb = DS_Ffjrb.Tables[0].Rows[i_0]["fjrb"].ToString();
                    get_fjrb_code = DS_Ffjrb.Tables[0].Rows[i_0]["fjrb_code"].ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        private void Ffjrb_select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewSummary1_DoubleClick(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { this.Close(); }
        }
    }
}