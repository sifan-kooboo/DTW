using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace jdgl_res_head_app.common_file
{
   public  static class common_ddbh
    {
        public static string lsm(int cd, int lsmcd)
        {
            string ddbhlsm = "";
            int a = cd;
            if (lsmcd == 2)
            {
                switch (a)
                {
                    case 0: ddbhlsm = "00"; break;
                    case 1: ddbhlsm = "0"; break;
                    default: ddbhlsm = ""; break;
                }
            }
            if (lsmcd == 3)
            {
                switch (a)
                {
                    case 0: ddbhlsm = "000"; break;
                    case 1: ddbhlsm = "00"; break;
                    case 2: ddbhlsm = "0"; break;
                    default: ddbhlsm = ""; break;
                }
            }
            if (lsmcd == 4)
            {
                switch (a)
                {
                    case 0: ddbhlsm = "0000"; break;
                    case 1: ddbhlsm = "000"; break;
                    case 2: ddbhlsm = "00"; break;
                    case 3: ddbhlsm = "0"; break;
                    default: ddbhlsm = ""; break;
                }
            }
            if (lsmcd == 5)
            {
                switch (a)
                {
                    case 0: ddbhlsm = "00000"; break;
                    case 1: ddbhlsm = "0000"; break;
                    case 2: ddbhlsm = "000"; break;
                    case 3: ddbhlsm = "00"; break;
                    case 4: ddbhlsm = "0"; break;
                    default: ddbhlsm = ""; break;

                }
            }

            if (lsmcd == 6)
            {
                switch (a)
                {
                    case 0: ddbhlsm = "000000"; break;
                    case 1: ddbhlsm = "00000"; break;
                    case 2: ddbhlsm = "0000"; break;
                    case 3: ddbhlsm = "000"; break;
                    case 4: ddbhlsm = "00"; break;
                    case 5: ddbhlsm = "0"; break;
                    default: ddbhlsm = ""; break;

                }
            }


            return ddbhlsm;
        }
        //第一种生成订单编号的方法
        public static string ddbh(string bs, string rq, string counter, int lsmcd)
        {
            int a; int c; int id;
            string b = ""; string d = "";
            string ddbhyy = "";
            string counteryy = ""; 
            string rqyy = "";
            string qybh = common_file.common_app.qybh;
            BLL.Common B_Common = new BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Qcounter","id>=0"+common_file.common_app.yydh_select);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                counteryy = DS_temp.Tables[0].Rows[0][counter].ToString();
                rqyy =  DS_temp.Tables[0].Rows[0][rq].ToString();
            }

            if (counteryy == "")
            {
                B_Common.ExecuteSql("update Qcounter set " + rq + "='" + DateTime.Today.ToString() + "'," + counter + "=0 where id>=0" + common_file.common_app.yydh_select);
            }
            else
            {
                if (Convert.ToDateTime( rqyy) == DateTime.Today)
                {
                    c = Convert.ToInt32(counteryy);
                    c = c + 1;
                    B_Common.ExecuteSql("update Qcounter set " + counter + "=" + c.ToString() + " where id>=0" + common_file.common_app.yydh_select);
                }
                else
                {
                    B_Common.ExecuteSql("update Qcounter set " + rq + "='" + DateTime.Today.ToString() + "'," + counter + "=0 where id>=0" + common_file.common_app.yydh_select);
                }

                DS_temp = B_Common.GetList("select * from Qcounter", "id>=0" + common_file.common_app.yydh_select);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    counteryy = DS_temp.Tables[0].Rows[0][counter].ToString();
                    rqyy = DS_temp.Tables[0].Rows[0][rq].ToString();
                }
                a = counteryy.ToString().Length;
                b = lsm(a, lsmcd);
                d = DateTime.Today.Year.ToString();
                if (DateTime.Today.Month.ToString().Length == 1) { d = d + "0"; }
                d = d + DateTime.Today.Month.ToString();
                if (DateTime.Today.Day.ToString().Length == 1) { d = d + "0"; }
                d = d + DateTime.Today.Day.ToString();
                ddbhyy = qybh + bs + d + b + counteryy.ToString();
            }

            DS_temp.Dispose();
            return ddbhyy;
        }
        //第一种生成订单编号的方法







    }
}
