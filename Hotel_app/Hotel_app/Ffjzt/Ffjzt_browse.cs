using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjzt_browse : Form
    {
        public int dg_count = 0;

        BLL.Ffjzt B_Ffjzt = new Hotel_app.BLL.Ffjzt();
        public static DataSet DS_Ffjzt;

        public Ffjzt_browse()
        {
            InitializeComponent();
            InitializeApp();
        }


        public void InitializeApp()
        {
            DS_Ffjzt = B_Ffjzt.GetList("ID>=0" + common_file.common_app.yydh_select + " order by fjbh");
            bindingSource1.DataSource = DS_Ffjzt.Tables[0];
            dg_count = DS_Ffjzt.Tables[0].Rows.Count;
            this.dataGridViewSummary1.AutoGenerateColumns = false;

        }

        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_Ffjzt = B_Ffjzt.GetList("ID>=0" + common_file.common_app.yydh_select + " order by fjbh");
            bindingSource1.DataSource = DS_Ffjzt.Tables[0];
            dg_count = DS_Ffjzt.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
        private void b_exit_Click(object sender, EventArgs e)
        {
            
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_ftcx_sc", common_file.common_app.user_type) == false)
            { return; }
            if (DS_Ffjzt != null && DS_Ffjzt.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dataGridViewSummary1.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dataGridViewSummary1.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dataGridViewSummary1.Rows[i].Index.ToString());

                            DataRowView dgr = dataGridViewSummary1.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Ffjzt.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_Ffjzt.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                if (DS_Ffjzt.Tables[0].Rows[j]["zyzt"].ToString() == common_file.common_fjzt.gjf && DS_Ffjzt.Tables[0].Rows[j]["zyzt_second"].ToString() == "")
                                {
                                    //id, yydh, qymc, jdlh, jdlh_name, jdcs, jdcs_name, 
                                    //fjrb, fjrb_code, fjbh, fjdh, dhfj, bz, add_edit_delete, xxzs
                                    string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                                    string[] args = new string[15];
                                    args[0] = DS_Ffjzt.Tables[0].Rows[j]["id"].ToString();
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
                                    args[13] = common_file.common_app.get_delete;
                                    args[14] = common_file.common_app.xxzs;
                                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Ffjzt_add_edit_delete", args);

                                    Hotel_app.Server.Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_services = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();
                                    string   result=Ffjzt_add_edit_services.Ffjzt_add_edit_delete(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString());

                                    if (result== common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
                                    {
                                        s = common_file.common_app.get_suc;
                                    }
                                    else s = common_file.common_app.get_failure;
                                }
                                else
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, DS_Ffjzt.Tables[0].Rows[j]["fjbh"].ToString() + "处于不能删除状态中！");
                                }
                            }
                            //common_file.common_app.Message_box_show(common_file.common_app.message_title, dataGridViewSummary1.Rows[i].Index.ToString());

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

        private void b_research_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_ftcx_gl", common_file.common_app.user_type) == false)
            { return; }
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            refresh_app();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_ftcx_xg", common_file.common_app.user_type) == false)
            { return; }
            if (dataGridViewSummary1.CurrentRow != null)
            {
                int i = dataGridViewSummary1.CurrentRow.Index;
                DataRowView dgr = dataGridViewSummary1.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Ffjzt.Tables[0].Rows.IndexOf(dgr.Row);



                if (DS_Ffjzt.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Ffjzt_add_edit(this);
                    Ffjzt_add_edit_new.Left = common_file.common_app.x();
                    Ffjzt_add_edit_new.Top = common_file.common_app.y();
                    Ffjzt_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Ffjzt_add_edit_new.Ffjzt_id = DS_Ffjzt.Tables[0].Rows[i]["ID"].ToString();
                    Ffjzt_add_edit_new.get_fjrb_code = DS_Ffjzt.Tables[0].Rows[i]["fjrb_code"].ToString();
                    Ffjzt_add_edit_new.tB_bz.Text = DS_Ffjzt.Tables[0].Rows[i]["bz"].ToString();
                    Ffjzt_add_edit_new.tB_dhfj.Text = DS_Ffjzt.Tables[0].Rows[i]["dhfj"].ToString();
                    Ffjzt_add_edit_new.tB_fjbh.Text = DS_Ffjzt.Tables[0].Rows[i]["fjbh"].ToString();
                    Ffjzt_add_edit_new.tB_fjdh.Text = DS_Ffjzt.Tables[0].Rows[i]["fjdh"].ToString();
                    Ffjzt_add_edit_new.tB_fjrb.Text = DS_Ffjzt.Tables[0].Rows[i]["fjrb"].ToString();
                    Ffjzt_add_edit_new.tB_jdcs.Text = DS_Ffjzt.Tables[0].Rows[i]["jdcs"].ToString();
                    Ffjzt_add_edit_new.tB_jdcs_name.Text = DS_Ffjzt.Tables[0].Rows[i]["jdcs_name"].ToString();
                    Ffjzt_add_edit_new.tB_jdlh.Text = DS_Ffjzt.Tables[0].Rows[i]["jdlh"].ToString();
                    Ffjzt_add_edit_new.tB_jdlh_name.Text = DS_Ffjzt.Tables[0].Rows[i]["jdlh_name"].ToString();
                    Ffjzt_add_edit_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_ftcx_xz", common_file.common_app.user_type) == false)
            { return; }

            Ffjzt.Ffjzt_add_edit Ffjzt_add_edit_new = new Ffjzt_add_edit(this);
            Ffjzt_add_edit_new.Left = common_file.common_app.x();
            Ffjzt_add_edit_new.Top = common_file.common_app.y();
            Ffjzt_add_edit_new.judge_add_edit = common_file.common_app.get_add;
            Ffjzt_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();

        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        internal void loadInfo(string p)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}