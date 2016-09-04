using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public static class common_Ffjzt
    {
        public static void add_wx_yd()
        {
            string cssj = DateTime.Now.ToShortDateString();
            string jssj = DateTime.Now.ToShortDateString() + " 23:59:59";
            string shlf = "0";
            string shts = "0";
            string shvip = "0";
            string fjbm = "0";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Fwx_other", " (ddsj between '" + cssj + "' and '" + jssj + "') and fjbh<>''");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    B_Common.ExecuteSql("update Ffjzt set zyzt='" + DS_temp.Tables[0].Rows[i_0]["zyzt"].ToString() + "',ddsj='" + DS_temp.Tables[0].Rows[i_0]["ddsj"].ToString() + "',lksj='" + DS_temp.Tables[0].Rows[i_0]["lksj"].ToString() + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + DS_temp.Tables[0].Rows[i_0]["fjbh"].ToString() + "' and zyzt <>'" + common_file.common_fjzt.zzf + "' and zyzt<>'" + DS_temp.Tables[0].Rows[i_0]["zyzt"].ToString()+ "'");
                }
            }
            DataSet DS_temp_0 = B_Common.GetList("select * from Qskyd_fjrb", " (ddsj between '" + cssj + "' and '" + jssj + "') and fjbh<>'' and yddj='" + common_file.common_yddj.yddj_yd + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                {
                    shvip = "0"; shlf = "0"; shvip = "0";
                    if (B_Common.ExecuteSql("update Ffjzt set zyzt_second='" + common_file.common_fjzt.ydf + "',yd_ddsj='" + DS_temp_0.Tables[0].Rows[i_0]["ddsj"].ToString() + "',yd_lksj='" + DS_temp_0.Tables[0].Rows[i_0]["lksj"].ToString() + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + DS_temp_0.Tables[0].Rows[i_0]["fjbh"].ToString() + "' and zyzt='" + common_file.common_fjzt.zzf + "' and (zyzt_second<>'" + common_file.common_fjzt.ydf + "' and yd_ddsj<>'" + DS_temp_0.Tables[0].Rows[i_0]["ddsj"].ToString() + "' and yd_lksj<>'" + DS_temp_0.Tables[0].Rows[i_0]["lksj"].ToString() + "' ) and   fjbh in (select fjbh from Qskyd_fjrb where id='" + DS_temp_0.Tables[0].Rows[i_0]["id"].ToString() + "' and yddj='" + common_file.common_yddj.yddj_yd + "')") < 1)
                    {
                        DS_temp = B_Common.GetList("select id from Ffjzt", "fjbh='" + DS_temp_0.Tables[0].Rows[i_0]["fjbh"].ToString() + "' and zyzt<>'" + common_file.common_fjzt.zzf + "' and zyzt_second<>'" + common_file.common_fjzt.ydf + "' ");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            if (common_file.common_fjzt.IsVIP(DS_temp_0.Tables[0].Rows[i_0]["lsbh"].ToString()) == true)
                            { shvip = "1"; }
                            if (common_file.common_fjzt.Islf(DS_temp_0.Tables[0].Rows[i_0]["lsbh"].ToString()) == true)
                            { shlf = "1"; }
                            if (common_file.common_fjzt.Ists(DS_temp_0.Tables[0].Rows[i_0]["lsbh"].ToString()) == true)
                            { shts = "1"; }
                            if (common_file.common_fjzt.Isbm(DS_temp_0.Tables[0].Rows[i_0]["lsbh"].ToString()) == true)
                            { fjbm = "1"; }
                            B_Common.ExecuteSql("update Ffjzt set zyzt_second='" + common_file.common_fjzt.ydf + "',yd_ddsj='" + DS_temp_0.Tables[0].Rows[i_0]["ddsj"].ToString() + "',yd_lksj='" + DS_temp_0.Tables[0].Rows[i_0]["lksj"].ToString() + "',krxm='" + DS_temp_0.Tables[0].Rows[i_0]["krxm"].ToString() + "',lsbh='" + DS_temp_0.Tables[0].Rows[i_0]["lsbh"].ToString() + "',sktt='" + DS_temp_0.Tables[0].Rows[i_0]["sktt"].ToString() + "',shts='" + shts + "',shvip='" + shvip + "',shlf='" + shlf + "',fjbm='" + fjbm + "',czsj='" + DateTime.Now.ToString() + "' where id='" + DS_temp.Tables[0].Rows[0]["id"].ToString() + "' and (zyzt_second<>'" + common_file.common_fjzt.ydf + "' and yd_ddsj<>'" + DS_temp_0.Tables[0].Rows[i_0]["ddsj"].ToString() + "' and yd_lksj<>'" + DS_temp_0.Tables[0].Rows[i_0]["lksj"].ToString() + "' ) and   fjbh in (select fjbh from Qskyd_fjrb where id='" + DS_temp_0.Tables[0].Rows[i_0]["id"].ToString() + "' and yddj='" + common_file.common_yddj.yddj_yd + "')");
                        }
                    }
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            DS_temp_0.Clear();
            DS_temp_0.Dispose();
        }

        
       public static string ftfx_bh_wx = "占用包含维修与其他房";
        public static string fsfx_zh_yd = "占用只含预订与在住房";
        //做成外部引用
        public static string fsfx_bh_mr = fsfx_zh_yd;
    }
}
