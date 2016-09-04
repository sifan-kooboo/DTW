using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Hotel_app.common_file
{
   public static class Common_lk
    {
       //id,yydh,qymc,lsbh,lksj,czsj,czy,bz,drbh,xfdr,xrbh,xfxr,xfmx,mxbh,xfsl,shsc
       public static void Getmxbh(string mxbh,string xftm, out string drbh, out string xfdr, out string xrbh, out string xfxr, out string xfmx,out string xftm_temp,out string mxbh_temp)
       {
           string s_0 = "";
           drbh = ""; xfdr = ""; xrbh = ""; xfxr = ""; xfmx = ""; xftm_temp = ""; mxbh_temp = "";
           BLL.Common B_Common = new Hotel_app.BLL.Common();
           if (xftm.Trim() != "")
           { 
               s_0 = " xftm='" + xftm + "'"; 
           }
           else 
           {
               s_0 = " mxbh='" + mxbh + "'"; 
 
           }
           DataSet DS_temp = B_Common.GetList("select * from Xxfmx",s_0);
           if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
           {
               drbh = DS_temp.Tables[0].Rows[0]["drbh"].ToString();
               xfdr = DS_temp.Tables[0].Rows[0]["xfdr"].ToString();
               xrbh = DS_temp.Tables[0].Rows[0]["xrbh"].ToString();
               xfxr = DS_temp.Tables[0].Rows[0]["xfxr"].ToString();
               xfmx = DS_temp.Tables[0].Rows[0]["xfmx"].ToString();
               xftm_temp = DS_temp.Tables[0].Rows[0]["xftm"].ToString();
               mxbh_temp = DS_temp.Tables[0].Rows[0]["mxbh"].ToString();
         

               
           }
           DS_temp.Dispose();
       }


       public static void Get_xf_info(string xrbh, string xfxm_temp, out string xfdr, out string xfrb, out string mxbh, out string xftm,out string xfxm)
       {
           xfdr = ""; xfrb = ""; mxbh = ""; xfxm = ""; string s_0 = ""; xftm="";
           BLL.Common B_Common = new Hotel_app.BLL.Common();
           if (xfxm_temp.Trim() != "")
           { s_0 = "  and  xfmx='" + xfxm_temp + "'"; }
           DataSet DS_temp = B_Common.GetList("select * from Xxfmx", "xrbh='" + xrbh + "'" + s_0);
           if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
           {
               xfdr = DS_temp.Tables[0].Rows[0]["xfdr"].ToString();
               xfrb = DS_temp.Tables[0].Rows[0]["xfxr"].ToString();
               //xfje = decimal.Parse(DS_temp.Tables[0].Rows[0]["xfje"].ToString());
               //jjje = decimal.Parse(DS_temp.Tables[0].Rows[0]["jjje"].ToString());
               xfxm = DS_temp.Tables[0].Rows[0]["xfmx"].ToString();
               mxbh = DS_temp.Tables[0].Rows[0]["mxbh"].ToString();
               xftm = DS_temp.Tables[0].Rows[0]["xftm"].ToString();
           }
           DS_temp.Dispose();

       }

    }
}
