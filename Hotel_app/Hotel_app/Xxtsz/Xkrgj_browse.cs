using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xkrgj_browse: Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xkrgj B_Xkrgj = new Hotel_app.BLL.Xkrgj();
        public DataSet DS_Xkrgj;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xkrgj = B_Xkrgj.GetList("id>=0" + common_file.common_app.yydh_select + " order by krgj");
            bindingSource1.DataSource = DS_Xkrgj.Tables[0];
            dg_count = DS_Xkrgj.Tables[0].Rows.Count;
            this.dg_krgj.AutoGenerateColumns = false;
        }
        #endregion

        public Xkrgj_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xkrgj = B_Xkrgj.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xkrgj.Tables[0];
            dg_count = DS_Xkrgj.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_krgj.CurrentRow != null)
            {
                int i = dg_krgj.CurrentRow.Index;
                DataRowView dgr = dg_krgj.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xkrgj.Tables[0].Rows.IndexOf(dgr.Row);
                if (DS_Xkrgj.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xkrgj_add_edit Xkrgj_add_edit_new = new Xkrgj_add_edit(this);
                    Xkrgj_add_edit_new.Left = common_file.common_app.x() - 200;
                    Xkrgj_add_edit_new.Top = common_file.common_app.y() - 100;
                    Xkrgj_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xkrgj_add_edit_new.Xkrgj_id = DS_Xkrgj.Tables[0].Rows[i]["id"].ToString();
                    Xkrgj_add_edit_new.tB_krgj.Text = DS_Xkrgj.Tables[0].Rows[i]["krgj"].ToString();
                    Xkrgj_add_edit_new.tB_zjm.Text = DS_Xkrgj.Tables[0].Rows[i]["zjm"].ToString();
                  
                    Xkrgj_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xkrgj_add_edit Xkrgj_add_edit_new = new Xkrgj_add_edit(this);
            Xkrgj_add_edit_new.Left = common_file.common_app.x() - 200;
            Xkrgj_add_edit_new.Top = common_file.common_app.y() - 100;
            Xkrgj_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_krgj.CurrentRow != null)
            {
                int i = dg_krgj.CurrentRow.Index;
                DataRowView dgr = dg_krgj.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xkrgj.Tables[0].Rows.IndexOf(dgr.Row);
                if (DS_Xkrgj.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xkrgj_add_edit Xkrgj_add_edit_new = new Xkrgj_add_edit(this);
                    Xkrgj_add_edit_new.Xkrgj_id = DS_Xkrgj.Tables[0].Rows[i]["id"].ToString();
                    B_Xkrgj.Delete(int.Parse(Xkrgj_add_edit_new.Xkrgj_id));

                }
                refresh_app();
               
            }

        }
    }
}