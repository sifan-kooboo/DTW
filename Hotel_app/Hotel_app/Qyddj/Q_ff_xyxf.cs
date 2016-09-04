using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_ff_xyxf : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        public DataSet DS_ff_xyxf;
        public int dg_count = 0;

        public Q_ff_xyxf()
        {
            InitializeComponent();
            Refresh_app();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Refresh_app()
        {
            dg_ff_xyxf.AutoGenerateColumns = false;
            DS_ff_xyxf = B_Common.GetList("select * from Q_ff_xyxf", "id>=0" + common_file.common_app.yydh_select + " order by id");
            bs_ff_xyxf.DataSource = DS_ff_xyxf.Tables[0];
            dg_count = DS_ff_xyxf.Tables[0].Rows.Count;
        }

        private void Q_ff_xyxf_Load(object sender, EventArgs e)
        {
        }

        private void dg_ff_xyxf_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            Szwgl.Sxfxm Frm_Sxfxm = new Szwgl.Sxfxm("xyxf");
            Frm_Sxfxm.StartPosition = FormStartPosition.CenterScreen;
            Frm_Sxfxm.ShowDialog();
            Refresh_app();
        }

        private void r_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_ff_xyxf != null && DS_ff_xyxf.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_ff_xyxf.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_ff_xyxf.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_ff_xyxf.Rows[i].Index.ToString());
                            DataRowView dgr = dg_ff_xyxf.SelectedRows[0].DataBoundItem as DataRowView;
                             dgr = dg_ff_xyxf.CurrentRow.DataBoundItem as DataRowView;
                            j = DS_ff_xyxf.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_ff_xyxf.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                //id,yydh, qymc, fyrx, xfdr, xfrb, xfxm, xfsl, xfje, 
                                
                                //add_edit_delete, czy, czsj, cznr, xxzs,jjje,mxbh)
                                string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
                                object[] args = new object[16];
                                args[0] = DS_ff_xyxf.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = "";
                                args[6] = "";
                                args[7] = decimal.Parse("0");
                                args[8] = decimal.Parse("0");
                                args[9] = common_file.common_app.get_delete;
                                args[10] = common_file.common_app.czy;
                                args[11] = DateTime.Now;
                                args[12] = common_file.common_app.chinese_delete;
                                args[13] = common_file.common_app.xxzs;
                                args[14] = decimal.Parse("0");
                                args[15] = "";

                                Hotel_app.Server.Qyddj.Q_ff_xyxf Q_ff_xyxf_services = new Hotel_app.Server.Qyddj.Q_ff_xyxf();
                                string result = Q_ff_xyxf_services.add_edit_delete_Q_ff_xyxf(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(),decimal.Parse(args[7].ToString()), decimal.Parse(args[8].ToString()), args[9].ToString(), args[10].ToString(), DateTime.Parse(args[11].ToString()), args[12].ToString(), args[13].ToString(), decimal.Parse(args[14].ToString()), args[15].ToString());
                               // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "add_edit_delete_Q_ff_xyxf", args);
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
                    Refresh_app();

                }
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_ff_xyxf.CurrentRow != null)
            {
                int i = dg_ff_xyxf.CurrentRow.Index;
                DataRowView dgr = dg_ff_xyxf.SelectedRows[0].DataBoundItem as DataRowView;
                i = DS_ff_xyxf.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_ff_xyxf.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Szwgl.Sxfxm Frm_Sxfxm = new Szwgl.Sxfxm("xyxf");
                    Frm_Sxfxm.StartPosition = FormStartPosition.CenterScreen;
                    Frm_Sxfxm.xfdr = DS_ff_xyxf.Tables[0].Rows[i]["xfdr"].ToString();
                    Frm_Sxfxm.cB_fyrx.Text = DS_ff_xyxf.Tables[0].Rows[i]["fyrx"].ToString();
                    Frm_Sxfxm.tB_xfrb.Text = DS_ff_xyxf.Tables[0].Rows[i]["xfrb"].ToString();
                    Frm_Sxfxm.tB_xfxm.Text = DS_ff_xyxf.Tables[0].Rows[i]["xfxm"].ToString();
                    Frm_Sxfxm.tB_xfsl.Text = DS_ff_xyxf.Tables[0].Rows[i]["xfsl"].ToString();
                    Frm_Sxfxm.tB_xfje.Text = DS_ff_xyxf.Tables[0].Rows[i]["xfje"].ToString();
                    Frm_Sxfxm.jjje = decimal.Parse(DS_ff_xyxf.Tables[0].Rows[i]["jjje"].ToString());
                    Frm_Sxfxm.xfje = decimal.Parse(DS_ff_xyxf.Tables[0].Rows[i]["xfje"].ToString()) / decimal.Parse(DS_ff_xyxf.Tables[0].Rows[i]["xfsl"].ToString());
                    Frm_Sxfxm.judge_add_edit = common_file.common_app.get_edit;
                    Frm_Sxfxm.Q_xy_xyxf_id = DS_ff_xyxf.Tables[0].Rows[i]["id"].ToString();
                    DataSet ds_temp = B_Common.GetList("select * from Xxfxr", "xfxr='" + DS_ff_xyxf.Tables[0].Rows[i]["xfrb"].ToString() + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        Frm_Sxfxm.xrbh = ds_temp.Tables[0].Rows[0]["xrbh"].ToString();
                        Frm_Sxfxm.xfxr = ds_temp.Tables[0].Rows[0]["xfxr"].ToString();

                        Frm_Sxfxm.xfdr = ds_temp.Tables[0].Rows[0]["xfdr"].ToString();
                    }
                    ds_temp.Dispose();
                    Frm_Sxfxm.ShowDialog();
                    Refresh_app();
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}