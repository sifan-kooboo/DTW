using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_gl : Form
    {
        public YH_gl(string _loadType)
        {
            InitializeComponent();
            load_type = _loadType;
        }

        string load_type = "";
        public string get_sel_cond = "";//最终获取的查询条件


        private void b_search_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }

        }

        private void gl()
        {
            string sel_cond = "";
            if (load_type == "yhczjl")
            {
                if (tB_bz.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and czbz like'%" + tB_bz.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_nr.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and cznr like'%" + tB_nr.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_zy.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and czzy like'%" + tB_zy.Text.Trim().Replace("'", "-") + "%'";

                }
                if (tB_czy.Text.Trim().Replace("'", "-") != "")
                {
                    sel_cond = sel_cond + " and czy like'%" + tB_czy.Text.Trim().Replace("'", "-") + "%'";

                }
                if (DateTime.Parse(dT_czsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) && DateTime.Parse(dT_czsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                {
                    sel_cond = sel_cond + " and (czsj between '" + dT_czsj_cs.Value.ToShortDateString() + "' and '" + dT_czsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }
            }

            if (sel_cond != "")
            {
                get_sel_cond = sel_cond;
            }
        }

        private void YH_gl_Load(object sender, EventArgs e)
        {
            dT_czsj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_czsj_js.Value = DateTime.Parse(common_file.common_app.cssj);
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dT_czsj_cs_Enter(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.Value = DateTime.Now;
        }
    }
}