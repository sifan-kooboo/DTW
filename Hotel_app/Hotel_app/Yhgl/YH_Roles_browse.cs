using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_Roles_browse : Form
    {
        Model.YH_Roles M_YH_Roles = new Model.YH_Roles();
        BLL.YH_Roles B_YH_Roles = new BLL.YH_Roles();
        public int dg_count = 0;//记录初期加载行数
        public DataSet DS_YH_Roles;
        public YH_Roles_browse()
        {
            InitializeComponent();
            InitializeApp();
        }
        #region 自定义方法

        public void InitializeApp()
        {
            DS_YH_Roles = B_YH_Roles.GetList("ID>=0" + common_file.common_app.yydh_select + " order by ID");
            bindingSource1.DataSource = DS_YH_Roles.Tables[0];
            dg_count = DS_YH_Roles.Tables[0].Rows.Count;
            this.dg_yhroles.AutoGenerateColumns = false;
        }
        #endregion
        public void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_YH_Roles = B_YH_Roles.GetList("ID>=0" + common_file.common_app.yydh_select + " order by ID");
            bindingSource1.DataSource = DS_YH_Roles.Tables[0];
            dg_count = DS_YH_Roles.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yhgl.YH_Roles_add_edit YH_Roles_add_edit_new = new YH_Roles_add_edit(this);
            YH_Roles_add_edit_new.Left = common_file.common_app.x()+50;
            YH_Roles_add_edit_new.Top = common_file.common_app.y() - 100;
            YH_Roles_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_yhroles.CurrentRow != null)
            {
                int i = dg_yhroles.CurrentRow.Index;

                DataRowView dgr = dg_yhroles.CurrentRow.DataBoundItem as DataRowView;
                i = DS_YH_Roles.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_YH_Roles.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Yhgl.YH_Roles_add_edit YH_Roles_add_edit_new = new YH_Roles_add_edit(this);
                    YH_Roles_add_edit_new.Left = common_file.common_app.x()+50;
                    YH_Roles_add_edit_new.Top = common_file.common_app.y() - 100;
                    YH_Roles_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    YH_Roles_add_edit_new.YH_Roles_id = DS_YH_Roles.Tables[0].Rows[i]["id"].ToString();
                    YH_Roles_add_edit_new.tB_Rlsbh.Text = DS_YH_Roles.Tables[0].Rows[i]["R_lsbh"].ToString();
                    YH_Roles_add_edit_new.tB_RolesName.Text = DS_YH_Roles.Tables[0].Rows[i]["R_RolesName"].ToString();
                    YH_Roles_add_edit_new.tB_bz.Text = DS_YH_Roles.Tables[0].Rows[i]["R_Bz"].ToString();
                    YH_Roles_add_edit_new.tB_ts.Text = DS_YH_Roles.Tables[0].Rows[i]["R_ts"].ToString();
                    YH_Roles_add_edit_new.tB_Rlsbh.Enabled = false;
                    YH_Roles_add_edit_new.tB_RolesName.Enabled = false;

                    YH_Roles_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_YH_Roles != null && DS_YH_Roles.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_yhroles.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_yhroles.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_yhroles.Rows[i].Index.ToString());


                            DataRowView dgr = dg_yhroles.Rows[i].DataBoundItem as DataRowView;
                            j = DS_YH_Roles.Tables[0].Rows.IndexOf(dgr.Row);



                            if (DS_YH_Roles.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Yhgl/Yhgl_app.asmx";
                                string[] args = new string[9];
                                args[0] = DS_YH_Roles.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = "";
                                args[7] = common_file.common_app.get_delete;
                                args[8] = common_file.common_app.xxzs;
                                Hotel_app.Server.Yhgl.YH_Roles YH_Roles_services = new Hotel_app.Server.Yhgl.YH_Roles();
                                string result = YH_Roles_services.YHRoles_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());

                               // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "YHRoles_add_edit", args);
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

        private void bt_roles_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_yhroles.CurrentRow != null)
            {
                int i = dg_yhroles.CurrentRow.Index;

                DataRowView dgr = dg_yhroles.Rows[i].DataBoundItem as DataRowView;
                i = DS_YH_Roles.Tables[0].Rows.IndexOf(dgr.Row);



                if (DS_YH_Roles.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    string r_lsbh_value=DS_YH_Roles.Tables[0].Rows[i]["R_lsbh"].ToString();
                    Yhgl.YH_Applications_browes YH_Applications_browes_new = new YH_Applications_browes(this,r_lsbh_value);
                    YH_Applications_browes_new.StartPosition = FormStartPosition.CenterScreen;
                    YH_Applications_browes_new.R_lsbh = DS_YH_Roles.Tables[0].Rows[i]["R_lsbh"].ToString();
                    YH_Applications_browes_new.R_RolesName = DS_YH_Roles.Tables[0].Rows[i]["R_RolesName"].ToString();
                    YH_Applications_browes_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void Bt_copy_Click(object sender, EventArgs e)
        {
            Yhgl.YH_Copy YH_Copy_new = new YH_Copy();
            YH_Copy_new.StartPosition = FormStartPosition.CenterScreen;
           
            YH_Copy_new.ShowDialog();
        }
    }
}