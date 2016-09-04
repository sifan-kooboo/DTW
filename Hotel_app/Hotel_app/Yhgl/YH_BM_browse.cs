using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_BM_browse: Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.YH_bmsz B_Bmsz = new Hotel_app.BLL.YH_bmsz();
        public DataSet DS_Bmsz;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Bmsz = B_Bmsz.GetList("id>=0" + common_file.common_app.yydh_select + " order by yhbm");
            bindingSource1.DataSource = DS_Bmsz.Tables[0];
            dg_count = DS_Bmsz.Tables[0].Rows.Count;
            this.dg_bmsz.AutoGenerateColumns = false;
        }
        #endregion

        public YH_BM_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Bmsz = B_Bmsz.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Bmsz.Tables[0];
            dg_count = DS_Bmsz.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_bmsz.CurrentRow != null)
            {
                int i = dg_bmsz.CurrentRow.Index;

                DataRowView dgr = dg_bmsz.Rows[i].DataBoundItem as DataRowView;
                i = DS_Bmsz.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Bmsz.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Yhgl.YH_BM_add_edit YH_BM_add_edit_new = new YH_BM_add_edit(this);

                    YH_BM_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    YH_BM_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    YH_BM_add_edit_new.Xqzrx_id = DS_Bmsz.Tables[0].Rows[i]["id"].ToString();
                    YH_BM_add_edit_new.tB_bm.Text = DS_Bmsz.Tables[0].Rows[i]["yhbm"].ToString();
                    YH_BM_add_edit_new.tB_zjm.Text = DS_Bmsz.Tables[0].Rows[i]["zjm"].ToString();
                    YH_BM_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yhgl.YH_BM_add_edit YH_BM_add_edit_new = new YH_BM_add_edit(this);
            YH_BM_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            YH_BM_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_bmsz.CurrentRow != null)
            {
                int i = dg_bmsz.CurrentRow.Index;
                DataRowView dgr = dg_bmsz.Rows[i].DataBoundItem as DataRowView;
                i = DS_Bmsz.Tables[0].Rows.IndexOf(dgr.Row);
                if (DS_Bmsz.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Yhgl.YH_BM_add_edit bm_add_edit_new = new YH_BM_add_edit(this);
                    bm_add_edit_new.Xqzrx_id = DS_Bmsz.Tables[0].Rows[i]["id"].ToString();
                    B_Bmsz.Delete(int.Parse(bm_add_edit_new.Xqzrx_id));

                }
                refresh_app();

            }

        }
    }
}