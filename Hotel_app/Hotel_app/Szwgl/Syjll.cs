using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Syjll : Form
    {
        public string sql_condition = "";//查询条件
        public string ls_condition = "";
        DataSet ds;

        public Syjll()
        {
            InitializeComponent();
            InitalApp();
            Bindata(ls_condition);
        }

        public void InitalApp()
        {
            if (sql_condition.Trim() == "")
            { sql_condition = " id>=0  and yydh='" + common_file.common_app.yydh + "'"; }
            else
            {
                sql_condition = "  id>=0  and  yydh='" + common_file.common_app.yydh + sql_condition + "'";
            }
        }

        private void Bindata(string ls_condition)
        {
            BLL.Common B_common = new Hotel_app.BLL.Common();
            bs_yjll.DataSource = null;
            string temp = sql_condition + ls_condition;
            ds = B_common.GetList(" select * from Syjcz ", sql_condition + ls_condition+"  order by id desc " );
            //dg_yjll.AutoGenerateColumns = false;
            dg_yjll.AutoGenerateColumns = false;
            //dg_zzll.AutoGenerateColumns = false;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                bs_yjll.DataSource = ds.Tables[0];
            }
            dg_yjll.DataSource = bs_yjll;
        }

        private void Tsmi_scdjyf_Click(object sender, EventArgs e)
        {
            sql_condition = "";
            ls_condition = "";
            Get_ls_condition("在住预付");
        }

        private void Tsmi_cxdjyf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_syjll_cx_zz", common_file.common_app.user_type) == false)
            { return; }
            Get_ls_condition("在住预付");
        }

        private void Tsmi_cxydyf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_syjll_cx_yd", common_file.common_app.user_type) == false)
            { return; }
            Get_ls_condition("预订预付");
        }

        private void Tsmi_cxjzyf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_syjll_cx_jz", common_file.common_app.user_type) == false)
            { return; }
            Get_ls_condition("记账预付");
        }
        private void Tsmi_cxgzyf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_syjll_cx_gz", common_file.common_app.user_type) == false)
            { return; }
            Get_ls_condition("挂账预付");
        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            ls_condition = "";
            sql_condition = "";
            InitalApp();
            Bindata(ls_condition);
        }

        private void b_gl_Click(object sender, EventArgs e)
        {

        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bs_yjll.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bs_yjll.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bs_yjll.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bs_yjll.MoveLast();
        }


        private void Get_ls_condition(string type)
        {
            sql_condition = "";
            ls_condition = "";
            ls_condition = " and 1=1   ";
            if (type == "在住预付")
            {
                ls_condition = ls_condition + " and  jzbh=''   and ( lsbh  in  (select  lsbh  from   Qskyd_mainrecord  where yddj='" + common_file.common_yddj.yddj_dj + "')  or  lsbh in (select  lsbh from  Qttyd_mainrecord  where yddj='" + common_file.common_yddj.yddj_dj + "'))  and yydh='" + common_file.common_app.yydh + "'";
            }
            if (type == "预订预付")
            {
                ls_condition = ls_condition + " and  jzbh=''  and ( lsbh  in  (select  lsbh  from   Qskyd_mainrecord  where yddj='" + common_file.common_yddj.yddj_yd + "')  or  lsbh in (select  lsbh from  Qttyd_mainrecord  where yddj='" + common_file.common_yddj.yddj_yd + "'))  and yydh='" + common_file.common_app.yydh + "'";
            }
            if (type == "记账预付")
            {
                ls_condition = ls_condition + " and  jzbh  in  (select  jzbh from  Sjzzd where czzt='" + common_file.common_jzzt.czzt_jz + "')   and  yydh='" + common_file.common_app.yydh + "'";
            }
            if (type == "挂账预付")
            {
                ls_condition = ls_condition + " and  jzbh  in  (select  jzbh from  Sjzzd where czzt='" + common_file.common_jzzt.czzt_gz + "')    and  yydh='" + common_file.common_app.yydh + "'";
            }
            InitalApp();
            Bindata(ls_condition);

        }
        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_yjll_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tsmi_print_Click(object sender, EventArgs e)
        {

            if (common_file.common_roles.get_user_qx("B_syjll_print", common_file.common_app.user_type) == false)
            { return; }

            if (dg_yjll.CurrentRow != null && dg_yjll.CurrentRow.Index > -1 && dg_yjll.CurrentRow.Index < ds.Tables[0].Rows.Count)
            {

                if (dg_yjll.CurrentRow != null&&common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要打印单房押金嘛?") == true)
                {
                    int i = dg_yjll.CurrentRow.Index;
                    DataRowView dgr = dg_yjll.CurrentRow.DataBoundItem as DataRowView;
                    i = ds.Tables[0].Rows.IndexOf(dgr.Row);

                    //DataSet ds_tmp_0 = B_Qcounter.GetList("  id>=0  and yydh='" + common_file.common_app.yydh + "'");
                    string sk_tt = "";
                    string sk_tt_0 = ds.Tables[0].Rows[i]["sktt"].ToString();
                    if (sk_tt_0 == common_file.common_sktt.sktt_hy || sk_tt_0 == common_file.common_sktt.sktt_tt)
                    {
                        sk_tt = "tt";
                    }
                    else
                    {
                        sk_tt = "sk";
                    }
                    //Szw_print_jzd Szw_print_jzd_new;
                    common_file.common_PrintFrm PrintFrm = new Hotel_app.common_file.common_PrintFrm(ds.Tables[0].Rows[i]["lsbh"].ToString(), ds.Tables[0].Rows[i]["sjxfje"].ToString(), "", "Syjcz", "yjd", sk_tt, ds.Tables[0].Rows[i]["jzbh"].ToString());
                    //Szw_print_jzd_new = new Szw_print_jzd(ds.Tables[0].Rows[i]["lsbh"].ToString(), ds.Tables[0].Rows[i]["sjxfje"].ToString(), "", "Syjcz", "yjd", sk_tt, ds.Tables[0].Rows[i]["jzbh"].ToString()); Szw_print_jzd_new.Visible = false;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Szw_gl Szw_gl_new = new Szw_gl("Syjll");
            Szw_gl_new.StartPosition = FormStartPosition.CenterScreen;
            if (Szw_gl_new.ShowDialog() == DialogResult.OK)
            {
                ls_condition += Szw_gl_new.get_sel_cond;
                if (ls_condition == " and  1=1 ")
                { ls_condition = ""; }
            }
            sql_condition = "";
            InitalApp();
            Bindata(ls_condition);
        }
 
        private void Tsmi_print_gl_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_syjll_print", common_file.common_app.user_type) == false)
            { return; }
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_gl_print = B_common.GetList(" select * from Syjcz ", sql_condition + ls_condition);
            if (ds_gl_print != null && ds_gl_print.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要打印当前过滤出的押金记录嘛?") == true)
                {
                    //dgvprint_app dgv_print_new = new dgvprint_app("", "", "multi", ds_gl_print);
                    common_file.common_PrintFrm PrintFrm = new Hotel_app.common_file.common_PrintFrm("zd_yjd_gl", ds_gl_print);

                }
            }
        }
    }
}