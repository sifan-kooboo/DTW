using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.Szwgl
{
   public static class common_form
    {


       public static Syjll Syjll_new;
       public static void Syjll_new_open()
        {
            if (Syjll_new == null || Syjll_new.IsDisposed)
            {
                Syjll_new = new Hotel_app.Szwgl.Syjll();
                Syjll_new.MdiParent =common_file.common_form.Fmain_new;
                Syjll_new.Show();
            }
            Syjll_new.Activate();
        }

       public static Szzzwll Szzzwll_new;
       public static void Szzzwll_new_open()
        {
            if (Szzzwll_new == null || Szzzwll_new.IsDisposed)
            {
                Szzzwll_new = new Hotel_app.Szwgl.Szzzwll();
                Szzzwll_new.MdiParent = common_file.common_form.Fmain_new;
                Szzzwll_new.Show();
            }
            Szzzwll_new.Activate();
        }



       public static S_jbzd_ll S_jbzd_ll_new;
       public static void S_jbzd_ll_new_open()
        {
            if (S_jbzd_ll_new == null || S_jbzd_ll_new.IsDisposed)
            {
                S_jbzd_ll_new = new Hotel_app.Szwgl.S_jbzd_ll();
                S_jbzd_ll_new.MdiParent = common_file.common_form.Fmain_new;
                S_jbzd_ll_new.Show();
            }
            S_jbzd_ll_new.Activate();
        }

       public static S_jkzd_ll S_jkzd_ll_new;
       public static void S_jkzd_ll_new_open()
        {
            if (S_jkzd_ll_new == null || S_jkzd_ll_new.IsDisposed)
            {
                S_jkzd_ll_new = new Hotel_app.Szwgl.S_jkzd_ll();
                S_jkzd_ll_new.MdiParent = common_file.common_form.Fmain_new;
                S_jkzd_ll_new.Show();
            }
            S_jkzd_ll_new.Activate();
        }


    }
}
