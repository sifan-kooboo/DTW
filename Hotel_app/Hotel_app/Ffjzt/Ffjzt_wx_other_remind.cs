using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjzt_wx_other_remind : Form
    {
        public DataSet DS_Fwx_other;
        public Ffjzt_wx_other_remind(DataSet DS_temp)
        {
            DS_Fwx_other = DS_temp;
            InitializeComponent();
            InitializeApp(DS_Fwx_other);
        }

        public Ffjzt_wx_other_remind()
        {

            InitializeComponent();
        }

        public void InitializeApp(DataSet DS_temp)
        {
            bindingSource1.DataSource = DS_temp.Tables[0];
            this.dg_wx_other.AutoGenerateColumns = false;
        }

        private void dg_wx_other_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Escape) { this.Close(); }
        }



    }
}