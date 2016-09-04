using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_sfz_temp : Form
    {
        public int dg_count = 0;//记录初期加载行数
        public string sql_condition = "";
        DataSet DS_Q_sfz_temp;
        BLL.Q_sfz_temp B_Q_sfz_temp = new Hotel_app.BLL.Q_sfz_temp();
        public string s_0 = "";
        public Q_sfz_temp(string sql_condition_0)
        {
            sql_condition = sql_condition_0;
            InitializeComponent();
            refresh_app();
        }

        internal void refresh_app()
        {
            common_file.common_app.get_czsj();
            this.dg_Q_sfz_temp.AutoGenerateColumns = false;
            DS_Q_sfz_temp = B_Q_sfz_temp.GetList("id>=0" + sql_condition + "    and shcl=0  order by id desc");
            bs_Q_sfz_temp.DataSource = DS_Q_sfz_temp.Tables[0];
            dg_count = DS_Q_sfz_temp.Tables[0].Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void Q_sfz_temp_Load(object sender, EventArgs e)
        {
            s_0 = this.Text;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            this.Dispose();
            

        }

        private void b_cx_Click(object sender, EventArgs e)
        {
            //if (tB_gl.Visible == true)
            //{
            //    tB_gl.Visible = false;
            //}
            //else
            //{
            //    tB_gl.Visible = true;
            //    tB_gl.Focus();
            //}
            tB_gl.Visible = true;
            tB_gl.BringToFront();
            tB_gl.Focus();




        }

        private void tB_gl_TextChanged(object sender, EventArgs e)
        {
            sql_condition = "    and    (krxm like '%" + tB_gl.Text.Trim() + "%' or zjhm like '%" + tB_gl.Text.Trim() + "%')";
            refresh_app();
        }

        private void b_zl_Click(object sender, EventArgs e)
        {
            if (dg_Q_sfz_temp.CurrentRow != null)
            {
                int i_00 = 0;
                DataRowView dgr = dg_Q_sfz_temp.CurrentRow.DataBoundItem as DataRowView;
                i_00 = DS_Q_sfz_temp.Tables[0].Rows.IndexOf(dgr.Row);
                if (dg_count > 0 && dg_Q_sfz_temp.CurrentRow.Index < dg_count && DS_Q_sfz_temp != null && DS_Q_sfz_temp.Tables[0].Rows[i_00]["id"].ToString() != "")
                {
                    Qyddj.Q_sk_tt_app Q_sk_tt_app_new = new Qyddj.Q_sk_tt_app(DS_Q_sfz_temp.Tables[0].Rows[i_00]["id"].ToString(), common_file.common_yddj.yddj_dj, "sfz_zl_fj");
                    Q_sk_tt_app_new.Left = 200;
                    Q_sk_tt_app_new.Top = 200;
                    Q_sk_tt_app_new.ShowDialog();
                    tB_gl.Text = "";
                    refresh_app();
                    tB_gl.Visible = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Qyddj.Q_zjgl Q_zjgl_new=new Q_zjgl();
            //this.Text=s_0+Q_zjgl_new.add_ls_sfz();
            string result_0 = "";
            string tBkrxm = ""; string tBkrxb = ""; string tBnation = "";
            string tBadd = ""; string tBid = ""; string tBkrsr = "";
            string tBdepart = ""; string tBstart = ""; string tBend = "";
            bool sh_massage = false;
            string massage_nr = "";
            byte[] imakrxp = new byte[0];
            common_file.CVRSDKReadCard cvrsdk =new Hotel_app.common_file.CVRSDKReadCard(ref  tBkrxm, ref  tBkrxb, ref  tBnation, ref  tBadd, ref  tBid, ref  tBkrsr, ref  tBdepart, ref  tBstart, ref  tBend, ref  imakrxp,  sh_massage, ref  massage_nr);
            refresh_app();
        }

        private void Q_sfz_temp_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this = null;
        }

        private void b_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Qyddj.Q_zjgl Q_zjgl_new = new Q_zjgl();
            //this.Text=s_0+Q_zjgl_new.add_ls_sfz();
            string result_0 = "";
            string tBkrxm = ""; string tBkrxb = ""; string tBnation = "";
            string tBadd = ""; string tBid = ""; string tBkrsr = "";
            string tBdepart = ""; string tBstart = ""; string tBend = "";
            bool sh_massage = false;
            string massage_nr = "";
            byte[] imakrxp = new byte[0];
            common_file.CVRSDKReadCard cvrsdk = new Hotel_app.common_file.CVRSDKReadCard(ref  tBkrxm, ref  tBkrxb, ref  tBnation, ref  tBadd, ref  tBid, ref  tBkrsr, ref  tBdepart, ref  tBstart, ref  tBend, ref  imakrxp, sh_massage, ref  massage_nr);
            refresh_app();
        }
    }
}