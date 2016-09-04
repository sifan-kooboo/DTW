using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Fftfx : Form
    {
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        DataSet DS_zft; DataSet DS_zkfx; DataSet DS_sktt_ddlk; DataSet DS_7days;
        DataSet DS_7days_zy; DataSet DS_7days_ky;
        int dG_count_zft = 0; int dG_count_zkfx = 0; int dG_count_sktt_ddlk = 0;
        int dG_count_7days = 0; int dG_count_7days_zy = 0; int dG_count_7days_ky = 0;
        DateTime start_date_db = DateTime.Parse(DateTime.Now.ToShortDateString());
        DateTime start_date_7days = DateTime.Parse(DateTime.Now.ToShortDateString());
        DateTime start_date_7days_zy = DateTime.Parse(DateTime.Now.ToShortDateString());
        DateTime start_date_7days_ky = DateTime.Parse(DateTime.Now.ToShortDateString());
        bool is_7days = false;//用来判断是否已经生成了，如果生成就不再自动生成，除非刷新
        bool is_7days_zy = false;//用来判断是否已经生成了，如果生成就不再自动生成，除非刷新
        bool is_7days_ky = false;//用来判断是否已经生成了，如果生成就不再自动生成，除非刷新
        string select_s = "";
        String sel_cond_bhwx = "";//用来赋是否包含维修和其他房的条件
        string condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   czy='" + common_file.common_app.czy + "' order by id";
        public Fftfx()
        {
            InitializeComponent();
            load_product();

        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void load_product()
        {
            common_file.common_app.get_czsj();
            Fftfx_c Fftfx_c_new = new Fftfx_c();
            Fftfx_c_new.dr_ft_fx(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, DateTime.Now, common_file.common_app.xxzs_zsvalue);
            refresh_zft();
            refresh_zkfx();
            refresh_sktt_ddlk();
            Cursor.Current = Cursors.Default;
        }

        public void refresh_zft()
        {
            select_s = "select * from F_ftfx_zft";
            dG_zft.AutoGenerateColumns = false;
            DS_zft = B_Common.GetList(select_s, condition);
            bS_zft.DataSource = DS_zft.Tables[0];
            dG_count_zft = DS_zft.Tables[0].Rows.Count;
        }

        public void refresh_zkfx()
        {
            select_s = "select * from F_ftfx_zkfx";
            dG_zkfx.AutoGenerateColumns = false;
            DS_zkfx = B_Common.GetList(select_s, condition);
            bS_zkfx.DataSource = DS_zkfx.Tables[0];
            dG_count_zkfx = DS_zkfx.Tables[0].Rows.Count;
        }


        public void refresh_sktt_ddlk()
        {
            select_s = "select * from F_ftfx_sktt_ddlk";
            dG_sktt_ddlk0.AutoGenerateColumns = false;
            DS_sktt_ddlk = B_Common.GetList(select_s, condition);
            bS_sktt_ddlk.DataSource = DS_sktt_ddlk.Tables[0];
            dG_count_sktt_ddlk = DS_sktt_ddlk.Tables[0].Rows.Count;
        }

        private void bS_zft_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void set_7day()
        {
            common_file.common_app.get_czsj();
            Fftft_7day Fftft_7day_new = new Fftft_7day();
            Fftft_7day_new.set_7day_app(common_file.common_app.yydh, common_file.common_app.qymc, start_date_7days, common_file.common_app.czy, DateTime.Now, common_file.common_app.xxzs_zsvalue);
            amend_colu_7days(start_date_7days);
            refresh_7days();
            is_7days = true;
            Cursor.Current = Cursors.Default;
        }

        private void set_ftfx_7day_zy()
        {
            
            common_file.common_app.get_czsj();
            //sel_cond_bhwx = cB_cond.Text;
            Fftfx_7day_zy Fftfx_7day_zy_new = new Fftfx_7day_zy();
            Fftfx_7day_zy_new.set_ftfx_7day_zy_app(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, start_date_7days_zy, DateTime.Now,sel_cond_bhwx);
            amend_colu_7days_zy(start_date_7days_zy);
            refresh_7days_zy();
            is_7days_zy = true;
            Cursor.Current = Cursors.Default;
        }

        private void set_ftfx_7day_ky()
        {
            common_file.common_app.get_czsj();
            //sel_cond_bhwx = cB_cond.Text;
            Fftfx_7day_ky Fftfx_7day_ky_new = new Fftfx_7day_ky();
            Fftfx_7day_ky_new.set_ftfx_7day_ky_app(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, start_date_7days_ky, DateTime.Now,  sel_cond_bhwx);
            amend_colu_7days_ky(start_date_7days_ky);
            refresh_7days_ky();
            is_7days_ky = true;
            Cursor.Current = Cursors.Default;
        }


        private void tc_AddInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_AddInfo.SelectedIndex == 0)
            {
                load_product();
            }
            else 
            if (tc_AddInfo.SelectedIndex == 1)
            {
                if (is_7days == false)
                {
                    set_7day();
                }
                else 
                {
                    //if (start_date_db != start_date_7days  || sel_cond_bhwx != cB_cond.Text)
                    //{
                        start_date_7days = start_date_db;
                        set_7day();
                    //}
                }
            }
            else
                if (tc_AddInfo.SelectedIndex == 2)
                {
                    if (is_7days_zy == false)
                    {
                        set_ftfx_7day_zy();
                    }
                    else
                    {
                        //if (start_date_db != start_date_7days_zy || sel_cond_bhwx != cB_cond.Text)
                        //{
                            start_date_7days_zy = start_date_db;
                            set_ftfx_7day_zy();
                        //}
                    }
                }
                else
                    if (tc_AddInfo.SelectedIndex == 3)
                    {
                        if (is_7days_ky == false)
                        {
                            set_ftfx_7day_ky();
                        }
                        else
                        {
                            //if (start_date_db != start_date_7days_ky || sel_cond_bhwx != cB_cond.Text)
                            //{
                                start_date_7days_ky = start_date_db;
                                set_ftfx_7day_ky();
                            //}
                        }
                    }
        }
        public void amend_colu_7days(DateTime start_rq)
        {
            DateTime start_rq_0 = start_rq;
            for (int i_0 = 1; i_0 < 8; i_0++)
            {
                dG_7days.Columns[i_0].HeaderText = start_rq_0.ToShortDateString() + "(" + common_file.common_app.get_week(start_rq_0) + ")";
                start_rq_0 = start_rq_0.AddDays(1);
            }
        }

        public void refresh_7days()
        {
            select_s = "select * from F_ftfx_7days";
            dG_7days.AutoGenerateColumns = false;
            DS_7days = B_Common.GetList(select_s, condition);
            bS_7days.DataSource = DS_7days.Tables[0];
            dG_count_7days = DS_7days.Tables[0].Rows.Count;
        }

        public void amend_colu_7days_zy(DateTime start_rq)
        {
            DateTime start_rq_0 = start_rq;
            for (int i_0 = 1; i_0 < 8; i_0++)
            {
                dG_7days_zy.Columns[2 * i_0 + 1].HeaderText = start_rq_0.Month + "-" + start_rq_0.Day + "(" + common_file.common_app.get_week(start_rq_0) + ")";
                start_rq_0 = start_rq_0.AddDays(1);
            }
        }

        public void refresh_7days_zy()
        {
            select_s = "select * from F_ftfx_7days_zy";
            dG_7days_zy.AutoGenerateColumns = false;
            DS_7days_zy = B_Common.GetList(select_s, condition);
            bS_7days_zy.DataSource = DS_7days_zy.Tables[0];
            dG_count_7days_zy = DS_7days_zy.Tables[0].Rows.Count;
        }


        public void amend_colu_7days_ky(DateTime start_rq)
        {
            DateTime start_rq_0 = start_rq;
            for (int i_0 = 1; i_0 < 8; i_0++)
            {
                dG_7days_ky.Columns[2 * i_0].HeaderText = start_rq_0.Month + "-" + start_rq_0.Day + "(" + common_file.common_app.get_week(start_rq_0) + ")";
                start_rq_0 = start_rq_0.AddDays(1);
            }
        }

        public void refresh_7days_ky()
        {
            select_s = "select * from F_ftfx_7days_ky";
            dG_7days_ky.AutoGenerateColumns = false;
            DS_7days_ky = B_Common.GetList(select_s, condition);
            bS_7days_ky.DataSource = DS_7days_ky.Tables[0];
            dG_count_7days_ky = DS_7days_ky.Tables[0].Rows.Count;
        }

        private void b_fx_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要重新分析房态") == true)
            {
                switch (tc_AddInfo.SelectedIndex)
                {
                    case 0:
                        load_product();
                        common_file.common_app.Message_box_show(common_file.common_app.message_title,"当日查询不受时间选择的影响，只查询当日信息！");
                        start_date_db = DateTime.Parse(DT_start_date.Value.ToShortDateString());
                        break;
                    case 1:
                        start_date_7days = DateTime.Parse(DT_start_date.Value.ToShortDateString());
                        start_date_db = start_date_7days;
                        sel_cond_bhwx = cB_cond.Text;
                        set_7day();
                        break;
                    case 2:
                        start_date_7days_zy = DateTime.Parse(DT_start_date.Value.ToShortDateString());
                        start_date_db = start_date_7days_zy;
                        sel_cond_bhwx = cB_cond.Text;
                        set_ftfx_7day_zy();
                        break;
                    case 3:
                        start_date_7days_ky =DateTime.Parse(DT_start_date.Value.ToShortDateString());
                        start_date_db = start_date_7days_ky;
                        sel_cond_bhwx = cB_cond.Text;
                        set_ftfx_7day_ky();
                        break;
                }
            }
        }

        private void Fftfx_Load(object sender, EventArgs e)
        {
            cB_cond.Text = common_Ffjzt.fsfx_bh_mr;
            sel_cond_bhwx = cB_cond.Text;
        }

        private void cB_cond_TextChanged(object sender, EventArgs e)
        {
            sel_cond_bhwx = cB_cond.Text;
        }


    }
}