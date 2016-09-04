using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Hotel_app.common_file;

namespace Hotel_app.Xxtsz
{
    public partial class Ｘ_ftsm : Form
    {
        public Ｘ_ftsm()
        {
            InitializeComponent();
            loadUpdateInfo();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void loadUpdateInfo()
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

    }
}
