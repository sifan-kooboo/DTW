using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Xxtsz
{
    public partial class Xyhsz_browse: Form
    {
        #region 自定义成员
        public int dg_count = 0;//记录初期加载行数
        public BLL.Xyhsz B_Xyhsz = new Hotel_app.BLL.Xyhsz();
        public DataSet DS_Xyhsz;

        #endregion

        #region 自定义方法

        public void InitializeApp()
        {
            DS_Xyhsz = B_Xyhsz.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xyhsz.Tables[0];
            dg_count = DS_Xyhsz.Tables[0].Rows.Count;
            this.dg_yhsz.AutoGenerateColumns = false;
        }
        #endregion

        public Xyhsz_browse()
        {
            InitializeComponent();
            InitializeApp();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Xyhsz = B_Xyhsz.GetList("id>=0" + common_file.common_app.yydh_select + " order by id");
            bindingSource1.DataSource = DS_Xyhsz.Tables[0];
            dg_count = DS_Xyhsz.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_yhsz.CurrentRow != null)
            {
                int i = dg_yhsz.CurrentRow.Index;

                DataRowView dgr = dg_yhsz.Rows[i].DataBoundItem as DataRowView;
                i = DS_Xyhsz.Tables[0].Rows.IndexOf(dgr.Row);


                if (DS_Xyhsz.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Xxtsz.Xyhsz_add_edit Xyhsz_add_edit_new = new Xyhsz_add_edit(this);


                    Xyhsz_add_edit_new.Left = common_file.common_app.x() - 200;
                    Xyhsz_add_edit_new.Top = common_file.common_app.y() - 100;
                    Xyhsz_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Xyhsz_add_edit_new.Xyhsz_id = DS_Xyhsz.Tables[0].Rows[i]["id"].ToString();
                    Xyhsz_add_edit_new.tB_yhbl.Text = DS_Xyhsz.Tables[0].Rows[i]["yhbl"].ToString();
                    Xyhsz_add_edit_new.tB_yh.Text = DS_Xyhsz.Tables[0].Rows[i]["yh"].ToString();
                    Xyhsz_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xyhsz_add_edit Xhysz_add_edit_new = new Xyhsz_add_edit(this);
            Xhysz_add_edit_new.Left = common_file.common_app.x() - 200;
            Xhysz_add_edit_new.Top = common_file.common_app.y() - 100;
            Xhysz_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Xyhsz != null && DS_Xyhsz.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_yhsz.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_yhsz.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_yhsz.Rows[i].Index.ToString());
                            DataRowView dgr = dg_yhsz.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Xyhsz.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_Xyhsz.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Xxtsz/Xxtsz_app.asmx";
                                object[] args = new object[7];
                                args[0] = DS_Xyhsz.Tables[0].Rows[j]["id"].ToString();
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] ="";
                                args[4] ="";

                                args[5] = common_file.common_app.get_delete;
                                args[6] = common_file.common_app.xxzs;

                                Hotel_app.Server.Xxtsz.Xyhsz Xyhsz_services = new Hotel_app.Server.Xxtsz.Xyhsz();
                                string result = Xyhsz_services.Xyhsz_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Xyhsz_add_edit", args);
                                if (result== common_file.common_app.get_suc && (s == common_file.common_app.get_suc || s == ""))
                                {
                                    s = common_file.common_app.get_suc;
                                }
                                else s = common_file.common_app.get_failure;
                            }
                            //common_file.common_app.Message_box_show(common_file.common_app.message_title, dataGridViewSummary1.Rows[i].Index.ToString());

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
    }
}