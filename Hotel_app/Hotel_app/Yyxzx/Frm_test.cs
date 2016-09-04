using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yyxzx
{
    public partial class Frm_test : Form
    {
        public Frm_test(string filename)
        {
            InitializeComponent();
            this.filename = filename;
            this.pictureBox1.Image = Image.FromFile(filename);
        }

       
        public string filename = "";
    }
}