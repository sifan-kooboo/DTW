using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Qyddj
{

    public class Qskyd_fjrb_add_edit_delete
    {

        /// <param name="zyzt"></param>//有三种状态,一种预订、一种登记、一种预订转登记

        public string Qskyd_fjrb_add_edit_delete_app(string id, string yydh, string qymc, string lsbh, string krxm, string sktt, string yddj, string fjrb, string fjbh, DateTime ddsj, DateTime lksj, Decimal lzfs, string shqh, decimal fjjg, decimal sjfjjg, string yh, decimal yhbl, string bz, string czy, DateTime czsj, string cznr, string zyzt, string add_edit_delete, string xxzs,string fjbm,decimal jcje)
        {
            string s = common_file.common_app.get_failure;
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            Model.Qskyd_fjrb M_Qskyd_fjrb = new Hotel_app.Model.Qskyd_fjrb();
            Model.Ffjzt M_Ffjzt = new Hotel_app.Model.Ffjzt();
            string old_fjbh = "";
            string old_fjbm = "";
            DataSet ds_temp = B_Ffjzt.GetList("fjbh='" + fjbh + "'");
            string krxm0 = ""; string sktt0 = ""; string lsbh0 = "";
            bool shlf0 = false; bool shts0 = false; bool shvip0 = false;
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Qskyd_fjrb.bz = bz;
                M_Qskyd_fjrb.cznr = cznr;
                M_Qskyd_fjrb.czsj = czsj;
                M_Qskyd_fjrb.czy = czy;
                M_Qskyd_fjrb.ddsj = ddsj;
                M_Qskyd_fjrb.fjbh = fjbh;
                M_Qskyd_fjrb.fjjg = fjjg;
                M_Qskyd_fjrb.fjrb = fjrb;
                M_Qskyd_fjrb.krxm = krxm;
                M_Qskyd_fjrb.lksj = lksj;
                M_Qskyd_fjrb.lsbh = lsbh;
                M_Qskyd_fjrb.lzfs = lzfs;
                M_Qskyd_fjrb.qymc = qymc;
                M_Qskyd_fjrb.shqh = shqh;
                M_Qskyd_fjrb.sjfjjg = sjfjjg;
                M_Qskyd_fjrb.sktt = sktt;
                M_Qskyd_fjrb.yddj = yddj;
                M_Qskyd_fjrb.yh = yh;
                M_Qskyd_fjrb.yhbl = yhbl;
                M_Qskyd_fjrb.yydh = yydh;
                M_Qskyd_fjrb.fjbm = fjbm;
                M_Qskyd_fjrb.jcje = jcje;
                int IsSuc = B_Qskyd_fjrb.Add(M_Qskyd_fjrb);
                if (IsSuc > 0)
                {
                    s = common_file.common_app.get_suc;
                    if (zyzt == common_file.common_yddj.yddj_dj)
                    {
                        if (fjbh != "")
                        {
                            s = add_fjbh_dj_fjzt(fjbh, M_Qskyd_fjrb, czsj, czy, xxzs);

                        }

                    }
                    else
                        if (zyzt == common_file.common_yddj.yddj_yd)
                        {

                            if (fjbh != "")
                            {
                                s = add_fjbh_yd_fjzt(lsbh, fjbh, sktt, czsj, czy, xxzs);
                            }
                        }

                }



            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(id));
                    if (M_Qskyd_fjrb != null)
                    {
                        old_fjbh = M_Qskyd_fjrb.fjbh;  //根据Id读取旧的房间编号old_fjbh
                        string old_fjjg=M_Qskyd_fjrb.fjjg.ToString();
                        string old_sjfjjg=M_Qskyd_fjrb.sjfjjg.ToString();
                        DateTime old_ddsj = M_Qskyd_fjrb.ddsj;
                        DateTime old_lksj = M_Qskyd_fjrb.lksj;
                        M_Qskyd_fjrb.fjrb = fjrb;
                        M_Qskyd_fjrb.fjbh = fjbh;
                        M_Qskyd_fjrb.lzfs = lzfs;
                        M_Qskyd_fjrb.shqh = shqh;
                        M_Qskyd_fjrb.fjjg = fjjg;
                        M_Qskyd_fjrb.sjfjjg = sjfjjg;
                        M_Qskyd_fjrb.yh = yh;
                        M_Qskyd_fjrb.yhbl = yhbl;
                        M_Qskyd_fjrb.bz = bz;
                        M_Qskyd_fjrb.czy = czy;
                        M_Qskyd_fjrb.czsj = czsj;
                        M_Qskyd_fjrb.cznr = cznr;
                        M_Qskyd_fjrb.fjbm = fjbm;
                        M_Qskyd_fjrb.jcje = jcje;
                        if (B_Qskyd_fjrb.Update(M_Qskyd_fjrb))
                        {
                            
                            if (zyzt == common_file.common_yddj.yddj_dj)  //如果yddj等于登记
                            {
                                if (old_fjbh != fjbh)//如果旧房间编号不等于新的房间编号说明换房了
                                {
                                    s = common_file.common_app.get_failure;

                                    if (fjbh != "")//先把新的房号的房态先修改进去
                                    {
                                        s = add_fjbh_dj_fjzt(fjbh, M_Qskyd_fjrb, czsj, czy, xxzs);
                                    }

                                    if (old_fjbh != "")//如果原来房间编号不为空读出相关客人信息，然后把这间房间改为脏房
                                    {

                                        s = clear_old_dj_fjzt(old_fjbh, czsj, czy, xxzs);
                                    }

                                    if (old_fjbh != "")
                                    {
                                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "换房", "原来房号：" + old_fjbh, "换后房号：" + fjbh, czsj);
                                    }

                                }
                                if (fjbm == common_file.common_app.fjbm_bm && fjbh != "")//修改房价保密的判断
                                {
                                    B_Common.ExecuteSql("update Ffjzt set fjbm=1,czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh + "' and fjbm=0");
                                }
                                else
                                    if (fjbm != common_file.common_app.fjbm_bm && fjbh != "")
                                    {
                                        B_Common.ExecuteSql("update Ffjzt set fjbm=0,czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh + "' and fjbm=1");
                                    
                                    }
                            }
                            else
                                if (zyzt == common_file.common_yddj.yddj_yd)  //如果yddj等于预订
                                {
                                    if (old_fjbh != fjbh)//如果旧房间编号不等于新的房间编号说明换房了
                                    {
                                        if (old_fjbh != "")//如果原来房间编号不为空读出相关客人信息，然后把这间房间改为原来的状态
                                        {


                                            s = clear_old_yd_fjzt(old_fjbh, old_ddsj, old_lksj, czsj, czy, xxzs);



                                        }
                                        if (fjbh != "")//现在的房号不为空--预订
                                        {

                                            s = add_fjbh_yd_fjzt(lsbh, fjbh, sktt, czsj, czy, xxzs);

                                        }

                                    }
                                    if (fjbm == common_file.common_app.fjbm_bm && fjbh != "")//修改房价保密的判断
                                    {
                                        B_Common.ExecuteSql("update Ffjzt set fjbm=1,czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh + "' and fjbm=0 and zyzt<>'" + common_file.common_fjzt.zzf + "' and yd_ddsj='" + M_Qskyd_fjrb.ddsj.ToString() + "' and yd_lksj='" + M_Qskyd_fjrb.lksj.ToString() + "'");
                                    }
                                    else
                                        if (fjbm != common_file.common_app.fjbm_bm && fjbh != "")
                                        {
                                            B_Common.ExecuteSql("update Ffjzt set fjbm=0,czsj='" + DateTime.Now.ToString() + "' where fjbh='" + fjbh + "' and fjbm=1 and zyzt<>'" + common_file.common_fjzt.zzf + "' and yd_ddsj='" + M_Qskyd_fjrb.ddsj.ToString() + "' and yd_lksj='" + M_Qskyd_fjrb.lksj.ToString() + "'");

                                        }
                                }
                                else
                                    if (zyzt == common_file.common_yddj.yddj_ydzdj)
                                    {
                                        DataSet DS_temp_1 = B_Common.GetList("select * from Ffjzt", "fjbh='" + fjbh + "' and zyzt_second='" + common_file.common_fjzt.ydf + "' and yd_ddsj='" + M_Qskyd_fjrb.ddsj + "' and yd_lksj='" + M_Qskyd_fjrb.lksj + "'");
                                        if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count >= 0)
                                        {
                                            clear_old_yd_fjzt(M_Qskyd_fjrb.fjbh, old_ddsj, old_lksj, czsj, czy, xxzs);
                                            if (old_ddsj.ToShortDateString() != czsj.ToShortDateString())
                                            {
                                                if(DateTime.Parse(old_ddsj.ToShortDateString())>DateTime.Parse(czsj.ToShortDateString()))
                                                {
                                                    common_file.common_czjl.add_czjl(yydh, qymc, czy, zyzt, krxm + "_" + fjrb + "_" + fjbh+"_"+lsbh, "由" + old_ddsj.ToShortDateString() + "提前至" + czsj.ToShortDateString(),czsj);
                                                }
                                                else
                                                    if (DateTime.Parse(old_ddsj.ToShortDateString()) < DateTime.Parse(czsj.ToShortDateString()))
                                                    {
                                                        common_file.common_czjl.add_czjl(yydh, qymc, czy, zyzt, krxm + "_" + fjrb + "_" + fjbh + "_" + lsbh, "由" + old_ddsj.ToShortDateString() + "推迟至" + czsj.ToShortDateString(),czsj);
                                                    }
                                            }
                                        }
                                        if (add_fjbh_dj_fjzt(fjbh, M_Qskyd_fjrb, czsj, czy, xxzs) == common_file.common_app.get_suc)
                                        {
                                            B_Common.ExecuteSql("update Ffjzt set ddsj='" + ddsj.ToString() + "' where fjbh='" + fjbh + "'");
                                        }
                                    }
                            if (M_Qskyd_fjrb.fjbh == "")
                            {
                                string s_0 = "update Qskyd_fjrb set fjjg='" + M_Qskyd_fjrb.fjjg.ToString() + "',sjfjjg='" + M_Qskyd_fjrb.sjfjjg.ToString() + "' , yh='" + M_Qskyd_fjrb.yh + "' , yhbl='" + M_Qskyd_fjrb.yhbl.ToString() + "',fjbm='"+M_Qskyd_fjrb.fjbm+"' where (fjrb='" + M_Qskyd_fjrb.fjrb + "' and fjbh<>'') and (fjjg='" + old_fjjg + "' and sjfjjg='" + old_sjfjjg + "') and (lsbh in(select lsbh from Qskyd_mainrecord where ddbh in(select ddbh from Qttyd_mainrecord where lsbh='" + M_Qskyd_fjrb.lsbh + "')))";
                                B_Common.ExecuteSql(s_0);
                            }
                            s = common_file.common_app.get_suc;
                            //以下对房态进行再次修改以保证房态会自动刷新
                            if (M_Qskyd_fjrb.yddj == common_file.common_yddj.yddj_dj)
                            {
                                B_Common.ExecuteSql("update Ffjzt set czsj='" + DateTime.Now.ToString() + "'");
                            }
                            else
                                if (M_Qskyd_fjrb.yddj == common_file.common_yddj.yddj_yd)
                                {
                                    if (M_Qskyd_fjrb.ddsj > DateTime.Parse(DateTime.Now.ToShortDateString()) && M_Qskyd_fjrb.ddsj < DateTime.Parse(DateTime.Now.AddDays(1).ToShortDateString()))
                                    {
                                        B_Common.ExecuteSql("update Ffjzt set czsj='" + DateTime.Now.ToString() + "'");
                                    }
                                }
                        }
                        
                    }

                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            String s_0 = "insert into Qskyd_fjrb_temp(yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm,jcje)";
                            s_0 = s_0 + "select yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,'" + czy + "','" + czsj + "','" + cznr + "',sdcz,fjbm,jcje from Qskyd_fjrb where id='" + id + "'";
                            if (B_Common.ExecuteSql(s_0) > 0)
                            {
                                if (B_Qskyd_fjrb.Delete(int.Parse(id)) == true)
                                {
                                    common_file.common_czjl.add_czjl(yydh,qymc,czy,"强制删除多排"+lzfs+fjrb,krxm,lsbh,czsj);
                                    s = common_file.common_app.get_suc;
                                }
                            }
                            
                        }

                    }
            ds_temp.Dispose();
            return s;
        }



        public string clear_old_dj_fjzt(string old_fjbh, DateTime czsj, string czy, string xxzs)
        //登记换房时清除旧的房态清除
        {
            string s = common_file.common_app.get_failure;
            string krxm0 = ""; string sktt0 = ""; string lsbh0 = "";
            bool shlf0 = false; bool shts0 = false; bool shvip0 = false; bool fjbm0 = false;
            string zyzt_second0 = "";
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            Model.Ffjzt M_Ffjzt;
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();
            DataSet ds_temp = B_Ffjzt.GetList("fjbh='" + old_fjbh + "'");
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                M_Ffjzt = B_Ffjzt.GetModel(int.Parse(ds_temp.Tables[0].Rows[0]["id"].ToString()));
                //在Qskyd_fjrb表里查询出预订客人的相关住房登记信息

                DateTime yd_ddsj0 = DateTime.Parse(common_file.common_app.cssj);
                DateTime yd_lksj0 = DateTime.Parse(common_file.common_app.cssj);
                ds_temp = B_Qskyd_fjrb.GetList("yddj='" + common_file.common_yddj.yddj_yd + "' and fjbh='" + old_fjbh + "' and ddsj='" + M_Ffjzt.yd_ddsj.ToString() + "' and lksj='" + M_Ffjzt.yd_lksj.ToString() + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    lsbh0 = ds_temp.Tables[0].Rows[0]["lsbh"].ToString();
                    shlf0 = common_file.common_fjzt.Islf(lsbh0);   //判断是否联房
                    shts0 = common_file.common_fjzt.Ists(lsbh0);//判断是否特殊
                    shvip0 = common_file.common_fjzt.IsVIP(lsbh0);//判断是否VIP或会员
                    fjbm0 = common_file.common_fjzt.Isbm(lsbh0);
                    krxm0 = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                    sktt0 = ds_temp.Tables[0].Rows[0]["sktt"].ToString();
                    lsbh0 = ds_temp.Tables[0].Rows[0]["lsbh"].ToString();
                    zyzt_second0 = common_file.common_fjzt.ydf;
                    yd_ddsj0 = DateTime.Parse(ds_temp.Tables[0].Rows[0]["ddsj"].ToString());
                    yd_lksj0 = DateTime.Parse(ds_temp.Tables[0].Rows[0]["lksj"].ToString());
                }

                Ffjzt_add_edit_new.Ffjzt_xgft(common_file.common_fjzt.zf, zyzt_second0, common_file.common_fjzt.ff, old_fjbh, krxm0, DateTime.Parse(common_file.common_app.cssj), DateTime.Parse(common_file.common_app.cssj), yd_ddsj0, yd_lksj0, shlf0, shts0, shvip0,fjbm0, sktt0, lsbh0, czsj, czy, common_file.common_fjzt.ff, xxzs);
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        //public string add_fjbh_dj_fjzt(string fjbh, Model.Qskyd_fjrb M_Qskyd_fjrb, DateTime czsj, string czy, string xxzs)
        ////登记时变更去修改房态,返回成功或失败
        //{
        //    string s = common_file.common_app.get_failure;
        //    string krxm0 = ""; string sktt0 = ""; string lsbh0 = "";
        //    bool shlf0 = false; bool shts0 = false; bool shvip0 = false; bool fjbm0 = false;
        //    BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
        //    DataSet ds_temp = B_Ffjzt.GetList("fjbh='" + fjbh + "'");
        //    Model.Ffjzt M_Ffjzt;
        //    Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Ffjzt.Ffjzt_add_edit();
        //    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
        //    {
        //        M_Ffjzt = B_Ffjzt.GetModel(int.Parse(ds_temp.Tables[0].Rows[0]["id"].ToString()));
        //        lsbh0 = M_Qskyd_fjrb.lsbh;
        //        krxm0 = M_Qskyd_fjrb.krxm;
        //        sktt0 = M_Qskyd_fjrb.sktt;
        //        shlf0 = common_file.common_fjzt.Islf(lsbh0);   //判断是否联房
        //        shts0 = common_file.common_fjzt.Ists(lsbh0);//判断是否特殊
        //        shvip0 = common_file.common_fjzt.IsVIP(lsbh0);//判断是否VIP或会员
        //        fjbm0 = common_file.common_fjzt.Isbm(lsbh0);
        //        Ffjzt_add_edit_new.Ffjzt_xgft(common_file.common_fjzt.zzf, M_Ffjzt.zyzt_second, M_Ffjzt.zybz, fjbh, krxm0, M_Qskyd_fjrb.ddsj, M_Qskyd_fjrb.lksj, M_Ffjzt.yd_ddsj, M_Ffjzt.yd_lksj, shlf0, shts0, shvip0,fjbm0, sktt0, lsbh0, czsj, czy, common_file.common_fjzt.ff, xxzs);
        //        s = common_file.common_app.get_suc;
        //    }
        //    return s;
        //}



        //登记时变更去修改房态,返回成功或失败
        public string add_fjbh_dj_fjzt(string fjbh, Model.Qskyd_fjrb M_Qskyd_fjrb, DateTime czsj, string czy, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string krxm0 = ""; string sktt0 = ""; string lsbh0 = "";
            bool shlf0 = false; bool shts0 = false; bool shvip0 = false; bool fjbm0 = false;
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            DataSet ds_temp = B_Ffjzt.GetList("fjbh='" + fjbh + "'");
            Model.Ffjzt M_Ffjzt;
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                M_Ffjzt = B_Ffjzt.GetModel(int.Parse(ds_temp.Tables[0].Rows[0]["id"].ToString()));
                lsbh0 = M_Qskyd_fjrb.lsbh;
                krxm0 = M_Qskyd_fjrb.krxm;
                sktt0 = M_Qskyd_fjrb.sktt;
                DateTime yd_ddsj_temp = M_Qskyd_fjrb.ddsj;
                DateTime yd_lksj_temp = M_Qskyd_fjrb.lksj;
                shlf0 = common_file.common_fjzt.Islf(lsbh0);   //判断是否联房
                shts0 = common_file.common_fjzt.Ists(lsbh0);//判断是否特殊
                shvip0 = common_file.common_fjzt.IsVIP(lsbh0);//判断是否VIP或会员
                fjbm0 = common_file.common_fjzt.Isbm(lsbh0);
                Ffjzt_add_edit_new.Ffjzt_xgft(common_file.common_fjzt.zzf, M_Ffjzt.zyzt_second, M_Ffjzt.zybz, fjbh, krxm0, M_Qskyd_fjrb.ddsj, M_Qskyd_fjrb.lksj, M_Ffjzt.yd_ddsj, M_Ffjzt.yd_lksj, shlf0, shts0, shvip0, fjbm0, sktt0, lsbh0, czsj, czy, common_file.common_fjzt.ff, xxzs);

                M_Ffjzt = B_Ffjzt.GetModel(int.Parse(ds_temp.Tables[0].Rows[0]["id"].ToString()));
                if (M_Ffjzt != null)
                {
                    if (M_Ffjzt.yd_ddsj == yd_ddsj_temp && M_Ffjzt.yd_lksj == yd_lksj_temp)
                    {
                        M_Ffjzt.zyzt_second = "";
                        M_Ffjzt.yd_ddsj = DateTime.Parse(common_file.common_app.cssj);
                        M_Ffjzt.yd_lksj = DateTime.Parse(common_file.common_app.cssj);
                        B_Ffjzt.Update(M_Ffjzt);
                    }
                }

                s = common_file.common_app.get_suc;
            }
            //s = common_file.common_app.get_suc;
            return s;
        }



        public string clear_old_yd_fjzt(string old_fjbh, DateTime ddsj, DateTime lksj, DateTime czsj, string czy, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string krxm0 = ""; string sktt0 = ""; string lsbh0 = "";
            bool shlf0 = false; bool shts0 = false; bool shvip0 = false; bool fjbm0 = false;
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            DataSet ds_temp = B_Ffjzt.GetList("fjbh='" + old_fjbh + "'");//选择旧房号
            Model.Ffjzt M_Ffjzt;
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                s = common_file.common_app.get_suc;
                M_Ffjzt = B_Ffjzt.GetModel(int.Parse(ds_temp.Tables[0].Rows[0]["id"].ToString()));
                ds_temp = B_Ffjzt.GetList("zyzt_second='" + common_file.common_fjzt.ydf + "' and fjbh='" + old_fjbh + "' and yd_ddsj='" + ddsj.ToString() + "' and yd_lksj='" + lksj.ToString() + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)//原来如果有在房态里体现预订的话要先清除,但新的房号如果有排也要重新加载新房号的房态
                {
                    s = common_file.common_app.get_failure;
                    //krxm0 = ""; sktt0 = ""; lsbh0 = "";
                    //shlf0 = false; shts0 = false; shvip0 = false;
                    //为什么要下面这步,为了在没在住房时清除以下三个值.
                    if (M_Ffjzt.zyzt == common_file.common_fjzt.zzf)
                    {
                        krxm0 = M_Ffjzt.krxm; lsbh0 = M_Ffjzt.lsbh; sktt0 = M_Ffjzt.sktt;
                        shlf0 = M_Ffjzt.shlf; shts0 = M_Ffjzt.shts; shvip0 = M_Ffjzt.shvip; fjbm0 = M_Ffjzt.fjbm;
                    }
                    Ffjzt_add_edit_new.Ffjzt_xgft(M_Ffjzt.zyzt, "", M_Ffjzt.zybz, old_fjbh, krxm0, M_Ffjzt.ddsj, M_Ffjzt.lksj, DateTime.Parse(common_file.common_app.cssj), DateTime.Parse(common_file.common_app.cssj), shlf0, shts0, shvip0,fjbm0, sktt0, lsbh0, czsj, czy, "预订清除", xxzs);
                    s = common_file.common_app.get_suc;

                }

            }
            return s;
        }

        public string add_fjbh_yd_fjzt(string lsbh, string fjbh, string sktt, DateTime czsj, string czy, string xxzs)
        //预订时变更去修改房态,返回成功或失败
        {
            string s = common_file.common_app.get_failure;
            string krxm0 = ""; string sktt0 = ""; string lsbh0 = "";
            bool shlf0 = false; bool shts0 = false; bool shvip0 = false; bool fjbm0 = false;
            BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
            Model.Ffjzt M_fjzt_temp;
            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();
            DataSet ds_temp = B_Qskyd_fjrb.GetList("lsbh='" + lsbh + "'");
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                s = common_file.common_app.get_failure;
                krxm0 = ds_temp.Tables[0].Rows[0]["krxm"].ToString();
                sktt0 = ds_temp.Tables[0].Rows[0]["sktt"].ToString();
                lsbh0 = ds_temp.Tables[0].Rows[0]["lsbh"].ToString();
                DateTime yd_ddsj_0 = DateTime.Parse(ds_temp.Tables[0].Rows[0]["ddsj"].ToString());
                DateTime yd_lksj_0 = DateTime.Parse(ds_temp.Tables[0].Rows[0]["lksj"].ToString());
                s = common_file.common_app.get_suc;
                if (yd_ddsj_0 >= DateTime.Now.Date && yd_ddsj_0 < DateTime.Now.Date.AddDays(1))
                //当天预订才去修改房态
                {
                    shlf0 = common_file.common_fjzt.Islf(lsbh0);   //判断是否联房
                    shts0 = common_file.common_fjzt.Ists(lsbh0);//判断是否特殊
                    shvip0 = common_file.common_fjzt.IsVIP(lsbh0);//判断是否VIP或会员
                    fjbm0 = common_file.common_fjzt.Isbm(lsbh0);
                    s = common_file.common_app.get_suc;
                    ds_temp = B_Ffjzt.GetList("fjbh='" + fjbh + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        s = common_file.common_app.get_failure;
                        M_fjzt_temp = B_Ffjzt.GetModel(int.Parse(ds_temp.Tables[0].Rows[0]["id"].ToString()));
                        if (M_fjzt_temp.zyzt == common_file.common_fjzt.zzf)
                        {
                            sktt0 = M_fjzt_temp.sktt;
                            lsbh0 = M_fjzt_temp.lsbh;
                            krxm0 = M_fjzt_temp.krxm;
                            shlf0 = M_fjzt_temp.shlf;//common_file.common_fjzt.Islf(lsbh);   //判断是否联房
                            shts0 = M_fjzt_temp.shts;//common_file.common_fjzt.Ists(lsbh);//判断是否特殊
                            shvip0 = M_fjzt_temp.shvip;//common_file.common_fjzt.IsVIP(lsbh);//判断是否VIP或会员
                            fjbm0 = M_fjzt_temp.fjbm;
                        }
                        //else
                        //{ sktt0 = M_fjzt_temp.sktt; lsbh0 = M_fjzt_temp.lsbh; }
                        //重新加载新房号的房态
                        Ffjzt_add_edit_new.Ffjzt_xgft(M_fjzt_temp.zyzt, common_file.common_fjzt.ydf, M_fjzt_temp.zybz, fjbh, krxm0, M_fjzt_temp.ddsj, M_fjzt_temp.lksj, yd_ddsj_0, yd_lksj_0, shlf0, shts0, shvip0,fjbm0, sktt0, lsbh0, czsj, czy, "加载预订", xxzs);
                        s = common_file.common_app.get_suc;
                    }
                }
            }
            return s;

        }



    }


}
