using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class FQ_yddj_select : Form
    {
        public DataSet DS_Qskyd;
        public int dg_count = 0;//记录初期加载行数
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        public FQ_yddj_select(string sql_condition_0)
        {
            InitializeComponent();
            refresh_app(sql_condition_0);
        }

        internal void refresh_app(string sql_condition_0)
        {
            common_file.common_app.get_czsj();
            this.dg_Qskyd.AutoGenerateColumns = false;
            DS_Qskyd = B_Common.GetList("select * from View_Qskzd", "id>=0" + sql_condition_0 + " order by id desc");
            bs_Qskyd.DataSource = DS_Qskyd.Tables[0];
            dg_count = DS_Qskyd.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void FQ_yddj_select_Load(object sender, EventArgs e)
        {
        }

        private void dg_Qskyd_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dg_Qskyd_DoubleClick(object sender, EventArgs e)
        {
            if (dg_Qskyd.CurrentRow != null)
            {
                int i = 0;
                DataRowView dgr = dg_Qskyd.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Qskyd.Tables[0].Rows.IndexOf(dgr.Row);
                if (dg_count > 0 && dg_Qskyd.CurrentRow.Index < dg_count && DS_Qskyd.Tables[0].Rows[i]["lsbh"].ToString() != "")
                {

                    common_file.common_form.Qskdj_new_open(DS_Qskyd.Tables[0].Rows[i]["id"].ToString(), DS_Qskyd.Tables[0].Rows[i]["yddj"].ToString(), common_file.common_app.get_edit, common_file.common_app.main_sec_main);
                    this.Close();
                }
            }
        }


    }
}