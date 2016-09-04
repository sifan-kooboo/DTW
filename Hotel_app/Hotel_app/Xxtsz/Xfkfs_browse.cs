using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xfkfs_browse : Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xfkfs B_Xfkfs = new Hotel_app.BLL.Xfkfs();
        public DataSet DS_Xfkfs;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xfkfs = B_Xfkfs.GetList("id>=0" + common_file.common_app.yydh_select + " order by fkfs");
            bindingSource1.DataSource = DS_Xfkfs.Tables[0];
            dg_count = DS_Xfkfs.Tables[0].Rows.Count;
            this.dg_fkfs.AutoGenerateColumns = false;
        }


        #endregion
        public Xfkfs_browse()
        {
            InitializeComponent();
            InitializeApp();
        }


        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xfkfs_add_edit Xfkfs_add_edit_new = new Xfkfs_add_edit(this);
            Xfkfs_add_edit_new.Left = common_file.common_app.x() - 200;
            Xfkfs_add_edit_new.Top = common_file.common_app.y() - 100;
            Xfkfs_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_fkfs.CurrentRow != null)
            {
                int i = dg_fkfs.CurrentRow.Index;
                DataRowView dgr = dg_fkfs.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xfkfs.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Xfkfs.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xfkfs_add_edit Xfkfs_add_edit_new = new Xfkfs_add_edit(this);
                    Xfkfs_add_edit_new.Left = common_file.common_app.x() - 200;
                    Xfkfs_add_edit_new.Top = common_file.common_app.y() - 100;
                    Xfkfs_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xfkfs_add_edit_new.Xfkfs_id = DS_Xfkfs.Tables[0].Rows[i]["id"].ToString();
                    Xfkfs_add_edit_new.tB_fkfs.Text = DS_Xfkfs.Tables[0].Rows[i]["fkfs"].ToString();
                    Xfkfs_add_edit_new.tB_zjm.Text = DS_Xfkfs.Tables[0].Rows[i]["zjm"].ToString();
                    Xfkfs_add_edit_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_Xfkfs = B_Xfkfs.GetList("id>=0" + common_file.common_app.yydh_select + " order by fkfs");
            bindingSource1.DataSource = DS_Xfkfs.Tables[0];
            dg_count = DS_Xfkfs.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_fkfs.CurrentRow != null)
            {
                int i = dg_fkfs.CurrentRow.Index;
                DataRowView dgr = dg_fkfs.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xfkfs.Tables[0].Rows.IndexOf(dgr.Row);
                if (DS_Xfkfs.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xfkfs_add_edit Xfkfs_add_edit_new = new Xfkfs_add_edit(this);
                    Xfkfs_add_edit_new.Xfkfs_id = DS_Xfkfs.Tables[0].Rows[i]["id"].ToString();
                    B_Xfkfs.Delete(int.Parse(Xfkfs_add_edit_new.Xfkfs_id));

                }
                refresh_app();

            }
        }

       
      

       
    }
}