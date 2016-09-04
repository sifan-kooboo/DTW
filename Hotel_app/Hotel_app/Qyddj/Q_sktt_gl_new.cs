using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    class Q_sktt_gl_new
    {
        public Qyddj.Q_sktt_gl Q_sktt_gl_new_0;

        public void not_visible()
        {

            
        }

        public void change_control(String load_type)
        {
            if (load_type == "sk" || load_type == "yt_sk")//散客和已退散客
            {
                Q_sktt_gl_new_0.l_qymc.Enabled = false;
                Q_sktt_gl_new_0.tB_qymc.Enabled = false;
                Q_sktt_gl_new_0.l_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.tB_ydrxm.Enabled = false;
            }

            if (load_type == "tt" || load_type == "yt_tt")//团体和已退团体
            {
                //Q_sktt_gl_new_0.l_ydrxm.Enabled = false;
                //Q_sktt_gl_new_0.tB_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.l_fjrb.Enabled = false;
                Q_sktt_gl_new_0.l_fjjg.Enabled = false;
                Q_sktt_gl_new_0.l_fjbh.Enabled = false;
                Q_sktt_gl_new_0.tB_fjrb.Enabled = false;
                Q_sktt_gl_new_0.tB_fjjg_cs.Enabled = false;
                Q_sktt_gl_new_0.tB_fjjg_js.Enabled = false;
                Q_sktt_gl_new_0.tB_fjbh.Enabled = false;


            }

            if (load_type == "ls")
            {
                Q_sktt_gl_new_0.l_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.tB_ydrxm.Enabled = false;

            }

            if (load_type == "lscz_sk")
            {
                Q_sktt_gl_new_0.tB_fjjg_cs.Enabled = false;
                Q_sktt_gl_new_0.tB_fjjg_js.Enabled = false;
                Q_sktt_gl_new_0.tB_krgj.Enabled = false;
                Q_sktt_gl_new_0.tB_krly.Enabled = false;
                Q_sktt_gl_new_0.tB_fjrb.Enabled = false;
                Q_sktt_gl_new_0.tB_krsj.Enabled = false;
                Q_sktt_gl_new_0.tB_qtyq.Enabled = false;
                Q_sktt_gl_new_0.tB_qymc.Enabled = false;
                Q_sktt_gl_new_0.tB_tsyq.Enabled = false;
                Q_sktt_gl_new_0.tB_xydw.Enabled = false;
                Q_sktt_gl_new_0.tB_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.tB_hykh.Enabled = false;
                Q_sktt_gl_new_0.dT_ddsj_cs.Enabled = false;
                Q_sktt_gl_new_0.dT_ddsj_js.Enabled = false;
                Q_sktt_gl_new_0.dT_lksj_cs.Enabled = false;
                Q_sktt_gl_new_0.dT_lksj_js.Enabled = false;
                Q_sktt_gl_new_0.tB_czy.Enabled = false;
                Q_sktt_gl_new_0.l_ddsj.Enabled = false;
                Q_sktt_gl_new_0.l_fjjg.Enabled = false;
                Q_sktt_gl_new_0.l_fjrb.Enabled = false;
                Q_sktt_gl_new_0.l_hykh.Enabled = false;
                Q_sktt_gl_new_0.l_krgj.Enabled = false;
                Q_sktt_gl_new_0.l_krly.Enabled = false;
                Q_sktt_gl_new_0.l_krsj.Enabled = false;
                Q_sktt_gl_new_0.l_lksj.Enabled = false;
                Q_sktt_gl_new_0.l_qtyq.Enabled = false;
                Q_sktt_gl_new_0.l_qymc.Enabled = false;
                Q_sktt_gl_new_0.l_tsyq.Enabled = false;
                Q_sktt_gl_new_0.l_xydw.Enabled = false;
                Q_sktt_gl_new_0.l_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.l_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.l_czy.Enabled = false;
            }
            if (load_type == "lscz_tt")
            {
                Q_sktt_gl_new_0.tB_fjjg_cs.Enabled = false;
                Q_sktt_gl_new_0.tB_fjjg_js.Enabled = false;
                Q_sktt_gl_new_0.tB_krgj.Enabled = false;
                Q_sktt_gl_new_0.tB_krly.Enabled = false;
                Q_sktt_gl_new_0.tB_fjrb.Enabled = false;
                Q_sktt_gl_new_0.tB_krsj.Enabled = false;
                Q_sktt_gl_new_0.tB_qtyq.Enabled = false;
                Q_sktt_gl_new_0.tB_qymc.Enabled = false;
                Q_sktt_gl_new_0.tB_tsyq.Enabled = false;
                Q_sktt_gl_new_0.tB_xydw.Enabled = false;
                Q_sktt_gl_new_0.tB_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.tB_hykh.Enabled = false;
                Q_sktt_gl_new_0.tB_fjbh.Enabled = false;
                Q_sktt_gl_new_0.tB_czy.Enabled = false;
                Q_sktt_gl_new_0.dT_ddsj_cs.Enabled = false;
                Q_sktt_gl_new_0.dT_ddsj_js.Enabled = false;
                Q_sktt_gl_new_0.dT_lksj_cs.Enabled = false;
                Q_sktt_gl_new_0.dT_lksj_js.Enabled = false;
                Q_sktt_gl_new_0.l_ddsj.Enabled = false;
                Q_sktt_gl_new_0.l_fjjg.Enabled = false;
                Q_sktt_gl_new_0.l_fjrb.Enabled = false;
                Q_sktt_gl_new_0.l_hykh.Enabled = false;
                Q_sktt_gl_new_0.l_krgj.Enabled = false;
                Q_sktt_gl_new_0.l_krly.Enabled = false;
                Q_sktt_gl_new_0.l_krsj.Enabled = false;
                Q_sktt_gl_new_0.l_lksj.Enabled = false;
                Q_sktt_gl_new_0.l_qtyq.Enabled = false;
                Q_sktt_gl_new_0.l_qymc.Enabled = false;
                Q_sktt_gl_new_0.l_tsyq.Enabled = false;
                Q_sktt_gl_new_0.l_xydw.Enabled = false;
                Q_sktt_gl_new_0.l_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.l_ydrxm.Enabled = false;
                Q_sktt_gl_new_0.l_fjbh.Enabled = false;
                Q_sktt_gl_new_0.l_czy.Enabled = false;
            }

        }



    }
}
