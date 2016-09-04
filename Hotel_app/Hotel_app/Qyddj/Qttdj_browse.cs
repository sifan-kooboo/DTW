using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qttdj_browse : Form
    {
        public Qttdj_browse()
        {
            InitializeComponent();
        }

        #region 成员
        string yddj = common_file.common_yddj.yddj_yd;
        Fmain MdiFmain = new Fmain();
        Hotel_app.BLL.Common B_common = new Hotel_app.BLL.Common();
        public int dg_count = 0;
        DataSet DS_ttdj = new DataSet();
        string sel_condition = "";
        public string get_qxyy = "";//获得取消原因，通过qtyq这个参数来传递。
        public string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
        #endregion
        public void InitalApp()
        {
            this.dg_Qttdj.AutoGenerateColumns = false;
            this.dg_Qttdj.DataSource = null;
        }
        internal void loadInfo(string yddj, Fmain MdiFmain)
        {
            this.yddj = yddj;
            this.MdiFmain = MdiFmain;
            load_refresh();
            setFormText();

            //窗体初始加载的时候绑定默认显示第一条的数据
            dg_frfs.DataSource = null;
            dg_ttdj_Detail.DataSource = null;
                if (dg_Qttdj.Rows.Count > 0)
                {
                    if (dg_Qttdj.Rows[0] != null)
                    {
                        //int i_000 = dg_Qttdj.CurrentRow.Index;
                        int i_000 = -1;
                        DataRowView dgr = dg_Qttdj.Rows[0].DataBoundItem as DataRowView;
                        i_000 = DS_ttdj.Tables[0].Rows.IndexOf(dgr.Row);
                        string _ddbh_temp = DS_ttdj.Tables[0].Rows[i_000]["ddbh"].ToString();
                        GetTTdjDetail(_ddbh_temp);
                    }
                }
        }
        void load_refresh()
        {
            sel_condition = "";
            if (yddj != common_file.common_app.get_his)
            { 
                refresh("");
            }
            else
            {
                refresh(" and czsj>'"+DateTime.Now.AddDays(-7).ToShortDateString()+"'");
            }
        }
        public void refresh(string sel_cond_0)
        {

            this.dg_Qttdj.AutoGenerateColumns = false;
            DS_ttdj = new DataSet();
            if (yddj != common_file.common_app.get_his)
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    DS_ttdj = B_common.GetList("select * from  View_Qttzd", "  id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sel_condition + "  and yddj='" + this.yddj + "'  and  ( (ddyy!='" + common_file.common_app.ydzx_flag + "' )   or ( ddyy='" + common_file.common_app.ydzx_flag + "'   and shsc=0  ) )    order by id desc");
                }
                else
                
                    if (yddj == common_file.common_yddj.yddj_dj)
                    {
                        DS_ttdj = B_common.GetList("select * from  View_Qttzd", "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sel_condition + "  and ((yddj='" + common_file.common_yddj.yddj_dj + "') or (yddj='" + common_file.common_yddj.yddj_yd + "' and ddbh in(select ddbh from Qskyd_mainrecord where yddj='"+common_file.common_yddj.yddj_dj+"'))) order by id desc");
                    }
                
            }
            else
            {
                DS_ttdj = B_common.GetList("select * from  VIEW_Qttyd_bak", "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sel_cond_0+sel_condition + "  order by id desc");
            }
            try
            {
                bindingSource_display.DataSource = DS_ttdj.Tables[0].DefaultView;
                dg_Qttdj.DataSource = bindingSource_display;
                dg_count = DS_ttdj.Tables[0].Rows.Count;
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.ToString());
            }

        }
        public void setFormText()
        {
            if (this.yddj == common_file.common_yddj.yddj_dj)
            {
                common_file.common_form.Qttdj_browse_new.Text = "团体登记查询";
            }
            if (this.yddj == common_file.common_yddj.yddj_yd)
            {
                common_file.common_form.Qttdj_browse_new.Text = "团体预订查询";
            }
            if (this.yddj == common_file.common_app.get_his)
            {
                common_file.common_form.Qttdj_browse_new.Text = "已退团体查询";
            }
        }

        private void open_record()
        {
            common_file.common_app.get_czsj();
            if (dg_count > 0 && dg_Qttdj.Rows[0].Cells["id"].Value != null && dg_Qttdj.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            {
                //得到ID
                int i = dg_Qttdj.CurrentRow.Index;
                if (i > -1 && i < dg_count)//当前行为内容行
                {
                    int id = Convert.ToInt32(dg_Qttdj.Rows[i].Cells["id"].Value);
                    if (yddj != common_file.common_app.get_his)
                    {
                        common_file.common_form.Qttdj_new_open(id.ToString(), this.yddj, common_file.common_app.get_edit, true);
                    }
                    else
                    {
                        common_file.common_form.Qttdj_new_open(id.ToString(), this.yddj, this.yddj, false);
                    
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void dg_Qttdj_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            open_record();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_tt_dj_save", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_save", common_file.common_app.user_type) == false)
                    { return; }

                }
            }


            open_record();
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_tt_dj_xz", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_xz", common_file.common_app.user_type) == false)
                    { return; }

                }
            }
            common_file.common_form.Qttdj_new_open("", this.yddj, common_file.common_app.get_add, false);
            if (common_file.common_form.Qttdj_new.add_edit == common_file.common_app.get_add)
            {
                common_file.common_form.Qttdj_new.czjl("   and  1=2  ", common_file.common_app.get_add);
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_tt_dj_ll_sc", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_ll_sc", common_file.common_app.user_type) == false)
                    { return; }

                }
            }



            common_file.common_app.get_czsj();
            int judge_cz = 1;//1为可以，2为不可以；
            if (dg_Qttdj.CurrentRow != null)
            {
                int i = dg_Qttdj.CurrentRow.Index;
                DataRowView dgr = dg_Qttdj.CurrentRow.DataBoundItem as DataRowView;
                int j_del = DS_ttdj.Tables[0].Rows.IndexOf(dgr.Row);
                if (i < dg_count)
                {
                    DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                    if (this.dg_Qttdj.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_Qttdj.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要删除此记录") == true)
                        {
                            judge_cz = 1;
                            BLL.Common B_Common = new Hotel_app.BLL.Common();
                            DataSet ds_temp_0 = B_common.GetList("select id from Syjcz", "lsbh='" + DS_ttdj.Tables[0].Rows[j_del]["lsbh"].ToString() + "'");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人有产生预收款了，如果确实要删除请先退还预收款！");
                                return;
                            }
                            ds_temp_0 = B_common.GetList("select id from Szwmx", "lsbh='" + DS_ttdj.Tables[0].Rows[j_del]["lsbh"].ToString() + "'");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人有产生消费了，如果确实要删除请先转出消费！");
                                return;
                            }
                            ds_temp_0 = B_common.GetList("select id from Syjcz", "lsbh in (select lsbh from Qskyd_mainrecord where ddbh='" + DS_ttdj.Tables[0].Rows[j_del]["ddbh"].ToString() + "')");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，成员有产生预收款了，如果确实要删除请先退还成员的预收款！");
                                return;
                            }
                            ds_temp_0 = B_common.GetList("select id from Szwmx", "lsbh in (select lsbh from Qskyd_mainrecord where ddbh='" + DS_ttdj.Tables[0].Rows[j_del]["ddbh"].ToString() + "')");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，成员有产生消费了，如果确实要删除请先转出成员的消费！");
                                return;
                            }


                            ds_temp_0 = B_common.GetList("select distinct yddj from Qskyd_mainrecord", "ddbh ='" + DS_ttdj.Tables[0].Rows[j_del]["ddbh"].ToString() + "' and (yddj='"+common_file.common_yddj.yddj_yd+"' or yddj='"+common_file.common_yddj.yddj_dj+"')");
                            if(ds_temp_0!=null)
                                if (ds_temp_0.Tables[0].Rows.Count > 1)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，这是张有部分转登记的预订单,如果只是预订成员要取消请直接去预订界面删除成员预订单！如果要包括在住的单据都要取消,请先把所有预订成员都取消掉才可以！");
                                    return;
                                
                                
                                }




                            Qyddj.Q_bz_input Q_bz_input_new = new Q_bz_input();
                            Q_bz_input_new.Text = "请输入操作理由";
                            Q_bz_input_new.Left = 200;
                            Q_bz_input_new.Top = 150;
                            if (Q_bz_input_new.ShowDialog() == DialogResult.OK)
                            {
                                get_qxyy = Q_bz_input_new.get_bz;
                            }
                            Q_bz_input_new.Dispose();





                            common_file.common_app.get_czsj();



                            string[] args = new string[34];
                            args[0] = DS_ttdj.Tables[0].Rows[j_del]["id"].ToString();
                            args[1] = "";
                            args[2] = "";
                            args[3] = "";
                            args[4] = "";
                            args[5] = "";
                            args[6] = "";
                            args[7] = "";
                            args[8] = "";
                            args[9] = "";
                            args[10] = "";
                            args[11] = "";
                            args[12] = "";
                            args[13] = "";
                            args[14] = "";
                            args[15] = "";
                            args[16] = "";
                            args[17] = "";
                            args[18] = "";
                            args[19] = "";
                            args[20] = "";
                            args[21] = "";
                            args[22] = get_qxyy;
                            args[23] = "";
                            args[24] = "";
                            args[25] = "";
                            args[26] = common_file.common_app.czy;
                            args[27] = common_file.common_yddj.yddj_qx;
                            args[28] = DateTime.Now.ToString();
                            args[29] = "";
                            args[30] = "";
                            args[31] = common_file.common_app.get_delete;
                            args[32] = common_file.common_app.xxzs;
                            args[33] = "";

                            Hotel_app.Server.Qyddj.Qttyd_add_edit_delete Qttyd_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qttyd_add_edit_delete();
                            string result = Qttyd_add_edit_delete_services.Qttyd_add_edit_delete_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(),
               args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString(), args[30].ToString(), args[31].ToString(),
               args[32].ToString(), args[33].ToString());
                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qttyd_add_edit_delete_app", args);
                            if (result== common_file.common_app.get_suc)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功！");
                                refresh("");
                            }
                            else
                            { common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除失败！"); }
                            ds_temp_0.Clear();
                            ds_temp_0.Dispose();
                        }

                    }
                }
            }


            Cursor.Current = Cursors.Default;
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            
            load_refresh();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_tt_yddj_ll_cx", common_file.common_app.user_type) == false)
                { return; }

            Qyddj.Q_sktt_gl Q_sktt_gl_new = new Q_sktt_gl("tt");
            Q_sktt_gl_new.Left = 130;
            Q_sktt_gl_new.Top = 70;
            if (Q_sktt_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_condition = sel_condition+Q_sktt_gl_new.get_sel_cond;
                if (Q_sktt_gl_new.get_sel_cond != "")
                {
                    refresh("");
                }
            }

            Q_sktt_gl_new.Dispose();
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bindingSource_display.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bindingSource_display.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bindingSource_display.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bindingSource_display.MoveLast();
        }

        //设置成员房费自付
        private void b_setCyFF_Click(object sender, EventArgs e)
        {

            if (common_file.common_roles.get_user_qx("B_cyffzf", common_file.common_app.user_type) == false)
            { return; }
            if (dg_Qttdj.CurrentRow != null)
            {
                int i_000 =dg_Qttdj.CurrentRow.Index;
                DataRowView dgr = dg_Qttdj.Rows[i_000].DataBoundItem as DataRowView;
                i_000 = DS_ttdj.Tables[0].Rows.IndexOf(dgr.Row);
                string tt_zd_id = DS_ttdj.Tables[0].Rows[i_000]["id"].ToString();
                Szwgl.common_zw.SetTTcyFF(tt_zd_id, "tt");
            } 
        }

        private void dg_Qttdj_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        //绑定详细信息
        private void GetTTdjDetail(string ddbh)
        {
            if (ddbh.Trim() != "")
            {
                dg_ttdj_Detail.AutoGenerateColumns = false;
                dg_frfs.AutoGenerateColumns = false;
                StringBuilder  sb=null;
                string cond="";
                if (yddj != common_file.common_app.get_his)
                {
                    sb = new StringBuilder();
                    sb.Append(" select * from View_Qskzd ");
                    cond = " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  ddbh='" + ddbh + "'";
                    DataSet ds_TTdjDetail = B_common.GetList(sb.ToString(), cond);
                    //if (ds_TTdjDetail != null && ds_TTdjDetail.Tables[0].Rows.Count > 0)
                    //{
                        bindingSource_ttdj_Details.DataSource = ds_TTdjDetail.Tables[0].DefaultView;
                        dg_ttdj_Detail.DataSource = bindingSource_ttdj_Details;
                        sb = new StringBuilder();
                        sb.Append(" select fjrb,sjfjjg,sum(lzfs)  as  fs_Total  from Qskyd_fjrb ");
                        //cond = "  ddbh='" + ddbh + "' group by fjrb,sjfjjg ";
                        cond = "  ( lzfs>0 and ((lsbh in (select distinct lsbh from Qskyd_mainrecord  where   ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "')) or (lsbh in (select lsbh from Qttyd_mainrecord where ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "'))";
                        cond = cond + " or (lsbh in (select distinct lsbh from Qskyd_mainrecord_bak  where   ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "'))) )  group by fjrb,sjfjjg";

                        DataSet ds_frfs = B_common.GetList(sb.ToString(), cond);
                        if (ds_frfs != null && ds_frfs.Tables[0].Rows.Count > 0)
                        {
                            bindingSource_frfs.DataSource = ds_frfs.Tables[0].DefaultView;
                            dg_frfs.DataSource = bindingSource_frfs;
                        }
                        else
                        {
                            dg_frfs.DataSource = null;
                        }

                    //}
                    //else
                    //{
                    //    dg_ttdj_Detail.DataSource = null;
                    //    dg_frfs.DataSource = null;
                    //}
                }
                if (yddj == common_file.common_app.get_his)
                {
                    sb = new StringBuilder();
                    sb.Append(" select * from VIEW_Qskyd_bak ");
                    cond = " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  ddbh='" + ddbh + "'";
                    DataSet ds_TTdjDetail = B_common.GetList(sb.ToString(), cond);
                    //if (ds_TTdjDetail != null && ds_TTdjDetail.Tables[0].Rows.Count > 0)
                    //{
                        bindingSource_ttdj_Details.DataSource = ds_TTdjDetail.Tables[0].DefaultView;
                        dg_ttdj_Detail.DataSource = bindingSource_ttdj_Details;
                        sb = new StringBuilder();
                        sb.Append(" select fjrb,sjfjjg,sum(lzfs)  as  fs_Total  from Qskyd_fjrb_bak ");
                      
                        cond = "  (lzfs>=0 and ((lsbh in (select distinct lsbh from Qskyd_mainrecord_bak  where   ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "')) or (lsbh in (select lsbh from Qttyd_mainrecord_bak where ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "'))))   group by fjrb,sjfjjg";
                        DataSet ds_frfs = B_common.GetList(sb.ToString(), cond);
                        if (ds_frfs != null && ds_frfs.Tables[0].Rows.Count > 0)
                        {
                            bindingSource_frfs.DataSource = ds_frfs.Tables[0].DefaultView;
                            dg_frfs.DataSource = bindingSource_frfs;
                        }
                        else
                        {
                            dg_frfs.DataSource = null;
                        }

                    //}
                    //else
                    //{
                        //dg_ttdj_Detail.DataSource = null;
                        //dg_frfs.DataSource = null;
                    //}
                }

            }
        }

        private void dg_Qttdj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dg_Qttdj.Rows.Count)
            {
                if (dg_Qttdj.Rows[e.RowIndex] != null)
                {
                    //int i_000 = dg_Qttdj.CurrentRow.Index;
                    int i_000 = -1;
                    DataRowView dgr = dg_Qttdj.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    i_000 = DS_ttdj.Tables[0].Rows.IndexOf(dgr.Row);
                    string _ddbh_temp = DS_ttdj.Tables[0].Rows[i_000]["ddbh"].ToString();
                    GetTTdjDetail(_ddbh_temp);
                }
            }
        }

        private void Qttdj_browse_Load(object sender, EventArgs e)
        {

        }
    }
}