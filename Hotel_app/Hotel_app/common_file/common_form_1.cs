using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Hotel_app.common_file
{
     public  class common_form_1
    {
        public static Fmain Fmain_new_1;







        #region    营销中心


         //会员管理
         public static Hhygl.Hhygl_browse Hhygl_browse_new;
         public static void Hhygl_new_open(Fmain MdiFmain)
         {
             if (Hhygl_browse_new == null || Hhygl_browse_new.IsDisposed)
             {
                 Hhygl_browse_new = new Hotel_app.Hhygl.Hhygl_browse(MdiFmain);
                 Hhygl_browse_new.MdiParent = MdiFmain;
                 Hhygl_browse_new.Show();
             }
             Hhygl_browse_new.Activate();
             Hhygl_browse_new.Show();
         }

        //会员级别管理
         public static Hhygl.Hhyjb_browse Hhyjb_browse_new;
         public static void Hhyjb_new_open()
         {
             Hhyjb_browse_new = new Hotel_app.Hhygl.Hhyjb_browse();
             Hhyjb_browse_new.Left = 200;
             Hhyjb_browse_new.Top = 150;
             Hhyjb_browse_new.ShowDialog();
         }


         //会员积分比例管理
         public static Hhygl.Hhyjf_bl_browse Hhyjfbl_browse_new;
         public static void Hhyjfbl_new_open()
         {
             Hhyjfbl_browse_new = new Hotel_app.Hhygl.Hhyjf_bl_browse();
             Hhyjfbl_browse_new.Left = 200;
             Hhyjfbl_browse_new.Top = 150;
             Hhyjfbl_browse_new.ShowDialog();
         }

        #endregion






         #region  系统设置

         //国籍管理
         public static Xxtsz.Xkrgj_browse Xkrgj_browse_new;
         public static void Xkrgj_new_open()
         {
             Xkrgj_browse_new = new Hotel_app.Xxtsz.Xkrgj_browse();
             Xkrgj_browse_new.Left = 200;
             Xkrgj_browse_new.Top = 150;
             Xkrgj_browse_new.ShowDialog();

 
         }
         //消费大类
         public static Xxtsz.Xxfdr_browse Xxfdr_browse_new;
         public static void Xxfdr_new_open()
         {
             Xxfdr_browse_new = new Hotel_app.Xxtsz.Xxfdr_browse();
             Xxfdr_browse_new.Left = 200;
             Xxfdr_browse_new.Top = 150;
             Xxfdr_browse_new.ShowDialog();

         }
         #endregion


     }
}
