using System;
using System.Data;
using System.Configuration;
using System.Text;

namespace Hotel_app.Server.Szwgl
{
    //此类是处理挂/记 To   转帐的
    public class Szw_jzOrgjToZz
    {
        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();

        BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();

        BLL.Sjzzd B_sjjzd = new Hotel_app.BLL.Sjzzd();
        BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        BLL.Common B_common = new Hotel_app.BLL.Common();

        string krxm_old = "";
        string krxm_new = "";
        string fjbh_old = "";
        string fjbh_new = "";
        string sk_tt_afterZZ = "";//转帐后要转成什么类型(散客转成散客，散客转成团体)

        public string GetjzOrgjToZzResult(string lsbh_old, string lsbh_new, string sk_tt,string Zz_Type, string yydh, string czy, string czy_bc, string czsj, string syzd, string xxzs)
        {
             //lsbh_new和lsbh_old在前台去判断(old是转前的lsbh,new是帐务转到的lsbh
            //Zz_Type  是指转的类型 （从帐务转进来有：jz-tt,jz-sk;gz-tt,gz-sk
           //sk_tt   是指转帐的主体是散客还是团体(lsbh_old类型,sk  or  tt）
            //注意，记、挂的帐务在Szwmx和Syjcz里面都记录的相关内容

            string s = common_file.common_app.get_failure;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            //备份当前lsbh下对应jzzd和jzmx里面的记录到相应的BAK


           StringBuilder  strsql = new StringBuilder();
            strsql.Append("insert into  sjzzd_bak(yydh,qymc,jzbh,jzbh_new,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,ddsj,krxm_lz,fjbh_lz)");
            strsql.Append("select yydh,qymc,jzbh,'',lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,'" + Zz_Type + "',xyh,jzzt,sdcz,syzd,'" + "帐务由lsbh:" + lsbh_old + "通过:" + Zz_Type + "方式转到lshb:" + lsbh_new + "',fp_print,is_visible,fkje,xfje,ddsj,krxm_lz,fjbh_lz  from  sjzzd");
            strsql.Append(" where  lsbh='" + lsbh_old + "' and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());//备份jzzd--jzzd_bak

            strsql = new StringBuilder();
            strsql.Append("insert into sjzmx_bak(yydh,qymc,is_top,is_select,id_app,jzbh,jzbh_new,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj)");
            strsql.Append("select yydh,qymc,is_top,is_select,id_app,jzbh,'',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,'" + Zz_Type + "',czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj  from sjzmx");
            strsql.Append(" where  lsbh='" + lsbh_old + "' and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());//备份jzmx-jzmx_bak  

            strsql = new StringBuilder();
            strsql.Append("insert into  Szwmx_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
            strsql.Append("select yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,xfje,yh,sjxfje,xfsl,shsc,czy_bc,'" + Zz_Type + "',czsj,syzd,is_visible,mxbh  from Szwmx");
            strsql.Append("  where  lsbh='" + lsbh_old + "'  and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());//备份帐务明细


            strsql = new StringBuilder();
            strsql.Append("insert into  Syjcz_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd)");
            strsql.Append("select  yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd  from  Syjcz");
            strsql.Append("  where  lsbh='" + lsbh_old + "'  and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());//备份押金操作



            //更新(Szwmx,Syjcz)||CZZT,lsbh,czy,czsj,syzd,bz里面作标记
            //删除（Sjzzd,Sjzmx）两张表里面的记录
            //Ssyxfmx里面的lsbh是否在更新(暂无备份表)

            if (GetjzOrgjToZz_helper(lsbh_old, lsbh_new, sk_tt, Zz_Type, yydh, czy, czy_bc, czsj, syzd, xxzs) == common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        private string GetjzOrgjToZz_helper(string lsbh_old, string lsbh_new,string sk_tt,string Zz_Type, string yydh, string czy, string czy_bc, string czsj, string syzd, string xxzs)//对GetjzOrgjToZz方法的辅助方法
        {
            //对每个表(Sjzzd,Sjzmx，循环查找，删除Sjzzd,Sjzmx里面的记录,将记录加到
            //Sjzzd
            string s = common_file.common_app.get_failure;
            DataSet ds_temp = new DataSet();
            Model.Sjzzd M_Sjzzd = B_sjjzd.GetModelList("id>0 and yydh='" + yydh + "' and lsbh='" + lsbh_old + "'")[0];
            krxm_old = M_Sjzzd.krxm;
            fjbh_old = M_Sjzzd.fjbh;

            //转向散客（
            if (Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_jz_sk)
            {
                ds_temp = B_Qskyd_fjrb.GetList("id>0 and yydh='" + yydh + "' and lsbh='" + lsbh_new + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    krxm_new = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                    fjbh_new = ds_temp.Tables[0].Rows[0]["fjbh"].ToString();
                    sk_tt_afterZZ = ds_temp.Tables[0].Rows[0]["sktt"].ToString();
                }
            }
            //转向团体（fjbh为空)
            if (Zz_Type == common_zw.zwzz_jz_tt || Zz_Type == common_zw.zwzz_gz_tt)
            {
                ds_temp = B_Qttyd_mainrecord.GetList("id>0 and yydh='" + yydh + "' and lsbh='" + lsbh_new + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    krxm_new = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                    fjbh_new = "";
                    sk_tt_afterZZ = ds_temp.Tables[0].Rows[0]["sktt"].ToString();
                }
            }
            if (GetjzOrgjToZz_helper_InsertToSzwzz_mx(lsbh_old, lsbh_new, krxm_old, krxm_new, fjbh_old, fjbh_new, "Syjcz", Zz_Type, czy, czsj, Zz_Type, yydh) == common_file.common_app.get_suc)
            {
                if (GetjzOrgjToZz_helper_InsertToSzwzz_mx(lsbh_old, lsbh_new, krxm_old, krxm_new, fjbh_old, fjbh_new, "Szwmx", Zz_Type, czy, czsj, Zz_Type, yydh) == common_file.common_app.get_suc)
                {
                    s = common_file.common_app.get_suc;
                }
            }

            StringBuilder  strsql = new StringBuilder();
            strsql.Append("delete from  Sjzzd");
            strsql.Append("  where  lsbh='" + lsbh_old + "'  and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());

            strsql = new StringBuilder();
            strsql.Append("delete from Sjzmx");
            strsql.Append(" where  lsbh='" + lsbh_old + "'  and yydh='" + yydh + "'");
            B_common.ExecuteSql(strsql.ToString());

            return s;
        }

        //Szwmx,Syjcz两张表（更新一条写入一条到Szwzz_mx里面）
        private string GetjzOrgjToZz_helper_InsertToSzwzz_mx(string lshb_old, string lsbh_new, string krxm_old, string krxm_new, string fjbh_old, string fjbh_new, string Table_name,string Zz_Type, string czy, string czsj, string zzrx, string yydh)
        {
            string s = common_file.common_app.get_failure;
            DataSet ds = new DataSet();
            ds = B_common.GetList("SELECT * FROM  " + Table_name, " ID >0 AND  yydh='" + yydh + "'  and lsbh='" + lshb_old + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    int id_temp = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());

                    //Szwzz_mx添加
                    sb = new StringBuilder();
                    sb.Append("insert into  Szwzz_mx(yydh,qymc,old_lsbh,old_krxm,old_fjbh,id_app,xfxm,xfzy,xfbz,sjxfje,new_lsbh,new_krxm,new_fjbh,czy,czsj,zzrx)");
                    sb.Append("  select  yydh,qymc,'" + lshb_old + "','" + krxm_old + "','" + fjbh_old + "',id_app,xfxm,xfzy,xfbz,sjxfje,'" + lsbh_new + "','" + krxm_new + "','" + fjbh_new + "','" + czy + "','" + czsj + "','" + Zz_Type + "'  from " + Table_name);
                    sb.Append("  where   id=" + id_temp);
                    B_common.ExecuteSql(sb.ToString());

                    if (Table_name == "Szwmx")
                    {
                    sb.Append("update  " + Table_name + "   set   lsbh='" + lsbh_new + "',krxm='" + krxm_new + "',fjbh='" + fjbh_new + "',sktt='" + sk_tt_afterZZ + "',czzt='" + Zz_Type + "'  where  id="+id_temp);
                    }
                    if(Table_name=="Syjcz")
                    {
                    sb.Append("update  " + Table_name + "   set   lsbh='" + lsbh_new + "',krxm='" + krxm_new + "',fjbh='" + fjbh_new + "',sktt='" + sk_tt_afterZZ + "',xfzy='" + Zz_Type + "'  where  id="+id_temp);//写在押金摘要里面
                    }
                    B_common.ExecuteSql(sb.ToString());


                    s = common_file.common_app.get_suc;
                }
            }
            return s;
        }
    }
}
