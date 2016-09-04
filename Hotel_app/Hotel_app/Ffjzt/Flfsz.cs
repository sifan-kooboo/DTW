using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Flfsz : Form
    {
        DataSet DS_lf;
        DataSet DS_sk;
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        public string lfbh = "";
        public string lsbh = "";
        public string fjbh = "";
        public string select_s = "";
        public string sk_condition = "";
        public string yddj = "";
        public int dg_count_sk = 0;
        public int dg_count_lf = 0;

        public Flfsz(string lfbh_0, string lsbh_0, string fjbh_0, string yddj_0)
        {
            lfbh = lfbh_0;
            lsbh = lsbh_0;
            fjbh = fjbh_0;
            yddj = yddj_0;
            sk_condition = " and fjbh<>'' and lsbh<>'" + lsbh + "' and yddj='" + yddj + "' and fjbh not in(select fjbh from Flfsz where lfbh='" + lfbh + "')";
            InitializeComponent();
            refresh_sk(sk_condition);
            refresh_lf();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        public void refresh_sk(string sql_s)
        {
            select_s = "select * from View_Qskzd";
            dg_sk.AutoGenerateColumns = false;
            string condition = "id>=0 and main_sec='" + common_file.common_app.main_sec_main + "' and yydh='" + common_file.common_app.yydh + "'" + sk_condition + sql_s + "  order by fjbh";
            DS_sk = B_Common.GetList(select_s, condition);
            bS_sk.DataSource = DS_sk.Tables[0];
            dg_count_sk = DS_sk.Tables[0].Rows.Count;
        }


        public void refresh_lf()
        {
            select_s = "select * from Flfsz";
            dg_lf.AutoGenerateColumns = false;
            string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   lfbh='" + lfbh + "'  order by fjbh";
            DS_lf = B_Common.GetList(select_s, condition);
            bS_lf.DataSource = DS_lf.Tables[0];
            dg_count_lf = DS_lf.Tables[0].Rows.Count;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            if (tB_gl.Visible == false)
            {
                tB_gl.BringToFront();
                tB_gl.Visible = true;
                tB_gl.Focus();
            }
            else
            {
                tB_gl.Visible = false;
            }

        }

        private void tB_gl_TextChanged(object sender, EventArgs e)
        {
            refresh_sk(" and (fjbh like'%" + tB_gl.Text.Trim() + "%' or krxm like'%" + tB_gl.Text.Trim() + "%')");
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            string[] id_arg = new string[50];
            int i_0 = 0;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Qcounter", "id>=0");
            for (int j = 0; j < dg_count_sk; j++)
            {
                common_file.common_app.get_czsj();
                DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                if (this.dg_sk.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_sk.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                {


                    int j_000 = 0;
                    DataRowView dgr = dg_sk.Rows[j].DataBoundItem as DataRowView;
                    j_000 = DS_sk.Tables[0].Rows.IndexOf(dgr.Row);


                    if (DS_sk.Tables[0].Rows[j_000]["id"].ToString() != "")
                    {
                        DS_temp = B_Common.GetList("select * from Flfsz ", "lsbh='" + DS_sk.Tables[0].Rows[j]["lsbh"].ToString() + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "此房已经有和别人联房了，是否要取消原来的联房加入新的联房呢？") == true)
                            {
                                id_arg[i_0] = DS_sk.Tables[0].Rows[j_000]["id"].ToString();
                                i_0 = i_0 + 1;
                                if (i_0 > 50)
                                { break; }
                            }

                        }
                        else
                        {
                            id_arg[i_0] = DS_sk.Tables[0].Rows[j_000]["id"].ToString();
                            i_0 = i_0 + 1;
                            if (i_0 > 50)
                            { break; }
                        }
                    }
                }
            }
            if (i_0 > 0)
            {
                bool shlz_0 = common_file.common_app.shlz;
                if (common_file.common_app.shlz == false)
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要对所选择的房间要进行联房的房间进行联账呢？") == true)
                    { shlz_0 = true; }
                }

                string url = common_file.common_app.service_url;
                url += "Ffjzt/Ffjzt_app.asmx";
                object[] args = new object[9];
                args[0] = common_file.common_app.yydh;
                args[1] = common_file.common_app.qymc;
                args[2] = lsbh;
                args[3] = lfbh;
                args[4] = id_arg;
                args[5] = shlz_0;
                args[6] = common_file.common_app.czy;
                args[7] = DateTime.Now.ToString();
                args[8] = common_file.common_app.xxzs;

                Hotel_app.Server.Ffjzt.Flfsz_add_edit Flfsz_add_edit_services = new Hotel_app.Server.Ffjzt.Flfsz_add_edit();
                string result = Flfsz_add_edit_services.set_pl_lf(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), id_arg, bool.Parse(args[5].ToString()), args[6].ToString(), args[7].ToString(), args[8].ToString());

                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "set_pl_lf", args);
                if (result!=null&&result== common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");

                    if (lfbh == "")
                    {
                        DS_temp = B_Common.GetList("select * from Flfsz ", "lsbh='" + lsbh + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            lfbh = DS_temp.Tables[0].Rows[0]["lfbh"].ToString();
                        }
                    }
                    refresh_lf();
                    sk_condition = " and fjbh<>'' and lsbh<>'" + lsbh + "' and yddj='" + yddj + "' and fjbh not in(select fjbh from Flfsz where lfbh='" + lfbh + "')";
                    refresh_sk(sk_condition);
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                } Cursor.Current = Cursors.Default;
            }
            DS_temp.Dispose();
            Cursor.Current = Cursors.Default;
        }

        private void set_lz(string update_lz_value, string cznr)
        {
            common_file.common_app.get_czsj();
            string[] id_arg = new string[50];
            //int i_0 = 0;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Qcounter", "id>=0");
            int judge_0 = 1;
            for (int j = 0; j < dg_count_lf; j++)
            {
                common_file.common_app.get_czsj();
                DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                if (this.dg_lf.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_lf.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                {
                    int j_00 = 0;
                    DataRowView dgr = dg_lf.Rows[j].DataBoundItem as DataRowView;
                    j_00 = DS_lf.Tables[0].Rows.IndexOf(dgr.Row);


                    if (DS_lf.Tables[0].Rows[j_00]["id"].ToString() != "")
                    {
                        judge_0 = 1;
                        if (update_lz_value == "1")
                        {
                            if (DS_lf.Tables[0].Rows[j_00]["shlz"].ToString() == "False")
                            {
                                judge_0 = 2;
                            }

                        }

                        if (update_lz_value == "0")
                        {
                            //tB_gl = DS_lf.Tables[0].Rows[dg_lf.CurrentRow.Index]["fjbh"].ToString();
                            //return;
                            if (DS_lf.Tables[0].Rows[j_00]["shlz"].ToString() == "True")
                            {
                                judge_0 = 2;


                            }

                        }
                        if (judge_0 == 2)
                        {
                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, cznr, DS_lf.Tables[0].Rows[j_00]["krxm"].ToString() + "_" + DS_lf.Tables[0].Rows[j_00]["fjbh"].ToString(), DS_lf.Tables[0].Rows[j_00]["lsbh"].ToString() + "_" + DS_lf.Tables[0].Rows[j_00]["lfbh"].ToString(), DateTime.Now);
                            if (DS_lf.Tables[0].Rows[j_00]["fjbh"].ToString() != "" && DS_lf.Tables[0].Rows[j_00]["yddj"].ToString() == common_file.common_yddj.yddj_dj)
                            {
                                B_Common.ExecuteSql("update Flfsz set shlz='" + update_lz_value + "', czsj='" + DateTime.Now.ToString() + "',czy='" + common_file.common_app.czy + "' where id='" + DS_lf.Tables[0].Rows[j_00]["id"].ToString() + "'");
                                B_Common.ExecuteSql("update Ffjzt set shlf='" + update_lz_value + "', czsj='" + DateTime.Now.ToString() + "',czy='" + common_file.common_app.czy + "' where fjbh='" + DS_lf.Tables[0].Rows[j_00]["fjbh"].ToString() + "'");
                                judge_0 = 3;
                            }
                        }

                    }
                }
            }
            if (judge_0 == 3)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
            }
            refresh_lf();
            DS_temp.Dispose();
            Cursor.Current = Cursors.Default;
        }




        private void b_lz_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "此操作只针对在住客人，非在住客人不能操作，确认要联账？") == true)
            {
                set_lz("1", "联账");
            }
        }

        private void b_qxlz_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "此操作只针对在住联账客人，非在住客人联账客人不能操作，确认要取消？") == true)
            {
                set_lz("0", "取消联账");
            }
        }

        private void b_qxlf_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要取消联房(注意,如果当前房间有联账,取消联房会同时取消联账)？") == true)
            {
                common_file.common_app.get_czsj();
                string[] id_arg = new string[50];
                //int i_0 = 0;
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp = B_Common.GetList("select * from Qcounter", "id>=0");
                int judge_0 = 1;
                for (int j = 0; j < dg_count_lf; j++)
                {
                    common_file.common_app.get_czsj();
                    DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                    if (this.dg_lf.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_lf.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                    {
                        int j_00 = 0;
                        DataRowView dgr = dg_lf.Rows[j].DataBoundItem as DataRowView;
                        j_00 = DS_lf.Tables[0].Rows.IndexOf(dgr.Row);


                        if (DS_lf.Tables[0].Rows[j_00]["id"].ToString() != "")
                        {
                            string lsbh_temp = DS_lf.Tables[0].Rows[j_00]["lsbh"].ToString();
                            DataSet ds_0 = B_Common.GetList(" select * from Flfsz ", "id>=0 and yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh_temp + "' ");
                            if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                            {
                                //这一步是为了防止单个房间的联账，当其再与另外的房间联账时会导致主单介面加载出错(更新于20121009)
                                string lfbh_temp = ds_0.Tables[0].Rows[0]["lfbh"].ToString();
                                if (B_Common.ExecuteSql(" delete from Flfsz  where  id>=0 and yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh_temp + "' ") > 0)
                                {
                                    common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "取消联房", DS_lf.Tables[0].Rows[j_00]["fjbh"].ToString(), "联房取消", DateTime.Now);
                                    B_Common.ExecuteSql(" update Ffjzt set shlf=0,czsj='" + DateTime.Now.ToString() + "'  where id>=0 and yydh='" + common_file.common_app.yydh + "'  and fjbh='" + DS_lf.Tables[0].Rows[j_00]["fjbh"].ToString() + "' ");
                                    common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "取消联账", DS_lf.Tables[0].Rows[j_00]["fjbh"].ToString(), "联房取消同步取消联账", DateTime.Now);
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "取消联房成功.");

                                    //这里防止问题产生
                                    DataSet ds_1 = B_Common.GetList(" select  *  from  Flfsz ", "id>=0 and yydh='" + common_file.common_app.yydh + "'  and  lfbh='" + lfbh_temp + "' ");
                                    if (ds_1 != null && ds_1.Tables[0].Rows.Count == 1)//只有一间房的联房的时候
                                    {
                                        string lsbh_temp_0 = ds_1.Tables[0].Rows[0]["lsbh"].ToString();
                                        string fjbh_temp_0 = ds_1.Tables[0].Rows[0]["fjbh"].ToString();
                                        B_Common.ExecuteSql(" delete from Flfsz  where  id>=0 and yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh_temp_0 + "' ");
                                        common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "取消联房", fjbh_temp_0, "由于同一联房编号下其它的所有房间都以经取消,这里同步取消最后一条联房信息", DateTime.Now);
                                        B_Common.ExecuteSql(" update Ffjzt set shlf=0,czsj='" + DateTime.Now.ToString() + "'  where id>=0 and yydh='" + common_file.common_app.yydh + "'  and fjbh='" + fjbh_temp_0 + "' ");
                                        common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "取消联账", fjbh_temp_0, "由于同一联房编号下其它的所有房间都以经取消,这里同步取消最后一条联房信息", DateTime.Now);
                                    }


                                    refresh_lf();
                                }
                            }
                            else
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "取消联房失败.");
                            }
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "取消联房失败,所选的房间本来就没有和其它房间联房.");
                        }
                    }
                }

                Cursor.Current = Cursors.Default;

            }
        }
    }
}