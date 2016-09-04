using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.control_user
{
    public partial class UC_roompic_title : UserControl
    {
        private string b_title;

        public string MP_title
        {
            get { return b_title; }
            set
            {
                b_title = value;
                l_title.Text = b_title;
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
                    pB_click.ImageLocation = Application.StartupPath + @"\16_ico\border grid.ico";
                else pB_click.ImageLocation = Application.StartupPath + @"\16_ico\borders.ico";
            }
        }


        public UC_roompic_title()
        {
            InitializeComponent();
        }

        public   delegate   void   newpBclick(object   sender,   System.EventArgs   e);
        public event newpBclick OnnewpBclick;



        private void pB_click_Click(object sender, EventArgs e)
        {
            if (OnnewpBclick != null)
            {
                OnnewpBclick(this, e);//这里引发事件，这个事件可以在UserControl的事件列表中找 
                //到并在使用UserControl的地方如窗体里使用。 
            }

        }




        private void UC_roompic_title_DoubleClick(object sender, EventArgs e)
        {
            if (click_pic == 1)
            {
                click_pic = 0;
                pB_click.ImageLocation = Application.StartupPath + @"\16_ico\border grid.ico";
            }
            else
            {
                click_pic = 1;
                pB_click.ImageLocation = Application.StartupPath + @"\16_ico\borders.ico";
            }
        }



    }
}
