using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.BBfx
{
    public static class common_bb
    {
        //这三个值用来判断报表分析哪一种类型时使用这个一定要在表里有相对应的字段名称才可以
        public static string xsy_krly_xydw_xsy = "xsy";
        public static string xsy_krly_xydw_krly = "krly";
        public static string xsy_krly_xydw_xydw = "xydw";
        public static string xsy_krly_xydw_pq = "pq";
        public static string xsy_krly_xydw_krgj = "krgj";
        public static string xsy_krly_xydw_gj_sf = "gj_sf";
        public static string xsy_krly_xydw_gj_cs = "gj_cs";




        public static string gz_type = "gz";
        public static string jz_type = "jz";

        public static int pddate(int yy, int mm, int ts)
        {
            int dd = 1;
            switch (mm)
            {
                case 2:
                    if (yy % 4 == 0)
                    {
                        dd = 29 - ts;
                    }
                    else
                    {
                        dd = 28 - ts;
                    }
                    break;
                case 4:
                    dd = 30 - ts;
                    break;
                case 6:
                    dd = 30 - ts;
                    break;
                case 9:
                    dd = 30 - ts;
                    break;
                case 11:
                    dd = 30 - ts;
                    break;
                default:
                    dd = 31 - ts;
                    break;
            }
            return dd;

        }

        public static DateTime judge_yfcssj(DateTime drrq, int tzts)
        {

            int yy0 = 200; int mm0 = 1; int dd0 = 1;
            yy0 = drrq.Year;
            mm0 = drrq.Month;
            dd0 = drrq.Day;
            int jsdate = 1;
            int csdate = 1;
            if (tzts > 0)
            {
                tzts = tzts - 1;
                if (mm0 == 1)
                {
                    if (dd0 < (31 - tzts))
                    {
                        jsdate = 1;
                    }
                    else
                    {
                        jsdate = 31 - tzts;
                    }
                }
                else
                {
                    csdate = pddate(yy0, mm0, tzts);
                    if ((dd0 >= csdate) && (mm0 != 12))
                    {
                        jsdate = pddate(yy0, mm0, tzts);
                    }

                    if ((dd0 < csdate) || (mm0 == 12))
                    {
                        if (mm0 != 1)
                        {
                            mm0 = mm0 - 1;
                            jsdate = pddate(yy0, mm0, tzts);
                        }
                    }
                }
            }
            else
                if (tzts == 0)
                {
                    jsdate = 1;
                }
                else if (tzts < 0)
                {
                    if (mm0 == 1)
                    { jsdate = 1; }
                    else
                    {
                        jsdate = 0 - tzts + 1;
                        if (dd0 + tzts <= 0)
                        { mm0 = mm0 - 1; }
                    }

                }
            DateTime result_date = DateTime.Parse(yy0.ToString() + "-" + mm0.ToString() + "-" + jsdate.ToString());
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Xqyxx", "id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["xtyysj"].ToString() != "")
                {
                    if (result_date < DateTime.Parse(DS_temp.Tables[0].Rows[0]["xtyysj"].ToString()))
                    {
                        result_date = DateTime.Parse(DS_temp.Tables[0].Rows[0]["xtyysj"].ToString());
                    }
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            return result_date;
        }

        public static int get_zfs()
        {
            int zfs = 1;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select id from Ffjzt", "id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs = DS_temp.Tables[0].Rows.Count;
            }
            DS_temp = B_Common.GetList("select tjkffs from Qcounter", "id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (int.Parse(DS_temp.Tables[0].Rows[0]["tjkffs"].ToString()) > 0)
                {
                    zfs = zfs - int.Parse(DS_temp.Tables[0].Rows[0]["tjkffs"].ToString());
                }
            }
            if (zfs < 1)
            { zfs = 1; }
            DS_temp.Clear();
            DS_temp.Dispose();
            return zfs;
        }
    }
}
