using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xqyxx_browse : Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xqyxx B_Xqyxx = new Hotel_app.BLL.Xqyxx();
        public DataSet DS_Xqyxx;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xqyxx = B_Xqyxx.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xqyxx.Tables[0];
            dg_count = DS_Xqyxx.Tables[0].Rows.Count;
            this.dg_qyxx.AutoGenerateColumns = false;
        }


        #endregion
        public Xqyxx_browse()
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

            Xxtsz.Xqyxx_add_edit Xqyxx_add_edit_new = new Xqyxx_add_edit(this);
            Xqyxx_add_edit_new.Left = common_file.common_app.x() - 200;
            Xqyxx_add_edit_new.Top = common_file.common_app.y() - 100;
            Xqyxx_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            int i = dg_qyxx.CurrentRow.Index;

            DataRowView dgr = dg_qyxx.Rows[i].DataBoundItem as DataRowView;
            i = DS_Xqyxx.Tables[0].Rows.IndexOf(dgr.Row);

            if (DS_Xqyxx.Tables[0].Rows[i]["id"].ToString() != "")
            {
                Xxtsz.Xqyxx_add_edit Xqyxx_add_edit_new = new Xqyxx_add_edit(this);
                Xqyxx_add_edit_new.Left = common_file.common_app.x() - 200;
                Xqyxx_add_edit_new.Top = common_file.common_app.y() - 100;
                Xqyxx_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                Xqyxx_add_edit_new.Xqyxx_id = DS_Xqyxx.Tables[0].Rows[i]["id"].ToString();
                Xqyxx_add_edit_new.tB_qymc.Text = DS_Xqyxx.Tables[0].Rows[i]["qymc"].ToString();
                Xqyxx_add_edit_new.tB_qybh.Text = DS_Xqyxx.Tables[0].Rows[i]["qybh"].ToString();
                Xqyxx_add_edit_new.tB_zjm.Text=DS_Xqyxx.Tables[0].Rows[i]["zjm"].ToString();
                Xqyxx_add_edit_new.tB_qydh.Text=DS_Xqyxx.Tables[0].Rows[i]["qydh"].ToString();
                Xqyxx_add_edit_new.tB_qycz.Text=DS_Xqyxx.Tables[0].Rows[i]["qycz"].ToString();

               Xqyxx_add_edit_new.tB_Email.Text=DS_Xqyxx.Tables[0].Rows[i]["Email"].ToString();
                Xqyxx_add_edit_new.tB_nxr.Text=DS_Xqyxx.Tables[0].Rows[i]["nxr"].ToString();
                Xqyxx_add_edit_new.tB_qydz.Text=DS_Xqyxx.Tables[0].Rows[i]["qydz"].ToString();

                Xqyxx_add_edit_new.ShowDialog();
            }

            
            Cursor.Current = Cursors.Default;
        }

        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_Xqyxx = B_Xqyxx.GetList("id>=0" + common_file.common_app.yydh_select + " order by qymc");
            bindingSource1.DataSource = DS_Xqyxx.Tables[0];
            dg_count = DS_Xqyxx.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
    }
}