using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xqzrx_browse: Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xqzrx B_Xqzrx = new Hotel_app.BLL.Xqzrx();
        public DataSet DS_Xqzrx;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xqzrx = B_Xqzrx.GetList("id>=0" + common_file.common_app.yydh_select + " order by qzrx");
            bindingSource1.DataSource = DS_Xqzrx.Tables[0];
            dg_count = DS_Xqzrx.Tables[0].Rows.Count;
            this.dg_qzrx.AutoGenerateColumns = false;
        }
        #endregion

        public Xqzrx_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xqzrx = B_Xqzrx.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xqzrx.Tables[0];
            dg_count = DS_Xqzrx.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_qzrx.CurrentRow != null)
            {
                int i = dg_qzrx.CurrentRow.Index;

                DataRowView dgr = dg_qzrx.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xqzrx.Tables[0].Rows.IndexOf(dgr.Row);


                if (   DS_Xqzrx.Tables[0].Rows[i]["id"].ToString() != "")
                {


                    Xxtsz.Xqzrx_add_edit Xqzrx_add_edit_new = new Xqzrx_add_edit(this);
                    Xqzrx_add_edit_new.Left = common_file.common_app.x();
                    Xqzrx_add_edit_new.Top = common_file.common_app.y();
                    Xqzrx_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xqzrx_add_edit_new.Xqzrx_id = DS_Xqzrx.Tables[0].Rows[i]["id"].ToString();
                    Xqzrx_add_edit_new.tB_qzrx.Text = DS_Xqzrx.Tables[0].Rows[i]["qzrx"].ToString();
                    Xqzrx_add_edit_new.tB_zjm.Text = DS_Xqzrx.Tables[0].Rows[i]["zjm"].ToString();
                    Xqzrx_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xqzrx_add_edit Xqzrx_add_edit_new = new Xqzrx_add_edit(this);
            Xqzrx_add_edit_new.Left = common_file.common_app.x();
            Xqzrx_add_edit_new.Top = common_file.common_app.y();
            Xqzrx_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_qzrx.CurrentRow != null)
            {
                int i = dg_qzrx.CurrentRow.Index;
                if (DS_Xqzrx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xqzrx_add_edit Xqzrx_add_edit_new = new Xqzrx_add_edit(this);
                    Xqzrx_add_edit_new.Xqzrx_id = DS_Xqzrx.Tables[0].Rows[i]["id"].ToString();
                    B_Xqzrx.Delete(int.Parse(Xqzrx_add_edit_new.Xqzrx_id));
                 
                }
                refresh_app();
               
            }

        }
    }
}