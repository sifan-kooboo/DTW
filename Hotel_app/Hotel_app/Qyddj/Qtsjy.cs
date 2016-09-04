using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qtsjy : Form
    {
        public string sk_dw = "";//三个值，单个客人用“sk”，单位用“dw”,会员用“hy”
        public string add_edit = "";
        public int dg_count = 0;//记录初期加载行数
        public string lsbh = "";
        public string sktt = "";
        public string krxm = "";
        public string fjbh = "";
        public string krsj = "";
        public string zjhm = "";
        public string xyh = "";
        public string xydw = "";
        public string hykh = "";
        public string id = "";
        public string sql_condition = "";
        public string cz_sel = "cz";//两个值一个是cz，一个是sel，如果是sel时就操作不了只能查看。
        DataSet DS_tsjy;
        BLL.Qtsjy B_Qtsjy = new Hotel_app.BLL.Qtsjy();
        public Qtsjy(string add_edit_0, string sk_dw_0, string lsbh_0, string sktt_0, string krxm_0, string fjbh_0, string krsj_0, string zjhm_0, string xyh_0, string xydw_0,string hykh_0, string sql_condition_0)
        {
            add_edit = add_edit_0;
            sk_dw = sk_dw_0;
            lsbh = lsbh_0;
            sktt = sktt_0;
            krxm = krxm_0;
            fjbh = fjbh_0;
            krsj = krsj_0;
            zjhm = zjhm_0;
            xyh = xyh_0;
            xydw = xydw_0;
            hykh = hykh_0;
            sql_condition = sql_condition_0;
            InitializeComponent();
            refresh_app(sql_condition);
            tB_tsnr.Focus();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            if (cz_sel == "cz")
            {
                add_edit = common_file.common_app.get_add;
                tB_tsnr.Text = "";
                tB_tsnr.Focus();
            }
            else
                if (cz_sel == "sel")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title,"此模式下只能看，不能操作！");
                }
        }

        internal void refresh_app(string sql_condition_0)
        {
            common_file.common_app.get_czsj();
            this.dg_tsjy.AutoGenerateColumns = false;
            DS_tsjy = B_Qtsjy.GetList("id>=0" + sql_condition + " order by id desc");
            bs_tsjy.DataSource = DS_tsjy.Tables[0];
            dg_count = DS_tsjy.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_his_Click(object sender, EventArgs e)
        {
            string sql_condition_0 = "";
            if (sk_dw == "sk")
            {
                if (zjhm != "")
                {
                    sql_condition_0 = " and zjhm<>'' and zjhm=" + zjhm + "";
                }
            }
            else
                if (sk_dw == "dw")
                {
                    if (xyh != "")
                    {
                        sql_condition_0 = " and xyh<>'' and xyh=" + xyh + "";
                    }
                }
                else
                    if (sk_dw == "hy")
                    {
                        if (xyh != "")
                        {
                            sql_condition_0 = " and hykh<>'' and hykh=" + hykh + "";
                        }
                    }
            if (sql_condition_0 != "")
            {
                refresh_app(sql_condition_0);
            }
        }

        private void Qtsjy_Load(object sender, EventArgs e)
        {
        }

        private void dg_tsjy_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dg_tsjy_Click(object sender, EventArgs e)
        {
            if (dg_tsjy.CurrentRow != null)
            {
                int k_0 = 0;
                DataRowView dgr = dg_tsjy.CurrentRow.DataBoundItem as DataRowView;
                k_0 = DS_tsjy.Tables[0].Rows.IndexOf(dgr.Row);


                if (dg_count > 0 && dg_tsjy.CurrentRow.Index < dg_count && DS_tsjy.Tables[0].Rows[k_0]["tsnr"].ToString() != "")
                {
                    id = DS_tsjy.Tables[0].Rows[k_0]["id"].ToString();
                    tB_tsnr.Text = DS_tsjy.Tables[0].Rows[k_0]["tsnr"].ToString();
                    add_edit = common_file.common_app.get_edit;
                }
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (cz_sel == "cz")
            {
                if (add_edit == common_file.common_app.get_add)
                {
                    if (tB_tsnr.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请输入要投诉的内容！");
                    }
                    else
                    {
                        common_file.common_app.get_czsj();
                        string url = common_file.common_app.service_url;
                        url += "Qyddj/Qyddj_app.asmx";
                        object[] args = new object[22];
                        args[0] = id;
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = lsbh;
                        args[4] = fjbh;
                        args[5] = sktt;
                        args[6] = krxm;
                        args[7] = krsj;
                        args[8] = zjhm;
                        args[9] = xyh;
                        args[10] = xydw;
                        args[11] = hykh;
                        args[12] = "";
                        args[13] = tB_tsnr.Text.Trim().Replace("'", "-");
                        args[14] = DateTime.Now;
                        args[15] = common_file.common_app.czy;
                        args[16] = "";
                        args[17] = "";
                        args[18] = DateTime.Now;
                        args[19] = "";
                        args[20] = add_edit;
                        args[21] = common_file.common_app.xxzs;

                        Hotel_app.Server.Qyddj.Qyddj_other Qyddj_other_services = new Hotel_app.Server.Qyddj.Qyddj_other();
                        string result = Qyddj_other_services.Qtsjy_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(),
               DateTime.Parse(args[14].ToString()), args[15].ToString(), args[16].ToString(), args[17].ToString(),DateTime.Parse(args[18].ToString()), args[19].ToString(), args[20].ToString(), args[21].ToString());

                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qtsjy_add_edit", args);
                        if (result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                            refresh_app(sql_condition);
                            tB_tsnr.Text = "";
                            //this.Close();
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                        }

                    }




                }
                Cursor.Current = Cursors.Default;
            }
            else
                if (cz_sel == "sel")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此模式下只能看，不能操作！");
                }
        }

    }
}