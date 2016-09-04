using System;
using System.Data;
using System.Configuration;
using Maticsoft.DBUtility;
using Hotel_app.common_file;
using System.Collections.Generic;
namespace Hotel_app.Server.Szwgl
{

    //挂账批结
    public class Szw_gzpj
    {
        //针对用金额批结的传一个jzbh_过来,标识最后一个有部分结的)
        public string Fun_gzpj(string jzzt,string jzbh_last, string jzType,string yydh, string qymc, string czy, string syzd,string czy_bc, string czsj, string xxzs,string  czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            DataSet ds_temp = null;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.Collections.Generic.List<string>  lists=new System.Collections.Generic.List<string>();
            string lsbh_new= common_file.common_ddbh.ddbh("gzpj", "lsbhdate", "lsbhcounter", 6);//生成新的lsbh
            string jzbh_new = common_file.common_ddbh.ddbh("gzpj", "jzdate", "jzcounter", 6);//算帐操作
            string xyh_temp = common_zw.GetxyhByxydw(jzzt, yydh);
            string temp = "";
            BLL.Common B_common = new Hotel_app.BLL.Common();

            string xyh = common_zw.GetxyhByxydw(jzzt, yydh);
            //通过Szw_temp中以czy_guid选择出来的记录
            //比对每一个jzbh下面的Szwmx与czy_guid选择出来的记录的，如果全部相同，则说明该jzbh下的所有记录都有选择，那么这笔就要完全结清
            List<string> list_selectAll=new List<string>();
            List<string> list_selectSub = new List<string>();
            //如果不是完全选择，那么  统计这条jzbh下面的消费与付款情况
            ds_temp = B_common.GetList(" select  distinct jzbh from Szw_temp", "id>=0  and czy_temp='" + czy_GUID + "'  and  jzbh!='' ");
            if (ds_temp != null && ds_temp.Tables.Count > 0 && ds_temp.Tables[0].Rows.Count > 0)
            {
                //定义两个数组
                foreach (DataRow dr in ds_temp.Tables[0].Rows)
                {
                    string jzbh_tmp = dr["jzbh"].ToString();
                    if (CheckSelectAll(jzbh_tmp))
                    { list_selectAll.Add(jzbh_tmp); }
                    else
                    {
                        list_selectSub.Add(jzbh_tmp);
                    }
                }
            }
            string czsj_jzsj = DateTime.Now.ToString();
            decimal fkje = Math.Abs(decimal.Parse(DbHelperSQL.GetSingle("select  ISNull(sum(sjxfje),0) from Szw_temp where  czy_temp='" + czy_GUID + "'  and  xfdr='" + common_file.common_app.fkdr + "'").ToString()));
            decimal xfje = Math.Abs(decimal.Parse(DbHelperSQL.GetSingle("select  ISNull(sum(sjxfje),0) from Szw_temp where  czy_temp='" + czy_GUID + "'  and  xfdr!='" + common_file.common_app.fkdr + "'").ToString()));
            #region 以前的
            //if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            //{
            //    //依据lsbh找到jzbh
            //    for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
            //    {
            //        DataSet ds_temp1 = B_common.GetList(" select  jzbh  from Szw_temp ", "id>=0  and czy_temp='" + czy + "'  and lsbh='" + ds_temp.Tables[0].Rows[i]["lsbh"].ToString() + "'");
            //        lists.Add(ds_temp.Tables[0].Rows[i]["lsbh"].ToString() + "|" + ds_temp1.Tables[0].Rows[0]["jzbh"].ToString());
            //    }

            //    if (lists.Count > 0)
            //    {
            //        //写入新的jzzd
            //        sb = new System.Text.StringBuilder();
            //        sb.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje)");
            //        sb.Append(" select  yydh,qymc,'" + lsbh_new + "','" + jzbh_new + "','','','',xyh,xydw,'',tfsj,'" + czsj + "','" + czy + "','" + common_file.common_jzzt.czzt_gzzsz + "','" + jzzt + "','" + syzd + "',''," + fkje + "," + xfje + "  from Sjzzd");
            //        sb.Append(" where  czy='" + czy + "'  and  lsbh='" + lists[0].Split('|')[0].ToString() + "' and jzbh='" + lists[0].Split('|')[1].ToString() + "'");
            //        temp = sb.ToString();
            //        B_common.ExecuteSql(sb.ToString());
            //        if (lists.Count > 0)
            //        {
            //            foreach (string lsbh_jzbh in lists)
            //            {
            //                string lsbh_0 = lsbh_jzbh.Split('|')[0].ToString();
            //                string jzbh_0 = lsbh_jzbh.Split('|')[1].ToString();
            //                //备份sjzzd
            //                sb = new System.Text.StringBuilder();
            //                sb.Append("insert into Sjzzd_bak(yydh,qymc,lsbh,jzbh,jzbh_new,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,is_top,is_select,fp_print,is_visible,sdcz)");
            //                sb.Append(" select  yydh,qymc,lsbh,jzbh,'" + jzbh_new + "',krxm,sktt,fjbh,xyh,jzzt,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,0,0,fp_print,is_visible,sdcz  from Sjzzd");
            //                sb.Append("  Where lsbh='" + lsbh_0 + "'  and yydh='" + yydh + "'   and  jzbh='" + jzbh_0 + "' ");
            //                temp = sb.ToString();
            //                B_common.ExecuteSql(sb.ToString());
            //                B_common.ExecuteSql(" delete from Sjzzd where  lsbh='" + lsbh_0 + "'  and yydh='" + yydh + "'   and  jzbh='" + jzbh_0 + "' ");

            //                //备份Sjzmx
            //                sb = new System.Text.StringBuilder();
            //                sb.Append("insert into  Sjzmx_bak(yydh,qymc,id_app,jzbh,jzbh_new,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,shsc,mxbh,tfsj)");
            //                sb.Append("  select  yydh,qymc,id_app,jzbh,'" + jzbh_new + "',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,shsc,mxbh,tfsj  from Sjzmx  ");
            //                sb.Append("  where  lsbh='" + lsbh_0 + "' and   yydh='" + yydh + "'  and id_app  in (select id_app  from Szw_temp  where lsbh='" + lsbh_0 + "'  and yydh='" + yydh + "' and czy_temp='" + czy + "'  and  xfdr!='" + common_file.common_app.fkdr + "') ");
            //                B_common.ExecuteSql(sb.ToString());

            //                sb = new System.Text.StringBuilder();
            //                //sb.Append("  update  Sjzmx  set  jzbh='" + jzbh_new + "'  where  lsbh='" + lsbh_0 + "' and   yydh='" + yydh + "'  and id_app  in (select id_app  from Szw_temp  where lsbh='" + lsbh_0 + "'  and yydh='" + yydh + "' and czy='" + czy + "'  and  xfdr!='" + common_file.common_app.fkdr + "') ");
            //                sb.Append("  update  Sjzmx  set  jzbh='" + jzbh_new + "',czzt='" + common_file.common_jzzt.czzt_gzzsz + "',czsj='"+czsj+"'  where  lsbh='" + lsbh_0 + "' and   yydh='" + yydh + "'  and id_app  in (select id_app  from Szw_temp  where lsbh='" + lsbh_0 + "'  and yydh='" + yydh + "' and czy_temp='" + czy + "')");
            //                B_common.ExecuteSql(sb.ToString());

            //                sb = new System.Text.StringBuilder();
            //                sb.Append("  insert into  Sfkfssz(yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,xfrq,xfsj,czrq,czsj,czy,czy_bc,syzd,id_app)");
            //                sb.Append("  select  yydh,qymc,is_top,is_select,'" + jzbh_new + "','" + jzzt + "',lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,xfrq,xfsj,'" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "',czy,czy_bc,syzd,id_app from Syjcz");
            //                sb.Append(" where  id_app  in (select id_app  from  Szw_temp  where  lsbh='" + lsbh_0 + "'  and  jzbh='" + jzbh_0 + "' and czy_temp='" + czy + "')");
            //                temp = sb.ToString();
            //                B_common.ExecuteSql(sb.ToString());


            //                //备份押金
            //                sb = new System.Text.StringBuilder();
            //                sb.Append("    insert into Syjcz_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt)");
            //                sb.Append("  select  yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt   from  Syjcz");
            //                sb.Append(" where  id_app  in (select id_app  from  Szw_temp  where  lsbh='" + lsbh_0 + "'  and  jzbh='" + jzbh_0 + "' and czy_temp='" + czy + "')");
            //                B_common.ExecuteSql(sb.ToString());

            //                //删除押金
            //                sb = new System.Text.StringBuilder();
            //                sb.Append(" delete from Syjcz  where  id_app  in (select id_app  from  Szw_temp  where  lsbh='" + lsbh_0 + "'  and  jzbh='" + jzbh_0 + "' and czy_temp='" + czy + "')");
            //                temp = sb.ToString();
            //                B_common.ExecuteSql(sb.ToString());

            //                //删除Szwmx
            //                sb = new System.Text.StringBuilder();
            //                sb.Append(" delete from Szwmx where id_app in  (select id_app  from  Szw_temp  where  lsbh='" + lsbh_0 + "'  and  jzbh='" + jzbh_0 + "' and czy_temp='" + czy + "')");
            //                temp = sb.ToString();
            //                B_common.ExecuteSql(sb.ToString());

            //                //更新Syxfmx里面的结账编号
            //                sb = new System.Text.StringBuilder();
            //                sb.Append("  update  Ssyxfmx set  jzbh='" + jzbh_new + "',czsj='"+czsj+"'  where  id_app in (select id_app  from  Szw_temp  where  lsbh='" + lsbh_0 + "'  and  jzbh='" + jzbh_0 + "' and czy_temp='" + czy + "')");
            //                temp = sb.ToString();
            //                B_common.ExecuteSql(sb.ToString());
            //            }
            //        }
            //    }

            //}
            //else
            //{
            //    sb = new System.Text.StringBuilder();
            //    sb.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje)");
            //    sb.Append(" select  yydh,qymc,'" + lsbh_new + "','" + jzbh_new + "',krxm,sktt,fjbh,xyh,xydw,'',tfsj,'" + czsj + "','" + czy + "','" + common_file.common_jzzt.czzt_gzzsz + "','" + jzzt + "','" + syzd + "',''," + fkje + "," + xfje + "  from Sjzzd");
            //    sb.Append(" where  jzbh='" + jzbh_last + "' and yydh='" + yydh + "'");
            //    B_common.ExecuteSql(sb.ToString());
            //}
            #endregion


            //增加主单
            sb = new System.Text.StringBuilder();
            sb.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,ddsj,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje)");
            sb.Append(" values('" + yydh + "','" + qymc + "','" + lsbh_new + "','" + jzbh_new + "','" + jzzt + "','','','" + xyh + "','" + jzzt + "','','" + czsj_jzsj + "','" + czsj_jzsj + "','" + czsj_jzsj + "','" + czy + "','" + common_file.common_jzzt.czzt_gzzsz + "','" + jzzt + "','" + syzd + "','" + common_zw.gzpj_flage + "'," + fkje + "," + xfje + ") ");
            B_common.ExecuteSql(sb.ToString());




            //有两种方式处理这些数据
            //a,将选出来的记录生成就的结账主单,更新所有的记录的jzbh后，当成一条新的结账单来进行挂账转结账
            //b.将所有记录分成两种，一种全选的，一种没有全选的.
            foreach (string tmp in  list_selectAll)
            {
                Szw_jzOrgzToSz jgtosz = new Szw_jzOrgzToSz();
                jgtosz.GetjzOrgzToSzResult(jzbh_new,tmp,common_app.yydh,common_app.pljz_flage,"",czy,czsj_jzsj,syzd,czy_bc,"0","0",common_app.xxzs,common_app.qymc,common_app.czy_GUID);
            }
            foreach (string tmp2 in list_selectSub)
            {
                //进行分结
                Szw_jzOrgzOrszToFj jgtoFj = new Szw_jzOrgzOrszToFj();
                jgtoFj.GetjzOrgzOrszToFjResult(jzbh_new, common_app.pljz_flage, "", common_app.czy, czsj_jzsj, common_app.syzd, common_app.czy_bc, "0", "0", common_app.xxzs, common_app.yydh, tmp2, common_app.czy_GUID);
            }

            //将付款统一写入Sfkfssz
            sb = new System.Text.StringBuilder();
            sb.Append("  insert into  Sfkfssz(yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,xfrq,xfsj,czrq,czsj,czy,czy_bc,syzd,id_app)");
            sb.Append("  select  yydh,qymc,is_top,is_select,'" + jzbh_new + "','" + jzzt + "','" + lsbh_new + "','','" + jzzt + "',fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,xfrq,xfsj,'" + czsj_jzsj + "','" + czsj_jzsj + "','" + czy + "','" + czy_bc + "','" + syzd + "',id_app from Szw_temp");
            sb.Append("  where  czy_temp='" + czy_GUID + "'  and  xfdr='" + common_file.common_app.fkdr + "'");
            temp = sb.ToString();
            B_common.ExecuteSql(sb.ToString());

            //将平账收款写入Sjzmx
            sb = new System.Text.StringBuilder();
            sb.Append(" insert into Sjzmx(yydh, qymc, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, jjje, xfje, yh, sjxfje, xfsl, czy_bc, czzt, tfsj, czsj, syzd, xyh, jzzt, fkfs,  mxbh)");
            sb.Append(" select                    yydh, qymc, id_app,'" + jzbh_new + "','" + lsbh_new + "', krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, jjje, xfje, yh, sjxfje, xfsl,'" + czy_bc + "','" + common_jzzt.czzt_gzzsz + "','" + czsj_jzsj + "','" + czsj_jzsj + "','" + syzd + "','" + xyh + "','" + jzzt + "',fkfs,mxbh from  Szw_temp");
            sb.Append("  where  czy_temp='"+czy_GUID+"'  and  xfxm='"+common_app.dj_pzsk+"'");
            B_common.ExecuteSql(sb.ToString());
            //完事后,清除Szw_temp


            #region MyRegion
            

            //if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            //{               
            //    //更新jzmx
            //   sb = new System.Text.StringBuilder();
            //   sb.Append(" update Sjzmx set jzbh='" + jzbh_new + "',czsj='" + czsj + "',czzt='" + common_file.common_jzzt.czzt_gzzsz + "' where id_app in (select id_app from Szw_temp where czy_temp='" + czy_GUID + "' and krxm='" + jzzt + "' and jzbh!='')");
            //   B_common.ExecuteSql(sb.ToString());

            //   sb = new System.Text.StringBuilder();
            //   sb.Append(" update Sjzmx set jzbh='" + jzbh_new + "',czsj='" + czsj + "',czzt='" + common_file.common_jzzt.czzt_gzzsz + "' where id_app in (select id_app from Szw_temp where czy_temp='" + czy_GUID + "' and krxm='" + jzzt + "' and jzbh!='' )");
            //   B_common.ExecuteSql(sb.ToString());

            //   sb = new System.Text.StringBuilder();
            //   sb.Append(" delete from Szwmx where  id_app in (select id_app from Szw_temp where czy_temp='" + czy_GUID + "' and krxm='" + jzzt + "' and jzbh!='' )");
            //   B_common.ExecuteSql(sb.ToString());

            //   for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
            //   {
            //       sb = new System.Text.StringBuilder();
            //       sb.Append(" delete from Sjzzd  where  jzbh='" + ds_temp.Tables[0].Rows[i]["jzbh"].ToString() + "'") ;
            //       B_common.ExecuteSql(sb.ToString());

            //   }

            //   //删除押金.写入sfkfssz

            //   //sb = new System.Text.StringBuilder();
            //   //sb.Append("  insert into  Sfkfssz(yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,xfrq,xfsj,czrq,czsj,czy,czy_bc,syzd,id_app)");
            //   //sb.Append("  select  yydh,qymc,is_top,is_select,'" + jzbh_new + "','" + jzzt + "',lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,xfrq,xfsj,'" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "','"+czy+"','"+czy_bc+"','"+syzd+"',id_app from Syjcz");
            //   //sb.Append(" where  id_app  in (select id_app  from  Szw_temp  where  czy_temp='" + czy + "' and jzzt='" + jzzt + "' and jzbh!=''");
            //   //temp = sb.ToString();
            //   //B_common.ExecuteSql(sb.ToString());

            //   sb = new System.Text.StringBuilder();
            //   sb.Append("    insert into Syjcz_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt)");
            //   sb.Append("  select  yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt   from  Syjcz");
            //   sb.Append(" where  id_app  in (select id_app  from  Szw_temp  where   czy_temp='" + czy_GUID + "' and krxm='" + jzzt + "' and jzbh!='' ) ");
            //   B_common.ExecuteSql(sb.ToString());

            //   //删除押金
            //   sb = new System.Text.StringBuilder();
            //   sb.Append(" delete from Syjcz  where  id_app  in (select id_app  from  Szw_temp  where  czy_temp='" + czy_GUID + "' and krxm='" + jzzt + "' and jzbh!='' )");
            //   temp = sb.ToString();
            //   B_common.ExecuteSql(sb.ToString());


            //}



            //对最后一个lsbh对应的记录做分结处理
            //if (jzbh_last != "")
            //{
            //    DataSet ds_temp_0 = B_common.GetList(" select * from Szw_temp ", " jzbh='" + jzbh_last + "' and czy_temp='" + czy_GUID + "'");
            //    if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
            //    {
            //        decimal xfje_bf = decimal.Parse(DbHelperSQL.GetSingle("select sum(sjxfje) from Szw_temp  where   jzbh='" + jzbh_last + "' and czy_temp='" + czy_GUID + "'").ToString());


            //        //处理主单
            //        sb = new System.Text.StringBuilder();
            //        sb.Append("insert into Sjzzd_bak(yydh,qymc,lsbh,jzbh,jzbh_new,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,is_top,is_select,fp_print,is_visible)");
            //        sb.Append(" select  yydh,qymc,lsbh,jzbh,'" + jzbh_new + "',krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,0,0,fp_print,is_visible from Sjzzd");
            //        sb.Append("  Where  yydh='" + yydh + "'   and  jzbh='" + jzbh_last + "' ");
            //        temp = sb.ToString();
            //        B_common.ExecuteSql(sb.ToString());
            //        B_common.ExecuteSql(" update  Sjzzd   set xfje=xfje-'" + xfje_bf + "'  where   yydh='" + yydh + "'   and  jzbh='" + jzbh_last + "' ");
            //        B_common.ExecuteSql(" update  Szwzd_bak set  xfje=xfje-'" + xfje_bf + "'  where   yydh='" + yydh + "'   and  jzbh='" + jzbh_last + "' ");

            //        //备份Sjzmx
            //        sb = new System.Text.StringBuilder();
            //        sb.Append("insert  into  Sjzmx_bak(yydh,qymc,id_app,jzbh,jzbh_new,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,shsc,mxbh,tfsj )");
            //        sb.Append("  select  yydh,qymc,id_app,jzbh,'" + jzbh_new + "',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,shsc,mxbh,tfsj   from Sjzmx  ");
            //        sb.Append("  where    yydh='" + yydh + "'  and id_app  in (select id_app  from Szw_temp  where jzbh='" + jzbh_last + "'  and yydh='" + yydh + "' and czy_temp='" + czy_GUID + "'  and  xfdr!='" + common_file.common_app.fkdr + "') ");
            //        temp = sb.ToString();
            //        B_common.ExecuteSql(sb.ToString());

            //        sb = new System.Text.StringBuilder();
            //        sb.Append("  update  Sjzmx  set  jzbh='" + jzbh_new + "',czzt='" + common_file.common_jzzt.czzt_gzzsz + "',czsj='" + czsj + "'  where    yydh='" + yydh + "'  and id_app  in (select id_app  from Szw_temp  where jzbh='" + jzbh_last + "'  and yydh='" + yydh + "' and czy_temp='" + czy_GUID + "'  and  xfdr!='" + common_file.common_app.fkdr + "') ");
            //        B_common.ExecuteSql(sb.ToString());

            //        //删除Szwmx
            //        sb = new System.Text.StringBuilder();
            //        sb.Append(" delete from Szwmx where id_app in  (select id_app  from  Szw_temp  where  jzbh='" + jzbh_last + "'  and czy_temp='" + czy_GUID + "')");
            //        //temp= sb.ToString();
            //        B_common.ExecuteSql(sb.ToString());

            //    }
            //}


            //sb = new System.Text.StringBuilder();
            //sb.Append("  update  Ssyxfmx set  jzbh='" + jzbh_new + "',czsj='" + czsj + "'   where  id_app in (select id_app  from  Szw_temp  where  czy_temp='" + czy_GUID + "' and yydh='" + yydh + "' and  krxm='" + jzzt + "')");
            //B_common.ExecuteSql(sb.ToString());

            //sb = new System.Text.StringBuilder();
            //sb.Append("  insert into Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj)");
            //sb.Append(" select  yydh,qymc,id_app,'" + jzbh_new + "',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'"+czy+"',xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'0','"+czy_bc+"','" + common_file.common_jzzt.czzt_gzzsz + "','" + czsj + "','" + syzd + "','"+xyh_temp+"','" + jzzt + "',fkfs,mxbh,'"+czsj+"'  from Szw_temp ");
            //sb.Append(" where czy_temp='" + czy_GUID + "'  and jzbh=''  and xfxm='" + common_file.common_app.dj_pzsk + "'");
            //B_common.ExecuteSql(sb.ToString());
            #endregion


              //成功后一定要记得删除Szw_Union中的记录
              DataSet ds_0 = B_common.GetList(" select * from Szw_temp ", " id>=0   and czy_temp='" + czy_GUID + "' ");
              if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
              {
                  for (int i = 0; i <  ds_0.Tables[0].Rows.Count ; i++)
                  {
                        string tempStr = " delete from Szw_union  where   id>=0  and yydh='" + yydh + "' and union_bh in( select union_bh  from Szw_union   where    id_app='" + ds_0.Tables[0].Rows[i]["id_app"].ToString() + "')";
                        B_common.ExecuteSql(tempStr);
                  }
              }

           DbHelperSQL.ExecuteSql("delete from Szw_temp  where  id>=0  " + common_app.yydh_select + "   and czy_temp='" + czy_GUID + "'");
              s = common_file.common_app.get_suc;
            return s;
        }


        public bool CheckSelectAll(string jzbh)
        {
            bool result = false;
            if (!jzbh.Equals(""))
            {
                DataTable dt_xf = null;
                DataTable dt_fk = null;
                DataTable dt_total = null;
                DataSet ds = null;
                BLL.Common bll = new Hotel_app.BLL.Common();
                ds = bll.GetList("select  id_app  from  Szwmx", " jzbh='" + jzbh + "'");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt_xf = ds.Tables[0];
                }
                ds = bll.GetList("select  id_app  from  Syjcz", " jzbh='" + jzbh + "'");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt_fk = ds.Tables[0];
                }
                if (dt_xf != null)
                {
                    if (dt_fk != null)
                    {
                        dt_xf.Merge(dt_fk);
                        dt_total = dt_xf;
                    }
                    else
                    {
                        dt_total = dt_xf;
                    }
                }
                else
                {
                    if (dt_fk != null)
                    {
                        dt_total = dt_fk;
                    }
                }
                if (dt_total != null&&dt_total.Rows.Count>0)
                {
                    DataSet ds_ls = bll.GetList(" select id_app  from Szw_temp", " jzbh='" + jzbh + "' and czy_temp='" + common_app.czy_GUID + "'");
                    if (ds_ls != null && ds_ls.Tables.Count > 0 && ds_ls.Tables[0].Rows.Count > 0)
                    {
                        //记录条数相同,那说明肯定是全部选择出来了
                        if (dt_total.Rows.Count == ds_ls.Tables[0].Rows.Count)
                        {
                            result = true;
                        }
                    }
 
                }
            }
                return result;
        }
    }
}
