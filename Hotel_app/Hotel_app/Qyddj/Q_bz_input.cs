using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_bz_input : Form
    {
       public  string get_bz = "";
        public Q_bz_input()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            get_bz = tB_bz.Text.Trim().Replace("'", "-");
            this.DialogResult = DialogResult.OK;
        }

        private void b_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}