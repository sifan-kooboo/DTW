using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xyh_select : Form
    {
        public BLL.YHuser_yhbl B_XYHuser_yhbl = new Hotel_app.BLL.YHuser_yhbl();
        public DataSet DS_YHuser_yhbl;

        public int dg_count = 0;
        public string get_yh = "";
        public string get_yhbl = "";

        public void InitializeApp(string sel_condition)
        {
            DS_YHuser_yhbl = B_XYHuser_yhbl.GetList(sel_condition);
            bindingSource1.DataSource = DS_YHuser_yhbl.Tables[0];
            dg_count = DS_YHuser_yhbl.Tables[0].Rows.Count;
            this.dg_yhbl.AutoGenerateColumns = false;
        }

        public Xyh_select()
        {
            InitializeComponent();
            InitializeApp("id>=0  and  yydh='" + common_file.common_app.yydh+"'  and   user_type='"+common_file.common_app.user_type+ "'  order by yh");
        }

        private void dg_yhbl_DoubleClick(object sender, EventArgs e)
        {
            if (dg_yhbl.CurrentRow != null)
            {
                int i = dg_yhbl.CurrentRow.Index;


                DataRowView dgr = dg_yhbl.Rows[i].DataBoundItem as DataRowView;
                i = DS_YHuser_yhbl.Tables[0].Rows.IndexOf(dgr.Row);

                if (dg_count > 0 && dg_yhbl.CurrentRow.Index < dg_count && DS_YHuser_yhbl.Tables[0].Rows[i]["yh"].ToString() != "")
                {
                    get_yh = DS_YHuser_yhbl.Tables[0].Rows[i]["yh"].ToString();
                    get_yhbl = DS_YHuser_yhbl.Tables[0].Rows[i]["yhbl"].ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}