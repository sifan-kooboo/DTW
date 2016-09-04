using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yhgl
{
    public partial class YH_Applincations_add : Form
    {
        BLL.YH_Applications B_YH_Applications = new BLL.YH_Applications();
          public string YH_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public YH_Applincations_add()
        {
            InitializeComponent();
            BindAppdr();
        }
        //邦定父级
        private void BindAppdr()
        {
       
            cB_Appdr.Items.Clear();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select distinct a_appdr from YH_Applications", "1=1");
            List<Model.YH_Applications> list = common_file.common_roles.DataTableToList(DS_temp.Tables[0]);
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_Appdr.Items.Add(list[i].A_Appdr.ToString());
                }
            }

        }
       
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_Plsbh.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起！权限编号不能为空。");
                tB_Plsbh.Focus();
               // Add(string yydh,string qymc,string appdr, string p_lsbh, string appname)
            }
            else if (tB_AppName.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起！权限名称不能为空。");
                tB_AppName.Focus();
 
            }
            else if (cB_Appdr.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起！父级不能为空。");
                cB_Appdr.Focus();

            }
            else
            {
                Save_new();
            }
            Cursor.Current = Cursors.Default;

        }
        void Save_new()
        {
            int judge_save = 3;//3保存，其余不保存
             
                judge_save = common_file.common_app.get_judge_repeat("YH_Applications", "p_lsbh", "权限编号已经存在了", tB_Plsbh.Text, judge_add_edit, YH_id);
                if (judge_save == 3)
                {
                    judge_save = common_file.common_app.get_judge_repeat("YH_Applications", "A_AppName", "权限姓名已经存在了", tB_AppName.Text, judge_add_edit, YH_id);
                }

                if (judge_save == 3)
                {
                    string appname_value = this.tB_AppName.Text;
                    string plsbh_value = this.tB_Plsbh.Text;
                    string appdr_value = this.cB_Appdr.Text;
                    bool f = common_file.common_roles.Add(common_file.common_app.yydh, common_file.common_app.qymc, appdr_value, plsbh_value, appname_value);
                    if (f)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");

                        tB_Plsbh.Text = "";
                        tB_AppName.Text = "";

                    }
                    else
                    {
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