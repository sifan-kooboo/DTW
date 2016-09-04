using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hotel_app.Qyddj
{
    public partial class Q_TEMP : Form
    {
        public int i = 0;
        public Q_TEMP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float sl = common_file.common_used_fjzt.get_fjzt_sl_canused("", DateTime.Parse(tb_ddsj.Text), DateTime.Parse(tb_lksj.Text), tb_fjrb.Text, true, true, 0, 0);
          common_file.common_app.Message_box_show(common_file.common_app.message_title,sl.ToString()); 
        }

        private void Q_TEMP_Load(object sender, EventArgs e)
        {

        }

        private void Q_TEMP_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Parse("2012-03-03 3:08:59");
            DateTime d2 = DateTime.Parse("2012-03-03 4:08:59");
            string[] info = Convert.ToString(DateTime.Parse(d2.ToShortDateString()) - DateTime.Parse(d1.ToShortDateString())).Split('.');
            if (info.Length > 1)
            {
                tb_ddsj.Text = info[0];
                d1 = d1.AddDays(int.Parse(info[0]) - 1);
            }
            tb_lksj.Text = d1.ToString();
        }

        private void tb_ddsj_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
           
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            //tb_ddsj.Text = "czy";
            //panel1
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            tb_ddsj.Text = "xqm";
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            tb_ddsj.Text = "czy00";
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            tb_ddsj.Text = "czy13";
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            tb_ddsj.Text = "czy69";

        }

        private void panel1_MouseCaptureChanged(object sender, EventArgs e)
        {
            //tb_ddsj.Text = "loi";
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //tb_ddsj.Text = "uioopp";
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            Pb.Visible = false;
            tb_ddsj.Text = "456";
            tb_lksj.Text = panel1.GetType().ToString();
        }

        private void uC_room_pic_01_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel2_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            Pb.Visible = true;
            
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Pb.Left = common_file.common_app.x();
            Pb.Top = common_file.common_app.y();
        }

        private void Q_TEMP_MouseMove(object sender, MouseEventArgs e)
        {
            Pb.Left = common_file.common_app.x();
            Pb.Top = common_file.common_app.y();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Qyddj.Q_zjgl Q_zjgl_new=new Q_zjgl();
            //Q_zjgl_new.get_sfz_info_tb(ref tBkrxm, ref tBkrxb, ref tBnation, ref tBadd, ref tBid, ref tBkrsr, ref tBdepart, ref tBstart, ref tBend);
            //common_file.common_app.Message_box_show("123",tBkrxb.Text.Trim().Length.ToString());
        }

        public int get_ls( char[] s)
        {
            int i = 0;
            s[0] = '6';
            s[1] = '6';
            s[2] = '6';
            return i;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            char[] s = new char[3];// { '0', '0', '0' };
            get_ls(s);
            string get_s = "";
            foreach (char i in s)
            { get_s += i; }
            tb_ddsj.Text = get_s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = "中1x国.,";
            //string s = "123456";
            common_file.common_app.Message_box_show("1",s.Length.ToString());
            tb_ddsj.Text = s.Substring(0,5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Qyddj.Q_temp_3 Q_temp_3_new = new Q_temp_3();
            Q_temp_3_new.OnTimer();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hhygl.H_hygl_k H_hygl_k_new = new Hotel_app.Hhygl.H_hygl_k();
           tB_hykh.Text= H_hygl_k_new.get_hykh();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hhygl.H_hygl_k H_hygl_k_new = new Hotel_app.Hhygl.H_hygl_k();
            H_hygl_k_new.write_hykh(tB_hykh.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BLL.Common B_Common=new Hotel_app.BLL.Common();
            DataSet DS_temp=B_Common.GetList("select * from Qskyd_mainrecord","id>=0");
            DS_temp.Clear();
            DS_temp.Dispose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Model.Q_sfz_save M_Q_sfz_save = new Hotel_app.Model.Q_sfz_save();
            BLL.Q_sfz_save B_Q_sfz_save = new Hotel_app.BLL.Q_sfz_save();
            M_Q_sfz_save = B_Q_sfz_save.GetModel(1);
            if (M_Q_sfz_save != null)
            {


                byte[] b = (byte[])M_Q_sfz_save.krxp;
                if (b.Length > 0)
                {
                    MemoryStream stream = new MemoryStream(b, true);
                    stream.Write(b, 0, b.Length);
                    pictureBox1.Image = new Bitmap(stream);
                    stream.Close();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string s="";
            string[] s_0=s.Split('|');
            tb_ddsj.Text = s_0[0]+" "+s_0.Length;
        }

        //public static void memset(byte[] buf, byte val, int size)  
        //int i;  
        //for (i = 0; i < size; i++)  
        //buf[i] = val;  




    }
}