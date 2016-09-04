using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;

namespace Hotel_app.Server.BBfx
{
    public class B_dsfx
    {
        //代收的报表
        //统计代收(分为结账代收以及未结代收,其中结账代收为：xxx结账退房,部分结账;未结代收分记账，挂账，记账转挂账，挂账转记账
        public string ds_fx(string yydh, string qymc, string  cssj, string  jssj,string czsj,string czy_temp,string xxzs)
        {
            string s = common_file.common_app.get_suc;
            BLL.Common  B_Common=new Hotel_app.BLL.Common();  
            DbHelperSQL.ExecuteSql(" delete from  BB_dsfx_temp  where  czy_temp='"+czy_temp+"'");
            
            DataSet DS_temp_1 = B_Common.GetList("select xfxr from Xxfxr", " xfdr='" + Szwgl.common_zw.dr_ds + "'");

            if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
            {
                DataSet DS_temp_0 = B_Common.GetList("select xfrb,sum(sjxfje) as sjxfje from VS_syxfmx_cz", "  xfdr='" + Szwgl.common_zw.dr_ds + "'  and   xfsj>='" + cssj + "'  and  xfsj<='" + jssj + "'   and xfrb in(select xfxr from Xxfxr  where  xfdr='" + Szwgl.common_zw.dr_ds + "') group by xfrb");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (int k_0 = 0; k_0 < DS_temp_0.Tables[0].Rows.Count; k_0++)
                    {
                        //小类
                        string sss = "  insert into  BB_dsfx_temp( qymc,yydh,dsdr,je,czy_temp) values('" + qymc + "','" + yydh + "','" + DS_temp_0.Tables[0].Rows[k_0]["xfrb"].ToString() + "'," + float.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString()) + ",'" + czy_temp + "'";
                        DbHelperSQL.ExecuteSql("  insert into  BB_dsfx_temp( qymc,yydh,dsdr,je,czy_temp) values('" + qymc + "','" + yydh + "','" + DS_temp_0.Tables[0].Rows[k_0]["xfrb"].ToString() + "'," +float.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString())+ ",'" + czy_temp + "')");
                        //小类未结
                        DataSet ds_temp_2 = B_Common.GetList(" select sum(sjxfje) as sjxfje from VS_syxfmx_cz ", " xfdr='" + Szwgl.common_zw.dr_ds + "' and  xfrb='" + DS_temp_0.Tables[0].Rows[k_0]["xfrb"].ToString() + "'  and   xfsj>='" + cssj + "'  and  xfsj<='" + jssj + "'  and jzbh=''  ");
                        if (ds_temp_2 != null && ds_temp_2.Tables[0].Rows.Count > 0)
                        {
                            DbHelperSQL.ExecuteSql("  insert into  BB_dsfx_temp( qymc,yydh,dsdr,je,czy_temp ) values('" + qymc + "','" + yydh + "','" + "      未结','" + ds_temp_2.Tables[0].Rows[0]["sjxfje"].ToString() + "','" + czy_temp + "')");
                        }
                        DataSet ds_temp_3 = B_Common.GetList(" select sum(sjxfje) as sjxfje from VS_syxfmx_cz ", " xfdr='" + Szwgl.common_zw.dr_ds + "' and  xfrb='" + DS_temp_0.Tables[0].Rows[k_0]["xfrb"].ToString() + "'  and   xfsj>='" + cssj + "'  and  xfsj<='" + jssj + "'  and jzbh!=''  ");
                        if (ds_temp_3 != null && ds_temp_3.Tables[0].Rows.Count > 0)
                        {
                            DbHelperSQL.ExecuteSql("  insert into  BB_dsfx_temp( qymc,yydh,dsdr,je,czy_temp ) values('" + qymc + "','" + yydh + "','" + "      以结','" + ds_temp_3.Tables[0].Rows[0]["sjxfje"].ToString() + "','" + czy_temp + "')");
                        }
                        //小类以结
                    }
                }
                s = common_file.common_app.get_suc;
            }
            else
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }
    }
}
