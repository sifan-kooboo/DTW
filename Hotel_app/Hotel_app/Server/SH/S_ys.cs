using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.SH
{
    public class S_ys
    {

        public string New_ys(string yydh, string qymc, string czy, DateTime czsj, string syzd, string czy_bc, bool sh_ds, string bz, string xxzs, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            //先把值给锁掉
            B_Common.ExecuteSql("update Qcounter set shys=1 ");
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—锁定成功", bz, czsj);
            //清除数据
            SH_YS SH_YS_new = new SH_YS();
            SH_YS_new.delete_all_trash(yydh, qymc, czy, czsj, xxzs);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—清除数据成功", bz, czsj);
            //产生房费

            Szwgl.Szwmx Szwmx_new = new Szwgl.Szwmx();
            Szwmx_new.New_all_fjfy(yydh, qymc, czy_bc, syzd, czy, czsj, xxzs);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—生成房费成功", bz, czsj);

            //导入电话费
            Szwgl.Szwmx Szwmx_new1 = new Szwgl.Szwmx();
            Szwmx_new1.AutoImportFee(yydh, qymc, czy, syzd, czsj.ToString(), xxzs);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—导入杂费成功", bz, czsj);

            //调整结账状态和操作状态
            update_jzzt_czzt(B_Common, yydh, qymc);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—调整结账状态和操作状态", bz, czsj);

            //生成审核后的未结在住费用
            add_sh_wj(yydh, qymc, DateTime.Parse(czsj.AddDays(-1).ToShortDateString()), czy, czsj, xxzs);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—生成审核后未结费用", bz, czsj);

            //生成库存统计
            //BBfx.B_kc B_kc_new = new Hotel_app.BBfx.B_kc();
            //B_kc_new.kc_fx(yydh, qymc, czsj.ToString(), bz, czy, xxzs);
           // common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—生成出库统计", bz, czsj);

            //生成报表

            BBfx.B_zhrbb B_zhrbb_new = new BBfx.B_zhrbb();
            B_zhrbb_new.New_zhrbb_app(yydh, qymc, DateTime.Parse(czsj.AddDays(-1).ToShortDateString()), czy, czsj, 4, xxzs);
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—生成报表成功", bz, czsj);

            //生成在住脏房
            if (sh_ds == true)
            {
                B_Common.ExecuteSql("update Ffjzt set zybz='" + common_file.common_fjzt.yjf + "',czsj='" + DateTime.Now.ToString() + "' where zyzt='" + common_file.common_fjzt.zzf + "'");
                common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—生成已洁房成功", bz, czsj);
            }

            //锁掉前天的账务
            B_Common.ExecuteSql("update Sjzzd set shys=1 where czsj<'" + czsj.ToShortDateString() + "'");
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—锁定账务主单成功", bz, czsj);




            //生成每天的收款明细
            Szwgl.S_jb_jk_fx S_jb_jk_fx_new = new Hotel_app.Server.Szwgl.S_jb_jk_fx();

            //生成每日交款明细与交班是一样的
            DataSet DS_temp = B_Common.GetList("select * from Xsyzd", "id>=0 order by id");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {

                    S_jb_jk_fx_new.add_jb_app(yydh, qymc, DS_temp.Tables[0].Rows[j_0]["syzd"].ToString(), czy, czy, "", DateTime.Parse(czsj.AddDays(-1).ToShortDateString() + " 23:59:59"), czy, "交款", Szwgl.common_zw.jb_jk_jk, xxzs,czy_GUID);

                }
                common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—生成交款单成功", bz, czsj);
            }




            //记录夜审时间
            B_Common.ExecuteSql("insert into Sqs(yydh,qymc,qsdate) values ('" + yydh + "','" + qymc + "','" + czsj.ToString() + "')");
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—记录时间", bz, czsj);



            //把之前锁起来的值放开
            B_Common.ExecuteSql("update Qcounter set shys=0");
            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核—取消锁定", bz, czsj);

            common_file.common_czjl.add_czjl(yydh, qymc, czy, "正常审核", "正常审核结束-完全成功", bz, czsj);


            s = common_file.common_app.get_suc;
            return s;
        }

        /// <summary>
        /// 生成审核后的未结在住费用
        /// </summary>
        /// <returns></returns>
        public string add_sh_wj(string yydh, string qymc, DateTime rq, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;

            string jssj = rq.ToShortDateString() + " 23:59:59";
            string xfsj_cond = " and xfsj <='" + jssj + "' ";
            string czsj_cond = " and czsj <='" + jssj + "' ";

            string yj_czsj = " and (czsj >= '" + czsj.ToShortDateString() + "' and czsj < '" + czsj.ToString() + "')";//针对已结的前天未结

            BLL.Common B_Common = new Hotel_app.BLL.Common();
            B_Common.ExecuteSql("delete from BB_sh_wj where yydh='" + yydh + "' and bbrq='" + rq.ToString() + "'");


            int i_0 = 0; int j_0 = 0;
            decimal zfh = 0; decimal ds = 0; decimal qt = 0; decimal zyye = 0;

            //在住团队_夜审时还在住
            DataSet DS_zd = B_Common.GetList("select * from View_Qttzd", "yydh='" + yydh + "' and (yddj='" + common_file.common_yddj.yddj_dj + "' or (yddj='" + common_file.common_yddj.yddj_yd + "' and xfje>0)) order by ddsj");
            DataSet DS_mx = B_Common.GetList("select * from View_Qttzd", "yydh='" + yydh + "' and (yddj='" + common_file.common_yddj.yddj_dj + "' or (yddj='" + common_file.common_yddj.yddj_yd + "' and xfje>0)) order by ddsj");
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                {
                    zfh = 0; ds = 0; qt = 0; zyye = 0;
                    DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from Szwmx", " jzbh='' and  lsbh='" + DS_zd.Tables[0].Rows[i_0]["lsbh"].ToString() + "'" + xfsj_cond + " group by xfdr");
                    if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                    {
                        for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                        {
                            if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                            {
                                if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                {
                                    zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                }
                                else
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                    {
                                        ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                    { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                            }

                            zyye = zfh + ds + qt;

                        }
                    }
                    insert_app(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["lksj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString());

                }
            }






            //在住团队_夜审时已经退房

            DS_zd = B_Common.GetList("select * from Sjzzd", "yydh='" + yydh + "' and (czzt='" + common_file.common_jzzt.czzt_sz + "' or czzt='" + common_file.common_jzzt.czzt_bfsz + "' or czzt='" + common_file.common_jzzt.czzt_gz + "' or czzt='" + common_file.common_jzzt.czzt_jz + "') and fjbh='' " + yj_czsj);
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {

                    for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                    {
                        if (DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString()).ToShortDateString() != DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["czsj"].ToString()).ToShortDateString())
                        {
                        zfh = 0; ds = 0; qt = 0; zyye = 0;
                        DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from Sjzmx", "  jzbh='" + DS_zd.Tables[0].Rows[i_0]["jzbh"].ToString() + "'  and xfdr<>'" + common_file.common_app.fkdr + "' " + xfsj_cond + "  group by xfdr");
                        if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                        {
                            for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                            {
                                if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                                {
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                    {
                                        zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                        if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                        {
                                            ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                        }
                                        else
                                        { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                                }

                                zyye = zfh + ds + qt;

                            }
                        }
                        insert_app(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString());

                    }
                }
            }







            //在住散客_夜审时还在住
            DS_zd = B_Common.GetList("select * from View_Qskzd", "yydh='" + yydh + "' and yddj='" + common_file.common_yddj.yddj_dj + "' and main_sec='" + common_file.common_app.main_sec_main + "' order by fjbh");
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                {
                    zfh = 0; ds = 0; qt = 0; zyye = 0;
                    DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from Szwmx", " jzbh=''  and   lsbh='" + DS_zd.Tables[0].Rows[i_0]["lsbh"].ToString() + "'" + xfsj_cond + " group by xfdr");
                    if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                    {
                        for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                        {
                            if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                            {
                                if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                {
                                    zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                }
                                else
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                    {
                                        ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                    { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                            }

                            zyye = zfh + ds + qt;

                        }
                    }
                    insert_app(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["lksj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), DS_zd.Tables[0].Rows[i_0]["fjrb"].ToString(), DS_zd.Tables[0].Rows[i_0]["fjbh"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString());

                }
            }



            //在住散客_夜审时已经退房

            DS_zd = B_Common.GetList("select * from Sjzzd", "yydh='" + yydh + "' and (czzt='" + common_file.common_jzzt.czzt_sz + "' or czzt='" + common_file.common_jzzt.czzt_bfsz + "' or czzt='" + common_file.common_jzzt.czzt_gz + "' or czzt='" + common_file.common_jzzt.czzt_jz + "') and fjbh<>'' " + yj_czsj);
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {

                    for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                    {
                        if (DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString()).ToShortDateString() != DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["czsj"].ToString()).ToShortDateString())
                        {
                        zfh = 0; ds = 0; qt = 0; zyye = 0;
                        DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from Sjzmx", "  jzbh='" + DS_zd.Tables[0].Rows[i_0]["jzbh"].ToString() + "' and xfdr<>'" + common_file.common_app.fkdr + "' " + xfsj_cond + "  group by xfdr");
                        if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                        {
                            for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                            {
                                if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                                {
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                    {
                                        zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                        if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                        {
                                            ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                        }
                                        else
                                        { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                                }

                                zyye = zfh + ds + qt;

                            }
                        }
                        insert_app(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString());

                    }
                }
            }





            //挂账_夜审时还未结


            DS_zd = B_Common.GetList("select * from VIEW_S_jz_jzORgz_zd", "yydh='" + yydh + "' and (czzt='" + common_file.common_jzzt.czzt_gz + "' or czzt='" + common_file.common_jzzt.czzt_jzzgz + "')  order by czsj");
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                {
                    zfh = 0; ds = 0; qt = 0; zyye = 0;
                    DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from VIEW_S_jz_jzORgz", " jzbh='" + DS_zd.Tables[0].Rows[i_0]["jzbh"].ToString() + "'" + czsj_cond + " group by xfdr");
                    if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                    {
                        for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                        {
                            if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                            {
                                if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                {
                                    zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                }
                                else
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                    {
                                        ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                    { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                            }

                            zyye = zfh + ds + qt;

                        }
                    }
                    insert_app_gj(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["czsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["jzzt"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), "", DS_zd.Tables[0].Rows[i_0]["fjbh"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["czzt"].ToString(), common_file.common_jzzt.czzt_gz, zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString(), DS_zd.Tables[0].Rows[i_0]["czy"].ToString());
                }
            }
            //挂账_夜审时还已结
            DS_zd = B_Common.GetList("select * from Sjzzd", "yydh='" + yydh + "' and (czzt='" + common_file.common_jzzt.czzt_gzzsz + "' or czzt='" + common_file.common_jzzt.czzt_gzfj + "')" + yj_czsj);
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {
                    for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                    {
                        if (DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString()).ToShortDateString() != DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["czsj"].ToString()).ToShortDateString())
                        {
                        zfh = 0; ds = 0; qt = 0; zyye = 0;
                        DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from Sjzmx", "  jzbh='" + DS_zd.Tables[0].Rows[i_0]["jzbh"].ToString() + "' and xfdr<>'" + common_file.common_app.fkdr + "' group by xfdr");
                        if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                        {
                            for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                            {
                                if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                                {
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                    {
                                        zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                        if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                        {
                                            ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                        }
                                        else
                                        { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                                }

                                zyye = zfh + ds + qt;

                            }
                        }
                        insert_app_gj(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["czsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["jzzt"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), "", DS_zd.Tables[0].Rows[i_0]["fjbh"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["czzt"].ToString(), common_file.common_jzzt.czzt_gz, zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString(), DS_zd.Tables[0].Rows[i_0]["czy"].ToString());
                    }
                }
            }
            //记账_夜审时还未结
            DS_zd = B_Common.GetList("select * from VIEW_S_jz_jzORgz_zd", "yydh='" + yydh + "' and (czzt='" + common_file.common_jzzt.czzt_jz + "' or czzt='" + common_file.common_jzzt.czzt_gzzjz + "')  order by czsj");
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                {
                    zfh = 0; ds = 0; qt = 0; zyye = 0;
                    DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from VIEW_S_jz_jzORgz", " jzbh='" + DS_zd.Tables[0].Rows[i_0]["jzbh"].ToString() + "'" + czsj_cond + " group by xfdr");
                    if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                    {
                        for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                        {
                            if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                            {
                                if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                {
                                    zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                }
                                else
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                    {
                                        ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                    { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                            }

                            zyye = zfh + ds + qt;

                        }
                    }
                    insert_app_gj(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["czsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["jzzt"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), "", DS_zd.Tables[0].Rows[i_0]["fjbh"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["czzt"].ToString(), common_file.common_jzzt.czzt_jz, zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString(), DS_zd.Tables[0].Rows[i_0]["czy"].ToString());
                }
            }
            //记账_夜审时还已结
            DS_zd = B_Common.GetList("select * from Sjzzd", "yydh='" + yydh + "' and (czzt='" + common_file.common_jzzt.czzt_jzzsz + "' or czzt='" + common_file.common_jzzt.czzt_jzfj + "')" + yj_czsj);
            if (DS_zd != null && DS_zd.Tables[0].Rows.Count > 0)
            {
                    for (i_0 = 0; i_0 < DS_zd.Tables[0].Rows.Count; i_0++)
                    {
                        if (DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString()).ToShortDateString() != DateTime.Parse(DS_zd.Tables[0].Rows[i_0]["czsj"].ToString()).ToShortDateString())
                        {
                        zfh = 0; ds = 0; qt = 0; zyye = 0;
                        DS_mx = B_Common.GetList("select xfdr,sum(sjxfje) as sjxfje from Sjzmx", "  jzbh='" + DS_zd.Tables[0].Rows[i_0]["jzbh"].ToString() + "' and xfdr<>'" + common_file.common_app.fkdr + "' group by xfdr");
                        if (DS_mx != null && DS_mx.Tables[0].Rows.Count > 0)
                        {
                            for (j_0 = 0; j_0 < DS_mx.Tables[0].Rows.Count; j_0++)
                            {
                                if (DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString() != "")
                                {
                                    if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ff))
                                    {
                                        zfh = zfh + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                    }
                                    else
                                        if ((DS_mx.Tables[0].Rows[j_0]["xfdr"].ToString() == Szwgl.common_zw.dr_ds))
                                        {
                                            ds = ds + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString());
                                        }
                                        else
                                        { qt = qt + decimal.Parse(DS_mx.Tables[0].Rows[j_0]["sjxfje"].ToString()); }
                                }

                                zyye = zfh + ds + qt;

                            }
                        }
                        insert_app_gj(B_Common, DS_zd.Tables[0].Rows[i_0]["yydh"].ToString(), DS_zd.Tables[0].Rows[i_0]["qymc"].ToString(), rq.ToString(), DS_zd.Tables[0].Rows[i_0]["ddsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["tfsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["czsj"].ToString(), DS_zd.Tables[0].Rows[i_0]["krxm"].ToString(), DS_zd.Tables[0].Rows[i_0]["jzzt"].ToString(), DS_zd.Tables[0].Rows[i_0]["xydw"].ToString(), DS_zd.Tables[0].Rows[i_0]["krly"].ToString(), "", DS_zd.Tables[0].Rows[i_0]["fjbh"].ToString(), DS_zd.Tables[0].Rows[i_0]["sktt"].ToString(), DS_zd.Tables[0].Rows[i_0]["czzt"].ToString(), common_file.common_jzzt.czzt_jz, zfh.ToString(), ds.ToString(), qt.ToString(), zyye.ToString(), DS_zd.Tables[0].Rows[i_0]["czy"].ToString());
                    }
                }
            }
            DS_zd.Clear();
            DS_zd.Dispose();
            DS_mx.Clear();
            DS_mx.Dispose();
            s = common_file.common_app.get_suc;
            return s;
        }

        public void insert_app(BLL.Common B_Common, string yydh, string qymc, string bbrq, string ddsj, string lksj, string krxm, string xydw, string krly, string fjrb, string fjbh, string sktt, string zfh, string ds, string qt, string zyye)
        {
            string insert_s = "";
            insert_s = "insert into BB_sh_wj(yydh, qymc, bbrq, ddsj, lksj, krxm, xydw, krly, fjrb, fjbh, sktt, zfh, ds, qt, zyye)";
            insert_s = insert_s + " values ('" + yydh + "','" + qymc + "','" + bbrq + "','" + ddsj + "','" + lksj + "','" + krxm + "','" + xydw + "','" + krly + "','" + fjrb + "','" + fjbh + "','" + sktt + "','" + zfh + "','" + ds + "','" + qt + "','" + zyye + "') ";
            B_Common.ExecuteSql(insert_s);
        }



        public void insert_app_gj(BLL.Common B_Common, string yydh, string qymc, string bbrq, string ddsj, string lksj, string czsj, string krxm, string jzzt, string xydw, string krly, string fjrb, string fjbh, string sktt, string czzt, string fx_zt, string zfh, string ds, string qt, string zyye, string czy)
        {
            string insert_s = "";
            insert_s = "insert into BB_sh_wj_gj(yydh, qymc, bbrq, ddsj, lksj,czsj, krxm,jzzt, xydw, krly, fjrb, fjbh, sktt,czzt,fx_zt, zfh, ds, qt, zyye,czy)";
            insert_s = insert_s + " values ('" + yydh + "','" + qymc + "','" + bbrq + "','" + ddsj + "','" + lksj + "','" + czsj + "','" + krxm + "','" + jzzt + "','" + xydw + "','" + krly + "','" + fjrb + "','" + fjbh + "','" + sktt + "','" + czzt + "','" + fx_zt + "','" + zfh + "','" + ds + "','" + qt + "','" + zyye + "','" + czy + "') ";
            B_Common.ExecuteSql(insert_s);
        }



        public void update_jzzt_czzt(BLL.Common B_Common, string yydh, string qymc)
        {
            DataSet DS_temp = B_Common.GetList("select * from VIEW_S_jzzt_czzt_jzmx", "1=1");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS_temp.Tables[0].Rows.Count; i++)
                {
                    string jzbh_zd = DS_temp.Tables[0].Rows[i]["jzbh"].ToString();
                    string jzzt_zd = DS_temp.Tables[0].Rows[i]["jzzt"].ToString();
                    string czzt_zd = DS_temp.Tables[0].Rows[i]["czzt"].ToString();
                    string czsj_zd = DS_temp.Tables[0].Rows[i]["czsj"].ToString();
                    B_Common.ExecuteSql(" update Sjzmx set jzzt='" + jzzt_zd + "',czzt='" + czzt_zd + "',czsj='" + czsj_zd + "' where jzbh='" + jzbh_zd + "' and yydh='" + yydh + "'");

                }
            }
            DS_temp = B_Common.GetList("select * from VIEW_S_czzt_zwmx", "1=1");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS_temp.Tables[0].Rows.Count; i++)
                {
                    string jzbh_zd = DS_temp.Tables[0].Rows[i]["jzbh"].ToString();
                    string czzt_zd = DS_temp.Tables[0].Rows[i]["czzt"].ToString();
                    B_Common.ExecuteSql(" update Szwmx set czzt='" + czzt_zd + "' where jzbh='" + jzbh_zd + "' and yydh='" + yydh + "'");

                }


            }
            B_Common.ExecuteSql("delete from Sjzmx where jzbh not in(select jzbh from Sjzzd)");
            DS_temp.Clear();
            DS_temp.Dispose();
        }



    }
}
