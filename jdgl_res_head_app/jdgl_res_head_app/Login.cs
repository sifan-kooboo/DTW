using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jdgl_res_head_app
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin("guanli","xsly751789");
            //UserLogin(this.txtUsername.Text.Trim(), this.txtPassword.Text);

        }
        private void UserLogin(string username, string password)
        {
            //if (this.txtUsername.Text.Trim() == "")
            //{
            //    MessageBox.Show("用户名错误", "错误");
            //    this.txtUsername.Focus();
            //    return;
            //}
            //if (this.txtPassword.Text == "")
            //{
            //    MessageBox.Show("密码错误", "错误");
            //    this.txtUsername.Focus();
            //    return;
            //}
            if (username.Trim() == "guanli" && password == "xsly751789")
            {
                MessageBox.Show("登录成功");
                this.Visible = false;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("用户名或者密码不对,请联系管理员");
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
                this.txtUsername.Focus();
                return;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                UserLogin(this.txtUsername.Text.Trim(), this.txtPassword.Text);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.txtUsername.Text = "";
            this.txtPassword.Text = "";
            this.txtUsername.Focus();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}