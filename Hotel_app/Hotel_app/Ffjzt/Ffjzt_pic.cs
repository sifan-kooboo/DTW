using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjzt_pic : Form
    {
        public Ffjzt_pic()
        {
            InitializeComponent();
        }
       // public void canceal_panel(object sender, EventArgs e)
        //common_file.My_eventArgs temp = new Hotel_app.common_file.My_eventArgs(Panel1);

        public void canceal_panel(object sender,EventArgs e)
        {
            Hotel_app.control_user.UC_panel temp = (Hotel_app.control_user.UC_panel)sender;
            if (temp != null)
            { common_file.common_app.Message_box_show(common_file.common_app.message_title,temp.Name.ToString()); }
            foreach (Control temp_control in p_pic.Controls)
            {
                
                Panel p = new Panel();
                if((temp_control as Panel)!=null)
                {
                    p = (Panel)temp_control;
                    if (p.Name.ToString() == "p_A1B3")
                    {
                        if (p.Visible == false) { p.Visible = true; }
                        else if (p.Visible == true ) { p.Visible = false ; }
                        break;
                    }
                }
                
            }
            //p_A1B3.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            uC_A1B3.titleclick += new Hotel_app.control_user.UC_panel.titleclickEventHandler(canceal_panel);
        }

        private void Ffjzt_pic_Load(object sender, EventArgs e)
        {

        }

        private void uC_room_clean3_Load(object sender, EventArgs e)
        {

        }


    }
}