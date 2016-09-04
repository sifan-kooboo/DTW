using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyjf_bl_browse : Form
    {
        Model.Hhyjf_bl M_Hhyjfbl = new Model.Hhyjf_bl();
        BLL.Hhyjf_bl B_Hhyjfbl = new BLL.Hhyjf_bl();
        public int dg_count = 0;//记录初期加载行数
        public DataSet DS_Hhyjfbl;
        public Hhyjf_bl_browse()
        {
            InitializeComponent();
            InitializeApp();
        }
        #region 自定义方法

        public void InitializeApp()
        {
            DS_Hhyjfbl = B_Hhyjfbl.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyjfbl.Tables[0];
            dg_count = DS_Hhyjfbl.Tables[0].Rows.Count;
            this.dg_hyjfbl.AutoGenerateColumns = false;
        }
        #endregion
        public void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Hhyjfbl = B_Hhyjfbl.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Hhyjfbl.Tables[0];
            dg_count = DS_Hhyjfbl.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }
        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Hhygl.Hhyjf_bl_add_edit Hhyjf_bl_add_edit_new = new Hhyjf_bl_add_edit(this);
            Hhyjf_bl_add_edit_new.Left = common_file.common_app.x() - 200;
            Hhyjf_bl_add_edit_new.Top = common_file.common_app.y() - 100;
            Hhyjf_bl_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_hyjfbl.CurrentRow != null)
            {
                int i = dg_hyjfbl.CurrentRow.Index;
                DataRowView dgr = dg_hyjfbl.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Hhyjfbl.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Hhyjfbl.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Hhygl.Hhyjf_bl_add_edit Hhyjfbl_add_edit_new = new Hhyjf_bl_add_edit(this);
                    Hhyjfbl_add_edit_new.Left = common_file.common_app.x() - 200;
                    Hhyjfbl_add_edit_new.Top = common_file.common_app.y() - 100;
                    Hhyjfbl_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Hhyjfbl_add_edit_new.Hhyjfbl_id = DS_Hhyjfbl.Tables[0].Rows[i]["id"].ToString();
                    Hhyjfbl_add_edit_new.tB_jfbl.Text = DS_Hhyjfbl.Tables[0].Rows[i]["jfbl"].ToString();
                    Hhyjfbl_add_edit_new.cB_hyrx.Text = DS_Hhyjfbl.Tables[0].Rows[i]["hyrx"].ToString();
                    Hhyjfbl_add_edit_new.cB_krly.Text = DS_Hhyjfbl.Tables[0].Rows[i]["krly"].ToString();
                    

                    Hhyjfbl_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Hhyjfbl != null && DS_Hhyjfbl.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_hyjfbl.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_hyjfbl.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_hyjfbl.Rows[i].Index.ToString());

                            DataRowView dgr = dg_hyjfbl.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Hhyjfbl.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_Hhyjfbl.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                string[] args = new string[9];
                                args[0] = DS_Hhyjfbl.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = "";
                                args[7] = common_file.common_app.get_delete;
                                args[8] = common_file.common_app.xxzs;

                                Hotel_app.Server.Hhygl.Hhyjf_bl Hhyjf_bl_services = new Hotel_app.Server.Hhygl.Hhyjf_bl();
                               string result=Hhyjf_bl_services.Hhyjfbl_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());

                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfbl_add_edit", args);
                                if (result== common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
                                {
                                    s = common_file.common_app.get_suc;
                                }
                                else s = common_file.common_app.get_failure;
                            }
                        }
                        else
                        {
                            //提示
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "你好,你没有选择任何信息");
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