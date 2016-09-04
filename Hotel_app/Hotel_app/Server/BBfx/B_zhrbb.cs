using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.BBfx
{
    public class B_zhrbb
    {
        string d_space = "      ";
        string s_space = "   ";
        string t_space = " ";
        string y_z_w_y = "y";

        float zyye_fl = 0;
        float zfs_fl = 0;
        float zfh_fl = 0;
        float czfs_fl = 0;
        float pjczl_fl = 0;
        float pjczl_fl_y = 0;
        float pjfj_fl = 0;
        float pjfj_fl_y = 0;
        float jcb_fl = 0;
        float wjds_fl = 0;


        int zfs_r = 1; int zfs_y = 1;
        float sk_r_ff = 0; float cz_r_ff = 0; float zd_r_ff = 0; float tt_r_ff = 0; float hy_r_ff = 0;

        float sk_y_ff = 0; float cz_y_ff = 0; float zd_y_ff = 0; float tt_y_ff = 0; float hy_y_ff = 0;

        float sk_r_fs = 0; float cz_r_fs = 0; float zd_r_fs = 0; float tt_r_fs = 0; float hy_r_fs = 0;
        float sk_y_fs = 0; float cz_y_fs = 0; float zd_y_fs = 0; float tt_y_fs = 0; float hy_y_fs = 0;

        public void Ssyxfmx_ls_add(string yydh, string qymc, DateTime csrq, DateTime jsrq, string czy, DateTime czsj)
        {
            string cssj = csrq.ToShortDateString();
            string jssj = jsrq.ToShortDateString() + " 23:59:59";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "insert into Ssyxfmx_bb_ls(yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,czy_temp)";
            sql_s = sql_s + "select yydh,qymc,id_app,jzbh,lsbh,krxm,fjrb,fjbh,sktt,xfrq,xfsj,xfdr,xfrb,xfxm,xfbz,xfzy,sjxfje,xfsl,'" + czy + "' from Ssyxfmx where xfsj between '" + cssj + "' and '" + jssj + "'";
            B_Common.ExecuteSql(sql_s);

        }


        /// <summary>
        /// //增加房费/类别费用/代收
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="B_Common"></param>
        /// <param name="DS_temp"></param>
        /// <param name="sbzd"></param>
        /// <param name="xfrb"></param>
        /// <param name="czy"></param>
        /// <param name="table_name"></param>
        /// <param name="y_r"></param>
        /// <param name="ff_fy_ds"></param>房费是ff；费用是fy；代收是ds
        public void zhrbb_yy_ff_add(string yydh, string qymc, BLL.Common B_Common, DataSet DS_temp, string sbzd, string xfrb, string czy, string table_name, string y_r, string ff_fy_ds, DateTime rq)
        {
            string sql_s = "";
            float sjxfje = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["xfrb"].ToString() == xfrb)
                    {
                        if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                        {
                            sjxfje = float.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());
                        }
                    }

                }
            }
            if (ff_fy_ds == "ff")
            {
                switch (y_r)
                {
                    case "r":
                        if (xfrb == common_file.common_sktt.sktt_sk)
                        {
                            sk_r_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_cz)
                        {
                            cz_r_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_zd)
                        {
                            zd_r_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_tt)
                        {
                            tt_r_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_hy)
                        {
                            hy_r_ff = sjxfje;
                        }
                        break;
                    case "y":
                        if (xfrb == common_file.common_sktt.sktt_sk)
                        {
                            sk_y_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_cz)
                        {
                            cz_y_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_zd)
                        {
                            zd_y_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_tt)
                        {
                            tt_y_ff = sjxfje;
                        }
                        if (xfrb == common_file.common_sktt.sktt_hy)
                        {
                            hy_y_ff = sjxfje;
                        }
                        break;
                }
            }
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + xfrb, sjxfje.ToString(), czy, y_r, y_z_w_y, rq);
        }





        public void Insert_SQL_bbfx(BLL.Common B_Common, string table_name, string yydh, string qymc, string sbzd, string xfrb, string sjxfje, string czy, string y_r, string y_z_w, DateTime bbrq)
        {
            string sql_s = "insert into " + table_name + " (yydh,qymc,sbzd,xfrb,sjxfje,czy_temp,y_r,y_z_w,bbrq)";
            sql_s = sql_s + " values ('" + yydh + "','" + qymc + "','" + sbzd + "','" + xfrb + "','" + sjxfje.ToString() + "','" + czy + "','" + y_r + "','" + y_z_w + "','" + bbrq.ToShortDateString() + "')";
            B_Common.ExecuteSql(sql_s);
        }

        //获取入住房数
        public void zhrbb_yy_fs_add(string yydh, string qymc, BLL.Common B_Common, DataSet DS_temp, string xfrb, string czy, string table_name, string y_r, DateTime rq)
        {
            string sql_s = "";
            float lzfs = 0;
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["xfrb"].ToString() == xfrb)
                    {
                        if (DS_temp.Tables[0].Rows[i_0]["xfsl"].ToString() != "")
                        {
                            lzfs = float.Parse(DS_temp.Tables[0].Rows[i_0]["xfsl"].ToString());
                        }
                    }

                }
            }
            switch (y_r)
            {
                case "r":
                    if (xfrb == common_file.common_sktt.sktt_sk)
                    {
                        sk_r_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_cz)
                    {
                        cz_r_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_zd)
                    {
                        zd_r_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_tt)
                    {
                        tt_r_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_hy)
                    {
                        hy_r_fs = lzfs;
                    }
                    break;
                case "y":
                    if (xfrb == common_file.common_sktt.sktt_sk)
                    {
                        sk_y_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_cz)
                    {
                        cz_y_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_zd)
                    {
                        zd_y_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_tt)
                    {
                        tt_y_fs = lzfs;
                    }
                    if (xfrb == common_file.common_sktt.sktt_hy)
                    {
                        hy_y_fs = lzfs;
                    }
                    break;
            }
        }



        //大类费用及类别费用
        public void zhrbb_add_fy(string yydh, string qymc, string czy, string y_r, DateTime rq)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select xfrb,sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls", "czy_temp='" + czy + "' and xfdr='" + Szwgl.common_zw.dr_ff + "' group by xfrb");
            string table_name = "BBfx_yyjl";
            float sjxfje = 0;
            string sbzd = "y_f_1";
            string sql_s = "";


            //标题1
            sbzd = "y_t_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "营业收入分析", "", czy, y_r, y_z_w_y, rq);
            //空格1
            sbzd = "y_sp_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);
            //总房费
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {

                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = sjxfje + float.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());
                    }

                }
            }

            if (y_r == "r")
            {
                zfh_fl = sjxfje;
            }
            sbzd = "y_f_1";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "客房费用", sjxfje.ToString(), czy, y_r, y_z_w_y, rq);

            //类别房费
            zhrbb_yy_ff_add(yydh, qymc, B_Common, DS_temp, "y_f_2", common_file.common_sktt.sktt_sk, czy, table_name, y_r, "ff", rq);
            zhrbb_yy_ff_add(yydh, qymc, B_Common, DS_temp, "y_f_3", common_file.common_sktt.sktt_cz, czy, table_name, y_r, "ff", rq);
            zhrbb_yy_ff_add(yydh, qymc, B_Common, DS_temp, "y_f_4", common_file.common_sktt.sktt_zd, czy, table_name, y_r, "ff", rq);
            zhrbb_yy_ff_add(yydh, qymc, B_Common, DS_temp, "y_f_5", common_file.common_sktt.sktt_tt, czy, table_name, y_r, "ff", rq);
            zhrbb_yy_ff_add(yydh, qymc, B_Common, DS_temp, "y_f_6", common_file.common_sktt.sktt_hy, czy, table_name, y_r, "ff", rq);






            //获取房数
            DS_temp = B_Common.GetList("select xfrb,sum(xfsl) as xfsl from Ssyxfmx_bb_ls", "czy_temp='" + czy + "' and xfdr='" + Szwgl.common_zw.dr_ff + "' group by xfrb");
            zhrbb_yy_fs_add(yydh, qymc, B_Common, DS_temp, common_file.common_sktt.sktt_sk, czy, table_name, y_r, rq);
            zhrbb_yy_fs_add(yydh, qymc, B_Common, DS_temp, common_file.common_sktt.sktt_cz, czy, table_name, y_r, rq);
            zhrbb_yy_fs_add(yydh, qymc, B_Common, DS_temp, common_file.common_sktt.sktt_zd, czy, table_name, y_r, rq);
            zhrbb_yy_fs_add(yydh, qymc, B_Common, DS_temp, common_file.common_sktt.sktt_tt, czy, table_name, y_r, rq);
            zhrbb_yy_fs_add(yydh, qymc, B_Common, DS_temp, common_file.common_sktt.sktt_hy, czy, table_name, y_r, rq);


            if (y_r == "r")
            {
                czfs_fl = sk_r_fs + cz_r_fs + zd_r_fs + tt_r_fs + hy_r_fs;

            }



            //类别费用
            DS_temp = B_Common.GetList("select drbh,xfdr  from Xxfdr", "is_visible_bb=1 and xfdr!='" + Szwgl.common_zw.dr_ds + "' order by drbh");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sjxfje = 0;
                for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    DataSet DS_temp_0 = B_Common.GetList("select xfrb,sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls", "czy_temp='" + czy + "'and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr='" + DS_temp.Tables[0].Rows[i_0]["xfdr"].ToString() + "'        group by xfrb");
                    sjxfje = 0;
                    sbzd = "y_dr_" + i_0.ToString();
                    //大类费用
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        for (int k_0 = 0; k_0 < DS_temp_0.Tables[0].Rows.Count; k_0++)
                        {
                            if (DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                            {
                                sjxfje = sjxfje + float.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString());
                            }
                        }
                    }

                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + DS_temp.Tables[0].Rows[i_0]["xfdr"].ToString(), sjxfje.ToString(), czy, y_r, y_z_w_y, rq);



                    DataSet DS_temp_1 = B_Common.GetList("select xfxr from Xxfxr", "is_visible_bb=1 and xfdr='" + DS_temp.Tables[0].Rows[i_0]["xfdr"].ToString() + "'");
                    DS_temp_0 = B_Common.GetList("select xfrb,sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls", "czy_temp='" + czy + "'and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr='" + DS_temp.Tables[0].Rows[i_0]["xfdr"].ToString() + "'and xfrb in(select xfxr from Xxfxr where is_visible_bb=1) group by xfrb");
                    if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                    {
                        for (int k_0 = 0; k_0 < DS_temp_1.Tables[0].Rows.Count; k_0++)
                        {
                            zhrbb_yy_ff_add(yydh, qymc, B_Common, DS_temp_0, "y_d_" + i_0.ToString() + "x_" + k_0.ToString(), DS_temp_1.Tables[0].Rows[k_0]["xfxr"].ToString(), czy, table_name, y_r, "fy", rq);
                        }
                    }


                    //未列入显示的小类
                    sjxfje = 0; sbzd = "y_" + i_0 + "_1";
                    DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls", "czy_temp='" + czy + "'and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr='" + DS_temp.Tables[0].Rows[i_0]["xfdr"].ToString() + "'and (xfrb in(select xfxr from Xxfxr where is_visible_bb=0 and xfdr='" + DS_temp.Tables[0].Rows[i_0]["xfdr"].ToString() + "') or xfrb not in(select xfxr from Xxfxr where xfdr='" + DS_temp.Tables[0].Rows[i_0]["xfdr"].ToString() + "'))");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                        {
                            sjxfje = float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                        }
                    }


                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "其他", sjxfje.ToString(), czy, y_r, y_z_w_y, rq);



                    DS_temp_0.Clear();
                    DS_temp_0.Dispose();
                    DS_temp_1.Clear();
                    DS_temp_1.Dispose();

                }
            }




            //未列入显示的大类
            sjxfje = 0; sbzd = "y_qt_1";
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje  from Ssyxfmx_bb_ls", "czy_temp='" + czy + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and xfdr in(select xfdr from Xxfdr where is_visible_bb=0)");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = float.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }

            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "其他消费", sjxfje.ToString(), czy, y_r, y_z_w_y, rq);



            //空格2
            sbzd = "y_sp_2";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);

            //标题2
            sjxfje = 0; sbzd = "y_t_2";
            DS_temp = B_Common.GetList("select sum(sjxfje) as sjxfje  from Ssyxfmx_bb_ls", "czy_temp='" + czy + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    sjxfje = float.Parse(DS_temp.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }



            if (y_r == "r")
            {
                zyye_fl = sjxfje;

            }


            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "营业总额", sjxfje.ToString(), czy, y_r, y_z_w_y, rq);


            //空格3
            sbzd = "y_sp_3";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);
            //sbzd = "y_sp_3_00";//临时增补的空格
            //Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);
            //总房数
            if (y_r == "r")
            {
                zfs_fl = zfs_r;
                sbzd = "y_t_3";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "总房数", zfs_r.ToString(), czy, y_r, y_z_w_y, rq);
            }
            else
                if (y_r == "y")
                {
                    sbzd = "y_t_3";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "总房数", zfs_y.ToString(), czy, y_r, y_z_w_y, rq);
                }
            //空格4
            sbzd = "y_sp_4";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);


            //出租房数
            if (y_r == "r")
            {
                sbzd = "y_fs_z";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "出租房数", Convert.ToString(sk_r_fs + cz_r_fs + zd_r_fs + tt_r_fs + hy_r_fs), czy, y_r, y_z_w_y, rq);
                sbzd = "y_fs_sk";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_sk, Convert.ToString(sk_r_fs), czy, y_r, y_z_w_y, rq);
                sbzd = "y_fs_cz";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_cz, Convert.ToString(cz_r_fs), czy, y_r, y_z_w_y, rq);
                sbzd = "y_fs_zd";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_zd, Convert.ToString(zd_r_fs), czy, y_r, y_z_w_y, rq);
                sbzd = "y_fs_tt";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_tt, Convert.ToString(tt_r_fs), czy, y_r, y_z_w_y, rq);
                sbzd = "y_fs_hy";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_hy, Convert.ToString(hy_r_fs), czy, y_r, y_z_w_y, rq);
            }
            else
                if (y_r == "y")
                {
                    sbzd = "y_fs_z";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "出租房数", Convert.ToString(sk_y_fs + cz_y_fs + zd_y_fs + tt_y_fs + hy_y_fs), czy, y_r, y_z_w_y, rq);

                    sbzd = "y_fs_sk";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_sk, Convert.ToString(sk_y_fs), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_fs_cz";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_cz, Convert.ToString(cz_y_fs), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_fs_zd";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_zd, Convert.ToString(zd_y_fs), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_fs_tt";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_tt, Convert.ToString(tt_y_fs), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_fs_hy";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_hy, Convert.ToString(hy_y_fs), czy, y_r, y_z_w_y, rq);
                }
            //

            //空格5
            sbzd = "y_sp_5";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);

            //出租率
            if (y_r == "r")
            {
                sbzd = "y_czl_z";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "平均出租率", Convert.ToString(Math.Floor(((sk_r_fs + cz_r_fs + zd_r_fs + tt_r_fs + hy_r_fs) / zfs_r) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                pjczl_fl = float.Parse(Convert.ToString(Math.Floor(((sk_r_fs + cz_r_fs + zd_r_fs + tt_r_fs + hy_r_fs) / zfs_r) * 10000) / 10000));
                sbzd = "y_czl_sk";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_sk, Convert.ToString(Math.Floor((sk_r_fs / zfs_r) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                sbzd = "y_czl_cz";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_cz, Convert.ToString(Math.Floor((cz_r_fs / zfs_r) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                sbzd = "y_czl_zd";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_zd, Convert.ToString(Math.Floor((zd_r_fs / zfs_r) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                sbzd = "y_czl_tt";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_tt, Convert.ToString(Math.Floor((tt_r_fs / zfs_r) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                sbzd = "y_czl_hy";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_hy, Convert.ToString(Math.Floor((hy_r_fs / zfs_r) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
            }
            else
                if (y_r == "y")
                {
                    sbzd = "y_czl_z";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "平均出租率", Convert.ToString(Math.Floor(((sk_y_fs + cz_y_fs + zd_y_fs + tt_y_fs + hy_y_fs) / zfs_y) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                    pjczl_fl_y = float.Parse(Convert.ToString(Math.Floor(((sk_y_fs + cz_y_fs + zd_y_fs + tt_y_fs + hy_y_fs) / zfs_y) * 10000) / 10000));
                    sbzd = "y_czl_sk";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_sk, Convert.ToString(Math.Floor((sk_y_fs / zfs_y) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                    sbzd = "y_czl_cz";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_cz, Convert.ToString(Math.Floor((cz_y_fs / zfs_y) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                    sbzd = "y_czl_zd";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_zd, Convert.ToString(Math.Floor((zd_y_fs / zfs_y) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                    sbzd = "y_czl_tt";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_tt, Convert.ToString(Math.Floor((tt_y_fs / zfs_y) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                    sbzd = "y_czl_hy";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_hy, Convert.ToString(Math.Floor((hy_y_fs / zfs_y) * 10000) / 100) + "%", czy, y_r, y_z_w_y, rq);
                }

            //空格6
            sbzd = "y_sp_6";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);

            //平均房价
            float zzyfs = 0;
            if (y_r == "r")
            {
                zzyfs = 0;
                zzyfs = sk_r_fs + cz_r_fs + zd_r_fs + tt_r_fs + hy_r_fs;
                if (zzyfs == 0) zzyfs = 1;
                sbzd = "y_pjfj_z";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "平均房价", Convert.ToString(Math.Floor(((sk_r_ff + cz_r_ff + zd_r_ff + tt_r_ff + hy_r_ff) / zzyfs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                pjfj_fl = float.Parse(Convert.ToString(Math.Floor(((sk_r_ff + cz_r_ff + zd_r_ff + tt_r_ff + hy_r_ff) / zzyfs) * 10) / 10));
                if (sk_r_fs == 0) sk_r_fs = 1;
                if (cz_r_fs == 0) cz_r_fs = 1;
                if (zd_r_fs == 0) zd_r_fs = 1;
                if (tt_r_fs == 0) tt_r_fs = 1;
                if (hy_r_fs == 0) hy_r_fs = 1;
                sbzd = "y_pjfj_sk";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_sk, Convert.ToString(Math.Floor((sk_r_ff / sk_r_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                sbzd = "y_pjfj_cz";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_cz, Convert.ToString(Math.Floor((cz_r_ff / cz_r_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                sbzd = "y_pjfj_zd";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_zd, Convert.ToString(Math.Floor((zd_r_ff / zd_r_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                sbzd = "y_pjfj_tt";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_tt, Convert.ToString(Math.Floor((tt_r_ff / tt_r_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                sbzd = "y_pjfj_hy";
                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_hy, Convert.ToString(Math.Floor((hy_r_ff / hy_r_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
            }
            else
                if (y_r == "y")
                {
                    zzyfs = 0;
                    zzyfs = sk_y_fs + cz_y_fs + zd_y_fs + tt_y_fs + hy_y_fs;
                    if (zzyfs == 0) zzyfs = 1;
                    sbzd = "y_pjfj_z";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "平均房价", Convert.ToString(Math.Floor(((sk_y_ff + cz_y_ff + zd_y_ff + tt_y_ff + hy_y_ff) / zzyfs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                    pjfj_fl_y = float.Parse(Convert.ToString(Math.Floor(((sk_y_ff + cz_y_ff + zd_y_ff + tt_y_ff + hy_y_ff) / zzyfs) * 10) / 10));
                    if (sk_y_fs == 0) sk_y_fs = 1;
                    if (cz_y_fs == 0) cz_y_fs = 1;
                    if (zd_y_fs == 0) zd_y_fs = 1;
                    if (tt_y_fs == 0) tt_y_fs = 1;
                    if (hy_y_fs == 0) hy_y_fs = 1;
                    sbzd = "y_pjfj_sk";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_sk, Convert.ToString(Math.Floor((sk_y_ff / sk_y_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_pjfj_cz";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_cz, Convert.ToString(Math.Floor((cz_y_ff / cz_y_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_pjfj_zd";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_zd, Convert.ToString(Math.Floor((zd_y_ff / zd_y_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_pjfj_tt";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_tt, Convert.ToString(Math.Floor((tt_y_ff / tt_y_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                    sbzd = "y_pjfj_hy";
                    Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + common_file.common_sktt.sktt_hy, Convert.ToString(Math.Floor((hy_y_ff / hy_y_fs) * 10) / 10), czy, y_r, y_z_w_y, rq);
                }


            //空格8
            //sbzd = "y_sp_71";
            //Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r);
            //int zkhj = 0;
            //DS_temp = B_Common.GetList("select count(id) as zrs from Qskyd_mainrecord"," ");

            //空格71
            sbzd = "y_sp_71";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);

            sbzd = "y_jcb_z";
            float jcb = 0;
            if (y_r == "r")
            {
                jcb = pjfj_fl * pjczl_fl;
                jcb_fl = jcb;
            }
            else
                if (y_r == "y")
                {
                    jcb = pjczl_fl_y * pjfj_fl_y;
                }

            jcb = float.Parse(Convert.ToString(common_file.common_sswl.Round_sswl(double.Parse(jcb.ToString()), 2, common_file.common_sswl.selectMode_sel).ToString()));



            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, s_space + "交叉比", jcb.ToString(), czy, y_r, y_z_w_y, rq);



            //空格8
            sbzd = "y_sp_8";
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);
            sbzd = "y_sp_8_00";//临时增补的空格
            Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, "", "", czy, y_r, y_z_w_y, rq);



            //代收
            //DS_temp = B_Common.GetList("select drbh,xfdr  from Xxfdr", "is_visible_bb=1 and xfdr!='" + Szwgl.common_zw.dr_ds + "' order by drbh");
            //if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sjxfje = 0;
                //for (int i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                //{
                DataSet DS_temp_0 = B_Common.GetList("select xfrb,sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls", "czy_temp='" + czy + "'and xfdr='" + Szwgl.common_zw.dr_ds + "' group by xfrb");
                sjxfje = 0;
                sbzd = "y_dsdr";
                //大类费用
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    for (int k_0 = 0; k_0 < DS_temp_0.Tables[0].Rows.Count; k_0++)
                    {
                        if (DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                        {
                            sjxfje = sjxfje + float.Parse(DS_temp_0.Tables[0].Rows[k_0]["sjxfje"].ToString());
                        }
                    }
                }

                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, t_space + "营业代收总额", sjxfje.ToString(), czy, y_r, y_z_w_y, rq);
                if (y_r == "r")
                {
                    wjds_fl = sjxfje;
                }

                DataSet DS_temp_1 = B_Common.GetList("select xfxr from Xxfxr", "is_visible_bb=1 and xfdr='" + Szwgl.common_zw.dr_ds + "'");

                if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                {
                    DS_temp_0 = B_Common.GetList("select xfrb,sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls", "czy_temp='" + czy + "'and xfdr='" + Szwgl.common_zw.dr_ds + "' and xfrb in(select xfxr from Xxfxr where is_visible_bb=1) group by xfrb");
                    for (int k_0 = 0; k_0 < DS_temp_1.Tables[0].Rows.Count; k_0++)
                    {
                        zhrbb_yy_ff_add(yydh, qymc, B_Common, DS_temp_0, "y_ds_" + k_0.ToString(), DS_temp_1.Tables[0].Rows[k_0]["xfxr"].ToString(), czy, table_name, y_r, "ds", rq);
                    }
                }
                //未列入显示的小类
                sjxfje = 0; sbzd = "y_dsqt_1";
                string s_temp_0_0="select sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls where czy_temp='" + czy + "'and xfdr='" + Szwgl.common_zw.dr_ds + "' and (xfrb in(select xfxr from Xxfxr where is_visible_bb=0 and xfdr='" + Szwgl.common_zw.dr_ds + "') or xfrb not in (select xfxr from Xxfxr where xfdr='" + Szwgl.common_zw.dr_ds + "'))";
                DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje from Ssyxfmx_bb_ls", "czy_temp='" + czy + "'and xfdr='" + Szwgl.common_zw.dr_ds + "' and (xfrb in(select xfxr from Xxfxr where is_visible_bb=0 and xfdr='" + Szwgl.common_zw.dr_ds + "') or xfrb not in (select xfxr from Xxfxr where xfdr='" + Szwgl.common_zw.dr_ds + "'))");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                    {
                        sjxfje = float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                    }
                }

                Insert_SQL_bbfx(B_Common, table_name, yydh, qymc, sbzd, d_space + "其他", sjxfje.ToString(), czy, y_r, y_z_w_y, rq);


                DS_temp_0.Clear();
                DS_temp_0.Dispose();
                DS_temp_1.Clear();
                DS_temp_1.Dispose();

                //}
            }

            DS_temp.Clear();
            DS_temp.Dispose();
        }

        /// <summary>
        /// 生成营业部分的最终报表
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="czy"></param>
        /// <param name="rq"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string zhrbb_add_fy_app(string yydh, string qymc, string czy, DateTime rq, DateTime czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;

            string sql_s = "";
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp;
            //日
            DS_temp = B_Common.GetList("select zfs from BBfx_zfs", "rq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                zfs_r = int.Parse(DS_temp.Tables[0].Rows[0]["zfs"].ToString());
            }
            else
            {
                zfs_r = common_bb.get_zfs();
                sql_s = "insert into BBfx_zfs(yydh,qymc,zfs,rq) values('" + yydh + "','" + qymc + "','" + zfs_r + "','" + rq.ToShortDateString() + "')";
                B_Common.ExecuteSql(sql_s);
            }
            sql_s = "delete from Ssyxfmx_bb_ls where czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "delete from BBfx_yyjl where czy_temp='" + czy + "' and y_z_w='" + y_z_w_y + "'";
            B_Common.ExecuteSql(sql_s);

            Ssyxfmx_ls_add(yydh, qymc, rq, rq, czy, czsj);
            zhrbb_add_fy(yydh, qymc, czy, "r", rq);


            //月
            int ybtqts = 0;
            DS_temp = B_Common.GetList("select ybtqts from Qcounter", " id>=0");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["ybtqts"].ToString() != "")
                {
                    ybtqts = int.Parse(DS_temp.Tables[0].Rows[0]["ybtqts"].ToString());
                }
            }
            zfs_y = zfs_r;

            DateTime yfcssj = common_bb.judge_yfcssj(rq, ybtqts);
            string sel_s = " rq between '" + yfcssj.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'";
            DS_temp = B_Common.GetList("select sum(zfs) as zfs from BBfx_zfs", sel_s);
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                if (DS_temp.Tables[0].Rows[0]["zfs"].ToString() != "")
                {
                    zfs_y = int.Parse(DS_temp.Tables[0].Rows[0]["zfs"].ToString());
                }
            }

            sql_s = "delete from Ssyxfmx_bb_ls where czy_temp='" + czy + "'";
            B_Common.ExecuteSql(sql_s);


            Ssyxfmx_ls_add(yydh, qymc, yfcssj, rq, czy, czsj);
            zhrbb_add_fy(yydh, qymc, czy, "y", rq);

            //把最终结果转移到正式的地方存储
            sql_s = "delete from BBfx_yyjl_last_save where bbrq='" + rq.ToShortDateString() + "' and y_z_w='y'";
            B_Common.ExecuteSql(sql_s);
            sql_s = "insert into BBfx_yyjl_last_save (yydh,qymc,sbzd,xfrb,sjxfje,czy,y_r,y_z_w,bbrq) select yydh,qymc,sbzd,xfrb,sjxfje,'" + czy + "',y_r,y_z_w,'" + rq.ToShortDateString() + "' from BBfx_yyjl where czy_temp='" + czy + "' and bbrq='" + rq.ToShortDateString() + "' and y_z_w='y'";
            B_Common.ExecuteSql(sql_s);

            sql_s = "";
            DS_temp = B_Common.GetList("select id from BSzhrbbfl", "yydh='" + yydh + "' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                sql_s = "update BSzhrbbfl set zfs='" + zfs_fl.ToString() + "',zyye='" + zyye_fl.ToString() + "',zfh='" + zfh_fl.ToString() + "',czfs='" + czfs_fl.ToString() + "',pjczl='" + Convert.ToString(pjczl_fl * 100) + "%" + "',pjfj='" + pjfj_fl.ToString() + "',jcb='" + jcb_fl.ToString() + "',wjds='" + wjds_fl.ToString() + "' where yydh='" + yydh + "' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'";
            }
            else
            {
                sql_s = "insert into BSzhrbbfl(yydh,qymc,bbrq,zfs,zyye,zfh,czfs,pjczl_nu,pjczl,pjfj,jcb,wjds) values('" + yydh + "','" + qymc + "','" + rq.ToShortDateString() + "','" + zfs_fl.ToString() + "','" + zyye_fl.ToString() + "','" + zfh_fl.ToString() + "','" + czfs_fl.ToString() + "','" + pjczl_fl.ToString() + "','" + Convert.ToString(pjczl_fl * 100) + "%" + "','" + pjfj_fl.ToString() + "','" + jcb_fl.ToString() + "','" + wjds_fl.ToString() + "')";

            }
            if (sql_s != "")
            {
                B_Common.ExecuteSql(sql_s);
            }

            common_file.common_czjl.add_czjl(yydh, qymc, czy, "生成日报表-费用", "", "", czsj);

            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="rq"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="judge_rx"></param>四个值1生成营业收入，2生成账务收入，3生成未结，4全部
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string New_zhrbb_app(string yydh, string qymc, DateTime rq, string czy, DateTime czsj, int judge_rx, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            B_zhrbb_zw B_zhrbb_zw_new = new B_zhrbb_zw();
            switch (judge_rx)
            {
                case 1:
                    zhrbb_add_fy_app(yydh, qymc, czy, rq, czsj, xxzs);
                    break;
                case 2:
                    
                    B_zhrbb_zw_new.zhrbb_zw_app(yydh, qymc, czy, rq, czsj.ToString(), xxzs);
                    break;
                case 3:
                    B_zhrbb_zw_new.zhrbb_zw_ys_wj_app(yydh, qymc, czy, rq, czsj.ToString(), xxzs);
                    break;

                case 4:
                    zhrbb_add_fy_app(yydh, qymc, czy, rq, czsj, xxzs);
                    B_zhrbb_zw_new.zhrbb_zw_app(yydh, qymc, czy, rq, czsj.ToString(), xxzs);
                    B_zhrbb_zw_new.zhrbb_zw_ys_wj_app(yydh, qymc, czy, rq, czsj.ToString(), xxzs);
                    break;

            }
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "delete from  BSzhrbb where bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "'";
            B_Common.ExecuteSql(sql_s);

            sql_s = "insert into BSzhrbb(yydh,qymc,bbrq,rbxm,brrj,byrj,rbxm0,brrj0,byrj0) select yydh,qymc,'" + rq.ToShortDateString() + "',xfrb,sjxfje,'','','','' from BBfx_yyjl_last_save where y_z_w='y' and y_r='r' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' order by id";
            B_Common.ExecuteSql(sql_s);

            DataSet DS_temp_yl;
            int k_0 = 0;
            DS_temp_yl = B_Common.GetList("select id from BSzhrbb", " bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' order by id");

            DataSet DS_temp;

            DS_temp = B_Common.GetList("select xfrb,sjxfje from BBfx_yyjl_last_save", " y_z_w='y' and y_r='y' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' order by id");
            if (DS_temp_yl != null && DS_temp_yl.Tables[0].Rows.Count > 0 && DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (k_0 = 0; k_0 < DS_temp_yl.Tables[0].Rows.Count; k_0++)
                {
                    if (k_0 < DS_temp.Tables[0].Rows.Count)
                    {
                        if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                        {
                            sql_s = "update BSzhrbb set byrj='" + DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() + "' where id='" + DS_temp_yl.Tables[0].Rows[k_0]["id"].ToString() + "'";
                            B_Common.ExecuteSql(sql_s);
                        }
                    }

                }

            }


            int k_first = 0;

            DS_temp = B_Common.GetList("select xfrb,sjxfje from BBfx_yyjl_last_save", " (y_z_w='z' ) and y_r='r' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' order by id");
            if (DS_temp_yl != null && DS_temp_yl.Tables[0].Rows.Count > 0 && DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (k_0 = 0; k_0 < DS_temp_yl.Tables[0].Rows.Count; k_0++)
                {
                    if (k_0 < DS_temp.Tables[0].Rows.Count)
                    {
                        if (DS_temp.Tables[0].Rows[k_0]["xfrb"].ToString() != "")
                        {
                            sql_s = "update BSzhrbb set rbxm0='" + DS_temp.Tables[0].Rows[k_0]["xfrb"].ToString() + "',brrj0='" + DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() + "' where id='" + DS_temp_yl.Tables[0].Rows[k_0]["id"].ToString() + "'";
                            B_Common.ExecuteSql(sql_s);
                        }
                        k_first = k_first + 1;

                    }

                }

            }

            


            DS_temp = B_Common.GetList("select xfrb,sjxfje from BBfx_yyjl_last_save", " (y_z_w='w') and y_r='r' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' order by id");
            if (DS_temp_yl != null && DS_temp_yl.Tables[0].Rows.Count > 0 && DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (k_0 = 0; k_first < DS_temp_yl.Tables[0].Rows.Count; k_0++)
                {
                    if (k_0 < DS_temp.Tables[0].Rows.Count)
                    {
                        if (DS_temp.Tables[0].Rows[k_0]["xfrb"].ToString() != "")
                        {
                            sql_s = "update BSzhrbb set rbxm0='" + DS_temp.Tables[0].Rows[k_0]["xfrb"].ToString() + "',brrj0='" + DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() + "' where id='" + DS_temp_yl.Tables[0].Rows[k_first]["id"].ToString() + "'";
                            B_Common.ExecuteSql(sql_s);
                        }
                    }
                    k_first = k_first + 1; 

                }

            }



            k_first = 0;


            DS_temp = B_Common.GetList("select xfrb,sjxfje from BBfx_yyjl_last_save", " (y_z_w='z') and y_r='y' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' order by id");
            if (DS_temp_yl != null && DS_temp_yl.Tables[0].Rows.Count > 0 && DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (k_0 = 0; k_0 < DS_temp_yl.Tables[0].Rows.Count; k_0++)
                {
                    if (k_0 < DS_temp.Tables[0].Rows.Count)
                    {
                        if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                        {
                            sql_s = "update BSzhrbb set byrj0='" + DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() + "' where id='" + DS_temp_yl.Tables[0].Rows[k_0]["id"].ToString() + "'";
                            B_Common.ExecuteSql(sql_s);
                        }
                        k_first = k_first + 1;
                    }

                }

            }

            

            DS_temp = B_Common.GetList("select xfrb,sjxfje from BBfx_yyjl_last_save", " (y_z_w='w') and y_r='y' and bbrq between '" + rq.ToShortDateString() + "' and '" + rq.ToShortDateString() + " 23:59:59" + "' order by id");
            if (DS_temp_yl != null && DS_temp_yl.Tables[0].Rows.Count > 0 && DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (k_0 = 0; k_first < DS_temp_yl.Tables[0].Rows.Count; k_0++)
                {
                    if (k_0 < DS_temp.Tables[0].Rows.Count)
                    {
                        if (DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() != "")
                        {
                            sql_s = "update BSzhrbb set byrj0='" + DS_temp.Tables[0].Rows[k_0]["sjxfje"].ToString() + "' where id='" + DS_temp_yl.Tables[0].Rows[ k_first]["id"].ToString() + "'";
                            B_Common.ExecuteSql(sql_s);
                        }
                    }
                    k_first = k_first + 1;
                }

            }






            common_file.common_czjl.add_czjl(yydh, qymc, czy, "生成日报表-综合", "", "", czsj);
            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;
        }
    }
}
