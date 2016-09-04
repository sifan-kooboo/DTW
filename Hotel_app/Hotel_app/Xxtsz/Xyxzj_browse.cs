using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xyxzj_browse: Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xyxzj B_Xyxzj = new Hotel_app.BLL.Xyxzj();
        public DataSet DS_Xyxzj;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xyxzj = B_Xyxzj.GetList("id>=0" + common_file.common_app.yydh_select + " order by yxzj");
            bindingSource1.DataSource = DS_Xyxzj.Tables[0];
            dg_count = DS_Xyxzj.Tables[0].Rows.Count;
            this.dg_yxzj.AutoGenerateColumns = false;
        }
        #endregion

        public Xyxzj_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xyxzj = B_Xyxzj.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xyxzj.Tables[0];
            dg_count = DS_Xyxzj.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_yxzj.CurrentRow != null)
            {
                int i = dg_yxzj.CurrentRow.Index;

                DataRowView dgr = dg_yxzj.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xyxzj.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Xyxzj.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xyxzj_add_edit Xyxzj_add_edit_new = new Xyxzj_add_edit(this);
                    Xyxzj_add_edit_new.Left = common_file.common_app.x() + 50;
                    Xyxzj_add_edit_new.Top = common_file.common_app.y() - 100;
                    Xyxzj_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xyxzj_add_edit_new.Xyxzj_id = DS_Xyxzj.Tables[0].Rows[i]["id"].ToString();
                    Xyxzj_add_edit_new.tB_yxzj.Text = DS_Xyxzj.Tables[0].Rows[i]["yxzj"].ToString();
                    Xyxzj_add_edit_new.tB_zjm.Text = DS_Xyxzj.Tables[0].Rows[i]["zjm"].ToString();
                    Xyxzj_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xyxzj_add_edit Xyxzj_add_edit_new = new Xyxzj_add_edit(this);
            Xyxzj_add_edit_new.Left = common_file.common_app.x()+50;
            Xyxzj_add_edit_new.Top = common_file.common_app.y() - 100;
            Xyxzj_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_yxzj.CurrentRow != null)
            {
                int i = dg_yxzj.CurrentRow.Index;
                DataRowView dgr = dg_yxzj.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xyxzj.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Xyxzj.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xyxzj_add_edit Xyxzj_add_edit_new = new Xyxzj_add_edit(this);
                    Xyxzj_add_edit_new.Xyxzj_id = DS_Xyxzj.Tables[0].Rows[i]["id"].ToString();
                    B_Xyxzj.Delete(int.Parse(Xyxzj_add_edit_new.Xyxzj_id));
                 
                }
                refresh_app();
               
            }
            Cursor.Current = Cursors.Default;

        }
    }
}