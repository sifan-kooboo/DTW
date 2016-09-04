using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    public partial class Ffjzt_select : Form
    {

        public BLL.Common B_Common = new Hotel_app.BLL.Common();
        public int dg_count = 0;
        public DataSet DS_Ffjzt;
        public string get_yddj = common_file.common_yddj.yddj_dj;//打开获得预订登记的状态；
        public string get_fjrb = "";//双击选择获得值,打开获得房间类别
        public string get_fjbh = "";//双击选择获得值
        public decimal get_fjjg = 0;//双击选择获得值
        public string url = "";
        public DateTime temp_ddsj = common_file.common_app.czsj;
        public DateTime temp_lksj = common_file.common_app.czsj;
        public string yddj = common_file.common_yddj.yddj_dj;
        public bool is_lksj = false;
        //团体排房时传递的临时变量
        public string tt_Qskdy_fjrb_id = "";
        public string tt_lsbh = "";
        public string tt_fjrb = "";
        public string tt_fjjg = "";
        public string tt_shqh = "";
        public string tt_yh = "";
        public string tt_bz = "";
        public string tt_lzfs = "";
        public string sh_ttpf = "";//值为tt
        public string yddj_type = common_file.common_app.yddj_type_personal;//判断是团体还是个人


        public string convery_fjrb = "";//从主单传递过来的房型
        public string table_name = "Ffjzt";//由于表到时有可能由存储过程创建,所以表不能用固守的表名
        public string zyzt = " and (zyzt='" + common_file.common_fjzt.gjf + "' or zyzt='" + common_file.common_fjzt.zf + "')";


        public Ffjzt_select(string fjrb_temp, DateTime ddsj, DateTime lksj, string yddj)
        {
            InitializeComponent();
            this.temp_ddsj = ddsj;
            this.temp_lksj = lksj;
            this.yddj = yddj;
            convery_fjrb = fjrb_temp;
            InitializeApp();
        }
        public Ffjzt_select()
        {
            InitializeComponent();
            InitializeApp();
        }


        public void InitializeApp()
        {
            if (temp_ddsj > Convert.ToDateTime("1949-01-01") && temp_lksj > Convert.ToDateTime("1949-01-01"))
            {


                refresh_ft(is_lksj);



                this.dg_fjzt.AutoGenerateColumns = false;
            }

        }
        public void refresh_ft(bool is_lksj_0)
        {
            //common_file.common_used_fjzt.get_dataset_fjzt_canused(out DS_Ffjzt, common_file.common_yddj.yddj_dj, this.temp_ddsj, this.temp_lksj, convery_fjrb, false ,false);
            common_file.common_used_fjzt.get_dataset_fjzt_canused(out DS_Ffjzt, this.yddj, this.temp_ddsj, this.temp_lksj, convery_fjrb, is_lksj_0, common_file.common_app.is_contain_wx);
            bindingSource1.DataSource = DS_Ffjzt.Tables[0];
            this.dg_fjzt.AutoGenerateColumns = false;
            dg_count = DS_Ffjzt.Tables[0].Rows.Count;
        }

        private void Ffjzt_select_Load(object sender, EventArgs e)
        {
            if (yddj_type == common_file.common_app.yddj_type_personal)
            {
                gB_pf.Visible = false;
                gB_exit.Left = 138;
            }
            else
                if (yddj_type == common_file.common_app.yddj_type_group)
                {
                    gB_pf.Visible = true;
                    gB_exit.Left = 265;
                }
        }

        private void dg_fjzt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dg_fjzt_DoubleClick(sender, e);
            }
            else
                if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

        private void b_FindMore_Click(object sender, EventArgs e)
        {
            if (temp_ddsj > Convert.ToDateTime("1949-01-01") && temp_lksj > Convert.ToDateTime("1949-01-01"))
            {
                is_lksj = true;
                refresh_ft(is_lksj);
                //(dg_fjzt);
            }
        }



        private void dg_fjzt_DoubleClick(object sender, EventArgs e)
        {
            ttpf();
        }


        private void ttpf()
        {
            sh_ttpf = "";
            if (yddj_type == common_file.common_app.yddj_type_personal)
            {

                if (dg_fjzt.CurrentRow != null)
                {
                    int j_000 = 0;
                    DataRowView dgr = dg_fjzt.CurrentRow.DataBoundItem as DataRowView;
                    j_000 = DS_Ffjzt.Tables[0].Rows.IndexOf(dgr.Row);



                    if (dg_count > 0 && dg_fjzt.CurrentRow.Index < dg_count && DS_Ffjzt.Tables[0].Rows[j_000]["fjbh"].ToString() != "")
                    {
                        int i_0 = 2;
                        if (common_file.common_fjzt.zf == DS_Ffjzt.Tables[0].Rows[j_000]["zyzt"].ToString())
                        {
                            i_0 = 3;
                            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "目前该房是" + common_file.common_fjzt.zf + "，是否确认要排房！") == true)
                            {
                                i_0 = 2;
                            }
                        }
                        if (i_0 == 2)
                        {
                            get_fjrb = DS_Ffjzt.Tables[0].Rows[j_000]["fjrb"].ToString();
                            get_fjbh = DS_Ffjzt.Tables[0].Rows[j_000]["fjbh"].ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            else
                if (yddj_type == common_file.common_app.yddj_type_group)
                {
                    common_file.common_app.get_czsj();
                    //遍历dgv,如果第一列为真，就删除
                    string[] strs_fjbh = new string[50];
                    string fjbh_temp = ""; int sl_fjbh = 0; int pfsl_temp = 0;
                    int k_0 = 0;
                    for (int j = 0; j < dg_count; j++)
                    {
                        common_file.common_app.get_czsj();

                        int j_000 = 0;
                        DataRowView dgr = dg_fjzt.Rows[j].DataBoundItem as DataRowView;
                        j_000 = DS_Ffjzt.Tables[0].Rows.IndexOf(dgr.Row);


                        DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                        if (this.dg_fjzt.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_fjzt.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                        {
                            if (this.dg_fjzt.Rows[j].Cells["fjbh"].Value != null)
                            {

                                fjbh_temp = (this.dg_fjzt.Rows[j].Cells["fjbh"].Value).ToString();
                                //if (j < 50)
                                if (j < dg_count)
                                {
                                    int i_0 = 2;
                                    if (common_file.common_fjzt.zf == DS_Ffjzt.Tables[0].Rows[j_000]["zyzt"].ToString())
                                    {
                                        i_0 = 3;
                                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "目前该房" + DS_Ffjzt.Tables[0].Rows[j_000]["fjbh"].ToString() + "是" + common_file.common_fjzt.zf + "，是否确认要排房！") == true)
                                        {
                                            i_0 = 2;
                                        }
                                    }

                                    if ((float.Parse(tt_lzfs.Trim()) - sl_fjbh - 1) < 0)
                                    {
                                        i_0 = 3;
                                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "房间以经超过目前初始的" + tt_lzfs.ToString() + "间" + ",是否要继续强制排房?") == true)
                                        {
                                            i_0 = 2;
                                        }
                                    }


                                    if (i_0 == 2)
                                    {
                                        strs_fjbh[k_0] = fjbh_temp;
                                        k_0 = k_0 + 1;
                                    }



                                }
                                sl_fjbh += 1;
                            }
                        }
                    }
                    if (fjbh_temp == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择要排的房间！");
                        return;
                    }
                    //如果选择了多间，进行多间排房
                    if (strs_fjbh.Length > 0 && sl_fjbh <= 50)
                    {
                        url = common_file.common_app.service_url;
                        url += "Qyddj/Qyddj_app.asmx";
                        object[] args_1 = new object[12];
                        args_1[0] = tt_Qskdy_fjrb_id.ToString();
                        args_1[1] = tt_lsbh;
                        args_1[2] = tt_fjrb;
                        args_1[3] = strs_fjbh;
                        args_1[4] = tt_fjjg;
                        args_1[5] = tt_shqh;
                        args_1[6] = tt_yh;
                        args_1[7] = tt_bz;
                        args_1[8] = common_file.common_app.czy;
                        args_1[9] = DateTime.Now.ToString();
                        args_1[10] = "团体排房";
                        args_1[11] = common_file.common_app.xxzs;
                        Hotel_app.Server.Qyddj.Qttyd_add_edit_delete Qttyd_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qttyd_add_edit_delete();
                        string result_temp = Qttyd_add_edit_delete_services.tt_pf_multi(args_1[0].ToString(), args_1[1].ToString(), args_1[2].ToString(), strs_fjbh, args_1[4].ToString(), args_1[5].ToString(), args_1[6].ToString(), args_1[7].ToString(),
args_1[8].ToString(), args_1[9].ToString(), args_1[10].ToString(), args_1[11].ToString());
                        //object result_temp = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "tt_pf_multi", args_1);
                        if (result_temp != null && result_temp== common_file.common_app.get_suc)
                        {
                            common_file.common_form.Qttdj_new.RefreshApp();
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "团体成员排房成功!");
                            sh_ttpf = "tt";
                        }
                        refresh_ft(is_lksj);
                        this.DialogResult = DialogResult.OK;
                        //this.Close();

                    }
                    else
                    {

                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "警告，一次排房不能超过50间,当前选择房间数过多,请减少一些排房数!");
                    }
                }

        }
        private void btn_ttpf_Click(object sender, EventArgs e)
        {
            ttpf();
        }

        private void b_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}