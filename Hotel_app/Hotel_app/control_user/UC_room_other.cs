using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.control_user
{
    public partial class UC_room_other : UserControl
    {
        public UC_room_other()
        {
            InitializeComponent();
        }

        private void UC_room_other_Resize(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Top;
        }

        //控制Panel1的大小
    }
}
