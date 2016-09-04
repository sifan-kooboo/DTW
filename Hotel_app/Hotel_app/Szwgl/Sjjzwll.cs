using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Sjjzwll : Form
    {
        public Sjjzwll()
        {
            InitializeComponent();
        }


        public string jjType = "";//要查询哪种帐务的数据
        public DataSet ds_GetZwData;//获取指定类型的帐务数据
        public string jzzd = "";//结帐主单
        public string jzzd_id = "";
        public string sel_cond = "";
        public int dg_count = 0;


        public BLL.Common B_common = new Hotel_app.BLL.Common();
        public void Inital_app(string jjType)
        {
            this.jjType = jjType;
            SetFrmText();
            load_refresh();
        }

        public void load_refresh()
        {
            sel_cond = "";
            if (jjType == common_file.common_jzzt.czzt_sz)
            {
                BindData(" and czsj >='" + DateTime.Now.AddDays(-10).ToShortDateString() + "'");
            }
            else
            {
                BindData("  ");
                if (dg_zzll.Rows.Count > 0)
                {
                    for (int m = 0; m < dg_zzll.Rows.Count; m++)
                    {
                        int mm_0 = 0;
                        DataRowView dgr = dg_zzll.Rows[m].DataBoundItem as DataRowView;
                        mm_0 = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);
                        if (double.Parse(ds_GetZwData.Tables[0].Rows[mm_0]["fkje"].ToString()) - double.Parse(ds_GetZwData.Tables[0].Rows[mm_0]["xfje"].ToString()) < 0)
                        {
                            dg_zzll.Rows[m].DefaultCellStyle.ForeColor = Color.Red;
                        }

                    }
                }
            }
        }
        public void BindData(string ls_condition)
        {
            this.dg_zzll.AutoGenerateColumns = false;
            dg_zzll.DataSource = null;
            if (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_jz || jjType == common_file.common_jzzt.czzt_jzzgz || jjType == common_file.common_jzzt.czzt_gzzjz)
            {

                string selectCondition = "";

                if (jjType == common_file.common_jzzt.czzt_gz)
                {
                    selectCondition = "id>=0    " + ls_condition + sel_cond + common_file.common_app.yydh_select + "  and  ( czzt='" + common_file.common_jzzt.czzt_gz + "'  or  czzt='" + common_file.common_jzzt.czzt_jzzgz + "')  order by czsj desc ";
                }
                if (jjType == common_file.common_jzzt.czzt_jz)
                {
                    selectCondition = "id>=0    " + ls_condition + sel_cond + common_file.common_app.yydh_select + "  and  ( czzt='" + common_file.common_jzzt.czzt_jz + "' or  czzt='" + common_file.common_jzzt.czzt_gzzjz + "')  order by czsj  desc";
                }
                ds_GetZwData = B_common.GetList("select  *  from  Sjzzd", selectCondition);
            }
            if (jjType == common_file.common_jzzt.czzt_sz || jjType == common_file.common_jzzt.czzt_bfsz || jjType == common_file.common_jzzt.czzt_gzfj || jjType == common_file.common_jzzt.czzt_jzfj || jjType == common_file.common_jzzt.czzt_gzzsz || jjType == common_file.common_jzzt.czzt_jzzsz)
            {
                //记帐分结，挂帐分结，挂账转算帐，记帐转算帐，部分结帐，挂帐分结，记帐分结
                ds_GetZwData = B_common.GetList("select * from Sjzzd", "id>=0     " + ls_condition + sel_cond + common_file.common_app.yydh_select + " and  (czzt='" + common_file.common_jzzt.czzt_sz + "'  or  czzt='" + common_file.common_jzzt.czzt_gzzsz + "'  or  czzt='" + common_file.common_jzzt.czzt_jzzsz + "'  or czzt='" + common_file.common_jzzt.czzt_bfsz + "'  or  czzt='" + common_file.common_jzzt.czzt_jzfj + "'  or  czzt='" + common_file.common_jzzt.czzt_gzfj + "')   order by czsj  desc ");
            }
            if (ds_GetZwData != null && ds_GetZwData.Tables[0].Rows.Count > 0)
            {
                dg_zzll.AutoGenerateColumns = false;
                dataSource_zwll.DataSource = ds_GetZwData.Tables[0].DefaultView;
                dg_zzll.DataSource = dataSource_zwll;
                dg_count = ds_GetZwData.Tables[0].Rows.Count;
                changeColor();
            }
        }

        public void SetFrmText()
        {
            if (this.jjType == common_file.common_jzzt.czzt_jz)
            {
                this.Text = "记帐帐务浏览";
                b_gzpj.Visible = false;
            }
            if (this.jjType == common_file.common_jzzt.czzt_gz)
            {
                this.Text = "挂帐帐务浏览";
                Tsmi_xggzdw.Enabled = true;
                b_gzpj.Visible = true;
            }
            if (this.jjType == common_file.common_jzzt.czzt_sz)
            {
                this.Text = "结账帐务浏览";
                b_gzpj.Visible = false;
            }
        }


        public void open_mx()
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_Sjjzwll_mx", common_file.common_app.user_type) == false)
            { return; }
            if (dg_zzll.CurrentRow != null && dg_zzll.CurrentRow.Index > -1 && dg_zzll.CurrentRow.Index < ds_GetZwData.Tables[0].Rows.Count && ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["id"] != null)
            {
                // int i = dg_zzll.CurrentRow.Index;
                DataRowView dgr = dg_zzll.SelectedRows[0].DataBoundItem as DataRowView;
                if (dgr != null)
                {
                    int i = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);
                    if (i > -1 && i < dg_count)//当前行为内容行
                    {
                        string czzt = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["czzt"].ToString();
                        string lsbh = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["lsbh"].ToString();
                        string sk_tt = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["sktt"].ToString();
                        string jzbh = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["jzbh"].ToString();
                        string fjbh = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["fjbh"].ToString();
                        czzt = ds_GetZwData.Tables[0].Rows[i]["czzt"].ToString();
                        lsbh = ds_GetZwData.Tables[0].Rows[i]["lsbh"].ToString();
                        jzbh = ds_GetZwData.Tables[0].Rows[i]["jzbh"].ToString();
                        fjbh = ds_GetZwData.Tables[0].Rows[i]["fjbh"].ToString();
                        sk_tt = ds_GetZwData.Tables[0].Rows[i]["sktt"].ToString();

                        if ((sk_tt == common_file.common_sktt.sktt_tt) || (sk_tt == common_file.common_sktt.sktt_hy))
                        {
                            sk_tt = "tt";
                        }
                        else
                        {
                            sk_tt = "sk";
                        }
                        //要显示出Szwcz界面(由于这里可以查出团体成员的帐务，但是要按客散的情形来查询

                        Szwcz Frm_Szwcz_new = new Szwcz();
                        Frm_Szwcz_new.InitalApp(czzt, lsbh, jzbh, sk_tt, "Sjjzwll");
                        Frm_Szwcz_new.fjbh = fjbh;
                        Frm_Szwcz_new.StartPosition = FormStartPosition.CenterScreen;
                        if (Frm_Szwcz_new.ShowDialog() == DialogResult.OK)
                        {
                            //this.Inital_app(jjType);
                            BindData(sel_cond);
                        }
                        //common_file.common_form.ShowFrm_Szwcz_new(jzzt, lsbh, jzbh, sk_tt, "Sjjzwll");
                        //common_file.common_form.Szwcz_new.fjbh = fjbh;
                    }
                }
            }
            Cursor.Current = Cursors.Default;

        }
        private void dg_zzll_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dg_zzll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            open_mx();
        }


        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //右键菜单
        private void Tsmi_zwcl_Click(object sender, EventArgs e)
        {
            open_mx();
        }

        private void Tsmi_dzsc_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_Sjjzwll_dzsc", common_file.common_app.user_type) == false)
            { return; }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你确定要修改挂账单位嘛？") == true)
            {
                if (dg_zzll.CurrentRow != null && dg_zzll.CurrentRow.Index > -1)
                {
                    int j_0 = 0;
                    j_0 = dg_zzll.CurrentRow.Index;

                    DataRowView dgr = dg_zzll.Rows[j_0].DataBoundItem as DataRowView;
                    j_0 = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);

                    string jzbh_tz = ds_GetZwData.Tables[0].Rows[j_0]["jzbh"].ToString();
                    S_gzdwz_tz FrmS_gzdwz_tz = new S_gzdwz_tz(jzbh_tz);
                    FrmS_gzdwz_tz.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                    if (FrmS_gzdwz_tz.ShowDialog() == DialogResult.OK)
                    {
                        this.Inital_app(jjType);
                    }

                }

            }
        }

        private void Tsmi_fpbz_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_Sjjzwll_fp", common_file.common_app.user_type) == false)
            { return; }

            if (dg_zzll.CurrentRow != null && dg_zzll.CurrentRow.Index > -1 && dg_zzll.CurrentRow.Index < ds_GetZwData.Tables[0].Rows.Count)
            {
                //p_fp.Visible = true;
                //p_fp.BringToFront();

                //int left = this.DisplayRectangle.Left;
                //int top = this.DisplayRectangle.Top;
                //p_fp.Left = left + 205;
                //p_fp.Top = top + 10 + dg_zzll.CurrentRow.Index * 41 + 20;

                int j_0 = 0;
                j_0 = dg_zzll.CurrentRow.Index;

                DataRowView dgr = dg_zzll.Rows[j_0].DataBoundItem as DataRowView;
                j_0 = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);

                jzzd_id = ds_GetZwData.Tables[0].Rows[j_0]["id"].ToString();
                //jzzd_id= ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["id"].ToString();
                //Model.Sjzzd M_Sjzzd;
                //BLL.Sjzzd B_sjzzd = new Hotel_app.BLL.Sjzzd();
                //M_Sjzzd = B_sjzzd.GetModel(int.Parse(jzzd_id));
                //if (M_Sjzzd != null)
                //{
                //    tB_fpcs.Text = M_Sjzzd.fp_print.ToString();
                //    tB_fpbz.Text = M_Sjzzd.bz;

                //}
                s_bz s_bz_new = new s_bz(jzzd_id);
                s_bz_new.StartPosition = FormStartPosition.CenterScreen;
                if (s_bz_new.ShowDialog() == DialogResult.OK)
                {
                    BindData(sel_cond);
                }
            }

        }

        private void Tsmi_cpjz_Click(object sender, EventArgs e)
        {
            b_gzpj_Click(sender, e);
        }
        private void b_first_Click(object sender, EventArgs e)
        {
            dataSource_zwll.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            dataSource_zwll.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            dataSource_zwll.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            dataSource_zwll.MoveLast();
        }

        private void b_gzpj_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_Sjjzwll_gzpj", common_file.common_app.user_type) == false)
            { return; }
            if (jjType == common_file.common_jzzt.czzt_gz)
            {
                Szw_pljz Szw_pljz_new = new Szw_pljz();
                if (Szw_pljz_new.ShowDialog() == DialogResult.OK)
                {
                    this.Inital_app(jjType);
                }
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //if (common_file.common_roles.get_user_qx("B_Sjjzwll_mx", common_file.common_app.user_type) == false)
            //{ return; }
            //open_mx();

            Szw_gl Szw_gl_new = new Szw_gl("Sjjzwll");
            if (Szw_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_cond += Szw_gl_new.get_sel_cond;
                BindData(sel_cond);
            }
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            load_refresh();
        }

        private void b_mxck_Click(object sender, EventArgs e)
        {
            open_mx();
        }

        private void b_gd_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_Sjjzwll_gd", common_file.common_app.user_type) == false)
            { return; }
            if (dg_zzll.CurrentRow != null && dg_zzll.CurrentRow.Index > -1 && dg_zzll.CurrentRow.Index < ds_GetZwData.Tables[0].Rows.Count && ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["id"] != null)
            {
                // int i = dg_zzll.CurrentRow.Index;
                DataRowView dgr = dg_zzll.SelectedRows[0].DataBoundItem as DataRowView;
                if (dgr != null)
                {
                    int i = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);
                    if (i > -1 && i < dg_count)//当前行为内容行
                    {
                        //string czzt = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["czzt"].ToString();
                        //string lsbh = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["lsbh"].ToString();
                        //string sk_tt = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["sktt"].ToString();
                        //string jzbh = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["jzbh"].ToString();
                        //string fjbh = ds_GetZwData.Tables[0].Rows[dg_zzll.CurrentRow.Index]["fjbh"].ToString();
                        //czzt = ds_GetZwData.Tables[0].Rows[i]["czzt"].ToString();
                        string lsbh_temp = ds_GetZwData.Tables[0].Rows[i]["lsbh"].ToString();
                        string jzbh_temp = ds_GetZwData.Tables[0].Rows[i]["jzbh"].ToString();
                        //fjbh = ds_GetZwData.Tables[0].Rows[i]["fjbh"].ToString();
                        //sk_tt = ds_GetZwData.Tables[0].Rows[i]["sktt"].ToString();

                        //if ((sk_tt == common_file.common_sktt.sktt_tt) || (sk_tt == common_file.common_sktt.sktt_hy))
                        //{
                        // sk_tt = "tt";
                        //}
                        //else
                        //{
                        //    sk_tt = "sk";
                        //}
                        //要显示出Szwcz界面(由于这里可以查出团体成员的帐务，但是要按客散的情形来查询

                        //Szwcz Frm_Szwcz_new = new Szwcz();
                        //Frm_Szwcz_new.InitalApp(czzt, lsbh, jzbh, sk_tt, "Sjjzwll");
                        //Frm_Szwcz_new.fjbh = fjbh;
                        //Frm_Szwcz_new.StartPosition = FormStartPosition.CenterScreen;
                        //if (Frm_Szwcz_new.ShowDialog() == DialogResult.OK)
                        //{
                        //    this.Inital_app(jjType);
                        //}
                        Szw_gd Frm_Szw_gd_new = new Szw_gd(jzbh_temp, lsbh_temp,"","jz");
                        Frm_Szw_gd_new.StartPosition = FormStartPosition.CenterScreen;
                        Frm_Szw_gd_new.ShowDialog();

                    }
                }
            }
            Cursor.Current = Cursors.Default;


        }

        private void b_UnlockZw_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            bool flage = false;

            //锁账修改成:administrator用户不判断，其它授权
            if (common_file.common_app.user_type == common_file.common_app.superUser)
            {
                flage = true;
            }
            else
            {
                if (common_file.common_roles.get_user_qx("B_Sjjzwll_Unlock", common_file.common_app.user_type) == false)
                { return; }
                if (dg_zzll.CurrentRow != null)
                {
                    int i_000 = dg_zzll.CurrentRow.Index;
                    DataRowView dgr = dg_zzll.Rows[i_000].DataBoundItem as DataRowView;
                    i_000 = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);
                    if (DateTime.Parse( ds_GetZwData.Tables[0].Rows[i_000]["tfsj"].ToString()).Date==DateTime.Now.Date)
                    {
                        flage = true;
                    }
                }
            }
            if (flage == true)
            {


                // if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你确认要解锁这笔账嘛?") == true)
                // {
                if (dg_zzll.CurrentRow != null)
                {
                    int i_000 = dg_zzll.CurrentRow.Index;
                    DataRowView dgr = dg_zzll.Rows[i_000].DataBoundItem as DataRowView;
                    i_000 = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);
                    if (bool.Parse(ds_GetZwData.Tables[0].Rows[i_000]["shys"].ToString()))
                    {
                        string tt_zd_id = ds_GetZwData.Tables[0].Rows[i_000]["id"].ToString();
                        Szwgl.common_zw.Unlock(tt_zd_id);
                    }
                }
            }
            // }
            Cursor.Current = Cursors.Default;
        }

        private void dg_zzll_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            changeColor();
        }

        private void changeColor()
        {
            if (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_jz || jjType == common_file.common_jzzt.czzt_jzzgz || jjType == common_file.common_jzzt.czzt_gzzjz)
            {
                if (dg_zzll.Rows.Count > 0)
                {
                    for (int m = 0; m < dg_zzll.Rows.Count; m++)
                    {
                        int mm_0 = 0;
                        DataRowView dgr = dg_zzll.Rows[m].DataBoundItem as DataRowView;
                        mm_0 = ds_GetZwData.Tables[0].Rows.IndexOf(dgr.Row);
                        if (double.Parse(ds_GetZwData.Tables[0].Rows[mm_0]["fkje"].ToString()) - double.Parse(ds_GetZwData.Tables[0].Rows[mm_0]["xfje"].ToString()) < 0)
                        {
                            dg_zzll.Rows[m].DefaultCellStyle.ForeColor = Color.Red;
                        }

                    }
                }
            }
        }

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            common_file.common_DataSetToExcel.ExportMX(ds_GetZwData, "jgjzwll", jjType + "详细内容导出");
        }
    }
}