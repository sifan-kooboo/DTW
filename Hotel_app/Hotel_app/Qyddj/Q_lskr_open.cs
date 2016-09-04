using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_lskr_open : Form
    {
        public int dg_count = 0;
        public DataSet DS_lskr;
        public BLL.Common B_Common = new Hotel_app.BLL.Common();
        public string sql_condition = "";
        public Qyddj.Qskdj F_ls;

        public Q_lskr_open(string sql_conditon_0, Qyddj.Qskdj F_ls_0)
        {
            sql_condition = sql_conditon_0;
            F_ls = F_ls_0;
            InitializeComponent();
            refresh_app();
        }


        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            this.dg_lskr.AutoGenerateColumns = false;
            string s = "id>=0" + sql_condition + "  order by ddsj desc";
            DS_lskr = B_Common.GetList("select * from VIEW_Q_skyd_lskr", s);
            bs_lskr.DataSource = DS_lskr.Tables[0];
            dg_count = DS_lskr.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void Q_lskr_open_Load(object sender, EventArgs e)
        {
            bs_lskr.MoveFirst();
            click_0();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void click_0()
        {
            if (dg_count > 0 && dg_lskr.CurrentRow.Index < dg_count && DS_lskr != null && DS_lskr.Tables[0].Rows[dg_lskr.CurrentRow.Index]["id"].ToString() != "")
            {

                string s_ls = " zjhm='" + DS_lskr.Tables[0].Rows[dg_lskr.CurrentRow.Index]["zjhm"].ToString() + "'";
                DataSet DS_temp = B_Common.GetList("select * from Q_lskr_xftj ", s_ls);
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    tB_xfsl.Text = DS_temp.Tables[0].Rows[0]["lzfs"].ToString();
                    tB_xfje.Text = DS_temp.Tables[0].Rows[0]["xfje_ff"].ToString();
                }
                else
                {
                    tB_xfje.Text = "0";
                    tB_xfsl.Text = "0";
                }
                DS_temp.Dispose();
              
            }
        }

        private void dg_lskr_Click(object sender, EventArgs e)
        {
            click_0();
        }

        private void dg_lskr_DoubleClick(object sender, EventArgs e)
        {
            if (dg_lskr.CurrentRow != null)
            {
                int j_000 = 0;
                DataRowView dgr = dg_lskr.CurrentRow.DataBoundItem as DataRowView;
                j_000 = DS_lskr.Tables[0].Rows.IndexOf(dgr.Row);

                if (dg_count > 0 && dg_lskr.CurrentRow.Index < dg_count && DS_lskr != null && DS_lskr.Tables[0].Rows[j_000]["id"].ToString() != "")
                {
                    string s_ls = " zjhm='" + DS_lskr.Tables[0].Rows[j_000]["zjhm"].ToString() + "' order by tssj desc";
                    DataSet DS_temp = B_Common.GetList("select * from Qtsjy", s_ls);
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        Qyddj.Qtsjy Qtsjy_new = new Qtsjy(common_file.common_app.get_add, "sk", "", "", "", "", DS_lskr.Tables[0].Rows[j_000]["krsj"].ToString(), DS_lskr.Tables[0].Rows[j_000]["zjhm"].ToString(), "", "", "", " and zjhm='" + DS_lskr.Tables[0].Rows[j_000]["zjhm"].ToString() + "'");
                        Qtsjy_new.Left = 150;
                        Qtsjy_new.Top = 100;
                        Qtsjy_new.cz_sel = "sel";
                        Qtsjy_new.ShowDialog();
                    }
                    s_ls = " zjhm='" + DS_lskr.Tables[0].Rows[j_000]["zjhm"].ToString() + "' order by xhrx desc";
                    DS_temp = B_Common.GetList("select * from Qkrxh", s_ls);
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        Qyddj.Qkrxh Qkrxh_new = new Qkrxh("sk", common_file.common_app.get_add, "", "", "", DS_lskr.Tables[0].Rows[j_000]["zjhm"].ToString());
                        Qkrxh_new.Left = 150;
                        Qkrxh_new.Top = 100;
                        Qkrxh_new.cz_sel = "sel";
                        Qkrxh_new.ShowDialog();

                    }
                    DS_temp.Dispose();
                    if (F_ls == common_file.common_form.Qskdj_new)
                    {
                        if(F_ls.tB_hykh_bz.Text.Trim()!=""&&common_file.common_app.message_box_show_select(common_file.common_app.message_title,"是否要清除当前的会员卡号?"))
                        {
                             F_ls.tB_hykh_bz.Text = DS_lskr.Tables[0].Rows[j_000]["hykh_bz"].ToString();
                        }
                        else
                        {
                            //F_ls.tB_hykh_bz.Text = DS_lskr.Tables[0].Rows[j_000]["hykh_bz"].ToString();
                        }
                        F_ls.tB_krxm.Text = DS_lskr.Tables[0].Rows[j_000]["krxm"].ToString();
                        F_ls.tB_krgj.Text = DS_lskr.Tables[0].Rows[j_000]["krgj"].ToString();
                        F_ls.tB_yxzj.Text = DS_lskr.Tables[0].Rows[j_000]["yxzj"].ToString();
                        F_ls.tB_zjhm.Text = DS_lskr.Tables[0].Rows[j_000]["zjhm"].ToString();
                        F_ls.tB_krmz.Text = DS_lskr.Tables[0].Rows[j_000]["krmz"].ToString();
                        F_ls.cB_krxb.Text = DS_lskr.Tables[0].Rows[j_000]["krxb"].ToString();
                        F_ls.dT_krsr.Value = DateTime.Parse(DS_lskr.Tables[0].Rows[j_000]["krsr"].ToString());
                        F_ls.tB_krdh.Text = DS_lskr.Tables[0].Rows[j_000]["krdh"].ToString();
                        F_ls.tB_krsj.Text = DS_lskr.Tables[0].Rows[j_000]["krsj"].ToString();
                        F_ls.tB_krEmail.Text = DS_lskr.Tables[0].Rows[j_000]["krEmail"].ToString();
                        F_ls.tB_krdz.Text = DS_lskr.Tables[0].Rows[j_000]["krdz"].ToString();
                        F_ls.tB_krjg.Text = DS_lskr.Tables[0].Rows[j_000]["krjg"].ToString();
                        F_ls.tB_krdw.Text = DS_lskr.Tables[0].Rows[j_000]["krdw"].ToString();
                        F_ls.tB_krzy.Text = DS_lskr.Tables[0].Rows[j_000]["krzy"].ToString();
                        F_ls.tB_cxmd.Text = DS_lskr.Tables[0].Rows[j_000]["cxmd"].ToString();
                        F_ls.tB_qzrx.Text = DS_lskr.Tables[0].Rows[j_000]["qzrx"].ToString();
                        F_ls.tB_qzhm.Text = DS_lskr.Tables[0].Rows[j_000]["qzhm"].ToString();
                        F_ls.dT_zjyxq.Value = DateTime.Parse(DS_lskr.Tables[0].Rows[j_000]["zjyxq"].ToString());
                        F_ls.dT_tlyxq.Value = DateTime.Parse(DS_lskr.Tables[0].Rows[j_000]["tlyxq"].ToString());
                        F_ls.dT_tjrq.Value = DateTime.Parse(DS_lskr.Tables[0].Rows[j_000]["tjrq"].ToString());
                        F_ls.tB_lzka.Text = DS_lskr.Tables[0].Rows[j_000]["lzka"].ToString();
                        F_ls.tB_vip_type.Text = DS_lskr.Tables[0].Rows[j_000]["vip_type"].ToString();
                        F_ls.tB_krrx.Text = common_file.common_app.krrx_htk;
                        F_ls.tB_krly.Focus();
                    }
                    Close();
                }
            }
        }

        private void dg_lskr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dg_lskr_DoubleClick(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { b_exit_Click(sender, e); }
        }



    }
}