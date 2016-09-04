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
    public partial class YH_UpdatePassWord : Form
    {
        public YH_UpdatePassWord()
        {
            InitializeComponent();
            GetInfo();
        }
        void GetInfo()
        {
            this.tB_yhbh.Text = common_file.common_app.userNo;
            this.tB_yhxm.Text = common_file.common_app.czy;
        }
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_oldmm.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "旧密码不能为空！");
                tB_oldmm.Focus();
 
            }
            else if (tB_NewsMM.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "新密码不能为空！");
                tB_NewsMM.Focus();
 
            }
            else if (tB_NewsMM01.Text == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请再次输入新密码！");
                tB_NewsMM01.Focus();
 
            }
            else if (tB_NewsMM01.Text.Trim() != tB_NewsMM.Text.Trim())
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "二次输入密码不一样！");
                tB_NewsMM01.Focus();

            }
            else
            {
                Save_New();

            }
            Cursor.Current = Cursors.Default;

           
        }

        void Save_New()
        {
            
            //读取用户密码判断和用户输入的旧密码是否一样
            string stryhbh=this.tB_yhbh.Text;  //用户编号
            string strYhMM = common_file.common_yhuser.GetUser(stryhbh, 1);
            string strmm=this.tB_oldmm.Text;
            if (strmm != strYhMM)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "你输入的旧密码有误！");
                tB_oldmm.Focus();

            }
            else
            {
                string strNewsmm=common_file.common_yhuser.GetUser_mm(this.tB_NewsMM.Text);

                string strSql = "update YH_user set yhmm='" + strNewsmm + "' where yhbh='" + stryhbh + "' " + common_file.common_app.yydh_select + " ";
                if ((DbHelperSQL.ExecuteSql(strSql)) > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "密码修改成功");
                    this.Close();
 
                }

            }
 
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}