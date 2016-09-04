using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfdr_browse : Form
    {
        public int dg_count = 0;//记录初期加载行数
        BLL.Xxfdr B_Xxfdr = new BLL.Xxfdr();
        Model.Xxfdr M_Xxfdr = new Model.Xxfdr();
        DataSet DS_Xxfdr;
        public Xxfdr_browse()
        {
           
            InitializeComponent();
            InitializeApp();
        }
        public void InitializeApp()
        {
           DS_Xxfdr = B_Xxfdr.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
           bindingSource1.DataSource = DS_Xxfdr.Tables[0];
           dg_count = DS_Xxfdr.Tables[0].Rows.Count;
           this.dg_xfdr.AutoGenerateColumns = false;
        }
        //刷新
        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xxfdr = B_Xxfdr.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xxfdr.Tables[0];
            dg_count = DS_Xxfdr.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default; 
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xxfdr_add_edit Xxfdr_add_edit_new = new Xxfdr_add_edit(this);
            Xxfdr_add_edit_new.Left = common_file.common_app.x()+50;
            Xxfdr_add_edit_new.Top = common_file.common_app.y() - 100;
            Xxfdr_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {

            common_file.common_app.get_czsj();
            if (dg_xfdr.CurrentRow != null)
            {
                int i = dg_xfdr.CurrentRow.Index;
                DataRowView dgr = dg_xfdr.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xxfdr.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Xxfdr.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xxfdr_add_edit Xxfdr_add_edit_new = new Xxfdr_add_edit(this);

                    Xxfdr_add_edit_new.Left = common_file.common_app.x();
                    Xxfdr_add_edit_new.Top = common_file.common_app.y();
                    Xxfdr_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xxfdr_add_edit_new.Xxfxr_id = DS_Xxfdr.Tables[0].Rows[i]["id"].ToString();
                    Xxfdr_add_edit_new.tB_drbh.Text = DS_Xxfdr.Tables[0].Rows[i]["drbh"].ToString();

                    Xxfdr_add_edit_new.tB_xfjg.Text = DS_Xxfdr.Tables[0].Rows[i]["xfje"].ToString();
                    Xxfdr_add_edit_new.tB_xfdr.Text = DS_Xxfdr.Tables[0].Rows[i]["xfdr"].ToString();
                    if (DS_Xxfdr.Tables[0].Rows[i]["is_visible_bb"].ToString() != null && DS_Xxfdr.Tables[0].Rows[i]["is_visible_bb"].ToString() != "")
                    {
                        Xxfdr_add_edit_new.Cb_visible_bb.Checked = Convert.ToBoolean(DS_Xxfdr.Tables[0].Rows[i]["is_visible_bb"].ToString());
                    }

                    Xxfdr_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }

            
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_xfdr.CurrentRow != null)
            {
                int i = dg_xfdr.CurrentRow.Index;
                DataRowView dgr = dg_xfdr.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xxfdr.Tables[0].Rows.IndexOf(dgr.Row);
                

                if (DS_Xxfdr.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xxfdr_add_edit Xxfdr_add_edit_new = new Xxfdr_add_edit(this);
                    
                    Xxfdr_add_edit_new.Xxfxr_id = DS_Xxfdr.Tables[0].Rows[i]["id"].ToString();
                    B_Xxfdr.Delete(int.Parse(Xxfdr_add_edit_new.Xxfxr_id));

                }
                refresh_app();

            }
        }
      
    }
}