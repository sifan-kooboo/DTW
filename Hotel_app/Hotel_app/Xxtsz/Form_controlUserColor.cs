using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Form_controlUserColor : Form
    {
        public Form_controlUserColor()
        {
            InitializeComponent();
        }





        private void colorEdit_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ColorEdit ce = (DevExpress.XtraEditors.ColorEdit)sender;
            if (ce.Name == "colorEdit_gj")
            {
                p_range1.BackColor = ce.Color;
            }

            if (ce.Name =="colorEdit_qt")
            {
                p_range1.BackColor = ce.Color;
            }

            if (ce.Name =="colorEdit_wx")
            {
                p_range1.BackColor = ce.Color;
            }

            if (ce.Name =="colorEdit_yd")
            {
                p_buttom.BackColor = ce.Color;
                p_buttom.BringToFront();
            }

            if (ce.Name =="colorEdit_ydyl")
            {
                pB_arrival.BackColor = ce.Color;
                pB_arrival.BringToFront();
            }
            if (ce.Name == "colorEdit_yj")
            {
                pB_room_clean.BackColor = ce.Color;
                pB_room_clean.BringToFront();
            }

            if (ce.Name == "colorEdit_zf")
            {
                p_range1.BackColor = ce.Color;
            }

            if (ce.Name == "colorEdit_zzf")
            {
                p_range1.BackColor = ce.Color;
            }
            if (ce.Name == "colorEdit_hy")
            {
                pB_room_VIP.BackColor = ce.Color;
                pB_room_VIP.BringToFront();
            }
            if (ce.Name == "colorEdit_gq")
            {
                pB_leaving.BackColor = ce.Color;
                pB_leaving.BringToFront();
            }
            if (ce.Name == "colorEdit_yjld")
            {
                pB_arrival.BackColor = ce.Color;
                pB_arrival.BringToFront();
            }
            if (ce.Name == "colorEdit_yjdd")
            {
                pB_arrival.BackColor = ce.Color;
                pB_arrival.BringToFront();
            }
            textBox1.Text = ce.Color.Name;
            MessageBox.Show(ce.Color.Name);
        }

        #region 房态颜色
        string gz_colorName = "";string gz_PicName="";
        string zf_colorName = "";string zf_PicName="";
        string zzf_colorName = "";string zzf_PicName="";
        string wxf_colorName = ""; string wxf_PicName = "";
        string qt_colorName = ""; string qt_PicName = "";
        string yd_colorName = "";
       // string 
        #endregion

        private void Form_controlUserColor_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
