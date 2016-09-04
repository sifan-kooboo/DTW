using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace Hotel_app.Yhgl
{
    public partial class YH_User_add_edit : Form
    {
        BLL.YH_Roles B_YH_Roles = new BLL.YH_Roles();
        Model.YH_Roles M_YH_Roles = new Hotel_app.Model.YH_Roles();
        BLL.YH_user B_YH_user = new BLL.YH_user();
        public string YH_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public YH_User_browse parent_form;//传递父窗体

        public YH_User_add_edit()
        {
            InitializeComponent();
            BindRole();
            BindBm();
        }
        public YH_User_add_edit(YH_User_browse F_temp)
        {
            InitializeComponent();
            BindRole();
            BindBm();
            parent_form = F_temp;
        }
       
        private void BindRole()
        {
            cB_Role.Items.Clear();
            
            List<Model.YH_Roles> list = B_YH_Roles.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_Role.Items.Add(list[i].R_RolesName.ToString());
                }
            }
       
        }
        private void BindBm()
        {
            BLL.YH_bmsz B_YH_bmsz=new BLL.YH_bmsz();

            cB_bm.Items.Clear();
            List<Model.YH_bmsz> list = B_YH_bmsz.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_bm.Items.Add(list[i].yhbm.ToString());
                }
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_yhbh.Text== "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，用户编号不能为空！");
                tB_yhbh.Focus();
            }
            else if (tB_yhxm.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，用户名不能为空！");
                tB_yhxm.Focus();
            }
            else
            {
                Save_new();
 
            }
            Cursor.Current = Cursors.Default;
        }
        //根据用户名读取用户编号
        public string GetR_lsbh(string Rname)
        {
            M_YH_Roles = B_YH_Roles.GetModelList("R_RolesName='" + Rname + "'")[0];
            return M_YH_Roles.R_lsbh;
        }
        void Save_new()
        {
            //id, yydh, qymc, yhbh, yhxm, yhmm, R_lsbh, R_RolesName, add_edit_delete, xxzs
            int judge_save = 3;//3保存，其余不保存

            string PassWord_value = common_file.common_yhuser.GetUser_mm("123456");
                judge_save = common_file.common_app.get_judge_repeat("YH_user", "yhbh", "用户编号已经存在了", tB_yhbh.Text, judge_add_edit, YH_id);
                if (judge_save == 3)
                {
                    judge_save = common_file.common_app.get_judge_repeat("YH_user", "yhxm", "用户姓名已经存在了", tB_yhxm.Text, judge_add_edit, YH_id);
                }

            if (judge_save == 3)
            {
                string strRName = this.cB_Role.Text;
                string strYhbm = this.cB_bm.Text;//用户部门
                string url = common_file.common_app.service_url + "Yhgl/Yhgl_app.asmx";
                object[] args = new object[11];
                args[0] = YH_id;
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] =tB_yhbh.Text.Trim().Replace("'", "-");
                args[4] =tB_yhxm.Text.Trim().Replace("'", "-");
                args[5] = PassWord_value;
                args[6] = GetR_lsbh(strRName);
                args[7] = strRName;
                args[8] = strYhbm;
                args[9] = judge_add_edit;
                args[10] = common_file.common_app.xxzs;

                Hotel_app.Server.Yhgl.YH_User yh_user_services = new Hotel_app.Server.Yhgl.YH_User();
                string result = yh_user_services.YHUser_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString());

                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "YHUser_add_edit", args);
                if (result == common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                    if (judge_add_edit == common_file.common_app.get_add)
                    { 
                        parent_form.refresh_app(); 
                        tB_yhbh.Text = ""; 
                        tB_yhbh.Focus(); 
                        tB_yhxm.Text = "";
                    }
                    else if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        parent_form.refresh_app();
                        this.Close();
                    }

                }
                else
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}