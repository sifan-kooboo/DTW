using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xxfmx_browse : Form
    {
        public int dg_count = 0;//记录初期加载行数
        BLL.Xxfmx B_Xxfmx = new BLL.Xxfmx();
        Model.Xxfmx M_Xxfmx = new Model.Xxfmx();
        DataSet DS_Xxfmx;
        public string sel_condition = "";
        public Xxfmx_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        public void InitializeApp()
        {
            DS_Xxfmx = B_Xxfmx.GetList("id>=0" + common_file.common_app.yydh_select + " order by xfmx");
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            this.dg_xfmx.AutoGenerateColumns = false;
        }
        //刷新
        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            //string sql = "id>=0" + common_file.common_app.yydh_select + " " + sel_condition + " order by xfmx";
            //common_file.common_app.Message_box_show(common_file.common_app.message_title, "" + sql + "");
            DS_Xxfmx = B_Xxfmx.GetList("id>=0" + common_file.common_app.yydh_select + " "+sel_condition+" order by xfmx");
            bindingSource1.DataSource = DS_Xxfmx.Tables[0];
            dg_count = DS_Xxfmx.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_xfxm_xz", common_file.common_app.user_type) == false)
            { return; }
            Xxtsz.Xxfmx_add_edit Xxfmx_add_edit_new = new Xxfmx_add_edit(this);
         
            Xxfmx_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            Xxfmx_add_edit_new.judge_add_edit = common_file.common_app.get_add;
            Xxfmx_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_xfxm__xg", common_file.common_app.user_type) == false)
            { return; }
            if (dg_xfmx.CurrentRow != null)
            {
                int i = dg_xfmx.CurrentRow.Index;
                DataRowView dgr = dg_xfmx.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xxfmx.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xxfmx_add_edit Xxfmx_add_edit_new = new Xxfmx_add_edit(this);

                    Xxfmx_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Xxfmx_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xxfmx_add_edit_new.Xxfxr_id = DS_Xxfmx.Tables[0].Rows[i]["id"].ToString();
                    Xxfmx_add_edit_new.tB_mxbh.Text = DS_Xxfmx.Tables[0].Rows[i]["mxbh"].ToString();
                    Xxfmx_add_edit_new.tB_xfxr.Text = DS_Xxfmx.Tables[0].Rows[i]["xfxr"].ToString();
                    Xxfmx_add_edit_new.tB_xfje.Text = DS_Xxfmx.Tables[0].Rows[i]["xfje"].ToString();
                    Xxfmx_add_edit_new.tB_xfdr.Text = DS_Xxfmx.Tables[0].Rows[i]["xfdr"].ToString();
                    Xxfmx_add_edit_new.tB_xfmx.Text = DS_Xxfmx.Tables[0].Rows[i]["xfmx"].ToString();
                    Xxfmx_add_edit_new.tB_zjm.Text = DS_Xxfmx.Tables[0].Rows[i]["zjm"].ToString();

                    Xxfmx_add_edit_new.tB_xfjl.Text = DS_Xxfmx.Tables[0].Rows[i]["jldw"].ToString();
                    Xxfmx_add_edit_new.tB_xftm.Text = DS_Xxfmx.Tables[0].Rows[i]["xftm"].ToString();
                    Xxfmx_add_edit_new.tB_xfgg.Text = DS_Xxfmx.Tables[0].Rows[i]["xfgg"].ToString();
                    Xxfmx_add_edit_new.tB_xfcd.Text = DS_Xxfmx.Tables[0].Rows[i]["xf_cd"].ToString();
                    Xxfmx_add_edit_new.tB_jjje.Text = DS_Xxfmx.Tables[0].Rows[i]["jjje"].ToString();
                    Xxfmx_add_edit_new.tB_xfdw.Text = DS_Xxfmx.Tables[0].Rows[i]["xf_dw"].ToString();
                    Xxfmx_add_edit_new.tB_kcsl.Text = DS_Xxfmx.Tables[0].Rows[i]["kcsl"].ToString();
                    if (DS_Xxfmx.Tables[0].Rows[i]["is_tj_kc"].ToString() != null && DS_Xxfmx.Tables[0].Rows[i]["is_tj_kc"].ToString() != "")
                    {
                        Xxfmx_add_edit_new.Cb_is_tj_kc.Checked = Convert.ToBoolean(DS_Xxfmx.Tables[0].Rows[i]["is_tj_kc"].ToString());
                    }

                    Xxfmx_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void dg_xfmx_DoubleClick(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();

            if (dg_xfmx.CurrentRow != null)
            {
                int i = dg_xfmx.CurrentRow.Index;

                DataRowView dgr = dg_xfmx.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xxfmx.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Xxfmx.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xxfmx_add_edit Xxfmx_add_edit_new = new Xxfmx_add_edit(this);

                    Xxfmx_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Xxfmx_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xxfmx_add_edit_new.Xxfxr_id = DS_Xxfmx.Tables[0].Rows[i]["id"].ToString();
                    Xxfmx_add_edit_new.tB_mxbh.Text = DS_Xxfmx.Tables[0].Rows[i]["mxbh"].ToString();
                    Xxfmx_add_edit_new.tB_xfxr.Text = DS_Xxfmx.Tables[0].Rows[i]["xfxr"].ToString();
                    Xxfmx_add_edit_new.tB_xfje.Text = DS_Xxfmx.Tables[0].Rows[i]["xfje"].ToString();
                    Xxfmx_add_edit_new.tB_xfdr.Text = DS_Xxfmx.Tables[0].Rows[i]["xfdr"].ToString();
                    Xxfmx_add_edit_new.tB_xfmx.Text = DS_Xxfmx.Tables[0].Rows[i]["xfmx"].ToString();
                    Xxfmx_add_edit_new.tB_zjm.Text = DS_Xxfmx.Tables[0].Rows[i]["zjm"].ToString();

                    Xxfmx_add_edit_new.tB_xfjl.Text = DS_Xxfmx.Tables[0].Rows[i]["jldw"].ToString();
                    Xxfmx_add_edit_new.tB_xftm.Text = DS_Xxfmx.Tables[0].Rows[i]["xftm"].ToString();
                    Xxfmx_add_edit_new.tB_xfgg.Text = DS_Xxfmx.Tables[0].Rows[i]["xfgg"].ToString();
                    Xxfmx_add_edit_new.tB_xfcd.Text = DS_Xxfmx.Tables[0].Rows[i]["xf_cd"].ToString();
                    Xxfmx_add_edit_new.tB_jjje.Text = DS_Xxfmx.Tables[0].Rows[i]["jjje"].ToString();
                    Xxfmx_add_edit_new.tB_xfdw.Text = DS_Xxfmx.Tables[0].Rows[i]["xf_dw"].ToString();
                    Xxfmx_add_edit_new.tB_kcsl.Text = DS_Xxfmx.Tables[0].Rows[i]["kcsl"].ToString();
                    if (DS_Xxfmx.Tables[0].Rows[i]["is_tj_kc"].ToString() != null && DS_Xxfmx.Tables[0].Rows[i]["is_tj_kc"].ToString() != "")
                    {
                        Xxfmx_add_edit_new.Cb_is_tj_kc.Checked = Convert.ToBoolean(DS_Xxfmx.Tables[0].Rows[i]["is_tj_kc"].ToString());
                    }
                    Xxfmx_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_xfxm__sc", common_file.common_app.user_type) == false)
            { return; }
            if (DS_Xxfmx != null && DS_Xxfmx.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_xfmx.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_xfmx.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_xfmx.Rows[i].Index.ToString());
                            DataRowView dgr = dg_xfmx.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Xxfmx.Tables[0].Rows.IndexOf(dgr.Row);


                            if (DS_Xxfmx.Tables[0].Rows[j]["id"].ToString() != "")
                            {

                                string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                                object[] args = new object[21];
                                args[0] = DS_Xxfmx.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = "";
                                args[7] = "";
                                args[8] = "";
                                args[9] = "";
                                args[10] = "";
                                args[11] = "";
                                args[12] = "";
                                args[13] = "";
                                args[14] = "";
                                args[15] = "";
                                args[16] = "";
                                args[17] =true;
                                args[18] = "0";
                                args[19] = common_file.common_app.get_delete;
                                args[20] = common_file.common_app.xxzs;

                                Hotel_app.Server.Xxtsz.Xxfmx Xxfmx_services = new Hotel_app.Server.Xxtsz.Xxfmx();
                                string result = Xxfmx_services.Xxfmx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), bool.Parse(args[17].ToString()), args[18].ToString(), args[19].ToString(), args[20].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xxfmx_add_edit", args);
                                if (result== common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
                                {
                                    s = common_file.common_app.get_suc;
                                }
                                else s = common_file.common_app.get_failure;

                            }


                        }

                    }
                    if (s == common_file.common_app.get_suc)
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功！");
                    else
                        if (s == common_file.common_app.get_failure) common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除不成功！");
                    refresh_app();

                }
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
            if (common_file.common_roles.get_user_qx("B_xfxm__gl", common_file.common_app.user_type) == false)
            { return; }
            sel_condition = "";
            Xxtsz.Xxfmx_gl Xxfmx_gl_new = new Xxfmx_gl();
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