using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public static class common_get_fjjg
    {
        //public static string get_fjjg(string fjrb,string krly,DateTime ddsj,DateTime lksj,string hyrx)
        public static string get_fjjg(string fjrb, string krly, string xyh, DateTime ddsj, DateTime lksj,string hykh,string hyrx)
        {
            string fjjg = "0";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Ffjrb", " fjrb='" + fjrb + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                fjjg = DS_temp.Tables[0].Rows[0]["sjjg"].ToString();
            }
            if (hykh != "" && hyrx != "")
            {
                DS_temp = B_Common.GetList("select * from Hhyfj", "fjrb='"+fjrb+"' and hyrx='"+hyrx+"'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    fjjg = DS_temp.Tables[0].Rows[0]["hyfj"].ToString();

                }
            }
            else
            {
                if (xyh != "")
                {
                    DS_temp = B_Common.GetList("select * from Yxydw_fjrb", "xyh='" + xyh + "' and fjrb='" + fjrb + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        fjjg = DS_temp.Tables[0].Rows[0]["sjjg"].ToString();

                    }
                    else
                    {
                        DS_temp = B_Common.GetList("select * from Ffjrb_krly", "krly='" + common_xydw.krly_xydw + "' and fjrb='" + fjrb + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            fjjg = DS_temp.Tables[0].Rows[0]["sjjg"].ToString();
                        }

                    }
                }
            }
            DS_temp.Dispose();
            return fjjg;
        }
    }
}
