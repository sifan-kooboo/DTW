using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common;
using System.Collections;
using System.IO;

namespace Hotel_app.Qyddj
{
    public partial class Qskdj_browse : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();

        //窗体初始加载的时候要确定是通过主窗体的哪个按纽打开的
        public string yddj = "";
        public string main_sec = common_file.common_app.main_sec_main;
        public string sel_condition = "";
        public DataSet DS_Qskdj;
        public int dg_count = 0;
        public string select_s = "";
        public string get_qxyy = "";//获得取消原因，通过qtyq这个参数来传递。
        string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";

        public Fmain MdiFmain;
        public Qskdj_browse()
        {
            InitializeComponent();
            //refresh_app();
        }

        public void Qskdj_browse_1(string yddj_flage, Fmain MdiFmain, string main_sec_0)
        {
            yddj = yddj_flage;
            main_sec = main_sec_0;
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                common_file.common_form.Qskdj_browse_new.Text = "散客登记查询";
            }
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                common_file.common_form.Qskdj_browse_new.Text = "散客预订查询";
            }
            if (yddj == common_file.common_app.get_his)
            {
                common_file.common_form.Qskdj_browse_new.Text = "已退客房查询";
            }
            this.MdiFmain = MdiFmain;
            load_refresh();
        }
        void load_refresh()
        {
            sel_condition = "";
            if (yddj != common_file.common_app.get_his)
            {
                refresh_app("");
            }
            else
            {
                refresh_app(" and czsj>'" + DateTime.Now.AddDays(-7) + "' ");
            }
        }
        #region 自定义方法
        //初始化数据
        //public void InitializeApp()
        //{
        //    select_s = "select * from View_Qskzd";
        //    dg_skdj.AutoGenerateColumns = false;
        //    string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sel_condition + " and   yddj='" + yddj + "'  order by id ";
        //    DS_Qskdj = B_Common.GetList(select_s, condition);
        //    bindingSource1.DataSource = DS_Qskdj.Tables[0];
        //    dg_count = DS_Qskdj.Tables[0].Rows.Count;
        //}
        //窗体刷新
        public void refresh_app(string sel_cond_0)
        {
            string condition = "";
            string sel_main_sec = "";
            if (main_sec == common_file.common_app.main_sec_main)
            {
                sel_main_sec = " and main_sec='" + common_file.common_app.main_sec_main + "'";
            }
            if (yddj != common_file.common_app.get_his)
            {
                select_s = "select * from View_Qskzd";
                if (yddj == common_file.common_yddj.yddj_dj)//登记显示团体成员
                {
                    condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' " + sel_main_sec + sel_condition + " and   yddj='" + yddj + "'            order by czsj  desc ";
                }
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    condition = "id>=0 and yydh='" + common_file.common_app.yydh + "' " + sel_main_sec + sel_condition + "  and yddj='" + yddj + "'  and     (sktt!='" + common_file.common_sktt.sktt_tt + "'  and sktt!='" + common_file.common_sktt.sktt_hy + "')   and ( ( ddyy!='" + common_file.common_app.ydzx_flag + "')  or  (       ddyy='" + common_file.common_app.ydzx_flag + "'    and   shsc=0  )        )  order by czsj desc";
                }
            }
            else
            {
                select_s = "select * from VIEW_Qskyd_bak";
                condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' " + sel_cond_0 + sel_main_sec + sel_condition + " order by id Desc";
            }
            if (condition != "")
            {
                dg_skdj.AutoGenerateColumns = false;
                DS_Qskdj = B_Common.GetList(select_s, condition);
                bindingSource1.DataSource = DS_Qskdj.Tables[0];
                dg_count = DS_Qskdj.Tables[0].Rows.Count;
            }
        }
        #endregion

        private void open_record()
        {
            common_file.common_app.get_czsj();
            if (dg_count > 0 && dg_skdj.Rows[0].Cells["id"].Value != null && dg_skdj.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            {
                int i = dg_skdj.CurrentRow.Index;
                if (i > -1 && i < dg_count)//当前行为内容行
                {
                    int id = Convert.ToInt32(dg_skdj.Rows[i].Cells["id"].Value);
                    if (yddj != common_file.common_app.get_his)
                    {
                        common_file.common_form.Qskdj_new_open(id.ToString(), yddj, common_file.common_app.get_edit, common_file.common_app.main_sec_main);
                    }
                    else
                    {
                        common_file.common_form.Qskdj_new_open(id.ToString(), yddj, common_file.common_app.get_his, common_file.common_app.main_sec_main);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        #region 快捷键事件
        private void b_amend_Click(object sender, EventArgs e)
        {

            //同主单介面的保存权限
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_save", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_save", common_file.common_app.user_type) == false)
                    { return; }

                }
            }
            open_record();

        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            main_sec = common_file.common_app.main_sec_main;
            load_refresh();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            //这里同主单的权限
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_xz", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_xz", common_file.common_app.user_type) == false)
                    { return; }

                }
            }


            if (common_file.common_form.Qskdj_new == null || common_file.common_form.Qskdj_new.IsDisposed)
            {
                common_file.common_form.Qskdj_new = new Hotel_app.Qyddj.Qskdj();
                common_file.common_form.Qskdj_new.MdiParent = MdiFmain;
                common_file.common_form.Qskdj_new.Show();
            }
            common_file.common_form.Qskdj_new.Activate();
            common_file.common_form.Qskdj_new.Qskdj_2(yddj, common_file.common_app.get_add);
            if (common_file.common_form.Qskdj_new.add_edit == common_file.common_app.get_add)
            {
                common_file.common_form.Qskdj_new.czjl_ls("   and  1=2  ", common_file.common_app.get_add);
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {

            if (common_file.common_roles.get_user_qx("B_sk_yddj_ll_cx", common_file.common_app.user_type) == false)
            { return; }

            Qyddj.Q_sktt_gl Q_sktt_gl_new = new Q_sktt_gl("sk");
            Q_sktt_gl_new.Left = 130;
            Q_sktt_gl_new.Top = 70;
            if (Q_sktt_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_condition = sel_condition + Q_sktt_gl_new.get_sel_cond;
                if (Q_sktt_gl_new.get_sel_cond != "")
                {
                    //refresh_app("");
                    refresh_app(sel_condition);
                }
            }

            Q_sktt_gl_new.Dispose();
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void b_delete_Click(object sender, EventArgs e)
        {

            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_ll_sc", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_ll_sc", common_file.common_app.user_type) == false)
                    { return; }

                }
            }


            common_file.common_app.get_czsj();
            string[] id_arg = new string[dg_skdj.Rows.Count];
            int sl_id = 0;
            int judge_ky = 2;//2可用，3不可用
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_temp_0 = B_Common.GetList("select * from Qcounter", "id>=0");

            for (int j = 0; j < dg_count; j++)
            {
                common_file.common_app.get_czsj();
                DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                if (this.dg_skdj.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_skdj.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                {
                    if (this.dg_skdj.Rows[j].Cells["id"].Value != null)
                    {

                        int j_000 = 0;
                        DataRowView dgr = dg_skdj.Rows[j].DataBoundItem as DataRowView;
                        j_000 = DS_Qskdj.Tables[0].Rows.IndexOf(dgr.Row);

                        judge_ky = 2;
                        if (j < dg_count)
                        {
                            ds_temp_0 = B_common.GetList("select id from Syjcz", "lsbh='" + DS_Qskdj.Tables[0].Rows[j_000]["lsbh"].ToString() + "'");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人" + DS_Qskdj.Tables[0].Rows[j_000]["krxm"].ToString() + "有产生预收款了，如果确实要删除请先退还预收款！"); return;
                                judge_ky = 3;
                            }
                            if (judge_ky == 2)
                            {
                                ds_temp_0 = B_common.GetList("select id from Szwmx", "lsbh='" + DS_Qskdj.Tables[0].Rows[j_000]["lsbh"].ToString() + "'");
                                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人" + DS_Qskdj.Tables[0].Rows[j_000]["krxm"].ToString() + "有产生消费了，如果确实要删除请先转出相应消费！"); return;
                                    judge_ky = 3;
                                }
                            }
                            if (judge_ky == 2)
                            {

                                id_arg[j] = this.dg_skdj.Rows[j].Cells["id"].Value.ToString();
                            }
                        }
                        if (judge_ky == 2)
                        {
                            sl_id += 1;
                        }
                    }
                }
            }
            ds_temp_0.Dispose();

            if (id_arg.Length > 0 && sl_id <= 50 && sl_id > 0)
            {
                if (sl_id > 0)
                {

                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要删除所选的主单记录嘛？") == true)
                    {
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



                        url = common_file.common_app.service_url;
                        url += "Qyddj/Qyddj_app.asmx";
                        object[] args_1 = new object[8];
                        args_1[0] = id_arg;
                        args_1[1] = "sc";
                        args_1[2] = common_file.common_yddj.yddj_qx;
                        args_1[3] = get_qxyy;
                        args_1[4] = "";
                        args_1[5] = common_file.common_app.czy;
                        args_1[6] = DateTime.Now.ToString();
                        args_1[7] = common_file.common_app.xxzs;

                        Hotel_app.Server.Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();

                        string  result_temp=Qyddj_add_edit_delete_services.delete_sk_multi(id_arg, args_1[1].ToString(), args_1[2].ToString(), args_1[3].ToString(), args_1[4].ToString(), args_1[5].ToString(), args_1[6].ToString(), args_1[7].ToString());



                        //object result_temp = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "delete_sk_multi", args_1);
                        if (result_temp != null && result_temp == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除记录成功!");
                            //如何删除会员有排房的预订，那么发短信提示删除





                            this.refresh_app("");
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除记录失败!");

                        }
                    }
                }


            }
            else
            {
                string errorMsg = "";
                if (sl_id == 0)
                { errorMsg = "没有选择任何记录,请选择你要删除的记录"; }
                else
                {
                    errorMsg = "选择记录超过50条，请取消你超过的记录";
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, errorMsg);
            }
            Cursor.Current = Cursors.Default;

        }
        #endregion

        private void sendMsm(string zd_id_0)
        {
 
        }

        private void dg_skdj_DoubleClick(object sender, EventArgs e)
        {
            open_record();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                main_sec = "";
                load_refresh();
            }
        }

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_yddj_outport", common_file.common_app.user_type) == false)
            { return; }
            if (DS_Qskdj != null && DS_Qskdj.Tables[0].Rows.Count > 0)
            {
                string filePath = "";
                string fileName = "";
                string get_fileName = "";
                Hashtable nameList=new Hashtable();
                if (yddj != common_file.common_app.get_his)
                {
                    //生成列的中文对应表
                    common_file.common_DataSetToExcel.ExportMX(DS_Qskdj, "skdj_current", "散客登记内容导出");
                }
                if (yddj == common_file.common_app.get_his)
                {
                    common_file.common_DataSetToExcel.ExportMX(DS_Qskdj, "skdj_lskr", "历史客人内容导出");
                }
            }
        }

        private void b_setTTcyFf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_cyffzf", common_file.common_app.user_type) == false)
            { return; }
            if(dg_skdj.CurrentRow!=null)
            {
                 int  i_000=dg_skdj.CurrentRow.Index;
                 DataRowView dgr = dg_skdj.Rows[i_000].DataBoundItem as DataRowView;
                 i_000 = DS_Qskdj.Tables[0].Rows.IndexOf(dgr.Row);
                 if(DS_Qskdj.Tables[0].Rows[i_000]["sktt"].ToString()==common_file.common_sktt.sktt_tt||DS_Qskdj.Tables[0].Rows[i_000]["sktt"].ToString()==common_file.common_sktt.sktt_hy)
                 {
                     string  cy_zd_id=DS_Qskdj.Tables[0].Rows[i_000]["id"].ToString();
                     if (Szwgl.common_zw.SetTTcyFF(cy_zd_id, "sk") == common_file.common_app.get_suc)
                     {
                         refresh_app("");
                     }
                 }
            }
        }
    }
}