using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Hotel_app.common_file_server
{
    public static class common_fjzt
    {
        public static string gjf = "干净房";
        public static string zf = "脏房";
        public static string wxf = "维修房";
        public static string zzf = "在住房";
        public static string ydf = "预订房";
        public static string qtf = "其他房";
        public static string ff = "换房";
        public static string yjf = "打扫";
        public static string  lszy= "临时占用";


        public static bool Islf(string lsbh)//是否联房
        {
            bool sflf = false;
            BLL.Flfsz B_flfsz = new Hotel_app.BLL.Flfsz();
            DataSet ds = B_flfsz.GetList("lsbh='" + lsbh + "' and shlz=1");

            if (ds.Tables[0].Rows.Count > 0)
            {
                sflf = true;
            }
            else
            {
                sflf = false;
            }

            return sflf;


        }

        public static bool Ists(string lsbh)//是否特殊要求及回头客或黑名单,只要其中一个不为空就要为TRUE
        {
            bool shts = false;
            //Model.Flfsz M_flfsz = new Hotel_app.Model.Flfsz();
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            DataSet ds = B_Qskyd_mainrecord.GetList("(lsbh='" + lsbh + "') and (tsyq<>'' or krrx='" + common_app.krrx_htk + "' or krrx='" + common_app.krrx_hmd + "')");

            if (ds.Tables[0].Rows.Count > 0)
            {
                shts = true;
            }
            else
            {
                shts = false;
            }

            return shts;


        }

        public static bool IsVIP(string lsbh)//是否VIP或会员，只要其中一个不要空就要为TRUE
        {
            bool shvip = false;
            //Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Hotel_app.Model.Qskyd_mainrecord();
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            DataSet ds = B_Qskyd_mainrecord.GetList("(lsbh='" + lsbh + "') and ((hykh<>'' and hyrx<>'') or (vip_type<>''))");
          

           
            if (ds.Tables[0].Rows.Count > 0)
            {
                shvip = true;
            }
            else
            {
                shvip = false;
            }

            return shvip;


        }

        public static bool Isbm(string lsbh)//房价是否保密
        {
            bool sflf = false;
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            DataSet ds = B_Qskyd_fjrb.GetList("lsbh='" + lsbh + "' and fjbm='" + common_app.fjbm_bm + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                sflf = true;
            }
            else
            {
                sflf = false;
            }

            return sflf;


        }



    }

}
