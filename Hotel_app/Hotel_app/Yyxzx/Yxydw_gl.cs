using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Yyxzx
{
    public partial class Yxydw_gl : Form
    {
        public string get_sel_cond = "";//最终获取的查询条件
        public Yxydw_gl()
        {
         
            InitializeComponent();
            Bindkrly();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }




        }
        private void Bindkrly()
        {
            cB_krly.Items.Clear();
            Model.Xkrly M_krly = new Model.Xkrly();
            BLL.Xkrly B_krly = new BLL.Xkrly();
            List<Model.Xkrly> list = B_krly.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_krly.Items.Add(list[i].krly.ToString());
                }
            }
        }
        private void gl()
        {
            string sel_cond = "";
            if (tB_qymc.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and qymc like'%" + tB_qymc.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tB_xyh.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xyh_inner like'%" + tB_xyh.Text.Trim().Replace("'", "-") + "%'";

            }
            if (tb_xydw.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xydw like'%" + tb_xydw.Text.Trim().Replace("'", "-") + "%'";
 
            }
            if (tb_zjm.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and zjm like'%" + tb_zjm.Text.Trim().Replace("'", "-") + "%'";
 
            }
            if (tB_xsy.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and xsy like'%" + tB_xsy.Text.Trim().Replace("'", "-") + "%'";
 
            }
            if (tB_krxm.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and nxr like'%" + tB_krxm.Text.Trim().Replace("'", "-") + "%'";
 
            }


            if (tB_krdh.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and krdh like'%" + tB_krdh.Text.Trim().Replace("'", "-") + "%'";

            }

            if (tB_krdz.Text.Trim().Replace("'", "-") != "")
            {
                sel_cond = sel_cond + " and krdz like'%" + tB_krdz.Text.Trim().Replace("'", "-") + "%'";

            }
            if (cB_krly.Text != "")
            {
                sel_cond = sel_cond + " and krly ='" + cB_krly.Text.Trim().Replace("'", "-") + "'";
 
            }
            if (sel_cond != "")
            {
                get_sel_cond = sel_cond;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}