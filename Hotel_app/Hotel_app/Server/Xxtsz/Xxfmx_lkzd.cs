using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
namespace Hotel_app.Server.Xxtsz
{
    public class Xxfmx_lkzd
    {
        //id,yydh,qymc,lsbh,czy,lksj,shsc,sh_sh,lknr,bz,sh_czy
        public string Xxfmx_lkzd_add_edit(string id, string yydh, string qymc, string lsbh, string czy, string lksj, bool sh_sh, string lknr, string bz, string sh_czy, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Xxfmx_lkzd B_Xxfmx_lkzd = new Hotel_app.BLL.Xxfmx_lkzd();
            Model.Xxfmx_lkzd M_Xxfmx_lkzd = new Hotel_app.Model.Xxfmx_lkzd();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xxfmx_lkzd.yydh = yydh;
                M_Xxfmx_lkzd.qymc = qymc;
                M_Xxfmx_lkzd.lsbh = lsbh;
                M_Xxfmx_lkzd.czy = czy;
                M_Xxfmx_lkzd.lksj = Convert.ToDateTime(lksj);
                M_Xxfmx_lkzd.sh_sh =sh_sh;
                M_Xxfmx_lkzd.sh_czy = sh_czy;
                M_Xxfmx_lkzd.lknr = lknr;
                M_Xxfmx_lkzd.bz = bz;
   

                if (B_Xxfmx_lkzd.Add(M_Xxfmx_lkzd) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xxfmx_lkzd.yydh = yydh;
                    M_Xxfmx_lkzd.qymc = qymc;
                    M_Xxfmx_lkzd.lsbh = lsbh;
                    M_Xxfmx_lkzd.czy = czy;
                    M_Xxfmx_lkzd.lksj = Convert.ToDateTime(lksj);
                    M_Xxfmx_lkzd.sh_sh = sh_sh;
                    M_Xxfmx_lkzd.sh_czy = sh_czy;
                    M_Xxfmx_lkzd.lknr = lknr;
                    M_Xxfmx_lkzd.bz = bz;
                    M_Xxfmx_lkzd.id = int.Parse(id);
                    if (B_Xxfmx_lkzd.Update(M_Xxfmx_lkzd))
                    {

                        s = common_file.common_app.get_suc;
                    }
                    if (sh_sh)
                    {
                        Update_kcsl(lsbh, add_edit_delete);
 
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            //Update_kcsl(lsbh, add_edit_delete);
                            B_Xxfmx_lkzd.Delete(Convert.ToInt32(id));
                            Delete_xfmx_lkmx(lsbh);//删除lsbh相同的入库名细
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }

        public string Update_lkzd_issh(string lsbh, string sh_czy)
        {
            string s = common_file.common_app.get_failure;
            string strSql_01 = "update Xxfmx_lkzd set sh_sh=1,sh_czy='" + sh_czy + "' where lsbh='" + lsbh + "'";
            int i = DbHelperSQL.ExecuteSql(strSql_01);
            if (i >= 0)
            {

                Update_kcsl(lsbh, common_file.common_app.get_edit);
                s = common_file.common_app.get_suc;

            }

            return s;

        }
        public static void Update_kcsl(string lsbh,string type)
        {
             BLL.Common B_Common = new BLL.Common();
             DataSet ds = B_Common.GetList("select * from Xxfmx_lkmx", "lsbh='" + lsbh + "'");
             if (ds != null && ds.Tables[0].Rows.Count > 0)
             {
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                     string strmxbh = ds.Tables[0].Rows[i]["mxbh"].ToString();
                     decimal strxfsl = Convert.ToDecimal(ds.Tables[0].Rows[i]["xfsl"].ToString());
                     if (type == common_file.common_app.get_delete)
                     {
                         //Delete_xfmx_kcsl(strmxbh, strxfsl);
                        

                     }
                     else
                     {
                         Update_xfmx_kcsl(strmxbh, strxfsl); ;//更新
                     }
                 }
 
             }

 
        }
        
        public static void Update_xfmx_kcsl(string mxbh, decimal lksl)
        {
            int kcsl = 0;
            BLL.Common B_Common = new BLL.Common();
            DataSet ds = B_Common.GetList("select * from Xxfmx", "mxbh='" + mxbh + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                kcsl = Convert.ToInt32(ds.Tables[0].Rows[0]["kcsl"].ToString());
                decimal sumxfsl_01 = kcsl + lksl;
                string strSql_01 = "update Xxfmx set kcsl=" + sumxfsl_01 + " where mxbh='" + mxbh + "'";
                DbHelperSQL.ExecuteSql(strSql_01);
            }
            

        }
        //删除主单时Xxfmx要-
        public static void Delete_xfmx_kcsl(string mxbh, decimal lksl)
        {
            int kcsl = 0;
            BLL.Common B_Common = new BLL.Common();
            DataSet ds = B_Common.GetList("select * from Xxfmx", "mxbh='" + mxbh + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                kcsl = Convert.ToInt32(ds.Tables[0].Rows[0]["kcsl"].ToString());
                decimal sumxfsl_01 = kcsl-lksl;
                string strSql_01 = "update Xxfmx set kcsl=" + sumxfsl_01 + " where mxbh='" + mxbh + "'";
                DbHelperSQL.ExecuteSql(strSql_01);
            }


        }
        //同时删除主单名细下的记录
        public static void Delete_xfmx_lkmx(string lsbh)
        {
            string strSql_01 = "delete Xxfmx_lkmx  where lsbh='" + lsbh + "'";
            DbHelperSQL.ExecuteSql(strSql_01);

        }

       
    }
}
