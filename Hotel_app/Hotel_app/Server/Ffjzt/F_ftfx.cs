using System;
using System.Data;
using System.Configuration;


namespace Hotel_app.Server.Ffjzt
{
    public class F_ftfx
    {
        /// <summary>获得可用房数量
        /// 
        /// </summary>
        /// <param name="yd_dj"></param>
        /// <param name="ddsj_temp"></param>
        /// <param name="lksj_temp"></param>
        /// <param name="fjrb_temp"></param>
        /// <param name="is_lksj"></param>//是否包含离开时间包含就不要排除当日预离房，如果不包含就排除当日预离房
        ///<param name="is_contain_wx"></param>//是否包含维修（就是说维修时还可排给预订房，但在维修房绝对不能排给登记）TRUE维修房可用，FALSE维修房不能用 
        /// <param name="ylsl"></param>//如果是修改要把原来的数量输入到这边，如果新增这个值就为0
        /// <param name="xzsl"></param>//现在要预订或入住的数量。
        /// <returns></returns>

        public static float get_fjzt_sl_canused(string yd_dj, DateTime ddsj_temp, DateTime lksj_temp, string fjrb_temp, bool is_lksj, bool is_contain_wx, float ylsl, float xzsl)
        {
            BLL.Common B_Common = new BLL.Common();
            string select_strwhere = "(1=1)  ";
            string ddsj_temp_0 = ddsj_temp.ToShortDateString();
            string lksj_temp_0 = lksj_temp.ToShortDateString() + " " + "23:59:59";
            DataSet DS_temp;
            if (fjrb_temp.Trim() != "")
            {
                DS_temp = B_Common.GetList("select count(*) as fs from Ffjzt", "fjrb='" + fjrb_temp + "'" + common_file.common_app.yydh_select);
            }
            else
            {
                DS_temp = B_Common.GetList("select count(*) as fs from Ffjzt", "id>=0" + common_file.common_app.yydh_select);
            }

            float zfs = 0; float zysl = 0; float kyfs = 0;

            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs = int.Parse(DS_temp.Tables[0].Rows[0]["fs"].ToString());

            }
            string fjrb_fjbh_select = ""; string fjrb_fjbh = "";

            if (fjrb_temp.Trim() != "")
            {
                fjrb_fjbh = " and (fjrb='" + fjrb_temp + "')";

            }

            if (is_contain_wx == false)
                fjrb_fjbh_select = fjrb_fjbh + "  and  (Zyzt ='" + common_file.common_fjzt.wxf + " 'and  Zyzt='" + common_file.common_fjzt.qtf + "')";//用于维修房
            else
                fjrb_fjbh_select = fjrb_fjbh + " and  (Zyzt='" + common_file.common_fjzt.qtf + "')";//用于其它房（其它房不管是在预订还是在登记的时候都要排除掉)

            string wx_select_condition = " and ((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";

            if (is_lksj == false)//false 时离开时间也是不可用，但TRUE时离开那一天可用
            {

                select_strwhere = " (id>=0 and fjrb<>''" + common_file.common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select;
                DS_temp = B_Common.GetList("select count(*) as sl from Fwx_other", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }
                select_strwhere = " (id>=0 and lzfs>0 and fjrb<>''" + common_file.common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh;
                DS_temp = B_Common.GetList("select sum(lzfs) as sl from VIEW_Qfjrb_fs_tj", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = zysl + float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }

            }
            else//if (is_lksj == false)//false 时离开时间也是不可用，但TRUE时离开那一天可用
            {

                select_strwhere = "  (id>=0 and fjrb<>''" + common_file.common_app.yydh_select + ")" + wx_select_condition + fjrb_fjbh_select;

                DS_temp = B_Common.GetList("select count(*) as sl from Fwx_other", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }
                string dj_select_condition = "";
                //
                //dj_select_condition = " and ((CONVERT(varchar(10),ddsj, 120)  between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (CONVERT(varchar(10),ddsj, 120) <'" + ddsj_temp_0 + "' and  CONVERT(varchar(10),lksj, 120)>'" + lksj_temp_0 + "') or (CONVERT(varchar(10),lksj, 120) between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "'))";

                string ddsj_cs = ddsj_temp.ToShortDateString();
                string ddsj_js = ddsj_temp.ToShortDateString() + " " + "23:59:59";
                string lksj_cs = lksj_temp.ToShortDateString();
                string lksj_js = lksj_temp.ToShortDateString() + " " + "23:59:59";
                if (ddsj_temp.ToShortDateString() != lksj_temp.ToShortDateString())
                {
                    dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where (ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "') ))         )";
                }
                else
                {
                    //dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where ((ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "'))   and  (CONVERT(varchar(10),ddsj, 120)=CONVERT(varchar(10),lksj, 120))  ))       )";
                    dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "')  or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and             (lsbh not in (select lsbh from VIEW_Qfjrb_fs_tj where ((ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "') or (lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "'))           ))       )";
                }
                //dj_select_condition = " and (((ddsj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "') or (ddsj<'" + ddsj_temp_0 + "' and lksj>'" + lksj_temp_0 + "') or (lksj between '" + ddsj_temp_0 + "' and '" + lksj_temp_0 + "')) and ((lsbh not in(select lsbh from VIEW_Qfjrb_fs_tj where ddsj between '" + lksj_cs + "' and '" + lksj_js + "' and lksj>='" + lksj_cs + "')) and ((lsbh not in(select lsbh from VIEW_Qfjrb_fs_tj where lksj between '" + ddsj_cs + "' and '" + ddsj_js + "' and ddsj<='" + ddsj_js + "')))))";


                select_strwhere = "  (id>=0 and lzfs>0 and fjrb<>'' " + common_file.common_app.yydh_select + ")" + dj_select_condition + fjrb_fjbh;

                DS_temp = B_Common.GetList("select sum(lzfs) as sl from VIEW_Qfjrb_fs_tj", select_strwhere);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp.Tables[0].Rows[0]["sl"].ToString() != "")
                    {
                        zysl = zysl + float.Parse(DS_temp.Tables[0].Rows[0]["sl"].ToString());
                    }
                }

            }
            kyfs = zfs + ylsl - xzsl - zysl;
            DS_temp.Dispose();
            return kyfs;


        }




        public string dr_ft_fx(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;

            dr_ft_tj_app(yydh, qymc, czy, czsj, xxzs);
            dr_fx_dd_lk_app(yydh, qymc, czy, czsj, xxzs);
            dr_yd_yl_sktt_app(yydh, qymc, czy, czsj, xxzs);

            get_result = common_file.common_app.get_suc;
            return get_result;

        }






        public void add_dr_ft_tj(string yydh, string qymc, string zyzt_db, DataSet DS_temp, BLL.Common B_Common, string table_name, string czy)
        {
            string zyfs = "0";
            string insert_s = "";
            for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
            {
                if (DS_temp.Tables[0].Rows[j_0]["zyzt"].ToString() == zyzt_db)
                {
                    zyfs = DS_temp.Tables[0].Rows[j_0]["zyfs"].ToString();
                    //M_F_ftfx_zft.zyfs = decimal.Parse(DS_temp.Tables[0].Rows[j_0]["zyfs"].ToString());
                }
            }
            insert_s = "insert into " + table_name + "(yydh,qymc,zyzt,zyfs,czy) values('" + yydh + "','" + qymc + "','" + zyzt_db + "','" + zyfs + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);

        }
        /// <summary>
        /// 进行当日的各种房型的房态分析
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="tjrq"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string dr_ft_tj_app(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string insert_s = "";
            //Model.F_ftfx_zft M_F_ftfx_zft = new Hotel_service.Model.F_ftfx_zft();
           // BLL.F_ftfx_zft B_F_ftfx_zft = new Hotel_service.BLL.F_ftfx_zft();
            B_Common.ExecuteSql("delete from " + "F_ftfx_zft where czy='"+czy+"'");
            DataSet DS_temp = B_Common.GetList("select count(*) as zyfs from Ffjzt", "id>=0");
            string zyfs = "0";
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zyfs = DS_temp.Tables[0].Rows[0]["zyfs"].ToString();
            }
            insert_s = "insert into " + "F_ftfx_zft" + "(yydh,qymc,zyzt,zyfs,czy) values('" + yydh + "','" + qymc + "','" + "总房数" + "','" + zyfs + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);

            DS_temp = B_Common.GetList("select zyzt,count(*)as zyfs  from Ffjzt", "id>=0 group by zyzt");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                add_dr_ft_tj(yydh, qymc, common_file.common_fjzt.gjf, DS_temp, B_Common, "F_ftfx_zft", czy);
                add_dr_ft_tj(yydh, qymc, common_file.common_fjzt.zf, DS_temp, B_Common, "F_ftfx_zft", czy);
                add_dr_ft_tj(yydh, qymc, common_file.common_fjzt.wxf, DS_temp, B_Common, "F_ftfx_zft", czy);
                add_dr_ft_tj(yydh, qymc, common_file.common_fjzt.qtf, DS_temp, B_Common, "F_ftfx_zft", czy);
                add_dr_ft_tj(yydh, qymc, common_file.common_fjzt.zzf, DS_temp, B_Common, "F_ftfx_zft", czy);
            }

            DS_temp = B_Common.GetList("select count(*) as zyfs from Ffjzt", "zyzt_second='" + common_file.common_fjzt.ydf + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zyfs = DS_temp.Tables[0].Rows[0]["zyfs"].ToString();

            }
            insert_s = "insert into " + "F_ftfx_zft" + "(yydh,qymc,zyzt,zyfs,czy) values('" + yydh + "','" + qymc + "','" + common_file.common_fjzt.ydf + "','" + zyfs + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);

            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }

        public void dr_fx_dd_lk_add(string yydh, string qymc, BLL.Common B_Common, string zyzt, Decimal zyfs, Decimal zyrs, string table_name, string czy)
        {
            string insert_s = "insert into " + table_name + "(yydh,qymc,zyzt,zyfs,zyrs,czy) values ('" + yydh + "','" + qymc + "','" + zyzt + "','" + zyfs + "','" + zyrs + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);

        }
        /// <summary>
        /// 抵离的分析
        /// </summary>
        /// <returns></returns>
        public string dr_fx_dd_lk_app(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {


            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            B_Common.ExecuteSql("delete from " + "F_ftfx_zkfx where czy='"+czy+"'");

            decimal zfs = 0;
            DataSet DS_temp = B_Common.GetList("select count(*) as zyfs from Ffjzt", "id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs = decimal.Parse(DS_temp.Tables[0].Rows[0]["zyfs"].ToString());
            }

            //预计离店
            decimal yjld_fs = 0;
            decimal yjld_rs = 0;
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_dj + "' and lksj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                yjld_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and lksj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                yjld_rs = DS_temp.Tables[0].Rows.Count;
            }
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "预计离店", yjld_fs, yjld_fs, "F_ftfx_zkfx", czy);

            //实际离店
            decimal sjld_fs = 0;
            decimal sjld_rs = 0;
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb_bak", " lksj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sjld_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord_bak", " lksj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sjld_rs = DS_temp.Tables[0].Rows.Count;
            }
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "实际离店", sjld_fs, sjld_rs, "F_ftfx_zkfx", czy);

            //预计到店
            decimal yjdd_fs = 0;
            decimal yjdd_rs = 0;
            DS_temp = B_Common.GetList("select sum(lzfs) as lzfs from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                {
                    string temp_0 = DS_temp.Tables[0].Rows[0]["lzfs"].ToString();
                    yjdd_fs = decimal.Parse(temp_0);
                }
            }

            DS_temp = B_Common.GetList("select fjrb,sum(lzfs) as lzfs  from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "' group by fjrb");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                {
                    decimal yjdd_rs_0 = 0;
                    for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {
                        yjdd_rs_0 = decimal.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString());
                        DataSet DS_temp_0 = B_Common.GetList("select zyrs from Ffjrb", "fjrb='" + DS_temp.Tables[0].Rows[0]["fjrb"].ToString() + "'");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            yjdd_rs_0 = decimal.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString()) * decimal.Parse(DS_temp_0.Tables[0].Rows[0]["zyrs"].ToString());
                        }
                        yjdd_rs = yjdd_rs + yjdd_rs_0;
                        DS_temp_0.Clear();
                        DS_temp_0.Dispose();
                    }
                }
            }
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "预计到店", yjdd_fs, yjdd_rs, "F_ftfx_zkfx", czy);

            //本日到店
            decimal brdd_fs = 0;
            decimal brdd_rs = 0;
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_dj + "' and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                brdd_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                brdd_rs = DS_temp.Tables[0].Rows.Count;
            }
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "本日到店", brdd_fs, brdd_rs, "F_ftfx_zkfx", czy);


            //续住
            decimal xz_fs = 0;
            decimal xz_rs = 0;
            DS_temp = B_Common.GetList("select distinct lsbh  from Qskyd_xz", "yddj='" + common_file.common_yddj.yddj_dj + "' and czsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                xz_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "lsbh in(select distinct lsbh  from Qskyd_xz where yddj='" + common_file.common_yddj.yddj_dj + "' and czsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                xz_rs = DS_temp.Tables[0].Rows.Count;
            }
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "续住", xz_fs, xz_rs, "F_ftfx_zkfx", czy);


            //提前离店
            decimal tqld_fs = 0;
            decimal tqld_rs = 0;
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb_bak", " CONVERT(varchar(10),lksj, 120)> CONVERT(varchar(10),czsj, 120)");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                tqld_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord_bak", " CONVERT(varchar(10),lksj, 120)> CONVERT(varchar(10),czsj, 120)");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                tqld_rs = DS_temp.Tables[0].Rows.Count;
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "提前离店", tqld_fs, tqld_rs, "F_ftfx_zkfx", czy);

            //之前入住
            decimal zqlz_fs = 0;
            decimal zqlz_rs = 0;
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_dj + "'  and lksj not between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zqlz_fs = DS_temp.Tables[0].Rows.Count;
            }

            //DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and ddsj < '" + DateTime.Now.ToShortDateString() + "' and  lksj>'" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "'  and lksj not between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zqlz_rs = DS_temp.Tables[0].Rows.Count;
            }
            DS_temp.Clear();
            DS_temp.Dispose();
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "之前入住", zqlz_fs, zqlz_rs, "F_ftfx_zkfx", czy);


            decimal kyfs = 0;
            kyfs = decimal.Parse(get_fjzt_sl_canused(common_file.common_yddj.yddj_yd, DateTime.Parse(DateTime.Now.ToShortDateString()), DateTime.Parse(DateTime.Now.ToShortDateString()), "", true, common_file.common_app.is_contain_wx, 0, 0).ToString());
            //get_fjzt_sl_canused(string yd_dj, DateTime ddsj_temp, DateTime lksj_temp, string fjrb_temp, bool is_lksj, bool is_contain_wx, float ylsl, float xzsl)

            decimal kyrs = 0;

            dr_fx_dd_lk_add(yydh, qymc, B_Common, "可用房数", kyfs, kyrs, "F_ftfx_zkfx", czy);

            get_ff_app(yydh, qymc, czy, czsj, xxzs);

            get_result = common_file.common_app.get_suc;
            return get_result;
        }


        //获得房费
        public string get_ff_app(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            decimal zzff = 0;
            DataSet DS_temp = B_Common.GetList("select sum(sjfjjg) as sjfjjg from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_dj + "' and fjbh<>'' and lksj not between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                {
                    zzff = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString());
                }
            }

            DS_temp = B_Common.GetList("select sum(sjfjjg) as sjfjjg from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_dj + "' and fjbh<>'' and (lksj  between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "') and (ddsj  between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                {
                    zzff = zzff + decimal.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString());
                }
            }
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "在住房费", zzff, 0, "F_ftfx_zkfx", czy);
            decimal ydff = 0;
            DS_temp = B_Common.GetList("select sum(sjfjjg*lzfs) as sjfjjg from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_yd + "'  and ddsj  <='" + DateTime.Now.ToShortDateString() + " 23:59:59" + "' and lksj>='" + DateTime.Now.ToShortDateString() + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                {
                    ydff = decimal.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString());
                }
            }
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "预计房费", zzff+ydff, 0, "F_ftfx_zkfx", czy);

            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }



        //当日 sktt 分析//预计到店
        public void dr_yd_yl_sktt_yd_add_repeat(BLL.Common B_Common, DataSet DS_temp, string zyzt, ref  decimal ydfs, ref decimal ydrs)
        {
            int j_0 = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {
                    if (DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString() != "")
                    {
                        if (DS_temp.Tables[0].Rows[j_0]["sktt"].ToString() == zyzt)
                        {
                            ydfs = decimal.Parse(DS_temp.Tables[j_0].Rows[0]["lzfs"].ToString());

                            DataSet DS_temp_0 = B_Common.GetList("select fjrb,sum(lzfs) as lzfs  from Qskyd_fjrb", " sktt='" + DS_temp.Tables[j_0].Rows[0]["sktt"].ToString() + "' and yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "' group by fjrb");
                            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            {

                                decimal yjdd_rs_0 = 0;
                                for (int i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                                {
                                    if (DS_temp_0.Tables[0].Rows[i_0]["lzfs"].ToString() != "")
                                    {
                                        yjdd_rs_0 = decimal.Parse(DS_temp_0.Tables[0].Rows[i_0]["lzfs"].ToString());
                                        DataSet DS_temp_1 = B_Common.GetList("select zyrs from Ffjrb", "fjrb='" + DS_temp_0.Tables[0].Rows[0]["fjrb"].ToString() + "'");
                                        if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                                        {
                                            yjdd_rs_0 = decimal.Parse(DS_temp_0.Tables[0].Rows[i_0]["lzfs"].ToString()) * decimal.Parse(DS_temp_1.Tables[0].Rows[0]["zyrs"].ToString());
                                        }
                                        DS_temp_1.Clear();
                                        DS_temp_1.Dispose();
                                        ydrs = ydrs + yjdd_rs_0;
                                    }
                                }

                            }
                            DS_temp_0.Clear();
                            DS_temp_0.Dispose();
                        }
                    }
                }

            }
        }



        //当日 sktt 分析//预计到店
        public void dr_yd_yl_sktt_yd_add(string yydh, string qymc, string zyzt, BLL.Common B_Common, DataSet DS_temp, string table_name, string czy)
        {
            string insert_s = "";
            decimal ydfs = 0;
            decimal ydrs = 0;
            insert_s = "insert into " + table_name + "(yydh,qymc,zyzt,ydfs,ydrs,zdfs,zdrs,ylfs,ylrs,czy)";
            ydfs = 0; ydrs = 0;
            dr_yd_yl_sktt_yd_add_repeat(B_Common, DS_temp, zyzt, ref ydfs, ref ydrs);
            insert_s = insert_s + "values ('" + yydh + "','" + qymc + "','" + zyzt + "','" + ydfs.ToString() + "','" + ydrs.ToString() + "','0','0','0','0','" + czy + "') ";
            B_Common.ExecuteSql(insert_s);
            DS_temp.Clear();
            DS_temp.Dispose();

        }
        //当日 sktt 分析//在住
        public void dr_yd_yl_zz_update_repeat(string yydh, string qymc, BLL.Common B_Common, string zyzt, string table_name, DataSet DS_fs, DataSet DS_rs, string fs, string rs)
        {

            int j_0 = 0;
            string update_s = "";
            if (DS_fs != null && DS_fs.Tables[0].Rows.Count > 0)
            {
                for (j_0 = 0; j_0 < DS_fs.Tables[0].Rows.Count; j_0++)
                {
                    if (DS_fs.Tables[0].Rows[j_0]["fs"].ToString() != "")
                    {
                        if (DS_fs.Tables[0].Rows[j_0]["sktt"].ToString() == zyzt)
                        {
                            update_s = "update " + table_name + " set " + fs + "='" + DS_fs.Tables[0].Rows[j_0]["fs"].ToString() + "' where zyzt='" + zyzt + "'";
                            B_Common.ExecuteSql(update_s);
                        }
                    }
                }
            }
            if (DS_rs != null && DS_rs.Tables[0].Rows.Count > 0)
            {
                for (j_0 = 0; j_0 < DS_rs.Tables[0].Rows.Count; j_0++)
                {
                    if (DS_rs.Tables[0].Rows[j_0]["sktt"].ToString() == zyzt)
                    {
                        update_s = "update " + table_name + " set " + rs + "='" + DS_rs.Tables[0].Rows[j_0]["rs"].ToString() + "' where zyzt='" + zyzt + "'";
                        B_Common.ExecuteSql(update_s);
                    }
                }
            }

        }

        //当日 sktt 分析//在住
        public void dr_yd_yl_zz_update(string yydh, string qymc, BLL.Common B_Common, string table_name, string select_cond, string fs, string rs)
        {
            DataSet DS_temp = B_Common.GetList("select sktt,sum(lzfs) as fs from Qskyd_fjrb", select_cond+" group by sktt");

            DataSet DS_temp_0 = B_Common.GetList("select sktt,count(id) as rs from Qskyd_fjrb", select_cond + " group by sktt");

            dr_yd_yl_zz_update_repeat(yydh, qymc, B_Common, common_file.common_sktt.sktt_sk, table_name, DS_temp, DS_temp_0, fs, rs);
            dr_yd_yl_zz_update_repeat(yydh, qymc, B_Common, common_file.common_sktt.sktt_cz, table_name, DS_temp, DS_temp_0, fs, rs);
            dr_yd_yl_zz_update_repeat(yydh, qymc, B_Common, common_file.common_sktt.sktt_zd, table_name, DS_temp, DS_temp_0, fs, rs);
            dr_yd_yl_zz_update_repeat(yydh, qymc, B_Common, common_file.common_sktt.sktt_tt, table_name, DS_temp, DS_temp_0, fs, rs);
            dr_yd_yl_zz_update_repeat(yydh, qymc, B_Common, common_file.common_sktt.sktt_hy, table_name, DS_temp, DS_temp_0, fs, rs);
            DS_temp.Clear();
            DS_temp.Dispose();
            DS_temp_0.Clear();
            DS_temp_0.Dispose();

        }



        //当日 sktt 分析
        public string dr_yd_yl_sktt_app(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            B_Common.ExecuteSql("delete from " + "F_ftfx_sktt_ddlk where czy='" + czy + "'");

            //预计到店
            DataSet DS_temp = B_Common.GetList("select sktt,sum(lzfs) as lzfs from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "' group by sktt");
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_sk, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_cz, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_zd, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_tt, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_hy, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);

            //在店
            dr_yd_yl_zz_update(yydh, qymc, B_Common, "F_ftfx_sktt_ddlk", "yddj='" + common_file.common_yddj.yddj_dj + "' and lksj not between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'", "zdfs", "zdrs");


            //预离
            dr_yd_yl_zz_update(yydh, qymc, B_Common, "F_ftfx_sktt_ddlk", "yddj='" + common_file.common_yddj.yddj_dj + "' and lksj  between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'", "ylfs", "ylrs");


            //合计
            B_Common.ExecuteSql("insert into " + "F_ftfx_sktt_ddlk" + "(yydh,qymc,zyzt,ydfs,ydrs,zdfs,zdrs,ylfs,ylrs,czy) select '" + yydh + "','" + qymc + "','" + "合计" + "',sum(ydfs),sum(ydrs),sum(zdfs),sum(zdrs),sum(ylfs),sum(ylrs),'"+czy+"' from " + "F_ftfx_sktt_ddlk");


            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;

        }



    }
}
