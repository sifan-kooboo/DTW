using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Text;
using Hotel_app.common_file_server;

namespace Hotel_app.Server.Szwgl
{
    //此类处理记、挂以及算帐分结
    //CZZT    gzfj  jzfj  bfsz  (分结时账务更新不正确，why????????）
    public class Szw_jzOrgzOrszToFj
    {
        string jzbh = "";//生成结帐编号
        DataSet ds_temp = null;
        public string fkje = "";//付款大类的统计
        public string xfje = "";//所有消费的项目总和
        public string czzt_temp = "";//记/挂分结的时候，将czzt转变成 记挂分结

        public BLL.Szw_temp B_szw_temp = new Hotel_app.BLL.Szw_temp();
        public BLL.Common B_common = new Hotel_app.BLL.Common();
        public decimal fkje_temp = 0;
        public decimal xfje_temp = 0;
        StringBuilder strSql = new StringBuilder();

        //20110611更新
        string ddsj = "";
        string krxm_lz = "";
        string fjbh_lz = "";


        //string lsbh, string jjType, string sk_tt, string czy, string czsj, string syzd, string czy_bc, string fkje, string xfje, string xxzs,string yydh)
        public string GetjzOrgzOrszToFjResult(string lsbh, string czzt, string sk_tt, string czy, string czsj, string syzd, string czy_bc, string fkje, string xfje, string xxzs, string yydh, string jzbh_old, string czy_GUID)
        {
            string s = common_app.get_failure;
            if (!czzt.Equals(common_app.pljz_flage))
            {
                if (czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_jzzgz)
                {
                    jzbh = common_file.common_ddbh.ddbh("gzfj", "jzdate", "jzcounter", 6);
                }
                if (czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_gzzjz)
                {
                    jzbh = common_file.common_ddbh.ddbh("jzfj", "jzdate", "jzcounter", 6);
                }
                if (czzt == common_file.common_jzzt.czzt_bfsz)
                {
                    jzbh = common_file.common_ddbh.ddbh("bfsz", "jzdate", "jzcounter", 6);
                }
                if (jzbh.Trim() != "")
                {
                    ds_temp = B_szw_temp.GetList("id>0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'  and czy_temp='" + czy_GUID + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0) //有消费记录
                    {
                        //更新Szw_temp里面的对应记录的jzbh
                        StringBuilder sb = new StringBuilder();
                        sb.Append("update Szw_temp  set  jzbh='" + jzbh + "'  where id>=0  " + common_file.common_app.yydh_select + "    and czy_temp='" + czy_GUID + "'");
                        if (B_common.ExecuteSql(sb.ToString()) > 0)//修改成功
                        {
                            ds_temp = B_szw_temp.GetList("id>0  " + common_file.common_app.yydh_select + "   and czy_temp='" + czy_GUID + "'");
                            //common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["fjjg"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                            //计算出xfje和fkje
                            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                                {
                                    if (ds_temp.Tables[0].Rows[i]["xfxm"].ToString() == common_app.dj_ysk || ds_temp.Tables[0].Rows[i]["xfxm"].ToString() == common_app.dj_pzsk)
                                    {
                                        fkje_temp += decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds_temp.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                                    }
                                    else
                                    {
                                        xfje_temp += decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds_temp.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                                    }
                                }
                            }
                            //fkje
                            fkje = Math.Abs(fkje_temp).ToString();//最终的付款金额(用绝对值存储)

                            //xfje
                            xfje = xfje_temp.ToString();
                            //GetInfo_xydw(lsbh, yydh, sk_tt, czzt, ref xydw, ref krly);

                            //帐务操作处理
                            if (Pladd(lsbh, jzbh_old, sk_tt, jzbh, yydh, czsj, syzd, czy, czy_bc, czzt, fkje, xfje, xxzs, ds_temp, czy_GUID) == common_app.get_suc)
                            {
                                s = common_file.common_app.get_suc;
                            }
                        }
                    }
                }
            }
            if (czzt.Equals(common_app.pljz_flage))
            {
                if (Pladd(lsbh, jzbh_old, sk_tt, jzbh, yydh, czsj, syzd, czy, czy_bc, czzt, fkje, xfje, xxzs, ds_temp, czy_GUID) == common_app.get_suc)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            common_file.common_czjl.add_czjl(yydh, "", czy, lsbh + "下的帐务当前分结掉金额为:" + xfje_temp, "当前的分结状态为:" + czzt, "分结的结果为:" + s, DateTime.Now);
            return s;
        }

        /// 分结时的帐务处理
        /// 先写入Sjzzd，同时写sjzmx,Ffkfssz
        /// 写入成功后，将zwmx里面的对应的记录写入到zwmx_bak,并删除当前lsbh对应下的zwmx记录(jzzt 结帐主体  ,czzt  记帐分结，算帐分结，挂帐分结)
        public string Pladd(string lsbh, string jzbh_old, string sk_tt, string jzbh, string yydh, string czsj, string syzd, string czy, string czy_bc, string czzt, string fkje, string xfje, string xxzs, DataSet ds, string czy_GUID)
        {
            string s = common_app.get_failure;
            decimal fkje_temp = decimal.Parse(fkje);
            decimal xfje_temp = decimal.Parse(xfje);
            string xydw = "";//注意这里是开单时主单选择的，与jzzt不同
            string krly = "";//
            common_zw.GetxydwFromMainRecord(lsbh, jzbh_old, yydh, sk_tt, ref xydw, ref krly);
            bool flage = false;

            #region 记帐分结，挂帐分结
            if (czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_jzzgz || czzt == common_file.common_jzzt.czzt_gzzjz)//记/挂帐分结
            {
                //czzt_temp=(czzt==common_file.common_jzzt.czzt_gz)?(common_file.common_jzzt.czzt_gzfj):(common_file.common_jzzt.czzt_jzfj);
                if (czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_jzzgz)
                {
                    czzt_temp = common_file.common_jzzt.czzt_gzfj;
                }
                if (czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_gzzjz)
                {
                    czzt_temp = common_file.common_jzzt.czzt_jzfj;
                }
                //注意，由于会有多次分结，备份时采取的办法是,旧的一条保留，只是更新xf与fk,但新增一条带有jzbh_new的记录来记录当前的状态
                strSql = new StringBuilder();
                strSql.Append("insert into Sjzzd_bak(yydh,qymc,lsbh,jzbh,jzbh_new,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,is_top,is_select,fp_print,is_visible,ddsj,krxm_lz,fjbh_lz)");
                strSql.Append(" select  yydh,qymc,lsbh,jzbh,'" + jzbh + "',krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,0,0,fp_print,is_visible,ddsj,krxm_lz,fjbh_lz  from Sjzzd");
                strSql.Append("  Where  yydh='" + yydh + "'   and  jzbh='" + jzbh_old + "' ");
                B_common.ExecuteSql(strSql.ToString());

                strSql = new StringBuilder();
                strSql.Append("  update Sjzzd set  xfje=xfje-'" + xfje_temp + "'  where id>=0 and yydh='" + yydh + "' and lsbh='" + lsbh + "'  and  jzbh='" + jzbh_old + "' ");
                B_common.ExecuteSql(strSql.ToString());


                strSql = new StringBuilder();
                strSql.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,ddsj,krxm_lz,fjbh_lz,shys)");
                strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "','" + jzbh + "',krxm,sktt,fjbh,xyh,'" + xydw + "','" + krly + "',tfsj,'" + czsj + "','" + czy + "','" + czzt_temp + "',jzzt,'" + syzd + "','" + czzt_temp + "'," + fkje_temp + "," + xfje_temp + ",ddsj,krxm_lz,fjbh_lz,1  from Sjzzd");
                strSql.Append(" where lsbh='" + lsbh + "' and  yydh='" + yydh + "'  and   jzbh='" + jzbh_old + "' ");
                B_common.ExecuteSql(strSql.ToString());


                //备份Sjzmx（注意，id_app在Szw_temp里面的那些记录)
                strSql = new StringBuilder();
                strSql.Append("insert into  Sjzmx_bak(yydh,qymc,id_app,jzbh,jzbh_new,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,mxbh,tfsj)");
                strSql.Append("  select  yydh,qymc,id_app,jzbh,'" + jzbh + "',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,'" + czzt + "',czsj,syzd,xyh,jzzt,fkfs,is_top,is_select,is_visible,mxbh,tfsj  from Sjzmx  ");
                strSql.Append("  where     yydh='" + yydh + "'  and id_app  in (select id_app  from Szw_temp  where  yydh='" + yydh + "' and czy_temp='" + czy_GUID + "'  and  xfdr!='" + common_file.common_app.fkdr + "') ");
                B_common.ExecuteSql(strSql.ToString());

                B_common.ExecuteSql("  update  Sjzmx set jzbh='" + jzbh + "',czsj='" + czsj + "',czzt='" + czzt_temp + "',czy='" + czy + "'  where  id_app in (select id_app from Szw_temp   where  yydh='" + yydh + "' and jzbh='" + jzbh + "'   and czy_temp='" + czy_GUID + "')");


                DataSet ds_1 = B_common.GetList(" select * from Szw_temp ", " id>=0  and   yydh='" + yydh + "' and jzbh='" + jzbh + "'   and czy_temp='" + czy_GUID + "'");
                if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_1.Tables[0].Rows.Count; i++)
                    {
                        string temp = " delete from Szw_union  where   id>=0  and yydh='" + yydh + "' and union_bh in( select union_bh  from Szw_union   where    id_app='" + ds_1.Tables[0].Rows[i]["id_app"].ToString() + "')";
                        B_common.ExecuteSql(temp);
                    }
                }



                //备份分结的Szwmx记录(触发器)
                strSql = new StringBuilder();
                strSql.Append("  update Szwmx  set   jzbh='" + jzbh + "',czzt='" + czzt + "',czsj='" + czsj + "'  where   yydh='" + yydh + "' and  id_app in (select id_app from Szw_temp   where jzbh='" + jzbh + "'  and yydh='" + yydh + "'  and czy_temp='" + czy_GUID + "')");
                B_common.ExecuteSql(strSql.ToString());

                DataSet ds_gz_del = B_common.GetList(" select * from Szwmx  ", "  id>=0  and  yydh='" + yydh + "'  and     jzbh='" + jzbh + "'  and jzbh<>'' ");
                if (ds_gz_del != null && ds_gz_del.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_gz_del.Tables[0].Rows.Count; i++)
                    {
                        B_common.ExecuteSql(" delete from Szwmx where  id_app='" + ds_gz_del.Tables[0].Rows[i]["id_app"].ToString() + "'");
                    }
                }

                common_czjl.add_czjl(yydh, "", czy, "分结删除" + ds_gz_del.Tables[0].Rows.Count + "条记录", "分结编号:" + jzbh, "分结时对应的账务明细记录删除成功", DateTime.Parse(czsj));

                if (jzbh.Trim() != "")
                {
                    DataSet ds_0 = B_common.GetList(" select * from Sjzmx ", "id>=0  and  yydh='" + yydh + "' and jzbh='" + jzbh + "'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
                        {
                            if (ds_0.Tables[0].Rows[i]["xfdr"].ToString() != common_app.fkdr)
                            {
                                strSql = new StringBuilder();
                                strSql.Append(" update Szwzd_bak  set  xfje=xfje-'" + decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds_0.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()) + "'  where lsbh='" + ds_0.Tables[0].Rows[i]["lsbh"].ToString() + "' and yydh='" + yydh + "'");
                                B_common.ExecuteSql(strSql.ToString());
                            }
                        }
                    }
                }

                //更新Ssyxfmx里面id_app对应记录的jzbh(晚上修改,这里不能用lsbh作为条件,联账时会有些没有改到)
                strSql = new StringBuilder();
                strSql.Append(" update  Ssyxfmx set  jzbh='" + jzbh + "'   where   yydh='" + yydh + "' and  id_app  in (select  id_app from Szw_temp where jzbh='" + jzbh + "'  and yydh='" + yydh + "'  and czy_temp='" + czy_GUID + "')");
                B_common.ExecuteSql(strSql.ToString());

                //将平帐收款写入jzmx
                strSql = new StringBuilder();
                strSql.Append(" insert  into  Sjzmx(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,czy_bc,czzt,czsj,syzd,is_visible,xyh,jzzt,fkfs,mxbh)");
                strSql.Append(" select   yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'" + czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,shsc,'" + czy_bc + "','" + czzt_temp + "','" + czsj + "','" + syzd + "',0,'',krxm,fkfs,mxbh  from Szw_temp");
                strSql.Append(" where jzbh='" + jzbh + "'  and  czy_temp='" + czy_GUID + "'  and  xfxm='" + common_app.dj_pzsk + "'");
                B_common.ExecuteSql(strSql.ToString());

                //提取分结主单的xyh,jzzt,tfsj更新当前平账收款的信息
                DataSet ds_temp_00 = B_common.GetList("  SELECT * FROM  Sjzzd  ", " id>=0  and  lsbh='" + lsbh + "'  and  jzbh='" + jzbh_old + "'  ");
                if (ds_temp_00 != null && ds_temp_00.Tables[0].Rows.Count > 0)
                {
                    string tfsj = ds_temp_00.Tables[0].Rows[0]["tfsj"].ToString();
                    string xyh = ds_temp_00.Tables[0].Rows[0]["xyh"].ToString();
                    string jzzt = ds_temp_00.Tables[0].Rows[0]["jzzt"].ToString();
                    B_common.ExecuteSql("  update  Sjzmx  set  tfsj='" + tfsj + "',xyh='" + xyh + "',jzzt='" + jzzt + "'  where    jzbh='" + jzbh + "'  and  yydh='" + yydh + "' ");
                }



                strSql = new StringBuilder();
                strSql.Append("insert into Sfkfssz(yydh,qymc,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
                strSql.Append(" select yydh,qymc,'" + jzbh + "',krxm,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,'" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "',xfrq,xfsj,'" + czy + "',czy_bc,syzd,id_app  from  Sjzmx ");
                strSql.Append(" where lsbh='" + lsbh + "'  and czy='" + czy + "'  and  xfdr='" + common_app.fkdr + "' and  jzbh='" + jzbh + "'");
                B_common.ExecuteSql(strSql.ToString());


                flage = true;
            }
            #endregion

            #region 部分结帐
            if (czzt == common_file.common_jzzt.czzt_bfsz)
            {
                //备份Szwmx（注意，id_app在Szw_temp里面的那些记录--删除时通过触发器实现备份
                string s_temp_0 = "update  Szwmx  set  jzbh='" + jzbh + "',czzt='" + czzt + "'   where   yydh='" + yydh + "'  and id_app  in (select id_app from Szw_temp where  jzbh='" + jzbh + "' and     yydh='" + yydh + "'     and czy_temp='" + czy_GUID + "')";
                B_common.ExecuteSql(s_temp_0);

                //
                common_zw.GetJZinfo(ref  krxm_lz, ref  fjbh_lz, ref  ddsj, lsbh, yydh, sk_tt);

                strSql = new StringBuilder();
                strSql.Append("insert into Sjzzd(yydh,qymc,lsbh,jzbh,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,ddsj,krxm_lz,fjbh_lz,shys)");
                strSql.Append(" select top 1 yydh,qymc,'" + lsbh + "','" + jzbh + "',krxm,sktt,fjbh,'','','" + krly + "','" + czsj + "','" + czsj + "','" + czy + "','" + czzt + "',krxm,'" + syzd + "','" + czzt + "'," + fkje_temp + "," + xfje_temp + ",'" + ddsj + "','" + krxm_lz + "','" + fjbh_lz + "',1  from Qskyd_fjrb");
                strSql.Append(" where lsbh='" + lsbh + "' ");
                B_common.ExecuteSql(strSql.ToString());

                strSql = new StringBuilder();
                strSql.Append(" insert into Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj)");
                strSql.Append("  select yydh,qymc,id_app,'" + jzbh + "',lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,'" + czy + "',xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,'" + czy_bc + "','" + czzt + "','" + czsj + "','" + syzd + "','',krxm,fkfs,mxbh,'" + czsj + "'  from  Szw_temp  where    yydh='" + yydh + "' and czy_temp='" + czy_GUID + "'");
                B_common.ExecuteSql(strSql.ToString());

                //考虑联账的情形
                DataSet ds_0 = B_common.GetList(" select * from Flfsz", " id>=0  and yydh='" + common_app.yydh + "'  and lsbh='" + lsbh + "'  and shlz=1  ");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["xfdr"].ToString() != common_app.fkdr)
                        {
                            strSql = new StringBuilder();
                            strSql.Append(" update Szwzd  set  xfje=xfje-'" + decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()) + "'  where lsbh='" + ds.Tables[0].Rows[i]["lsbh"].ToString() + "' and yydh='" + yydh + "'");
                            B_common.ExecuteSql(strSql.ToString());
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["xfdr"].ToString() != common_app.fkdr)
                        {
                            strSql = new StringBuilder();
                            strSql.Append(" update Szwzd  set  xfje=xfje-'" + decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()) + "'  where lsbh='" + ds.Tables[0].Rows[i]["lsbh"].ToString() + "' and yydh='" + yydh + "'");
                            B_common.ExecuteSql(strSql.ToString());
                        }
                    }
                }

                strSql = new StringBuilder();
                strSql.Append("insert into Sfkfssz(yydh,qymc,is_top,is_select,jzbh,jzzt,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,xfje,sjxfje,czrq,czsj,xfrq,xfsj,czy,czy_bc,syzd,id_app)");
                strSql.Append(" select yydh,qymc,0,0,'" + jzbh + "',krxm,lsbh,fjbh,krxm,fkfs,xfdr,xfrb,xfxm,-xfje,-sjxfje,'" + DateTime.Parse(czsj).ToShortDateString() + "','" + czsj + "',xfrq,xfsj,czy,czy_bc,syzd,id_app  from  Sjzmx ");
                strSql.Append(" where lsbh='" + lsbh + "'  and czy='" + czy + "'  and  xfdr='" + common_app.fkdr + "' and  jzbh='" + jzbh + "'");
                B_common.ExecuteSql(strSql.ToString());

                DataSet ds_del = B_common.GetList(" select * from Szwmx ", " id>=0   and  yydh='" + yydh + "' and jzbh='" + jzbh + "'");
                if (ds_del != null && ds_del.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds_del.Tables[0].Rows.Count; i++)
                    {
                        B_common.ExecuteSql(" update Ssyxfmx set jzbh='" + jzbh + "' where yydh='" + yydh + "' and id_app='" + ds_del.Tables[0].Rows[i]["id_app"].ToString() + "' ");
                        B_common.ExecuteSql(" delete from Szwmx where yydh='" + yydh + "'  and  id_app='" + ds_del.Tables[0].Rows[i]["id_app"].ToString() + "' ");
                        B_common.ExecuteSql(" delete from Szw_zz_fj_temp where yydh='" + yydh + "'  and id_app='" + ds_del.Tables[0].Rows[i]["id_app"].ToString() + "' ");
                    }
                }

                flage = true;
            }
            #endregion

            #region AddSolution_挂账批结分部结账功能
            if (czzt.Equals(common_app.pljz_flage))
            {
                if (!jzbh_old.Trim().Equals(""))
                {
                    //统计消费、付款
                    xfje_temp = decimal.Parse(DbHelperSQL.GetSingle("select  ISnull(sum(sjxfje),0)  from  Szw_temp  where  jzbh='" + jzbh_old + "' and  czy_temp='" + czy_GUID + "' and  yydh='" + yydh + "' and  xfdr!='"+common_app.fkdr+"'   ").ToString());
                    fkje_temp = decimal.Parse(DbHelperSQL.GetSingle(" select  ISnull(sum(sjxfje),0)  from Szw_temp  where jzbh='" + jzbh_old + "'  and  czy_temp='" + czy_GUID + "' and  yydh='" + yydh + "' and  xfdr='" + common_app.fkdr + "'   ").ToString());

                    strSql = new StringBuilder();
                    strSql.Append("insert into Sjzzd_bak(yydh,qymc,lsbh,jzbh,jzbh_new,krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,is_top,is_select,fp_print,is_visible,ddsj,krxm_lz,fjbh_lz)");
                    strSql.Append(" select  yydh,qymc,lsbh,jzbh,'" + jzbh + "',krxm,sktt,fjbh,xyh,xydw,krly,tfsj,czsj,czy,czzt,jzzt,syzd,bz,fkje,xfje,0,0,fp_print,is_visible,ddsj,krxm_lz,fjbh_lz  from Sjzzd");
                    strSql.Append("  Where  yydh='" + yydh + "'   and  jzbh='" + jzbh_old + "' ");
                    B_common.ExecuteSql(strSql.ToString());

                    strSql = new StringBuilder();
                    strSql.Append("  update Sjzzd set  xfje=xfje-'" + xfje_temp + "',fkje=fkje-'"+fkje_temp+"'  where id>=0 and yydh='" + yydh + "'  and  jzbh='" + jzbh_old + "' ");
                    B_common.ExecuteSql(strSql.ToString());

                    //更新jzmx与删除Szwmx中对应的记录
                    B_common.ExecuteSql("  update  Sjzmx set jzbh='" + lsbh + "',czsj='" + czsj + "',czzt='" + common_jzzt.czzt_gzzsz + "',czy='" + czy + "'  where  id_app in (select id_app from Szw_temp   where  yydh='" + yydh + "' and jzbh='" + jzbh_old + "'   and czy_temp='" + czy_GUID + "')");
                    B_common.ExecuteSql("  update Ssyxfmx set jzbh='" + lsbh + "',czsj='" + czsj + "',czy='" + czy + "'  where  id_app in (select id_app from Szw_temp   where  yydh='" + yydh + "' and jzbh='" + jzbh_old + "'   and czy_temp='" + czy_GUID + "')");
                    B_common.ExecuteSql("  delete from Szwmx  where    jzbh='" + jzbh_old + "'   and    yydh='" + yydh + "' and  id_app in (select id_app from Szw_temp   where jzbh='" + jzbh_old + "'  and yydh='" + yydh + "'  and czy_temp='" + czy_GUID + "')");
                    B_common.ExecuteSql(" delete from Syjcz where jzbh='" + jzbh_old + "' and  id_app   in (select  id_app  from Szw_temp  where jzbh='" + jzbh_old + "'  and yydh='" + yydh + "' and  czy_temp='" + czy_GUID + "') ");
                    flage = true;
                }
 
            }
            #endregion

            //清除临时数据
            if (!czzt.Equals(common_app.pljz_flage))
            {
                if ((flage == true) && (GetJzResult(lsbh, jzbh, czzt, sk_tt, czy, czsj, czy_GUID) == common_app.get_suc))
                { s = common_app.get_suc; }
                string cznr = "这个主单的帐务进行了分结操作";
                string qymc = "";
                common_file.common_czjl.add_czjl(yydh, qymc, czy, cznr, "", "", DateTime.Now);
            }
            if (czzt.Equals(common_app.pljz_flage))
            {
                if ((flage == true) && (GetJzResult(lsbh, jzbh, czzt, sk_tt, czy, czsj, czy_GUID) == common_app.get_suc))
                {
                    { s = common_app.get_suc; }
                    string cznr = czzt;
                    string qymc = "";
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, cznr, "", "", DateTime.Now);
                }
            }
            return s;
        }

        //删除临时数据（分结完成后)
        public string GetJzResult(string lsbh, string jzbh, string czzt, string sk_tt, string czy, string czsj, string czy_GUID)
        {
            string s = common_app.get_failure;
            //记.挂.算 分结的处理节
            if (czzt == common_file.common_app.pljz_flage||czzt == common_file.common_jzzt.czzt_bfsz || czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_gzzjz || czzt == common_file.common_jzzt.czzt_jzzgz)//算帐
            {
                //结帐成功后一定要删除分结表里面的数据（注意操作员,union表里面的数据,暂时保留,撤消时可以用到)
                strSql = new StringBuilder();
                strSql.Append("delete from Szw_zz_fj_temp  where id>=0  " + common_file.common_app.yydh_select + "   and czy='" + czy_GUID + "'");
                B_common.ExecuteSql(strSql.ToString());

                strSql = new StringBuilder();
                strSql.Append(" insert into Szw_temp_bak(yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,jjje,xfje,yh,sjxfje,xfsl,shsc,mxbh,czsj,czy_temp)");
                strSql.Append(" select yydh,qymc,is_top,is_select,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,fkfs,jjje,xfje,yh,sjxfje,xfsl,shsc,mxbh,czsj,czy_temp  from Szw_temp");
                strSql.Append("  where czy_temp='" + czy_GUID + "'   and xfxm!='" + common_app.dj_pzsk + "'");
                B_common.ExecuteSql(strSql.ToString());

                //清除temp前先清除掉uinion表中的数据
                DataSet ds444 = B_common.GetList(" select   *  from  Szw_temp  ", " id>=0  and    yydh='" + common_app.yydh + "'   and czy_temp='" + czy_GUID + "'");
                {
                    if (ds444 != null && ds444.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds444.Tables[0].Rows.Count; i++)
                        {
                            DataSet ds555 = B_common.GetList(" select * from Szw_union  ", " id>=0  and  id_app='" + ds444.Tables[0].Rows[i]["id_app"].ToString() + "'  ");
                            if (ds555 != null && ds555.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds555.Tables[0].Rows.Count; j++)
                                {
                                    string tempUnionBh = ds555.Tables[0].Rows[j]["union_bh"].ToString();
                                    B_common.ExecuteSql(" delete from  Szw_union  where  union_bh='" + tempUnionBh + "' ");
                                }
                            }
                        }
                    }
                }

                //清除Szw_temp
                if (!czzt.Equals(common_app.pljz_flage))
                {
                    strSql = new StringBuilder();
                    strSql.Append("delete from Szw_temp  where  id>=0  " + common_app.yydh_select + "   and czy_temp='" + czy_GUID + "'");
                    B_common.ExecuteSql(strSql.ToString()); //清除Szw_temp里面的数据了
                }

                //结帐成功后,更新会员的积分(挂-结，记-结，部分结，结帐都要加积分
                if ((czzt == common_jzzt.czzt_bfsz) || (czzt == common_jzzt.czzt_gz) || (czzt == common_jzzt.czzt_jz))
                {
                    //有启用时才增加

                    //IncHYScore(jzbh,lsbh, sk_tt);
                }
                s = common_file.common_app.get_suc;

            }
            return s;
        }
    }
}
