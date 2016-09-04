using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyjb_browse : Form
    {
        Model.Hhyjb M_Hhyjb = new Model.Hhyjb();
        BLL.Hhyjb B_Hhyjb = new BLL.Hhyjb();
        public int dg_count = 0;//记录初期加载行数
        public DataSet DS_Hhyjb;
        public Hhyjb_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 自定义方法

        public void InitializeApp()
        {
            DS_Hhyjb = B_Hhyjb.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyjb.Tables[0];
            dg_count = DS_Hhyjb.Tables[0].Rows.Count;
            this.dg_hyjb.AutoGenerateColumns = false;
        }
        #endregion
        public void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Hhyjb = B_Hhyjb.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyjb.Tables[0];
            dg_count = DS_Hhyjb.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Hhygl.Hhyjb_add_edit Hhyjb_add_edit_new = new Hhyjb_add_edit(this);
            Hhyjb_add_edit_new.Left = common_file.common_app.x() - 200;
            Hhyjb_add_edit_new.Top = common_file.common_app.y() - 100;
            Hhyjb_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_hyjb.CurrentRow != null)
            {
                int i = dg_hyjb.CurrentRow.Index;

                DataRowView dgr = dg_hyjb.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Hhyjb.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Hhyjb.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Hhygl.Hhyjb_add_edit Hhyjb_add_edit_new = new Hhyjb_add_edit(this);
                    Hhyjb_add_edit_new.Left = common_file.common_app.x() - 200;
                    Hhyjb_add_edit_new.Top = common_file.common_app.y() - 100;
                    Hhyjb_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Hhyjb_add_edit_new.Hhyjb_id = DS_Hhyjb.Tables[0].Rows[i]["id"].ToString();
                    Hhyjb_add_edit_new.tB_dfjf.Text = DS_Hhyjb.Tables[0].Rows[i]["dfjf"].ToString();
                    Hhyjb_add_edit_new.tB_hyrx.Text = DS_Hhyjb.Tables[0].Rows[i]["hyrx"].ToString();
                    Hhyjb_add_edit_new.tB_jbxs.Text = DS_Hhyjb.Tables[0].Rows[i]["jbxs"].ToString();
                    Hhyjb_add_edit_new.tB_jbxs.Enabled = false;

                    Hhyjb_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Hhyjb != null && DS_Hhyjb.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_hyjb.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_hyjb.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_hyjb.Rows[i].Index.ToString());

                            DataRowView dgr = dg_hyjb.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Hhyjb.Tables[0].Rows.IndexOf(dgr.Row);


                            if (DS_Hhyjb.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                string[] args = new string[8];
                                args[0] = DS_Hhyjb.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = common_file.common_app.get_delete;
                                args[7] = common_file.common_app.xxzs;

                                Hotel_app.Server.Hhygl.Hhyjb Hhyjb_services = new Hotel_app.Server.Hhygl.Hhyjb();
                                string result = Hhyjb_services.Hhyjb_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString());

                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjb_add_edit", args);
                                if (result== common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
                                {
                                    s = common_file.common_app.get_suc;
                                }
                                else s = common_file.common_app.get_failure;
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
    }
}