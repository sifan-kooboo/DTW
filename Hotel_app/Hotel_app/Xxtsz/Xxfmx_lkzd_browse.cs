using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_lkzd_browse : Form
    {
        public int dg_count = 0;//记录初期加载行数
        BLL.Xxfmx_lkzd B_Xxfmx_lkzd = new BLL.Xxfmx_lkzd();
        Model.Xxfmx_lkzd M_Xxfmx_lkzd = new Model.Xxfmx_lkzd();
        DataSet DS_Xxfmx;
        public string sel_condition = "";
        public Xxfmx_lkzd_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        public void InitializeApp()
        {
            DS_Xxfmx = B_Xxfmx_lkzd.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            this.dg_xfmx_lkzd.AutoGenerateColumns = false;
        }
        //刷新
        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xxfmx = B_Xxfmx_lkzd.GetList("id>=0" + common_file.common_app.yydh_select + " " + sel_condition + " order by id");
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xxfmx_lkzd_add_edit Xxfmx_lkzd_add_edit_new = new Xxfmx_lkzd_add_edit(this);
            Xxfmx_lkzd_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            Xxfmx_lkzd_add_edit_new.judge_add_edit = common_file.common_app.get_add;
            Xxfmx_lkzd_add_edit_new.ShowDialog();
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
                    Xxtsz.Xxfmx_lkzd_add_edit Xxfmx_lkzd_add_edit_new = new Xxfmx_lkzd_add_edit(this);

                    Xxfmx_lkzd_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Xxfmx_lkzd_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xxfmx_lkzd_add_edit_new.Xxfxr_id = DS_Xxfmx.Tables[0].Rows[i]["id"].ToString();
                    Xxfmx_lkzd_add_edit_new.tB_bz.Text = DS_Xxfmx.Tables[0].Rows[i]["bz"].ToString();
                    Xxfmx_lkzd_add_edit_new.tB_lknr.Text = DS_Xxfmx.Tables[0].Rows[i]["lknr"].ToString();
                    bool is_sh = Convert.ToBoolean(DS_Xxfmx.Tables[0].Rows[i]["sh_sh"].ToString());
                    Xxfmx_lkzd_add_edit_new.strissh = is_sh;
                    if (DS_Xxfmx.Tables[0].Rows[i]["sh_sh"].ToString() != null && DS_Xxfmx.Tables[0].Rows[i]["sh_sh"].ToString() != "")
                    {
                        if (is_sh)
                        {
                            Xxfmx_lkzd_add_edit_new.Cb_is_tj_kc.Visible = false;

                        }

                        else
                        {
                            Xxfmx_lkzd_add_edit_new.Cb_is_tj_kc.Visible = true;
                            Xxfmx_lkzd_add_edit_new.Cb_is_tj_kc.Checked = Convert.ToBoolean(DS_Xxfmx.Tables[0].Rows[i]["sh_sh"].ToString());
                        }
                    }
                    Xxfmx_lkzd_add_edit_new.ShowDialog();
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
                if (DS_Xxfmx.Tables[0].Rows.Count >= 1)
                {
                    if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                    {
                        string lsbh = DS_Xxfmx.Tables[0].Rows[i]["lsbh"].ToString();

                        Xxtsz.Xxfmx_lkmx_browse Xxfmx_lkmx_browse_new = new Xxfmx_lkmx_browse(this, lsbh);

                        Xxfmx_lkmx_browse_new.StartPosition = FormStartPosition.CenterScreen;
                        //Xxfmx_lkmx_browse_new.strlsbh = DS_Xxfmx.Tables[0].Rows[i]["lsbh"].ToString();

                        Xxfmx_lkmx_browse_new.ShowDialog();
                    }
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
                            bool strissh = Convert.ToBoolean(DS_Xxfmx.Tables[0].Rows[i]["sh_sh"].ToString());

                            if (strissh)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，审核通过就不能删除！");
                                return;

                            }
                            else
                            {
                                string strlsbh = DS_Xxfmx.Tables[0].Rows[i]["lsbh"].ToString();
                                string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                                object[] args = new object[12];
                                args[0] = strid;
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = strlsbh;
                                args[4] = "";
                                args[5] = "";
                                args[6] = false;
                                args[7] = "";
                                args[8] = "";
                                args[9] = "";
                                args[10] = common_file.common_app.get_delete;
                                args[11] = common_file.common_app.xxzs;

                                Hotel_app.Server.Xxtsz.Xxfmx_lkzd Xxfmx_lkzd_services = new Hotel_app.Server.Xxtsz.Xxfmx_lkzd();
                                string result = Xxfmx_lkzd_services.Xxfmx_lkzd_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(),bool.Parse(args[6].ToString()), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfmx_lkzd_add_edit", args);
                                if (result== common_file.common_app.get_suc)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功!");
                                }
                                else
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");


                            }
                        }

                    }

                }
            InitializeApp();
            Cursor.Current = Cursors.Default;


            //common_file.common_app.get_czsj();
            //if (DS_Xxfmx != null && DS_Xxfmx.Tables[0].Rows.Count > 0)
            //    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
            //    {
            //        int j = 0; string s = "";
            //        for (int i = 0; i < dg_count; i++)
            //        {
            //            common_file.common_app.get_czsj();
            //            DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
            //            if (this.dg_xfmx_lkzd.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_xfmx_lkzd.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
            //            {
            //                j = Convert.ToInt32(dg_xfmx_lkzd.Rows[i].Index.ToString());
            //                if (DS_Xxfmx.Tables[0].Rows[j]["id"].ToString() != "")
            //                {
            //                   int strid=int.Parse(DS_Xxfmx.Tables[0].Rows[j]["id"].ToString());
            //                   B_Xxfmx_lkzd.Delete(strid);
            //                   s = common_file.common_app.get_suc;

            //                }
            //            }

            //        }
            //        if (s == common_file.common_app.get_suc)
            //            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功！");
            //        else
            //            if (s == common_file.common_app.get_failure) common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除不成功！");
            //        InitializeApp();

            //    }
            //Cursor.Current = Cursors.Default;
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
            Xxtsz.Xxfmx_lkzd_gl Xxfmx_gl_new = new Xxfmx_lkzd_gl();
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