using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.control_user
{
    //这个用于加载精简单界面风格
    public partial class UC_room_pic_1 : UserControl
    {
        public UC_room_pic_1()
        {
            InitializeComponent();
        }

        private int room_state;//房间状态

        public int MP_room_state
        {
            get { return room_state; }
            set
            {
                room_state = value;
                int i = room_state;
                switch (i)
                {
                    case 0://0空房
                        p_range.BackColor = Color.White;
                        //p_buttom.BackColor = Color.White;
                        //pB_head.Visible = false;
                        break;
                    case 1://1干净房
                        p_range.BackColor = Color.White;// Color.DarkGreen;
                        //p_buttom.BackColor = Color.White;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 11://11干净预订
                        p_range.BackColor = Color.White;
                        //p_buttom.BackColor = Color.LightSalmon;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ico";
                        break;
                    case 2://2脏房
                        p_range.BackColor = Color.DimGray;
                        //p_buttom.BackColor = Color.DimGray;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 21://21脏房预订
                        p_range.BackColor = Color.DimGray;
                        //p_buttom.BackColor = Color.LightSalmon;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ico";
                        break;
                    case 3://3维修房
                        p_range.BackColor = Color.IndianRed;
                        //p_buttom.BackColor = Color.IndianRed;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 31://31维修预订
                        p_range.BackColor = Color.Firebrick;
                        //p_buttom.BackColor = Color.LightSalmon;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ico";
                        break;
                    case 4://4其他房
                        p_range.BackColor = Color.DarkGoldenrod;
                        //p_buttom.BackColor = Color.DarkGoldenrod;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 5://5在住房
                        p_range.BackColor = Color.MediumPurple;
                        //p_buttom.BackColor = Color.MediumPurple;
                        //string icoName = "a-4.ico";
                        //if (!MP_roomno.Equals("") && !MP_room_type.Equals(""))
                        //{
                        //    icoName = common_file.common_app.GetIco(MP_roomno, MP_room_type);
                        //}
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\" + icoName;
                        break;
                    case 51://51在住预订
                        p_range.BackColor = Color.MediumPurple;
                        //p_buttom.BackColor = Color.LightSalmon;
                        //string icoName_1 = "a-4.ico";
                        //if (!MP_roomno.Equals("") && !MP_room_type.Equals(""))
                        //{
                        //    icoName_1 = common_file.common_app.GetIco(MP_roomno, MP_room_type);
                        //}
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\" + icoName_1;
                        break;


                }
            }
        }

    }
}
