using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.common_file_server
{

        public static class common_get_fjjg
        {
            //public static string get_fjjg(string fjrb,string krly,DateTime ddsj,DateTime lksj,string hyrx)
            public static string get_fjjg(string fjrb)
            {
                string fjjg = "0";
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select * from Ffjrb", " fjrb='" + fjrb + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    fjjg = DS_temp.Tables[0].Rows[0]["sjjg"].ToString();
                }
                return fjjg;
            }
        }

}
