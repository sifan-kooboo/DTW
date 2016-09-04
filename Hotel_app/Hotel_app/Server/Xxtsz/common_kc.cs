using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Xxtsz
{
    public static  class common_kc
    {
        //日的成本单价来源于当月的初期成本
        public static string kc_rx_qc_r = "日期初";
        public static string kc_rx_rc_r = "日入库";
        public static string kc_rx_ck_r = "日出库";
        public static string kc_rx_tz_r = "日调整";
        public static string kc_rx_qm_r = "日期末";

        
        public static string kc_rx_qc_y = "月期初";
        public static string kc_rx_rc_y = "月入库";
        public static string kc_rx_ck_y = "月出库";
        public static string kc_rx_tz_y = "月调整";
        public static string kc_rx_qm_y = "月期末";


        public static string kc_cbtj_r = "日统计查询";
        public static string kc_cbtj_y = "月统计查询";
    }
}
