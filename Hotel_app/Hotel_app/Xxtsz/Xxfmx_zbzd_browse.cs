using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_zbzd_browse : Form
    {
        public int dg_count = 0;//记录初期加载行数
        BLL.Xxfmx_zbzd B_Xxfmx_zbzd = new BLL.Xxfmx_zbzd();
        Model.Xxfmx_zbzd M_Xxfmx_zbzd = new Model.Xxfmx_zbzd();
        DataSet DS_Xxfmx;
        public string sel_condition = "";
        public Xxfmx_zbzd_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        public void InitializeApp()
        {
            DS_Xxfmx = B_Xxfmx_zbzd.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            this.dg_xfmx_lkzd.AutoGenerateColumns = false;
        }
        //刷新
        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xxfmx = B_Xxfmx_zbzd.GetList("id>=0" + common_file.common_app.yydh_select + " " + sel_condition + " order by id");
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xxfmx_zbzd_add_edit Xxfmx_zbzd_add_edit_new = new Xxfmx_zbzd_add_edit(this);
            Xxfmx_zbzd_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            Xxfmx_zbzd_add_edit_new.judge_add_edit = common_file.common_app.get_add;
            Xxfmx_zbzd_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_xfmx_lkzd.CurrentRow != null)
            {
                int i = dg_xfmx_lkzd.CurrentRow.Index;
                if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xxfmx_zbzd_add_edit Xxfmx_zbzd_add_edit_new = new Xxfmx_zbzd_add_edit(this);

                    Xxfmx_zbzd_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Xxfmx_zbzd_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xxfmx_zbzd_add_edit_new.Xxfxr_id = DS_Xxfmx.Tables[0].Rows[i]["id"].ToString();
                    Xxfmx_zbzd_add_edit_new.tB_bz.Text = DS_Xxfmx.Tables[0].Rows[i]["bz"].ToString();
                    Xxfmx_zbzd_add_edit_new.tB_zbnr.Text = DS_Xxfmx.Tables[0].Rows[i]["zbnr"].ToString();
                    Xxfmx_zbzd_add_edit_new.strissh = DS_Xxfmx.Tables[0].Rows[i]["is_sh"].ToString();
                    string is_sh = DS_Xxfmx.Tables[0].Rows[i]["is_sh"].ToString();

                    if (DS_Xxfmx.Tables[0].Rows[i]["is_sh"].ToString() != null && DS_Xxfmx.Tables[0].Rows[i]["is_sh"].ToString() != "")
                    {
                        if (is_sh == common_file.common_app.is_sh)
                        {
                            Xxfmx_zbzd_add_edit_new.Cb_is_tj_kc.Visible = false;

                        }

                        else
                        {
                            Xxfmx_zbzd_add_edit_new.Cb_is_tj_kc.Visible = true;
                            Xxfmx_zbzd_add_edit_new.Cb_is_tj_kc.Checked = false;
                        }
                    }
                    Xxfmx_zbzd_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void dg_xfmx_DoubleClick(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_xfmx_lkzd.CurrentRow != null)
            {
                int i = dg_xfmx_lkzd.CurrentRow.Index;
                if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    string lsbh = DS_Xxfmx.Tables[0].Rows[i]["lsbh"].ToString();
                    Xxtsz.Xxfmx_zbmx_browse Xxfmx_zbmx_browse_new = new Xxfmx_zbmx_browse(this, lsbh);
                    Xxfmx_zbmx_browse_new.StartPosition = FormStartPosition.CenterScreen;
                    Xxfmx_zbmx_browse_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Xxfmx != null && DS_Xxfmx.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    if (dg_xfmx_lkzd.CurrentRow != null)
                    {
                        int i = dg_xfmx_lkzd.CurrentRow.Index;
                        DataRowView dgr = dg_xfmx_lkzd.Rows[i].DataBoundItem as DataRowView;
                        i = DS_Xxfmx.Tables[0].Rows.IndexOf(dgr.Row);
                        if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                        {
                            string strid = DS_Xxfmx.Tables[0].Rows[i]["id"].ToString();
                            string strissh = DS_Xxfmx.Tables[0].Rows[i]["is_sh"].ToString();
                            if (strissh != null && strissh != "")
                            {
                                if (strissh == common_file.common_app.is_wsh)
                                {
                                    string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                                    object[] args = new object[12];
                                    args[0] = strid;
                                    args[1] = common_file.common_app.yydh;
                                    args[2] = common_file.common_app.qymc;
                                    args[3] = DS_Xxfmx.Tables[0].Rows[i]["lsbh"].ToString();
                                    args[4] = "";
                                    args[5] = "";
                                    args[6] = "";
                                    args[7] = "";
                                    args[8] = "";
                                    args[9] = "";
                                    args[10] = common_file.common_app.get_delete;
                                    args[11] = common_file.common_app.xxzs;

                                    Hotel_app.Server.Xxtsz.Xxfmx_zbzd Xxfmx_zbzd_services = new Hotel_app.Server.Xxtsz.Xxfmx_zbzd();
                                    string result = Xxfmx_zbzd_services.Xxfmx_zbzd_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString());
                                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfmx_zbzd_add_edit", args);
                                    if (result== common_file.common_app.get_suc)
                                    {
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功!");
                                    }
                                    else
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                                }
                                else
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，审核通过就不能删除！");
                                    return;

                                }
                            }
                        }
                    }

                }
            InitializeApp();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            InitializeApp();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            sel_condition = "";
            Xxtsz.Xxfmx_zbzd_gl Xxfmx_gl_new = new Xxfmx_zbzd_gl();
            Xxfmx_gl_new.StartPosition = FormStartPosition.CenterScreen;
            if (Xxfmx_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_condition = sel_condition + Xxfmx_gl_new.get_sel_cond;

                if (Xxfmx_gl_new.get_sel_cond != "")
                {
                    refresh_app();
                }
            }
            Xxfmx_gl_new.Dispose();
        }

      


    }
}