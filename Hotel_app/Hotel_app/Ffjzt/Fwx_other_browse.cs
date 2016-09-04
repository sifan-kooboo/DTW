using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Fwx_other_browse : Form
    {
        public string get_fjrb = "";
        public string get_fjbh = "";
        public int dg_count = 0;//记录初期加载行数
        public string zyzt = common_file.common_fjzt.wxf;
        public BLL.Fwx_other B_Fwx_other = new Hotel_app.BLL.Fwx_other();
        public DataSet DS_Fwx_other;
        public string sel_cond = "";

        public void InitializeApp()
        {
            
            DS_Fwx_other = B_Fwx_other.GetList("id>=0" + common_file.common_app.yydh_select +sel_cond+ " order by ddsj");
            bindingSource1.DataSource = DS_Fwx_other.Tables[0];
            dg_count = DS_Fwx_other.Tables[0].Rows.Count;
            this.dg_wx_other.AutoGenerateColumns = false;
        }

        public void refresh_app()//刷新
        {
            common_file.common_app.get_czsj();
            DS_Fwx_other = B_Fwx_other.GetList("ID>=0" + common_file.common_app.yydh_select + sel_cond + " order by ddsj");
            bindingSource1.DataSource = DS_Fwx_other.Tables[0];
            dg_count = DS_Fwx_other.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        public Fwx_other_browse(string fjrb_0,string fjbh_0)
        {
            get_fjrb = fjrb_0;
            get_fjbh = fjbh_0;
            if(fjrb_0!=null && fjrb_0!="")
            {sel_cond += "and fjrb='" + get_fjrb+"'";
            }
            if (fjbh_0 != null && fjbh_0 != "")
            {
                sel_cond += "and fjbh='" + get_fjbh + "'";
            }
            InitializeComponent();
           
            InitializeApp();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Ffjzt.Fwx_other_add_edit Fwx_other_add_edit_new = new Fwx_other_add_edit(this, "");
            Fwx_other_add_edit_new.zyzt = zyzt;
            Fwx_other_add_edit_new.Left = b_new.Left + 200;
            Fwx_other_add_edit_new.Top = b_new.Top;
            Fwx_other_add_edit_new.tB_fjrb.Text = get_fjrb;
            Fwx_other_add_edit_new.tB_fjbh.Text = get_fjbh;
            Fwx_other_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            int i = dg_wx_other.CurrentRow.Index;
            if (dg_wx_other.CurrentRow != null)
            {
                DataRowView dgr = dg_wx_other.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Fwx_other.Tables[0].Rows.IndexOf(dgr.Row);

                if (i > -1 && i < dg_count)//当前行为内容行
                {
                    Ffjzt.Fwx_other_add_edit Fwx_other_add_edit_new = new Fwx_other_add_edit(this, DS_Fwx_other.Tables[0].Rows[i]["id"].ToString());
                    Fwx_other_add_edit_new.Left = b_new.Left + 200;
                    Fwx_other_add_edit_new.Top = b_new.Top;
                    Fwx_other_add_edit_new.tB_fjrb.Text = get_fjrb;
                    Fwx_other_add_edit_new.tB_fjbh.Text = get_fjbh;
                    Fwx_other_add_edit_new.judge_add_edit = common_file.common_app.get_edit;

                    Fwx_other_add_edit_new.ShowDialog();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Fwx_other != null && DS_Fwx_other.Tables[0].Rows.Count > 0)
            {
                int j = 0; string s = "";
                for (int i = 0; i < dg_count; i++)
                {
                    common_file.common_app.get_czsj();
                    DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                    if (this.dg_wx_other.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_wx_other.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                        {
                            //j = Convert.ToInt32(dg_wx_other.Rows[i].Index.ToString());

                            DataRowView dgr = dg_wx_other.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Fwx_other.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_Fwx_other.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Ffjzt/Ffjzt_app.asmx";
                                object[] args = new object[16];
                                args[0] =int.Parse( DS_Fwx_other.Tables[0].Rows[j]["id"].ToString());
                                args[1] = common_file.common_app.yydh;
                                args[2] = common_file.common_app.qymc;
                                args[3] = "";
                                args[4] = "";
                                args[5] = DS_Fwx_other.Tables[0].Rows[j]["fjbh"].ToString();
                                args[6] = DateTime.Now;
                                args[7] = DateTime.Now;
                                args[8] = "";
                                args[9] = DS_Fwx_other.Tables[0].Rows[j]["zyzt"].ToString();
                                args[10] = common_file.common_app.czy;
                                args[11] = DateTime.Now.ToString();
                                args[12] = false;
                                args[13] = false;
                                args[14] = common_file.common_app.get_delete;
                                args[15] = common_file.common_app.xxzs;

                                Hotel_app.Server.Ffjzt.Fwx_other Fwx_other_services = new Hotel_app.Server.Ffjzt.Fwx_other();
                                string result = Fwx_other_services.set_wx_other(int.Parse(args[0].ToString()), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), DateTime.Parse(args[6].ToString()), DateTime.Parse(args[7].ToString()), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), bool.Parse(args[12].ToString()), bool.Parse(args[13].ToString()), args[14].ToString(), args[15].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "set_wx_other", args);
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
}