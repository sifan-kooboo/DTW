using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public partial class Time_count : Form
    {
        public int i = 11;
        public Time_count()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            i = i -1;
            label1.Text = i.ToString();
            if (i < 0)
            {
                this.Close();
            
            }
        }
    }
}