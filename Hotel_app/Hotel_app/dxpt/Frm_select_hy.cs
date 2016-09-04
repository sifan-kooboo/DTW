using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace Hotel_app.dxpt
{
    public partial class Frm_select_hy : Form
    {
        dxpt_send frm_dxpt_send_new = null;
        string tableName = common_dxpt.dx_table_source_hy;
        int CurrentPage = 1;
        int PageSize = 12;
        int PageCount = 0;  //总页数
        DataTable dt = null;
        int tempCount = -1;
        ListBox ls;
        public Frm_select_hy(dxpt_send frm,ref   ListBox  ls_parent)
        {
            InitializeComponent();
            frm_dxpt_send_new = frm;
            ls = ls_parent;
        }

        //重置查询条件
        private void RestControlText()
        {
            tB_0.Text = tB_1.Text = tB_2.Text = tB_3.Text = tB_4.Text = "";
            dT_ddsj_cs.Text = dT_ddsj_js.Text  = common_file.common_app.cssj;
        }

        //生成查询条件
        private string GetSelCond()
        {
            string get_sel_cond = "    1=1   ";
            if (tB_0.Text.Trim() != "")
            {
                get_sel_cond += "  and  hykh_bz  like '%" + tB_0.Text.Trim() + "%'  ";
            }
            if (tB_1.Text.Trim() != "")
            {
                get_sel_cond += "  and   hyrx  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
            }
            if (tB_2.Text.Trim() != "")
            {
                get_sel_cond += "  and  krxm   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
            }
            if (tB_3.Text.Trim() != "")
            {
                get_sel_cond += "  and  qymc   like '%" + tB_3.Text.Trim().Replace("'", "-") + "%'  ";
            }
            if (tB_4.Text.Trim().Equals("男")||tB_4.Text.Trim().Equals("女"))
            {
                get_sel_cond += "  and  krxb   like '%" + tB_3.Text.Trim().Replace("'", "-") + "%'  ";
            }
            if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                get_sel_cond = get_sel_cond + " and (djsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
            }
            return get_sel_cond += "  and  krsj!=''  ";
        }




        private void Frm_select_hy_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            tabControl1.TabPages[1].Focus();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //tempCount = -1;
            //dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, PageSize, "*", GetSelCond(), "", ref tempCount);
            //if ((tempCount % PageSize) == 0)
            //{
            //    PageCount = tempCount / PageSize;
            //}
            //else
            //{
            //    PageCount = tempCount / PageSize + 1;
            //}
            //l_totalPage.Text = PageCount.ToString();
            //l_currentPage.Text = CurrentPage.ToString();
            //dg_infoSource.AutoGenerateColumns = false;
            //dg_infoSource.DataSource = dt;
            //tabControl1.SelectedIndex = 0;
            //tabControl1.TabPages[0].Focus();
            common_dxpt.searchButtion_Click(tempCount,  dt, tableName, ref CurrentPage, PageSize,ref  PageCount, l_totalPage, l_currentPage, dg_infoSource, GetSelCond(), tabControl1);

        }

        private void lb_last_Click(object sender, EventArgs e)
        {
            common_dxpt.linkButtion_Click(sender, PageSize, PageCount,ref  CurrentPage, l_totalPage, l_currentPage,  dt, tableName, dg_infoSource, GetSelCond());
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dT_ddsj_cs_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);

        }

        private void b_selectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_infoSource.Rows.Count;i++ )
            {
                string addInfo = "";//增加的
                string krxm = dg_infoSource.Rows[i].Cells[1].Value.ToString();
                string krdh = dg_infoSource.Rows[i].Cells[2].Value.ToString();
                string zjhm = dg_infoSource.Rows[i].Cells[3].Value.ToString();
                if (!krxm.Equals("") && !krdh.Equals(""))
                {
                    if (zjhm.Equals(""))
                    { zjhm = "未知"; }
                    addInfo = krxm + "|" + krdh + "|" + zjhm;
                    if (!ls.Items.Contains(addInfo))
                    {
                        ls.Items.Add(addInfo);
                    }
                }
            }
        }

        private void b_SelectMulti_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr_temp in dg_infoSource.Rows)
            {
                DataGridViewCheckBoxCell chk = dgvr_temp.Cells[0] as DataGridViewCheckBoxCell;

                if (bool.Parse(chk.EditingCellFormattedValue.ToString()))
                {
                    string addInfo = "";//增加的
                    string krxm = dgvr_temp.Cells[1].Value.ToString();
                    string krsj = dgvr_temp.Cells[2].Value.ToString();
                    string zjhm = dgvr_temp.Cells[3].Value.ToString();
                    if (!krxm.Equals("") && !krsj.Equals(""))
                    {
                        if (zjhm.Equals(""))
                        { zjhm = "未知"; }
                        addInfo = krxm + "|" + krsj + "|" + zjhm;
                        if (!ls.Items.Contains(addInfo))
                        {
                            ls.Items.Add(addInfo);
                        }
                    }
                }
            }
        }
    }
}