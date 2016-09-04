using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_User_browse : Form
    {
        Model.YH_user M_YH_User = new Model.YH_user();
        BLL.YH_user B_YH_User = new BLL.YH_user();
        public int dg_count = 0;//记录初期加载行数
        public DataSet DS_YH_User;
        public YH_User_browse()
        {
            InitializeComponent();
            InitializeApp();
        }


        #region 自定义方法

        public void InitializeApp()
        {
            DS_YH_User = B_YH_User.GetList("ID>=0" + common_file.common_app.yydh_select + " order by ID");
            bindingSource1.DataSource = DS_YH_User.Tables[0];
            dg_count = DS_YH_User.Tables[0].Rows.Count;
            this.dg_yhgl.AutoGenerateColumns = false;
        }
        #endregion
        public void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_YH_User = B_YH_User.GetList("ID>=0" + common_file.common_app.yydh_select + " order by ID");
            bindingSource1.DataSource = DS_YH_User.Tables[0];
            dg_count = DS_YH_User.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yhgl.YH_User_add_edit YH_User_add_edit_new = new YH_User_add_edit(this);
            YH_User_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            YH_User_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            //int i = dg_yhgl.CurrentRow.Index;
            if (dg_yhgl.CurrentRow != null)
            {
                DataRowView dgr = dg_yhgl.CurrentRow.DataBoundItem as DataRowView;
                int i = DS_YH_User.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_YH_User.Tables[0].Rows[i]["id"].ToString() != "")
                {

                    Yhgl.YH_User_add_edit YH_User_add_edit_new = new YH_User_add_edit(this);
                    YH_User_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                    YH_User_add_edit_new.judge_add_edit = common_file.common_app.get_edit;

                    YH_User_add_edit_new.tB_yhbh.Text = DS_YH_User.Tables[0].Rows[i]["yhbh"].ToString();
                    YH_User_add_edit_new.tB_yhxm.Text = DS_YH_User.Tables[0].Rows[i]["yhxm"].ToString();
                    YH_User_add_edit_new.cB_Role.Text = DS_YH_User.Tables[0].Rows[i]["RoleName"].ToString();
                    YH_User_add_edit_new.cB_bm.Text = DS_YH_User.Tables[0].Rows[i]["yhbm"].ToString();
                    YH_User_add_edit_new.YH_id = DS_YH_User.Tables[0].Rows[i]["ID"].ToString();
                    YH_User_add_edit_new.tB_yhbh.Enabled = false;
                    YH_User_add_edit_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_YH_User != null && DS_YH_User.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_yhgl.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_yhgl.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_yhgl.Rows[i].Index.ToString());

                            DataRowView dgr = dg_yhgl.Rows[i].DataBoundItem as DataRowView;
                            j = DS_YH_User.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_YH_User.Tables[0].Rows[j]["id"].ToString() != "")
                            {//id, yydh, qymc, yhbh, yhxm, yhmm, R_lsbh, R_RolesName,yhbm,add_edit_delete, xxzs
                                string url = common_file.common_app.service_url + "Yhgl/Yhgl_app.asmx";
                                object[] args = new object[11];
                                args[0] = DS_YH_User.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = "";
                                args[7] = "";
                                args[8] = "";
                                args[9] = common_file.common_app.get_delete;
                                args[10] = common_file.common_app.xxzs;

                                Hotel_app.Server.Yhgl.YH_User yh_user_services = new Hotel_app.Server.Yhgl.YH_User();
                                string result = yh_user_services.YHUser_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "YHUser_add_edit", args);
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