using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyfj_browse : Form
    {
        public int dg_count = 0;

        public BLL.Hhyfj B_Hhyfj = new Hotel_app.BLL.Hhyfj();
        public DataSet DS_Hhyfj;
        public Hhyfj_browse()
        {
            InitializeComponent();
            InitializeApp();
        }
        public void InitializeApp()
        {
            DS_Hhyfj = B_Hhyfj.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyfj.Tables[0];
            dg_count = DS_Hhyfj.Tables[0].Rows.Count;
            this.dg_hyfj.AutoGenerateColumns = false;
        }
        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_Hhyfj = B_Hhyfj.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyfj.Tables[0];
            dg_count = DS_Hhyfj.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();

            Hhygl.Hhyfj_add_edit Hhyfj_add_edit_new = new Hhyfj_add_edit(this);
            //Hhyfj_add_edit_new.Left = common_file.common_app.x() - 200;
            //Hhyfj_add_edit_new.Top = common_file.common_app.y() - 100;
            Hhyfj_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            Hhyfj_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_hyfj.CurrentRow != null)
            {
                int i = dg_hyfj.CurrentRow.Index;
                DataRowView dgr = dg_hyfj.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Hhyfj.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Hhyfj.Tables[0].Rows[i]["id"].ToString() != "")
                {

                    Hhygl.Hhyfj_add_edit Hhyfj_add_edit_new = new Hhyfj_add_edit(this);
                    //Hhyfj_add_edit_new.Left = common_file.common_app.x() - 200;
                    //Hhyfj_add_edit_new.Top = common_file.common_app.y() - 100;
                    Hhyfj_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Hhyfj_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Hhyfj_add_edit_new.Hhyfj_id = DS_Hhyfj.Tables[0].Rows[i]["id"].ToString();

                    Hhyfj_add_edit_new.tB_fjrb.Text = DS_Hhyfj.Tables[0].Rows[i]["fjrb"].ToString();
                    Hhyfj_add_edit_new.tB_hyfj.Text = DS_Hhyfj.Tables[0].Rows[i]["hyfj"].ToString();
                    Hhyfj_add_edit_new.cB_hyrx.Text = DS_Hhyfj.Tables[0].Rows[i]["hyrx"].ToString();
                    Hhyfj_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Hhyfj != null && DS_Hhyfj.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_hyfj.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_hyfj.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_hyfj.Rows[i].Index.ToString());

                            DataRowView dgr = dg_hyfj.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Hhyfj.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_Hhyfj.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                object[] args = new object[9];
                                args[0] = DS_Hhyfj.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = "";
                                args[7] = common_file.common_app.get_delete;
                                args[8] = common_file.common_app.xxzs;

                                Hotel_app.Server.Hhygl.Hhyfj Hhyfj_services = new Hotel_app.Server.Hhygl.Hhyfj();
                                string result = Hhyfj_services.Hhyfj_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyfj_add_edit", args);
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
    }
}