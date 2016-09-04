using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yyxzx
{
    public partial class Yxydw_fjrb_browse : Form
    {
        public int dg_count = 0;

        public BLL.Yxydw_fjrb B_xydw_krly = new Hotel_app.BLL.Yxydw_fjrb();
        public DataSet DS_xydw_krly;
        public Yxydw_fjrb_browse()
        {
            InitializeComponent();
            InitializeApp();
        }
        public void InitializeApp()
        {
            DS_xydw_krly = B_xydw_krly.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_xydw_krly.Tables[0];
            dg_count = DS_xydw_krly.Tables[0].Rows.Count;
            this.dg_xydwkrly.AutoGenerateColumns = false;
        }
        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_xydw_krly = B_xydw_krly.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_xydw_krly.Tables[0];
            dg_count = DS_xydw_krly.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yyxzx.Yxydw_fjrb_add_edit Yxydw_fjrb_add_edit_new = new Yxydw_fjrb_add_edit(this);
            Yxydw_fjrb_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            Yxydw_fjrb_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_xydwkrly.CurrentRow != null)
            {
                int i = dg_xydwkrly.CurrentRow.Index;

                DataRowView dgr = dg_xydwkrly.CurrentRow.DataBoundItem as DataRowView;
                i = DS_xydw_krly.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_xydw_krly.Tables[0].Rows[i]["id"].ToString() != "")
                {

                    Yyxzx.Yxydw_fjrb_add_edit Yxydw_fjrb_add_edit_new = new Yxydw_fjrb_add_edit(this);
                    Yxydw_fjrb_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    Yxydw_fjrb_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Yxydw_fjrb_add_edit_new.Hhyfj_id = DS_xydw_krly.Tables[0].Rows[i]["id"].ToString();
                    Yxydw_fjrb_add_edit_new.tB_fjrb.Text = DS_xydw_krly.Tables[0].Rows[i]["fjrb"].ToString();
                    Yxydw_fjrb_add_edit_new.tB_hyfj.Text = DS_xydw_krly.Tables[0].Rows[i]["sjjg"].ToString();
                    Yxydw_fjrb_add_edit_new.tB_xydw.Text = DS_xydw_krly.Tables[0].Rows[i]["xydw"].ToString();
                    Yxydw_fjrb_add_edit_new.xyh = DS_xydw_krly.Tables[0].Rows[i]["xyh"].ToString();
                    Yxydw_fjrb_add_edit_new.fjrb_code = DS_xydw_krly.Tables[0].Rows[i]["fjrb_code"].ToString();
                    Yxydw_fjrb_add_edit_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_xydw_krly != null && DS_xydw_krly.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_xydwkrly.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_xydwkrly.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_xydwkrly.Rows[i].Index.ToString());
                            DataRowView dgr = dg_xydwkrly.Rows[i].DataBoundItem as DataRowView;
                            j = DS_xydw_krly.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_xydw_krly.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Yyxzx/Yyxzx_app.asmx";
                                object[] args = new object[10];
                                args[0] = DS_xydw_krly.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = "";
                                args[7] = "";
                                args[8] = common_file.common_app.get_delete;
                                args[9] = common_file.common_app.xxzs;

                                Hotel_app.Server.Yyxzx.Yxydw_fjrb Yxydw_fjrb_services = new Hotel_app.Server.Yyxzx.Yxydw_fjrb();
                                string result = Yxydw_fjrb_services.Yxydw_fjrb_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString());
                               // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Yxydw_fjrb_add_edit", args);
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

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tB_select_TextChanged(object sender, EventArgs e)
        {
            string strSelect = this.tB_select.Text.Trim();
            string strSql = "id>=0" + common_file.common_app.yydh_select + " ";

            strSql += " and (xyh like '%" + strSelect + "%' or xydw like '%" + strSelect + "%' or fjrb like '%" + strSelect + "%' or fjrb_code like '%" + strSelect + "%' or sjjg like '%" + strSelect + "%'   )";
            DS_xydw_krly = B_xydw_krly.GetList(strSql);
            bindingSource1.DataSource = DS_xydw_krly.Tables[0];
            dg_count = DS_xydw_krly.Tables[0].Rows.Count;
            this.dg_xydwkrly.AutoGenerateColumns = false;
        }

    }
}