using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfsz_browse : Form
    {
        public int dg_count = 0;//记录初期加载行数
        BLL.Xxfxr B_Xxfxr = new BLL.Xxfxr();
        Model.Xxfxr M_Xxfxr = new Model.Xxfxr();
        DataSet DS_Xxfxr;
        public Xxfsz_browse()
        {
           
            InitializeComponent();
            InitializeApp();
        }
        public void InitializeApp()
        {
            DS_Xxfxr = B_Xxfxr.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
           bindingSource1.DataSource = DS_Xxfxr.Tables[0];
           dg_count = DS_Xxfxr.Tables[0].Rows.Count;
           this.dg_xfsz.AutoGenerateColumns = false;
        }
        //刷新
        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xxfxr = B_Xxfxr.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xxfxr.Tables[0];
            dg_count = DS_Xxfxr.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default; 
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xxfsz_add_edit Xxfsz_add_edit_new = new Xxfsz_add_edit(this);
            Xxfsz_add_edit_new.Left = common_file.common_app.x() + 50;
            Xxfsz_add_edit_new.Top = common_file.common_app.y() - 100;
            Xxfsz_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {

            common_file.common_app.get_czsj();
            if (dg_xfsz.CurrentRow != null)
            {
                int i = dg_xfsz.CurrentRow.Index;

                DataRowView dgr = dg_xfsz.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xxfxr.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Xxfxr.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xxfsz_add_edit Xxfsz_add_edit_new = new Xxfsz_add_edit(this);

                  
                    Xxfsz_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Xxfsz_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xxfsz_add_edit_new.Xxfxr_id = DS_Xxfxr.Tables[0].Rows[i]["id"].ToString();
                    Xxfsz_add_edit_new.tB_xrbh.Text = DS_Xxfxr.Tables[0].Rows[i]["xrbh"].ToString();
                    Xxfsz_add_edit_new.tB_xfxr.Text = DS_Xxfxr.Tables[0].Rows[i]["xfxr"].ToString();
                    Xxfsz_add_edit_new.tB_xfjg.Text = DS_Xxfxr.Tables[0].Rows[i]["xfje"].ToString();
                    Xxfsz_add_edit_new.tB_xfdr.Text = DS_Xxfxr.Tables[0].Rows[i]["xfdr"].ToString();
                    if (DS_Xxfxr.Tables[0].Rows[i]["is_visible_bb"].ToString() != null && DS_Xxfxr.Tables[0].Rows[i]["is_visible_bb"].ToString() != "")
                    {
                        Xxfsz_add_edit_new.Cb_visible_bb.Checked = Convert.ToBoolean(DS_Xxfxr.Tables[0].Rows[i]["is_visible_bb"].ToString());
                    }
                    Xxfsz_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }

            
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_xfsz.CurrentRow != null)
            {
               if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "您确定要删除所选择的消费小类嘛?") == true)
                {
                    int i = dg_xfsz.CurrentRow.Index;

                    DataRowView dgr = dg_xfsz.Rows[i].DataBoundItem as DataRowView;
                    i = DS_Xxfxr.Tables[0].Rows.IndexOf(dgr.Row);

                    if (DS_Xxfxr.Tables[0].Rows[i]["id"].ToString() != "")
                    {
                        Xxtsz.Xxfsz_add_edit Xxfsz_add_edit_new = new Xxfsz_add_edit(this);
                        Xxfsz_add_edit_new.Xxfxr_id = DS_Xxfxr.Tables[0].Rows[i]["id"].ToString();
                       if(B_Xxfxr.Delete(int.Parse(Xxfsz_add_edit_new.Xxfxr_id))==true)
                        {
                             common_file.common_app.Message_box_show(common_file.common_app.message_title,"删除成功");
                             refresh_app();
                        }
                        else
	{
                             common_file.common_app.Message_box_show(common_file.common_app.message_title,"删除失败！");
	}
                    }
               }
                }

            }
        }
      
}