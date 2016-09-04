using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    
    public partial class Fyddj_remind : Form
    {
        public DataSet DS_yddj;
        public Fyddj_remind(DataSet DS_temp)
        {
            DS_yddj = DS_temp;
            InitializeComponent();
            InitializeApp(DS_yddj);
        }
        public Fyddj_remind()
        {
            InitializeComponent();
        }

        public void InitializeApp(DataSet DS_temp)
        {
            bindingSource1.DataSource = DS_temp.Tables[0];
            this.dg_yddj.AutoGenerateColumns = false;
        }

        private void Fyddj_remind_Load(object sender, EventArgs e)
        {
        }

        private void dg_yddj_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dg_yddj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

    }
}