using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yyxzx
{
    public partial class Yxsy_browse: Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Yxsy B_Yxsy = new Hotel_app.BLL.Yxsy();
        public DataSet DS_Yxsy;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Yxsy = B_Yxsy.GetList("id>=0" + common_file.common_app.yydh_select + " order by xsy");
            bindingSource1.DataSource = DS_Yxsy.Tables[0];
            dg_count = DS_Yxsy.Tables[0].Rows.Count;
            this.dg_yxsy.AutoGenerateColumns = false;
        }
        #endregion

        public Yxsy_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Yxsy = B_Yxsy.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Yxsy.Tables[0];
            dg_count = DS_Yxsy.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_yxsy.CurrentRow != null)
            {
                int i = dg_yxsy.CurrentRow.Index;

                DataRowView dgr = dg_yxsy.Rows[i].DataBoundItem as DataRowView;
                i = DS_Yxsy.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Yxsy.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Yyxzx.Yxsy_add_edit Yxsy_add_edit_new = new Yxsy_add_edit(this);
                    Yxsy_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Yxsy_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Yxsy_add_edit_new.Yxsy_id = DS_Yxsy.Tables[0].Rows[i]["id"].ToString();
                    Yxsy_add_edit_new.tB_xsy.Text = DS_Yxsy.Tables[0].Rows[i]["xsy"].ToString();
                    Yxsy_add_edit_new.tB_zjm.Text = DS_Yxsy.Tables[0].Rows[i]["zjm"].ToString();
                    Yxsy_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yyxzx.Yxsy_add_edit Yxsy_add_edit_new = new Yxsy_add_edit(this);
            Yxsy_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
      
            Yxsy_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_yxsy.CurrentRow != null)
            {
                int i = dg_yxsy.CurrentRow.Index;
                DataRowView dgr = dg_yxsy.Rows[i].DataBoundItem as DataRowView;
                i = DS_Yxsy.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Yxsy.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Yyxzx.Yxsy_add_edit Yxsy_add_edit_new = new Yxsy_add_edit(this);
                    Yxsy_add_edit_new.Yxsy_id = DS_Yxsy.Tables[0].Rows[i]["id"].ToString();
                    B_Yxsy.Delete(int.Parse(Yxsy_add_edit_new.Yxsy_id));
                 
                }
                refresh_app();
               
            }

        }
    }
}