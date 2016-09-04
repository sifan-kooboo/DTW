using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Hotel_app.Yhgl
{
    public partial class YH_Roles_add_edit : Form
    {
        public YH_Roles_browse parent_form;
        public string YH_Roles_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        Model.YH_Roles M_YH_Roles = new Model.YH_Roles();
        BLL.YH_Roles B_YH_Roles = new BLL.YH_Roles();
        public YH_Roles_add_edit()
        {
            InitializeComponent();
        }
        #region 自定义方法
        public YH_Roles_add_edit(YH_Roles_browse Form_temp)
        {
           
            InitializeComponent();
            this.parent_form = Form_temp;
            
        }
        #endregion
        private void b_save_Click(object sender, EventArgs e)
        {




            common_file.common_app.get_czsj();
            if (tB_Rlsbh.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "编号不能为空");
                tB_Rlsbh.Focus();
            }
            else if (tB_RolesName.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "角色名不能为空");
                tB_RolesName.Focus();

            }

            else
            {
                Save_new();
            }
            Cursor.Current = Cursors.Default;


        }
        void Save_new()
        {
            //id,yydh,qymc,jbxs,hyrx,dfjf,is_top,is_select
            int judge_save = 3;//3保存，其余不保存

          
            judge_save = common_file.common_app.get_judge_repeat("YH_Roles", "R_lsbh", "编号已经存在了", tB_Rlsbh.Text, judge_add_edit, YH_Roles_id);

            if (judge_save == 3)
            {
                judge_save = common_file.common_app.get_judge_repeat("YH_Roles", "R_RolesName", "角色名称已经存在了", tB_RolesName.Text, judge_add_edit, YH_Roles_id);
            }
            if (judge_save == 3)
            {

                if (judge_add_edit == common_file.common_app.get_add)
                {
                    string bz_value = tB_bz.Text.Trim().Replace("'", "-");
                    string RolesName_value = this.tB_RolesName.Text;
                    int ts_value = int.Parse(this.tB_ts.Text);
                    string Rlsbh_value = this.tB_Rlsbh.Text;
                    bool f = common_file.common_roles.YH_Roles_Add(common_file.common_app.yydh, common_file.common_app.qymc, Rlsbh_value, RolesName_value, bz_value, ts_value);
                    if (f)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                       
                            parent_form.refresh_app(); 
                            tB_Rlsbh.Text = ""; 
                            tB_Rlsbh.Focus(); 
                            tB_RolesName.Text = "";
                            tB_bz.Text = "";
                

                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                    }
                }
                else if (judge_add_edit == common_file.common_app.get_edit)
                {

                    string url = common_file.common_app.service_url + "Yhgl/Yhgl_app.asmx";
                    object[] args = new object[9];
                    args[0] = YH_Roles_id;
                    args[1] = common_file.common_app.yydh;
                    args[2] = common_file.common_app.qymc;
                    args[3] = tB_Rlsbh.Text.Trim().Replace("'", "-");
                    args[4] = tB_RolesName.Text.Trim().Replace("'", "-");
                    args[5] = tB_bz.Text.Trim().Replace("'", "-");
                    args[6] = tB_ts.Text.Trim().Replace("'", "-");
                    args[7] = judge_add_edit;
                    args[8] = common_file.common_app.xxzs;

                    Hotel_app.Server.Yhgl.YH_Roles YH_Roles_services = new Hotel_app.Server.Yhgl.YH_Roles();
                    string result = YH_Roles_services.YHRoles_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());
                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "YHRoles_add_edit", args);
                    if (result== common_file.common_app.get_suc)
                    {
                        string p_lshb_value = tB_Rlsbh.Text.Trim();
                        string r_RoleN_value = tB_RolesName.Text.Trim();
                        //把所有权限写到角色表里p_value=0;

                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                        
                            parent_form.refresh_app();
                            this.Close();
                 




                    }
                    else
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                }
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}