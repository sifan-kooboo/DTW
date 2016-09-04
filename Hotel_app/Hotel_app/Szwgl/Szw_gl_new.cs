using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Hotel_app.Szwgl
{
    class Szw_gl_new
    {

        public Szw_gl Szw_gl_0;

        public void ResetControlStatus()
        {

            //tb
            Szw_gl_0.tB_syzd.Enabled = false;
            Szw_gl_0.tB_czy.Enabled = false;

            Szw_gl_0.tB_hykh.Enabled = false;
            Szw_gl_0.tB_krxm.Enabled = false;

            Szw_gl_0.tB_jzbh.Enabled = false;
            Szw_gl_0.tB_czzt.Enabled = false;

            Szw_gl_0.tB_krly.Enabled = false;
            Szw_gl_0.tB_jzdw.Enabled = false;

            Szw_gl_0.tB_fkfs.Enabled = false;
            Szw_gl_0.tB_czybc.Enabled = false;

            Szw_gl_0.dT_ddsj_cs.Enabled = false;
            Szw_gl_0.dT_ddsj_js.Enabled = false;

            Szw_gl_0.dT_lksj_cs.Enabled = false;
            Szw_gl_0.dT_lksj_js.Enabled = false;

            Szw_gl_0.tB_sk_tt.Enabled = false;
            Szw_gl_0.tB_fjbh.Enabled = false;

            Szw_gl_0.tB_fjjg_cs.Enabled = false;
            Szw_gl_0.tB_fjjg_js.Enabled = false;

            Szw_gl_0.tB_ydrxm.Enabled = false;
            Szw_gl_0.dT_czsj_cs.Enabled = false;
            Szw_gl_0.dT_czsj_js.Enabled = false;
            Szw_gl_0.tB_ydrxm.Enabled = false;
            Szw_gl_0.tB_hykh.Enabled = false;

            //lb

            Szw_gl_0.dT_ddsj_cs.Enabled = false;
            Szw_gl_0.dT_ddsj_js.Enabled = false;
            Szw_gl_0.dT_lksj_cs.Enabled = false;
            Szw_gl_0.dT_lksj_js.Enabled = false;
            Szw_gl_0.l_ddsj.Enabled = false;
            Szw_gl_0.l_fjjg.Enabled = false;
            Szw_gl_0.l_fjrb.Enabled = false;//sk_tt
            Szw_gl_0.l_fjbh.Enabled = false;
            Szw_gl_0.l_hykh.Enabled = false;
            Szw_gl_0.l_krgj.Enabled = false;//jzbh
            Szw_gl_0.l_krly.Enabled = false;
            Szw_gl_0.l_lksj.Enabled = false;
            Szw_gl_0.l_qtyq.Enabled = false;//fkfs
            Szw_gl_0.l_qymc.Enabled = false;//syzd
            Szw_gl_0.l_tsyq.Enabled = false;//czybc
            Szw_gl_0.l_xydw.Enabled = false;//jzdw
            Szw_gl_0.l_ydrxm.Enabled = false;
            Szw_gl_0.l_czy.Enabled = false;
            Szw_gl_0.l_krxm.Enabled = false;
            Szw_gl_0.l_jzzt.Enabled = false;
            Szw_gl_0.l_czsj.Enabled = false;
            Szw_gl_0.l_fjjg.Enabled = false;
            Szw_gl_0.l_ydrxm.Enabled = false;
        }


        public void change_control(String load_type)
        {
            ResetControlStatus();
            if (load_type == "Sjjzwll" )
            {
                Szw_gl_0.tB_syzd.Enabled = true;
                Szw_gl_0.tB_czy.Enabled = true;
                Szw_gl_0.tB_krxm.Enabled = true;
                Szw_gl_0.tB_jzbh.Enabled = true;
                Szw_gl_0.tB_krly.Enabled = true;
                Szw_gl_0.tB_jzdw.Enabled = true;
                Szw_gl_0.tB_fkfs.Enabled = true;
                Szw_gl_0.tB_sk_tt.Enabled = true;
                Szw_gl_0.tB_czzt.Enabled = true;
                Szw_gl_0.tB_fjbh.Enabled = true;
                Szw_gl_0.dT_ddsj_cs.Enabled = true;
                Szw_gl_0.dT_ddsj_js.Enabled = true;
                Szw_gl_0.tB_sk_tt.Enabled = true;
                Szw_gl_0.tB_fjbh.Enabled = true;

                Szw_gl_0.l_lksj.Enabled = true;
                Szw_gl_0.l_lksj.Text = "退房时间";
                Szw_gl_0.dT_lksj_cs.Enabled = true;
                Szw_gl_0.dT_lksj_js.Enabled = true;



                Szw_gl_0.dT_ddsj_cs.Enabled = true;
                Szw_gl_0.dT_ddsj_js.Enabled = true;
                Szw_gl_0.l_ddsj.Text = "到店时间";
                Szw_gl_0.l_ddsj.Enabled = true;
                Szw_gl_0.l_fjrb.Enabled = true;//sk_tt
                Szw_gl_0.l_fjbh.Enabled = true;
                Szw_gl_0.l_krly.Enabled = true;
                Szw_gl_0.l_qymc.Enabled = true;//syzd
                //Szw_gl_0.l_tsyq.Enabled = true;//czybc
                Szw_gl_0.l_xydw.Enabled = true;//jzdw
                Szw_gl_0.l_xydw.Text = "账务主体";
                Szw_gl_0.l_qtyq.Enabled = true;
                Szw_gl_0.l_qtyq.Text = "单位";
                Szw_gl_0.l_czy.Enabled = true;
                Szw_gl_0.l_krxm.Enabled = true;
                Szw_gl_0.l_jzzt.Enabled = true;
                Szw_gl_0.l_krgj.Enabled = true;
                Szw_gl_0.l_czsj.Enabled = true;
                Szw_gl_0.dT_czsj_cs.Enabled = true;
                Szw_gl_0.dT_czsj_js.Enabled = true;

            }

            if (load_type == "Syjll")
            {
                Szw_gl_0.l_tsyq.Text = "备注";
                Szw_gl_0.tB_syzd.Enabled = true;
                Szw_gl_0.tB_czy.Enabled = true;
                Szw_gl_0.tB_krxm.Enabled = true;
                Szw_gl_0.tB_czybc.Enabled = true;
                Szw_gl_0.tB_sk_tt.Enabled = true;
                Szw_gl_0.dT_ddsj_cs.Enabled = true;//这里显示为消费的初始时间
                Szw_gl_0.dT_ddsj_js.Enabled = true;
                Szw_gl_0.tB_fjbh.Enabled = true;
                Szw_gl_0.tB_fkfs.Enabled = true;
                Szw_gl_0.tB_jzbh.Enabled = true;

                Szw_gl_0.l_krgj.Enabled = true;//jzbh
                Szw_gl_0.dT_ddsj_cs.Enabled = true;
                Szw_gl_0.dT_ddsj_js.Enabled = true;
                Szw_gl_0.l_ddsj.Enabled = true;
                Szw_gl_0.l_fjrb.Enabled = true;//sk_tt
                Szw_gl_0.l_fjbh.Enabled = true;
                //Szw_gl_0.l_krly.Enabled = true;
                Szw_gl_0.l_qtyq.Enabled = true;//fkfs
                Szw_gl_0.l_qymc.Enabled = true;//syzd
                Szw_gl_0.l_tsyq.Enabled = true;//这个换成bz
               // Szw_gl_0.l_xydw.Enabled = true;//jzdw
                Szw_gl_0.l_czy.Enabled = true;
                Szw_gl_0.l_krxm.Enabled = true;
                //Szw_gl_0.l_jzzt.Enabled = true;




            }
            if (load_type == "Szzzwll")
            {
                Szw_gl_0.l_qtyq.Text = "消费项目";//fkfs--xfxm
                Szw_gl_0.l_fjrb.Text = "转账类型";
                Szw_gl_0.l_krgj.Text = "备注";
                Szw_gl_0.l_jzzt.Text = "摘要";
                //l_krgj     tB_jzbh
                Szw_gl_0.l_qtyq.Enabled = true;
                Szw_gl_0.l_fjrb.Enabled = true;
                Szw_gl_0.l_krgj.Enabled = true;
                Szw_gl_0.l_jzzt.Enabled = true;
                Szw_gl_0.l_krxm.Enabled = true;
                Szw_gl_0.l_fjbh.Enabled = true;
                Szw_gl_0.l_lksj.Enabled = true;
                Szw_gl_0.l_czy.Enabled = true;
                Szw_gl_0.tB_czzt.Enabled = true;
                Szw_gl_0.tB_fkfs.Enabled = true;
                Szw_gl_0.tB_czy.Enabled = true;//czy
                Szw_gl_0.tB_krxm.Enabled = true;
                Szw_gl_0.tB_sk_tt.Enabled = true;
                Szw_gl_0.dT_lksj_cs.Enabled = true;
                Szw_gl_0.dT_lksj_js.Enabled = true;
                Szw_gl_0.tB_fjbh.Enabled = true;
                Szw_gl_0.tB_jzbh.Enabled = true;
            }
        }
    }
}
