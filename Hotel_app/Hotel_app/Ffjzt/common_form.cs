using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.Ffjzt
{
    public static class common_form
    {

        //房态

        public static Ffjzt.Ffjzt_pic_big Ffjzt_pic_big_new;
        public static void Ffjzt_pic_big_new_open()
        {
            if (Ffjzt_pic_big_new == null || Ffjzt_pic_big_new.IsDisposed)
            {
                Ffjzt_pic_big_new = new Hotel_app.Ffjzt.Ffjzt_pic_big();
                Ffjzt_pic_big_new.MdiParent =common_file.common_form .Fmain_new;
                Ffjzt_pic_big_new.Show();
            }
            Ffjzt_pic_big_new.Activate();
            Ffjzt_pic_big_new.Show();
        }

        /// <summary>
        /// 房间查询
        /// </summary>
        public static Ffjzt.Ffjzt_browse Ffjzt_browse_new;
        public static void Ffjzt_browse_new_open()
        {
            if (Ffjzt_browse_new == null || Ffjzt_browse_new.IsDisposed)
            {
                Ffjzt_browse_new = new Hotel_app.Ffjzt.Ffjzt_browse();
                Ffjzt_browse_new.MdiParent = common_file.common_form.Fmain_new;
                Ffjzt_browse_new.Show();
            }
            Ffjzt_browse_new.Activate();
            Ffjzt_browse_new.Show();

        }

        /// <summary>
        /// 房态分析
        /// </summary>
        public static Ffjzt.Fftfx Fftfx_new;
        public static void Fftfx_new_open()
        {
            if (Fftfx_new == null || Fftfx_new.IsDisposed)
            {
                Fftfx_new = new Hotel_app.Ffjzt.Fftfx();
                Fftfx_new.MdiParent = common_file.common_form.Fmain_new;
                Fftfx_new.Show();
            }
            Fftfx_new.Activate();
            Fftfx_new.Show();

        }


        /// <summary>
        /// 入住来源分析
        /// </summary>
        public static Ffjzt.Fkfxsfx_app Fkfxsfx_app_new;
        public static void Fkfxsfx_app_new_open()
        {
            if (Fkfxsfx_app_new == null || Fkfxsfx_app_new.IsDisposed)
            {
                Fkfxsfx_app_new = new Hotel_app.Ffjzt.Fkfxsfx_app();
                Fkfxsfx_app_new.MdiParent = common_file.common_form.Fmain_new;
                Fkfxsfx_app_new.Show();
            }
            Fkfxsfx_app_new.Activate();
            Fkfxsfx_app_new.Show();

        }



    }
}
