using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_sktt_gl : Form
    {
        string load_type = "";
        public string  get_sel_cond="";//最终获取的查询条件

        public Q_sktt_gl(string load_type_0)
        {
            InitializeComponent();
            load_type = load_type_0;
            Qyddj.Q_sktt_gl_new Q_sktt_gl_new_new = new Q_sktt_gl_new();
            Q_sktt_gl_new_new.Q_sktt_gl_new_0 = this;
            Q_sktt_gl_new_new.change_control(load_type);
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gl()
        {
            string sel_cond = "";
            if (load_type == "lscz_sk" || load_type == "lscz_tt")
            {
                string sel_czsj = "";
                if (DateTime.Parse(dT_czsj_cs.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_czsj_js.Value.ToShortDateString()) == DateTime.Parse(common_file.common_app.cssj))
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title,"请先选择好操作时间！");

                }
                else
                {
                    
                    sel_czsj  = " and (czsj between '" + dT_czsj_cs.Value.ToShortDateString() + "' and '" + dT_czsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    
                }
                if (sel_czsj != "")
                {
                    if (load_type == "lscz_sk")
                    {
                        sel_cond = " and lsbh in (select lsbh Qskyd_mainrecord_temp where id>=0 " + sel_czsj + ")";
                        if (tB_krxm.Text.Trim().Replace("'", "-") != "")
                        {
                            sel_cond = " and lsbh in (select lsbh from Qskyd_mainrecord_temp where (krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%' " + sel_czsj + "))";

                        }

                        if (tB_fjbh.Text.Trim().Replace("'", "-") != "")
                        {
                            sel_cond = sel_cond + " and lsbh in (select lsbh from Qskyd_fjrb_teno where (fjbh like'%" + tB_fjbh.Text.Trim().Replace("'", "-") + "%' " + sel_czsj + "))";

                        }
                    }

                    if (load_type == "lscz_tt")
                    {
                        sel_cond = " and lsbh in (select lsbh Qttyd_mainrecord_temp where id>=0 " + sel_czsj + ")";
                        if (tB_krxm.Text.Trim().Replace("'", "-") != "")
                        {
                            sel_cond = sel_cond + " and lsbh in (select lsbh from Qttyd_mainrecord_temp where (krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%' " + sel_czsj + "))";

                        }
                    }
                }

            }
            else 
            {
                if (tB_qymc.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and qymc like'%" + tB_qymc.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_hykh.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and hykh like'%" + tB_hykh.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_krxm.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and krxm like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_krgj.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and krgj like'%" + tB_krgj.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_krsj.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and krsj like'%" + tB_krsj.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_krly.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and krly like'%" + tB_krly.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_xydw.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and xydw like'%" + tB_xydw.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_qtyq.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and qtyq like'%" + tB_qtyq.Text.Trim().Replace("'", "-") + "%'";

                }

                if (tB_tsyq.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and tsyq like'%" + tB_tsyq.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_fjrb.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and fjrb like'%" + tB_fjrb.Text.Trim().Replace("'", "-") + "%'";

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
            if (tb_xsy.Text.Trim() != "")
            {
                sel_cond = sel_cond + " and xsy like'%" + tb_xsy.Text.Trim().Replace("'", "-") + "%'";
            }
            if (sel_cond != "")
            {
                get_sel_cond = sel_cond;
            }
            
        }



        private void Q_sktt_gl_Load(object sender, EventArgs e)
        {
            dT_ddsj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_ddsj_js.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_lksj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_lksj_js.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_czsj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_czsj_js.Value = DateTime.Parse(common_file.common_app.cssj);
            this.AcceptButton = b_amend;
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

        private void b_amend_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void dT_ddsj_cs_Enter(object sender, EventArgs e)
        {
            //dT_ddsj_cs.Value = DateTime.Now;
            //dT_lksj_cs.Text = DateTime.Now.ToString();
            //dT_lksj_js.Text = DateTime.Now.ToString();
            //dT_czsj_cs.Text = DateTime.Now.ToString();
            //dT_czsj_js.Text = DateTime.Now.ToString();
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.Value = DateTime.Now;
        }
    }
}