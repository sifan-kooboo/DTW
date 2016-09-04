using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Szw_gd_tj : Form
    {
        public Szw_gd_tj()
        {
            InitializeComponent();
        }
        public string filterstring = "";//获取显示的过滤条件
        public string getFilter = "";
        private void b_save_Click(object sender, EventArgs e)
        {
            if (tB_xfxm_new.Text.Trim() != "")
            {
                filterstring = "  xfxm like '%" + tB_xfxm_new.Text.Trim() + "%'";
            }
            if (!(dT_csxfsj_Date.Value==DateTime.Parse("1800-01-01"))||!(dT_jsxfsj_Date.Value==DateTime.Parse("1800-01-01"))||!(dT_csxfsj_Time.Value==DateTime.Parse("00:00:00"))||!(dT_jsxfsj_Time.Value==DateTime.Parse("00:00:00")))
            {
                DateTime  dt1=DateTime.Parse( dT_csxfsj_Date.Text.Trim()+" "+dT_csxfsj_Time.Text.Trim());
                DateTime  dt2=DateTime.Parse( dT_jsxfsj_Date.Text.Trim()+" "+dT_jsxfsj_Time.Text.Trim());
                if(filterstring.Trim()!="")
                {
                    filterstring += " and   xfsj>='" + dt1.ToString() + "' and xfsj<='" + dt2.ToString() + "'  ";
                }
                else
                {
                     filterstring= "   xfsj>='" + dt1.ToString() + "' and xfsj<='" + dt2.ToString() + "'  ";
                }
            }
            if (filterstring.Trim() != "")
            {
                getFilter = filterstring;
            }
            else
            {
                getFilter = "  1=1 ";
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Szw_gd_tj_Load(object sender, EventArgs e)
        {
            dT_csxfsj_Date.Text = "1800-01-01";
            dT_jsxfsj_Date.Text = "1800-01-01";
            dT_csxfsj_Time.Text = "00:00:00";
            dT_jsxfsj_Time.Text = "00:00:00";
        }

        private void dT_csxfsj_Date_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void dT_jsxfsj_Date_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}