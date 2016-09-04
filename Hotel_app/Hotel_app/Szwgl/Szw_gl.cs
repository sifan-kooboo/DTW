using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_gl : Form
    {


        string load_type = "";
        public string get_sel_cond = "";//最终获取的查询条件

        public Szw_gl(string load_type_0)
        {
            InitializeComponent();
            this.load_type = load_type_0;
            Szwgl.Szw_gl_new S_Szw_gl_new = new Szw_gl_new();
            S_Szw_gl_new.Szw_gl_0 = this;
            S_Szw_gl_new.change_control(load_type);
        }


        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void gl()
        {
            string sel_cond = "";
            sel_cond = " and  1=1 ";
            if (load_type == "Sjjzwll")
            {
                if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (ddsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }
                if (DateTime.Parse(dT_lksj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_lksj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (tfsj between '" + dT_lksj_cs.Value.ToShortDateString() + "' and '" + dT_lksj_cs.Value.ToShortDateString() + " 23:59:59" + "')";
                } 
                  
                if (DateTime.Parse(dT_czsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_czsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (czsj between '" + dT_czsj_cs.Value.ToShortDateString() + "' and '" + dT_czsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }
                //if (sel_cond != "")
                //{
                    if (tB_syzd.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and syzd like '%" + tB_syzd.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_czy.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and czy like '%" + tB_czy.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_krxm.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_jzbh.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and jzbh like'%" + tB_jzbh.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_krly.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and krly like'%" + tB_krly.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_jzdw.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and   jzzt like '%" + tB_jzdw.Text.Trim().Replace("'", "-") + "%'   ";
                    }
                    if (tB_fkfs.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + "  and    xydw like '%" + tB_fkfs.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_czybc.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and czy_bc like'%" + tB_czybc.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_czzt.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and czzt like'%" + tB_czzt.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_sk_tt.Text.Trim().Replace("'","-")!="")
                    {
                        sel_cond = sel_cond + "  and   sktt  like '%" + tB_sk_tt.Text.ToString().Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_fjbh.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + "  and fjbh like '%" + tB_fjbh.Text.Trim().Replace("'", "-") + "%'";
                    }

                //}
            }
            else if(load_type=="Szwcz")//一般不会用到
            {
                if (tB_syzd.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and syzd like'%" + tB_syzd.Text.Trim().Replace("'", "-") + "%'";
                }
                if (tB_hykh.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and hykh like'%" + tB_hykh.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_krxm.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_jzbh.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and krgj like'%" + tB_jzbh.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_krly.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and krly like'%" + tB_krly.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_jzdw.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and xydw like'%" + tB_jzdw.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_fkfs.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and qtyq like'%" + tB_fkfs.Text.Trim().Replace("'", "-") + "%'";

                }

                if (tB_czybc.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and tsyq like'%" + tB_czybc.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_sk_tt.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and fjrb like'%" + tB_sk_tt.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_fjbh.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and fjbh like'%" + tB_fjbh.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_ydrxm.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and ydrxm like'%" + tB_ydrxm.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_czy.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and czy like'%" + tB_czy.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_fjjg_cs.Text.Trim().Replace("'", "-") != "" && tB_fjjg_js.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and (fjjg between '" + tB_fjjg_cs.Text.Trim().Replace("'", "-") + "' and '" + tB_fjjg_js.Text.Trim().Replace("'", "-") + "')";

                }
                if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (ddsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }
                if (DateTime.Parse(dT_lksj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dT_lksj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (lksj between '" + dT_lksj_cs.Value.ToShortDateString() + "' and '" + dT_lksj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }
                if (DateTime.Parse(dT_czsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dT_czsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (czsj between '" + dT_czsj_cs.Value.ToShortDateString() + "' and '" + dT_czsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }
            }
            if (load_type =="Syjll")
            {
                //if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj))
                //{
                //    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先选择好消费时间！"); return;
                //}
                //else
                //{
                //    sel_cond = sel_cond + " and (xfsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                //}
                if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (xfsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }

               // if (sel_cond != "")
                //{
                    if (tB_syzd.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and syzd like '%" + tB_syzd.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_czy.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and czy like '%" + tB_czy.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_krxm.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_fkfs.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and fkfs like'%" + tB_fkfs.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_fjbh.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and fjbh like'%" + tB_fjbh.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_czybc.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + "  and  xfbz like '%" + tB_czybc.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_jzbh.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and  jzbh like '%" + tB_jzbh.Text.Trim().Replace("'", "-") + "%'";
                    }
                //}

            }
            if (load_type == "Szzzwll")
            {
                if (DateTime.Parse(dT_lksj_cs.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_lksj_js.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj))
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先选择好转账时间！");
                    dT_lksj_cs.Focus();
                    return;
                }
                else
                {
                    sel_cond = sel_cond + " and (czsj between '" + dT_lksj_cs.Value.ToShortDateString() + "' and '" + dT_lksj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }

                if (sel_cond != "")
                {
                    if (tB_czy.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and czy like '%" + tB_czy.Text.Trim().Replace("'", "-") + "%'";
                    }

                    if (tB_krxm.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and  (  old_krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%'  or    new_krxm like '%" + tB_krxm.Text.Trim().Replace("'", "-") + "%' )   ";
                    }
                    if (tB_fkfs.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and xfxm like'%" + tB_fkfs.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_fjbh.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + " and  (   old_fjbh like'%" + tB_fjbh.Text.Trim().Replace("'", "-") + "%'   or  new_fjbh like '% " + tB_fjbh.Text.Trim().Replace("'", "-") + "%' )  ";
                    }
                    if (tB_jzbh.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + "  and  xfbz like '%" + tB_jzbh.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_czzt.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + "  and  xfzy like '%" + tB_czzt.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tB_sk_tt.Text.Trim().Replace("'", "-") != "")
                    {
                        sel_cond = sel_cond + "  and zzrx like '%" + tB_sk_tt.Text.Trim().Replace("'", "-") + "%'";
                    }
                }

            }
            if (sel_cond != "")
            {
                get_sel_cond = sel_cond;
            }
        }
        private void b_search_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Szw_gl_Load(object sender, EventArgs e)
        {
            dT_ddsj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_ddsj_js.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_lksj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_lksj_js.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_czsj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_czsj_js.Value = DateTime.Parse(common_file.common_app.cssj);
            this.AcceptButton = b_search;
            this.CancelButton = b_exit;
        }

        private void tB_fjjg_cs_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void tB_fjjg_js_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void dT_ddsj_cs_Enter(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.Value = DateTime.Now;
        }
    }
}