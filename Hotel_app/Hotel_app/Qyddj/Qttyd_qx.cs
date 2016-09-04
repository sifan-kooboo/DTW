using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qttyd_qx : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        DataSet DS_ttyd_qx;
        DataSet DS_ttyd_fjrb;
        DataSet DS_ttyd_cy;
        int dg_count_ttyd_qx = 0;
        int dg_count_fjrb = 0;
        int dg_count_cy = 0;
        string select_s = "";
        string sel_condition = "";
        public Qttyd_qx()
        {
            InitializeComponent();
            load_refresh();
        }

        void load_refresh()
        {
            sel_condition = "";
            refresh_app(" and czsj>'" + DateTime.Now.AddDays(-7).ToShortDateString() + "'");
        }
        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void refresh_app(string sel_s_0)
        {
            sel_condition = sel_s_0;
            select_s = "select * from VIEW_Qttyd_qx";
            dg_ttyd_qx.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "'" + sel_s_0 + sel_condition + " order by id desc";
            DS_ttyd_qx = B_Common.GetList(select_s, condition);
            bS_ttyd_qx.DataSource = DS_ttyd_qx.Tables[0];
            dg_count_ttyd_qx = DS_ttyd_qx.Tables[0].Rows.Count;
            if (dg_count_ttyd_qx > 0)
            {
                bind_child_data(0);
            }
        }
        void bind_child_data(int j_0)
        {
            DataRowView dgr = dg_ttyd_qx.Rows[j_0].DataBoundItem as DataRowView;
            if (dgr != null)
            {
                j_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);


                refresh_fjrb(DS_ttyd_qx.Tables[0].Rows[j_0]["lsbh"].ToString());
                refresh_cy(DS_ttyd_qx.Tables[0].Rows[j_0]["ddbh"].ToString());
            }


        }
        public void refresh_fjrb(string lsbh_0)
        {
            select_s = "select * from VIEW_Qskyd_fjrb_qx";
            dg_ttyd_fjrb.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and lsbh='" + lsbh_0 + "' order by id ";
            DS_ttyd_fjrb = B_Common.GetList(select_s, condition);
            bS_ttyd_fjrb.DataSource = DS_ttyd_fjrb.Tables[0];
            dg_count_fjrb = DS_ttyd_fjrb.Tables[0].Rows.Count;
        }

        public void refresh_cy(string ddbh_0)
        {
            select_s = "select * from VIEW_Qskyd_qx";
            dg_ttyd_cy.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and ddbh='" + ddbh_0 + "' order by id ";
            DS_ttyd_cy = B_Common.GetList(select_s, condition);
            bS_ttyd_cy.DataSource = DS_ttyd_cy.Tables[0];
            dg_count_cy = DS_ttyd_cy.Tables[0].Rows.Count;
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            load_refresh();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            Qyddj.Q_sktt_gl Q_sktt_gl_new = new Q_sktt_gl("tt");
            Q_sktt_gl_new.Left = 130;
            Q_sktt_gl_new.Top = 70;
            if (Q_sktt_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_condition = sel_condition + Q_sktt_gl_new.get_sel_cond;
                if (Q_sktt_gl_new.get_sel_cond != "")
                {
                   // refresh_app("");
                    refresh_app(sel_condition);
                }
            }

            Q_sktt_gl_new.Dispose();
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            bS_ttyd_qx.MoveFirst();
            if (dg_count_ttyd_qx > 0)
            {
                if (dg_ttyd_qx.CurrentRow != null)
                {
                    int j_0 = 0;
                    DataRowView dgr = dg_ttyd_qx.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);
                    bind_child_data(j_0);
                }
            }
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bS_ttyd_qx.MovePrevious();
            if (dg_count_ttyd_qx > 0)
            {
                if (dg_ttyd_qx.CurrentRow != null)
                {
                    int j_0 = 0;
                    DataRowView dgr = dg_ttyd_qx.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);
                    bind_child_data(j_0);
                }
            }
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bS_ttyd_qx.MoveNext();
            if (dg_count_ttyd_qx > 0)
            {
                if (dg_ttyd_qx.CurrentRow != null)
                {
                    int j_0 = 0;
                    DataRowView dgr = dg_ttyd_qx.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);
                    bind_child_data(j_0);
                }
            }
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bS_ttyd_qx.MoveLast();
            if (dg_count_ttyd_qx > 0)
            {
                if (dg_ttyd_qx.CurrentRow != null)
                {
                    int j_0 = 0;
                    DataRowView dgr = dg_ttyd_qx.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);
                    bind_child_data(j_0);
                }
            }
        }

        private void dg_ttyd_qx_Click(object sender, EventArgs e)
        {
            if (dg_count_ttyd_qx > 0 && dg_ttyd_qx.CurrentRow.Index < dg_count_ttyd_qx)
            {
                if (dg_ttyd_qx.CurrentRow != null)
                {
                    int j_0 = 0;
                    DataRowView dgr = dg_ttyd_qx.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);
                    bind_child_data(j_0);
                }
            }
        }

        private void dg_ttyd_qx_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_count_ttyd_qx > 0 && dg_ttyd_qx.CurrentRow.Index < dg_count_ttyd_qx)
            {
                if (dg_ttyd_qx.CurrentRow != null)
                {
                    int j_0 = 0;
                    DataRowView dgr = dg_ttyd_qx.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);
                    bind_child_data(j_0);
                }
            }
        }

        private void b_cx_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if( dg_ttyd_qx.CurrentRow!=null)
            {
            int k_0 = 0;
            DataRowView dgr = dg_ttyd_qx.CurrentRow.DataBoundItem as DataRowView;
            k_0 = DS_ttyd_qx.Tables[0].Rows.IndexOf(dgr.Row);


            if (dg_count_ttyd_qx > 0 && dg_ttyd_qx.CurrentRow.Index < dg_count_ttyd_qx && DS_ttyd_qx != null && DS_ttyd_qx.Tables[0].Rows[k_0]["id"].ToString() != "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要撤销此记录？") == true)
                {
                    int i_temp_0 = 5;
                    float lzfs_0 = 0;

                    //BLL.Common B_Common = new Hotel_app.BLL.Common();
                    //DataSet ds_temp = DS_ttyd_fjrb;
                    //if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int j_0 = 0; j_0 < ds_temp.Tables[0].Rows.Count; j_0++)
                    //    {
                    //        lzfs_0 = float.Parse(ds_temp.Tables[0].Rows[j_0]["lzfs"].ToString());
                    //        if (common_file.common_used_fjzt.judge_kyfs(common_file.common_app.get_add, ds_temp.Tables[0].Rows[j_0]["yddj"].ToString(), lzfs_0.ToString(), 0, ds_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), ds_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["lksj"].ToString()), ds_temp.Tables[0].Rows[j_0]["krxm"].ToString(), ds_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), ds_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), " 撤销团队预订-初始房类判断") == true)
                    //        {
                    //            i_temp_0 = 1;
                    //            break;
                    //        }
                    //    }

                    //}

                    if (i_temp_0 == 5)
                    {
                        DataSet ds_temp = DS_ttyd_cy;
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            for (int j_0 = 0; j_0 < ds_temp.Tables[0].Rows.Count; j_0++)
                            {
                                common_file.common_app.get_czsj();
                                //lzfs_0 = float.Parse(ds_temp.Tables[0].Rows[j_0]["lzfs"].ToString());
                                //if (common_file.common_used_fjzt.judge_kyfs(common_file.common_app.get_add, ds_temp.Tables[0].Rows[j_0]["yddj"].ToString(), lzfs_0.ToString(), 0, ds_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), ds_temp.Tables[0].Rows[j_0]["fjrb"].ToString(), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["ddsj"].ToString()), DateTime.Parse(ds_temp.Tables[0].Rows[j_0]["lksj"].ToString()), ds_temp.Tables[0].Rows[j_0]["krxm"].ToString(), ds_temp.Tables[0].Rows[j_0]["fjbh"].ToString(), ds_temp.Tables[0].Rows[j_0]["lsbh"].ToString(), " 撤销团队预订-成员判断") == true)
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
                        ds_temp.Clear();
                        ds_temp.Dispose();
                    }

                    if (i_temp_0 == 5)
                    { //进入撤销

                        common_file.common_app.get_czsj();
                        //进入撤销
                        string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
                        object[] args = new object[7];
                        args[0] = common_file.common_app.yydh;
                        args[1] = common_file.common_app.qymc;
                        args[2] = DS_ttyd_qx.Tables[0].Rows[k_0]["lsbh"].ToString();
                        args[3] = DS_ttyd_qx.Tables[0].Rows[k_0]["cznr"].ToString();
                        args[4] = common_file.common_app.czy;
                        args[5] = common_file.common_app.czsj;
                        args[6] = common_file.common_app.xxzs;

                        Hotel_app.Server.Qyddj.Qydcx Qydcx_services = new Hotel_app.Server.Qyddj.Qydcx();
                        string result = Qydcx_services.ttyd_cx(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(),DateTime.Parse(args[5].ToString()), args[6].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "ttyd_cx", args);

                        if (result == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                            refresh_app(sel_condition);
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

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            //先处理要导出的DS
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_0 = null;
            if (DS_ttyd_qx.Tables[0].Rows.Count > 0)
            {
                ds_0 = DS_ttyd_cy.Clone();
                for (int i = 0; i < DS_ttyd_qx.Tables[0].Rows.Count; i++)
                {
                    string ddbh = DS_ttyd_qx.Tables[0].Rows[i]["ddbh"].ToString();
                    DataRow dr = ds_0.Tables[0].NewRow();
                    dr["lsbh"] = DS_ttyd_qx.Tables[0].Rows[i]["lsbh"].ToString();
                    dr["ddbh"] = DS_ttyd_qx.Tables[0].Rows[i]["ddbh"].ToString();
                    dr["krxm"] = DS_ttyd_qx.Tables[0].Rows[i]["krxm"].ToString();
                    dr["hykh"] = DS_ttyd_qx.Tables[0].Rows[i]["krbh"].ToString();
                    dr["yddj"] = DS_ttyd_qx.Tables[0].Rows[i]["yddj"].ToString();
                    dr["sktt"] = "团体主单";
                    dr["krly"] = DS_ttyd_qx.Tables[0].Rows[i]["krly"].ToString();
                    dr["xyh"] = DS_ttyd_qx.Tables[0].Rows[i]["xyh"].ToString();
                    dr["xydw"] = DS_ttyd_qx.Tables[0].Rows[i]["xydw"].ToString();
                    dr["krdh"] = DS_ttyd_qx.Tables[0].Rows[i]["krdh"].ToString();
                    dr["krsj"] = DS_ttyd_qx.Tables[0].Rows[i]["krsj"].ToString();
                    dr["tlkr"] ="预订人姓名:"+ DS_ttyd_qx.Tables[0].Rows[i]["ydrxm"].ToString();
                    dr["ddsj"] = DS_ttyd_qx.Tables[0].Rows[i]["ddsj"].ToString();
                    dr["lksj"] = DS_ttyd_qx.Tables[0].Rows[i]["lksj"].ToString();
                    ds_0.Tables[0].Rows.Add(dr);
                    
                    
                     
                }
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    common_file.common_DataSetToExcel.ExportMX(ds_0, "skyd_qx", "团队未到内容导出");
                }

            }
             
        }
    }
}