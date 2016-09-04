using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_Applications_browes : Form
    {
        public YH_Roles_browse parent_form;
        Model.YH_Applications M_YH_App = new Model.YH_Applications();
        BLL.YH_Applications B_YH_App = new BLL.YH_Applications();
        BLL.YH_RolePermission B_YH_RoleP = new BLL.YH_RolePermission();
        public int dg_count = 0;//记录初期加载行数
        public DataSet DS_YH_Roles;

        public String R_lsbh = "";
        public String R_RolesName = "";

        public YH_Applications_browes()
        {
            InitializeComponent();
            InitializeApp();
        }

         #region 自定义方法
        public YH_Applications_browes(YH_Roles_browse Form_temp,string r_lsbh)
        {
            this.R_lsbh = r_lsbh;
            InitializeComponent();
            InitializeApp();
            this.parent_form = Form_temp;
        }
        #endregion

        #region 自定义方法

        public void InitializeApp()
        {

            DS_YH_Roles = B_YH_RoleP.GetList("ID>=0" + common_file.common_app.yydh_select + " and r_lsbh='" + R_lsbh + "' order by ID");
            bindingSource1.DataSource = DS_YH_Roles.Tables[0];
            dg_count = DS_YH_Roles.Tables[0].Rows.Count;
            this.dg_qxlb.AutoGenerateColumns = false;
        }
        #endregion
        //void bintxz()
        //{
        //    for (int i = 0; i < dg_qxlb.Rows.Count; i++)
        //    {
        //        string _selectValue = dg_qxlb.Rows[i].Cells["Column1"].EditedFormattedValue.ToString();
        //        if (_selectValue == "True")
        //        {

        //        }
        //    }
        //}

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            string s = common_file.common_app.get_failure;
            if (DS_YH_Roles != null && DS_YH_Roles.Tables[0].Rows.Count > 0)
            {
                int j = 0;
                for (int i = 0; i < dg_count; i++)
                {
                    //j = Convert.ToInt32(dg_qxlb.Rows[i].Index.ToString());

                    DataRowView dgr = dg_qxlb.Rows[i].DataBoundItem as DataRowView;
                    j = DS_YH_Roles.Tables[0].Rows.IndexOf(dgr.Row);


                     if (DS_YH_Roles.Tables[0].Rows[j]["id"].ToString() != "")
                     {
                         int id = int.Parse(DS_YH_Roles.Tables[0].Rows[j]["id"].ToString());
                         bool p_value = Convert.ToBoolean(DS_YH_Roles.Tables[0].Rows[j]["p_value"].ToString());
                         common_file.common_roles.Update_Role(id, p_value);

                         //string url = common_file.common_app.service_url + "Yhgl/Yhgl_app.asmx";
                         //string[] args = new string[11];
                         //args[0] = DS_YH_Roles.Tables[0].Rows[j]["id"].ToString();
                         //args[1] = common_file.common_app.yydh;
                         //args[2] = common_file.common_app.qymc;
                         //args[3] = R_lsbh;
                         //args[4] = R_RolesName;
                         //args[5] = DS_YH_Roles.Tables[0].Rows[j]["p_lsbh"].ToString();
                         //args[6] = DS_YH_Roles.Tables[0].Rows[j]["A_Appdr"].ToString();
                         //args[7] = DS_YH_Roles.Tables[0].Rows[j]["A_AppName"].ToString();
                         //args[8] = DS_YH_Roles.Tables[0].Rows[j]["p_value"].ToString(); ;
                         //args[9] = common_file.common_app.get_edit;
                         //args[10] = common_file.common_app.xxzs;
                         //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "YHRolesp_add_edit", args);
                         //if (result.ToString() == common_file.common_app.get_suc)
                         //{
                         //    s = common_file.common_app.get_suc;
                         //}
                         //else s = common_file.common_app.get_failure;

                         //common_file.common_app.Message_box_show(common_file.common_app.message_title, dataGridViewSummary1.Rows[i].Index.ToString());
                     }
                }
               common_file.common_app.Message_box_show(common_file.common_app.message_title, "受权成功！");
               
          

            }
            Cursor.Current = Cursors.Default;


        }

        private void b_addmenu_Click(object sender, EventArgs e)
        {
            YH_Applincations_add YH_Applincations_add_new = new YH_Applincations_add();
            YH_Applincations_add_new.StartPosition = FormStartPosition.CenterScreen;
            YH_Applincations_add_new.ShowDialog();
        }
        //void Save_new()
        //{
        //    //id,yydh,qymc,jbxs,hyrx,dfjf,is_top,is_select
        //    int judge_save = 3;//3保存，其余不保存
        //    judge_save = common_file.common_app.get_judge_repeat("YH_Roles", "R_lsbh", "编号已经存在了", tB_Rlsbh.Text, judge_add_edit, YH_Roles_id);
        //    judge_save = common_file.common_app.get_judge_repeat("YH_Roles", "R_RolesName", "角色名称已经存在了", tB_RolesName.Text, judge_add_edit, YH_Roles_id);
        //    if (judge_save == 3)
        //    {
        //        string url = common_file.common_app.service_url + "Yhgl/Yhgl_app.asmx";
        //        object[] args = new object[8];
        //        args[0] = YH_Roles_id;
        //        args[1] = common_file.common_app.yydh;
        //        args[2] = common_file.common_app.qymc;
        //        args[3] = tB_Rlsbh.Text.Trim().Replace("'", "-");
        //        args[4] = tB_RolesName.Text.Trim().Replace("'", "-");
        //        args[5] = tB_bz.Text.Trim().Replace("'", "-");
        //        args[6] = judge_add_edit;
        //        args[7] = common_file.common_app.xxzs;
        //        object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "YHRoles_add_edit", args);
        //        if (result.ToString() == common_file.common_app.get_suc)
        //        {
        //            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
        //            if (judge_add_edit == common_file.common_app.get_add) { parent_form.refresh_app(); tB_Rlsbh.Text = ""; tB_Rlsbh.Focus(); tB_RolesName.Text = ""; tB_bz.Text = ""; }
        //            else if (judge_add_edit == common_file.common_app.get_edit)
        //            {
        //                parent_form.refresh_app();
        //                this.Close();
        //            }

        //        }
        //        else
        //            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

        //    }
        //}
    }
}