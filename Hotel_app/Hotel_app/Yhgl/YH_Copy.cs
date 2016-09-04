using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_Copy : Form
    {
        BLL.YH_Roles B_YH_Roles = new BLL.YH_Roles();
        Model.YH_Roles M_YH_Roles = new Model.YH_Roles();
   
        public YH_Copy()
        {
            InitializeComponent();
            BindRole(cB_Role);
            BindRole(cB_Roleb);
        }
        public void BindRole(ComboBox Roles)
        {
            Roles.Items.Clear();

            List<Model.YH_Roles> list = B_YH_Roles.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Roles.Items.Add(list[i].R_RolesName.ToString());
                }
            }

        }
        //根据用户名读取用户编号
        public string GetR_lsbh(string Rname)
        {
            M_YH_Roles = B_YH_Roles.GetModelList("R_RolesName='" + Rname + "'")[0];
            return M_YH_Roles.R_lsbh;
        }
        private void b_save_Click(object sender, EventArgs e)
        {
            //string yydh, string qymc, string R_lsbh, string R_lsbh_new, string R_rolesname

            common_file.common_app.get_czsj();
            if (cB_Role.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起！复制角色不能为空。");
                cB_Role.Focus();
            }
            else if (cB_Roleb.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起！粘贴角色不能为空。");
                cB_Roleb.Focus();

            }
            else
            {
                Save_new();
 
            }
            Cursor.Current = Cursors.Default;

        }
        void Save_new()
        {
            string r_lsbh_value = GetR_lsbh(cB_Role.Text);
            string r_lsbh_new_value = GetR_lsbh(cB_Roleb.Text);
            string R_rolesname_value = cB_Roleb.Text;
            bool f = common_file.common_roles.Copy_Roles(common_file.common_app.yydh, common_file.common_app.qymc, r_lsbh_value, r_lsbh_new_value, R_rolesname_value);
            if (f)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                cB_Roleb.Text = "";
                cB_Roleb.Text = "";
                return;
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                return;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}