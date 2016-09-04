using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xkrrx_browse : Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xkrrx B_Xkrrx = new Hotel_app.BLL.Xkrrx();
        public DataSet DS_Xkrrx;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xkrrx = B_Xkrrx.GetList("id>=0" + common_file.common_app.yydh_select + " order by krrx");
            bindingSource1.DataSource = DS_Xkrrx.Tables[0];
            dg_count = DS_Xkrrx.Tables[0].Rows.Count;
            this.dg_krrx.AutoGenerateColumns = false;
        }
        #endregion

        public Xkrrx_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xkrrx = B_Xkrrx.GetList("id>=0" + common_file.common_app.yydh_select + " order by krrx");
            bindingSource1.DataSource = DS_Xkrrx.Tables[0];
            dg_count = DS_Xkrrx.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_krrx.CurrentRow != null)
            {
                int i = dg_krrx.CurrentRow.Index;

                //修改成表对应的行号
                DataRowView dgr = dg_krrx.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xkrrx.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Xkrrx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xkrrx_add_edit Xkrrx_add_edit_new = new Xkrrx_add_edit(this);
                    Xkrrx_add_edit_new.Left = common_file.common_app.x() - 200;
                    Xkrrx_add_edit_new.Top = common_file.common_app.y() - 100;
                    Xkrrx_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xkrrx_add_edit_new.Xkrrx_id = DS_Xkrrx.Tables[0].Rows[i]["id"].ToString();
                    Xkrrx_add_edit_new.tB_krrx.Text = DS_Xkrrx.Tables[0].Rows[i]["krrx"].ToString();
                    Xkrrx_add_edit_new.tB_zjm.Text = DS_Xkrrx.Tables[0].Rows[i]["zjm"].ToString();
                    Xkrrx_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xkrrx_add_edit Xkrrx_add_edit_new = new Xkrrx_add_edit(this);
            Xkrrx_add_edit_new.Left = common_file.common_app.x() - 200;
            Xkrrx_add_edit_new.Top = common_file.common_app.y() - 100;
            Xkrrx_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_krrx.CurrentRow != null)
            {
                int i = dg_krrx.CurrentRow.Index;
                DataRowView dgr = dg_krrx.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xkrrx.Tables[0].Rows.IndexOf(dgr.Row);
                if (DS_Xkrrx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xkrrx_add_edit Xkrrx_add_edit_new = new Xkrrx_add_edit(this);
                    Xkrrx_add_edit_new.Xkrrx_id = DS_Xkrrx.Tables[0].Rows[i]["id"].ToString();
                    B_Xkrrx.Delete(int.Parse(Xkrrx_add_edit_new.Xkrrx_id));

                }
                refresh_app();

            }
        }
    }
}