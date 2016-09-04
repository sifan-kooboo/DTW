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
    public class Qyddj_add_edit_delete_1
    {
        public string sk_ydzdj(string lsbh, string czy, string cznr, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            string yydh = "";
            string qymc = "";
            string krxm = "";
            string fjrb = "";
            string fjbh = "";
            DateTime yd_ddsj = DateTime.Parse(common_file.common_app.cssj);
            DateTime yd_lksj = DateTime.Parse(common_file.common_app.cssj);
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp_2 = B_Common.GetList("select * from Qskyd_fjrb", "lsbh='" + lsbh + "' and fjbh<>'' and yddj='" + common_file.common_yddj.yddj_yd + "'");
            if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
            {
                yydh = DS_temp_2.Tables[0].Rows[0]["yydh"].ToString();
                qymc = DS_temp_2.Tables[0].Rows[0]["qymc"].ToString();
                krxm = DS_temp_2.Tables[0].Rows[0]["krxm"].ToString();
                fjrb = DS_temp_2.Tables[0].Rows[0]["fjrb"].ToString();
                fjbh = DS_temp_2.Tables[0].Rows[0]["fjbh"].ToString();
                yd_ddsj = DateTime.Parse(DS_temp_2.Tables[0].Rows[0]["ddsj"].ToString());
                yd_lksj = DateTime.Parse(DS_temp_2.Tables[0].Rows[0]["lksj"].ToString());
                Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();
                s = Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(DS_temp_2.Tables[0].Rows[0]["id"].ToString(), DS_temp_2.Tables[0].Rows[0]["yydh"].ToString(), DS_temp_2.Tables[0].Rows[0]["qymc"].ToString(), lsbh, DS_temp_2.Tables[0].Rows[0]["krxm"].ToString(), "", DS_temp_2.Tables[0].Rows[0]["yddj"].ToString(), DS_temp_2.Tables[0].Rows[0]["fjrb"].ToString(), DS_temp_2.Tables[0].Rows[0]["fjbh"].ToString(), czsj, DateTime.Parse(DS_temp_2.Tables[0].Rows[0]["lksj"].ToString()), decimal.Parse(DS_temp_2.Tables[0].Rows[0]["lzfs"].ToString()), DS_temp_2.Tables[0].Rows[0]["shqh"].ToString(), decimal.Parse(DS_temp_2.Tables[0].Rows[0]["fjjg"].ToString()), decimal.Parse(DS_temp_2.Tables[0].Rows[0]["sjfjjg"].ToString()), DS_temp_2.Tables[0].Rows[0]["yh"].ToString(), decimal.Parse(DS_temp_2.Tables[0].Rows[0]["yhbl"].ToString()), DS_temp_2.Tables[0].Rows[0]["bz"].ToString(), czy, czsj, cznr, common_file.common_yddj.yddj_ydzdj, common_file.common_app.get_edit, xxzs, DS_temp_2.Tables[0].Rows[0]["fjbm"].ToString(), decimal.Parse(DS_temp_2.Tables[0].Rows[0]["jcje"].ToString()));



            }
            DS_temp_2.Dispose();
            if (s == common_file.common_app.get_suc)
            {
                s = common_file.common_app.get_failure;
                if (B_Common.ExecuteSql("update Qskyd_mainrecord set ddsj='" + czsj + "',yddj='" + common_file.common_yddj.yddj_dj + "' where lsbh='" + lsbh + "'") > 0)
                {
                    if (fjbh != "")
                    {
                        B_Common.ExecuteSql("update Ffjzt set zyzt_second='',yd_ddsj='" + common_file.common_app.cssj + "',yd_lksj='" + common_file.common_app.cssj + "' where fjbh='" + fjbh + "' and zyzt_second='" + common_file.common_yddj.yddj_yd + "' and yd_ddsj='" + yd_ddsj.ToString() + "' and yd_lksj='" + yd_lksj.ToString() + "'");
                    }
                    s = common_file.common_app.get_suc;

                }
            }
            if (s == common_file.common_app.get_suc)
            {
                //在这里判断是否是从预定中心来的单子
                DataSet ds_ydzx = B_Common.GetList(" select * from View_Qskzd ", " id>=0 and yydh='" + yydh + "' and ddyy='" + common_file_server.common_app.ydzx_flage + "' and lsbh='" + lsbh + "'  and main_sec='" + common_file.common_app.main_sec_main + "'  and shsc=0 ");
                if (ds_ydzx != null && ds_ydzx.Tables[0].Rows.Count > 0)
                {
                    Hotel_app.Server.Qyddj.Q_ff_xyxf Q_ff_xyxf_new = new Hotel_app.Server.Qyddj.Q_ff_xyxf();
                    Q_ff_xyxf_new.Qyddj_otherfee_add(yydh, qymc, lsbh, ds_ydzx.Tables[0].Rows[0]["krxm"].ToString(), ds_ydzx.Tables[0].Rows[0]["sktt"].ToString(), "", czy);


                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(" insert into    Qyqskyd_ydzlzmx(yydh, qymc, lsbh, fjrb, fjbh, sjjg, ddsj, lksj, ddrq, lkrq, lzrx, lzfs, shsc, scsj )");
                    sb.Append("  select  yydh,qymc,lsbh,fjrb,fjbh,sjfjjg,ddsj,lksj,ddsj,lksj,1,lzfs,0,'" + czsj + "'  from  View_Qskzd   where lsbh='" + lsbh + "' and yydh='" + yydh + "'  and  main_sec='" + common_file.common_app.main_sec_main + "' ");
                    B_Common.ExecuteSql(sb.ToString());

                }

                if (yydh != "")
                {
                    common_file.common_czjl.add_czjl(yydh, qymc, czy, common_file.common_yddj.yddj_ydzdj, krxm + "_" + fjrb + "_" + fjbh, lsbh, czsj);
                }
            }
            return s;
        }
        /// <summary>
        /// 预订转登记
        /// </summary>
        /// <param name="lsbh"></param>
        /// <param name="sktt"></param>两个值一个sk代表散客、长住、钟点； tt代表团体、会议
        /// <param name="ddbh"></param>如果是团体要输ddbh，如果不是放空
        /// <param name="shlf"></param>如果为TRUE时，就是所有联房都要处理；如果为FALSE时只处理自己
        /// <param name="czy"></param>
        /// <param name="cznr"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string ydzdj_app(string yydh, string qymc, string lsbh, string sktt, string ddbh, bool shlf, string czy, string cznr, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (sktt == "sk")
            {
                string lfbh = "";
                DataSet DS_temp_2 = B_Common.GetList("select lfbh from Flfsz", "lsbh='" + lsbh + "'");
                if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                {
                    lfbh = DS_temp_2.Tables[0].Rows[0]["lfbh"].ToString();
                    if (lfbh != "")
                    {
                        if (shlf == true)
                        {
                            DS_temp_2 = B_Common.GetList("select * from Qskyd_mainrecord", " lsbh in(select lsbh from Flfsz where lfbh='" + lfbh + "') and yddj='" + common_file.common_yddj.yddj_yd + "'and sktt<>'" + common_file.common_sktt.sktt_tt + "'  and sktt<>'" + common_file.common_sktt.sktt_hy + "' ");
                            if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                            {
                                for (int j_temp_0 = 0; j_temp_0 < DS_temp_2.Tables[0].Rows.Count; j_temp_0++)
                                {
                                    s = sk_ydzdj(DS_temp_2.Tables[0].Rows[j_temp_0]["lsbh"].ToString(), czy, cznr, czsj, xxzs);
                                }
                            }
                        }
                        else //如果只是要自己转，把lfbh赋空值。
                        {
                            lfbh = "";
                        }

                    }

                }
                if (lfbh == "")
                {
                    s = sk_ydzdj(lsbh, czy, cznr, czsj, xxzs);
                }
                DS_temp_2.Dispose();
            }
            else
                if (sktt == "tt")
                {
                    s = common_file.common_app.get_suc;
                    DataSet DS_temp_2 = B_Common.GetList("select * from Qskyd_mainrecord", "  ddbh='" + ddbh + "' and yddj='" + common_file.common_yddj.yddj_yd + "'");
                    if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                    {
                        s = common_file.common_app.get_failure;
                        for (int j_temp_0 = 0; j_temp_0 < DS_temp_2.Tables[0].Rows.Count; j_temp_0++)
                        {
                            s = sk_ydzdj(DS_temp_2.Tables[0].Rows[j_temp_0]["lsbh"].ToString(), czy, cznr, czsj, xxzs);

                        }

                    }
                    if (s == common_file.common_app.get_suc)
                    {
                        s = common_file.common_app.get_failure;

                        if (B_Common.ExecuteSql("update Qttyd_mainrecord set ddsj='" + czsj + "',yddj='" + common_file.common_yddj.yddj_dj + "' where lsbh='" + lsbh + "'") > 0)
                        {
                            s = common_file.common_app.get_suc;
                        }
                    }
                    if (s == common_file.common_app.get_suc)
                    {
                        DS_temp_2 = B_Common.GetList("select * from Qttyd_mainrecord", "  ddbh='" + ddbh + "'");
                        if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_czjl.add_czjl(yydh, qymc, czy, common_file.common_yddj.yddj_ydzdj, DS_temp_2.Tables[0].Rows[0]["krxm"].ToString() + "_" + DS_temp_2.Tables[0].Rows[0]["sktt"].ToString(), lsbh, czsj);
                        }
                    }
                    DS_temp_2.Dispose();
                }
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sktt"></param>sk,tt
        /// <param name="lsbh"></param>
        /// <param name="ddbh"></param>
        /// <param name="ctlt"></param>如果有出团ct，如果有入团lt，如果没有""
        /// <param name="old_sktt_bz"></param>
        /// <param name="sktt_bz"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string sktt_hz(string yydh, string qymc, string sktt, string lsbh, string krxm, string ddbh, string ctlt, string old_sktt_bz, string sktt_bz, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            int i = 0; string ddbh_News = ""; string fjbh = "";
            string sql_s = "";
            if (sktt == "sk")
            {
                i = 0;
                DataSet ds_temp = B_Common.GetList("select * from Qskyd_fjrb", "lsbh='" + lsbh + "' and fjbh<>''");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    if (ds_temp.Tables[0].Rows[0]["yddj"].ToString() == common_file.common_yddj.yddj_yd)
                    {
                        fjbh = ds_temp.Tables[0].Rows[0]["fjbh"].ToString();
                        i = B_Common.ExecuteSql("update Ffjzt set sktt='" + sktt_bz + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + ds_temp.Tables[0].Rows[0]["fjbh"].ToString() + "' and zyzt<>'" + common_file.common_fjzt.zzf + "' and zyzt_second='" + common_file.common_fjzt.ydf + "' and yd_ddsj='" + ds_temp.Tables[0].Rows[0]["ddsj"].ToString() + "' and yd_lksj='" + ds_temp.Tables[0].Rows[0]["lksj"].ToString() + "'");
                    }
                    else
                        if (ds_temp.Tables[0].Rows[0]["yddj"].ToString() == common_file.common_yddj.yddj_dj)
                        {
                            fjbh = ds_temp.Tables[0].Rows[0]["fjbh"].ToString();
                            i = B_Common.ExecuteSql("update Ffjzt set sktt='" + sktt_bz + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + ds_temp.Tables[0].Rows[0]["fjbh"].ToString() + "' and zyzt='" + common_file.common_fjzt.zzf + "' and ddsj='" + ds_temp.Tables[0].Rows[0]["ddsj"].ToString() + "' and lksj='" + ds_temp.Tables[0].Rows[0]["lksj"].ToString() + "'");
                        }
                }
                if (i > 0)
                {
                    if (sktt_bz == common_file.common_sktt.sktt_zd)
                    {
                        sql_s = "update Qskyd_mainrecord set sktt='" + sktt_bz + "',krly='" + sktt_bz + "' where lsbh='" + lsbh + "'";
                    }
                    else
                    {
                        sql_s = "update Qskyd_mainrecord set sktt='" + sktt_bz + "' where lsbh='" + lsbh + "'";
                    }
                    if (B_Common.ExecuteSql(sql_s) > 0)
                    {
                        B_Common.ExecuteSql("update Qskyd_mainrecord set xydw=krly where lsbh='" + lsbh + "' and xydw=''");
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, old_sktt_bz + "转成" + sktt_bz, krxm + "_" + fjbh, lsbh, czsj);
                        s = common_file.common_app.get_suc;
                    }
                    if (s == common_file.common_app.get_suc && ctlt != "")
                    {
                        s = common_file.common_app.get_failure;
                        if (ctlt == "ct")
                        {
                            ddbh_News = common_file.common_ddbh.ddbh("ttct", "skyddate", "skydcounter", 6);
                        }
                        else
                            if (ctlt == "lt")
                            {
                                ddbh_News = ddbh;
                            }
                        if (B_Common.ExecuteSql("update Qskyd_mainrecord set ffzf=0,ddbh='" + ddbh_News + "' where lsbh='" + lsbh + "'") > 0)
                        { s = common_file.common_app.get_suc; }
                    }
                }
            }
            else
                if (sktt == "tt")
                {
                    DataSet ds_temp = B_Common.GetList("select * from Qskyd_fjrb", "lsbh in (select lsbh from Qskyd_mainrecord where ddbh='" + ddbh + "') and fjbh<>''");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        i = 0;
                        for (int j = 0; j < ds_temp.Tables[0].Rows.Count; j++)
                        {
                            if (ds_temp.Tables[0].Rows[j]["yddj"].ToString() == common_file.common_yddj.yddj_yd)
                            {
                                i = B_Common.ExecuteSql("update Ffjzt set sktt='" + sktt_bz + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + ds_temp.Tables[0].Rows[j]["fjbh"].ToString() + "' and zyzt<>'" + common_file.common_fjzt.zzf + "' and zyzt_second='" + common_file.common_fjzt.ydf + "' and yd_ddsj='" + ds_temp.Tables[0].Rows[j]["ddsj"].ToString() + "' and yd_lksj='" + ds_temp.Tables[0].Rows[j]["lksj"].ToString() + "'");
                            }
                            else
                                if (ds_temp.Tables[0].Rows[j]["yddj"].ToString() == common_file.common_yddj.yddj_dj)
                                {
                                    i = B_Common.ExecuteSql("update Ffjzt set sktt='" + sktt_bz + "',czsj='" + DateTime.Now.ToString() + "' where fjbh='" + ds_temp.Tables[0].Rows[j]["fjbh"].ToString() + "' and zyzt='" + common_file.common_fjzt.zzf + "' and ddsj='" + ds_temp.Tables[0].Rows[j]["ddsj"].ToString() + "' and lksj='" + ds_temp.Tables[0].Rows[j]["lksj"].ToString() + "'");
                                }
                            //在这里借助Qskyd_fjrb上的触发器,来,更新otherfee里面的sk/tt的类型值
                            B_Common.ExecuteSql(" update  Qskyd_fjrb  set sktt='" + sktt_bz + "',czsj='" + DateTime.Now.ToString() + "' where lsbh='" + ds_temp.Tables[0].Rows[j]["lsbh"].ToString() + "'");
                        }
                    }
                    if (B_Common.ExecuteSql("update Qttyd_mainrecord set sktt='" + sktt_bz + "' where lsbh='" + lsbh + "'") > 0)
                    {
                        //Qyddj_otherFee这个表里面的类型要同时更改
                        s = common_file.common_app.get_suc;
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, old_sktt_bz + "转成" + sktt_bz, krxm, lsbh, czsj);
                    }
                }
            return s;
        }

        public string New_skyd_dl_record(string id, string old_lsbh, string czy, string czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            if (id != "")
            {
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                string new_lsbh = common_file.common_ddbh.ddbh("skdjN", "skdjdate", "skdjcounter", 6);
                int krzs = 0;
                DataSet DS_temp = B_Common.GetList("select count(*) as sl from Qskyd_mainrecord", "lsbh='" + old_lsbh + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    krzs = int.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    if (krzs > 2) { krzs = 2; }
                }
                if (krzs > 1)
                {
                    string insert_s = "";
                    decimal[] fjjg = new decimal[krzs]; decimal[] sjfjjg = new decimal[krzs];
                    BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
                    Model.Qskyd_fjrb M_Qskyd_fjrb = new Hotel_app.Model.Qskyd_fjrb();
                    Model.Qskyd_fjrb M_Qskyd_fjrb_temp = new Hotel_app.Model.Qskyd_fjrb();
                    DS_temp = B_Common.GetList("select id from Qskyd_fjrb", "lsbh='" + old_lsbh + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        string id_0 = DS_temp.Tables[0].Rows[0]["id"].ToString();
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(id_0));
                        if (M_Qskyd_fjrb != null)
                        {
                            decimal fjjg_temp = 0; decimal sjfjjg_temp = 0;
                            for (int i_0 = 0; i_0 < krzs; i_0++)
                            {
                                if (i_0 < (krzs - 1))
                                {
                                    fjjg[i_0] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(Convert.ToString(M_Qskyd_fjrb.fjjg / krzs)), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                                    fjjg_temp = fjjg_temp + fjjg[i_0];
                                    sjfjjg[i_0] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(Convert.ToString(M_Qskyd_fjrb.sjfjjg / krzs)), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                                    sjfjjg_temp = sjfjjg_temp + fjjg[i_0];
                                }
                            }
                            fjjg[krzs - 1] = M_Qskyd_fjrb.fjjg - fjjg_temp;
                            sjfjjg[krzs - 1] = M_Qskyd_fjrb.sjfjjg - sjfjjg_temp;
                            insert_s = "insert into Qskyd_fjrb (yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,is_top,is_select,shsc,czy,czsj,cznr,sdcz,fjbm)";
                            insert_s = insert_s + " select yydh,qymc,'" + new_lsbh + "',krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,0,shqh,'" + fjjg[krzs - 1].ToString() + "','" + sjfjjg[krzs - 1].ToString() + "',yh,yhbl,bz,0,0,0,'" + czy + "','" + czsj + "','" + common_file.common_app.chinese_add + "',sdcz,fjbm from Qskyd_fjrb where lsbh='" + old_lsbh + "'";
                            B_Common.ExecuteSql(insert_s);
                            //增加配套费用
                            Q_ff_xyxf Q_ff_xyxf_new = new Q_ff_xyxf();
                            Q_ff_xyxf_new.Qyddj_otherfee_add(M_Qskyd_fjrb.yydh, M_Qskyd_fjrb.qymc, new_lsbh, M_Qskyd_fjrb.krxm, M_Qskyd_fjrb.sktt, "", czy);
                            B_Common.ExecuteSql("update Qskyd_fjrb set fjjg='" + fjjg[0] + "',sjfjjg='" + sjfjjg[0] + "' where lsbh='" + old_lsbh + "'");
                            insert_s = "insert into Szwzd(yydh,qymc,lsbh,krxm,sktt,yddj,fjbh,fkje,xfje,main_sec,is_top,is_select)";
                            insert_s = insert_s + " select yydh,qymc,'" + new_lsbh + "',krxm,sktt,yddj,fjbh,0,0,'" + common_file.common_app.main_sec_sec + "',0,0 from Szwzd where lsbh='" + old_lsbh + "'";
                            B_Common.ExecuteSql(insert_s);
                            B_Common.ExecuteSql("update Qskyd_mainrecord set main_sec='" + common_file.common_app.main_sec_main + "',lsbh='" + new_lsbh + "' where id='" + id + "'");
                            common_file.common_czjl.add_czjl(M_Qskyd_fjrb.yydh, M_Qskyd_fjrb.qymc, czy, "自成主单", "旧" + old_lsbh + "/新" + new_lsbh, M_Qskyd_fjrb.fjbh, DateTime.Parse(czsj));
                            s = common_file.common_app.get_suc;
                        }
                    }
                }
                DS_temp.Dispose();
            }
            return s;
        }
    }
}
