using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_syxffx_gl : Form
    {
        public Frm_BB_syxffx_gl()
        {
            InitializeComponent();
        }

        string sel_con = "";//生成查询条件
        public string second_selection = "";
        public string Time_begin = "";
        public string Time_end = "";
        public string loadType = "";
        private void gl()
        {
            //second_selection = "";
            if (dtp_cssj.Value > dtp_jssj.Value)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "初始时间不能大于结束时间,请正确选择过滤时间");
                return;
            }
            //if ( !dtp_cssj.Value.ToShortDateString().ToString("yyyy-mm-dd").Equals("1800-01-01") || !dtp_jssj.Value.ToShortDateString().Trim().Equals("1800-01-01"))
            if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dtp_jssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                second_selection += "  and  xfsj>='" + dtp_cssj.Value.ToShortDateString() + "'  and xfsj<='" + dtp_jssj.Value.ToShortDateString() + " 23:59:59  '";
                Time_begin = dtp_cssj.Value.ToShortDateString();
                Time_end = dtp_jssj.Value.ToShortDateString();
            }
            if (tb_fjbh.Text.Trim() != "")
            { second_selection += " and  fjbh  like '%" + tb_fjbh.Text.Trim().Replace("'", "-") + "%' "; }
            if (tb_krly.Text.Trim() != "")
            { second_selection += "  and  krly like '%" + tb_krly.Text.Trim().Replace("'", "-") + "%' "; }
            if (tb_krxm.Text.Trim() != "")
            { second_selection += "  and krxm like '%" + tb_krxm.Text.Trim().Replace("'", "-") + "%' "; }
            if (tb_sktt.Text.Trim() != "")
            { second_selection += "  and sktt like '%" + tb_sktt.Text.Trim().Replace("'", "-") + "%' "; }
            if (tb_xfbz.Text.Trim() != "")
            {
                second_selection += "  and xfbz like '%" + tb_xfbz.Text.Trim().Replace("'", "-") + "%' ";
            }
            if (tb_xfxm.Text.Trim() != "")
            {
                second_selection += "  and xfxm like '%" + tb_xfxm.Text.Trim().Replace("'", "-") + "%' ";
            }
            if (tb_xfzy.Text.Trim() != "")
            { second_selection += "  and xfzy like '%" + tb_xfzy.Text.Trim().Replace("'", "-") + "%' "; }
            if (tb_xsy.Text.Trim() != "")
            { second_selection += "  and xsy like '%" + tb_xsy.Text.Trim().Replace("'", "-") + "%' "; }
            if (tb_xydw.Text.Trim() != "")
            {
                second_selection += "  and xydw  like '%" + tb_xydw.Text.Trim().Replace("'", "-") + "%' ";
            }
            if (tB_xfdr.Text.Trim() != "")
            {
                second_selection += "  and  xfdr like '%" + tB_xfdr.Text.Trim().Replace("'", "-") + "%'";
            }
            if (tB_xfxr.Text.Trim() != "")
            {
                second_selection += "  and  xfrb like '%" + tB_xfxr.Text.Trim().Replace("'", "-") + "%'";
            }
            if (second_selection.Trim() != "")
            {
                this.DialogResult = DialogResult.OK; 
            }
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            sel_con = "";
        }

        private void Frm_BB_syxffx_gl_Load(object sender, EventArgs e)
        {
            dtp_cssj.Text = common_file.common_app.cssj;
            dtp_jssj.Text = common_file.common_app.cssj;
            if (loadType == "czOrbz")
            {
                tb_sktt.ReadOnly = true;
                tb_krly.ReadOnly = true;
                tb_xydw.ReadOnly = true;
                tB_xfdr.ReadOnly = true;
                tB_xfdr.Enabled = false;
                tb_xsy.ReadOnly = true;
                tb_sktt.Enabled = false;
                tb_krly.Enabled = false;
                tb_xydw.Enabled = false;
                tb_xsy.Enabled = false;

            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            gl();
        }

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            dtp_cssj.Value = DateTime.Now;
        }

        private void dtp_jssj_Enter(object sender, EventArgs e)
        {
            dtp_jssj.Value = DateTime.Now;
        }

    }
}