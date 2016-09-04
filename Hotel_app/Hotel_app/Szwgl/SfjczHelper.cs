using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;

namespace Hotel_app.Szwgl
{
    //此类处理有关分结操作的内容
   public  class SfjczHelper
    {

       //id_app_old  要拆帐的那条，id_app_new  要拆出的那条  union_lzbh 两条生成的lzbh
       //fj_type  是算帐分结，记帐分结，挂帐分结(common_file.common_jzzt.xxxxx)
        //je_need要拆出来的金额，je_last余下的金额
       //

        //userType  1为正常的拆账，2为单拆
       public static void  Fun_fj_chaizhang(string id_app_old, string id_app_new, string union_lzbh, decimal je_need,decimal je_last,string fj_type,string czsj,string  userType)
       {
           BLL.Szwmx B_Szwmx = new Hotel_app.BLL.Szwmx();
           BLL.Common B_common = new Hotel_app.BLL.Common();
           StringBuilder strsql;
           Model.Szwmx M_Szwmx;

           M_Szwmx = B_Szwmx.GetModelList("id_app='" + id_app_old + "'  and id>=0  and  yydh='" + common_file.common_app.yydh + "'")[0];
           double xfsl_need =common_file.common_sswl.Round_sswl(double.Parse((je_need / (je_need + je_last) * M_Szwmx.xfsl).ToString()),common_file.common_sswl.sswl_ws,common_file.common_sswl.selectMode_sel); //拆出消费数量
           double xfsl_last =double.Parse((M_Szwmx.xfsl).ToString()) - xfsl_need;

           //向Szw_union里面加入拆出来的两条记录(1表示是第一条记录，原来被拆的那条，0表示新加的那条)
           string temp_czsj = DateTime.Now.ToString();//保持两条的时间一致
           strsql = new StringBuilder();
           strsql.Append("insert into  Szw_union(yydh,qymc,union_bh,jzbh,id_app,czsj,is_first)");
           strsql.Append("  select yydh,qymc,'" + union_lzbh + "',jzbh,'" + id_app_old + "','" + temp_czsj + "',1   from Szwmx ");
           strsql.Append("  where  id_app='" + id_app_old + "'");
           B_common.ExecuteSql(strsql.ToString());//第一条(旧的记录)
           strsql = new StringBuilder();
           strsql.Append("insert into  Szw_union(yydh,qymc,union_bh,jzbh,id_app,czsj,is_first)");
           strsql.Append("  select yydh,qymc,'" + union_lzbh + "',jzbh,'" + id_app_new + "','" + temp_czsj + "',0   from Szwmx ");
           strsql.Append("  where id_app='" + id_app_old + "'");
           B_common.ExecuteSql(strsql.ToString());//第二条(新生成的一条记录)

           //第一步，拆分帐务明细表的记录
           strsql = new StringBuilder();
           strsql.Append("update  Szwmx  set  xfje=" + je_last + ", sjxfje=" + je_last + ", xfsl="+xfsl_last+"  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_old + "'");
           B_common.ExecuteSql(strsql.ToString());
           //注意这里的xfzy  以分结类型用"拆帐"来显示
           strsql = new StringBuilder();
           strsql.Append("insert into  Szwmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
           strsql.Append("  select  yydh,qymc,is_top,is_select,'" + id_app_new + "',jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,'" + common_zw.zwcl_caiz + "',jjje," + je_need + ",yh," + je_need + "," + xfsl_need + ",shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh  from  Szwmx");
           strsql.Append("  where  id>=0 and id_app='" + id_app_old + "'");
           B_common.ExecuteSql(strsql.ToString());

           ////结帐明细要一起分拆--针对记。挂
           //if (fj_type == common_file.common_jzzt.czzt_gzfj || fj_type == common_file.common_jzzt.czzt_jzfj)
           //{
           //    strsql = new StringBuilder();
           //    strsql.Append("update  Sjzmx  set  xfje=" + je_last + ", sjxfje=" + je_last + ", xfsl=" + xfsl_last + "  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_old + "'");
           //    B_common.ExecuteSql(strsql.ToString());

           //    strsql = new StringBuilder();
           //    strsql.Append("insert into  Sjzmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj)");
           //    strsql.Append("  select  yydh,qymc,is_top,is_select,'" + id_app_new + "',jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,'" + common_zw.zwcl_caiz + "',jjje," + je_need + ",yh," + je_need + "," + xfsl_need + ",shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj  from  Sjzmx");
           //    strsql.Append("  where  id>=0 and id_app='" + id_app_old + "'");
           //    B_common.ExecuteSql(strsql.ToString());
           //}
           //看当前的id_app_old是否存在于Sjzmx中,存在也要拆分
           DataSet ds_temp_0 = B_common.GetList(" select * from Sjzmx  ", " id>=0  and  id_app='" + id_app_old + "'  and  yydh='" + common_file.common_app.yydh + "' ");
           if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
           {
               strsql = new StringBuilder();
               strsql.Append("update  Sjzmx  set  xfje=" + je_last + ", sjxfje=" + je_last + ", xfsl=" + xfsl_last + "  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_old + "'");
               B_common.ExecuteSql(strsql.ToString());

               strsql = new StringBuilder();
               strsql.Append("insert into  Sjzmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj)");
               strsql.Append("  select  yydh,qymc,is_top,is_select,'" + id_app_new + "',jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,'" + common_zw.zwcl_caiz + "',jjje," + je_need + ",yh," + je_need + "," + xfsl_need + ",shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj  from  Sjzmx");
               strsql.Append("  where  id>=0 and id_app='" + id_app_old + "'");
               B_common.ExecuteSql(strsql.ToString()); 
           }

           //第二步，拆分ssyxfmx里面的记录
           strsql = new StringBuilder();
           strsql.Append(" update   Ssyxfmx  Set xfje=" + je_last + ",  sjxfje=" + je_last + ",xfsl="+xfsl_last+"   where id>=0  and yydh='" + common_file.common_app.yydh + "' and id_app='" + id_app_old + "'");
           B_common.ExecuteSql(strsql.ToString());
          //

           strsql = new StringBuilder();
           strsql.Append("insert into Ssyxfmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,mxbh,ddsj,lksj,czsj )");
           strsql.Append(" select yydh,qymc,'" + id_app_new + "',jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,'" + common_zw.zwcl_caiz + "',jjje," + je_need + ",yh," + je_need + "," + xfsl_need + ",czy_bc,mxbh,ddsj,lksj,'"+czsj+"'   from Ssyxfmx");
           strsql.Append(" where id_app='" + id_app_old + "'");
           B_common.ExecuteSql(strsql.ToString());

           //增加完成后直接向Ssyxfmx_cz里面加一条记录
           strsql = new StringBuilder();
           strsql.Append("insert into  Ssyxfmx_cz(yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq)");
           strsql.Append("  select  yydh,qymc,'" + id_app_new + "',krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq from Ssyxfmx_cz ");
           strsql.Append("  where id>=0  and id_app='" + id_app_old + "'");
           B_common.ExecuteSql(strsql.ToString());



           //把新拆出来的一条记录加入到Szw_zz_fj_temp里面
           if (userType == "1")
           {
               strsql = new StringBuilder();
               strsql.Append("insert into  Szw_zz_fj_temp(yydh,qymc,jzbh,id_app,lsbh,czy,czsj)");
               //strsql.Append("   select  yydh,qymc,jzbh,'" + id_app_new + "',lsbh,czy,'" + czsj + "'  from  Szwmx ");
               strsql.Append("   select  yydh,qymc,jzbh,'" + id_app_new + "',lsbh,'"+common_file.common_app.czy_GUID+"','" + czsj + "'  from  Szwmx ");
               //strsql.Append("  where  id_app='" + id_app_old + "'");
               strsql.Append("   where  id_app='" + id_app_new + "'");
               B_common.ExecuteSql(strsql.ToString());
           }
       }

       //id_app_temp这条指当前行     是否有Szw_union(注意,最后保留Szw_union里面为is_first为1的那条)    //结帐类型
       public static void Fun_fj_chaizhang_cx(string id_app_temp,string fj_Type,string jzbh_current)
       {
           DataSet ds_temp ;
           string union_lzbh = "";
           StringBuilder strsql;
           string id_app_last = "";//确定哪条记录要最后保留下来进行累加(is_first为真的那条)
           string id_app_delete = "";//要删除掉的那条记录
           BLL.Common B_common = new Hotel_app.BLL.Common();
           decimal xfje = 0;
           decimal sjxfje = 0;
           decimal xfsl = 0;
           //注意：由于，一个lsbh可能对应着N多条的union编号，所以，还要加一个时间的条件来约束当唯一确定跟 当前要撤消的记录是哪个union_bh

           //object obj = DbHelperSQL.GetSingle("select  union_bh  from  Szw_union where id_app='" + id_app_temp + "'");
           ds_temp = B_common.GetList(" select   *  from  Szw_union ", " id_app='" + id_app_temp + "'  and yydh='" + common_file.common_app.yydh + "'  order by  czsj  desc");
           if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
           {
               if (ds_temp.Tables[0].Rows.Count>=1)//当前这条只拆分过一次或者多次
               {
                   union_lzbh = ds_temp.Tables[0].Rows[0]["union_bh"].ToString();
                   //有存在(撤消时要找到对应的另一条，并修改加回去)
                   //Szwmx,Ssyxfmx,Ssyxfmx_cz,Szw_union,Szw_zz_fj_temp 
                   string id_app = DbHelperSQL.GetSingle("SELECT   id_app from Szw_union where  union_bh='" + union_lzbh + "'  and  id_app!='" + id_app_temp + "'  ").ToString();

                   //撤销回去的时候
                   //判断id_app对应的记录是否在Szw_zz_fj_temp里面有没有这条记录
                   //a.不存在，那么要从Szw_zz_fj_temp里面删除，再把数值加回去
                   //b.存在，直接把id_app对应的记录从Szw_zz_fj_temp里面删除
                   object obj_temp = DbHelperSQL.GetSingle("Select id  from Szw_zz_fj_temp  where  id>=0 and yydh='" + common_file.common_app.yydh + "' and  id_app='" + id_app + "'");
                   if (obj_temp == null)
                   {
                       //要加回去的时候，找出要保留的id_app_last
                       id_app_last = DbHelperSQL.GetSingle("  select  id_app  from Szw_union where  union_bh='" + union_lzbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  is_first='1'").ToString();
                       if (id_app_last.Equals(id_app))
                       {
                           id_app_last = id_app;
                           id_app_delete = id_app_temp;
                       }
                       else
                       {
                           id_app_delete = id_app;
                           id_app_last = id_app_temp;
                       }

                       DataSet ds_0 = B_common.GetList("  select  * from Szwmx ", " id>=0  and  yydh='"+common_file.common_app.yydh+"'   and   id_app  in('" + id_app_temp + "','" + id_app + "')");
                       if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                       {
                           for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
                           {
                               xfje += decimal.Parse(ds_0.Tables[0].Rows[i]["xfje"].ToString());
                               xfsl += decimal.Parse(ds_0.Tables[0].Rows[i]["xfsl"].ToString()); 
                               sjxfje += decimal.Parse(ds_0.Tables[0].Rows[i]["sjxfje"].ToString());
                           }
                       }
                       //xfje = decimal.Parse(DbHelperSQL.GetSingle("select sum(xfje)  from Szwmx  where id_app in ('" + id_app_temp + "','" + id_app + "')").ToString());
                       //xfsl = decimal.Parse(DbHelperSQL.GetSingle("select sum(xfsl)  from Szwmx where id_app  in('" + id_app_temp + "','" + id_app + "')").ToString());
                       //sjxfje = decimal.Parse(DbHelperSQL.GetSingle(" select sum(sjxfje) from Szwmx where id_app in('" + id_app_temp + "','" + id_app + "')").ToString());
                      //要确定出保留哪一条记录

                       //第一步，更新（Szwmx里面这条记录的消费金额)
                       strsql = new StringBuilder();
                       strsql.Append("update  Szwmx  set  xfje=" + xfje + ", sjxfje=" + sjxfje + ",xfsl='" + xfsl + "'  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_last + "'");
                       B_common.ExecuteSql(strsql.ToString());
                       //删除Szwmx里面多出来的这条记录
                       strsql = new StringBuilder();
                       strsql.Append("delete  from Szwmx where  id_app='" + id_app_delete + "'");
                       B_common.ExecuteSql(strsql.ToString());

                       strsql = new StringBuilder();
                       strsql.Append(" delete from Szw_zz_fj_temp  where id_app='" + id_app_delete + "'");
                       B_common.ExecuteSql(strsql.ToString());
                       #region  Test
                       //strsql = new StringBuilder();
                       //strsql.Append(" delete from Szwmx_bak where id_app='" + id_app_delete + "'");
                       // B_common.ExecuteSql(strsql.ToString());
                       #endregion
                       common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, "合并分拆记录", "保留的id_app:" + id_app_last, "删除的id_app:" + id_app_delete, "合并分拆记录", DateTime.Now);

                       //第二步，合并Ssyxfmx里面的记录，并删除Ssyxfmx和Ssyxfmx_cz里面的那条
                       strsql = new StringBuilder();
                       strsql.Append("update  Ssyxfmx  set  xfje=" + xfje + ", sjxfje=" + sjxfje + ",xfsl='" + xfsl + "'  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_last + "'");
                       B_common.ExecuteSql(strsql.ToString());
                       strsql = new StringBuilder();

                       //如果记分，或者是挂分,合并Sjzmx里面的记录
                       //if (fj_Type == common_file.common_jzzt.czzt_jzfj || fj_Type == common_file.common_jzzt.czzt_gzfj)
                       //{
                       //    strsql = new StringBuilder();
                       //    strsql.Append("update  Sjzmx  set  xfje=" + xfje + ", sjxfje=" + sjxfje + ",xfsl='" + xfsl + "'  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_last + "'");
                       //    B_common.ExecuteSql(strsql.ToString());

                       //    //删除前  先备份到Sjzmx_bak
                       //    strsql = new StringBuilder();
                       //    strsql.Append("insert into Sjzmx_bak(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh ) ");
                       //    strsql.Append("select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh  from Sjzmx ");
                       //    strsql.Append("  where  id_app='" + id_app_temp + "'");
                       //    B_common.ExecuteSql(strsql.ToString());

                       //    strsql = new StringBuilder();
                       //    strsql.Append("delete  from Sjzmx where  id_app='" + id_app_delete + "'");
                       //    B_common.ExecuteSql(strsql.ToString());
                       //}
                       //如果当前的记录在Sjzmx里面找得到,那么也要合并记录
                       DataSet ds_temp_01 = B_common.GetList(" select * from  Sjzmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   id_app='" + id_app_last + "' and jzbh='"+jzbh_current+"' ");
                       if (ds_temp_01 != null && ds_temp_01.Tables[0].Rows.Count > 0)
                       {
                           strsql = new StringBuilder();
                           strsql.Append("update  Sjzmx  set  xfje=" + xfje + ", sjxfje=" + sjxfje + ",xfsl='" + xfsl + "'  where id>=0  and yydh='" + common_file.common_app.yydh + "'  and id_app='" + id_app_last + "'");
                           B_common.ExecuteSql(strsql.ToString());

                           //删除前  先备份到Sjzmx_bak
                           strsql = new StringBuilder();
                           strsql.Append("insert into Sjzmx_bak(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh ) ");
                           strsql.Append("select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh  from Sjzmx ");
                           strsql.Append("  where  id_app='" + id_app_temp + "'");
                           B_common.ExecuteSql(strsql.ToString());

                           strsql = new StringBuilder();
                           strsql.Append("delete  from Sjzmx where  id_app='" + id_app_delete + "'");
                           B_common.ExecuteSql(strsql.ToString());
                       }

                       //删除分拆出来的记录
                       strsql.Append("delete  from Ssyxfmx where  id_app='" + id_app_delete + "'");
                       B_common.ExecuteSql(strsql.ToString());
                       strsql = new StringBuilder();
                       //删除分拆出来的记录
                       strsql.Append("delete  from Ssyxfmx_cz where  id_app='" + id_app_delete + "'");
                       B_common.ExecuteSql(strsql.ToString());

                       //第三步，删除Union表里面的记录
                       strsql = new StringBuilder();
                       strsql.Append("delete from Szw_union  where  union_bh='" + union_lzbh + "'");
                       B_common.ExecuteSql(strsql.ToString());
                   }
               }
               else//分拆出来的那条记录以经被记录到Szw_zz_fj_temp里面
               {

               }
               strsql = new StringBuilder();
               strsql.Append(" delete from Szw_zz_fj_temp ");
               strsql.Append("  where  czy='" + common_file.common_app.czy_GUID + "' and id_app='" + id_app_delete + "'");
               B_common.ExecuteSql(strsql.ToString());


           }

           //没有被拆过，就直接删除
           strsql = new StringBuilder();
           strsql.Append(" delete from Szw_zz_fj_temp ");
           strsql.Append("  where  czy='" + common_file.common_app.czy_GUID + "' and id_app='" + id_app_temp + "'");
           B_common.ExecuteSql(strsql.ToString());
       }


       //分结后窗体的刷新
       public static  void RefreshStaticFrm(string lsbh,string sk_tt,string czzt,string jzbh)
       {
           if (common_file.common_form.Szw_Common_check_new != null)
           {
               common_file.common_form.Szw_Common_check_new.Close();
           }
           //注意，只有部分算帐时才有可能打开帐务处理窗体，记挂分结会出异常的
           if (common_file.common_form.Szwcl_new != null&&czzt==common_file.common_jzzt.czzt_bfsz)
           {
               common_file.common_form.Szwcl_new.BindData(lsbh, common_file.common_app.czy);
               common_file.common_form.Szwcl_new.Inital_app(lsbh, sk_tt, false, common_file.common_app.czy_GUID);
           }
           if (common_file.common_form.Sfjcz_new != null && common_file.common_form.Sfjcz_new.IsDisposed == false)
           {
               common_file.common_form.Sfjcz_new.InitalApp(czzt, lsbh, sk_tt, jzbh);
           }
       }
    }
}
