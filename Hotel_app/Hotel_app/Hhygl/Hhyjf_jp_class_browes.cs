using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Hhygl
{
    public partial class Hhyjf_jp_class_browes : Form
    {
        Model.Hhyjf_jp_Class M_Hhyjfjpclass = new Model.Hhyjf_jp_Class();
        BLL.Hhyjf_jp_Class B_Hhyjfjpclass = new BLL.Hhyjf_jp_Class();
        public DataSet DS_Hhyjfjpclass;
        public int dg_count=0;

        public Hhyjf_jp_class_browes()
        {
            InitializeComponent();
            InitializeApp();
        }
         public void InitializeApp()
        {
            DS_Hhyjfjpclass = B_Hhyjfjpclass.GetList("id>=0  order by id");
            bindingSource1.DataSource = DS_Hhyjfjpclass.Tables[0];
            dg_count = DS_Hhyjfjpclass.Tables[0].Rows.Count;
            this.dg_jpclass.AutoGenerateColumns = false;
        }
   
        public void refresh_app()
        {
            common_file.common_app.get_czsj();
            DS_Hhyjfjpclass = B_Hhyjfjpclass.GetList("id>=0  order by id");
            bindingSource1.DataSource = DS_Hhyjfjpclass.Tables[0];
            dg_count = DS_Hhyjfjpclass.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Hhygl.Hhyjf_jp_class_add_edit Hhyjfjpclass_add_edit_new = new Hhyjf_jp_class_add_edit(this);
            Hhyjfjpclass_add_edit_new.Left = common_file.common_app.x() +50;
            Hhyjfjpclass_add_edit_new.Top = common_file.common_app.y() - 100;
            Hhyjfjpclass_add_edit_new.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_jpclass.CurrentRow != null)
            {
                int i = dg_jpclass.CurrentRow.Index;

                DataRowView dgr = dg_jpclass.CurrentRow.DataBoundItem as DataRowView;
                i= DS_Hhyjfjpclass.Tables[0].Rows.IndexOf(dgr.Row);

                if (DS_Hhyjfjpclass.Tables[0].Rows[i]["id"].ToString() != "")
                {
                    Hhygl.Hhyjf_jp_class_add_edit Hhyjfjpclass_add_edit_new = new Hhyjf_jp_class_add_edit(this);
                    Hhyjfjpclass_add_edit_new.Left = common_file.common_app.x()+50;
                    Hhyjfjpclass_add_edit_new.Top = common_file.common_app.y() - 100;
                    Hhyjfjpclass_add_edit_new.judge_add_edit = common_file.common_app.get_edit;
                    Hhyjfjpclass_add_edit_new.Hhyjfjpclass_id = DS_Hhyjfjpclass.Tables[0].Rows[i]["id"].ToString();
                    Hhyjfjpclass_add_edit_new.tB_title.Text = DS_Hhyjfjpclass.Tables[0].Rows[i]["title"].ToString();



                    Hhyjfjpclass_add_edit_new.ShowDialog();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (DS_Hhyjfjpclass != null && DS_Hhyjfjpclass.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_jpclass.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_jpclass.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_jpclass.Rows[i].Index.ToString());

                            DataRowView dgr = dg_jpclass.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Hhyjfjpclass.Tables[0].Rows.IndexOf(dgr.Row);

                            if (DS_Hhyjfjpclass.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                string[] args = new string[4];
                                args[0] = DS_Hhyjfjpclass.Tables[0].Rows[j]["id"].ToString();
                                args[1] = "";
                                args[2] = common_file.common_app.get_delete;
                                args[3] = common_file.common_app.xxzs;

                                Hotel_app.Server.Hhygl.Hhyjf_jp_class Hhyjf_jp_class_services = new Hotel_app.Server.Hhygl.Hhyjf_jp_class();
                                string  result=Hhyjf_jp_class_services.Hhyjfjpclass_add_edit(args[0].ToString(),args[1].ToString(),args[2].ToString(),args[3].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhyjfjpclass_add_edit", args);
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
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "你好,你没有选择任何信息");

                   }
            Cursor.Current = Cursors.Default;
     
        }
    }
}