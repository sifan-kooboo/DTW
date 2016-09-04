using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Fkfxsfx_app : Form
    {
        public int column_sl_z = 0;
        public Fkfxsfx_app()
        {
            InitializeComponent();
            
            
            refresh_app();

        }
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        DateTime Start_date = DateTime.Now.Date;
        DataSet DS_fx_fs;
        DataSet DS_fx_fy;
        string select_s = "";
        string condition = "";
        DataSet ds_out_fs = new DataSet();
        DataSet ds_out_fy = new DataSet();
        DataSet DS_temp = null;
        int col_Count = 0;
        public void set_column(int column_sl)
        {
            col_Count = column_sl;
            DS_temp = B_Common.GetList("select * from F_kfxsfx", " yydh='" + common_file.common_app.yydh + "' and czy_temp='" + common_file.common_app.czy + "' and  hj_n_fs='" + "本年累计" + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (int i_0 = 1; i_0 < column_sl + 1; i_0++)
                {
                    dG_fx_fs.Columns[i_0].Visible = true;
                    dG_fx_fs.Columns[i_0].HeaderText = DS_temp.Tables[0].Rows[0]["fjrb_fs_" + i_0.ToString()].ToString();
                    dG_fx_fy.Columns[i_0].Visible = true;
                    dG_fx_fy.Columns[i_0].HeaderText = DS_temp.Tables[0].Rows[0]["fjrb_fy_" + i_0.ToString()].ToString();
                }


            }


            DS_temp.Clear();
            DS_temp.Dispose();
        }

        public void refresh_app()
        {
            common_file.common_app.get_czsj();
            if (Start_date == DateTime.Now.Date)
            {
                Start_date = Start_date.AddDays(-1);
            }

            tB_fxsj.Text = "分析时间：" + Start_date.ToString();
            Ffjzt.Fkfxsfx Fkfxsfx_new = new Hotel_app.Ffjzt.Fkfxsfx();


           column_sl_z=  Fkfxsfx_new.F_ftxsfx(common_file.common_app.yydh, common_file.common_app.qymc, DateTime.Parse(Start_date.ToString()), common_file.common_app.czy);


            set_column(column_sl_z);
            
            common_file.common_app.get_czsj();
            select_s = "select * from F_kfxsfx";
            dG_fx_fs.AutoGenerateColumns = false;
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   czy_temp='" + common_file.common_app.czy + "' and krly!='' order by id";
            DS_fx_fs = B_Common.GetList(select_s, condition);
            DS_fx_fy = DS_fx_fs;
            bs_fx_fs.DataSource = DS_fx_fs.Tables[0];
            bs_fx_fy.DataSource = DS_fx_fy.Tables[0];
            //dg_count_sk = DS_fx_fs.Tables[0].Rows.Count;
            //(dg_sk);
            Cursor.Current = Cursors.Default;
        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_fx_Click(object sender, EventArgs e)
        {
            Start_date =DateTime.Parse(DT_start_date.Value.ToShortDateString());
            refresh_app();
        }


        private void OutToExcel()
        {


        }

        private void b_OutPort_Click(object sender, EventArgs e)
        {
            int TotalCount = 0;
            DS_temp = B_Common.GetList("select * from F_kfxsfx", " yydh='" + common_file.common_app.yydh + "' and czy_temp='" + common_file.common_app.czy + "' ");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                
                if (TC_fx.SelectedIndex == 0)
                {
                    //导出前处理一下DS

                    common_file.common_DataSetToExcel.ExportMX(DS_fx_fs,col_Count, DS_temp, "Fkfxsfx_fxfs", "房数分析");
                }
                if (TC_fx.SelectedIndex == 1)
                {
                    common_file.common_DataSetToExcel.ExportMX(DS_fx_fy,col_Count, DS_temp, "Fkfxsfx_fy", "费用分析");
                }
            }
        }

        private void tB_fxsj_TextChanged(object sender, EventArgs e)
        {

        }

    }
}