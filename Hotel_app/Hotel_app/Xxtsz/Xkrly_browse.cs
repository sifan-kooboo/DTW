using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xkrly_browse : Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xkrly B_Xkrly = new Hotel_app.BLL.Xkrly();
        public DataSet DS_Xkrly;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xkrly = B_Xkrly.GetList("id>=0" + common_file.common_app.yydh_select + " order by krly");
            bindingSource1.DataSource = DS_Xkrly.Tables[0];
            dg_count = DS_Xkrly.Tables[0].Rows.Count;
            this.dg_krly.AutoGenerateColumns = false;
        }


        #endregion
        public Xkrly_browse()
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
            Xxtsz.Xkrly_add_edit Xkrly_add_edit_new = new Xkrly_add_edit(this);
            Xkrly_add_edit_new.Left = common_file.common_app.x() - 200;
            Xkrly_add_edit_new.Top = common_file.common_app.y() - 100;
            Xkrly_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_krly.CurrentRow != null)
            {
                int i = dg_krly.CurrentRow.Index;
                DataRowView dgr = dg_krly.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xkrly.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Xkrly.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xkrly_add_edit Xkrly_add_edit_new = new Xkrly_add_edit(this);
                    Xkrly_add_edit_new.Left = common_file.common_app.x() - 200;
                    Xkrly_add_edit_new.Top = common_file.common_app.y() - 100;
                    Xkrly_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xkrly_add_edit_new.Xkrly_id = DS_Xkrly.Tables[0].Rows[i]["id"].ToString();
                    Xkrly_add_edit_new.tB_krly.Text = DS_Xkrly.Tables[0].Rows[i]["krly"].ToString();
                    Xkrly_add_edit_new.tB_zjm.Text = DS_Xkrly.Tables[0].Rows[i]["zjm"].ToString();
                    Xkrly_add_edit_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_Xkrly = B_Xkrly.GetList("id>=0" + common_file.common_app.yydh_select + " order by krly");
            bindingSource1.DataSource = DS_Xkrly.Tables[0];
            dg_count = DS_Xkrly.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_krly.CurrentRow != null)
            {
                int i = dg_krly.CurrentRow.Index;
                DataRowView dgr = dg_krly.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Xkrly.Tables[0].Rows.IndexOf(dgr.Row);
                if (DS_Xkrly.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xkrly_add_edit Xkrly_add_edit_new = new Xkrly_add_edit(this);
                    Xkrly_add_edit_new.Xkrly_id = DS_Xkrly.Tables[0].Rows[i]["id"].ToString();
                    B_Xkrly.Delete(int.Parse(Xkrly_add_edit_new.Xkrly_id));
                }
                refresh_app();

            }
        }

       
      

       
    }
}