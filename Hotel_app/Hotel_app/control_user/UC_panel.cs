using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.control_user
{
    public partial class UC_panel : UserControl
    {


        private string b_title;

        public string MP_title
        {
            get { return b_title; }
            set
            {
                b_title = value;
                L_title.Text = b_title;
            }
        }

        private string uc_panel_Tag;
        public string UC_Panel_Tag
        {
            set {
                uc_panel_Tag = value;
            }
        }



        private int click_pic;

        public int MP_click_pic
        {
            get { return click_pic; }
            set
            {
                click_pic = value;

                if (click_pic == 1)
                    PB_open_close.ImageLocation = Application.StartupPath + @"\image\16_ico\border grid.ico";
                else PB_open_close.ImageLocation = Application.StartupPath + @"\image\16_ico\borders.ico";
            }
        }

        public UC_panel()
        {
            InitializeComponent();
            this.Click += new EventHandler(titleclick_app);
            PB_open_close.Click += new EventHandler(titleclick_app);
            L_title.Click += new EventHandler(titleclick_app);
        }

        public delegate void titleclickEventHandler(object sender, EventArgs e);
        public event titleclickEventHandler titleclick;

        public void ontitleclick()
        {
            if (this.titleclick != null)
            {
                this.titleclick(this, new EventArgs());
            }
        }
        public void titleclick_app(object sender, EventArgs e)
        {
            ontitleclick();
        }




    }
}
