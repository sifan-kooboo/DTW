using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.DBUtility;
using Hotel_app.common_file_server;
using Hotel_app.Qyddj;

namespace Hotel_app.Server.Szwgl
{
    //此类处理记转结，挂转结(如果是批量结账，那么lsbh里面存储新的jzbh)
    public class Szw_jzOrgzToSz
    {
        public string GetjzOrgzToSzResult(string lsbh, string jzbh,string yydh,string czzt, string sk_tt, string czy, string czsj,string syzd,string czy_bc,string fkje,string xfje,string xxzs,string qymc,string czy_GUID)//转结的时候要重新统计出来是total
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            //备份当前lsbh下对应jzzd和jzmx里面的记录到相应的BAK
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into  sjzzd_bak(yydh,qymc,jzbh,jzbh_new,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,ddsj,krxm_lz,fjbh_lz)");
            strsql.Append("  select yydh,qymc,jzbh,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,czzt,fp_print,is_visible,fkje,xfje,ddsj,krxm_lz,fjbh_lz  from  sjzzd");
            strsql.Append("  where  lsbh='" + lsbh + "' and  jzbh='"+jzbh+"'   and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());//备份jzzd--jzzd_bak

            strsql = new StringBuilder();
            strsql.Append("insert into sjzmx_bak(yydh,qymc,is_top,is_select,id_app,jzbh,jzbh_new,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj)");
            strsql.Append(" select yydh,qymc,is_top,is_select,id_app,jzbh,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj  from  sjzmx");
            //strsql.Append(" where  lsbh='" + lsbh + "' and yydh='" + yydh + "' and  jzbh='"+jzbh+"'  and   xfdr!='"+common_file.common_app.fkdr+"'");
            strsql.Append(" where   yydh='" + yydh + "' and  jzbh='" + jzbh + "'  and   xfdr!='" + common_file.common_app.fkdr + "'");
            B_common.ExecuteSql(strsql.ToString());//备份jzmx-jzmx_bak


            
            //将以上记录删除
            strsql = new StringBuilder();
            strsql.Append("delete from Szwmx  where  jzbh='" + jzbh + "'  and yydh='"+yydh+"'  and jzbh<>''  " );
            B_common.ExecuteSql(strsql.ToString());
            strsql = new StringBuilder();

            strsql = new StringBuilder();
            strsql.Append("    insert into Syjcz_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt)");
            strsql.Append("  select  yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt  from  Syjcz");
            strsql.Append(" where jzbh='" + jzbh + "'  and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());


            strsql = new StringBuilder();
            strsql.Append("delete from  Syjcz where  jzbh='" + jzbh + "'  and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());

            //更新结帐主单和结帐明细里面的操作员，操作时间，CZZT的值
            if (czzt != common_app.pljz_flage)
            {
                strsql = new StringBuilder();
                strsql.Append("  insert  into  Sfkfssz(yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
                strsql.Append("  select      yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,'"+DateTime.Parse(czsj).ToShortDateString()+"','"+czsj+"',xfrq,xfsj,czy,czy_bc,syzd,id_app from Sjzmx");
                strsql.Append("   where  id>=0 and yydh='" + yydh + "' and  xfrb='" + common_app.dj_ysk + "'  and  jzbh='"+jzbh+"'");
                B_common.ExecuteSql(strsql.ToString());

                strsql = new StringBuilder();
                strsql.Append("update  sjzzd  set  czzt='" + czzt + "',czsj='" + czsj + "',czy='" + czy + "',syzd='" + syzd + "',fkje='" + fkje + "',xfje='" + xfje + "',bz=''  where  jzbh='" + jzbh + "'  and yydh='" + yydh + "'");

                if (B_common.ExecuteSql(strsql.ToString()) >= 0)
                {
                    strsql = new StringBuilder();
                    strsql.Append("update sjzmx set czzt='" + czzt + "',czsj='" + czsj + "',czy='" + czy + "',syzd='" + syzd + "',czy_bc='" + czy_bc + "'  where  jzbh='" + jzbh + "'  and yydh='" + yydh + "'");
                    if (B_common.ExecuteSql(strsql.ToString()) >= 0)
                    {
                        s = common_file.common_app.get_suc;
                    }
                }
            }
            if(czzt.Equals(common_app.pljz_flage))
            {
                strsql = new StringBuilder();
                strsql.Append(" delete from Sjzzd where jzbh='" + jzbh + "'");
                B_common.ExecuteSql(strsql.ToString());

                //此时的LSBH存储着新的jzbh
                strsql = new StringBuilder();
                strsql.Append("update sjzmx set czzt='" + common_jzzt.czzt_gzzsz + "',czsj='" + czsj + "',czy='" + czy + "',syzd='" + syzd + "',czy_bc='" + czy_bc + "',jzbh='"+lsbh+"'  where  jzbh='" + jzbh + "'  and yydh='" + yydh + "'");
                B_common.ExecuteSql(strsql.ToString());

                strsql = new StringBuilder();
                strsql.Append("update Ssyxfmx set czsj='" + czsj + "',czy='" + czy + "',jzbh='" + lsbh + "'  where  jzbh='" + jzbh + "'  and yydh='" + yydh + "'");
                B_common.ExecuteSql(strsql.ToString());
                s = common_file.common_app.get_suc;
            }
            common_file.common_czjl.add_czjl(yydh,qymc,czy, lsbh + "下的帐务当前执行"+czzt+"结算的金额为:"+fkje+"当前的消费总金额为:"+xfje,czzt, czzt+"的结果为:" + s, DateTime.Now);
            return s;
        }
    }
}
