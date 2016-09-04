using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
namespace Hotel_app.Hhygl
{
    public partial class Hhygl_browse : Form
    {
        public DataSet DS_Hygl;
        BLL.Hhygl B_Hhygl = new BLL.Hhygl();
        Model.Hhygl M_Hhygl = new Model.Hhygl();
        public  Fmain MdiFmaina;
        public int dg_count = 0;//记录初期加载行数
        
        public string sel_condition = "";

        public Hhygl_browse()
        {
            InitializeComponent();
            InitializeApp();
        }
        public Hhygl_browse(Fmain MdiFmaina)
        {
            InitializeComponent();
            InitializeApp();
            this.MdiFmaina = MdiFmaina;
        }

        #region 自定义方法
        //初使企业单位
        public static string Getyydh()
        {
            string stryydh = "";
            string stryydh_temp="";
            DataTable dt = DbHelperSQL.Query("select yydh from Hhy_cs_qy").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                stryydh+= "'"+dt.Rows[i]["yydh"].ToString()+"'"+",";
               
            }
            if (stryydh.Length > 0)
            {
                stryydh_temp = stryydh.Remove(stryydh.Length - 1, 1);

            }
            return stryydh_temp;
        }
            





        //初始化数据
        public void InitializeApp()
        {
            //Getyydh();
            dg_hygl.AutoGenerateColumns = false;
            if (Getyydh() != "" && Getyydh() != null)
            {
                DS_Hygl = B_Hhygl.GetList("id>=0  and yydh in(" + Getyydh() + ") and djsj>'" + DateTime.Now.AddMonths(-12).ToString() + "' order by id desc");

            }
            else
            {
                DS_Hygl = B_Hhygl.GetList("id>=0 and djsj>'" + DateTime.Now.AddMonths(-6).ToString() + "' order by id desc");
 
            }
               
    
            bindingSource1.DataSource = DS_Hygl.Tables[0];
            dg_count = DS_Hygl.Tables[0].Rows.Count;
        }
        //窗体刷新
        public void refresh_app()
        {

            dg_hygl.AutoGenerateColumns = false;
            if (Getyydh() != "" && Getyydh() != null)
            {
                DS_Hygl = B_Hhygl.GetList("id>=0   " + sel_condition + "  and yydh in(" + Getyydh() + ")  order by id desc");
            }
            else
            {
                DS_Hygl = B_Hhygl.GetList("id>=0  " + sel_condition + "  order by id desc");
 
            }
            bindingSource1.DataSource = DS_Hygl.Tables[0];
            dg_count = DS_Hygl.Tables[0].Rows.Count;

         
           
        }
        #endregion

        private void b_exit_Click(object sender, EventArgs e)
        {
            
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_hygl_xz", common_file.common_app.user_type) == false)
            { return; }
            common_file.common_hy.Form_hygl_add_edit("", common_file.common_app.get_add,MdiFmaina);
        }

        private void b_amend_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_hygl__xg", common_file.common_app.user_type) == false)
            { return; }
            open_record();

        }
        public void open_record()
        {
            common_file.common_app.get_czsj();
            if (dg_count > 0 && dg_hygl.Rows[0].Cells["id"].Value != null && dg_hygl.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            {
                int i = dg_hygl.CurrentRow.Index;

                if (i > -1 && i < dg_count)//当前行为内容行
                {
                    int id = Convert.ToInt32(dg_hygl.Rows[i].Cells["id"].Value);
                    common_file.common_hy.Form_hygl_add_edit(id.ToString(), common_file.common_app.get_edit,MdiFmaina);
                }
            }
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// action=first,priv,next,last
        /// </summary>
        /// <param name="action"></param>
        public void move_record(string action)
        {
            if (common_file.common_hy.Hhygl_browse_new != null)
            {
                switch (action)
                {
                    case "first":
                        bindingSource1.MoveFirst();
                        break;
                    case "previous":
                        bindingSource1.MovePrevious();
                        break;
                    case "next":
                        bindingSource1.MoveNext();
                        break;
                    case "last":
                        bindingSource1.MoveLast();
                        break;
                       
                }
                

            }
        
        }
       
        private void b_delete_Click(object sender, EventArgs e)
        {
            b_delete_hygl();
            
        }
        public void b_delete_hygl()
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_hygl__sc", common_file.common_app.user_type) == false)
            { return; }
            if (DS_Hygl != null && DS_Hygl.Tables[0].Rows.Count > 0)
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要删除所选中的记录！") == true)
                {
                    int j = 0; string s = "";
                    for (int i = 0; i < dg_count; i++)
                    {
                        common_file.common_app.get_czsj();
                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_hygl.Rows[i].Cells[0].GetEditedFormattedValue(i, ss) != null && Convert.ToBoolean(this.dg_hygl.Rows[i].Cells[0].GetEditedFormattedValue(i, ss)) == true)
                        {
                            //j = Convert.ToInt32(dg_hygl.Rows[i].Index.ToString());

                            DataRowView dgr = dg_hygl.Rows[i].DataBoundItem as DataRowView;
                            j = DS_Hygl.Tables[0].Rows.IndexOf(dgr.Row);



                            if (DS_Hygl.Tables[0].Rows[j]["id"].ToString() != "")
                            {
                                common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "删除会员", "" + DS_Hygl.Tables[0].Rows[j]["id"].ToString() + "", "", DateTime.Now);
                                string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                s = common_file.common_hy.Delete_Hygl(DS_Hygl.Tables[0].Rows[j]["id"].ToString(), url);


                            }
                            else
                            {
                                //提示
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "你好,你没有选择任何信息");
                            }


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

        private void b_refresh_Click(object sender, EventArgs e)
        {
            sel_condition = "";
            InitializeApp();

        }
        private void b_first_Click(object sender, EventArgs e)
        {
            move_record("first");
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            move_record("previous");
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            move_record("next");
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            move_record("last");
        }

        private void dg_hygl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            open_record();
        }

        private void b_hk_Click(object sender, EventArgs e)
        {
            //common_file.common_app.get_czsj();
            //if (dg_count > 0 && dg_hygl.Rows[0].Cells["id"].Value != null && dg_hygl.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            //{
            //    int i = dg_hygl.CurrentRow.Index;
            //    if (i > -1 && i < dg_count)//当前行为内容行
            //    {
            //        int id = Convert.ToInt32(dg_hygl.Rows[i].Cells["id"].Value);
            //        Hhygl.Hhygl_hyhk Hhygl_hyhk_new = new Hhygl_hyhk();
            //        Hhygl_hyhk_new.Hhygl_hyhk_1();
            //        Hhygl_hyhk_new.StartPosition = FormStartPosition.CenterScreen;
            //        Hhygl_hyhk_new.ShowDialog();
            //    }
            //}
            //Cursor.Current = Cursors.Default;
       
           
        }
        

        private void b_sj_Click(object sender, EventArgs e)
        {
            open_hysj();
           

        }
        public void open_hysj()  //会员升级页
        {
            common_file.common_app.get_czsj();
            if (dg_count > 0 && dg_hygl.Rows[0].Cells["id"].Value != null && dg_hygl.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            {
                int i = dg_hygl.CurrentRow.Index;

                DataRowView dgr = dg_hygl.CurrentRow.DataBoundItem as DataRowView;
                i = DS_Hygl.Tables[0].Rows.IndexOf(dgr.Row);


                if (i > -1 && i < dg_count)//当前行为内容行
                {
                    //int id = Convert.ToInt32(dg_hygl.Rows[i].Cells["id"].Value);
                    Hhygl.Hhygl_hysj Hhygl_hysj_new = new Hhygl_hysj(this);
                    Hhygl_hysj_new.StartPosition = FormStartPosition.CenterScreen;

                    Hhygl_hysj_new.Hhygl_id = DS_Hygl.Tables[0].Rows[i]["id"].ToString();
                    Hhygl_hysj_new.tB_hykh_bz.Text = DS_Hygl.Tables[0].Rows[i]["hykh_bz"].ToString();
                    Hhygl_hysj_new.tB_krxm.Text = DS_Hygl.Tables[0].Rows[i]["krxm"].ToString();
                    Hhygl_hysj_new.tB_hyrx.Text = DS_Hygl.Tables[0].Rows[i]["hyrx"].ToString();
                    Hhygl_hysj_new.tB_hyjf.Text = DS_Hygl.Tables[0].Rows[i]["hyjf"].ToString();
                    //Hhygl_hysj_new.tB_hykh.Text = DS_Hygl.Tables[0].Rows[i]["hykh"].ToString();
                    Hhygl_hysj_new.strhykh = DS_Hygl.Tables[0].Rows[i]["hykh"].ToString();
                    Hhygl_hysj_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_jfdf_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_count > 0 && dg_hygl.Rows[0].Cells["id"].Value != null && dg_hygl.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            {
                int i = dg_hygl.CurrentRow.Index;
                if (i > -1 && i < dg_count)//当前行为内容行
                {
                    int id = Convert.ToInt32(dg_hygl.Rows[i].Cells["id"].Value);

                    DataRowView dgr = dg_hygl.CurrentRow.DataBoundItem as DataRowView;
                    i = DS_Hygl.Tables[0].Rows.IndexOf(dgr.Row);

                    Hhygl.Hhygl_jfdf Hhygl_jfdf_new = new Hhygl_jfdf(this);
                    Hhygl_jfdf_new.StartPosition = FormStartPosition.CenterScreen;
                   // Hhygl_jfdf_new.tB_hykh.Text = DS_Hygl.Tables[0].Rows[i]["hykh"].ToString();
                    Hhygl_jfdf_new.hykh = DS_Hygl.Tables[0].Rows[i]["hykh"].ToString();
                    Hhygl_jfdf_new.ShowDialog();
                }
            }
            Cursor.Current = Cursors.Default;


        }

        private void b_search_Click(object sender, EventArgs e)
        {


            Hhygl.Hhygl_gl Hhygl_gl_new = new Hhygl_gl();
            Hhygl_gl_new.StartPosition = FormStartPosition.CenterScreen;
            if (Hhygl_gl_new.ShowDialog() == DialogResult.OK)
            {
                //sel_condition = "";
                sel_condition = sel_condition + Hhygl_gl_new.get_sel_cond;
                if (Hhygl_gl_new.get_sel_cond != "")
                {
                    refresh_app();
                }
            }

            Hhygl_gl_new.Dispose();


         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}