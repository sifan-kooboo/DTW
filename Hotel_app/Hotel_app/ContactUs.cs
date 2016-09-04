using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Hotel_app.common_file;

namespace Hotel_app
{
    public partial class ContactUs : Form
    {
        public ContactUs()
        {
            InitializeComponent();
        }

        private void ContactUs_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string fileName_notice = Application.StartupPath + @"\notice.txt";
            FileStream fs = new FileStream(fileName_notice, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fileName_notice, Encoding.GetEncoding("gb2312"));
            try
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    sb.AppendLine(line);
                    line = sr.ReadLine();
                }
                richTextBox1.Text = sb.ToString();
            }
            catch (Exception ee)
            {
                common_app.Message_box_show(common_app.message_title, "对不起，读取文件失败");
            }
            finally { sr.Close(); fs.Close(); }
        }

        //private int WM_NCHITTEST = 0x0084;
        //private int HTCAPTION = 2;

        //protected override void WndProc(ref System.Windows.Forms.Message msg)
        //{
        //    if (msg.Msg == WM_NCHITTEST)
        //        msg.Result = (System.IntPtr)HTCAPTION;
        //    else base.WndProc(ref msg);
        //} 


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContactUs_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);

        }
        Point mouse_offset = new Point();
        private void ContactUs_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { Point mousePos = Control.MousePosition; mousePos.Offset(mouse_offset.X, mouse_offset.Y); Location = mousePos; }
        }
    }
}