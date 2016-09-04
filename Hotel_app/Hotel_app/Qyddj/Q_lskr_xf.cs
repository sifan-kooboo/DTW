using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Hotel_app.Qyddj
{
    public partial class Q_lskr_xf : Form
    {
        public Q_lskr_xf()
        {
            InitializeComponent();
        }
        DataSet ds = null;
        string time_qssj = "";
        string time_jssj = "";
        string sel_con = "";
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        public Q_lskr_xf(DataSet _ds, string _time_qssj, string _time_jssj)
        {
            InitializeComponent();
            this.ds = _ds;
            time_jssj = _time_jssj;
            time_qssj = _time_qssj;
            Bindata();
        }
        private void Bindata()
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dg_lskr.AutoGenerateColumns = false;
                ds.Tables[0].DefaultView.RowFilter = sel_con;
                bindingSource1.DataSource = ds.Tables[0];
                dg_lskr.DataSource = bindingSource1;
            }
        }


        private void b_first_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
        }

        private void b_mx_Click(object sender, EventArgs e)
        {
            openmx();

        }




        private void openmx()
        {
            common_file.common_app.get_czsj();
            string zjhm_0 = "";
            string krxm_0 = "";
            string totalCost = "";//累计消费
            if (dg_lskr.CurrentRow != null && dg_lskr.CurrentRow.Index > -1)
            {
                int i = dg_lskr.CurrentRow.Index;
                DataRowView dgr = dg_lskr.CurrentRow.DataBoundItem as DataRowView;
                int j = ds.Tables[0].Rows.IndexOf(dgr.Row);
                string temp = ds.Tables[0].Rows[i]["zjhm"].ToString();

                if (j > -1 && i <ds.Tables[0].Rows.Count)//当前行为内容行
                {
                    //int id = Convert.ToInt32(dg_lskr.Rows[i].Cells["id"].Value);
                    //if (id != 0)
                    //{
                        totalCost = dg_lskr.Rows[i].Cells["totalCost"].Value.ToString();
                        //Model.Qskyd_mainrecord_lskr M_Qskyd_mainrecord_lskr = null;
                        //BLL.Qskyd_mainrecord_lskr B_Qskyd_mainrecord_lskr = new Hotel_app.BLL.Qskyd_mainrecord_lskr();
                        //M_Qskyd_mainrecord_lskr = B_Qskyd_mainrecord_lskr.GetModel(id);
                        zjhm_0 = ds.Tables[0].Rows[j]["zjhm"].ToString();
                        krxm_0 = ds.Tables[0].Rows[j]["krxm"].ToString();
                        //if (M_Qskyd_mainrecord_lskr != null)
                        //{
                            //if (M_Qskyd_mainrecord_lskr.zjhm != null)
                            //{
                            //    zjhm_0 = M_Qskyd_mainrecord_lskr.zjhm;
                            //}
                            //if (M_Qskyd_mainrecord_lskr.krxm != null)
                            //{//证件号码存在时才进行积分查询
                            //    krxm_0 = M_Qskyd_mainrecord_lskr.krxm;
                            //}
                            if (zjhm_0.Trim() != "" && krxm_0.Trim() != "")
                            {
                                DataSet ds_lskr_xfmx = B_Common.GetList(" select * from View_ssyxfmx_lskr_mx ", " id>=0  and  krxm='" + krxm_0 + "' and  zjhm='" + zjhm_0 + "'  and  xfdr='" + Szwgl.common_zw.dr_ff + "'  and  yydh='" + common_file.common_app.yydh + "'   and   xfsj>='"+time_qssj+"'  and xfsj<='"+time_jssj+"'   order by xfrq ");
                                if (ds_lskr_xfmx != null && ds_lskr_xfmx.Tables[0].Rows.Count > 0)
                                {
                                    Q_lskr_xfmx Q_lskr_xfmx_new = new Q_lskr_xfmx(ds_lskr_xfmx, krxm_0, zjhm_0, totalCost);
                                    Q_lskr_xfmx_new.StartPosition = FormStartPosition.CenterScreen;
                                    Q_lskr_xfmx_new.ShowDialog();
                                }

                            }
                            else
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,由于历史客人没有正确录入证件号码和姓名,系统无法查询历史累计消费");
                                return;
                            }
                        //}

                    //}
                }
            }
            Cursor.Current = Cursors.Default;

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            Q_lskr_xf_gl Q_lskr_xf_gl_new = new Q_lskr_xf_gl();
            Q_lskr_xf_gl_new.StartPosition = FormStartPosition.CenterScreen;
            if (Q_lskr_xf_gl_new.ShowDialog() == DialogResult.OK)
            {
                sel_con = Q_lskr_xf_gl_new.sel_con;
                Bindata();
            }
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            sel_con = "";
            Bindata();
        }

        private void dg_lskr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dg_lskr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            openmx();
        }

        private void b_krxh_Click(object sender, EventArgs e)
        {

        }

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_yddj_outport", common_file.common_app.user_type) == false)
            { return; }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    
                }
                string filePath = "";
                string fileName = "";
                string get_fileName = "";
                Hashtable nameList = new Hashtable();
               common_file.common_DataSetToExcel.ExportMX(ds, "skdj_lskr", "历史客人内容导出");
            }
        }
    }
}