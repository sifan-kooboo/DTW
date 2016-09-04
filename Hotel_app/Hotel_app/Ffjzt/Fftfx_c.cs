using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    class Fftfx_c
    {

        public string dr_ft_fx(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {
            common_file.common_app.get_czsj();
            string get_result = common_file.common_app.get_failure;
            common_file.common_app.get_czsj();
            dr_ft_tj_app(yydh, qymc, czy, czsj, xxzs);
            common_file.common_app.get_czsj();
            dr_fx_dd_lk_app(yydh, qymc, czy, czsj, xxzs);
            common_file.common_app.get_czsj();
            dr_yd_yl_sktt_app(yydh, qymc, czy, czsj, xxzs);

            get_result = common_file.common_app.get_suc;
            return get_result;
            Cursor.Current = Cursors.Default;
        }


        public void add_dr_ft_tj(string yydh, string qymc, string zyzt_db, DataSet DS_temp, BLL.Common B_Common, string table_name, string czy)
        {
            common_file.common_app.get_czsj();
            string zyfs = "0";
            string insert_s = "";
            for (int j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
            {
                if (DS_temp.Tables[0].Rows[j_0]["zyzt"].ToString() == zyzt_db)
                {
                    zyfs = DS_temp.Tables[0].Rows[j_0]["zyfs"].ToString();
                    //M_F_ftfx_zft.zyfs = float.Parse(DS_temp.Tables[0].Rows[j_0]["zyfs"].ToString());
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
            common_file.common_app.get_czsj();
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new BLL.Common();
            string insert_s = "";
            //Model.F_ftfx_zft M_F_ftfx_zft = new Hotel_service.Model.F_ftfx_zft();
            // BLL.F_ftfx_zft B_F_ftfx_zft = new Hotel_service.BLL.F_ftfx_zft();
            B_Common.ExecuteSql("delete from " + "F_ftfx_zft where czy='" + czy + "'");
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
            insert_s = "insert into " + "F_ftfx_zft" + "(yydh,qymc,zyzt,zyfs,czy) values('" + yydh + "','" + qymc + "','" + "已排预订" + "','" + zyfs + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);

            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
            Cursor.Current = Cursors.Default;
        }

        public void dr_fx_dd_lk_add(string yydh, string qymc, BLL.Common B_Common, string zyzt, float zyfs, float zyrs, string table_name, string czy)
        {
            common_file.common_app.get_czsj();
            string insert_s = "insert into " + table_name + "(yydh,qymc,zyzt,zyfs,zyrs,czy) values ('" + yydh + "','" + qymc + "','" + zyzt + "','" + zyfs + "','" + zyrs + "','" + czy + "')";
            B_Common.ExecuteSql(insert_s);

        }


        //抵离的分析-预计离店
        public void dr_fx_dd_lk_yjld_zz(BLL.Common B_Common, DataSet DS_temp, ref float yjld_fs, ref float yjld_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select id from Qskyd_fjrb", "fjrb<>''and lzfs>=0 and fjbh<>'' and yddj='" + common_file.common_yddj.yddj_dj + "' and lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                //if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                //{
                yjld_fs = DS_temp.Tables[0].Rows.Count;
                //}
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                yjld_rs = DS_temp.Tables[0].Rows.Count;
            }

        }



        //抵离的分析-预计离店
        public void dr_fx_dd_lk_yjld(BLL.Common B_Common, DataSet DS_temp, ref float yjld_fs, ref float yjld_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select sum(lzfs) as lzfs  from Qskyd_fjrb", "fjrb<>'' and lzfs>=0 and lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                {
                    yjld_fs = float.Parse(DS_temp.Tables[0].Rows[0]["lzfs"].ToString());
                }
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                yjld_rs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select fjrb,sum(lzfs) as lzfs  from Qskyd_fjrb", "fjrb<>'' and lzfs>=0 and yddj='" + common_file.common_yddj.yddj_yd + "'and lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' group by fjrb");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                {
                    float yjld_rs_0 = 0;
                    for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {
                        yjld_rs_0 = float.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString());
                        DataSet DS_temp_0 = B_Common.GetList("select zyrs from Ffjrb", "fjrb='" + DS_temp.Tables[0].Rows[i_0]["fjrb"].ToString() + "'");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            yjld_rs_0 = float.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString()) * float.Parse(DS_temp_0.Tables[0].Rows[0]["zyrs"].ToString());
                        }
                        yjld_rs = yjld_rs + yjld_rs_0;
                        DS_temp_0.Clear();
                        DS_temp_0.Dispose();
                    }
                }
            }


        }

        //抵离的分析-实际离店
        public void dr_fx_dd_lk_sjld(BLL.Common B_Common, DataSet DS_temp, ref float sjld_fs, ref float sjld_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb_bak", " fjrb<>'' and lzfs>=0 and lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sjld_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord_bak", "  lksj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sjld_rs = DS_temp.Tables[0].Rows.Count;
            }
        }

        //抵离的分析-预计到店
        public void dr_fx_dd_lk_yjdd(BLL.Common B_Common, DataSet DS_temp, ref float yjdd_fs, ref float yjdd_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select sum(lzfs) as lzfs from Qskyd_fjrb", "fjrb<>'' and lzfs>=0  and yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                {
                    string temp_0 = DS_temp.Tables[0].Rows[0]["lzfs"].ToString();
                    yjdd_fs = float.Parse(temp_0);
                }
            }

            DS_temp = B_Common.GetList("select fjrb,sum(lzfs) as lzfs  from Qskyd_fjrb", "fjrb<>'' and lzfs>=0  and yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' group by fjrb");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["lzfs"].ToString() != "")
                {
                    float yjdd_rs_0 = 0;
                    for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                    {
                        yjdd_rs_0 = float.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString());
                        DataSet DS_temp_0 = B_Common.GetList("select zyrs from Ffjrb", "fjrb='" + DS_temp.Tables[0].Rows[i_0]["fjrb"].ToString() + "'");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {
                            yjdd_rs_0 = float.Parse(DS_temp.Tables[0].Rows[i_0]["lzfs"].ToString()) * float.Parse(DS_temp_0.Tables[0].Rows[0]["zyrs"].ToString());
                        }
                        yjdd_rs = yjdd_rs + yjdd_rs_0;
                        DS_temp_0.Clear();
                        DS_temp_0.Dispose();
                    }
                }
            }
        }


        //抵离的分析-本日到店
        public void dr_fx_dd_lk_brdd(BLL.Common B_Common, DataSet DS_temp, ref float brdd_fs, ref float brdd_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb", "fjrb<>'' and lzfs>=0  and fjbh<>'' and yddj='" + common_file.common_yddj.yddj_dj + "' and ddsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                brdd_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and ddsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                brdd_rs = DS_temp.Tables[0].Rows.Count;
            }

        }


        //抵离的分析-续住
        public void dr_fx_dd_lk_xz(BLL.Common B_Common, DataSet DS_temp, ref float xz_fs, ref float xz_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select distinct lsbh  from Qskyd_xz", "yddj='" + common_file.common_yddj.yddj_dj + "' and czsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                xz_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "lsbh in(select distinct lsbh  from Qskyd_xz where yddj='" + common_file.common_yddj.yddj_dj + "' and czsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                xz_rs = DS_temp.Tables[0].Rows.Count;
            }

        }


        //抵离的分析-提前离店
        public void dr_fx_dd_lk_tqld(BLL.Common B_Common, DataSet DS_temp, ref float tqld_fs, ref float tqld_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb_bak", "fjrb<>'' and lzfs>=0  and  CONVERT(varchar(10),lksj, 120)> CONVERT(varchar(10),czsj, 120) and (czsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                tqld_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord_bak", " CONVERT(varchar(10),lksj, 120)> CONVERT(varchar(10),czsj, 120) and (czsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                tqld_rs = DS_temp.Tables[0].Rows.Count;
            }
        }


        //抵离的分析-当日抵离
        public void dr_fx_dd_lk_drdl(BLL.Common B_Common, DataSet DS_temp, ref float drdl_fs, ref float drdl_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb", "fjrb<>'' and lzfs>=0  and  CONVERT(varchar(10),ddsj, 120)= CONVERT(varchar(10),lksj, 120) and (ddsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                drdl_fs = DS_temp.Tables[0].Rows.Count;
            }

            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", " CONVERT(varchar(10),ddsj, 120)= CONVERT(varchar(10),lksj, 120) and (ddsj between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                drdl_rs = DS_temp.Tables[0].Rows.Count;
            }
        }


        //抵离的分析-之前入住
        public void dr_fx_dd_lk_zqlz(BLL.Common B_Common, DataSet DS_temp, ref float zqlz_fs, ref float zqlz_rs, DateTime rq)
        {
            DS_temp = B_Common.GetList("select distinct fjbh  from Qskyd_fjrb", "fjrb<>'' and lzfs>=0  and fjbh<>'' and yddj='" + common_file.common_yddj.yddj_dj + "'  and  ddsj<'" + DateTime.Now.ToShortDateString() + "' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zqlz_fs = DS_temp.Tables[0].Rows.Count;
            }

            //DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and ddsj < '" + DateTime.Now.ToShortDateString() + "' and  lksj>'" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'");
            DS_temp = B_Common.GetList("select id  from Qskyd_mainrecord", "yddj='" + common_file.common_yddj.yddj_dj + "' and  ddsj<'" + DateTime.Now.ToShortDateString() + "' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zqlz_rs = DS_temp.Tables[0].Rows.Count;
            }
        }

        /// <summary>
        /// 抵离的分析
        /// </summary>
        /// <returns></returns>
        public string dr_fx_dd_lk_app(string yydh, string qymc, string czy, DateTime czsj, string xxzs)
        {

            common_file.common_app.get_czsj();
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new BLL.Common();

            B_Common.ExecuteSql("delete from " + "F_ftfx_zkfx where czy='" + czy + "'");

            float zfs = 0;
            DataSet DS_temp = B_Common.GetList("select count(*) as zyfs from Ffjzt", "id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs = float.Parse(DS_temp.Tables[0].Rows[0]["zyfs"].ToString());
            }

            //预计离店
            float yjld_fs = 0;
            float yjld_rs = 0;
            dr_fx_dd_lk_yjld_zz(B_Common, DS_temp, ref yjld_fs, ref yjld_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "预计离店", yjld_fs, yjld_fs, "F_ftfx_zkfx", czy);

            //实际离店
            float sjld_fs = 0;
            float sjld_rs = 0;
            dr_fx_dd_lk_sjld(B_Common, DS_temp, ref sjld_fs, ref sjld_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "实际离店", sjld_fs, sjld_rs, "F_ftfx_zkfx", czy);

            //预计到店
            float yjdd_fs = 0;
            float yjdd_rs = 0;
            dr_fx_dd_lk_yjdd(B_Common, DS_temp, ref yjdd_fs, ref yjdd_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "预计到店", yjdd_fs, yjdd_rs, "F_ftfx_zkfx", czy);

            //本日到店
            float brdd_fs = 0;
            float brdd_rs = 0;
            dr_fx_dd_lk_brdd(B_Common, DS_temp, ref brdd_fs, ref brdd_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "本日入住", brdd_fs, brdd_rs, "F_ftfx_zkfx", czy);


            //续住
            float xz_fs = 0;
            float xz_rs = 0;
            dr_fx_dd_lk_xz(B_Common, DS_temp, ref xz_fs, ref xz_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "续住", xz_fs, xz_rs, "F_ftfx_zkfx", czy);


            //提前离店
            float tqld_fs = 0;
            float tqld_rs = 0;
            dr_fx_dd_lk_tqld(B_Common, DS_temp, ref tqld_fs, ref tqld_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "提前离店", tqld_fs, tqld_rs, "F_ftfx_zkfx", czy);


            //当日抵离
            float drdl_fs = 0;
            float drdl_rs = 0;
            dr_fx_dd_lk_drdl(B_Common, DS_temp, ref drdl_fs, ref drdl_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "当日抵离（在住）", drdl_fs, drdl_rs, "F_ftfx_zkfx", czy);


            //之前入住
            float zqlz_fs = 0;
            float zqlz_rs = 0;
            dr_fx_dd_lk_zqlz(B_Common, DS_temp, ref zqlz_fs, ref zqlz_rs, DateTime.Now);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "之前入住", zqlz_fs, zqlz_rs, "F_ftfx_zkfx", czy);
            float zfs_0 = 0;
            float kyfs = 0;
            float yd_zz_zy = 0;
            float yd_zz_rs = 0;
            float wx_other_zy = 0;
            common_file.common_used_fjzt.get_zyfs_fx("", DateTime.Now, common_file.common_app.is_contain_wx, ref yd_zz_zy, false, ref yd_zz_rs, ref wx_other_zy, ref zfs_0, ref kyfs);

            //kyfs = float.Parse(common_file.common_used_fjzt.get_zyfs_fx("", DateTime.Now, common_file.common_app.is_contain_wx).ToString());

            //get_fjzt_sl_canused(string yd_dj, DateTime ddsj_temp, DateTime lksj_temp, string fjrb_temp, bool is_lksj, bool is_contain_wx, float ylsl, float xzsl)
            float kyrs = 0;
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "可用房数", kyfs, kyrs, "F_ftfx_zkfx", czy);

            float zzff = 0; float yjzff = 0;
            get_ff_app(yydh, qymc, czy, czsj, DateTime.Now, xxzs, ref zzff, ref yjzff);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "在住房费", zzff, 0, "F_ftfx_zkfx", czy);
            dr_fx_dd_lk_add(yydh, qymc, B_Common, "预计房费", yjzff, 0, "F_ftfx_zkfx", czy);

            get_result = common_file.common_app.get_suc;

            DS_temp.Clear();
            DS_temp.Dispose();
            return get_result;
            Cursor.Current = Cursors.Default;
        }


        //获得房费
        public string get_ff_app(string yydh, string qymc, string czy, DateTime czsj, DateTime rq, string xxzs, ref float zzff, ref float yjzff)
        {
            zzff = 0; yjzff = 0;
            common_file.common_app.get_czsj();
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new BLL.Common();
            //float zzff = 0;
            DataSet DS_temp = B_Common.GetList("select sum(sjfjjg) as sjfjjg from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_dj + "' and fjbh<>'' and lzfs>=0   and ddsj  <='" + rq.ToShortDateString() + " 23:59:59" + "' and lksj>='" + rq.AddDays(1).ToShortDateString() + "'  and lksj not between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                {
                    zzff = float.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString());
                }
            }

            DS_temp = B_Common.GetList("select sum(sjfjjg) as sjfjjg from Qskyd_fjrb", " (lksj  between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "') and lzfs>=0  and (ddsj  between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "')");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                {
                    zzff = zzff + float.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString());

                }
            }

            float ydff = 0;
            DS_temp = B_Common.GetList("select sum(sjfjjg*lzfs) as sjfjjg from Qskyd_fjrb", "yddj='" + common_file.common_yddj.yddj_yd + "' and lzfs>=0  and ddsj  <='" + rq.ToShortDateString() + " 23:59:59" + "' and lksj>='" + rq.AddDays(1).ToShortDateString() + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString() != "")
                {
                    ydff = float.Parse(DS_temp.Tables[0].Rows[0]["sjfjjg"].ToString());
                }
            }
            yjzff = zzff + ydff;


            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }



        //当日 sktt 分析//预计到店
        public void dr_yd_yl_sktt_yd_add_repeat(BLL.Common B_Common, DataSet DS_temp, string zyzt, ref  float ydfs, ref float ydrs)
        {
            common_file.common_app.get_czsj();
            int j_0 = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (j_0 = 0; j_0 < DS_temp.Tables[0].Rows.Count; j_0++)
                {
                    if (DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString() != "")
                    {
                        if (DS_temp.Tables[0].Rows[j_0]["sktt"].ToString() == zyzt)
                        {
                            ydfs = float.Parse(DS_temp.Tables[0].Rows[j_0]["lzfs"].ToString());

                            DataSet DS_temp_0 = B_Common.GetList("select fjrb,sum(lzfs) as lzfs  from Qskyd_fjrb", "  sktt='" + DS_temp.Tables[0].Rows[j_0]["sktt"].ToString() + "'and lzfs>=0  and yddj='" + common_file.common_yddj.yddj_yd + "' and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "' group by fjrb");
                            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                            {

                                float yjdd_rs_0 = 0;
                                for (int i_0 = 0; i_0 < DS_temp_0.Tables[0].Rows.Count; i_0++)
                                {
                                    if (DS_temp_0.Tables[0].Rows[i_0]["lzfs"].ToString() != "")
                                    {
                                        yjdd_rs_0 = float.Parse(DS_temp_0.Tables[0].Rows[i_0]["lzfs"].ToString());
                                        DataSet DS_temp_1 = B_Common.GetList("select zyrs from Ffjrb", "fjrb='" + DS_temp_0.Tables[0].Rows[i_0]["fjrb"].ToString() + "'");
                                        if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                                        {
                                            yjdd_rs_0 = float.Parse(DS_temp_0.Tables[0].Rows[i_0]["lzfs"].ToString()) * float.Parse(DS_temp_1.Tables[0].Rows[0]["zyrs"].ToString());
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
            common_file.common_app.get_czsj();
            string insert_s = "";
            float ydfs = 0;
            float ydrs = 0;
            insert_s = "insert into " + table_name + "(yydh,qymc,zyzt,ydfs,ydrs,zdfs,zdrs,ylfs,ylrs,czy)";
            ydfs = 0; ydrs = 0;
            dr_yd_yl_sktt_yd_add_repeat(B_Common, DS_temp, zyzt, ref ydfs, ref ydrs);
            insert_s = insert_s + "values ('" + yydh + "','" + qymc + "','" + zyzt + "','" + ydfs.ToString() + "','" + ydrs.ToString() + "','0','0','0','0','" + czy + "') ";
            B_Common.ExecuteSql(insert_s);
            //DS_temp.Clear();
            //DS_temp.Dispose();

        }
        //当日 sktt 分析//在住
        public void dr_yd_yl_zz_update_repeat(string yydh, string qymc, BLL.Common B_Common, string zyzt, string table_name, DataSet DS_fs, DataSet DS_rs, string fs, string rs)
        {
            common_file.common_app.get_czsj();
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
            common_file.common_app.get_czsj();
            DataSet DS_temp = B_Common.GetList("select sktt,sum(lzfs) as fs from Qskyd_fjrb", select_cond + " and fjrb<>'' and lzfs>=0  and fjbh<>'' group by sktt");

            DataSet DS_temp_0 = B_Common.GetList("select sktt,count(id) as rs from Qskyd_mainrecord", select_cond + " group by sktt");

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
            common_file.common_app.get_czsj();
            string get_result = common_file.common_app.get_failure;
            BLL.Common B_Common = new BLL.Common();
            B_Common.ExecuteSql("delete from " + "F_ftfx_sktt_ddlk" + " where czy=  '" + czy + "'");

            //预计到店
            string sel_cond = "id>=0 and lzfs>=0  and yddj='" + common_file.common_yddj.yddj_yd + "'   and ddsj between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "' group by sktt";
            DataSet DS_temp = B_Common.GetList("select sktt,sum(lzfs) as lzfs from Qskyd_fjrb", sel_cond);
            //  

            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_sk, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_cz, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_zd, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_tt, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);
            dr_yd_yl_sktt_yd_add(yydh, qymc, common_file.common_sktt.sktt_hy, B_Common, DS_temp, "F_ftfx_sktt_ddlk", czy);

            //在店
            dr_yd_yl_zz_update(yydh, qymc, B_Common, "F_ftfx_sktt_ddlk", "yddj='" + common_file.common_yddj.yddj_dj + "'  and lksj not between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'", "zdfs", "zdrs");


            //预离
            dr_yd_yl_zz_update(yydh, qymc, B_Common, "F_ftfx_sktt_ddlk", "yddj='" + common_file.common_yddj.yddj_dj + "' and lksj  between '" + DateTime.Now.ToShortDateString() + "' and '" + DateTime.Now.ToShortDateString() + " 23:59:59" + "'", "ylfs", "ylrs");


            //合计
            B_Common.ExecuteSql("insert into " + "F_ftfx_sktt_ddlk" + "(yydh,qymc,zyzt,ydfs,ydrs,zdfs,zdrs,ylfs,ylrs,czy) select '" + yydh + "','" + qymc + "','" + "合计" + "',sum(ydfs),sum(ydrs),sum(zdfs),sum(zdrs),sum(ylfs),sum(ylrs),'" + czy + "' from " + "F_ftfx_sktt_ddlk where czy='" + czy + "'");


            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
            Cursor.Current = Cursors.Default;
        }




    }
}
