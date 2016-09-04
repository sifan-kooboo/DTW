using System;
using System.Data;
using System.Configuration;
using System.Text;
using Maticsoft.DBUtility;
using System.Collections.Generic;
namespace Hotel_app.Server.Szwgl
{
    public class Szwmx
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zd_id"></param>用来查找sk、tt主单ID，
        /// <param name="sktt"></param>sk、tt如果是散客、长住、钟点、团体成员、会议成员传SK;如果团体、会议传tt; 
        /// <param name="old_id_app"></param>
        /// 如果是复制、拆账、冲账、补账时，同条消费记录,有一部分记录的信息可从旧的这条记录去读取，像拆账时一条拆成两条时就要用到，拆账时还要记得Szw_union这张表要像联房那样做一下记录！如果没有旧的记录参照，就把这个参数放空“”
        /// 如果old_id_app有传值时，zd_id为“”，sktt为“”
        /// 
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="id_app"></param>
        /// <param name="jzbh"></param>
        /// <param name="xfrq"></param>
        /// <param name="xfsj"></param>
        /// <param name="czy"></param>
        /// <param name="xfdr"></param>
        /// <param name="xfrb"></param>
        /// <param name="xfxm"></param>
        /// <param name="xfbz"></param>
        /// <param name="xfzy"></param>
        /// <param name="xfje"></param>
        /// <param name="yh"></param>
        /// <param name="sjxfje"></param>
        /// <param name="xfsl"></param>
        /// <param name="czy_bc"></param>
        /// <param name="czzt"></param>
        /// <param name="czsj"></param>
        /// <param name="syzd"></param>
        /// <param name="add_edit_delete"></param>
        /// <param name="xxzs"></param>
        /// <param name="jjje"></param>
        /// <returns></returns>
        public string Szwmx_add_edit(string zd_id, string sk_tt, string old_id_app, string yydh, string qymc, string id_app,
        string xfrq, string xfsj, string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string xfje, string yh, string sjxfje, string xfsl,
        string czy_bc, string czzt, string czsj, string syzd, string add_edit_delete, string xxzs, string jjje, string fjrb, string fjbh, string mxbh, string ddsj, string lksj)
        {
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            Model.Qskyd_fjrb M_Qskyd_fjrb;
            Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Hotel_app.Model.Qskyd_mainrecord();
            Model.Qttyd_mainrecord M_Qttyd_mainrecord = new Hotel_app.Model.Qttyd_mainrecord();

            BLL.Common B_common = new Hotel_app.BLL.Common();
            StringBuilder strsql;
            string xydw = "";

            string s = common_file.common_app.get_failure;
            BLL.Szwmx B_Szwmx = new Hotel_app.BLL.Szwmx();
            Model.Szwmx M_Szwmx = new Hotel_app.Model.Szwmx();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                //zd_id,sktt,old_id_app,yydh,qymc,id_app,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,xfje
                //yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,add_edit_delete,xxzs,jjje
                if (old_id_app == "")
                {
                    if (sk_tt == "sk")
                    {
                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(zd_id));
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("lsbh='" + M_Qskyd_mainrecord.lsbh + "'")[0];
                        M_Szwmx.lsbh = M_Qskyd_mainrecord.lsbh;
                        M_Szwmx.krxm = M_Qskyd_mainrecord.krxm;
                        M_Szwmx.fjrb = M_Qskyd_fjrb.fjrb;
                        M_Szwmx.fjbh = M_Qskyd_fjrb.fjbh;
                        M_Szwmx.sktt = M_Qskyd_mainrecord.sktt;
                        //xydw = M_Qskyd_mainrecord.xydw;
                    }
                    if (sk_tt == "tt")
                    {
                        M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(zd_id));
                        M_Szwmx.lsbh = M_Qttyd_mainrecord.lsbh;
                        M_Szwmx.krxm = M_Qttyd_mainrecord.krxm;
                        M_Szwmx.fjrb = fjrb;
                        M_Szwmx.fjbh = fjbh;
                        M_Szwmx.sktt = M_Qttyd_mainrecord.sktt;
                        //xydw = M_Qttyd_mainrecord.xydw;
                    }
                    M_Szwmx.yydh = yydh;
                    M_Szwmx.qymc = qymc;
                    M_Szwmx.id_app = id_app;
                    M_Szwmx.jzbh = ""; //新增为空
                    M_Szwmx.xfrq = Convert.ToDateTime(xfrq);
                    M_Szwmx.xfsj = Convert.ToDateTime(xfsj);
                    M_Szwmx.czy = czy;
                    M_Szwmx.xfdr = xfdr;
                    M_Szwmx.xfrb = xfrb;
                    M_Szwmx.xfxm = xfxm;
                    M_Szwmx.xfbz = xfbz;
                    M_Szwmx.xfzy = xfzy;
                    M_Szwmx.xfje = Convert.ToDecimal(xfje);
                    M_Szwmx.yh = yh;
                    M_Szwmx.sjxfje = Convert.ToDecimal(sjxfje);
                    M_Szwmx.xfsl = Convert.ToDecimal(xfsl);
                    M_Szwmx.czy_bc = czy_bc;
                    M_Szwmx.czzt = czzt;
                    M_Szwmx.czsj = Convert.ToDateTime(czsj);
                    M_Szwmx.syzd = syzd;
                    //2012-02-09新增一个进价金额
                    M_Szwmx.jjje = Convert.ToDecimal(jjje);
                    M_Szwmx.mxbh = mxbh;
                    if (B_Szwmx.Add(M_Szwmx) > 0)
                    {
                        //2012-03-06更新（消费后写入Szwzd)
                        strsql = new StringBuilder();
                        strsql.Append("update   Szwzd  set   xfje=xfje+" + M_Szwmx.sjxfje + "  where lsbh='" + M_Szwmx.lsbh + "'");
                        B_common.ExecuteSql(strsql.ToString());
                        //InsertToSsyxfmx(string yydh,string qymc, string krxm, string lsbh,string fjrb,string fjbh,string id_app, string old_id_app, string zd_id, string sk_tt,string xfdr,string xfrb,string xfxm,string xfsl,string sjxfje, string yydh_temp, string xydw_temp,string xxzs)
                        if (InsertToSsyxfmx(yydh, qymc, M_Szwmx.krxm, M_Szwmx.lsbh, M_Szwmx.fjrb, M_Szwmx.fjbh, id_app, old_id_app, zd_id, sk_tt, xfdr, xfrb, xfxm, xfsl, sjxfje, czy, DateTime.Parse(czsj), xxzs, DateTime.Parse(ddsj), DateTime.Parse(lksj)) == common_file.common_app.get_suc)
                            s = common_file.common_app.get_suc;
                    }
                }
                else
                {
                    Model.Szwmx M_Szwmx_temp = new Hotel_app.Model.Szwmx();
                    M_Szwmx_temp = B_Szwmx.GetModelList("id_app='" + old_id_app + "'")[0];
                    //这里新增一个冲补账的检测,在Ssyxfmx中没有话不执行)
                    BLL.Ssyxfmx B_Ssyxfmx_cz_new = new Hotel_app.BLL.Ssyxfmx();
                    DataSet ds_Ssyxfmx_cz_new = B_Ssyxfmx_cz_new.GetList(" yydh='" + yydh + "' and  id_app='" + old_id_app + "'");
                    if (ds_Ssyxfmx_cz_new != null && ds_Ssyxfmx_cz_new.Tables[0].Rows.Count > 0)
                    {
                        if (M_Szwmx_temp != null)
                        {
                            M_Szwmx.lsbh = M_Szwmx_temp.lsbh;
                            M_Szwmx.krxm = M_Szwmx_temp.krxm;
                            M_Szwmx.fjrb = M_Szwmx_temp.fjrb;
                            M_Szwmx.fjbh = M_Szwmx_temp.fjbh;
                            M_Szwmx.sktt = M_Szwmx_temp.sktt;
                            M_Szwmx.yydh = yydh;
                            M_Szwmx.qymc = qymc;
                            M_Szwmx.id_app = id_app;
                            M_Szwmx.jzbh = M_Szwmx_temp.jzbh; //新增为空
                            M_Szwmx.jjje = M_Szwmx.jjje;
                            M_Szwmx.xfrq = Convert.ToDateTime(xfrq);
                            M_Szwmx.xfsj = Convert.ToDateTime(xfsj);
                            M_Szwmx.czy = czy;
                            M_Szwmx.xfdr = xfdr;
                            M_Szwmx.xfrb = xfrb;
                            M_Szwmx.xfxm = xfxm;
                            M_Szwmx.xfbz = xfbz;
                            M_Szwmx.xfzy = xfzy;
                            if (xfzy == common_zw.zwcl_congz)  //冲帐时为负数
                            {
                                xfje = Convert.ToString(-Convert.ToDecimal(xfje));
                                M_Szwmx.xfje = Convert.ToDecimal(xfje);
                                sjxfje = Convert.ToString(-Convert.ToDecimal(sjxfje));
                                M_Szwmx.sjxfje = Convert.ToDecimal(sjxfje);
                                //xfsl = Convert.ToString(-Convert.ToDecimal(xfsl));
                                M_Szwmx.xfsl = -Convert.ToDecimal(Math.Abs(Convert.ToDecimal(xfsl)));
                            }
                            else
                            {
                                M_Szwmx.xfje = Convert.ToDecimal(xfje);
                                M_Szwmx.sjxfje = Convert.ToDecimal(sjxfje);
                                M_Szwmx.xfsl = Convert.ToDecimal(Math.Abs(Convert.ToDecimal(xfsl)));
                            }
                            M_Szwmx.yh = yh;
                            M_Szwmx.czy_bc = czy_bc;

                            //
                            //M_Szwmx.czzt = czzt;

                            M_Szwmx.czzt = M_Szwmx_temp.czzt;


                            M_Szwmx.czsj = Convert.ToDateTime(czsj);
                            M_Szwmx.syzd = syzd;
                            M_Szwmx.mxbh = M_Szwmx_temp.mxbh;
                            if (B_Szwmx.Add(M_Szwmx) > 0)
                            {
                                if (M_Szwmx.jzbh != "")
                                {
                                    DataSet DS_temp = B_common.GetList("select * from Sjzzd", "jzbh='" + M_Szwmx.jzbh + "'");
                                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                                    {
                                        //更新冲补账这条记录的czzt，如果这里的备注为空,就把结账主单的房号给它
                                        if (M_Szwmx.xfbz.Trim() == "")
                                        {
                                            B_common.ExecuteSql("  update   Szwmx  set  czzt='" + DS_temp.Tables[0].Rows[0]["czzt"].ToString() + "',xfbz='" + DS_temp.Tables[0].Rows[0]["fjbh"].ToString() + "'  where id_app='" + id_app + "'");
                                        }
                                        else
                                        {
                                            B_common.ExecuteSql("  update   Szwmx  set  czzt='" + DS_temp.Tables[0].Rows[0]["czzt"].ToString() + "'  where id_app='" + id_app + "'");
                                        }
                                        strsql = new StringBuilder();
                                        strsql.Append("insert into Sjzmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,xyh,jzzt,fkfs,mxbh,tfsj)");
                                        strsql.Append("   select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,'" + DS_temp.Tables[0].Rows[0]["xyh"].ToString() + "','" + DS_temp.Tables[0].Rows[0]["jzzt"].ToString() + "','',mxbh,'" + DS_temp.Tables[0].Rows[0]["tfsj"].ToString() + "' from Szwmx where id_app='" + id_app + "'");
                                        B_common.ExecuteSql(strsql.ToString());

                                        strsql = new StringBuilder();
                                        strsql.Append("  update   Szwzd_bak  set   xfje=xfje+" + M_Szwmx.sjxfje + "  where lsbh='" + M_Szwmx.lsbh + "' and jzbh='" + M_Szwmx.jzbh + "'");
                                        B_common.ExecuteSql(strsql.ToString());

                                        strsql = new StringBuilder();
                                        strsql.Append("update   Sjzzd  set  shsc=0 , xfje=xfje+" + M_Szwmx.sjxfje + "  where jzbh='" + M_Szwmx.jzbh + "'");
                                        B_common.ExecuteSql(strsql.ToString());
                                    }
                                    DS_temp.Dispose();
                                }
                                strsql = new StringBuilder();
                                strsql.Append("update   Szwzd  set   xfje=xfje+" + M_Szwmx.sjxfje + "  where lsbh='" + M_Szwmx.lsbh + "'");
                                B_common.ExecuteSql(strsql.ToString());
                                //成功后写入Ssyxfmx和Ssyxfmx_cz
                                //InsertToSsyxfmx(string yydh,string qymc, string krxm, string lsbh,string fjrb,string fjbh,string id_app, string old_id_app, string zd_id, string sk_tt,string xfdr,string xfrb,string xfxm,string xfsl,string sjxfje, string xxzs)
                                if (InsertToSsyxfmx(yydh, qymc, M_Szwmx.krxm, M_Szwmx.lsbh, M_Szwmx.fjrb, M_Szwmx.fjbh, id_app, old_id_app, zd_id, sk_tt, xfdr, xfrb, xfxm, xfsl, sjxfje, czy, DateTime.Parse(czsj), xxzs, DateTime.Parse(ddsj), DateTime.Parse(lksj)) == common_file.common_app.get_suc)
                                    s = common_file.common_app.get_suc;
                            }
                        }
                    }
                    else
                    {
                        return s = common_file.common_app.get_failure;
                    }
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_delete)
                {
                    DataSet DS_temp = B_common.GetList("select * from Szwmx", "id_app='" + id_app + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {

                        if (DS_temp.Tables[0].Rows[0]["jzbh"].ToString() != "")
                        {
                            B_common.ExecuteSql("update Sjzzd set xfje=xfje-'" + DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "' where jzbh='" + DS_temp.Tables[0].Rows[0]["jzbh"].ToString() + "'");
                            B_common.ExecuteSql("update Szwzd_bak set xfje=xfje-'" + DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "' where jzbh='" + DS_temp.Tables[0].Rows[0]["jzbh"].ToString() + "'");
                            B_common.ExecuteSql("delete from Sjzmx where id_app='" + id_app + "'");
                        }
                        string ss = "update Szwzd set xfje=xfje-'" + DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "' where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'";
                        B_common.ExecuteSql("update Szwzd set xfje=xfje-'" + DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "' where lsbh='" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        B_common.ExecuteSql("update Ffjzt set use_time=use_time-'" + DS_temp.Tables[0].Rows[0]["xfsl"].ToString() + "' where fjbh='" + DS_temp.Tables[0].Rows[0]["fjbh"].ToString() + "'");
                        B_common.ExecuteSql("delete from Szwmx where id_app='" + id_app + "'");
                        B_common.ExecuteSql("delete from Ssyxfmx where id_app='" + id_app + "'");
                        B_common.ExecuteSql("delete from Hhyjf_xfjl where id_app='" + id_app + "'");
                        //同时要删除Ssyxfmx_cz里面相同的这条
                        B_common.ExecuteSql("delete from Ssyxfmx_cz where id_app='" + id_app + "'");
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "消账", DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() + "_" + DS_temp.Tables[0].Rows[0]["xfxm"].ToString(), DS_temp.Tables[0].Rows[0]["krxm"].ToString() + "_" + DS_temp.Tables[0].Rows[0]["fjbh"].ToString() + "_" + DS_temp.Tables[0].Rows[0]["lsbh"].ToString(), DateTime.Parse(czsj));
                        s = common_file.common_app.get_suc;
                    }
                    DS_temp.Dispose();
                }
            return s;
        }

        //写入消费明细同步写入Ssyxfmx和Ssyxfmx_cz
        //Hhyjf_xfjl_new.Hhyjfxfjl_add_edit(string id, string yydh, string qymc, string hykh, string hykh_bz, string krxm,string id_app,string lsbh,string fjrb,string fjbh,string hyjf,string bz,string xfdr,string xfrb, string xfxm,string sjxmje,string add_edit_delete,string czy,DateTime czsj,string parent_hykh, string xxzs);
        public string InsertToSsyxfmx(string yydh, string qymc, string krxm, string lsbh, string fjrb, string fjbh, string id_app, string old_id_app, string zd_id, string sk_tt, string xfdr, string xfrb, string xfxm, string xfsl, string sjxfje, string czy, DateTime czsj, string xxzs, DateTime ddsj, DateTime lksj)
        {
            string s = common_file.common_app.get_failure;
            BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Hotel_app.Model.Qskyd_mainrecord();
            Model.Qttyd_mainrecord M_Qttyd_mainrecord = new Hotel_app.Model.Qttyd_mainrecord();
            StringBuilder strSql;
            string yxzj = "";//有效证件 
            string pq = "";
            string gj_sf = "";
            string gj_cs = "";
            string gj_dq = "";
            string krly = "";
            string zjhm = "";
            string krsj = "";
            string xyh = "";
            string xydw = "";
            string xsy = "";
            string hykh = "";
            string krgj = "";
            strSql = new StringBuilder();
            strSql.Append("insert into Ssyxfmx(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,mxbh,czsj,ddsj,lksj ) ");
            strSql.Append(" select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy,jjje,xfje,yh,sjxfje,xfsl,czy_bc,mxbh,'" + czsj.ToString() + "','" + ddsj.ToString() + "','" + lksj.ToString() + "'   from Szwmx");
            strSql.Append(" where id_app='" + id_app + "'");
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (B_common.ExecuteSql(strSql.ToString()) > 0)
            {
                //写入Ssyxfmx_cz
                if (old_id_app == "")
                {
                    if (sk_tt == "sk")
                    {
                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(zd_id));
                        yydh = M_Qskyd_mainrecord.yydh;
                        qymc = M_Qskyd_mainrecord.qymc;
                        krly = M_Qskyd_mainrecord.krly;
                        yxzj = M_Qskyd_mainrecord.yxzj;
                        zjhm = M_Qskyd_mainrecord.zjhm;
                        krsj = M_Qskyd_mainrecord.krsj;
                        xydw = M_Qskyd_mainrecord.xydw;
                        xsy = M_Qskyd_mainrecord.xsy;
                        hykh = M_Qskyd_mainrecord.hykh;
                        krgj = M_Qskyd_mainrecord.krgj;
                        yxzj = M_Qskyd_mainrecord.yxzj;

                        //增加每个入住客人的记录和它的消费统计
                        DataSet DS_temp = B_common.GetList("select krxm,zjhm from Qskyd_mainrecord", " lsbh='" + M_Qskyd_mainrecord.lsbh + "'  and  zjhm<>''  and  krxm<>''");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            decimal xfje_ff = 0; decimal xfje_other = 0;
                            decimal lzfs = 0;
                            if (xfdr == common_zw.dr_ff)
                            {
                                if (sjxfje.Trim() == "") { xfje_ff = 0; }
                                else
                                {
                                    xfje_ff = decimal.Parse(sjxfje);
                                }
                                if (xfsl.Trim() == "") { lzfs = 0; }
                                else
                                {
                                    lzfs = decimal.Parse(xfsl);
                                }
                            }
                            else
                            {
                                if (sjxfje.Trim() == "") { xfje_other = 0; }
                                else
                                {
                                    xfje_other = decimal.Parse(sjxfje);
                                }
                            }
                            if (B_common.ExecuteSql("update Q_lskr_xftj set xfje_ff=xfje_ff+" + xfje_ff + ", lzfs=lzfs+" + lzfs + " where zjhm='" + M_Qskyd_mainrecord.zjhm + "'") < 1)
                            {//消费统计
                                B_common.ExecuteSql("insert into Q_lskr_xftj (yydh,qymc,zjhm,krxm,xfje_ff,xfje_other,lzfs) values ('" + M_Qskyd_mainrecord.yydh + "','" + M_Qskyd_mainrecord.qymc + "','" + DS_temp.Tables[0].Rows[0]["zjhm"].ToString() + "','" + DS_temp.Tables[0].Rows[0]["krxm"].ToString() + "','" + xfje_ff.ToString() + "','" + xfje_other.ToString() + "','" + lzfs.ToString() + "')");
                            }
                        }
                        DS_temp.Clear();
                        DS_temp.Dispose();
                        B_common.ExecuteSql("insert into Ssyxfmx_lskr (yydh,qymc,krxm,zjhm,id_app) select yydh,qymc,krxm,zjhm,'" + id_app + "' from Qskyd_mainrecord where lsbh='" + M_Qskyd_mainrecord.lsbh + "' and zjhm<>'' and krxm<>''");
                        if (M_Qskyd_mainrecord.xsy != "")
                        {
                            string[] xsy_arg = M_Qskyd_mainrecord.xsy.Split('|');
                            for (int j_0 = 0; j_0 < xsy_arg.Length; j_0++)
                            {
                                B_common.ExecuteSql("insert into Ssyxfmx_xsy (yydh,qymc,xsy,id_app,xsy_sl)  values('" + M_Qskyd_mainrecord.yydh + "','" + M_Qskyd_mainrecord.qymc + "','" + xsy_arg[j_0] + "','" + id_app + "','" + xsy_arg.Length + "')");
                            }
                        }

                    }
                    if (sk_tt == "tt")
                    {
                        M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(zd_id));
                        yydh = M_Qttyd_mainrecord.yydh;
                        qymc = M_Qttyd_mainrecord.qymc;
                        krly = M_Qttyd_mainrecord.krly;
                        krsj = M_Qttyd_mainrecord.krsj;
                        xydw = M_Qttyd_mainrecord.xydw;
                        xsy = M_Qttyd_mainrecord.xsy;
                        krgj = M_Qttyd_mainrecord.krgj;
                        if (M_Qttyd_mainrecord.xsy != "")
                        {
                            string[] xsy_arg = M_Qttyd_mainrecord.xsy.Split('|');
                            for (int j_0 = 0; j_0 < xsy_arg.Length; j_0++)
                            {
                                B_common.ExecuteSql("insert into Ssyxfmx_xsy (yydh,qymc,xsy,id_app,xsy_sl) values('" + M_Qttyd_mainrecord.yydh + "','" + M_Qttyd_mainrecord.qymc + "','" + xsy_arg[j_0] + "','" + id_app + "','" + xsy_arg.Length + "')");
                            }
                        }
                    }
                    if (yxzj == common_file.common_app.yxzj_sfz)//如果是身份证
                    {
                        GetValue(zjhm, ref pq, ref gj_dq, ref  gj_cs, ref gj_sf, krgj, yydh);
                    }
                    else//不是身份证的，保留方法
                    {
                        GetNullValue(ref pq, ref gj_dq, ref  gj_cs, ref gj_sf, krgj, yydh);
                    }
                    string xyh_temp = common_zw.GetxyhByxydw(xydw, yydh);
                    xyh = xyh_temp;
                    strSql = new StringBuilder();
                    strSql.Append("insert into  Ssyxfmx_cz(yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq)");
                    strSql.Append(" values('" + yydh + "','" + qymc + "','" + id_app + "','" + krly + "','" + yxzj + "','" + zjhm + "','" + krsj + "','" + xyh_temp + "','" + xydw + "','" + xsy + "','" + hykh + "','" + krgj + "','" + pq + "','" + gj_sf + "','" + gj_cs + "','" + gj_dq + "')");
                    if (B_common.ExecuteSql(strSql.ToString()) > 0)
                    {
                        DataSet DS_temp_0 = B_common.GetList("select * from Szwmx", "id_app='" + id_app + "' and xfdr='" + Szwgl.common_zw.dr_ff + "'");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            B_common.ExecuteSql("update Ffjzt set use_time=use_time+'" + DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString() + "' where fjbh='" + DS_temp_0.Tables[0].Rows[0]["fjbh"].ToString() + "'");

                        }
                        s = common_file.common_app.get_suc;
                        DS_temp_0.Dispose();
                    }

                }
                else
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into  Ssyxfmx_cz(yydh,qymc,id_app,krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq)");
                    strSql.Append(" select yydh,qymc,'" + id_app + "',krly,yxzj,zjhm,krsj,xyh,xydw,xsy,hykh,krgj,pq,gj_sf,gj_cs,gj_dq from Ssyxfmx_cz where id_app='" + old_id_app + "'");
                    if (B_common.ExecuteSql(strSql.ToString()) > 0)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into Ssyxfmx_lskr (yydh,qymc,krxm,zjhm,id_app) select yydh,qymc,krxm,zjhm,'" + id_app + "' from Ssyxfmx_lskr where id_app='" + old_id_app + "'");
                        B_common.ExecuteSql(strSql.ToString());

                        strSql = new StringBuilder();
                        strSql.Append("insert into Ssyxfmx_xsy (yydh,qymc,xsy,id_app,xsy_sl) select yydh,qymc,xsy,'" + id_app + "',xsy_sl from Ssyxfmx_xsy where id_app='" + old_id_app + "'");
                        B_common.ExecuteSql(strSql.ToString());



                        DataSet DS_temp_0 = B_common.GetList("select * from Szwmx", "  id_app='" + id_app + "' and xfdr='" + Szwgl.common_zw.dr_ff + "'");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            B_common.ExecuteSql("update Ffjzt set use_time=use_time+" + decimal.Parse(DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString()) + "  where fjbh='" + DS_temp_0.Tables[0].Rows[0]["fjbh"].ToString() + "'");

                        }

                        DS_temp_0 = B_common.GetList("select krly,hykh,xyh,xydw,xsy from Ssyxfmx_cz", "id_app='" + id_app + "'");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            hykh = DS_temp_0.Tables[0].Rows[0]["hykh"].ToString();
                            krly = DS_temp_0.Tables[0].Rows[0]["krly"].ToString();
                            xyh = DS_temp_0.Tables[0].Rows[0]["xyh"].ToString();
                            xydw = DS_temp_0.Tables[0].Rows[0]["xydw"].ToString();
                            xsy = DS_temp_0.Tables[0].Rows[0]["xsy"].ToString();
                        }



                        s = common_file.common_app.get_suc;
                        DS_temp_0.Dispose();
                        s = common_file.common_app.get_suc;
                    }


                }


                if (hykh != "" && xfdr == Szwgl.common_zw.dr_ff && xfxm == Szwgl.common_zw.ff_kffy)
                {
                    Hhygl.Hhyjf_xfjl Hhyjf_xfjl_new = new Hotel_app.Server.Hhygl.Hhyjf_xfjl();
                    Hhyjf_xfjl_new.Hhyjf_gc_app(krly, hykh, yydh, qymc, krxm, id_app, lsbh, fjrb, fjbh, xfdr, xfrb, xfxm, sjxfje, czy, czsj, xxzs);
                }


                //协议单位积分
                if (xyh != "" && xydw != "")
                {
                    //获取积分比率
                    float jfbl_0 = get_xydw_jfbl(krly, fjrb, sjxfje);
                    if (jfbl_0 > 0 && xfdr == Szwgl.common_zw.dr_ff && xfxm == Szwgl.common_zw.ff_kffy)
                    {

                        String s_insert_xydw_jf = "insert into Yxydw_jf(yydh,qymc,krly,xyh,xydw,xsy,krxm,id_app,lsbh,fjrb,fjbh,xfrq,xfsj,xydw_jf,bz,xfdr,xfrb,xfxm,sjxfje,shsc,scsj,is_top,is_select,shqx,czy)";
                        s_insert_xydw_jf = s_insert_xydw_jf + " values ('" + yydh + "','" + qymc + "','" + krly + "','" + xyh + "','" + xydw + "','" + xsy + "','" + krxm + "','" + id_app + "','" + lsbh + "','" + fjrb + "','" + fjbh + "','" + DateTime.Parse(czsj.ToShortDateString()) + "','" + czsj.ToString() + "','" + Convert.ToString(float.Parse(sjxfje) * jfbl_0) + "','" + "" + "','" + xfdr + "','" + xfrb + "','" + xfxm + "','" + sjxfje + "',0,'" + czsj.ToString() + "',0,0,0,'" + czy + "')";
                        B_common.ExecuteSql(s_insert_xydw_jf);
                        s_insert_xydw_jf = "update Yxydw set xydw_jf=xydw_jf+'" + Convert.ToString(float.Parse(sjxfje) * jfbl_0) + "' where xyh='" + xyh + "'";
                        B_common.ExecuteSql(s_insert_xydw_jf);

                    }
                }




            }

            return s;
        }

        //身份证获取国家，地区
        private void GetValue(string zjhm, ref string pq, ref string gj_dq, ref string gj_cs, ref string gj_sf, string krgj, string yydh)
        {

            //身份证信息确定(省份，城市，地区)
            if (zjhm.Trim() != "" && zjhm.Length > 15)
            {
                string gj_sf_temp = zjhm.Substring(0, 2);
                string gj_cs_temp = zjhm.Substring(2, 2);
                string gj_dq_temp = zjhm.Substring(4, 2);
                string sfzdm_temp = zjhm.Substring(0, 6);

                BLL.Xsfzdq B_Xsfzdq = new Hotel_app.BLL.Xsfzdq();
                BLL.Common B_common = new Hotel_app.BLL.Common();
                object string_temp = DbHelperSQL.GetSingle("SELECT  SFMC  FROM   Xsfzdq  where  sfdm='" + gj_sf_temp + "'");
                if (string_temp != null)
                {
                    gj_sf = string_temp.ToString();
                }
                string_temp = DbHelperSQL.GetSingle("SELECT  csmc  FROM   Xsfzdq  where  csdm='" + gj_cs_temp + "'  and  sfdm='" + gj_sf_temp + "'");
                if (string_temp != null)
                {
                    gj_cs = string_temp.ToString();
                    string_temp = DbHelperSQL.GetSingle("select dqmc from Xsfzdq where  sfzdm='" + sfzdm_temp + "'");
                    if (string_temp != null)
                    {
                        gj_dq = string_temp.ToString();
                    }
                    else
                    {
                        gj_dq = "其它";
                    }
                }
                else
                {
                    gj_cs = "其它"; gj_dq = "其它";
                }
            }
            else
            {
                gj_sf = "其它"; gj_cs = "其它"; gj_dq = "其它";
            }
            //krgj确定pq
            if (krgj.Trim() == "")
            { pq = "其它"; }
            else
            {
                object obj = DbHelperSQL.GetSingle("select  pq from Xkrgj  where krgj='" + krgj + "'  and yydh='" + yydh + "' ");
                if (obj != null)
                { pq = obj.ToString(); }
                else
                {
                    pq = "其它";
                }
            }


        }

        //不是身份证的时候
        private void GetNullValue(ref string pq, ref string gj_dq, ref string gj_cs, ref string gj_sf, string krgj, string yydh)
        {
            pq = "其它";
            gj_dq = "其它";
            gj_cs = "其它";
            gj_sf = "其它";
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="lsbh"></param>
        /// <param name="sktt"></param>
        /// <param name="fffs">产生房费的房式</param>ff_kffy"房费费用"，ff_jsbtfy"加收半天房费"，ff_jcfy"加床费用"。
        /// <param name="xfsj_bd">消费时间是否变动</param>如果是夜审产生的要变动"bd"，如果手动产生的房费不要变动"bbd"
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string New_fjfy(string yydh, string qymc, string lsbh, string fffs, string xfsj_bd, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string sktt = "sk";
            string sktt_bz = "";
            string zd_id = "";
            string id_app = "";
            string fjrb_0 = "";
            string fjbh_0 = "";
            DateTime xfrq_0;
            DateTime xfsj_0;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "fjbh<>'' and lsbh='" + lsbh + "' and yddj='" + common_file.common_yddj.yddj_dj + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                    if (float.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString()) < 0.001)
                    {
                        if (DS_temp.Tables[0].Rows[0]["fjjg"].ToString() != "")
                            if (float.Parse(DS_temp.Tables[0].Rows[0]["fjjg"].ToString()) > 0)
                            {
                                if (DS_temp.Tables[0].Rows[0]["yhbl"].ToString() != "")
                                    if (float.Parse(DS_temp.Tables[0].Rows[0]["yhbl"].ToString()) > 0)
                                    {
                                        float sjfjjg_tz = 0;
                                        sjfjjg_tz = float.Parse(DS_temp.Tables[0].Rows[0]["fjjg"].ToString()) * float.Parse(DS_temp.Tables[0].Rows[0]["yhbl"].ToString());
                                        decimal sjfjjg_tz_0 = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(sjfjjg_tz.ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                                        string s_temp_0 = "update Qskyd_fjrb set sjfjjg='" + sjfjjg_tz_0.ToString() + "' where id='" + DS_temp.Tables[0].Rows[0]["id"].ToString() + "'";
                                        B_Common.ExecuteSql(s_temp_0);
                                        DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "fjbh<>'' and lsbh='" + lsbh + "' and yddj='" + common_file.common_yddj.yddj_dj + "'");
                                    }
                            }
                    }

                sktt_bz = DS_temp.Tables[0].Rows[0]["sktt"].ToString();

                string temp = " ddbh=(select ddbh from Qskyd_mainrecord where lsbh='" + lsbh + "'  and  main_sec='main')";
                DataSet DS_temp_0 = B_Common.GetList("select * from Qttyd_mainrecord", "ddbh  in  (select ddbh from Qskyd_mainrecord where lsbh='" + lsbh + "'  and  main_sec='main')");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    string zd_id_0 = DS_temp_0.Tables[0].Rows[0]["id"].ToString();
                    DS_temp_0 = B_Common.GetList("select ffzf from Qskyd_mainrecord", "lsbh='" + lsbh + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (bool.Parse(DS_temp_0.Tables[0].Rows[0]["ffzf"].ToString()) == false)
                        {
                            sktt = "tt";
                            zd_id = zd_id_0;
                        }
                        else
                        {
                            DS_temp_0 = B_Common.GetList("select * from Qskyd_mainrecord", "lsbh='" + lsbh + "'");
                            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            {
                                zd_id = DS_temp_0.Tables[0].Rows[0]["id"].ToString();
                                sktt = "sk";
                            }
                        }

                    }
                }
                else
                {
                    DS_temp_0 = B_Common.GetList("select * from Qskyd_mainrecord", "lsbh='" + lsbh + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        zd_id = DS_temp_0.Tables[0].Rows[0]["id"].ToString();
                        sktt = "sk";
                    }
                }
                if (zd_id != "")
                {
                    if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                        if (decimal.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString()) >= 0)
                        {
                            fjrb_0 = DS_temp.Tables[0].Rows[0]["fjrb"].ToString();
                            fjbh_0 = DS_temp.Tables[0].Rows[0]["fjbh"].ToString();
                            string xfbz_0 = fjbh_0;
                            xfsj_0 = czsj; xfrq_0 = DateTime.Parse(xfsj_0.ToShortDateString());
                            if (xfsj_bd == "bd")
                            {
                                //xfrq_0.

                                DateTime ddsj_0 = DateTime.Parse(DS_temp.Tables[0].Rows[0]["ddsj"].ToString());
                                xfsj_0 = ddsj_0;
                                string[] info = Convert.ToString(DateTime.Parse(czsj.ToShortDateString()) - DateTime.Parse(ddsj_0.ToShortDateString())).Split('.');
                                if (info.Length > 1)
                                {
                                    //tb_ddsj.Text = info[0];
                                    xfsj_0 = ddsj_0.AddDays(int.Parse(info[0]) - 1);


                                }
                                else
                                {

                                    DS_temp_0 = B_Common.GetList("select * from Qcounter ", "id>=0");
                                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                                    {
                                        if (DS_temp_0.Tables[0].Rows[0]["ff_xfsj_rx"].ToString() == "1")
                                        {
                                            xfsj_0 = DateTime.Parse(ddsj_0.AddDays(-1).ToShortDateString() + " 23:59:59");
                                        }

                                    }

                                }
                                xfrq_0 = DateTime.Parse(xfsj_0.ToShortDateString());



                            }

                            //生成房费
                            string xfje_0 = "0";
                            string sjxfje_0 = "";
                            string xfsl_0 = "0";
                            string jjje_0 = "0";
                            string xfxm_0 = "";
                            string xfdr_0 = "";
                            string xfrb_0 = "";
                            decimal xfje_num = 0;
                            decimal sjxfje_num = 0;
                            string yh_0 = "";

                            double bl_0 = 1;//如果是加收半天就有可能是0.5,加收全天是1,因为伴随房费产生的杂费全部要乘相对应的比率
                            if (fffs == Szwgl.common_zw.ff_jsbtfy)
                            { bl_0 = bl_0 * Szwgl.common_zw.ff_jsbtfy_sl; }
                            //else
                            //    if (fffs == Szwgl.common_zw.ff_jsqtfy)
                            //    { bl_0 = bl_0 * Szwgl.common_zw.ff_jsqtfy_sl; }

                            //加床金额
                            if (DS_temp.Tables[0].Rows[0]["jcje"].ToString() != "")
                                if (decimal.Parse(DS_temp.Tables[0].Rows[0]["jcje"].ToString()) > 0)
                                {
                                    xfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["jcje"].ToString()) * bl_0, common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                    sjxfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["jcje"].ToString()) * bl_0, common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                    xfsl_0 = Convert.ToString(Szwgl.common_zw.ff_jcfy_sl * bl_0);
                                    jjje_0 = "0";
                                    xfdr_0 = Szwgl.common_zw.dr_ff;
                                    xfrb_0 = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                                    xfxm_0 = Szwgl.common_zw.ff_jcfy;
                                    yh_0 = "";
                                    id_app = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);
                                    Szwmx_add_edit(zd_id, sktt, "", yydh, qymc, id_app,
                                    xfrq_0.ToShortDateString(), xfsj_0.ToString(), czy, xfdr_0, xfrb_0, xfxm_0, xfbz_0, "", xfje_0, yh_0, sjxfje_0.ToString(), xfsl_0,
                                    czy_bc, DS_temp.Tables[0].Rows[0]["yddj"].ToString(), czsj.ToString(), syzd, common_file.common_app.get_add, xxzs, jjje_0, fjrb_0, fjbh_0, "", DS_temp.Tables[0].Rows[0]["ddsj"].ToString(), DS_temp.Tables[0].Rows[0]["lksj"].ToString());

                                }

                            //伴随房费产生的杂费，如基金，服务费等

                            if (sktt_bz != common_file.common_sktt.sktt_zd)
                            {
                                DS_temp_0 = B_Common.GetList("select * from Qyddj_otherfee", " lsbh='" + lsbh + "'");
                                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                                {
                                    for (int j_0 = 0; j_0 < DS_temp_0.Tables[0].Rows.Count; j_0++)
                                    {
                                        xfje_0 = "0";
                                        sjxfje_0 = "";
                                        xfsl_0 = "0";
                                        jjje_0 = "0";
                                        xfsl_0 = Convert.ToString(double.Parse(DS_temp_0.Tables[0].Rows[j_0]["xfsl"].ToString()) * bl_0);
                                        xfxm_0 = DS_temp_0.Tables[0].Rows[j_0]["xfxm"].ToString();
                                        xfdr_0 = DS_temp_0.Tables[0].Rows[j_0]["xfdr"].ToString();
                                        xfrb_0 = DS_temp_0.Tables[0].Rows[j_0]["xfrb"].ToString();
                                        if (DS_temp_0.Tables[0].Rows[j_0]["fyrx"].ToString() == Szwgl.common_zw.fwrx_abl)
                                        {
                                            xfje_0 = common_file.common_sswl.Round_sswl((double.Parse(DS_temp_0.Tables[0].Rows[j_0]["xfje"].ToString()) / 100) * double.Parse(DS_temp.Tables[0].Rows[0]["fjjg"].ToString()) * bl_0, common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                            sjxfje_0 = common_file.common_sswl.Round_sswl((double.Parse(DS_temp_0.Tables[0].Rows[j_0]["xfje"].ToString()) / 100) * double.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString()) * bl_0, common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                            jjje_0 = "0";
                                            yh_0 = DS_temp.Tables[0].Rows[0]["yh"].ToString();
                                        }
                                        else
                                        {
                                            xfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp_0.Tables[0].Rows[j_0]["xfje"].ToString()) * bl_0, common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                            sjxfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp_0.Tables[0].Rows[j_0]["xfje"].ToString()) * bl_0, common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                            jjje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp_0.Tables[0].Rows[j_0]["jjje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                            yh_0 = "";
                                        }
                                        id_app = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);
                                        Szwmx_add_edit(zd_id, sktt, "", yydh, qymc, id_app,
                                        xfrq_0.ToShortDateString(), xfsj_0.ToString(), czy, xfdr_0, xfrb_0, xfxm_0, xfbz_0, "", xfje_0, yh_0, sjxfje_0.ToString(), xfsl_0,
                                        czy_bc, DS_temp.Tables[0].Rows[0]["yddj"].ToString(), czsj.ToString(), syzd, common_file.common_app.get_add, xxzs, jjje_0, fjrb_0, fjbh_0, DS_temp_0.Tables[0].Rows[j_0]["mxbh"].ToString(), DS_temp.Tables[0].Rows[0]["ddsj"].ToString(), DS_temp.Tables[0].Rows[0]["lksj"].ToString());
                                        if (DS_temp.Tables[0].Rows[0]["shqh"].ToString() == common_file.common_app.fy_qh)//全含
                                        {
                                            xfje_num = xfje_num + decimal.Parse(xfje_0);
                                            sjxfje_num = sjxfje_num + decimal.Parse(sjxfje_0);

                                        }
                                    }

                                }
                            }
                            //以下产生房费
                            xfje_0 = "0";
                            sjxfje_0 = "";
                            xfsl_0 = "0";
                            jjje_0 = "0";
                            xfxm_0 = "";
                            xfdr_0 = Szwgl.common_zw.dr_ff;
                            xfrb_0 = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                            yh_0 = DS_temp.Tables[0].Rows[0]["yh"].ToString();
                            if (fffs == Szwgl.common_zw.ff_kffy)
                            {
                                xfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["fjjg"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                sjxfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                xfsl_0 = DS_temp.Tables[0].Rows[0]["lzfs"].ToString();
                                if (DS_temp.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_zd)
                                {
                                    xfsl_0 = Szwgl.common_zw.ff_jsbtfy_sl.ToString();
                                }
                                xfxm_0 = Szwgl.common_zw.ff_kffy;

                                //如果要分出单审的房费把这个启用，其余关闭
                                //if (sktt_bz != common_file.common_sktt.sktt_zd && xfsj_bd=="bbd")
                                //{
                                //    xfxm_0 = Szwgl.common_zw.ff_sqff;
                                //}

                            }
                            else
                                if (fffs == Szwgl.common_zw.ff_jsqtfy)
                                {
                                    xfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["fjjg"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                    sjxfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                    xfsl_0 = Szwgl.common_zw.ff_jsqtfy_sl.ToString();
                                    if (DS_temp.Tables[0].Rows[0]["sktt"].ToString() == common_file.common_sktt.sktt_zd)
                                    {
                                        xfsl_0 = Szwgl.common_zw.ff_jsbtfy_sl.ToString();
                                    }
                                    xfxm_0 = Szwgl.common_zw.ff_jsqtfy;
                                }
                                else
                                    if (fffs == Szwgl.common_zw.ff_jsbtfy)
                                    {
                                        xfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["fjjg"].ToString()) * double.Parse(Szwgl.common_zw.ff_jsbtfy_sl.ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                        sjxfje_0 = common_file.common_sswl.Round_sswl(double.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString()) * double.Parse(Szwgl.common_zw.ff_jsbtfy_sl.ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                                        xfsl_0 = Szwgl.common_zw.ff_jsbtfy_sl.ToString();
                                        xfxm_0 = Szwgl.common_zw.ff_jsbtfy;
                                    }


                            //全含的房费

                            if (DS_temp.Tables[0].Rows[0]["shqh"].ToString() == common_file.common_app.fy_qh)//全含的房费
                            {
                                xfje_0 = Convert.ToString(decimal.Parse(xfje_0) - xfje_num);
                                sjxfje_0 = Convert.ToString(decimal.Parse(sjxfje_0) - sjxfje_num);
                            }
                            id_app = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);
                            Szwmx_add_edit(zd_id, sktt, "", yydh, qymc, id_app,
                            xfrq_0.ToShortDateString(), xfsj_0.ToString(), czy, xfdr_0, xfrb_0, xfxm_0, xfbz_0, "", xfje_0, yh_0, sjxfje_0.ToString(), xfsl_0,
                            czy_bc, DS_temp.Tables[0].Rows[0]["yddj"].ToString(), czsj.ToString(), syzd, common_file.common_app.get_add, xxzs, jjje_0, fjrb_0, fjbh_0, "", DS_temp.Tables[0].Rows[0]["ddsj"].ToString(), DS_temp.Tables[0].Rows[0]["lksj"].ToString());
                            common_file.common_czjl.add_czjl(yydh, qymc, czy, "增加房费", fffs + " " + DS_temp.Tables[0].Rows[0]["fjbh"].ToString(), DS_temp.Tables[0].Rows[0]["krxm"].ToString() + " " + DS_temp.Tables[0].Rows[0]["lsbh"].ToString(), czsj);



                            s = common_file.common_app.get_suc;
                        }
                }
                DS_temp_0.Dispose();
            }
            DS_temp.Dispose();
            s = common_file.common_app.get_suc;
            return s;
        }

        //多选产生房费
        public string New_muli_fjfy(string yydh, string qymc, string[] lsbh, string fffs, string xfsj_bd, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            for (int j_0 = 0; j_0 < lsbh.Length; j_0++)
            {
                s = common_file.common_app.get_failure;
                if (lsbh[j_0] != null && lsbh[j_0].Trim() != "")
                {
                    New_fjfy(yydh, qymc, lsbh[j_0], fffs, xfsj_bd, czy_bc, syzd, czy, czsj, xxzs);
                }
                s = common_file.common_app.get_suc;
                //common_file.common_czjl.add_czjl(yydh, qymc, czy, "增加所有房费", "", "", czsj);
            }
            return s;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="ddbh"></param>
        /// <param name="xfsj_bd"></param>消费时间是否变动</param>如果是夜审产生的要变动"bd"，如果手动产生的房费不要变动"bbd"
        /// <param name="czy_bc"></param>
        /// <param name="syzd"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string New_tt_fjfy(string yydh, string qymc, string ddbh, string xfsj_bd, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Qskyd_fjrb", "fjbh<>'' and yddj='" + common_file.common_yddj.yddj_dj + "' and yydh='" + yydh + "' and lsbh in(select lsbh from Qskyd_mainrecord where ddbh='" + ddbh + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {
                    s = common_file.common_app.get_failure;
                    New_fjfy(yydh, qymc, DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), Szwgl.common_zw.ff_kffy, xfsj_bd, czy_bc, syzd, czy, czsj, xxzs);
                    s = common_file.common_app.get_suc;
                    //common_file.common_czjl.add_czjl(yydh, qymc, czy, "增加所有房费", "", "", czsj);
                }
            }
            return s;

        }
        public string New_all_fjfy(string yydh, string qymc, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string ys_dh = ""; string s_0 = "";
            s_0 = "delete from S_ys_fy_gz where czrq<'" + DateTime.Now.AddDays(-20).ToShortDateString() + "'";
            B_Common.ExecuteSql(s_0);
            DataSet DS_temp_0 = B_Common.GetList("select * from S_ys_fy_gz ", " czrq='" + DateTime.Now.ToShortDateString() + "' and start_sc='" + common_file.common_app.get_suc + "' and end_sc=''");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                ys_dh = DS_temp_0.Tables[0].Rows[0]["ys_dh"].ToString();

                common_file.common_czjl.add_czjl(yydh, qymc, czy, "夜审加房费异常", DS_temp_0.Tables[0].Rows[0]["fjrb"].ToString() + "/" + DS_temp_0.Tables[0].Rows[0]["fjbh"].ToString() + "/" + DS_temp_0.Tables[0].Rows[0]["krxm"].ToString(), DS_temp_0.Tables[0].Rows[0]["krly"].ToString() + "/" + DS_temp_0.Tables[0].Rows[0]["xydw"].ToString(), czsj);
                s_0 = "delete from S_ys_fy_gz where ys_dh='" + ys_dh + "' and czrq='" + DateTime.Now.ToShortDateString() + "' and start_sc='" + common_file.common_app.get_suc + "' and end_sc=''";


                B_Common.ExecuteSql(s_0);
            }
            else
            {
                ys_dh = common_file.common_ddbh.ddbh("ysfy", "lsbhdate", "lsbhcounter", 6);
            }



            DataSet DS_temp = B_Common.GetList("select * from View_Qskzd", " main_sec='" + common_file.common_app.main_sec_main + "' and fjbh<>'' and yydh='" + yydh + "'and yddj='" + common_file.common_yddj.yddj_dj + "' and lsbh not in(select lsbh from S_ys_fy_gz where czrq='" + DateTime.Now.ToShortDateString() + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {
                    s = common_file.common_app.get_failure;


                    s_0 = "insert into S_ys_fy_gz (yydh,qymc,ys_dh,lsbh,fjrb,fjbh,krxm,sktt,xydw,krly,ddsj,lksj,sjfjjg,start_sc,end_sc,czsj,czrq,czy,bz) ";
                    s_0 = s_0 + " values ('" + yydh + "','" + qymc + "','" + ys_dh + "','" + DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["fjrb"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["fjbh"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["krxm"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["sktt"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["xydw"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["krly"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["ddsj"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["lksj"].ToString() + "','" + DS_temp.Tables[0].Rows[j_0]["sjfjjg"].ToString() + "','" + common_file.common_app.get_suc + "','" + "" + "','" + czsj + "','" + czsj.ToShortDateString() + "','" + "czy" + "','" + "加收房费没成功！请先检查这张登记单中的房类、房费是否有问题！" + "')";

                    B_Common.ExecuteSql(s_0);

                    New_fjfy(yydh, qymc, DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), Szwgl.common_zw.ff_kffy, "bd", czy_bc, syzd, czy, czsj, xxzs);

                    s_0 = "update S_ys_fy_gz set end_sc='" + common_file.common_app.get_suc + "',bz='" + "成功" + "' where ys_dh='" + ys_dh + "' and lsbh='" + DS_temp.Tables[0].Rows[j_0]["lsbh"].ToString() + "'";
                    B_Common.ExecuteSql(s_0);
                    s = common_file.common_app.get_suc;
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, "增加所有房费", "", "", czsj);
                }
            }
            DS_temp_0.Clear();
            DS_temp_0.Dispose();
            DS_temp.Clear();
            DS_temp.Dispose();
            return s;

        }



        //增加客房电话费到账务明细中
        /// <summary>
        /// sk_tt 当为团体时，is_addToSingle才有意义,指是否将电话费用加到团体成员自身里面(true就加到成员房费里面去)
        /// </summary>
        /// <returns></returns>
        public string InsertDHFtoZw(string sk_tt, string is_addToSingle, string yydh, string qymc, string lsbh, string czy, string czy_bc, string czsj, string syzd, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string zd_id_temp = "";
            string lsbh_temp = "";
            string fjbh_temp = "";
            string fjrb_temp = "";
            BLL.Common B_common = new Hotel_app.BLL.Common();
            if (sk_tt == "sk")
            {
                DataSet ds_dhhy_00 = null;


                DataSet ds_dhhy_0 = B_common.GetList(" select distinct  lsbh  from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and fjbh!=''   and  shlz='1'  ) ");
                if (ds_dhhy_0 != null && ds_dhhy_0.Tables[0].Rows.Count > 0)
                {
                    string ss = "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select * from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ";
                    ds_dhhy_00 = B_common.GetList(" select * from Dh_jl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select  lsbh  from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ");
                    {
                        if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds_dhhy_0.Tables[0].Rows.Count; j++)
                            {
                                DataSet ds_00 = B_common.GetList(" select  * from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + ds_dhhy_0.Tables[0].Rows[j]["lsbh"].ToString() + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                                if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                                {
                                    zd_id_temp = ds_00.Tables[0].Rows[0]["id"].ToString();
                                    lsbh_temp = ds_00.Tables[0].Rows[0]["lsbh"].ToString();
                                    fjbh_temp = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                                    fjrb_temp = ds_00.Tables[0].Rows[0]["fjrb"].ToString();
                                    DataSet ds_add_tmp = B_common.GetList(" select * from Dh_jl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "'");

                                    {
                                        s = InsertDHFtoZw_InsertToSingle(ds_add_tmp, zd_id_temp, yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                                    }
                                }
                                else
                                {
                                    return s = common_file.common_app.get_failure;
                                }
                            }
                        }
                        else
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                }


                else
                {
                    ds_dhhy_00 = B_common.GetList(" SELECT  *  from Dh_jl ", "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  lsbh='" + lsbh + "' ");
                    if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                    {
                        DataSet ds_00 = B_common.GetList(" select  * from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + lsbh + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                        if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                        {
                            zd_id_temp = ds_00.Tables[0].Rows[0]["id"].ToString();
                            lsbh_temp = ds_00.Tables[0].Rows[0]["lsbh"].ToString();
                            fjrb_temp = ds_00.Tables[0].Rows[0]["fjrb"].ToString();
                            fjbh_temp = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                            s = InsertDHFtoZw_InsertToSingle(ds_dhhy_00, zd_id_temp, yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                        }
                    }
                    else
                    {
                        s = common_file.common_app.get_suc;
                    }
                }

            }
            if (sk_tt == "tt")
            {
                DataSet ds_0 = B_common.GetList(" select * from View_Qskzd  ", "  id>=0  and  ddbh=(select ddbh from Qttyd_mainrecord where  lsbh='" + lsbh + "' and  id>=0  and yydh='" + common_file.common_app.yydh + "' )");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    //话费加到成员自身
                    if (bool.Parse(is_addToSingle))
                    {
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds_0.Tables[0].Rows.Count; i++)
                            {
                                s = common_file.common_app.get_failure;
                                zd_id_temp = ds_0.Tables[0].Rows[i]["id"].ToString();
                                lsbh_temp = ds_0.Tables[0].Rows[i]["lsbh"].ToString();
                                fjbh_temp = ds_0.Tables[0].Rows[i]["fjbh"].ToString();
                                fjrb_temp = ds_0.Tables[0].Rows[i]["fjrb"].ToString();
                                DataSet ds_add_tmp = B_common.GetList(" select * from Dh_jl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "'");
                                s = InsertDHFtoZw_InsertToSingle(ds_add_tmp, zd_id_temp, yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                            }
                        }
                        else
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                    //话费加到团体里
                    else
                    {

                    }
                }
                else
                {
                    s = common_file.common_app.get_suc;
                }
            }
            return s;
        }

        //importType指要导入哪些费用，各种费用以|线隔开
        //如:telFee|cyFee
        public string InsertOtherFeetoZw(string sk_tt, string is_addToSingle, string yydh, string qymc, string lsbh, string czy, string czy_bc, string czsj, string syzd, string add_edit_delete, string xxzs, string importType)
        {
            string s = common_file.common_app.get_failure;

            string zd_id_temp = "";
            string lsbh_temp = "";
            string fjbh_temp = "";
            string fjrb_temp = "";
            int i = 0;//指示电话费导入状态
            int j_0 = 0;//指示餐饮费导入状态
            BLL.Common B_common = new Hotel_app.BLL.Common();
            //首先判断importType包含哪些费用
            if (importType.Contains("telFee"))//包含电话费
            {
                if (sk_tt == "sk")
                {
                    DataSet ds_dhhy_00 = null;
                    DataSet ds_dhhy_0 = B_common.GetList(" select distinct  lsbh  from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and fjbh!=''   and  shlz='1'  ) ");
                    if (ds_dhhy_0 != null && ds_dhhy_0.Tables[0].Rows.Count > 0)
                    {
                        string ss = "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select * from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ";
                        ds_dhhy_00 = B_common.GetList(" select * from Dh_jl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select  lsbh  from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ");
                        {
                            if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds_dhhy_0.Tables[0].Rows.Count; j++)
                                {
                                    DataSet ds_00 = B_common.GetList(" select  * from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + ds_dhhy_0.Tables[0].Rows[j]["lsbh"].ToString() + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                                    if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                                    {
                                        zd_id_temp = ds_00.Tables[0].Rows[0]["id"].ToString();
                                        lsbh_temp = ds_00.Tables[0].Rows[0]["lsbh"].ToString();
                                        fjbh_temp = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                                        fjrb_temp = ds_00.Tables[0].Rows[0]["fjrb"].ToString();
                                        DataSet ds_add_tmp = B_common.GetList(" select * from Dh_jl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "'");
                                        {
                                            s = InsertDHFtoZw_InsertToSingle(ds_add_tmp, zd_id_temp, yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                                            if (s == common_file.common_app.get_suc)
                                            {
                                                i++;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //s = common_file.common_app.get_suc;
                                i++;
                            }
                        }
                    }
                    else
                    {
                        ds_dhhy_00 = B_common.GetList(" SELECT  *  from Dh_jl ", "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  lsbh='" + lsbh + "' ");
                        if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                        {
                            DataSet ds_00 = B_common.GetList(" select  * from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + lsbh + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                            if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                            {
                                zd_id_temp = ds_00.Tables[0].Rows[0]["id"].ToString();
                                lsbh_temp = ds_00.Tables[0].Rows[0]["lsbh"].ToString();
                                fjrb_temp = ds_00.Tables[0].Rows[0]["fjrb"].ToString();
                                fjbh_temp = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                                s = InsertDHFtoZw_InsertToSingle(ds_dhhy_00, zd_id_temp, yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                                if (s == common_file.common_app.get_suc)
                                {
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            //s = common_file.common_app.get_suc;
                            i++;

                        }
                    }

                }
                if (sk_tt == "tt")
                {
                    DataSet ds_0 = B_common.GetList(" select * from View_Qskzd  ", "  id>=0  and  ddbh=(select ddbh from Qttyd_mainrecord where  lsbh='" + lsbh + "' and  id>=0  and yydh='" + common_file.common_app.yydh + "' )");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        //话费加到成员自身
                        if (bool.Parse(is_addToSingle))
                        {
                            if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                            {
                                for (int i_0 = 0; i_0 < ds_0.Tables[0].Rows.Count; i_0++)
                                {
                                    s = common_file.common_app.get_failure;
                                    zd_id_temp = ds_0.Tables[0].Rows[i_0]["id"].ToString();
                                    lsbh_temp = ds_0.Tables[0].Rows[i_0]["lsbh"].ToString();
                                    fjbh_temp = ds_0.Tables[0].Rows[i_0]["fjbh"].ToString();
                                    fjrb_temp = ds_0.Tables[0].Rows[i_0]["fjrb"].ToString();
                                    DataSet ds_add_tmp = B_common.GetList(" select * from Dh_jl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "'");
                                    s = InsertDHFtoZw_InsertToSingle(ds_add_tmp, zd_id_temp, yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                                    if (s == common_file.common_app.get_suc)
                                    { i++; }
                                }
                            }
                            else
                            {
                                //s = common_file.common_app.get_suc;
                                i++;
                            }
                        }
                        //话费加到团体里
                        else
                        {

                        }
                    }
                    else
                    {
                        //s = common_file.common_app.get_suc;
                        i++;
                    }
                }
            }
            if (importType.Contains("cyFee")) //包含餐饮费用
            {

                if (sk_tt == "sk")
                {
                    DataSet ds_dhhy_00 = null;
                    DataSet ds_dhhy_0 = B_common.GetList(" select distinct  lsbh  from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and fjbh!=''   and  shlz='1'  ) ");
                    if (ds_dhhy_0 != null && ds_dhhy_0.Tables[0].Rows.Count > 0)
                    {
                        string ss = "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select * from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ";
                        ds_dhhy_00 = B_common.GetList(" select * from S_cy_zl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select  lsbh  from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ");
                        {
                            if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j < ds_dhhy_0.Tables[0].Rows.Count; j++)
                                {
                                    DataSet ds_00 = B_common.GetList(" select  * from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + ds_dhhy_0.Tables[0].Rows[j]["lsbh"].ToString() + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                                    if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                                    {
                                        zd_id_temp = ds_00.Tables[0].Rows[0]["id"].ToString();
                                        lsbh_temp = ds_00.Tables[0].Rows[0]["lsbh"].ToString();
                                        fjbh_temp = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                                        fjrb_temp = ds_00.Tables[0].Rows[0]["fjrb"].ToString();
                                        DataSet ds_add_tmp = B_common.GetList(" select * from S_cy_zl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "'");
                                        {
                                            s = InsertcyFeetoZw_InsertToSingle(ds_add_tmp, zd_id_temp, "sk", yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                                            if (s == common_file.common_app.get_suc)
                                            { j_0++; }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //s = common_file.common_app.get_suc;
                                j_0++;
                            }
                        }
                    }


                    else
                    {
                        ds_dhhy_00 = B_common.GetList(" SELECT  *  from S_cy_zl ", "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  lsbh='" + lsbh + "' ");
                        if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                        {
                            DataSet ds_00 = B_common.GetList(" select  * from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + lsbh + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                            if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                            {
                                zd_id_temp = ds_00.Tables[0].Rows[0]["id"].ToString();
                                lsbh_temp = ds_00.Tables[0].Rows[0]["lsbh"].ToString();
                                fjrb_temp = ds_00.Tables[0].Rows[0]["fjrb"].ToString();
                                fjbh_temp = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                                s = InsertcyFeetoZw_InsertToSingle(ds_dhhy_00, zd_id_temp, "sk", yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                                if (s == common_file.common_app.get_suc)
                                { j_0++; }
                            }
                        }
                        else
                        {
                            // s = common_file.common_app.get_suc;
                            j_0++;

                        }
                    }
                }
                if (sk_tt == "tt")
                {
                    DataSet ds_0 = B_common.GetList(" select * from View_Qskzd  ", "  id>=0  and  ddbh  in  (select ddbh from Qttyd_mainrecord where  lsbh='" + lsbh + "' and  id>=0  and yydh='" + common_file.common_app.yydh + "' )");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                        {
                            for (int i_0 = 0; i_0 < ds_0.Tables[0].Rows.Count; i_0++)
                            {
                                s = common_file.common_app.get_failure;
                                zd_id_temp = ds_0.Tables[0].Rows[i_0]["id"].ToString();
                                lsbh_temp = ds_0.Tables[0].Rows[i_0]["lsbh"].ToString();
                                fjbh_temp = ds_0.Tables[0].Rows[i_0]["fjbh"].ToString();
                                fjrb_temp = ds_0.Tables[0].Rows[i_0]["fjrb"].ToString();
                                DataSet ds_add_tmp = B_common.GetList(" select * from S_cy_zl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  fjbh='" + fjbh_temp + "'  and  lsbh='" + lsbh_temp + "'");
                                s = InsertcyFeetoZw_InsertToSingle(ds_add_tmp, zd_id_temp, "sk", yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, fjrb_temp, fjbh_temp);
                                if (s == common_file.common_app.get_suc)
                                { j_0++; }
                            }
                        }
                        else
                        {
                            //s = common_file.common_app.get_suc;
                            j_0++;
                        }
                    }
                    ds_0 = B_common.GetList(" select * from View_Qttzd  ", "  id>=0  and    lsbh='" + lsbh + "' and  id>=0  and yydh='" + common_file.common_app.yydh + "'");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        s = common_file.common_app.get_failure;
                        zd_id_temp = ds_0.Tables[0].Rows[0]["id"].ToString();
                        lsbh_temp = ds_0.Tables[0].Rows[0]["lsbh"].ToString();
                        DataSet ds_add_tmp = B_common.GetList(" select * from S_cy_zl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  fjbh=''  and  lsbh='" + lsbh_temp + "'");
                        s = InsertcyFeetoZw_InsertToSingle(ds_add_tmp, zd_id_temp, "tt", yydh, qymc, lsbh_temp, czy, czy_bc, czsj, syzd, common_file.common_app.get_add, xxzs, "", "");
                        if (s == common_file.common_app.get_suc)
                        { j_0++; }
                    }
                }
            }
            if ((importType.Contains("telFee") && i > 0 && !(importType.Contains("cyFee"))) ||
                (importType.Contains("cyFee") && j_0 > 0 && !(importType.Contains("telFee"))) ||
                (importType.Contains("cyFee") && j_0 > 0 && (importType.Contains("telFee"))) && i > 0)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        public string InsertDHFtoZw_InsertToSingle(DataSet ds_add, string zd_id, string yydh, string qymc, string lsbh,
             string czy, string czy_bc, string czsj, string syzd, string add_edit_delete, string xxzs, string fjrb, string fjbh)
        {
            string s = common_file.common_app.get_failure;
            if (ds_add != null && ds_add.Tables[0].Rows.Count > 0)
            {
                //先将shsc更新为1，然后再进行单条添加
                BLL.Common B_common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_common.GetList("select * from Qskyd_fjrb", " lsbh='" + lsbh + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    int i = 0;
                    for (i = 0; i < ds_add.Tables[0].Rows.Count; i++)
                    {
                        B_common.ExecuteSql(" Update DH_jl  set  shsc='1'  where  id>=0  and  id='" + ds_add.Tables[0].Rows[i]["id"].ToString() + "'  and yydh='" + common_file.common_app.yydh + "' ");
                    }
                    for (i = 0; i < ds_add.Tables[0].Rows.Count; i++)
                    {
                        DS_temp = B_common.GetList("select * from Qskyd_fjrb", " lsbh='" + ds_add.Tables[0].Rows[i]["lsbh"].ToString() + "'");
                        string xfrq = ds_add.Tables[0].Rows[i]["xfrq"].ToString();
                        string xfsj = ds_add.Tables[0].Rows[i]["xfsj"].ToString();
                        string xfje = ds_add.Tables[0].Rows[i]["sjxfje"].ToString();
                        string sjxfje = ds_add.Tables[0].Rows[i]["sjxfje"].ToString();
                        string yh = "";

                        s = common_file.common_app.get_failure;
                        s = Szwmx_add_edit(zd_id, "sk", "", yydh, qymc, ds_add.Tables[0].Rows[i]["id_app"].ToString(), xfrq, xfsj, czy, "客房部", "客房电话", "客房电话", "客房电话", "客房电话", xfje, yh, sjxfje, "1", czy_bc, common_file.common_yddj.yddj_dj, czsj, syzd, add_edit_delete, xxzs, "0.0", fjrb, fjbh, "", DS_temp.Tables[0].Rows[0]["ddsj"].ToString(), DS_temp.Tables[0].Rows[0]["lksj"].ToString());
                    }
                }
                DS_temp.Clear();
                DS_temp.Dispose();
            }
            else
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        public string InsertcyFeetoZw_InsertToSingle(DataSet ds_add, string zd_id, string sk_tt, string yydh, string qymc, string lsbh,
string czy, string czy_bc, string czsj, string syzd, string add_edit_delete, string xxzs, string fjrb, string fjbh)
        {
            string s = common_file.common_app.get_failure;
            if (ds_add != null && ds_add.Tables[0].Rows.Count > 0)
            {
                //先将shsc更新为1，然后再进行单条添加
                BLL.Common B_common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_common.GetList("select * from Qskyd_fjrb", " lsbh='" + lsbh + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    int i = 0;

                    for (i = 0; i < ds_add.Tables[0].Rows.Count; i++)
                    {
                        B_common.ExecuteSql(" Update S_cy_zl  set  shsc='1'  where  id>=0  and  id='" + ds_add.Tables[0].Rows[i]["id"].ToString() + "'  and yydh='" + common_file.common_app.yydh + "' ");
                    }

                    for (i = 0; i < ds_add.Tables[0].Rows.Count; i++)
                    {
                        DS_temp = B_common.GetList("select * from Qskyd_fjrb", " lsbh='" + ds_add.Tables[0].Rows[i]["lsbh"].ToString() + "'");
                        string xfdr = ds_add.Tables[0].Rows[i]["xfdr"].ToString();
                        string xfrb = ds_add.Tables[0].Rows[i]["xfrb"].ToString();
                        string xfxm = ds_add.Tables[0].Rows[i]["xfxm"].ToString();
                        string xfbz = ds_add.Tables[0].Rows[i]["xfbz"].ToString();
                        string xfzy = ds_add.Tables[0].Rows[i]["xfzy"].ToString();
                        //string xfrq = DateTime.Parse(czsj).ToShortDateString();
                        //string xfsj = czsj;
                        string xfrq = DateTime.Parse(ds_add.Tables[0].Rows[i]["czsj"].ToString()).ToShortDateString();
                        string xfsj = ds_add.Tables[0].Rows[i]["czsj"].ToString();
                        string xfje = ds_add.Tables[0].Rows[i]["sjxfje"].ToString();
                        string sjxfje = ds_add.Tables[0].Rows[i]["sjxfje"].ToString();
                        string yh = "";
                        s = common_file.common_app.get_failure;
                        string id_app_0_0 = ds_add.Tables[0].Rows[i]["id_app"].ToString();

                        s = Szwmx_add_edit(zd_id, sk_tt, "", yydh, qymc, id_app_0_0, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, "1", czy_bc, common_file.common_yddj.yddj_dj, czsj, syzd, add_edit_delete, xxzs, "0.0", fjrb, fjbh, "mxkh004", DS_temp.Tables[0].Rows[0]["ddsj"].ToString(), DS_temp.Tables[0].Rows[0]["lksj"].ToString());
                    }
                }
                DS_temp.Clear();
                DS_temp.Dispose();
            }
            else
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }


        //杂费自动导入（电话费自动导入及餐饮费用自动导入）
        public void AutoImportFee(string yydh, string qymc, string czy, string syzd, string czsj, string xxzs)
        {
            //自动导入电话费
            DateTime Time_now = DateTime.Now.Date;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            string sql = "   fjbh!=''  and lsbh!=''   and xfsj>='" + Time_now.AddDays(-1) + "'  and xfsj<'" + Time_now + "'  and shsc=0   ";
            DataSet ds_import_dh = B_common.GetList(" select distinct  lsbh  from  dh_jl   ", sql);
            if (ds_import_dh != null && ds_import_dh.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds_import_dh.Tables[0].Rows.Count; i++)
                {
                    InsertOtherFeetoZw("sk", "true", yydh, qymc, ds_import_dh.Tables[0].Rows[i]["lsbh"].ToString(), czy, "", czsj, syzd, common_file.common_app.get_add, xxzs, "telFee");
                }
            }
            if (ds_import_dh != null)
            {
                ds_import_dh.Dispose();
            }

            //导入餐饮费用
            sql = "    lsbh!=''   and czsj>='" + Time_now.AddDays(-1) + "'  and czsj<'" + Time_now + "'  and shsc=0   ";
            DataSet ds_import_cy = null;
            ds_import_cy = B_common.GetList(" select distinct  lsbh  from  S_cy_zl   ", sql);
            if (ds_import_cy != null && ds_import_cy.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds_import_cy.Tables[0].Rows.Count; i++)
                {
                    string lsbh_0 = ds_import_cy.Tables[0].Rows[i]["lsbh"].ToString();
                    DataSet ds_0 = B_common.GetList(" select distinct  lsbh from View_Qskzd ", " lsbh='" + lsbh_0 + "' ");
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                    {
                        InsertOtherFeetoZw("sk", "true", yydh, qymc, ds_import_cy.Tables[0].Rows[i]["lsbh"].ToString(), czy, "", czsj, syzd, common_file.common_app.get_add, xxzs, "cyFee");
                    }
                    else
                    {
                        InsertOtherFeetoZw("tt", "true", yydh, qymc, ds_import_cy.Tables[0].Rows[i]["lsbh"].ToString(), czy, "", czsj, syzd, common_file.common_app.get_add, xxzs, "cyFee");
                    }
                }
            }
        }

        public float get_xydw_jfbl(string krly, string fjrb, String sjxfje_0)
        {

            float result = 0;
            float sjxfje=float.Parse(sjxfje_0);
            float cr = 0;
            BLL.Common B_Common = new BLL.Common();
            DataSet DS_temp_0 = B_Common.GetList("select * from Ffjrb_krly "," fjrb='" + fjrb + "' and krly='" + krly + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["sjjg"].ToString() != "")
                {
                    cr = sjxfje - float.Parse(DS_temp_0.Tables[0].Rows[0]["sjjg"].ToString());

                }
            }

             DS_temp_0 = B_Common.GetList("select top 1 * from Yxydw_jfbl "," fd_sl<='" + cr + "' and krly='" + krly + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["bl"].ToString() != "")
                {
                    result = float.Parse(DS_temp_0.Tables[0].Rows[0]["bl"].ToString());
                }
            }
            else
            {
                 DS_temp_0 = B_Common.GetList("select min(bl) as bl from Yxydw_jfbl ","  krly='" + krly + "'");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp_0.Tables[0].Rows[0]["bl"].ToString() != "")
                    {
                        result = float.Parse(DS_temp_0.Tables[0].Rows[0]["bl"].ToString());
                    }
                }
            }


            return result;
            
        }
        

    }
}