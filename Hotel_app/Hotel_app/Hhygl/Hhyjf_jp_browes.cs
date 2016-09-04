using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyjf_jp_browes : Form
    {
        public DataSet DS_Hhyjfjp;
        Model.Hhyjf_jp M_Hhyjfjp = new Model.Hhyjf_jp();
        BLL.Hhyjf_jp B_Hhyjfjp = new BLL.Hhyjf_jp();
        public int dg_count = 0;
        public Hhyjf_jp_browes()
        {
            InitializeComponent();
            InitializeApp();
        }
        #region 自定义方法

        public void InitializeApp()
        {
            DS_Hhyjfjp = B_Hhyjfjp.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyjfjp.Tables[0];
            dg_count = DS_Hhyjfjp.Tables[0].Rows.Count;
            this.dg_hyjfjp.AutoGenerateColumns = false;
        }
        #endregion
        public void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Hhyjfjp = B_Hhyjfjp.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyjfjp.Tables[0];
            dg_count = DS_Hhyjfjp.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Hhygl.Hhyjf_jp_add_edit Hhyjf_jp_add_edit_new = new Hhyjf_jp_add_edit(this);
            Hhyjf_jp_add_edit_new.Left = common_file.common_app.x() - 200;
            Hhyjf_jp_add_edit_new.Top = common_file.common_app.y() - 100;
            Hhyjf_jp_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_hyjfjp.CurrentRow != null)
            {
                int i = dg_hyjfjp.CurrentRow.Index;

                DataRowView dgr = dg_hyjfjp.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Hhyjfjp.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Hhyjfjp.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Hhygl.Hhyjf_jp_add_edit Hhyjfjp_add_edit_new = new Hhyjf_jp_add_edit(this);
                    Hhyjfjp_add_edit_new.Left = common_file.common_app.x();
                    Hhyjfjp_add_edit_new.Top = common_file.common_app.y();
                    Hhyjfjp_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Hhyjfjp_add_edit_new.Hhyjfjp_id = DS_Hhyjfjp.Tables[0].Rows[i]["id"].ToString();


                    Hhyjfjp_add_edit_new.tB_classname.Text = DS_Hhyjfjp.Tables[0].Rows[i]["classname"].ToString();
                    Hhyjfjp_add_edit_new.tB_Title.Text = DS_Hhyjfjp.Tables[0].Rows[i]["Title"].ToString();
                    Hhyjfjp_add_edit_new.tB_dfjf.Text = DS_Hhyjfjp.Tables[0].Rows[i]["jpjf"].ToString();
                    Hhyjfjp_add_edit_new.tB_bz.Text = DS_Hhyjfjp.Tables[0].Rows[i]["bz"].ToString();


                    Hhyjfjp_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Hhyjfjp != null && DS_Hhyjfjp.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_hyjfjp.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_hyjfjp.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_hyjfjp.Rows[i].Index.ToString());

                            DataRowView dgr = dg_hyjfjp.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Hhyjfjp.Tables[0].Rows.IndexOf(dgr.Row);


                            if (DS_Hhyjfjp.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                string[] args = new string[13];
                                args[0] = DS_Hhyjfjp.Tables[0].Rows[j]["id"].ToString();
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
                                args[11] = common_file.common_app.get_delete;
                                args[12] = common_file.common_app.xxzs;

                                Hotel_app.Server.Hhygl.Hhyjf_jp Hhyjf_jp_services = new Hotel_app.Server.Hhygl.Hhyjf_jp();
                                string result = Hhyjf_jp_services.Hhyjfjp_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfjp_add_edit", args);
                                if (result== common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
                                {
                                    s = common_file.common_app.get_suc;
                                }
                                else s = common_file.common_app.get_failure;
                            }
                            else
                            {
                                //提示
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "你好,你没有选择任何信息");
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