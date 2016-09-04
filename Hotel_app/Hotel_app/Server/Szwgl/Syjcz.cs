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

namespace Hotel_app.Server.Szwgl
{
    public class Syjcz
    {
        //注:分结时被调定的金额用sjxfje传过来
        public string Syjcz_add_edit(string id, string yydh, string qymc, string id_app, string jzbh, string lsbh, string krxm, string fjrb, string fjbh, string sktt, string xfrq, string xfsj,
            string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string fkfs, string xfje, string sjxfje, string czy_bc, string syzd, string add_edit_delete, string xxzs,string czsj)
        {

            string s = common_file.common_app.get_failure;
            decimal sjxfje_old = 0;//押金修改前的值 
            BLL.Syjcz B_Syjcz = new Hotel_app.BLL.Syjcz();
            Model.Syjcz M_Syjcz = new Hotel_app.Model.Syjcz();
            BLL.Common B_common = new Hotel_app.BLL.Common();
            StringBuilder strsql;
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {


                M_Syjcz.yydh = yydh;
                M_Syjcz.qymc = qymc;
                M_Syjcz.id_app = id_app;
                M_Syjcz.jzbh = jzbh;
                M_Syjcz.lsbh = lsbh;
                M_Syjcz.krxm = krxm;
                M_Syjcz.fjrb = fjrb;
                M_Syjcz.fjbh = fjbh;
                M_Syjcz.sktt = sktt;
                M_Syjcz.xfrq = Convert.ToDateTime(xfrq);
                M_Syjcz.xfsj = Convert.ToDateTime(xfsj);
                M_Syjcz.czy = czy;
                M_Syjcz.xfdr = xfdr;
                M_Syjcz.xfrb = xfrb;
                M_Syjcz.xfxm = xfxm;
                M_Syjcz.xfbz = xfbz;
                M_Syjcz.xfzy = xfzy;
                M_Syjcz.fkfs = fkfs;
                M_Syjcz.xfje = Convert.ToDecimal(xfje);
                M_Syjcz.sjxfje = Convert.ToDecimal(sjxfje);
                M_Syjcz.czy_bc = czy_bc;
                M_Syjcz.syzd = syzd;

                if (B_Syjcz.Add(M_Syjcz) > 0)
                {
                    s = common_file.common_app.get_suc;

                    //2012-03-06 更新(Szwzd)
                    if (jzbh.Trim() == "")
                    {
                        strsql = new StringBuilder();
                        strsql.Append("update   Szwzd  set   fkje=fkje+" + M_Syjcz.xfje + "  where lsbh='" + lsbh + "'");
                        B_common.ExecuteSql(strsql.ToString());
                    }
                    if (jzbh.Trim() != "")
                    {
                        DataSet ds_temp_0=B_common.GetList(" select * from Sjzzd "," jzbh='"+jzbh+"'  and  yydh='"+yydh+"'");
                        if(ds_temp_0!=null)
                        {

                            string czzt_temp=ds_temp_0.Tables[0].Rows[0]["czzt"].ToString();
                            string xyh_0 = ds_temp_0.Tables[0].Rows[0]["xyh"].ToString();
                            string jzzt_0 = ds_temp_0.Tables[0].Rows[0]["jzzt"].ToString();
                            string tfsj_0 = ds_temp_0.Tables[0].Rows[0]["tfsj"].ToString();

                            B_common.ExecuteSql("  update  Syjcz  set  czzt='" + czzt_temp + "'   where   jzbh='" + jzbh + "'  and   id_app='" + id_app + "'  and  yydh='"+yydh+"'");

                            strsql =new StringBuilder();
                            strsql.Append("insert into Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj) ");
                            strsql.Append(" values('" + yydh + "','" + qymc + "','" + id_app + "','" + jzbh + "','" + lsbh + "','" + krxm + "','" + fjrb + "','" + fjbh + "','" + sktt + "','" + xfrq + "','" + xfsj + "','" + czy + "','" + xfdr + "','" + xfrb + "','" + xfxm + "','" + xfbz + "','" + xfzy + "',0,'-" + xfje + "','','-" + sjxfje + "',1,0,'" + czy_bc + "','" + czzt_temp + "','" + xfsj + "','" + syzd + "','" + xyh_0 + "','" + jzzt_0 + "','" + fkfs + "','','"+tfsj_0+"')");
                            B_common.ExecuteSql(strsql.ToString());

                            //strsql = new StringBuilder();
                            //strsql.Append("  insert  into  Sfkfssz(yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,fkrq,fksj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
                            //strsql.Append("  values('" + yydh + "','" + qymc + "',0,0,'" + jzbh + "','" + krxm + "','" + lsbh + "','" + fjbh + "','" + krxm + "','" + fkfs + "','" + xfdr + "','" + xfrb + "','" + xfxm + "','" + xfje + "','" + sjxfje + "','" + xfrq + "','" + xfsj + "','" + xfrq + "','" + xfsj + "','" + czy + "','" + czy_bc + "','" + syzd + "','" + id_app + "')");
                            //B_common.ExecuteSql(strsql.ToString());

                            B_common.ExecuteSql("  update  Szwzd_bak set fkje=fkje+" + M_Syjcz.xfje + " where lsbh='" + lsbh + "'  and  jzbh='" + jzbh + "'");
                            B_common.ExecuteSql("  update  Sjzzd  set fkje=fkje+" + M_Syjcz.xfje + "  where lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'");
                        }
                    }
                    
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, lsbh + "增加" + common_file.common_app.dj_ysk + ",金额为:" + sjxfje, common_file.common_app.dj_ysk, "收取押金的结果为:" + s, DateTime.Now);

                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Syjcz = B_Syjcz.GetModel(Convert.ToInt32(id));
                    sjxfje_old = M_Syjcz.sjxfje;//缓存一下押金修改前的值
                    M_Syjcz.yydh = yydh;
                    M_Syjcz.qymc = qymc;
                    M_Syjcz.id_app = id_app;
                    M_Syjcz.jzbh = jzbh;
                    M_Syjcz.lsbh = lsbh;
                    M_Syjcz.krxm = krxm;
                    M_Syjcz.fjrb = fjrb;
                    M_Syjcz.fjbh = fjbh;
                    M_Syjcz.sktt = sktt;
                    M_Syjcz.xfrq = Convert.ToDateTime(xfrq);
                    M_Syjcz.xfsj = Convert.ToDateTime(xfsj);
                    M_Syjcz.czy = czy;
                    M_Syjcz.xfdr = xfdr;
                    M_Syjcz.xfrb = xfrb;
                    M_Syjcz.xfxm = xfxm;
                    M_Syjcz.xfbz = xfbz;
                    M_Syjcz.xfzy = xfzy;
                    M_Syjcz.fkfs = fkfs;
                    M_Syjcz.xfje = Convert.ToDecimal(xfje);
                    M_Syjcz.sjxfje = Convert.ToDecimal(sjxfje);
                    M_Syjcz.czy_bc = czy_bc;
                    M_Syjcz.syzd = syzd;
                    M_Syjcz.id = int.Parse(id);
                    //M_Syjcz.czzt = "";
                    if (B_Syjcz.Update(M_Syjcz))
                    {
                        s = common_file.common_app.get_suc;
                        //这个功能当前保留（暂时在前台屏敝掉了)
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "押金由" + sjxfje_old.ToString() + "分结时调定出" + sjxfje, "调定", "分结押金调定", DateTime.Now);
                    }
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            //退订押金或者预授权的时候要更新Szwzd
                            M_Syjcz = B_Syjcz.GetModel(Convert.ToInt32(id));
                            if (M_Syjcz.jzbh.Trim() == "")//算帐,记帐，挂帐及在住的退订(退还没有生成jzbh时的押金的退订)
                            {
                                strsql = new StringBuilder();
                                strsql.Append("  update   Szwzd  set   fkje=fkje-'" + M_Syjcz.xfje + "'   where lsbh='" +M_Syjcz.lsbh + "'");
                                B_common.ExecuteSql(strsql.ToString());
                            }
                            //记帐，挂帐后的退订(记挂转结的时候)
                            if (M_Syjcz.jzbh.Trim() != "")
                            {
                                strsql=new StringBuilder();
                                strsql.Append( " update   Szwzd_bak  set   fkje=fkje-(" + M_Syjcz.sjxfje + ")  where    jzbh='" + M_Syjcz.jzbh + "'");
                                B_common.ExecuteSql(strsql.ToString());
                                
                                strsql=new StringBuilder();
                                strsql.Append("  insert into  Sjzzd_bak(yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc)");
                                strsql.Append("  select  yydh,qymc,jzbh,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,shsc  from Sjzzd where  lsbh='"+M_Syjcz.lsbh+"'  and jzbh='"+M_Syjcz.jzbh+"'");
                                B_common.ExecuteSql(strsql.ToString());

                                strsql = new StringBuilder();
                                strsql.Append(" update  Sjzzd Set  fkje=fkje-'" + M_Syjcz.xfje + "'  ,shsc=0  where   jzbh='"+M_Syjcz.jzbh+"'");
                                B_common.ExecuteSql(strsql.ToString());

                                strsql=new StringBuilder();
                                strsql.Append("  insert  into   Sjzmx_bak(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs)");
                                strsql.Append("  select  yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs from Sjzmx where id_app='" + M_Syjcz.id_app + "'  and  yydh='"+M_Syjcz.yydh+"'");
                                B_common.ExecuteSql(strsql.ToString());

                                strsql = new StringBuilder();
                                strsql.Append("  delete from Sjzmx where  id_app='" + M_Syjcz.id_app + "'  and yydh='" +M_Syjcz.yydh + "'");
                                B_common.ExecuteSql(strsql.ToString());

                            }
                            //退订时备份到Syjcz_temp中
                            strsql = new StringBuilder();
                            strsql.Append(" insert into Syjcz_temp(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt,czsj)");
                            strsql.Append(" select  yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'"+czy+"',xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,'"+common_file.common_app.get_delete+"','"+czsj+"'  from Syjcz ");
                            strsql.Append(" where  id='" + id + "'  and  yydh='" + yydh + "'");
                            B_common.ExecuteSql(strsql.ToString());


                            B_Syjcz.Delete(Convert.ToInt32(id));   //DEL时，由触发器来备份到bak中
                            s = common_file.common_app.get_suc;
                            common_file.common_czjl.add_czjl(yydh, qymc, czy, "押金退订", "押金退定", "押金退定,操作执行的结果为:"+s, DateTime.Now);
                        }
                    }
                            return s;
        }
    }
}
