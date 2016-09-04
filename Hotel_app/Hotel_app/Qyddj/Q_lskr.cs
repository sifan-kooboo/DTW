using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Hotel_app.Qyddj
{
    public partial class Q_lskr : Form
    {
        int dg_count = 0;
        DataSet DS_lskr;
        string select_s = "";
        string condition = "";
        public string sel_condition = "";
        BLL.Common B_Common = new Hotel_app.BLL.Common();

        public Q_lskr()
        {
            InitializeComponent();
            common_file.common_app.get_czsj();
            refresh_app(" and ddsj>'"+DateTime.Now.AddDays(-30).ToString()+"'");
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refresh_app(string sql_0)
        {
            select_s = "select * from VIEW_Q_skyd_lskr";
            dg_lskr.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sql_0 + sel_condition + "  order by czsj desc";
            DS_lskr = B_Common.GetList(select_s, condition);
            bS_lskr.DataSource = DS_lskr.Tables[0];
            dg_count = DS_lskr.Tables[0].Rows.Count;
        }

        private void b_krxh_Click(object sender, EventArgs e)
        {
            if (dg_count > 0 && dg_lskr.CurrentRow.Index < dg_count && DS_lskr != null && DS_lskr.Tables[0].Rows[dg_lskr.CurrentRow.Index]["id"].ToString() != "")
            {
                Qyddj.Qkrxh Qkrxh_new = new Qkrxh("sk", common_file.common_app.get_add, DS_lskr.Tables[0].Rows[dg_lskr.CurrentRow.Index]["krxm"].ToString(), DS_lskr.Tables[0].Rows[dg_lskr.CurrentRow.Index]["krsj"].ToString(), DS_lskr.Tables[0].Rows[dg_lskr.CurrentRow.Index]["hykh"].ToString(), DS_lskr.Tables[0].Rows[dg_lskr.CurrentRow.Index]["zjhm"].ToString());
                Qkrxh_new.Left = 150;
                Qkrxh_new.Top = 100;
                Qkrxh_new.ShowDialog();
            }
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            condition = "";
            sel_condition = "";
            refresh_app(" and ddsj>'" + DateTime.Now.AddDays(-30).ToString() + "'");
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bS_lskr.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bS_lskr.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bS_lskr.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bS_lskr.MoveLast();
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要删除所选择的历史客人！") == true)
            {
                for (int j = 0; j < dg_count; j++)
                {
                    common_file.common_app.get_czsj();
                    DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                    if (this.dg_lskr.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_lskr.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                    {
                        if (this.dg_lskr.Rows[j].Cells["id"].Value != null)
                        {
                            DataRowView dgr = dg_lskr.Rows[j].DataBoundItem as DataRowView;
                            j = DS_lskr.Tables[0].Rows.IndexOf(dgr.Row);


                            B_Common.ExecuteSql("delete from Qskyd_mainrecord_lskr where lsbh='" + DS_lskr.Tables[0].Rows[j]["lsbh"].ToString() + "'");
                            B_Common.ExecuteSql("delete from Qskyd_fjrb_lskr where lsbh='" + DS_lskr.Tables[0].Rows[j]["lsbh"].ToString() + "'");
                        }
                    }
                }
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            Qyddj.Q_sktt_gl Q_sktt_gl_new = new Q_sktt_gl("ls");
            Q_sktt_gl_new.Left = 130;
            Q_sktt_gl_new.Top = 70;
            if (Q_sktt_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_condition = sel_condition+Q_sktt_gl_new.get_sel_cond;
                if (Q_sktt_gl_new.get_sel_cond != "")
                {
                refresh_app("");
                }
            }

            Q_sktt_gl_new.Dispose();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Q_gl_jf Q_gl_jf_new = new Q_gl_jf();
            Q_gl_jf_new.StartPosition = FormStartPosition.CenterScreen;
            Q_gl_jf_new.ShowDialog();
        }

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_yddj_outport", common_file.common_app.user_type) == false)
            { return; }
            if (DS_lskr != null && DS_lskr.Tables[0].Rows.Count > 0)
            {
                string filePath = "";
                string fileName = "";
                string get_fileName = "";
                Hashtable nameList = new Hashtable();
                common_file.common_DataSetToExcel.ExportMX(DS_lskr, "skdj_lskr", "历史客人内容导出");
            }
        }
    }
}