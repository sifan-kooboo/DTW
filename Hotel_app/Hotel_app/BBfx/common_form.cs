using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public static class common_form
    {

        //分录表
        public static BBfx.Frm_BB_zhrbb_fl Frm_BB_zhrbb_fl_new;
        public static void Frm_BB_zhrbb_fl_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_zhrbb_fl_new == null || Frm_BB_zhrbb_fl_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_zhrbb_fl_new = new BBfx.Frm_BB_zhrbb_fl();
                Frm_BB_zhrbb_fl_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_zhrbb_fl_new.Show();
            }
            Frm_BB_zhrbb_fl_new.Activate();

            Cursor.Current = Cursors.Default;
        }


        //日报表(按始显示一周)
        public static BBfx.Frm_BB_zhrbb Frm_BB_zhrbb_new;
        public static void Frm_BB_zhrbb_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_zhrbb_new == null || Frm_BB_zhrbb_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_zhrbb_new = new BBfx.Frm_BB_zhrbb();
                Frm_BB_zhrbb_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_zhrbb_new.Show();
            }
            Frm_BB_zhrbb_new.Activate(); Cursor.Current = Cursors.Default;
            Cursor.Current = Cursors.Default;

        }



        //销售员—协议单位分析

        public static BBfx.Frm_BB_syxffx_xsy_xydw Frm_BB_syxffx_xsy_xydw_new;
        public static void Frm_BB_syxffx_xsy_xydw_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_syxffx_xsy_xydw_new == null || Frm_BB_syxffx_xsy_xydw_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_syxffx_xsy_xydw_new = new BBfx.Frm_BB_syxffx_xsy_xydw();
                Frm_BB_syxffx_xsy_xydw_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_syxffx_xsy_xydw_new.Show();
            } 
            common_file.common_app.get_czsj();

            Frm_BB_syxffx_xsy_xydw_new.Activate(); Cursor.Current = Cursors.Default;

        }

        /// <summary>
        /// 销售明细分析/协议单位消费分析/客人来源消费明细查询
        /// </summary>
        public static BBfx.Frm_BB_xsymxfx Frm_BB_xsymxfx_new;
        public static void Frm_BB_xsymxfx_new_open(string loadType)
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_xsymxfx_new == null || Frm_BB_xsymxfx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_xsymxfx_new = new BBfx.Frm_BB_xsymxfx();
                Frm_BB_xsymxfx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_xsymxfx_new.initalApp(loadType);
                Frm_BB_xsymxfx_new.Show();            Cursor.Current = Cursors.Default;

            }
            else
            {
                common_file.common_app.get_czsj();

                Frm_BB_xsymxfx_new.initalApp(loadType);
                Frm_BB_xsymxfx_new.Activate();
            } Cursor.Current = Cursors.Default;

        }

        //销售员统计分析
        public static BBfx.Frm_BB_xsy Frm_BB_xsy_new;
        public static void Frm_BB_xsy_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_xsy_new == null || Frm_BB_xsy_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_xsy_new = new BBfx.Frm_BB_xsy();
                Frm_BB_xsy_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_xsy_new.Show();
            } common_file.common_app.get_czsj();

            Frm_BB_xsy_new.Activate(); Cursor.Current = Cursors.Default;

        }

        //客人来源-协议单位分析
        public static BBfx.Frm_BB_syxffx_krly_xydw Frm_BB_syxffx_krly_xydw_new;
        public static void Frm_BB_syxffx_krly_xydw_new_open()
        {
            if (Frm_BB_syxffx_krly_xydw_new == null || Frm_BB_syxffx_krly_xydw_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_syxffx_krly_xydw_new = new BBfx.Frm_BB_syxffx_krly_xydw();
                Frm_BB_syxffx_krly_xydw_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_syxffx_krly_xydw_new.Show();
            } common_file.common_app.get_czsj();

            Frm_BB_syxffx_krly_xydw_new.MdiParent = common_file.common_form.Fmain_new;
            Frm_BB_syxffx_krly_xydw_new.WindowState = FormWindowState.Maximized;
            Frm_BB_syxffx_krly_xydw_new.Activate(); Cursor.Current = Cursors.Default;

        }

        //客人来源统计分析
        public static BBfx.Frm_BB_krly Frm_BB_krly_new;
        public static void Frm_BB_krly_new_open()
        {
            if (Frm_BB_krly_new == null || Frm_BB_krly_new.IsDisposed)
            {
                Frm_BB_krly_new = new BBfx.Frm_BB_krly();
                Frm_BB_krly_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_krly_new.Show();
            }
            Frm_BB_krly_new.Activate(); Cursor.Current = Cursors.Default;

        }

        /// <summary>
        ///协议单位
        /// </summary>
        public static BBfx.Frm_BB_xydw Frm_BB_xydw_new;
        public static void Frm_BB_xydw_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_xydw_new == null || Frm_BB_xydw_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_xydw_new = new BBfx.Frm_BB_xydw();
                Frm_BB_xydw_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_xydw_new.Show();
            } common_file.common_app.get_czsj();

            Frm_BB_xydw_new.Activate(); Cursor.Current = Cursors.Default;

        }


        /// <summary>
        /// 国家片区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public static BBfx.Frm_BB_gj_pq Frm_BB_gj_pq_new;
        public static void Frm_BB_gj_pq_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_gj_pq_new == null || Frm_BB_gj_pq_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_gj_pq_new = new BBfx.Frm_BB_gj_pq();
                Frm_BB_gj_pq_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_gj_pq_new.Show();
            } common_file.common_app.get_czsj();

            Frm_BB_gj_pq_new.Activate(); Cursor.Current = Cursors.Default;

        }


        /// <summary>
        /// 省份城市
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public static BBfx.Frm_BB_sf_cs Frm_BB_sf_cs_new;
        public static void Frm_BB_sf_cs_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_sf_cs_new == null || Frm_BB_sf_cs_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_sf_cs_new = new BBfx.Frm_BB_sf_cs();
                Frm_BB_sf_cs_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_sf_cs_new.Show();
            } common_file.common_app.get_czsj();

            Frm_BB_sf_cs_new.Activate(); Cursor.Current = Cursors.Default;

        }


        ///挂账分析
        ///

        /// <summary>
        /// 记账分析
        /// </summary>
        /// BBfx.common_bb.jz_type
        /// BBfx.common_bb.gz_type
        public static BBfx.Frm_BB_j_g_fx Frm_BB_j_g_fx_new;
        public static void Frm_BB_j_g_fx_new_open(string loadType)
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_j_g_fx_new == null || Frm_BB_j_g_fx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_j_g_fx_new = new BBfx.Frm_BB_j_g_fx();
                Frm_BB_j_g_fx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_j_g_fx_new.initalApp(loadType);
                Frm_BB_j_g_fx_new.Show();
            }
            else
            {
                common_file.common_app.get_czsj();

                Frm_BB_j_g_fx_new.initalApp(loadType);
                Frm_BB_j_g_fx_new.Activate(); Cursor.Current = Cursors.Default;

            }
            
        }


        //记账挂明细分类分析
        public static BBfx.Frm_BB_j_g_mxfx Frm_BB_j_g_mxfx_new;
        public static void Frm_BB_j_g_mxfx_new_open(string loadType)
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_j_g_mxfx_new == null || Frm_BB_j_g_mxfx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_j_g_mxfx_new = new BBfx.Frm_BB_j_g_mxfx();
                Frm_BB_j_g_mxfx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_j_g_mxfx_new.initalApp(loadType);
                Frm_BB_j_g_mxfx_new.Show();
            }
            else
            {
                Frm_BB_j_g_mxfx_new.initalApp(loadType);
                Frm_BB_j_g_mxfx_new.Activate();
            }
             
        }

        //记账挂明细详细查看

        public static BBfx.Frm_BB_j_g_mxfx_xx Frm_BB_j_g_mxfx_xx_new;
        public static void Frm_BB_j_g_mxfx_xx_new_open(string loadType)
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_j_g_mxfx_xx_new == null || Frm_BB_j_g_mxfx_xx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_j_g_mxfx_xx_new = new BBfx.Frm_BB_j_g_mxfx_xx();
                Frm_BB_j_g_mxfx_xx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_j_g_mxfx_xx_new.initalApp(loadType);
                Frm_BB_j_g_mxfx_xx_new.Show();
            }
            else
            {
                common_file.common_app.get_czsj();

                Frm_BB_j_g_mxfx_xx_new.initalApp(loadType);
                Frm_BB_j_g_mxfx_xx_new.Activate();
            } Cursor.Current = Cursors.Default;

        }

        //在店预离分析
        public static BBfx.Frm_BB_zdkr_ylfx Frm_BB_zdkr_ylfx_new;
        public static void Frm_BB_zdkr_ylfx_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_zdkr_ylfx_new == null || Frm_BB_zdkr_ylfx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_zdkr_ylfx_new = new BBfx.Frm_BB_zdkr_ylfx();
                Frm_BB_zdkr_ylfx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_zdkr_ylfx_new.Show();
            }
            Frm_BB_zdkr_ylfx_new.Activate();

        }
        public static BBfx.Frm_BB_zdkr_mxfx Frm_BB_zdkr_mxfx_new;
        internal static void Frm_BB_zdkr_mxfx_new_open(string loadType)
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_zdkr_mxfx_new == null || Frm_BB_zdkr_mxfx_new.IsDisposed || (Frm_BB_zdkr_mxfx_new != null && Frm_BB_zdkr_mxfx_new.LoadType!=loadType))
            {
                common_file.common_app.get_czsj();

                Frm_BB_zdkr_mxfx_new = new BBfx.Frm_BB_zdkr_mxfx(loadType);
                Frm_BB_zdkr_mxfx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_zdkr_mxfx_new.Show();
            } 
            common_file.common_app.get_czsj();
            Frm_BB_zdkr_mxfx_new.Activate(); 
            Cursor.Current = Cursors.Default;

        }

        public static BBfx.Frm_BB_syxffx_mx Frm_BB_syxffx_mx_new;
        public static void Frm_BB_syxffx_mx_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_syxffx_mx_new == null || Frm_BB_syxffx_mx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_syxffx_mx_new = new BBfx.Frm_BB_syxffx_mx();
                Frm_BB_syxffx_mx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_syxffx_mx_new.initalApp();
                Frm_BB_syxffx_mx_new.Show();
            }
            else
            {
                common_file.common_app.get_czsj();

                Frm_BB_syxffx_mx_new.initalApp();
                Frm_BB_syxffx_mx_new.Activate();
            } Cursor.Current = Cursors.Default;

        }



        //客人来源统计分析
        public static BBfx.Frm_BB_ds Frm_BB_ds_new;
        public static void Frm_BB_ds_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_ds_new == null || Frm_BB_ds_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_ds_new = new BBfx.Frm_BB_ds();
                Frm_BB_ds_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_ds_new.Show();
            }
            Frm_BB_ds_new.Activate(); Cursor.Current = Cursors.Default;

        }
        public static BBfx.Frm_BB_zzwj Frm_BB_zzwj_new;

        internal static void Frm_BB_zzwj_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_zzwj_new == null || Frm_BB_zzwj_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_zzwj_new = new BBfx.Frm_BB_zzwj();
                Frm_BB_zzwj_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_zzwj_new.Show();
            }
            common_file.common_app.get_czsj();
            Frm_BB_zzwj_new.Activate();
            Cursor.Current = Cursors.Default;
        }




        public static BBfx.Frm_BB_czOrbz Frm_BB_czORbz_new;

        internal static void Frm_BB_czOrbz_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_czORbz_new == null || Frm_BB_czORbz_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_czORbz_new = new BBfx.Frm_BB_czOrbz();
                Frm_BB_czORbz_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_czORbz_new.Show();
            }
            common_file.common_app.get_czsj();
            Frm_BB_czORbz_new.Activate();
            Cursor.Current = Cursors.Default;
        }


        public static BBfx.Frm_BB_qtsytj Frm_BB_qtsytj_new;

        internal static void Frm_BB_qtsytj_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_qtsytj_new == null || Frm_BB_qtsytj_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_qtsytj_new = new BBfx.Frm_BB_qtsytj();
                Frm_BB_qtsytj_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_qtsytj_new.Show();
            }
            common_file.common_app.get_czsj();
            Frm_BB_qtsytj_new.Activate();
            Cursor.Current = Cursors.Default;
        }


        public static BBfx.Frm_BB_wj_gj Frm_BB_wj_gj_new;

        internal static void Frm_BB_wj_gj_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_wj_gj_new == null || Frm_BB_wj_gj_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_wj_gj_new = new BBfx.Frm_BB_wj_gj();
                Frm_BB_wj_gj_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_wj_gj_new.Show();
            }
            common_file.common_app.get_czsj();
            Frm_BB_wj_gj_new.Activate();
            Cursor.Current = Cursors.Default;
        }

        public static BBfx.Frm_BB_cy Frm_BB_cy_new;
        public static void Frm_BB_cy_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_cy_new == null || Frm_BB_cy_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_cy_new = new BBfx.Frm_BB_cy();
                Frm_BB_cy_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_cy_new.Show();
            }
            common_file.common_app.get_czsj();
            Frm_BB_cy_new.Activate();
            Cursor.Current = Cursors.Default;
        }

        public static BBfx.Frm_BB_zzkrdqtj Frm_BB_zzkrdqtj_new;
        internal static void Frm_BB_zzkrdqtj_new_open()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_zzkrdqtj_new == null || Frm_BB_zzkrdqtj_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_zzkrdqtj_new = new BBfx.Frm_BB_zzkrdqtj();
                Frm_BB_zzkrdqtj_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_zzkrdqtj_new.Show();
            }
            common_file.common_app.get_czsj();
            Frm_BB_zzkrdqtj_new.Activate();
            Cursor.Current = Cursors.Default;
        }



        public static BBfx.Frm_BB_j_g_yefx Frm_BB_j_g_yefx_new;
        internal static void Frm_BB_j_g_ye_fx_new_open(string loadType)
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_j_g_yefx_new == null || Frm_BB_j_g_yefx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_j_g_yefx_new = new BBfx.Frm_BB_j_g_yefx();
                Frm_BB_j_g_yefx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_j_g_yefx_new.initalApp(loadType);
                Frm_BB_j_g_yefx_new.Show();
            }
            else
            {
                common_file.common_app.get_czsj();

                Frm_BB_j_g_yefx_new.initalApp(loadType);
                Frm_BB_j_g_yefx_new.Activate(); 
                Cursor.Current = Cursors.Default;

            }
        }



        public static BBfx.Frm_BB_hyk_xsy Frm_BB_hyk_xsy_new;
        internal static void Frm_BB_hyk_xsy()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_hyk_xsy_new == null || Frm_BB_hyk_xsy_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_hyk_xsy_new = new BBfx.Frm_BB_hyk_xsy();
                Frm_BB_hyk_xsy_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_hyk_xsy_new.Show();
            } common_file.common_app.get_czsj();

            Frm_BB_hyk_xsy_new.Activate(); Cursor.Current = Cursors.Default;
        }


        public static BBfx.Frm_BB_hyk_xfmxfx Frm_BB_hyk_xfmxfx_new;
        internal static void Frm_BB_hyk_xftj()
        {
            common_file.common_app.get_czsj();

            if (Frm_BB_hyk_xfmxfx_new == null || Frm_BB_hyk_xfmxfx_new.IsDisposed)
            {
                common_file.common_app.get_czsj();

                Frm_BB_hyk_xfmxfx_new = new BBfx.Frm_BB_hyk_xfmxfx();
                Frm_BB_hyk_xfmxfx_new.MdiParent = common_file.common_form.Fmain_new;
                Frm_BB_hyk_xfmxfx_new.Show();
            } common_file.common_app.get_czsj();

            Frm_BB_hyk_xfmxfx_new.Activate(); Cursor.Current = Cursors.Default;
        }




        //public static BBfx.Frm_BB_kc_y_r_cbtj Frm_BB_kc_y_r_cbtj_new;
        //internal static void Frm_BB_kc_y_r_cbtj_open()
        //{
        //    common_file.common_app.get_czsj();

        //    if (Frm_BB_kc_y_r_cbtj_new == null || Frm_BB_kc_y_r_cbtj_new.IsDisposed)
        //    {
        //        common_file.common_app.get_czsj();

        //        Frm_BB_kc_y_r_cbtj_new = new BBfx.Frm_BB_kc_y_r_cbtj();
        //        Frm_BB_kc_y_r_cbtj_new.MdiParent = common_file.common_form.Fmain_new;
        //        Frm_BB_kc_y_r_cbtj_new.Show();
        //    }
        //    Frm_BB_kc_y_r_cbtj_new.Activate();

        //    Cursor.Current = Cursors.Default;
        //}
    }
}
