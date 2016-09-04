using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_app.common_file;

namespace Hotel_app.Qyddj
{
    public partial class Q_ydzx_notice : Form
    {
        public Q_ydzx_notice()
        {
            InitializeComponent();
            Get_ydzx_Data();
        }

        //确定(处理选择的)，取消(取消选择的),退出(当前不处理),会再次提醒
        BLL.Common B_common = new Hotel_app.BLL.Common();
        DataSet ds_ydzx_Data_sk = null;
        DataSet ds_ydzx_Data_tt = null;
        DataSet ds_tt_fr_detail = null;
        private void Get_ydzx_Data()
        {
            dg_skyd_ydzx.AutoGenerateColumns = false;
            dg_ttyd_ydzx.AutoGenerateColumns = false;
            dg_tt_fr_mx.AutoGenerateColumns = false;
            if (dg_skyd_ydzx.ScrollBars != ScrollBars.Both)
            {
                //dg_skyd_ydzx.ScrollBars = ScrollBars.Both;
            }
            ds_ydzx_Data_sk = B_common.GetList(" select * from  View_Qskzd ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  yddj='" + common_file.common_yddj.yddj_yd + "'  and  ddyy='" + Common_initalSystem.ReadXML("add", "hyrx_site") + "'  and  shsc=1");
            bindingSource_ydzx_sk.DataSource = ds_ydzx_Data_sk.Tables[0];
            dg_skyd_ydzx.DataSource = bindingSource_ydzx_sk;

            ds_ydzx_Data_tt = B_common.GetList(" select * from View_Qttzd ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and yddj='" + common_file.common_yddj.yddj_yd + "'  and  ddyy='" + Common_initalSystem.ReadXML("add", "hyrx_site") + "'  and  shsc=1");
            bindingSource_ydzx_tt.DataSource = ds_ydzx_Data_tt.Tables[0].DefaultView;
            dg_ttyd_ydzx.DataSource = bindingSource_ydzx_tt;

            if (dg_ttyd_ydzx.Rows.Count > 0)
            {
                   int j_000 = 0;
                   DataRowView dgr = dg_ttyd_ydzx.Rows[0].DataBoundItem as DataRowView;
                    j_000 = ds_ydzx_Data_tt.Tables[0].Rows.IndexOf(dgr.Row);
                    GetTTdjDetail(ds_ydzx_Data_tt.Tables[0].Rows[0]["lsbh"].ToString());
            }
            else
            {
                dg_tt_fr_mx.DataSource = null;
            }
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            List<string> qr_lists = new List<string>();
            int i = 0;
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否真要确认当前选择的预订信息?") == true)
            {
                if (ds_ydzx_Data_sk.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < dg_skyd_ydzx.Rows.Count; j++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();

                        if (dg_skyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_skyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                        {
                            if (this.dg_skyd_ydzx.Rows[j].Cells["id"].Value != null)
                            {
                                int j_000 = 0;
                                DataRowView dgr = dg_skyd_ydzx.Rows[j].DataBoundItem as DataRowView;
                                j_000 = ds_ydzx_Data_sk.Tables[0].Rows.IndexOf(dgr.Row);
                                if (j < dg_skyd_ydzx.Rows.Count)
                                {
                                    string temp = ds_ydzx_Data_sk.Tables[0].Rows[j_000]["id"].ToString();
                                    if (B_common.ExecuteSql(" update  Qskyd_mainrecord  set  shsc=0,czsj='"+DateTime.Now.ToString()+"',syzd='"+common_file.common_app.syzd+"',czy='"+common_file.common_app.czy+"'   where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  id= " + Int32.Parse(ds_ydzx_Data_sk.Tables[0].Rows[j_000]["id"].ToString())) > 0)//确认订单
                                    {
                                        System.Text.StringBuilder sb = new StringBuilder();
                                        sb.Append(" insert into  Qyqskyd_ydzxqr (lsbh, qrzt, qrsj, qryy, czy, shsc, scsj, fjrb, sktt, qymc, yydh)  ");
                                        sb.Append("  values('" + ds_ydzx_Data_sk.Tables[0].Rows[j_000]["lsbh"].ToString() + "','确认','" + DateTime.Now + "','门店确认','" + common_file.common_app.czy + "',0,'" + DateTime.Now + "','" + ds_ydzx_Data_sk.Tables[0].Rows[j_000]["fjrb"].ToString() + "','" + ds_ydzx_Data_sk.Tables[0].Rows[j_000]["sktt"].ToString() + "','" + common_file.common_app.qymc + "','" + common_file.common_app.yydh + "' )");
                                        //string tempstr = sb.ToString();
                                        i += B_common.ExecuteSql(sb.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                if (ds_ydzx_Data_tt.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < dg_ttyd_ydzx.Rows.Count; j++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();

                        if (dg_ttyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_ttyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                        {
                            if (this.dg_ttyd_ydzx.Rows[j].Cells["ttzd_id"].Value != null)
                            {
                                int j_000 = 0;
                                DataRowView dgr = dg_ttyd_ydzx.Rows[j].DataBoundItem as DataRowView;
                                j_000 = ds_ydzx_Data_tt.Tables[0].Rows.IndexOf(dgr.Row);
                                if (j < dg_ttyd_ydzx.Rows.Count)
                                {
                                    string temp = ds_ydzx_Data_tt.Tables[0].Rows[j_000]["id"].ToString();
                                    //确认房类信息
                                    if (B_common.ExecuteSql(" update  Qttyd_mainrecord   set  shsc=0,syzd='"+common_file.common_app.syzd+"',czy='"+common_file.common_app.czy+"'   where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  id= " + Int32.Parse(ds_ydzx_Data_tt.Tables[0].Rows[j_000]["id"].ToString())) > 0)//确认订单
                                    {
                                        System.Text.StringBuilder sb = new StringBuilder();
                                        sb.Append(" insert into  Qyqskyd_ydzxqr (lsbh, qrzt, qrsj, qryy, czy, shsc, scsj, fjrb, sktt, qymc, yydh)  ");
                                        sb.Append("  values('" + ds_ydzx_Data_tt.Tables[0].Rows[j_000]["lsbh"].ToString() + "','确认','" + DateTime.Now + "','门店确认','" + common_file.common_app.czy + "',0,'" + DateTime.Now + "','','" + ds_ydzx_Data_tt.Tables[0].Rows[j_000]["sktt"].ToString() + "','" + common_file.common_app.qymc + "','" + common_file.common_app.yydh + "' )");
                                        i += B_common.ExecuteSql(sb.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "你选择的订单确认成功");
                    Get_ydzx_Data();
                }
                if (i <= 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "你没有选择任订单或者确认失败！请选择要确认的订单重试!");
                }
            }
        }

        private void b_Cancell_Click(object sender, EventArgs e)
        {
            List<string> qr_lists = new List<string>();
            int i = 0;
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否真要取消当前选择的预订信息?") == true)
            {
                if (ds_ydzx_Data_sk.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < dg_skyd_ydzx.Rows.Count; j++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();

                        if (dg_skyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_skyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                        {
                            if (this.dg_skyd_ydzx.Rows[j].Cells["id"].Value != null)
                            {
                                int j_000 = 0;
                                DataRowView dgr = dg_skyd_ydzx.Rows[j].DataBoundItem as DataRowView;
                                j_000 = ds_ydzx_Data_sk.Tables[0].Rows.IndexOf(dgr.Row);
                                if (j < dg_skyd_ydzx.Rows.Count)
                                {
                                    string temp = ds_ydzx_Data_sk.Tables[0].Rows[j_000]["id"].ToString();
                                    if (B_common.ExecuteSql(" update  Qskyd_mainrecord  set  shsc=0,czsj='" + DateTime.Now.ToString() + "',syzd='" + common_file.common_app.syzd + "',czy='" + common_file.common_app.czy + "'    where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  id= " + Int32.Parse(ds_ydzx_Data_sk.Tables[0].Rows[j_000]["id"].ToString())) > 0)//确认订单
                                    {
                                        System.Text.StringBuilder sb = new StringBuilder();
                                        sb.Append(" insert into  Qyqskyd_ydzxqr (lsbh, qrzt, qrsj, qryy, czy, shsc, scsj, fjrb, sktt, qymc, yydh)  ");
                                        sb.Append("  values('" + ds_ydzx_Data_sk.Tables[0].Rows[j_000]["lsbh"].ToString() + "','取消','" + DateTime.Now + "','门店取消','" + common_file.common_app.czy + "',0,'" + DateTime.Now + "','" + ds_ydzx_Data_sk.Tables[0].Rows[j_000]["fjrb"].ToString() + "','" + ds_ydzx_Data_sk.Tables[0].Rows[j_000]["sktt"].ToString() + "','" + common_file.common_app.qymc + "','" + common_file.common_app.yydh + "' )");
                                        B_common.ExecuteSql(sb.ToString());


                                        //取销成功后，删除此预订信息
                                        sb = new StringBuilder();
                                        sb.Append(" delete from Qskyd_mainrecord  where id=" + Int32.Parse(ds_ydzx_Data_sk.Tables[0].Rows[j_000]["id"].ToString()) + "  and yydh='" + common_file.common_app.yydh + "'");
                                        i += B_common.ExecuteSql(sb.ToString());

                                        //还要考虑联房的情况
                                        DataSet ds_lf = B_common.GetList(" select   *  from  Flfsz ", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + ds_ydzx_Data_sk.Tables[0].Rows[j_000]["lsbh"].ToString() + "' ");
                                        if (ds_lf != null && ds_lf.Tables[0].Rows.Count > 0)
                                        {
                                            B_common.ExecuteSql(" delete from Qskyd_mainrecord where id=" + Int32.Parse(ds_ydzx_Data_sk.Tables[0].Rows[j_000]["id"].ToString()) + "  and yydh='" + common_file.common_app.yydh + "'");
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                if (ds_ydzx_Data_tt.Tables[0].Rows.Count > 0)
                {

                    for (int j = 0; j < dg_ttyd_ydzx.Rows.Count; j++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();

                        if (dg_ttyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_ttyd_ydzx.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                        {
                            if (this.dg_ttyd_ydzx.Rows[j].Cells["ttzd_id"].Value != null)
                            {
                                int j_000 = 0;
                                DataRowView dgr = dg_ttyd_ydzx.Rows[j].DataBoundItem as DataRowView;
                                j_000 = ds_ydzx_Data_tt.Tables[0].Rows.IndexOf(dgr.Row);
                                if (j < dg_ttyd_ydzx.Rows.Count)
                                {
                                    string temp = ds_ydzx_Data_tt.Tables[0].Rows[j_000]["id"].ToString();
                                    if (B_common.ExecuteSql(" update  Qttyd_mainrecord  set  shsc=0,syzd='" + common_file.common_app.syzd + "',czy='" + common_file.common_app.czy + "'   where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  id= " + Int32.Parse(ds_ydzx_Data_tt.Tables[0].Rows[j_000]["id"].ToString())) > 0)//确认订单
                                    {
                                        System.Text.StringBuilder sb = new StringBuilder();
                                        sb.Append(" insert into  Qyqskyd_ydzxqr (lsbh, qrzt, qrsj, qryy, czy, shsc, scsj, fjrb, sktt, qymc, yydh)  ");
                                        sb.Append("  values('" + ds_ydzx_Data_tt.Tables[0].Rows[j_000]["lsbh"].ToString() + "','取消','" + DateTime.Now + "','门店取消','" + common_file.common_app.czy + "',0,'" + DateTime.Now + "','','" + ds_ydzx_Data_tt.Tables[0].Rows[j_000]["sktt"].ToString() + "','" + common_file.common_app.qymc + "','" + common_file.common_app.yydh + "' )");
                                        i += B_common.ExecuteSql(sb.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                if (i > 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "你选择的订单取消成功");
                    Get_ydzx_Data();
                }
                if (i <= 0)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "你没有选择任订单或者确认失败！请选择要确认的订单重试!");
                }
            }
        }

        private string GetqyOrqxResult()
        {
            return "";
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_ttyd_ydzx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dg_ttyd_ydzx.Rows.Count)
            {
                if (dg_ttyd_ydzx.Rows[e.RowIndex] != null)
                {
                    //int i_000 = dg_Qttdj.CurrentRow.Index;
                    int i_000 = -1;
                    DataRowView dgr = dg_ttyd_ydzx.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    i_000 = ds_ydzx_Data_tt.Tables[0].Rows.IndexOf(dgr.Row);
                    string _ddbh_temp = ds_ydzx_Data_tt.Tables[0].Rows[i_000]["lsbh"].ToString();
                    GetTTdjDetail(_ddbh_temp);
                }
            }
        }

        private void GetTTdjDetail(string lsbh)
        {
            dg_tt_fr_mx.AutoGenerateColumns = false;
            ds_tt_fr_detail = B_common.GetList(" select * from Qskyd_fjrb", " id>=0  and yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'  ");
            bindingSource_ydzx_tt_mx.DataSource = ds_tt_fr_detail.Tables[0].DefaultView;
            dg_tt_fr_mx.DataSource = bindingSource_ydzx_tt_mx;
        }

        private void Get_NewVersion()
        {
             
        }
    }
}