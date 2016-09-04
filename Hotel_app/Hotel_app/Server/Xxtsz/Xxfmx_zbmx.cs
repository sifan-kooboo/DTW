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
    public class Xxfmx_zbmx
    {
        //id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfmx,mxbh,zb_sl,shsc
        	//id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfxr,xfmx,mxbh,zb_sl,shsc
        public string Xxfmx_zbmx_add_edit(string id, string yydh, string qymc, string lsbh, string drbh, string xfdr, string xrbh, string xfxr, string xfmx, string mxbh, string xftm, string zb_sj, string zb_czy, string zb_sl, string zb_zt, string add_edit_delete, string xxzs,string dj)
        {

            //id,yydh,qymc,lsbh,drbh,xfdr,xrbh,xfxr,xftm,xfmx,mxbh,zb_sl,zb_zt,zb_sj,zb_czy,shsc
            string s = common_file.common_app.get_failure;
            BLL.Xxfmx_zbmx B_Xxfmx_zbmx = new Hotel_app.BLL.Xxfmx_zbmx();
            Model.Xxfmx_zbmx M_Xxfmx_zbmx = new Hotel_app.Model.Xxfmx_zbmx();
            decimal strzbsl = Get_lksl(mxbh, zb_sl, lsbh);
            string strzbzt = common_file.common_app.zb_zt_kj;
            if (strzbsl > 0)
            {
                strzbzt = common_file.common_app.zb_zt_zj;
 
            }
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xxfmx_zbmx.yydh = yydh;
                M_Xxfmx_zbmx.qymc = qymc;
                M_Xxfmx_zbmx.lsbh = lsbh;
                M_Xxfmx_zbmx.drbh = drbh;
                M_Xxfmx_zbmx.xfdr = xfdr;
                M_Xxfmx_zbmx.xrbh = xrbh;
                M_Xxfmx_zbmx.mxbh = mxbh;
                M_Xxfmx_zbmx.xfmx = xfmx;
                M_Xxfmx_zbmx.zb_czy = zb_czy;
                M_Xxfmx_zbmx.zb_sj = Convert.ToDateTime(zb_sj);
                M_Xxfmx_zbmx.zb_sl = strzbsl;
                M_Xxfmx_zbmx.zb_zt = strzbzt;
                M_Xxfmx_zbmx.xfxr = xfxr;
                M_Xxfmx_zbmx.xftm = xftm;


                decimal dj_0 = 0;
                try
                {
                    dj_0 = decimal.Parse(dj);
                }
                catch
                {
                    dj_0 = 0;
                }
                M_Xxfmx_zbmx.zb_jjje = dj_0;
                M_Xxfmx_zbmx.zb_Total_cb = strzbsl * dj_0;


                if (B_Xxfmx_zbmx.Add(M_Xxfmx_zbmx) > 0)
                {
                    
                    s = common_file.common_app.get_suc;
                }
            }
            else
            {
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xxfmx_zbmx = B_Xxfmx_zbmx.GetModel(Convert.ToInt32(id));
                    M_Xxfmx_zbmx.yydh = yydh;
                    M_Xxfmx_zbmx.qymc = qymc;
                    M_Xxfmx_zbmx.lsbh = lsbh;
                    M_Xxfmx_zbmx.drbh = drbh;
                    M_Xxfmx_zbmx.xfdr = xfdr;
                    M_Xxfmx_zbmx.xrbh = xrbh;
                    M_Xxfmx_zbmx.mxbh = mxbh;
                    M_Xxfmx_zbmx.xfmx = xfmx;
                    M_Xxfmx_zbmx.zb_czy = zb_czy;
                    M_Xxfmx_zbmx.zb_sj = Convert.ToDateTime(zb_sj);
                    M_Xxfmx_zbmx.zb_sl = strzbsl;
                    M_Xxfmx_zbmx.zb_zt = strzbzt;
                    M_Xxfmx_zbmx.xfxr = xfxr;
                    M_Xxfmx_zbmx.xftm = xftm;
                    M_Xxfmx_zbmx.id = int.Parse(id);
                    if (B_Xxfmx_zbmx.Update(M_Xxfmx_zbmx))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            //Update_xfmx_kcsl_add(mxbh, Convert.ToDecimal(zb_sl));
                            B_Xxfmx_zbmx.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            }
            return s;
        }
        public static decimal Get_lksl(string mxbh,string lksl,string lsbh)
        {
            BLL.Common B_Common = new BLL.Common();
            decimal zb_sl = 0;
            decimal zb_sl_01 = 0;
            decimal sumzb_sl = 0;
            DataSet ds = B_Common.GetList("select * from Xxfmx_zbmx", "mxbh='" + mxbh + "' and lsbh='"+lsbh+"'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                zb_sl = Convert.ToDecimal(ds.Tables[0].Rows[0]["zb_sl"].ToString());
                if (lksl != null && lksl != "")
                {

                    zb_sl_01 = Convert.ToDecimal(lksl);
                    sumzb_sl = zb_sl + zb_sl_01;
                }

            }
            else
            {
                sumzb_sl = Convert.ToDecimal(lksl);
                
            }
            
            return sumzb_sl;

        }
       
      
       
    }
}
