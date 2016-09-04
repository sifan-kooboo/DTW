using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xckcx_browse : Form
    {
        public Xckcx_browse()
        {
            InitializeComponent();
            InitializeApp(true,"", "");
        }
        BLL.Common B_common = new Hotel_app.BLL.Common();
        DataSet ds_0 = null;
        string other_cond = "";
        private void InitializeApp(bool isLoad,string  sql_0,string sql_refresh)
        {
            dg_ckmx.AutoGenerateColumns = false; dg_ckmx.ScrollBars = ScrollBars.Both;
            string sql_con = " id>=0  ";
            if (isLoad)
            {
                 sql_con += "   and   xfsj>='" + DateTime.Now.AddDays(-30) + "'  ";
            }
            else
            {
                if (sql_0.Trim() != "")
                {
                    sql_con += sql_0;
                }
                if (sql_refresh.Trim() != "")
                {
                    sql_con += sql_refresh;
                }
            }
            sql_0 += "  order by id desc  ";
            ds_0 = B_common.GetList("select  * from VIEW_S_KC ", sql_con);
            bindingSource_ckmx.DataSource = ds_0.Tables[0].DefaultView;
            dg_ckmx.DataSource = bindingSource_ckmx;
        }


        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void move(string MoveType)
        {
            if (MoveType == "first")
            {
                this.bindingSource_ckmx.MoveFirst();
            }
            if (MoveType == "next")
            {
                this.bindingSource_ckmx.MoveNext();
            }
            if (MoveType == "pre")
            {
                this.bindingSource_ckmx.MovePrevious();

            }
            if (MoveType == "last")
            {
                this.bindingSource_ckmx.MoveLast();
            }
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            move("first");
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            move("pre");
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            move("next");
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            move("last");
        }

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("M_ckmxcx", common_file.common_app.user_type) == false)
            { return; }
            common_file.common_DataSetToExcel.ExportMX(ds_0, "Xckcx", "³ö¿âÃ÷Ï¸");
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            Xckcx_gl Frm_Xckcx_gl = new Xckcx_gl();
            Frm_Xckcx_gl.StartPosition = FormStartPosition.CenterScreen;
            if (Frm_Xckcx_gl.ShowDialog() == DialogResult.OK)
            {
                this.other_cond = Frm_Xckcx_gl.second_selection;
                //ds_0.Tables[0].DefaultView.RowFilter = other_cond;
                //dg_ckmx.AutoGenerateColumns = false;
                InitializeApp(false, other_cond, "");
          }
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            
            InitializeApp(true,"", "");
        }
    }
}