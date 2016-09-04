using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public static class common_form
    {
        public static Fmain Fmain_new;
        //散客
        public static Qyddj.Qskdj Qskdj_new;
        public static void Qskdj_new_open(string id, string yddj, string add_edit_delete,string main_sec)
        {
            if (Qskdj_new == null || Qskdj_new.IsDisposed)
            {
                Qskdj_new = new Hotel_app.Qyddj.Qskdj();
                Qskdj_new.MdiParent = Fmain_new;
                Qskdj_new.Text = "新增散客" + yddj;
                Qskdj_new.Show();
            }
            
            if (yddj != common_file.common_app.get_his)
            {
                if (id != "")
                {
                    Qskdj_new.Qskdj_1(int.Parse(id), yddj, add_edit_delete);
                }
                else
                {
                    Qskdj_new.Qskdj_2(yddj, add_edit_delete);
                }
            }
            else
            {
                Qskdj_new.Qskdj_open_his(id, yddj);
            }
            Qskdj_new.Activate();
        }


        public static Qyddj.Qskdj_browse Qskdj_browse_new;
        public static void Qskdj_browse_new_open(string yddj)
        {
            if (Qskdj_browse_new == null || Qskdj_browse_new.IsDisposed)
            {
                Qskdj_browse_new = new Hotel_app.Qyddj.Qskdj_browse();
                Qskdj_browse_new.MdiParent = Fmain_new;
                Qskdj_browse_new.Show();
            }
            Qskdj_browse_new.Activate();
            Qskdj_browse_new.Qskdj_browse_1(yddj, Fmain_new, common_file.common_app.main_sec_main);
        }

        //团体
        public static Qyddj.Qttdj Qttdj_new;
        public static void Qttdj_new_open(string id, string yddj, string add_edit_delete, bool is_refresh)
        {
            if (Qttdj_new == null || Qttdj_new.IsDisposed)
            {
                Qttdj_new = new Hotel_app.Qyddj.Qttdj();
                Qttdj_new.MdiParent = Fmain_new;
                Qttdj_new.Show();
            }

            if (add_edit_delete != common_app.get_his)
            {
                Qttdj_new.loadInfo(id, yddj, add_edit_delete, Fmain_new);
                if (is_refresh == true)
                {
                    Qttdj_new.RefreshApp();
                    if (Qttdj_new.Ds_fjfx != null && Qttdj_new.Ds_fjfx.Tables[0].Rows.Count > 0 && add_edit_delete == common_file.common_app.get_edit && yddj == common_file.common_yddj.yddj_dj)
                    {
                        Qttdj_new.GetFxfj_tj();
                        for (int i = 0; i < Qttdj_new.Ds_fjfx.Tables[0].Rows.Count; i++)
                        {
                            if (float.Parse(Qttdj_new.Ds_fjfx.Tables[0].Rows[i]["lzfs"].ToString()) - 1 >= 0 && Qttdj_new.Ds_fjfx.Tables[0].Rows[i]["fjrb"].ToString().Trim() != "")
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前存在没有排完房的记录！如果确认不再排房请把入住房数修改为0，否则将引起分析预计占用房数和预计总房费的出错！"); break;
                            }
                        }

                    }


                }
            }
            else
            {
                Qttdj_new.open_his(id, add_edit_delete);
            }
            
            Qttdj_new.Activate();
        }

        public static Qyddj.Qttdj_browse Qttdj_browse_new;
        public static void Qttdj_browse_new_open(string yddj)
        {
            if (Qttdj_browse_new == null || Qttdj_browse_new.IsDisposed)
            {
                Qttdj_browse_new = new Hotel_app.Qyddj.Qttdj_browse();
                Qttdj_browse_new.MdiParent = Fmain_new;
                Qttdj_browse_new.Show();
            }
            Qttdj_browse_new.Activate();
            Qttdj_browse_new.loadInfo(yddj, Fmain_new);
        }

        public static Qyddj.Q_lskr Q_lskr_new;
        public static void Q_lskr_new_open()
        {
            if (Q_lskr_new == null || Q_lskr_new.IsDisposed)
            {
                Q_lskr_new = new Hotel_app.Qyddj.Q_lskr();
                Q_lskr_new.MdiParent = Fmain_new;
                Q_lskr_new.Show();
            }
            Q_lskr_new.Activate();
        }


        public static Qyddj.Q_czjl_ls Q_czjl_ls_new;
        public static void Q_czjl_ls_new_open()
        {
            if (Q_czjl_ls_new == null || Q_czjl_ls_new.IsDisposed)
            {
                Q_czjl_ls_new = new Hotel_app.Qyddj.Q_czjl_ls();
                Q_czjl_ls_new.MdiParent = Fmain_new;
                Q_czjl_ls_new.Show();
            }
            Q_czjl_ls_new.Activate();
        }


        //散客取消
        public static Qyddj.Qskyd_qx Qskyd_qx_new;
        public static void Qskyd_qx_new_open()
        {
            if (Qskyd_qx_new == null || Qskyd_qx_new.IsDisposed)
            {
                Qskyd_qx_new = new Hotel_app.Qyddj.Qskyd_qx();
                Qskyd_qx_new.MdiParent = Fmain_new;
                Qskyd_qx_new.Show();
            }
            Qskyd_qx_new.Activate();
        }

        //团队取消
        public static Qyddj.Qttyd_qx Qttyd_qx_new;
        public static void Qttyd_qx_new_open()
        {
            if (Qttyd_qx_new == null || Qttyd_qx_new.IsDisposed)
            {
                Qttyd_qx_new = new Hotel_app.Qyddj.Qttyd_qx();
                Qttyd_qx_new.MdiParent = Fmain_new;
                Qttyd_qx_new.Show();
            }
            Qttyd_qx_new.Activate();
        }






        //帐务处理
        public static Szwgl.Szwcl Szwcl_new;
        public static Szwgl.Sjjzwll Sjjzwll_new;//账务浏览
        public static Szwgl.Szw_Common_check Szw_Common_check_new; //结\记\挂账处理
        public static Szwgl.Szwcz Szwcz_new;//帐务操作
        public static Szwgl.Sfjcz Sfjcz_new;//转帐、分结

        public static void ShowFrm_Szwcz_new(string jzzt, string lsbh, string jzbh, string sk_tt, string OpenFrom)
        {
            if (common_file.common_form.Szwcz_new == null || common_file.common_form.Szwcz_new.IsDisposed)
            {
                common_file.common_form.Szwcz_new = new Hotel_app.Szwgl.Szwcz();
                common_file.common_form.Szwcz_new.StartPosition = FormStartPosition.CenterScreen;
                common_file.common_form.Szwcz_new.Show();
            }
            common_file.common_form.Szwcz_new.Activate();
            // common_file.common_form.Szwcz_new.InitalApp(common_file.common_jzzt.czzt_gz, this.lsbh, sk_tt);
            common_file.common_form.Szwcz_new.InitalApp(jzzt, lsbh, jzbh, sk_tt, OpenFrom);
        }

        public static void ShowFrm_Szwcl_new(string lsbh, string sk_tt, string czy,bool is_his)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_form.Szwcl_new == null || common_file.common_form.Szwcl_new.IsDisposed)
            {
                common_file.common_app.get_czsj();
                common_file.common_form.Szwcl_new = new Hotel_app.Szwgl.Szwcl(lsbh, sk_tt, is_his);
                common_file.common_form.Szwcl_new.MdiParent = Fmain_new;
                common_file.common_form.Szwcl_new.Show();
            }
            common_file.common_form.Szwcl_new.Activate();
            common_file.common_form.Szwcl_new.Inital_app(lsbh, sk_tt,is_his, czy);
            common_file.common_form.Szwcl_new.BindData(lsbh, czy);
            Cursor.Current = Cursors.Default;
        }

        public static void ShowFrm_Sjjzwll_new(string jjType)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_form.Sjjzwll_new == null || common_file.common_form.Sjjzwll_new.IsDisposed)
            {
                common_file.common_app.get_czsj();
                common_file.common_form.Sjjzwll_new = new Hotel_app.Szwgl.Sjjzwll();
                common_file.common_form.Sjjzwll_new.MdiParent = Fmain_new;
                common_file.common_form.Sjjzwll_new.Show();
            }
            common_file.common_form.Sjjzwll_new.Activate();
            common_file.common_form.Sjjzwll_new.Inital_app(jjType);
            //common_file.common_form.Sjjzwll_new.BindData();
            Cursor.Current = Cursors.Default;
        }

        public static void ShowFrm_Szw_Common_check_new(string jzzt, string lsbh, string sk_tt)
        {
            if (common_file.common_form.Szw_Common_check_new == null || common_file.common_form.Szw_Common_check_new.IsDisposed)
            {
                common_file.common_form.Szw_Common_check_new = new Hotel_app.Szwgl.Szw_Common_check();
                common_file.common_form.Szw_Common_check_new.StartPosition = FormStartPosition.CenterScreen;
                common_file.common_form.Szw_Common_check_new.Show();
            }
            common_file.common_form.Szw_Common_check_new.Activate();
            common_file.common_form.Szw_Common_check_new.InitalApp(jzzt, lsbh, sk_tt);
        }



        public static void ShowFrm_Sfjcz_new(string jzzt, string lsbh, string sk_tt,string jzbh)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_form.Sfjcz_new == null || common_file.common_form.Sfjcz_new.IsDisposed)
            {
                common_file.common_form.Sfjcz_new = new Hotel_app.Szwgl.Sfjcz();
                common_file.common_form.Sfjcz_new.MdiParent = Fmain_new;
                common_file.common_form.Sfjcz_new.Show();
            }
            common_file.common_form.Sfjcz_new.Activate();
            common_file.common_app.get_czsj();
            common_file.common_form.Sfjcz_new.InitalApp(jzzt, lsbh, sk_tt,jzbh);
        }


        public static Yyxzx.Yxydw_browse Yxydw_browse_new;
        public static void Yxydw_browse_new_open(string xygz)
        {
            if (Yxydw_browse_new == null || Yxydw_browse_new.IsDisposed)
            {
                Yxydw_browse_new = new Hotel_app.Yyxzx.Yxydw_browse();
                Yxydw_browse_new.MdiParent = Fmain_new;
                Yxydw_browse_new.Show();
            }
            Yxydw_browse_new.Activate();
            Yxydw_browse_new.Yxydw_browse_1(xygz, Fmain_new);
        }

        //入库主单
        public static Xxtsz.Xxfmx_lkzd_browse Xxfmx_lkzd_browse_new;
        public static void Xxfmx_lkzd_browse_new_open()
        {
            if (Xxfmx_lkzd_browse_new == null || Xxfmx_lkzd_browse_new.IsDisposed)
            {
                Xxfmx_lkzd_browse_new = new Hotel_app.Xxtsz.Xxfmx_lkzd_browse();
                Xxfmx_lkzd_browse_new.MdiParent = Fmain_new;
                Xxfmx_lkzd_browse_new.Show();
            }
            Xxfmx_lkzd_browse_new.Activate();
        }


        //系统处理
        public static Xxtsz.Xxfmx_browse Xxfmx_browse_new;
        //public static Yyxzx.Yxydw_browse Yxydw_browse_new;
        //public static Yyxzx.Ygzdw_browse Ygzdw_browse_new;

        public static Yhgl.YH_czjl Yh_czjl_new;
        public static void Yh_czjl_new_open()
        {
            if (Yh_czjl_new == null || Yh_czjl_new.IsDisposed)
            {
                Yh_czjl_new = new Hotel_app.Yhgl.YH_czjl();
                Yh_czjl_new.MdiParent = Fmain_new;
                Yh_czjl_new.Show();
            }
            else
            {
                Yh_czjl_new.Activate();
                Yh_czjl_new.refresh_app("");
            }
        }


        public static Xxtsz.Xckcx_browse Xckcx_browse_new;
        internal static void Frm_Xxtsz_ckmxcx_new_open()
        {
            if (Xckcx_browse_new == null || Xckcx_browse_new.IsDisposed)
            {
                Xckcx_browse_new = new Hotel_app.Xxtsz.Xckcx_browse();
                Xckcx_browse_new.MdiParent = Fmain_new;
                Xckcx_browse_new.Show();
            }
            Xckcx_browse_new.Activate();
        }



        public static Xxtsz.Xxfmx_zbzd_browse Xxfmx_zbzd_browse_new;
        internal static void Xxfmx_zbzd_browse_new_open()
        {
            if (Xxfmx_zbzd_browse_new == null || Xxfmx_zbzd_browse_new.IsDisposed)
            {
                Xxfmx_zbzd_browse_new = new Hotel_app.Xxtsz.Xxfmx_zbzd_browse();
                Xxfmx_zbzd_browse_new.MdiParent = Fmain_new;
                Xxfmx_zbzd_browse_new.Show();
            }
            Xxfmx_zbzd_browse_new.Activate();
        }
    }
}
