using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.control_user
{
    public partial class UC_room_pic_0 : UserControl
    {
        private int room_state;//房间状态
        string gj_colorName = "Lime";// common_file.Common_initalSystem.ReadXML("add", "gjf");
        string zf_colorName ="LightSlateGray"; //common_file.Common_initalSystem.ReadXML("add", "zf");
        string zzf_colorName = "MediumPurple"; //common_file.Common_initalSystem.ReadXML("add", "zzf");
        string wxf_colorName ="Black"; //common_file.Common_initalSystem.ReadXML("add", "wxf");
        string qt_colorName = "Orange"; //common_file.Common_initalSystem.ReadXML("add", "qtf");
        string yd_colorName ="Pink"; //common_file.Common_initalSystem.ReadXML("add", "yd");
        string kryl_colorName ="MediumSlateBlue"; //common_file.Common_initalSystem.ReadXML("add", "kryl");

        //图片
        string hy_PicName = "";
        string krrx_PicName = "";
        string bz_colorName = "";
        string gz_PicName = ""; 
        string zf_PicName = ""; 
        string zzf_PicName = ""; 
        string wxf_PicName = ""; 
        string qt_PicName = "";

        public int MP_room_state
        {
            
            get { return room_state; }
            set
            {
                room_state = value;
                int i = room_state;
                if (i != 3)
                {
                    l_room_type.ForeColor = Color.Black;
                    l_roomno.ForeColor = Color.Black;
                }

                switch (i)
                {
                    case 0://0空房
                        p_range.BackColor = Color.FromName(gj_colorName);
                        p_buttom.BackColor = Color.FromName(gj_colorName);
                        pB_head.Visible = false;
                        break;
                    case 1://1干净房
                        p_range.BackColor = Color.FromName(gj_colorName);
                        p_buttom.BackColor = Color.FromName(gj_colorName);
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 11://11干净预订
                        p_range.BackColor = Color.FromName(gj_colorName);
                        p_buttom.BackColor = Color.FromName(yd_colorName);
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ico";
                        break;
                    case 2://2脏房
                        p_range.BackColor = Color.FromName(zf_colorName);
                        p_buttom.BackColor = Color.FromName(zf_colorName);
                        pB_room_clean.Visible = false;
                        pB_head.Visible = false;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 21://21脏房预订
                        p_range.BackColor = Color.FromName(zf_colorName);
                        p_buttom.BackColor = Color.FromName(yd_colorName);
                        pB_head.Visible = false;
                        pB_room_clean.Visible = false;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ico";
                        break;
                    case 3://3维修房
                        p_range.BackColor = Color.FromName(wxf_colorName);
                        p_buttom.BackColor = Color.FromName(wxf_colorName);
                        l_roomno.ForeColor = Color.White; l_room_type.ForeColor = Color.White;
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 31://31维修预订
                        p_range.BackColor = Color.FromName(wxf_colorName);
                        p_buttom.BackColor = Color.FromName(yd_colorName);
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ico";
                        break;
                    case 4://4其他房
                        p_range.BackColor = Color.FromName(qt_colorName);
                        p_buttom.BackColor = Color.FromName(qt_colorName);
                        //pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\occup_0.ICO";
                        break;
                    case 5://5在住房
                        p_range.BackColor = Color.FromName(zzf_colorName);
                        p_buttom.BackColor = Color.FromName(zzf_colorName);
                        string icoName = "a-4.ico";
                        if (!MP_roomno.Equals("") && !MP_room_type.Equals(""))
                        {
                            icoName = common_file.common_app.GetIco(MP_roomno, MP_room_type);
                        }
                        if (!icoName.Equals(""))
                        {
                            pB_head.Visible = true;
                            pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\" + icoName;
                        }
                        else
                        {
                            pB_head.Visible = false;
                        }
                        break;
                    case 51://51在住预订
                        p_range.BackColor = Color.FromName(zzf_colorName);
                        p_buttom.BackColor = Color.FromName(yd_colorName);
                        string icoName_1 = "a-4.ico";
                        if (!MP_roomno.Equals("") && !MP_room_type.Equals(""))
                        {
                            icoName_1 = common_file.common_app.GetIco(MP_roomno, MP_room_type);
                        }
                        pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\" + icoName_1;
                        break;


                }
            }
        }


        private int ls_zy;
        public int MP_lszy
        {
            get { return ls_zy; }
            set 
            {
                ls_zy = value;
                if (ls_zy == 1)
                {
                    p_range.BackColor = Color.Teal;

                }
                else
                    if (ls_zy == 0)
                    {
                        p_range.BackColor = Color.Teal;
                    }
            
            }
        
        }


        private int Border_select;//边框颜色，1处于没被选择状态-黑色，2处于选择状态-红色；

        public int MP_Border_select
        {
            get { return Border_select; }
            set
            {
                Border_select = value;
                if (Border_select == 1)
                {
                    this.BackColor = Color.Black;

                }
                else
                    if (Border_select == 2)
                    {
                        this.BackColor = Color.Red;
                    }
            }
        }


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

        private string guestname;//客人名称

        public string MP_guestname
        {
            get { return guestname; }
            set
            {
                guestname = value;
                l_guestname.Text = guestname;
            }
        }

        private string i_g_m_l_c; //用来判断入住、预订房间的占用类型-散客、团体、会议、长住、钟点     

        public string MP_i_g_m_l_c
        {
            get { return i_g_m_l_c; }
            set
            {
                i_g_m_l_c = value;
                l_i_g_m_l_c.Text = i_g_m_l_c;
            }
        }

        private string charge;//房费

        public string MP_charge
        {
            get { return charge; }
            set
            {
                charge = value;
                l_charge.Text = charge;
                if (l_charge.Text.Trim() == "") { l_moneysignal.Visible = false; }
                else { l_moneysignal.Visible = true; }
            }
        }

        private int room_clean;//判断是否出现已洁房,1显示，其余显示为灰块

        public int MP_room_clean
        {
            get { return room_clean; }
            set
            {
                room_clean = value;
                if (room_clean == 1)
                { pB_room_clean.Visible = true; }
                else { pB_room_clean.Visible = false; }
            }
        }


        private int room_special;//判断是否出现特殊要求房,1显示，其余不显示

        public int MP_room_special
        {
            get { return room_special; }
            set
            {
                room_special = value;
                //if (room_special == 1)
                //{ pB_room_special.Visible = true; }
                //else { pB_room_special.Visible = false; }
                pB_room_special.Visible = false;
            }
        }


        private int arrival;//判断是否出现预抵房,1显示，其余不显示

        public int MP_arrival
        {
            get { return arrival; }
            set
            {
                arrival = value;
                if (arrival == 1)
                { pB_arrival.Visible = true; }
                else { pB_arrival.Visible = false; }
            }
        }

        private int leaving;//判断是否出现预离房,1显示，2显示超期，其余不显示

        public int MP_leaving
        {
            get { return leaving; }
            set
            {
                leaving = value;
                if (leaving == 1)
                {
                    //pB_leaving.ImageLocation = Application.StartupPath + @"\image\16_ico\room_right.ico";
                    pB_leaving.BackColor = Color.DarkTurquoise;
                    pB_leaving.Visible = true;
                }
                else
                    if (leaving == 2)
                    {
                        pB_leaving.BackColor = Color.Transparent;
                        pB_leaving.ImageLocation = Application.StartupPath + @"\image\NewsIco\d-2.ico";
                        pB_leaving.Visible = true;
                    }
                    else
                    { pB_leaving.Visible = false; }
            }
        }


        private int room_union;//判断是否出现联房,1显示，其余不显示

        public int MP_room_union
        {
            get { return room_union; }
            set
            {
                room_union = value;
                if (room_union == 1)
                { pB_room_union.Visible = true; }
                else { pB_room_union.Visible = false; }
            }
        }

        public string uc_tag;//标识为uc

        public string MP_uc_tag
        {
            set
            {
                uc_tag = value;
            }
        }


        private int room_VIP;//判断是否出现VIP、回头客,1显示，其余不显示

        public int MP_room_VIP
        {
            get { return room_VIP; }
            set
            {
                room_VIP = value;
                if (room_VIP == 1)
                { pB_room_VIP.Visible = true; }
                else { pB_room_VIP.Visible = false; }
            }
        }


        private bool  is_Visible;//所处的行
        public bool Is_Visible
        {
            get { return is_Visible; }
            set
            {
                is_Visible = value;
            }
        }


        public UC_room_pic_0()
        {
            InitializeComponent();
            ///mouseDown事件
            this.MouseDown += new MouseEventHandler(MouseDown_0_app);
            p_range.MouseDown += new MouseEventHandler(MouseDown_0_app);
            l_i_g_m_l_c.MouseDown += new MouseEventHandler(MouseDown_0_app);
            l_guestname.MouseDown += new MouseEventHandler(MouseDown_0_app);
            l_room_type.MouseDown += new MouseEventHandler(MouseDown_0_app);
            l_roomno.MouseDown += new MouseEventHandler(MouseDown_0_app);
            p_buttom.MouseDown += new MouseEventHandler(MouseDown_0_app);
            l_moneysignal.MouseDown += new MouseEventHandler(MouseDown_0_app);
            pB_room_clean.MouseDown += new MouseEventHandler(MouseDown_0_app);
            pB_room_special.MouseDown += new MouseEventHandler(MouseDown_0_app);
            pB_arrival.MouseDown += new MouseEventHandler(MouseDown_0_app);
            pB_room_union.MouseDown += new MouseEventHandler(MouseDown_0_app);
            pB_room_VIP.MouseDown += new MouseEventHandler(MouseDown_0_app);
            pB_leaving.MouseDown += new MouseEventHandler(MouseDown_0_app);
            l_charge.MouseDown += new MouseEventHandler(MouseDown_0_app);
            pB_head.MouseDown += new MouseEventHandler(MouseDown_0_app);

            ///DoubleClick事件
            this.DoubleClick += new EventHandler(DoubleClick_0_app);
            p_range.DoubleClick += new EventHandler(DoubleClick_0_app);
            l_i_g_m_l_c.DoubleClick += new EventHandler(DoubleClick_0_app);
            l_guestname.DoubleClick += new EventHandler(DoubleClick_0_app);
            l_room_type.DoubleClick += new EventHandler(DoubleClick_0_app);
            l_roomno.DoubleClick += new EventHandler(DoubleClick_0_app);
            p_buttom.DoubleClick += new EventHandler(DoubleClick_0_app);
            l_moneysignal.DoubleClick += new EventHandler(DoubleClick_0_app);
            pB_room_clean.DoubleClick += new EventHandler(DoubleClick_0_app);
            pB_room_special.DoubleClick += new EventHandler(DoubleClick_0_app);
            pB_arrival.DoubleClick += new EventHandler(DoubleClick_0_app);
            pB_room_union.DoubleClick += new EventHandler(DoubleClick_0_app);
            pB_room_VIP.DoubleClick += new EventHandler(DoubleClick_0_app);
            pB_leaving.DoubleClick += new EventHandler(DoubleClick_0_app);
            l_charge.DoubleClick += new EventHandler(DoubleClick_0_app);
            pB_head.DoubleClick += new EventHandler(DoubleClick_0_app);


            ///MouseHover事件
            ///
            this.MouseHover += new EventHandler(MouseHover_0_app);
            p_range.MouseHover += new EventHandler(MouseHover_0_app);
            l_i_g_m_l_c.MouseHover += new EventHandler(MouseHover_0_app);
            l_guestname.MouseHover += new EventHandler(MouseHover_0_app);
            l_room_type.MouseHover += new EventHandler(MouseHover_0_app);
            l_roomno.MouseHover += new EventHandler(MouseHover_0_app);
            p_buttom.MouseHover += new EventHandler(MouseHover_0_app);
            l_moneysignal.MouseHover += new EventHandler(MouseHover_0_app);
            pB_room_clean.MouseHover += new EventHandler(MouseHover_0_app);
            pB_room_special.MouseHover += new EventHandler(MouseHover_0_app);
            pB_arrival.MouseHover += new EventHandler(MouseHover_0_app);
            pB_room_union.MouseHover += new EventHandler(MouseHover_0_app);
            pB_room_VIP.MouseHover += new EventHandler(MouseHover_0_app);
            pB_leaving.MouseHover += new EventHandler(MouseHover_0_app);
            l_charge.MouseHover += new EventHandler(MouseHover_0_app);
            pB_head.MouseHover += new EventHandler(MouseHover_0_app);

            ///MouseLeave事件
            ///
            this.MouseLeave += new EventHandler(MouseLeave_0_app);
            p_range.MouseLeave += new EventHandler(MouseLeave_0_app);
            l_i_g_m_l_c.MouseLeave += new EventHandler(MouseLeave_0_app);
            l_guestname.MouseLeave += new EventHandler(MouseLeave_0_app);
            l_room_type.MouseLeave += new EventHandler(MouseLeave_0_app);
            l_roomno.MouseLeave += new EventHandler(MouseLeave_0_app);
            p_buttom.MouseLeave += new EventHandler(MouseLeave_0_app);
            l_moneysignal.MouseLeave += new EventHandler(MouseLeave_0_app);
            pB_room_clean.MouseLeave += new EventHandler(MouseLeave_0_app);
            pB_room_special.MouseLeave += new EventHandler(MouseLeave_0_app);
            pB_arrival.MouseLeave += new EventHandler(MouseLeave_0_app);
            pB_room_union.MouseLeave += new EventHandler(MouseLeave_0_app);
            pB_room_VIP.MouseLeave += new EventHandler(MouseLeave_0_app);
            pB_leaving.MouseLeave += new EventHandler(MouseLeave_0_app);
            l_charge.MouseLeave += new EventHandler(MouseLeave_0_app);
            pB_head.MouseLeave += new EventHandler(MouseLeave_0_app);


        }
        /// <summary>
        /// mouseDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void MouseDown_0EventHandler(object sender, MouseEventArgs e);
        public event MouseDown_0EventHandler MouseDown_0;

        public void onMouseDown_0(MouseButtons  ms)
        {
            if (this.MouseDown_0 != null)
            {
                /// 所带参数为临时赋值
                this.MouseDown_0(this, new MouseEventArgs(ms, 1, 1, 1, 1));
            }
        }
        public void MouseDown_0_app(object sender, MouseEventArgs e)
        {
            onMouseDown_0(e.Button);
        }

        /// <summary>
        /// DoubleClick事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DoubleClick_0EventHandler(object sender, EventArgs e);
        public event DoubleClick_0EventHandler DoubleClick_0;

        public void onDoubleClick_0()
        {
            if (this.DoubleClick_0 != null)
            {
                this.DoubleClick_0(this, new EventArgs());
            }

        }
        public void DoubleClick_0_app(object sender, EventArgs e)
        {
            onDoubleClick_0();
        }


        /// <summary>
        /// MouseHover事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public delegate void MouseHover_0EventHandler(object sender, EventArgs e);
        public event MouseHover_0EventHandler MouseHover_0;

        public void onMouseHover_0()
        {
            if (this.MouseHover_0 != null)
            {
                this.MouseHover_0(this, new EventArgs());
            }

        }
        public void MouseHover_0_app(object sender, EventArgs e)
        {
            onMouseHover_0();
        }



        /// <summary>
        /// MouseLeave事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void MouseLeave_0EventHandler(object sender, EventArgs e);
        public event MouseLeave_0EventHandler MouseLeave_0;

        public void onMouseLeave_0()
        {
            if (this.MouseLeave_0 != null)
            {
                this.MouseLeave_0(this, new EventArgs());
            }

        }
        public void MouseLeave_0_app(object sender, EventArgs e)
        {
            onMouseLeave_0();
        }

        private void UC_room_pic_0_Resize(object sender, EventArgs e)
        {
            p_range.Dock = DockStyle.Fill;
        }

    }
}
