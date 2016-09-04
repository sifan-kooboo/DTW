using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Maticsoft.DBUtility;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
namespace Hotel_app.update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int i = 10;
        bool startUpdate = false;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.downLoad.Enabled = false;
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void downLoad_Click(object sender, EventArgs e)
        {
            if (startUpdate)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GZipCompresser.Decompress(Path.Combine(Application.StartupPath, "update.data"), Application.StartupPath);
                    MessageBox.Show("恭喜您应用程序更新成功");
                    this.Close();
                    Cursor.Current = Cursors.Default;
                    Process.Start(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Hotel_app.exe"));
                    　
                }
                catch(Exception ee)
                {
                    common_app.Message_box_show(common_app.message_title, "更新出错！具体信息为" + ee.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i = i - 1;
           label2.Text = i.ToString();
            if (i < 1)
            {
                timer1.Enabled = false;
                //tb_info.Visible = false;
                startUpdate = true;
                downLoad.Enabled = true;
            }
        }
    }
}