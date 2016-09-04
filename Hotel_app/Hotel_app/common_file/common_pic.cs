using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.common_file
{
    public  class common_pic
    {

        #region   old_sl_w_h_function
        ////public static int big_horizon_NO = 9;//大图的房间数量
        //public static int big_horizon_NO = int.Parse(Common_initalSystem.ReadNameValueSectionValue("ft_info", "big_horizon_NO"));

        ////public static int big_pic_space = 3;//图片间的间隔
        //public static int big_pic_space = int.Parse(Common_initalSystem.ReadNameValueSectionValue("ft_info", "big_pic_space"));

        ////public static int big_pic_height = 95;//图片间的高度
        //public static int big_pic_height = int.Parse(Common_initalSystem.ReadNameValueSectionValue("ft_info", "big_pic_height"));

        ////public static int big_pic_width = 86;//图片间的宽度_
        //public static int big_pic_width = int.Parse(Common_initalSystem.ReadNameValueSectionValue("ft_info", "big_pic_width"));
        
        #endregion

        #region new_sl_w_h_function
        //big_horizon_NO= int.Parse(Common_initalSystem     "ft_info", "big_horizon_NO"));
        #endregion
        public   string jdlh_select = "";//作为酒店楼号的其余选择条件，例设定默认楼号（and jdlh in(select jdlh from ***)）；
        public   string jdcs_select = "";//作为酒店楼层的其余选择条件，例设定默认楼号（and jdcs in(select jdcs from ***)）；


        public    int big_horizon_NO = int.Parse(Common_initalSystem.ReadXML("add", "big_horizon_NO"));
        public    int big_pic_space = int.Parse(Common_initalSystem.ReadXML("add", "big_pic_space"));
        public   int big_pic_height = int.Parse(Common_initalSystem.ReadXML("add", "big_pic_height"));
        public   int big_pic_width = int.Parse(Common_initalSystem.ReadXML("add", "big_pic_width"));



    }
}
