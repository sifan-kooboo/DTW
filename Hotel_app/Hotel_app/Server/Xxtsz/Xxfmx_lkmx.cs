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
    public class Xxfmx_lkmx
    {
        //id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfmx,mxbh,xfsl,shsc
        	//id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfxr,xfmx,mxbh,xfsl,shsc
        public string Xxfmx_lkmx_add_edit(string id, string yydh, string qymc,string lsbh,string lksj,string czsj,string czy,string bz, string drbh, string xfdr, string xrbh,string xfxr,string xfmx,string mxbh, string xfsl,string xftm,string add_edit_delete, string xxzs,string dj)
        {


            string s = common_file.common_app.get_failure;
            BLL.Xxfmx_lkmx B_Xxfmx_lkmx = new Hotel_app.BLL.Xxfmx_lkmx();
            Model.Xxfmx_lkmx M_Xxfmx_lkmx = new Hotel_app.Model.Xxfmx_lkmx();
           
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xxfmx_lkmx.yydh = yydh;
                M_Xxfmx_lkmx.qymc = qymc;
                M_Xxfmx_lkmx.drbh = drbh;
                M_Xxfmx_lkmx.xfdr = xfdr;
                M_Xxfmx_lkmx.xrbh = xrbh;
                M_Xxfmx_lkmx.mxbh = mxbh;
                M_Xxfmx_lkmx.xfmx = xfmx;
                M_Xxfmx_lkmx.bz = bz;
                M_Xxfmx_lkmx.czsj = Convert.ToDateTime(czsj);
                M_Xxfmx_lkmx.czy = czy;
                M_Xxfmx_lkmx.lksj = Convert.ToDateTime(lksj);
                M_Xxfmx_lkmx.lsbh = lsbh;
                M_Xxfmx_lkmx.xfsl = Get_lksl(mxbh,xfsl,lsbh);
                M_Xxfmx_lkmx.xfxr = xfxr;
                M_Xxfmx_lkmx.xftm = xftm;

                decimal dj_0 = 0;
                try
                {
                    dj_0 = decimal.Parse(dj);
                }
                catch
                {
                    dj_0 = 0;
                }
                M_Xxfmx_lkmx.jjdj = dj_0;
                M_Xxfmx_lkmx.Total_cb = Get_lksl(mxbh, xfsl, lsbh) * dj_0;

                if (B_Xxfmx_lkmx.Add(M_Xxfmx_lkmx) > 0)
                {   

                    s = common_file.common_app.get_suc;
                }
            }
            else
            {
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xxfmx_lkmx = B_Xxfmx_lkmx.GetModel(Convert.ToInt32(id));
                    M_Xxfmx_lkmx.yydh = yydh;
                    M_Xxfmx_lkmx.qymc = qymc;
                    M_Xxfmx_lkmx.drbh = drbh;
                    M_Xxfmx_lkmx.xfdr = xfdr;
                    M_Xxfmx_lkmx.xrbh = xrbh;
                    M_Xxfmx_lkmx.mxbh = mxbh;
                    M_Xxfmx_lkmx.xfmx = xfmx;
                    M_Xxfmx_lkmx.bz = bz;
                    M_Xxfmx_lkmx.czsj = Convert.ToDateTime(czsj);
                    M_Xxfmx_lkmx.czy = czy;
                    M_Xxfmx_lkmx.lksj = Convert.ToDateTime(lksj);
                    M_Xxfmx_lkmx.lsbh = lsbh;
                    M_Xxfmx_lkmx.xfsl =decimal.Parse(xfsl);// Get_lksl(mxbh, xfsl, lsbh);
                    M_Xxfmx_lkmx.xfxr = xfxr;
                    M_Xxfmx_lkmx.xftm = xftm;
                    M_Xxfmx_lkmx.id = int.Parse(id);
                    if (B_Xxfmx_lkmx.Update(M_Xxfmx_lkmx))
                    {

                        s = common_file.common_app.get_suc;
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            //Update_xfmx_kcsl_add(mxbh, Convert.ToDecimal(xfsl));
                            B_Xxfmx_lkmx.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            }
            return s;
        }
        public static decimal Get_lksl(string xrbh,string lksl,string lsbh)
        {
            BLL.Common B_Common = new BLL.Common();
            decimal xfsl = 0;
            decimal xfsl_01 = 0;
            decimal sumxfsl = 0;
            DataSet ds = B_Common.GetList("select * from Xxfmx_lkmx", "mxbh='" + xrbh + "' and lsbh='"+lsbh+"'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                xfsl = Convert.ToDecimal(ds.Tables[0].Rows[0]["xfsl"].ToString());
                if (lksl != null && lksl != "")
                {

                    xfsl_01 = Convert.ToDecimal(lksl);
                    sumxfsl = xfsl + xfsl_01;
                   // Update_xfmx_kcsl(xrbh, xfsl_01);//更新xfmx里的kcsl
                }

            }
            else
            {
                sumxfsl = Convert.ToDecimal(lksl);
                //Update_xfmx_kcsl(xrbh, sumxfsl);//更新xfmx里的kcsl
            }
            return sumxfsl;

        }
        
       
    }
}
