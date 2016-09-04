using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hotel_app.Yyxzx
{
    public partial class Yxydw_browse : Form
    {
        public int dg_count = 0;//记录初期加载行数
        BLL.Yxydw B_Yxydw = new BLL.Yxydw();
        Model.Yxydw M_Yxydw = new Model.Yxydw();
        DataSet DS_Yxydw;
        public string lsbhid = "";
        public string xygz = "";
        public string sel_condition = "";
        public Fmain MdiFmain;
        public Yxydw_browse()
        {
            InitializeComponent();
          
            InitializeApp(xygz);
        }


        public void Yxydw_browse_1(string xygz_flage, Fmain MdiFmain)
        {
            xygz = xygz_flage;

            if (xygz == common_file.common_xydw.krly_xydw)
            {
                common_file.common_form.Yxydw_browse_new.Text = "协议单位管理";
                this.bt_xyfj.Visible = true;
                this.b_jzdw.Visible = true;
            }
            if (xygz == common_file.common_xydw.xyrx_gzdw)
            {
                common_file.common_form.Yxydw_browse_new.Text = "挂账单位管理";
                this.bt_xyfj.Visible = false;
                this.b_jzdw.Visible = false;
            }
           
            this.MdiFmain = MdiFmain;
            InitializeApp(xygz);
        }
        public void InitializeApp(string strxygz)
        {
            int id_0 = 0;
            //id_0 = B_Yxydw.GetMaxId()-500;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DS_Yxydw = B_Common.GetList("select top 200 * from Yxydw", " rx='" + strxygz + "'      order by id desc");
            bindingSource1.DataSource = DS_Yxydw.Tables[0];
            dg_count = DS_Yxydw.Tables[0].Rows.Count;
            this.dg_xydw.AutoGenerateColumns = false;
        }
        //刷新
        internal void refresh_app()
        {

            DS_Yxydw = B_Yxydw.GetList("id>=0    " + sel_condition + " and rx='" + xygz + "' order by id desc");
            bindingSource1.DataSource = DS_Yxydw.Tables[0];
            dg_count = DS_Yxydw.Tables[0].Rows.Count;
            dg_xydw.AutoGenerateColumns = false;
        }


       

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (xygz == common_file.common_xydw.krly_xydw)
            {
                if (common_file.common_roles.get_user_qx("B_xydwgl_xz", common_file.common_app.user_type) == false)
                { return; }
            }
            if (xygz == common_file.common_xydw.xyrx_gzdw)
            {
                if (common_file.common_roles.get_user_qx("B_gzdwgl_xz", common_file.common_app.user_type) == false)
                { return; }
            }
            Yyxzx.Yxydw_add_edit Yxydw_add_edit_new = new Yxydw_add_edit(0, xygz, common_file.common_app.get_add);
            Yxydw_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
            Yxydw_add_edit_new.judge_add_edit = common_file.common_app.get_add;
            Yxydw_add_edit_new.ShowDialog();
           
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (xygz == common_file.common_xydw.krly_xydw)
            {
                if (common_file.common_roles.get_user_qx("B_xydwgl_xg", common_file.common_app.user_type) == false)
                { return; }
            }
            if (xygz == common_file.common_xydw.xyrx_gzdw)
            {
                if (common_file.common_roles.get_user_qx("B_gzdwgl_xg", common_file.common_app.user_type) == false)
                { return; }
            }


            if (dg_xydw.CurrentRow != null)
            {
                int i = dg_xydw.CurrentRow.Index;

                DataRowView dgr = dg_xydw.Rows[i].DataBoundItem as DataRowView;
                i = DS_Yxydw.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Yxydw.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    int getid = Convert.ToInt32(DS_Yxydw.Tables[0].Rows[i]["id"]);
                    Yyxzx.Yxydw_add_edit Yxydw_add_edit_new = new Yxydw_add_edit(getid, xygz, common_file.common_app.get_edit);
                   
                    Yxydw_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
               
                    Yxydw_add_edit_new.judge_add_edit = common_file.common_app.get_edit;

                    Yxydw_add_edit_new.Yxydw_id = DS_Yxydw.Tables[0].Rows[i]["id"].ToString();

                    Yxydw_add_edit_new.tB_Email.Text = DS_Yxydw.Tables[0].Rows[i]["kremail"].ToString();
                    Yxydw_add_edit_new.tB_krcz.Text = DS_Yxydw.Tables[0].Rows[i]["krcz"].ToString();
                    Yxydw_add_edit_new.tB_krdh.Text = DS_Yxydw.Tables[0].Rows[i]["krdh"].ToString();
                    Yxydw_add_edit_new.tB_nxr.Text = DS_Yxydw.Tables[0].Rows[i]["nxr"].ToString();
                    Yxydw_add_edit_new.tB_qydz.Text = DS_Yxydw.Tables[0].Rows[i]["krdz"].ToString();
                    Yxydw_add_edit_new.tB_xsy.Text = DS_Yxydw.Tables[0].Rows[i]["xsy"].ToString();
                    Yxydw_add_edit_new.tB_xydw.Text = DS_Yxydw.Tables[0].Rows[i]["xydw"].ToString();
                    Yxydw_add_edit_new.tB_xyh_inner.Text = DS_Yxydw.Tables[0].Rows[i]["xyh_inner"].ToString();
                    Yxydw_add_edit_new.tB_zjm.Text = DS_Yxydw.Tables[0].Rows[i]["zjm"].ToString();
                   // Yxydw_add_edit_new.t.Text = DS_Yxydw.Tables[0].Rows[i]["bz"].ToString();
                   
                  
                    Yxydw_add_edit_new.tB_bz.Text = DS_Yxydw.Tables[0].Rows[i]["bz"].ToString();

                    Yxydw_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }
       

        private void dg_xydw_DoubleClick(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_xydw.CurrentRow != null)
            {
                int i = dg_xydw.CurrentRow.Index;

                DataRowView dgr = dg_xydw.Rows[i].DataBoundItem as DataRowView;
                i = DS_Yxydw.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Yxydw.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    int getid = Convert.ToInt32(DS_Yxydw.Tables[0].Rows[i]["id"]);
                    Yyxzx.Yxydw_add_edit Yxydw_add_edit_new = new Yxydw_add_edit(getid, xygz, common_file.common_app.get_edit);

                    Yxydw_add_edit_new.StartPosition = FormStartPosition.CenterScreen;

                    Yxydw_add_edit_new.judge_add_edit = common_file.common_app.get_edit;

                    Yxydw_add_edit_new.Yxydw_id = DS_Yxydw.Tables[0].Rows[i]["id"].ToString();

                    Yxydw_add_edit_new.tB_Email.Text = DS_Yxydw.Tables[0].Rows[i]["kremail"].ToString();
                    Yxydw_add_edit_new.tB_krcz.Text = DS_Yxydw.Tables[0].Rows[i]["krcz"].ToString();
                    Yxydw_add_edit_new.tB_krdh.Text = DS_Yxydw.Tables[0].Rows[i]["krdh"].ToString();
                    Yxydw_add_edit_new.tB_nxr.Text = DS_Yxydw.Tables[0].Rows[i]["nxr"].ToString();
                    Yxydw_add_edit_new.tB_qydz.Text = DS_Yxydw.Tables[0].Rows[i]["krdz"].ToString();
                    Yxydw_add_edit_new.tB_xsy.Text = DS_Yxydw.Tables[0].Rows[i]["xsy"].ToString();
                    Yxydw_add_edit_new.tB_xydw.Text = DS_Yxydw.Tables[0].Rows[i]["xydw"].ToString();
                    Yxydw_add_edit_new.tB_xyh_inner.Text = DS_Yxydw.Tables[0].Rows[i]["xyh_inner"].ToString();
                    Yxydw_add_edit_new.tB_zjm.Text = DS_Yxydw.Tables[0].Rows[i]["zjm"].ToString();
                    // Yxydw_add_edit_new.t.Text = DS_Yxydw.Tables[0].Rows[i]["bz"].ToString();

                    Yxydw_add_edit_new.tB_bz.Text = DS_Yxydw.Tables[0].Rows[i]["bz"].ToString();
                    Yxydw_add_edit_new.tb_sxed.Text = DS_Yxydw.Tables[0].Rows[i]["xsed"].ToString();

                    Yxydw_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (xygz == common_file.common_xydw.krly_xydw)
            {
                if (common_file.common_roles.get_user_qx("B_xydwgl_sc", common_file.common_app.user_type) == false)
                { return; }
            }
            if (xygz == common_file.common_xydw.xyrx_gzdw)
            {
                if (common_file.common_roles.get_user_qx("B_gzdwgl_sc", common_file.common_app.user_type) == false)
                { return; }
            }
            if (DS_Yxydw != null && DS_Yxydw.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_xydw.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_xydw.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_xydw.Rows[i].Index.ToString());

                            DataRowView dgr = dg_xydw.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Yxydw.Tables[0].Rows.IndexOf(dgr.Row);


                            if (DS_Yxydw.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                byte[] imageb = new byte[0];
                                string url = common_file.common_app.service_url + "Yyxzx/Yyxzx_app.asmx";
                                object[] args = new object[21];
                                args[0] = DS_Yxydw.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
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

                                args[15] = imageb;
                                args[16] = "";
                                args[17] = "";
                                args[18] = common_file.common_app.get_delete;
                                args[19] = common_file.common_app.xxzs;
                                args[20] = "0";

                                Hotel_app.Server.Yyxzx.Yxydw Yxydw_services = new Hotel_app.Server.Yyxzx.Yxydw();
                                string result = Yxydw_services.Yxydw_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), imageb, args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(),args[20].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Yxydw_add_edit", args);
                                if (result== common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
                                {
                                    s = common_file.common_app.get_suc;
                                }
                                else s = common_file.common_app.get_failure;

                            }


                        }

                    }
                    if (s == common_file.common_app.get_suc)
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功！");
                    else
                        if (s == common_file.common_app.get_failure) common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除不成功！");
                    refresh_app();

                }
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            

        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            InitializeApp(xygz);
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            if (xygz == common_file.common_xydw.krly_xydw)
            {
                if (common_file.common_roles.get_user_qx("B_xydwgl_gl", common_file.common_app.user_type) == false)
                { return; }
            }
            if (xygz == common_file.common_xydw.xyrx_gzdw)
            {
                if (common_file.common_roles.get_user_qx("B_gzdwgl_gl", common_file.common_app.user_type) == false)
                { return; }
            }


            sel_condition = "";
            Yyxzx.Yxydw_gl Yxydw_gl_new = new Yxydw_gl();
            Yxydw_gl_new.StartPosition = FormStartPosition.CenterScreen;
 
            if (Yxydw_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_condition = sel_condition + Yxydw_gl_new.get_sel_cond;
                if (Yxydw_gl_new.get_sel_cond != "")
                {
                    refresh_app();
                }
            }

            Yxydw_gl_new.Dispose();

        }

        private void b_jzdw_Click(object sender, EventArgs e)
        {
            SaveNew_jzdw();
        }
        private void SaveNew_jzdw()
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_xydwgl_zh", common_file.common_app.user_type) == false)
            { return; }
            if (DS_Yxydw != null && DS_Yxydw.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要转换所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_xydw.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_xydw.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_xydw.Rows[i].Index.ToString());

                            DataRowView dgr = dg_xydw.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Yxydw.Tables[0].Rows.IndexOf(dgr.Row);


                            if (DS_Yxydw.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                int strid = int.Parse(DS_Yxydw.Tables[0].Rows[j]["id"].ToString());
                                s = common_file.common_xydw.UpdateRx(strid);
                            }


                        }

                    }
                    if (s == common_file.common_app.get_suc)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "转换成功！");
                        DS_Yxydw = B_Yxydw.GetList("id>=0  order by id desc");
                        bindingSource1.DataSource = DS_Yxydw.Tables[0];
                        dg_count = DS_Yxydw.Tables[0].Rows.Count;
                        dg_xydw.AutoGenerateColumns = false;
                        //refresh_app();
                    }
                    else
                        if (s == common_file.common_app.get_failure) common_file.common_app.Message_box_show(common_file.common_app.message_title, "转换不成功！");

                }
            Cursor.Current = Cursors.Default;

        }

        private void bt_xyfj_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_xydwgl_szfj", common_file.common_app.user_type) == false)
            { return; }

            if (DS_Yxydw != null && DS_Yxydw.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要设置所选协议单位的房价！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_xydw.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_xydw.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_xydw.Rows[i].Index.ToString());

                            DataRowView dgr = dg_xydw.Rows[i].DataBoundItem as DataRowView;
                            i = DS_Yxydw.Tables[0].Rows.IndexOf(dgr.Row);



                            if (DS_Yxydw.Tables[0].Rows[i]["id"].ToString() != "")
                            {
                                int strid = int.Parse(DS_Yxydw.Tables[0].Rows[i]["id"].ToString());
                                Yyxzx.Yxydw_fjrb_add_edit Yxydw_fjrb_add_edit_new = new Yxydw_fjrb_add_edit(this);
                                Yxydw_fjrb_add_edit_new.xyh=DS_Yxydw.Tables[0].Rows[i]["xyh"].ToString();
                                Yxydw_fjrb_add_edit_new.tB_xydw.Text = DS_Yxydw.Tables[0].Rows[i]["xydw"].ToString();
                                Yxydw_fjrb_add_edit_new.StartPosition = FormStartPosition.CenterScreen;
                                Yxydw_fjrb_add_edit_new.ShowDialog();
                               
                            }


                        }

                    }
                    ;

                }
            Cursor.Current = Cursors.Default;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}