using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qskyd_qx : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        DataSet DS_skyd_qx;
        int dg_count = 0;
        string sel_condition = "";
        string select_s = "";
        public Qskyd_qx()
        {
            InitializeComponent();
            refresh_app(" and czsj>'" + DateTime.Now.AddDays(-7).ToShortDateString() + "' ");
        }
        public void refresh_app(string sel_s_0)
        {
            sel_condition = sel_s_0;
            select_s = "select * from VIEW_Qskyd_qx";
            dg_skyd_qx.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sel_s_0 + sel_condition + " order by id desc";
            DS_skyd_qx = B_Common.GetList(select_s, condition);
            bS_skyd_qx.DataSource = DS_skyd_qx.Tables[0];
            dg_count = DS_skyd_qx.Tables[0].Rows.Count;
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            sel_condition = "";
            refresh_app(" and czsj>'" + DateTime.Now.AddDays(-7).ToShortDateString() + "' ");

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void b_search_Click(object sender, EventArgs e)
        {
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
            bS_skyd_qx.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bS_skyd_qx.MovePrevious();

        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bS_skyd_qx.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bS_skyd_qx.MoveLast();
        }

        private void b_cx_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_skyd_qx.CurrentRow != null)
            {
                int k_0 = 0;
                DataRowView dgr = dg_skyd_qx.CurrentRow.DataBoundItem as DataRowView;
                k_0 = DS_skyd_qx.Tables[0].Rows.IndexOf(dgr.Row);


                if (dg_count > 0 && dg_skyd_qx.CurrentRow.Index < dg_count && DS_skyd_qx != null && DS_skyd_qx.Tables[0].Rows[k_0]["id"].ToString() != "")
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要撤销此记录？") == true)
                    {
                        int i_temp_0 = 5;
                        if (DS_skyd_qx.Tables[0].Rows[k_0]["sktt"].ToString() == common_file.common_sktt.sktt_tt || DS_skyd_qx.Tables[0].Rows[k_0]["sktt"].ToString() == common_file.common_sktt.sktt_hy)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，团队成员不能单独撤销！");
                            i_temp_0 = 1;
                        }

                        if (i_temp_0 == 5)
                        {
                            BLL.Common B_Common = new Hotel_app.BLL.Common();
                            DataSet ds_temp = B_Common.GetList("select * from VIEW_Qskyd_qx", "lsbh='" + DS_skyd_qx.Tables[0].Rows[dg_skyd_qx.CurrentRow.Index]["lsbh"].ToString() + "' and fjbh<>''");
                            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.get_czsj();
                                for (int j_0 = 0; j_0 < ds_temp.Tables[0].Rows.Count; j_0++)
                                {
                                    //if (common_file.common_used_fjzt.judge_kyfs(common_file.common_app.get_add, ds_temp.Tables[0].Rows[j_0]["yddj"].ToString(), ds_temp.Tables[0].Rows[j_0]["lzfs"].ToString(), 0, ds_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), ds_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["lksj"].ToString()), ds_temp.Tables[0].Rows[j_0]["krxm"].ToString(), ds_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), ds_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), " 撤销散客预订") == true)
                                    //{
                                    //    i_temp_0 = 1;
                                    //    break;
                                    //}
                                    if (common_file.common_used_fjzt.get_dataset_usedfjzt(ds_temp.Tables[0].Rows[j_0]["yddj"].ToString(), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["lksj"].ToString()), ds_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), "", ds_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), "", common_file.common_app.is_contain_wx) == true)
                                    {
                                        i_temp_0 = 1;
                                        break;
                                    }
                                }
                            }
                            ds_temp.Dispose();

                        }


                        if (i_temp_0 == 5)
                        {
                            common_file.common_app.get_czsj();
                            //进入撤销
                            string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
                            object[] args = new object[7];
                            args[0] = common_file.common_app.yydh;
                            args[1] = common_file.common_app.qymc;
                            args[2] = DS_skyd_qx.Tables[0].Rows[k_0]["lsbh"].ToString();
                            args[3] = DS_skyd_qx.Tables[0].Rows[k_0]["cznr"].ToString();
                            args[4] = common_file.common_app.czy;
                            args[5] = common_file.common_app.czsj;
                            args[6] = common_file.common_app.xxzs;

                            Hotel_app.Server.Qyddj.Qydcx Qydcx_services = new Hotel_app.Server.Qyddj.Qydcx();
                            string result = Qydcx_services.skyd_cx(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(),DateTime.Parse(args[5].ToString()), args[6].ToString());
                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "skyd_cx", args);
                            if (result== common_file.common_app.get_suc)
                            {
                                refresh_app(sel_condition);
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                            }
                            else
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                            }
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {

        }

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_yddj_outport", common_file.common_app.user_type) == false)
            { return; }
            common_file.common_DataSetToExcel.ExportMX(DS_skyd_qx, "skyd_qx", "散客预定未到");
        }



    }
}