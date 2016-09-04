using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.control_user
{
    public partial class UC_room_clean : UserControl
    {
        private String roomno;//房号
        public String MP_roomno
        {
            get { return roomno; }
            set
            {
                roomno = value;
                l_roomno.Text = roomno;
            }
        }
        private String room_type;//房型
        public String MP_room_type
        {
            get { return room_type; }
            set
            {
                room_type = value;
                l_room_type.Text = room_type;
            }
        }
        public UC_room_clean()
        {
            InitializeComponent();
        }
    }
}
