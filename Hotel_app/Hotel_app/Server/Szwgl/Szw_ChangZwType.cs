using System;
using System.Data;
using System.Configuration;
using System.Text;

namespace Hotel_app.Server.Szwgl
{
    //此类处理  记帐/挂帐的互转
    public class Szw_ChangZwType
    {
        //注意，记/挂的互转要更新jzzt（结帐主体)
        public string Szw_GetChangZwType(string lsbh, string qymc, string yydh,string jzzt, string czy, string syzd, string czsj, string jjType, string xxzs,string jzbh)
        {
            string s = common_file.common_app.get_failure;
            StringBuilder strSql = new StringBuilder();
            BLL.Common B_common = new Hotel_app.BLL.Common();
            string  jjType_afterChange="";
            if (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_gzzjz || jjType == common_file.common_jzzt.czzt_jz || jjType == common_file.common_jzzt.czzt_jzzgz)
            {
                //要更新Szwmx,Sjzzd,Sjzmx里面的结帐状态以及结帐主体
                //备份Sjzzd到BAK
                //strSql = new StringBuilder();
                //strSql.Append("insert into Sjzzd_bak(yydh,qymc,lsbh,jzbh,jzbh_new,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,is_top,is_select,sdcz,fp_print,is_visible)");
                //strSql.Append(" select  yydh,qymc,lsbh,jzbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,is_top,is_select,0,fp_print,is_visible  from Sjzzd");
                //strSql.Append("  Where lsbh='" + lsbh + "'  and  jzbh='"+jzbh+"'  and yydh='" + yydh + "'");
                //B_common.ExecuteSql(strSql.ToString());

                //strSql = new StringBuilder();
                //strSql.Append("insert into  Sjzmx_bak(yydh,qymc,id_app,jzbh,jzbh_new,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,mxbh)");
                //strSql.Append("  select  yydh,qymc,id_app,jzbh,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,mxbh  from Sjzmx  ");
                //strSql.Append("  where  lsbh='" + lsbh + "'  and  jzbh='"+jzbh+"'  and   yydh='" + yydh + "'");
                //B_common.ExecuteSql(strSql.ToString());

                jjType_afterChange = ((jjType == common_file.common_jzzt.czzt_jz||jjType == common_file.common_jzzt.czzt_gzzjz) ? common_file.common_jzzt.czzt_jzzgz : common_file.common_jzzt.czzt_gzzjz);

                //更新以上三张表的信息,注意，记转挂时(要更新xydw,xyh，挂帐转记帐时，要把xydw,xyh放空,针对Sjzzd)
                if (jjType_afterChange == common_file.common_jzzt.czzt_jzzgz)
                {
                    //备注:20120726更新(这里选择不更改xydw，保留原来的xydw是为了说明, 记挂互转时,账务是从哪个xydw转过来的)
                    string xyh_temp = common_zw.GetxyhByxydw(jzzt, yydh);
                    strSql = new StringBuilder();
                    //strSql.Append(" update  Sjzzd  Set  czzt='" + jjType_afterChange + "',  jzzt='" + jzzt + "',shsc=0,xydw='"+jzzt+"',xyh='"+xyh_temp+"',czsj='"+czsj+"'   where lsbh='" + lsbh + "'  and  jzbh='"+jzbh+"'  and yydh='" + yydh + "'");
                    strSql.Append(" update  Sjzzd  Set  czzt='" + jjType_afterChange + "',  jzzt='" + jzzt + "',shsc=0,xyh='" + xyh_temp + "',czsj='" + czsj + "',czy='"+czy+"'   where lsbh='" + lsbh + "'  and  jzbh='" + jzbh + "'  and yydh='" + yydh + "'");
                    B_common.ExecuteSql(strSql.ToString());
                }
                if (jjType_afterChange == common_file.common_jzzt.czzt_gzzjz)
                {
                    jzzt = "";
                    DataSet ds_temp = B_common.GetList(" select * from Sjzzd ", " id>=0  and yydh='" + yydh + "'  and lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        jzzt = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                    }
                    //备注:20120726更新(这里选择不更改xydw，保留原来的xydw是为了说明, 记挂互转时,账务是从哪个xydw转过来的)
                   // strSql.Append(" update  Sjzzd  Set  czzt='" + jjType_afterChange + "',  jzzt='" + jzzt + "',shsc=0,xydw='',xyh='',czsj='"+czsj+"'  where lsbh='" + lsbh + "'     and  jzbh='" + jzbh + "'   and yydh='" + yydh + "'");
                    strSql.Append(" update  Sjzzd  Set  czzt='" + jjType_afterChange + "',  jzzt='" + jzzt + "',shsc=0,xydw='',xyh='',czsj='" + czsj + "',czy='"+czy+"'   where lsbh='" + lsbh + "'     and  jzbh='" + jzbh + "'   and yydh='" + yydh + "'");
                    B_common.ExecuteSql(strSql.ToString());
                }

                //更新押金的状态
                strSql = new StringBuilder();
                if (jjType_afterChange == common_file.common_jzzt.czzt_gzzjz)
                {
                    strSql.Append(" update  Sjzmx  Set  czzt='" + jjType_afterChange + "',  jzzt='" + jzzt + "',shsc=0,xyh='',czsj='"+czsj+"',czy='"+czy+"'   where   jzbh='" + jzbh + "'    and yydh='" + yydh + "'");
                }
                if (jjType_afterChange == common_file.common_jzzt.czzt_jzzgz)
                {
                    string xyh_temp = common_zw.GetxyhByxydw(jzzt, yydh);
                    strSql.Append(" update  Sjzmx  Set  czzt='" + jjType_afterChange + "',  jzzt='" + jzzt + "',shsc=0,xyh='"+xyh_temp+"',czsj='"+czsj+"',czy='"+czy+"'   where   jzbh='" + jzbh + "'    and yydh='" + yydh + "'");
                }

                B_common.ExecuteSql(strSql.ToString());
                strSql = new StringBuilder();
                if (jjType_afterChange == common_file.common_jzzt.czzt_gzzjz)
                {
                    strSql.Append(" update  Szwmx  Set  czzt='" + jjType_afterChange + "',shsc=0,czsj='" + czsj + "',czy='" + czy + "'   where   jzbh='" + jzbh + "'    and yydh='" + yydh + "'");
                }
                if (jjType_afterChange == common_file.common_jzzt.czzt_jzzgz)
                {
                    string xyh_temp = common_zw.GetxyhByxydw(jzzt, yydh);
                    strSql.Append(" update  Szwmx  Set  czzt='" + jjType_afterChange + "',shsc=0,czsj='" + czsj + "',czy='" + czy + "'   where   jzbh='" + jzbh + "'    and yydh='" + yydh + "'");
                }
                B_common.ExecuteSql(strSql.ToString());

                B_common.ExecuteSql("  update  Syjcz  set  czzt='" + jjType_afterChange + "'  where  jzbh='" + jzbh + "'");

                common_file.common_czjl.add_czjl(yydh, qymc, czy, jjType_afterChange, "记挂互转", "记挂互转", DateTime.Parse(czsj.ToString()));
                s = common_file.common_app.get_suc;
            }
            return s;
        }
    }
}
