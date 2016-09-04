using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Qyddj
{
    public class Q_tt_unit
    {
        public string tt_unit(string yydh,string qymc,string czy,DateTime czsj,string lsbh_old,string ddbh_old,string lsbh_add,string ddbh_add,string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string czbz = "";
            string czzy = "";
            DataSet DS_temp = B_Common.GetList("select * from Qttyd_mainrecord","lsbh='"+lsbh_old+"'");
            DataSet DS_temp_0 = B_Common.GetList("select * from Qttyd_mainrecord", "lsbh='" + lsbh_add + "'");
            if ((DS_temp != null && DS_temp.Tables[0].Rows.Count > 0) && (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0))
            {
                czbz = DS_temp.Tables[0].Rows[0]["krxm"].ToString() + " 合并到 " + DS_temp_0.Tables[0].Rows[0]["krxm"].ToString();
                czzy = DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + " 合并到 " + DS_temp_0.Tables[0].Rows[0]["lsbh"].ToString(); 

                DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "lsbh='" + lsbh_old + "' and fjrb in(select fjrb from Qskyd_fjrb where lsbh='" + lsbh_add + "')");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {
                        B_Common.ExecuteSql("update Qskyd_fjrb set lzfs=lzfs+'" + DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString() + "' where lsbh='" + lsbh_add + "' and fjrb='" + DS_temp.Tables[0].Rows[i_0]["fjrb"].ToString() + "'");
                    }

                }

                DS_temp = B_Common.GetList("select * from Szwzd", "lsbh='" + lsbh_old + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {

                    B_Common.ExecuteSql("update Szwzd set fkje=fkje+'" + DS_temp.Tables[0].Rows[0]["fkje"].ToString() + "',xfje=xfje+'" + DS_temp.Tables[0].Rows[0]["xfje"].ToString() + "' where lsbh='" + lsbh_add + "'");

                }
                B_Common.ExecuteSql("update Qskyd_fjrb set lsbh='" + lsbh_add + "' where lsbh='" + lsbh_old + "' and fjrb  not in(select fjrb from Qskyd_fjrb where lsbh='" + lsbh_add + "')");
                B_Common.ExecuteSql("delete from Qskyd_fjrb  where lsbh='" + lsbh_old + "'");
                B_Common.ExecuteSql("update Qskyd_mainrecord set ddbh='" + ddbh_add + "' where ddbh='" + ddbh_old + "'");
                B_Common.ExecuteSql("update Szwmx set lsbh='" + lsbh_add + "' where lsbh='"+lsbh_old+"'");
                B_Common.ExecuteSql("update Syjcz set lsbh='" + lsbh_add + "' where lsbh='" + lsbh_old + "'");
                B_Common.ExecuteSql("update Ssyxfmx set lsbh='" + lsbh_add + "' where lsbh='" + lsbh_old + "'");
                B_Common.ExecuteSql("delete from Qttyd_mainrecord  where lsbh='" + lsbh_old + "'");
                B_Common.ExecuteSql("delete from Qyddj_otherfee  where lsbh='" + lsbh_old + "'");
                B_Common.ExecuteSql("delete from Szwzd  where lsbh='" + lsbh_old + "'");
            }

            DS_temp.Clear();
            DS_temp.Dispose();
            DS_temp_0.Clear();
            DS_temp_0.Dispose();
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "团队合并", czzy, czbz, czsj);
            get_result = common_file.common_app.get_suc;
            return get_result;
        }
    }
}
