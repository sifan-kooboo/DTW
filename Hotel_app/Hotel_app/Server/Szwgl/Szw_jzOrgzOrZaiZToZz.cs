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

namespace Hotel_app.Server.Szwgl
{
    //此类是处理挂/记 To   转帐的
    public class Szw_jzOrgzOrZaiZToZz
    {
        Model.Qskyd_mainrecord M_Qskyd_mainrecord;
        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        Model.Qskyd_mainrecord_bak M_Qskyd_mainrecord_bak;
        BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();

        Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        Model.Qttyd_mainrecord_bak M_Qttyd_mainrecord_bak;
        BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();

        BLL.Sjzzd B_sjjzd = new Hotel_app.BLL.Sjzzd();
        BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        BLL.Common B_common = new Hotel_app.BLL.Common();

        string krxm_old = "";
        string krxm_new = "";
        
        string fjbh_old = "";
        string fjbh_new = "";

        string sktt_old="";
        string sktt_new="";

        string fjrb_new = "";//转帐后要更新Ssyxfmx里面的这个值

        decimal xfje_zz = 0;//转到新的lsbh时的消费金额
        decimal fkje_zz = 0;//转到新的lsbh时的付款金额

        StringBuilder strsql;
         
        //新增一个转账的标识符(由于存在账务转来转去的情况，当同一笔账有多次转的时候，会造成无法分析情况
        //生成一个临时码+转账时的时间来标识出来，放在zy字段里面来区分
        string   zz_lsbh="";//common_file.common_ddbh.ddbh("zwzz","jzdate","jzcounter",6)+DateTime.Now.ToString();

        //jzbh = common_file.common_ddbh.ddbh("szcz", "jzdate", "jzcounter", 6)

        public string GetjzOrgzOrZaizToZzResult(string lsbh_old,string jzbh_old, string lsbh_new, string sk_tt, string Zz_Type, string yydh, string czy, string czy_bc, string czsj, string syzd, string xxzs,string qymc,string  czy_GUID)
        {
            //lsbh_new和lsbh_old在前台去判断(old是转前的lsbh,new是帐务转到的lsbh
            //Zz_Type  是指转的类型 （从帐务转进来有：jz-tt,jz-sk;gz-tt,gz-sk  sk-sk,sk-tt,tt-sk,tt-tt(后面四种是针对在住转在住的）
            //sk_tt   是指转帐的主体是散客还是团体(lsbh_old类型,sk  or  tt）
            //注意，记、挂的帐务在Szwmx和Syjcz里面都记录的相关内容

            string s = common_file.common_app.get_failure;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_gz_tt || Zz_Type == common_zw.zwzz_jz_sk || Zz_Type == common_zw.zwzz_jz_tt)
            {

            }
            //在住类型的转帐(要转的帐务在Szw_zz_fj_temp里面)
            //if (Zz_Type == common_zw.zwzz_sk_sk || Zz_Type == common_zw.zwzz_sk_tt || Zz_Type == common_zw.zwzz_tt_sk || Zz_Type == common_zw.zwzz_tt_tt)
            //{
            //    ////先备份Szwmx到BAK中,
            //    //strsql = new StringBuilder();
            //    //strsql.Append("insert into  Szwmx_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
            //    //strsql.Append(" select yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,xfje,yh,sjxfje,xfsl,shsc,czy_bc,'" + Zz_Type + "',czsj,syzd,is_visible,mxbh  from Szwmx");
            //    //strsql.Append("  where  lsbh='" + lsbh_old + "'  and yydh='" + yydh + "'  and  id_app  in (select  id_app  from Szw_zz_fj_temp where lsbh='" + lsbh_old + "'  and czy='" + czy + "') ");
            //    //B_common.ExecuteSql(strsql.ToString());//备份在Szw_zz_fj_temp这个表里面出现的Szwmx的记录，要转到lsbh_new的
            //}
            if (GetjzOrgzOrZaiZToZz_helper(lsbh_old,jzbh_old, lsbh_new, sk_tt, Zz_Type, yydh, czy, czy_bc, czsj, syzd, xxzs,czy_GUID) == common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_suc;
            }
            common_file.common_czjl.add_czjl(yydh,qymc,czy,"当前帐务由:" + lsbh_old + "转到:" + lsbh_new + "名下", Zz_Type, Zz_Type+"转帐结果为:"+s,Convert.ToDateTime(czsj));
            return s;
        }

        private string GetjzOrgzOrZaiZToZz_helper(string lsbh_old, string jzbh_old, string lsbh_new, string sk_tt, string Zz_Type, string yydh, string czy, string czy_bc, string czsj, string syzd, string xxzs, string czy_GUID)//对GetjzOrgjToZz方法的辅助方法
        {
            //对每个表(Sjzzd,Sjzmx，循环查找，删除Sjzzd,Sjzmx里面的记录,将记录加到
            //Sjzzd
            string s = common_file.common_app.get_failure;
            DataSet ds_temp = new DataSet();
            zz_lsbh = common_file.common_ddbh.ddbh("zwzz", "jzdate", "jzcounter", 6);
            #region 获取转入的团体或者散客的信息（krxm_new,fjbh_new)
            //转向散客
            if (Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_jz_sk || Zz_Type == common_zw.zwzz_sk_sk || Zz_Type == common_zw.zwzz_tt_sk)
            {
                ds_temp = B_Qskyd_fjrb.GetList("id>0 and yydh='" + yydh + "' and lsbh='" + lsbh_new + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    krxm_new = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                    fjbh_new = ds_temp.Tables[0].Rows[0]["fjbh"].ToString();
                    fjrb_new = ds_temp.Tables[0].Rows[0]["fjrb"].ToString();
                    sktt_new=ds_temp.Tables[0].Rows[0]["sktt"].ToString();
                }
            }
            //转向团体（fjbh为空)
            if (Zz_Type == common_zw.zwzz_jz_tt || Zz_Type == common_zw.zwzz_gz_tt || Zz_Type == common_zw.zwzz_sk_tt || Zz_Type== common_zw.zwzz_tt_tt)
            {
                ds_temp = B_Qttyd_mainrecord.GetList("id>0 and yydh='" + yydh + "' and lsbh='" + lsbh_new + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    krxm_new = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                    fjbh_new = "";
                    fjrb_new = "";//团体没有房间类别
                    sktt_new=ds_temp.Tables[0].Rows[0]["sktt"].ToString();
                }
            }
            #endregion

            #region 转帐时旧获取旧的信息(krxm_old,fjbh_old)
            //挂或者记帐转帐旧的信息的获取
            if (Zz_Type == common_zw.zwzz_jz_sk || Zz_Type == common_zw.zwzz_jz_tt || Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_gz_tt)
            {
                Model.Sjzzd M_Sjzzd = B_sjjzd.GetModelList("id>0 and yydh='" + yydh + "' and lsbh='" + lsbh_old + "'  and jzbh='"+jzbh_old+"'")[0];
                krxm_old = M_Sjzzd.krxm;
                fjbh_old = M_Sjzzd.fjbh;
                sktt_old=M_Sjzzd.sktt;
            }
            //在住类型的转帐旧的信息的获取
            if (Zz_Type == common_zw.zwzz_sk_sk || Zz_Type == common_zw.zwzz_sk_tt || Zz_Type == common_zw.zwzz_tt_sk || Zz_Type == common_zw.zwzz_tt_tt)
            {
                //散客类型转
                if (Zz_Type == common_zw.zwzz_sk_sk || Zz_Type == common_zw.zwzz_sk_tt)
                {
                    ds_temp = new DataSet();
                    ds_temp = B_common.GetList("select krxm,fjbh from View_Qskzd", "  lsbh='" + lsbh_old + "' and  yydh='" + yydh + "'");
                    if (ds_temp != null&&ds_temp.Tables[0].Rows.Count>0)
                    {
                        krxm_old = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                        fjbh_old = ds_temp.Tables[0].Rows[0]["fjbh"].ToString();
                    }
                }
                //团体类型转
                if (Zz_Type == common_zw.zwzz_tt_sk || Zz_Type == common_zw.zwzz_tt_tt)
                {
                    ds_temp = new DataSet();
                    ds_temp = B_common.GetList("select krxm from View_Qttzd", "  lsbh='" + lsbh_old + "' and  yydh='" + yydh + "'");
                    if (ds_temp != null&&ds_temp.Tables[0].Rows.Count>0)
                    {
                        krxm_old = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                        fjbh_old = "";//团体房号为空
                    }
                }
            }
            #endregion

            #region              //挂记帐类型执行的操作
            if (Zz_Type == common_zw.zwzz_jz_sk || Zz_Type == common_zw.zwzz_jz_tt || Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_gz_tt)
            {
                if (GetjzOrgjToZz_helper_InsertToSzwzz_mx(lsbh_old, jzbh_old, lsbh_new, krxm_old, krxm_new, fjbh_old, fjbh_new, "Syjcz", Zz_Type, czy, czsj, Zz_Type, yydh, zz_lsbh, czy_GUID) == common_file.common_app.get_suc)
                {
                    if (GetjzOrgjToZz_helper_InsertToSzwzz_mx(lsbh_old, jzbh_old, lsbh_new, krxm_old, krxm_new, fjbh_old, fjbh_new, "Szwmx", Zz_Type, czy, czsj, Zz_Type, yydh, zz_lsbh, czy_GUID) == common_file.common_app.get_suc)
                    {
                        //jzzd到bak，备份jzmx到bak ，备份押金操作到bak
                        //删除jzmx及jzzd里面的数据
                        //更新Ssyxfmx及Ssyxfmx里面的lsbh
                        //更新转入的Szwzd里面的xfje和fkje

                        //获取转帐的金额
                        if (Zz_Type == common_zw.zwzz_jz_sk || Zz_Type == common_zw.zwzz_jz_tt || Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_gz_tt)
                        {
                            ds_temp = B_common.GetList("select *  from Sjzzd ", " id>0 and yydh='" + yydh + "'    and jzbh='"+jzbh_old + "'");
                            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                            {
                                xfje_zz = decimal.Parse(ds_temp.Tables[0].Rows[0]["xfje"].ToString());
                                fkje_zz = decimal.Parse(ds_temp.Tables[0].Rows[0]["fkje"].ToString());
                            }
                        }
                        string Zz_Type_temp = "";//备份时主单及明细的状态
                        if (Zz_Type == common_zw.zwzz_jz_sk || Zz_Type == common_zw.zwzz_jz_tt)
                        {
                            Zz_Type_temp = common_file.common_jzzt.czzt_jzzzz;
                        }
                        if (Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_gz_tt)
                        {
                            Zz_Type_temp = common_file.common_jzzt.czzt_gzzzz;
                        }
                        strsql = new StringBuilder();//备份jzzd--jzzd_bak
                        strsql.Append("insert into  sjzzd_bak(yydh,qymc,jzbh,jzbh_new,lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,czzt,xyh,jzzt,sdcz,syzd,bz,fp_print,is_visible,fkje,xfje,ddsj,krxm_lz,fjbh_lz)");
                        strsql.Append("select yydh,qymc,jzbh,'',lsbh,is_top,is_select,krxm,sktt,fjbh,xydw,krly,tfsj,czsj,czy,'" + Zz_Type_temp + "',xyh,jzzt,sdcz,syzd,'" + "帐务由lsbh:" + lsbh_old + "通过:" + Zz_Type + "方式转到lsbh:" + lsbh_new + "',fp_print,is_visible,fkje,xfje,ddsj,krxm_lz,fjbh_lz  from  sjzzd");
                        strsql.Append(" where  lsbh='" + lsbh_old + "' and  jzbh='"+jzbh_old+"'  and yydh='" + yydh + "'");
                        B_common.ExecuteSql(strsql.ToString());

                        strsql = new StringBuilder();//备份jzmx--jzmx_bak
                        strsql.Append("insert into sjzmx_bak(yydh,qymc,is_top,is_select,id_app,jzbh,jzbh_new,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj)");
                        strsql.Append("select yydh,qymc,is_top,is_select,id_app,jzbh,'',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,'" + Zz_Type_temp + "','" + czsj + "',syzd,is_visible,xyh,jzzt,fkfs,mxbh,tfsj  from sjzmx");
                        strsql.Append(" where   yydh='" + yydh + "'  and jzbh='" +jzbh_old  + "'");
                        B_common.ExecuteSql(strsql.ToString());

                        //更新收银消费明细里面的临时编号到new
                        strsql = new StringBuilder();
                        strsql.Append("update  Ssyxfmx set  lsbh='" + lsbh_new + "',jzbh=''   where  id>=0   and jzbh='" + jzbh_old + "'  and yydh='" + yydh + "'");
                        B_common.ExecuteSql(strsql.ToString());

                        //更新转入的LSBH对应Szwzd的消费和付款金额
                        strsql = new StringBuilder();
                        strsql.Append("update Szwzd set  xfje=xfje+" + xfje_zz + ",fkje=fkje+" + fkje_zz + "  where id>=0 and lsbh='" + lsbh_new + "' and yydh='" + yydh + "'");
                        B_common.ExecuteSql(strsql.ToString());

                        strsql = new StringBuilder();
                        strsql.Append("delete from  Sjzzd");
                        strsql.Append("  where  lsbh='" + lsbh_old + "' and jzbh='"+jzbh_old+"'  and yydh='" + yydh + "'");
                        B_common.ExecuteSql(strsql.ToString());

                        strsql = new StringBuilder();
                        strsql.Append("delete from Sjzmx");
                        strsql.Append(" where   jzbh='"+jzbh_old+"'  and yydh='" + yydh + "'");
                        B_common.ExecuteSql(strsql.ToString());

                        s = common_file.common_app.get_suc;
                    }
                }
            }


            #endregion


            #region //在住类型执行的操作
            if (Zz_Type == common_zw.zwzz_sk_sk || Zz_Type == common_zw.zwzz_sk_tt || Zz_Type == common_zw.zwzz_tt_sk || Zz_Type == common_zw.zwzz_tt_tt)
            {
                if (GetjzOrgjToZz_helper_InsertToSzwzz_mx(lsbh_old,jzbh_old, lsbh_new, krxm_old, krxm_new, fjbh_old, fjbh_new, "Szwmx", Zz_Type, czy, czsj, Zz_Type, yydh,zz_lsbh,czy_GUID) == common_file.common_app.get_suc)
                {
                    //在住的转帐(更新两边的Szwzd的消费金额)
                    //更新转入的LSBH对应Szwzd的消费和付款金额
                    strsql = new StringBuilder();
                    strsql.Append("update Szwzd set  xfje=xfje+" + xfje_zz + ",fkje=fkje+" + fkje_zz + "  where id>=0 and lsbh='" + lsbh_new + "' and yydh='" + yydh + "'");
                    B_common.ExecuteSql(strsql.ToString());

                    strsql = new StringBuilder();
                    strsql.Append("update Szwzd set  xfje=xfje-(" + xfje_zz + "),fkje=fkje-(" + fkje_zz + ")   where id>=0 and lsbh='" + lsbh_old + "' and yydh='" + yydh + "'");
                    B_common.ExecuteSql(strsql.ToString());


                    //更新收银消费明细里面的临时编号到new(注意,只能更新在Szw_zz_fj_temp里面的记录)
                    strsql = new StringBuilder();
                    strsql.Append("update  Ssyxfmx set  lsbh='" + lsbh_new + "',jzbh=''  where  id>=0  and  id_app  in (select id_app from Szw_zz_fj_temp where  lsbh='" + lsbh_old + "'  and  yydh='" + yydh + "')");
                    B_common.ExecuteSql(strsql.ToString());

                    //最后，删除Szw_zz_fj_temp,以及Szw_temp里面的临时数据
                    strsql = new StringBuilder();
                    strsql.Append("  delete from  Szw_zz_fj_temp   where  lsbh='" + lsbh_old + "'  and  yydh='" + yydh + "'");
                    B_common.ExecuteSql(strsql.ToString());

                    strsql = new StringBuilder();
                    strsql.Append(" delete from Szw_temp where lsbh='" + lsbh_old + "'  and yydh='" + yydh + "'");
                    B_common.ExecuteSql(strsql.ToString());

                    s = common_file.common_app.get_suc;
                }
            }
            #endregion

            if (s == common_file.common_app.get_suc)
            {
                DataSet ds_0 = B_common.GetList(" select * from Szwzz_mx ", " id>=0  and  yydh='" + yydh + "' and xfzy='" + zz_lsbh + "'");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
			{
                B_common.ExecuteSql(" delete from Szw_union  where id>=0 and yydh='" + yydh + "'  and  union_bh in (select union_bh from Szw_union where id_app='" + ds_0.Tables[0].Rows[i]["id_app"].ToString()+"')");

			}
                }
            }

            return s;
            
        }

        //记挂--转帐会关系到:Sjzzd,Szwmx,Syjcz,Szwzd三张表的备份,以及要更新Ssyxfmx,Ssyxfmx_cz里面的lsbh（更新一条写入一条到Szwzz_mx里面）
        //在住--转帐会关系到:Szwmx,

        private string GetjzOrgjToZz_helper_InsertToSzwzz_mx(string lsbh_old,string jzbh_old, string lsbh_new, string krxm_old, string krxm_new, string fjbh_old, string fjbh_new, string Table_name, string Zz_Type, string czy, string czsj, string zzrx, string yydh,string zz_lsbh,string  czy_GUID)
        {
            BLL.Common B_common = new Hotel_app.BLL.Common();
            string s = common_file.common_app.get_failure;
            DataSet ds = new DataSet();
            //记、挂的转帐处理的过程
            //由于记挂帐的转帐是整笔全部转走，所以过程为
            //备份Szwmx到bak 备份  
            //更新Szwmx里面的lsbh，置jzbh为空
            //更新Syjcz里面的lsbh，置jzbh为空 

            //记、挂的转帐要处理的数据
            if (Zz_Type == common_zw.zwzz_jz_sk || Zz_Type == common_zw.zwzz_jz_tt || Zz_Type == common_zw.zwzz_gz_sk || Zz_Type == common_zw.zwzz_gz_tt)
            {
                //ds = B_common.GetList("SELECT * FROM  " + Table_name, " ID >0 AND  yydh='" + yydh + "'  and lsbh='" + lsbh_old + "' and  jzbh='"+jzbh_old+"' ");
                ds = B_common.GetList("SELECT * FROM  " + Table_name, " ID >0 AND  yydh='" + yydh + "'   and  jzbh='" + jzbh_old + "' ");

            }

            //在住的转帐要处理的数据（只写当前在Szw_zz_fj_temp里面的有关
            if (Zz_Type == common_zw.zwzz_sk_sk || Zz_Type == common_zw.zwzz_sk_tt || Zz_Type == common_zw.zwzz_tt_sk || Zz_Type == common_zw.zwzz_tt_tt)
            {
                ds = B_common.GetList("select  *  from  " + Table_name, "id>0 and yydh='" + yydh + "'  and lsbh='" + lsbh_old + "'  and id_app in(select id_app from  Szw_zz_fj_temp where lsbh='" + lsbh_old + "' and czy='" + czy_GUID + "')");
                xfje_zz = 0;
                fkje_zz = 0;//注意：在住转的付款金额为0;
            }

            //第一步---向Szwzz_mx添加
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        int id_temp = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                        if (Table_name == "Szwmx")
                        {
                            xfje_zz += decimal.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString());//如果是帐务记录累加到消费金额
                        }
                        if (Table_name == "Syjcz")
                        {
                            fkje_zz += decimal.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString());//是押金的记录累加到fkje
                        }
                        //向Szwzz_mx添加
                        sb = new StringBuilder();
                        sb.Append("insert into  Szwzz_mx(yydh,qymc,old_lsbh,old_krxm,old_fjbh,id_app,xfxm,xfzy,xfbz,sjxfje,new_lsbh,new_krxm,new_fjbh,czy,czsj,zzrx)");
                        sb.Append("  select  yydh,qymc,'" + lsbh_old + "','" + krxm_old + "','" + fjbh_old + "',id_app,xfxm,'"+zz_lsbh+"',xfbz,sjxfje,'" + lsbh_new + "','" + krxm_new + "','" + fjbh_new + "','" + czy + "','" + czsj + "','" + Zz_Type + "'  from " + Table_name);
                        sb.Append("  where   id=" + id_temp);
                        B_common.ExecuteSql(sb.ToString());

                        if (Table_name == "Szwmx")
                        {
                            sb = new StringBuilder();//备份到 Szwmx_bak
                            sb.Append("insert into  Szwmx_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh)");
                            sb.Append(" select yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,mxbh  from  Szwmx");
                            sb.Append("  where  id=" + id_temp);
                            B_common.ExecuteSql(sb.ToString());

                            //更新到新的(lsbh)
                            sb = new StringBuilder();
                            sb.Append("update  " + Table_name + "   set   lsbh='" + lsbh_new + "',jzbh='',sktt='"+sktt_new+"',czy='"+czy+"',czsj='"+czsj+"',czzt='"+common_file.common_yddj.yddj_dj+"' where  id=" + id_temp);
                            B_common.ExecuteSql(sb.ToString());
                        }
                        if (Table_name == "Syjcz")
                        {
                            sb = new StringBuilder();//先备份押金
                            sb.Append(" insert into Syjcz_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt)");
                            sb.Append("  select   yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,xfje,sjxfje,czy_bc,shsc,syzd,czzt   from  Syjcz");
                            sb.Append("  where id=" + id_temp);
                            B_common.ExecuteSql(sb.ToString());
                            sb = new StringBuilder();//更新押金信息
                            sb.Append("update  " + Table_name + "   set   lsbh='" + lsbh_new + "',xfzy='" + Zz_Type + "',jzbh='',sktt='"+sktt_new+"',czzt='',czy='"+czy+"'  where  id=" + id_temp);//写在押金摘要里面
                            B_common.ExecuteSql(sb.ToString());
                        }
                    }
                    s = common_file.common_app.get_suc;
                }
                catch
                {
                    s = common_file.common_app.get_failure;
                }
            }
            else
            {
                //没有任何数据时,直接返回true
                s = common_file.common_app.get_suc;
            }
            return s;
        }
    }
}
