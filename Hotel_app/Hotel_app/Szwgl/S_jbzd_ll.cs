using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class S_jbzd_ll : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        string select_s = ""; string condition = "";
        string czzt_cond_qt = " and (czzt!='" + common_file.common_jzzt.czzt_gz + "' and czzt!='" + common_file.common_jzzt.czzt_jz + "' and czzt!='" + common_file.common_jzzt.czzt_gzzjz + "' and czzt!='" + common_file.common_jzzt.czzt_jzzgz + "')";
        DataSet DS_jbzd;
        string s_c_jbzd = " and czsj>'" + DateTime.Now.AddDays(-10) + "'";
        string lsbh = "";
        int count_jbzd = 0;

        DataSet DS_jbmx;
        string s_c_jbmx = "";
        int count_jbmx = 0;

        DataSet DS_ysk_fs;
        string s_c_ysk_fs = "";
        int count_ysk_fs = 0;


        DataSet DS_ysk;
        string s_c_ysk = "";
        int count_ysk = 0;




        DataSet DS_t_ysk;
        string s_c_t_ysk = "";
        int count_t_ysk = 0;


        DataSet DS_qtfk;
        string s_c_qtfk = "";
        int count_qtfk = 0;


        DataSet DS_ysk_td;
        string s_c_ysk_td = "";
        int count_ysk_td = 0;

        
        public S_jbzd_ll()
        {
            InitializeComponent();
            refresh_all();
        }

        public void refresh_all()
        {
            
            lsbh = "";
            refresh_jbzd();
            //refresh_jbmx();
            //refresh_ysk_fs();
            //refresh_ysk();
            //refresh_t_ysk();
            //refresh_qtfk();
            //refresh_ysk_td();
            TC_jb.SelectedIndex = 0;
        }
        public void refresh_jbzd()
        {
            common_file.common_app.get_czsj();
            select_s = "select * from S_jbzd";
            dg_jbzd.AutoGenerateColumns = false;
            condition = "id>=0  and jb_jk_rx='" + common_zw.jb_jk_jb + "' and  yydh='" + common_file.common_app.yydh + "' " + s_c_jbzd + " order by czsj desc";
            DS_jbzd = B_Common.GetList(select_s, condition);
            if (DS_jbzd != null && DS_jbzd.Tables[0].Rows.Count>0)
            {
                lsbh = DS_jbzd.Tables[0].Rows[0]["lsbh"].ToString();
            }
            bS_jbzd.DataSource = DS_jbzd.Tables[0];

            count_jbzd = DS_jbzd.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }



        public void refresh_jbmx()
        {
            common_file.common_app.get_czsj();
            select_s = "select * from S_jbmx";
            dg_jbmx.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and lsbh='" + lsbh + "' " + s_c_jbmx + " order by id";
            DS_jbmx = B_Common.GetList(select_s, condition);
            bS_jbmx.DataSource = DS_jbmx.Tables[0];

            count_jbmx = DS_jbmx.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }


        public void refresh_ysk_fs()
        {
            common_file.common_app.get_czsj();
            select_s = "select * from Syjcz_jb_fs";
            dg_ysk_fs.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and lsbh_jb='" + lsbh + "' " + s_c_ysk_fs + " order by czy,id";
            DS_ysk_fs = B_Common.GetList(select_s, condition);
            bS_ysk_fs.DataSource = DS_ysk_fs.Tables[0];
            count_ysk_fs = DS_ysk_fs.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }


        public void refresh_ysk()
        {
            common_file.common_app.get_czsj();
            select_s = "select * from Syjcz_jb";
            dg_ysk.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and lsbh_jb='" + lsbh + "' " + s_c_ysk + " order by czy,id";
            DS_ysk = B_Common.GetList(select_s, condition);
            bS_ysk.DataSource = DS_ysk.Tables[0];
            count_ysk = DS_ysk.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }


        public void refresh_t_ysk()
        {
            common_file.common_app.get_czsj();
            select_s = "select * from BS_jzmx_ls_jb";
            dg_t_ysk.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and lsbh_jb='" + lsbh + "'  and xfrb='" + common_file.common_app.dj_ysk + "'  " + czzt_cond_qt + s_c_t_ysk + " order by czy,id";
            DS_t_ysk = B_Common.GetList(select_s, condition);
            bS_t_ysk.DataSource = DS_t_ysk.Tables[0];
            count_t_ysk = DS_t_ysk.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }



        public void refresh_qtfk()
        {
            common_file.common_app.get_czsj();
            select_s = "select * from BS_jzmx_ls_jb";
            dg_qtfk.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and lsbh_jb='" + lsbh + "'  and xfrb!='" + common_file.common_app.dj_ysk + "'  " + czzt_cond_qt + s_c_qtfk + " order by czy,id";
            DS_qtfk = B_Common.GetList(select_s, condition);
            bS_qtfk.DataSource = DS_qtfk.Tables[0];
            count_qtfk = DS_qtfk.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }


        public void refresh_ysk_td()
        {
            common_file.common_app.get_czsj();
            select_s = "select * from Syjcz_jb_td";
            dg_ysk_td.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and lsbh_jb='" + lsbh + "' " + s_c_ysk_td + " order by czy,id";
            DS_ysk_td = B_Common.GetList(select_s, condition);
            bS_ysk_td.DataSource = DS_ysk_td.Tables[0];
            count_ysk_td = DS_ysk_td.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }


        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewSummary2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dg_jbzd_DoubleClick(object sender, EventArgs e)
        {
            if (count_jbzd > 0 && dg_jbzd.CurrentRow.Index < count_jbzd && DS_jbzd.Tables[0].Rows[dg_jbzd.CurrentRow.Index]["id"].ToString() != "")
            {
                lsbh = DS_jbzd.Tables[0].Rows[dg_jbzd.CurrentRow.Index]["lsbh"].ToString();
                refresh_jbmx();

                
                
                
                
                TC_jb.SelectedIndex = 1;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            S_jbzd_add S_jbzd_add_new = new S_jbzd_add();
            S_jbzd_add_new.Left = 250;
            S_jbzd_add_new.Top = 250;
            if (S_jbzd_add_new.ShowDialog() == DialogResult.OK)
            {
                s_c_jbzd = " and czsj>'" + DateTime.Now.AddDays(-10) + "'";
                refresh_all();
            }
            
        }

        private void TC_jb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TC_jb.SelectedIndex == 1)
            {
                s_c_jbmx = "";
                refresh_jbmx();
            }
            else
                if (TC_jb.SelectedIndex == 2)
                {
                    clear_ys_fk();
                    s_c_ysk_fs = "";
                    refresh_ysk_fs();
                }
                else
                    if (TC_jb.SelectedIndex == 3)
                    {
                        clear_ys_fk();
                        s_c_ysk_td = "";
                        refresh_ysk_td();

                    }

                    else
                        if (TC_jb.SelectedIndex == 4)
                        {
                            clear_ys_fk();
                            s_c_t_ysk = "";
                            refresh_t_ysk();
                        }
                        else
                            if (TC_jb.SelectedIndex == 5)
                            {
                                clear_ys_fk();
                                s_c_ysk = "";
                                refresh_ysk();
                            }

                            else
                                if (TC_jb.SelectedIndex == 6)
                                {
                                    clear_ys_fk();
                                    s_c_qtfk = "";
                                    refresh_qtfk();
                                }
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p_gl_zd.Visible = false;
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            gl();
        }
        private void gl()
        {
            s_c_jbzd = " and czsj>'" + DateTime.Now.AddDays(-10) + "'";
            if (TC_jb.SelectedIndex == 0)
            {
                p_gl_zd.BringToFront();
                p_gl_zd.Visible = true;

            }





            if (TC_jb.SelectedIndex == 0)
            {
                s_c_jbzd = " and czsj>'" + DateTime.Now.AddDays(-10) + "'";
                p_gl_zd.BringToFront();
                p_gl_zd.Visible = true;

            }
            if (TC_jb.SelectedIndex == 1)
            {
                //s_c_jbmx = " and czy>'" + tB_mx_czy.Text + "'";
                p_gl_mx.BringToFront();
                p_gl_mx.Visible = true;

            }
            else
                if (TC_jb.SelectedIndex == 2 || TC_jb.SelectedIndex == 3 || TC_jb.SelectedIndex == 4 || TC_jb.SelectedIndex == 5 || TC_jb.SelectedIndex == 6)
                {
                    if (TC_jb.SelectedIndex == 2)
                    {
                        p_gl_ys_fk.Parent = tP_fs;
                    }
                    else
                        if (TC_jb.SelectedIndex == 3)
                        {
                            p_gl_ys_fk.Parent = tP_td;

                        }
                        else
                            if (TC_jb.SelectedIndex == 4)
                            {
                                p_gl_ys_fk.Parent = tP_td_z;
                            }
                            else
                                if (TC_jb.SelectedIndex == 5)
                                {
                                    p_gl_ys_fk.Parent = tP_ye;
                                }
                                else
                                    if (TC_jb.SelectedIndex == 6)
                                    {
                                        p_gl_ys_fk.Parent = tP_fk;
                                    }
                    //if (p_gl_ys_fk.Visible = false)
                    //{
                    clear_ys_fk();
                    //}
                    p_gl_ys_fk.BringToFront();
                    p_gl_ys_fk.Visible = true;
                }

        }


        private void clear_ys_fk()
        {
            dT_ys_fk_czsj_cs.Value = DateTime.Parse(common_file.common_app.cssj);
            dT_ys_fk_czsj_js.Value = DateTime.Parse(common_file.common_app.cssj);
            tB_ys_fk_krxm.Text = "";
            tB_ys_fk_fjbh.Text = "";
            tB_ys_fk_xfxm.Text = "";
            tB_ys_fk_xfbz.Text = "";
            tB_ys_fk_fkfs.Text = "";
            tB_ys_fk_czy.Text = "";
        }




        private void b_save_Click(object sender, EventArgs e)
        {
            string sel_s = "";
            if (DateTime.Parse(dT_czsj_js.Value.ToShortDateString()) < DateTime.Parse(dT_czsj_cs.Value.ToShortDateString()))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，请选择好正确的查询时间！");
            }
            else
            {
                sel_s = sel_s + " and (czsj between '" + dT_czsj_cs.Value.ToShortDateString() + "' and '" + dT_czsj_js.Value.ToShortDateString()+" 23:59:59" + "')";
            }
            if (tB_czy_jb.Text.Trim() != "")
            {
                sel_s = sel_s + " and  czy_jb like '%"+tB_czy_jb.Text.Trim()+"%'";
            }
            if (tB_czy_sb.Text.Trim() != "")
            {
                sel_s = sel_s + " and  czy_sb like '%" + tB_czy_sb.Text.Trim() + "%'";
            }
            if (sel_s != "")
            {
                s_c_jbzd = sel_s;
                refresh_all();
                p_gl_zd.Visible = false;
            }
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            s_c_jbzd = " and czsj>'" + DateTime.Now.AddDays(-10) + "'";
            refresh_all();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {

        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_jbzd_del", common_file.common_app.user_type) == false)
            { return; }
            if (dg_jbzd.CurrentRow == null)
            { return; }
                        int i =dg_jbzd.CurrentRow.Index;
                        if (i < count_jbzd && TC_jb.SelectedIndex == 0)
                        {

                            DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                            if (this.dg_jbzd.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_jbzd.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                            {


                                DataRowView dgr = dg_jbzd.SelectedRows[0].DataBoundItem as DataRowView;
                                if (dgr != null)
                                {
                                    i = DS_jbzd.Tables[0].Rows.IndexOf(dgr.Row);






                                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要删除此记录") == true)
                                    {


                                        if (common_file.common_app.user_type == "administrator")
                                        {




                                            string sql_s = "delete from S_jbzd where lsbh='" + DS_jbzd.Tables[0].Rows[i]["lsbh"].ToString() + "'";

                                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "删除交班记录", DS_jbzd.Tables[0].Rows[i]["czy_jb"].ToString() + "||" + DS_jbzd.Tables[0].Rows[i]["czy_sb"].ToString(), "交班时间：" + DS_jbzd.Tables[0].Rows[i]["czsj"].ToString(), DateTime.Now);
                                            B_Common.ExecuteSql(sql_s);
                                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "已经成功取消！");
                                            b_refresh_Click(sender, e);




                                        }

                                        else
                                        {
                                            DataSet DS_temp_0 = B_Common.GetList("select max(id) as id from S_jbzd", "id>=0 and yydh='" + common_file.common_app.yydh + "' and syzd='" + common_file.common_app.syzd + "'  and jb_jk_rx='" + common_zw.jb_jk_jb + "' ");
                                            {
                                                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                                                {
                                                    if (int.Parse(DS_temp_0.Tables[0].Rows[0]["id"].ToString()) != int.Parse(DS_jbzd.Tables[0].Rows[i]["id"].ToString()))
                                                    {
                                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，当前用户只能删除最新的记录！");
                                                        string sql_s = "delete from S_jbzd where lsbh='" + DS_jbzd.Tables[0].Rows[i]["lsbh"].ToString() + "'";
                                                        common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "删除交班记录", DS_jbzd.Tables[0].Rows[i]["czy_jb"].ToString() + "||" + DS_jbzd.Tables[0].Rows[i]["czy_sb"].ToString(), "交班时间：" + DS_jbzd.Tables[0].Rows[i]["czsj"].ToString(), DateTime.Now);
                                                        B_Common.ExecuteSql(sql_s);
                                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "已经成功取消！");
                                                        b_refresh_Click(sender, e);

                                                    }
                                                }
                                            }
                                            DS_temp_0.Clear();
                                            DS_temp_0.Dispose();
                                        }



                                    }








                                }
                            }
                        }
        }

        private void bS_ysk_fs_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void b_print_jb_Click(object sender, EventArgs e)
        {
            if (this.lsbh.Trim() != "")
            {
                if (DS_jbmx != null && DS_jbmx.Tables[0].Rows.Count > 0)
                {
                    dgvprint_app printFrm = new dgvprint_app(lsbh, "", "jbmx", DS_jbmx); printFrm.Visible = false;
                }
            }
        }

        private void cM_gl_Click(object sender, EventArgs e)
        {
            gl();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            s_c_jbmx = " and syy like '%" + tB_mx_czy.Text + "%'";
            refresh_jbmx();
            p_gl_mx.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s_temp_0 = "";
            if (dT_ys_fk_czsj_cs.Value != DateTime.Parse(common_file.common_app.cssj) && dT_ys_fk_czsj_js.Value != DateTime.Parse(common_file.common_app.cssj) && dT_ys_fk_czsj_js.Value >= dT_ys_fk_czsj_cs.Value)
            {
                if (TC_jb.SelectedIndex == 6 || TC_jb.SelectedIndex == 4 || TC_jb.SelectedIndex == 3)
                {
                    s_temp_0 = s_temp_0 + " and (czsj between '" + dT_ys_fk_czsj_cs.Value.ToShortDateString() + "' and '" + dT_ys_fk_czsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                }
                else
                {
                    s_temp_0 = s_temp_0 + " and (xfsj between '" + dT_ys_fk_czsj_cs.Value.ToShortDateString() + "' and '" + dT_ys_fk_czsj_js.Value.ToShortDateString() + " 23:59:59" + "')";

                }
            }

            if (tB_ys_fk_krxm.Text.Trim() != "")
            {
                s_temp_0 = s_temp_0 + " and krxm like '%" + tB_ys_fk_krxm.Text + "%'";
            }

            if (tB_ys_fk_fjbh.Text.Trim() != "")
            {
                s_temp_0 = s_temp_0 + " and fjbh like '%" + tB_ys_fk_fjbh.Text + "%'";
            }

            if (tB_ys_fk_xfxm.Text.Trim() != "")
            {
                s_temp_0 = s_temp_0 + " and xfxm like '%" + tB_ys_fk_xfxm.Text + "%'";
            }
            if (tB_ys_fk_xfbz.Text.Trim() != "")
            {
                s_temp_0 = s_temp_0 + " and xfbz like '%" + tB_ys_fk_xfbz.Text + "%'";
            }
            if (tB_ys_fk_fkfs.Text.Trim() != "")
            {
                s_temp_0 = s_temp_0 + " and fkfs like '%" + tB_ys_fk_fkfs.Text + "%'";
            }

            if (tB_ys_fk_czy.Text.Trim() != "")
            {
                s_temp_0 = s_temp_0 + " and czy like '%" + tB_ys_fk_czy.Text + "%'";
            }
            if (s_temp_0 != "")
            {

                switch (TC_jb.SelectedIndex)
                {

                    case 2:
                        s_c_ysk_fs = s_c_ysk_fs + s_temp_0;
                        refresh_ysk_fs();
                        break;
                    case 3:
                        s_c_ysk_td = s_c_ysk_td + s_temp_0;
                        refresh_ysk_td();
                        break;
                    case 4:
                        s_c_t_ysk = s_c_t_ysk + s_temp_0;
                        refresh_t_ysk();
                        break;
                    case 5:
                        s_c_ysk = s_c_ysk + s_temp_0;
                        refresh_ysk();
                        break;
                    case 6:
                        s_c_qtfk = s_c_qtfk + s_temp_0;
                        refresh_qtfk();
                        break;
                }



                p_gl_ys_fk.Visible = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p_gl_mx.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear_ys_fk();
            p_gl_ys_fk.Visible = false;
        }

        private void cM_dc_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_Szwgl_outPort", common_file.common_app.user_type) == false)
            { return; }
            string strTitle="";
            if (TC_jb.SelectedIndex== 1)
            {
                if (DS_jbzd != null && DS_jbzd.Tables[0].Rows.Count > 0)
                {
                     strTitle= DateTime.Parse(DS_jbzd.Tables[0].Rows[0]["cssj"].ToString()).ToString("yyyyMMddHHmmss") + "-" + DateTime.Parse(DS_jbzd.Tables[0].Rows[0]["czsj"].ToString()).ToString("yyyyMMddHHmmss");
                }
                common_file.common_DataSetToExcel.ExportMX(DS_jbmx, "S_jbll_mx",strTitle);
            }
            if (TC_jb.SelectedIndex == 2)//发生
            {
                common_file.common_DataSetToExcel.ExportMX(DS_ysk_fs, "S_jbll_ysk_fs","");
            }
            if (TC_jb.SelectedIndex == 3)//退订
            {
                common_file.common_DataSetToExcel.ExportMX(DS_ysk_td, "S_jbll_ysk_td","");
            }
            if (TC_jb.SelectedIndex == 4)//退预收款账务
            {
                common_file.common_DataSetToExcel.ExportMX(DS_t_ysk, "S_jbll_t_ysk", "");
            }
            if (TC_jb.SelectedIndex == 5)//余额
            {
                common_file.common_DataSetToExcel.ExportMX(DS_ysk, "S_jbll_ysk_ye", "");
            }
            if (TC_jb.SelectedIndex == 6)//往来款
            {
                common_file.common_DataSetToExcel.ExportMX(DS_qtfk, "S_jbll_ysk_qtfk","");
            }

        }

        private void dT_ys_fk_czsj_cs_Enter(object sender, EventArgs e)
        {
            dT_ys_fk_czsj_cs.Value = DateTime.Now;
        }

        private void dT_ys_fk_czsj_js_Enter(object sender, EventArgs e)
        {
            dT_ys_fk_czsj_js.Value = DateTime.Now;
        }

        private void dg_ysk_fs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}