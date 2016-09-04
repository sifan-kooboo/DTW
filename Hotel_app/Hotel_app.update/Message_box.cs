using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.update
{
    public partial class Message_box : Form
    {
        #region 窗体访问器
        private string  F_content;  //窗体内部显示的内容

        public string  F_Content
        {
            get { return F_content; }
            set { F_content = value; }
        }
        private int judge_y_n_con;//窗体要显示的按纽,等于1时弹出确定界面,等于2时弹出是否界面

        public int Judge_y_n_con
        {
            get { return judge_y_n_con; }
            set { judge_y_n_con = value; }
        }
        private string  F_tilte;//窗体标题信息，提示还是警告

        public string  F_Title
        {
            get { return F_tilte; }
            set { F_tilte = value; }
        }
        #endregion
        //public string F_content = "您好,陈志永！";
        //public int judge_y_n_con = 1;//等于1时弹出确定界面,等于2时弹出是否界面
        public Message_box()
        {
            InitializeComponent();
            initialize();
        }

        public Message_box(string F_tilte, string F_content, int judge_y_n_con)
        {
            InitializeComponent();
           
            this.F_Title = F_tilte;
            this.F_Content = F_content;
            this.Judge_y_n_con = judge_y_n_con;
            initialize();
        }
        public void initialize()
        {
            this.Text = this.F_Title;
            this.tB_content.Text = F_Content;
            if (judge_y_n_con == 1)
            {
                b_confirm.Visible = true;
            }
            else
            {
                b_yes.Visible = true;
                b_no.Visible = true;
            }
  
        }

        private void b_yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void b_confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_no_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Massage_box_Load(object sender, EventArgs e)
        {
        }
    }
}