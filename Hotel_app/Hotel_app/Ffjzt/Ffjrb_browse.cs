using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjrb_browse : Form
    {

        public int dg_count = 0;

        public BLL.Ffjrb B_Ffjrb = new Hotel_app.BLL.Ffjrb();
        public DataSet DS_Ffjrb;
        public Ffjrb_browse()
        {
            InitializeComponent();

            InitializeApp();

        }

        public void InitializeApp()
        {
            DS_Ffjrb = B_Ffjrb.GetList("id>=0" + common_file.common_app.yydh_select + " order by fjrb");
            bindingSource1.DataSource = DS_Ffjrb.Tables[0];
            dg_count = DS_Ffjrb.Tables[0].Rows.Count;
            this.dataGridViewSummary1.AutoGenerateColumns = false;
        }
        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_Ffjrb = B_Ffjrb.GetList("id>=0" + common_file.common_app.yydh_select + " order by fjrb");
            bindingSource1.DataSource = DS_Ffjrb.Tables[0];
            dg_count = DS_Ffjrb.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Ffjzt.Ffjrb_add_edit Ffjrb_add_edit_new = new Ffjrb_add_edit(this);
            Ffjrb_add_edit_new.Left = common_file.common_app.x() - 200;
            Ffjrb_add_edit_new.Top = common_file.common_app.y() - 100;
            Ffjrb_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dataGridViewSummary1.CurrentRow != null)
            {
                int i = dataGridViewSummary1.CurrentRow.Index;
                DataRowView dgr = dataGridViewSummary1.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Ffjrb.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Ffjrb.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Ffjzt.Ffjrb_add_edit Ffjrb_add_edit_new = new Ffjrb_add_edit(this);
                    Ffjrb_add_edit_new.Left = common_file.common_app.x() - 200;
                    Ffjrb_add_edit_new.Top = common_file.common_app.y() - 100;
                    Ffjrb_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Ffjrb_add_edit_new.Ffjrb_id = DS_Ffjrb.Tables[0].Rows[i]["id"].ToString();
                    Ffjrb_add_edit_new.tB_fjrb_code.Text = DS_Ffjrb.Tables[0].Rows[i]["fjrb_code"].ToString();
                    Ffjrb_add_edit_new.tB_fjrb.Text = DS_Ffjrb.Tables[0].Rows[i]["fjrb"].ToString();
                    Ffjrb_add_edit_new.tB_sjjg.Text = DS_Ffjrb.Tables[0].Rows[i]["sjjg"].ToString();
                    Ffjrb_add_edit_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Ffjrb != null && DS_Ffjrb.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dataGridViewSummary1.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dataGridViewSummary1.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j =Convert.ToInt32( dataGridViewSummary1.Rows[i].Index.ToString());
                            DataRowView dgr = dataGridViewSummary1.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Ffjrb.Tables[0].Rows.IndexOf(dgr.Row);


                            if (DS_Ffjrb.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                                string[] args = new string[9];
                                args[0] = DS_Ffjrb.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] ="";
                                args[7] = common_file.common_app.get_delete;
                                args[8] = common_file.common_app.xxzs;
                                Hotel_app.Server.Ffjzt.Ffjzt_add_edit Ffjzt_app_services = new Hotel_app.Server.Ffjzt.Ffjzt_add_edit();
                                string result = Ffjzt_app_services.Ffjrb_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Ffjrb_add_edit", args);
                                if (result == common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
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