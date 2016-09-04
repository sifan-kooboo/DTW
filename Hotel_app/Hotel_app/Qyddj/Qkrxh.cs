using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qkrxh : Form
    {
        BLL.Qkrxh B_Qkrxh = new Hotel_app.BLL.Qkrxh();
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        DataSet DS_Qkrxh;
        string url = common_file.common_app.service_url;

        public int dg_count = 0;//记录初期加载行数
        public string sk_hy = "";//有两个值，一个是“sk”，另一个是“hy”
        public string add_edit = "";
        public string krxm = "";
        public string krsj = "";
        public string hykh = "";
        public string zjhm = "";
        public string id = "";
        public string cz_sel = "cz";//两个值一个是cz，一个是sel，如果是sel时就操作不了只能查看。

        public Qkrxh(string sk_hy_0, string add_edit_0, string krxm_0, string krsj_0, string hykh_0, string zjhm_0)
        {
            sk_hy = sk_hy_0;
            add_edit = add_edit_0;
            krxm = krxm_0;
            krsj = krsj_0;
            hykh = hykh_0;
            zjhm = zjhm_0;
            InitializeComponent();
            refresh_app();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            this.dg_Qkrxh.AutoGenerateColumns = false;
            if (sk_hy == "sk")
            {
                DS_Qkrxh = B_Qkrxh.GetList("id>=0 and zjhm='" + zjhm + "' order by id desc");
            }
            if (sk_hy == "hy")
            {
                DS_Qkrxh = B_Qkrxh.GetList("id>=0 and hykh='" + hykh + "' order by id desc");
            }
            else
            { }
            bs_Qkrxh.DataSource = DS_Qkrxh.Tables[0];
            dg_count = DS_Qkrxh.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Qkrxh_Load(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();

            DataSet ds_temp_0 = B_Common.GetList("select * from Qkrxh_rx", "id>=0");
            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds_temp_0.Tables[0].Rows.Count; j++)
                {
                    cB_xhrx.Items.Add(ds_temp_0.Tables[0].Rows[j]["xhrx"].ToString());
                }

            }
            if (sk_hy == "hy")
            {
                if (zjhm != "")
                {
                    ds_temp_0 = B_Common.GetList("select * from Qkrxh", "zjhm='" + zjhm + "' and hykh=''");
                    if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                    {
                        B_Common.ExecuteSql("update Qkrxh set hykh='" + hykh + "'where zjhm='" + zjhm + "' and hykh=''");
                    }

                }

            }
            refresh_app();
            ds_temp_0.Dispose();
            Cursor.Current = Cursors.Default;
        }

        private void dg_Qkrxh_Click(object sender, EventArgs e)
        {
            if (dg_Qkrxh.CurrentRow!=null)
            {
            int i_0 = 0;
            DataRowView dgr = dg_Qkrxh.CurrentRow.DataBoundItem as DataRowView;
            i_0 = DS_Qkrxh.Tables[0].Rows.IndexOf(dgr.Row);
            if (dg_count > 0 && dg_Qkrxh.CurrentRow.Index < dg_count && DS_Qkrxh.Tables[0].Rows[dg_Qkrxh.CurrentRow.Index]["krxh"].ToString() != "")
            {



                id = DS_Qkrxh.Tables[0].Rows[i_0]["id"].ToString();
                cB_xhrx.Text = DS_Qkrxh.Tables[0].Rows[i_0]["xhrx"].ToString();
                tB_krxh.Text = DS_Qkrxh.Tables[0].Rows[i_0]["krxh"].ToString();
                add_edit = common_file.common_app.get_edit;
            }}
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            if (cz_sel == "cz")
            {
                add_edit = common_file.common_app.get_add;
                cB_xhrx.Text = "";
                tB_krxh.Text = "";
                tB_krxh.Focus();
            }
            else
                if (cz_sel == "sel")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此模式下只能看，不能操作！");
                }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (cz_sel == "cz")
            {
                if (add_edit == common_file.common_app.get_add)
                {
                    if (cB_xhrx.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择类型！");
                    }
                    else
                    {
                        DataSet ds_temp = B_Common.GetList("select * from Qkrxh", "zjhm='" + zjhm + "' and xhrx='" + cB_xhrx.Text.Trim().Replace("'", "-") + "'");
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人喜好已经存在了！");
                            return;
                        }

                        if (tB_krxh.Text.Trim() == "")
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "请输入客人喜好！"); return;
                        }
                        else
                        {
                            if (add_edit == common_file.common_app.get_add)
                            {
                                common_file.common_app.get_czsj();
                                url = common_file.common_app.service_url;
                                url += "Qyddj/Qyddj_app.asmx";
                                object[] args = new object[14];
                                args[0] = id;
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = krxm;
                                args[4] = krsj;
                                args[5] = zjhm;
                                args[6] = hykh;
                                args[7] = cB_xhrx.Text.Trim().Replace("'", "-");
                                args[8] = tB_krxh.Text.Trim().Replace("'", "-");
                                args[9] = "";
                                args[10] = common_file.common_app.czy;
                                args[11] = DateTime.Now;
                                args[12] = add_edit;
                                args[13] = common_file.common_app.xxzs;

                                Hotel_app.Server.Qyddj.Qyddj_other Qyddj_other_services = new Hotel_app.Server.Qyddj.Qyddj_other();
                                string result = Qyddj_other_services.Qkrxh_add_edit_delete(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(),DateTime.Parse(args[11].ToString()), args[12].ToString(), args[13].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qkrxh_add_edit_delete", args);
                                if (result == common_file.common_app.get_suc)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                                    refresh_app();
                                    cB_xhrx.Text = "";
                                    tB_krxh.Text = "";
                                    tB_krxh.Focus();
                                    add_edit = common_file.common_app.get_edit;
                                }
                                else
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                                } Cursor.Current = Cursors.Default;
                            }

                        }
                    }

                }
                if (add_edit == common_file.common_app.get_edit)
                {
                    if (id != "")
                    {
                        common_file.common_app.get_czsj();
                        url = common_file.common_app.service_url;
                        url += "Qyddj/Qyddj_app.asmx";
                        object[] args = new object[14];
                        args[0] = id;
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = krxm;
                        args[4] = krsj;
                        args[5] = zjhm;
                        args[6] = hykh;
                        args[7] = cB_xhrx.Text.Trim().Replace("'", "-");
                        args[8] = tB_krxh.Text.Trim().Replace("'", "-");
                        args[9] = "";
                        args[10] = common_file.common_app.czy;
                        args[11] = DateTime.Now;
                        args[12] = add_edit;
                        args[13] = common_file.common_app.xxzs;

                        Hotel_app.Server.Qyddj.Qyddj_other Qyddj_other_services = new Hotel_app.Server.Qyddj.Qyddj_other();
                        string result = Qyddj_other_services.Qkrxh_add_edit_delete(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(),DateTime.Parse(args[11].ToString()), args[12].ToString(), args[13].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qkrxh_add_edit_delete", args);
                        if (result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                            refresh_app();
                            cB_xhrx.Text = "";
                            tB_krxh.Text = "";
                            tB_krxh.Focus();
                            id = "";
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择要修改的喜好项目！");

                        } Cursor.Current = Cursors.Default;
                    }
                }
            }
            else
                if (cz_sel == "sel")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此模式下只能看，不能操作！");
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cz_sel == "cz" && dg_Qkrxh.CurrentRow!=null)
            {
                int i_000 = 0;
                DataRowView dgr = dg_Qkrxh.CurrentRow.DataBoundItem as DataRowView;
                i_000 = DS_Qkrxh.Tables[0].Rows.IndexOf(dgr.Row);

                if (dg_count > 0 && DS_Qkrxh.Tables[0].Rows[i_000]["krxh"].ToString() != "")
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要删除此记录！") == true)
                    {
                        common_file.common_app.get_czsj();
                        url = common_file.common_app.service_url;
                        url += "Qyddj/Qyddj_app.asmx";

                        id = DS_Qkrxh.Tables[0].Rows[i_000]["id"].ToString();
                        object[] args = new object[14];
                        args[0] = id;
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = krxm;
                        args[4] = krsj;
                        args[5] = zjhm;
                        args[6] = hykh;
                        args[7] = cB_xhrx.Text.Trim().Replace("'", "-");
                        args[8] = tB_krxh.Text.Trim().Replace("'", "-");
                        args[9] = "";
                        args[10] = common_file.common_app.czy;
                        args[11] = DateTime.Now;
                        args[12] = common_file.common_app.get_delete;
                        args[13] = common_file.common_app.xxzs;

                        Hotel_app.Server.Qyddj.Qyddj_other Qyddj_other_services = new Hotel_app.Server.Qyddj.Qyddj_other();
                        string result = Qyddj_other_services.Qkrxh_add_edit_delete(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(),DateTime.Parse(args[11].ToString()), args[12].ToString(), args[13].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qkrxh_add_edit_delete", args);
                        if (result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                            refresh_app();
                            //this.Close();
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                        } Cursor.Current = Cursors.Default;
                    }
                }
            }
            else
                if (cz_sel == "sel")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此模式下只能看，不能操作！");
                }

        }
    }
}