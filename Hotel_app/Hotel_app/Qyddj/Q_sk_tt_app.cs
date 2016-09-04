using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_sk_tt_app : Form
    {
        public string id = "";
        public int i = 0;
        public int dg_count_sk = 0;
        public int dg_count_tt = 0;
        public string yddj = "";
        public string select_s = "";
        public DataSet DS_Qsk;
        public DataSet DS_Qtt;
        public BLL.Common B_Common = new Hotel_app.BLL.Common();
        public string load_type = "";//登录进来做什么；"lt","zz","jzzz","gzzz"
        string condition = "";





        BLL.Sjzzd B_Sjzzd = new Hotel_app.BLL.Sjzzd();
        Model.Sjzzd M_Sjzzd;
        BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        Model.Qskyd_mainrecord M_Qskyd_mainrecord;

        /// <summary>
        /// jzzz,gzzz用到的变量
        /// </summary>
        /// <param name="id_0"></param>
        /// <param name="yddj_0"></param>
        /// <param name="load_type_0"></param>
        /// //sk_tt,Zz_Type,yydh,czy,czy_bc,czsj,syzd,xxzs
        string lsbh_old = "";
        string jzbh_old = "";
        string lsbh_new = "";
        string sk_tt = "";//sk,tt
        string Zz_Type = "";//当击确定的时候确定 是 向散转  还是团转



        public Q_sk_tt_app(string id_0, string yddj_0, string load_type_0)
        {
            InitializeComponent();
            yddj = yddj_0;
            id = id_0;//
            load_type = load_type_0;
            refresh_sk("");
            refresh_tt();
        }

        public void refresh_sk(string sql_s)
        {
            select_s = "select * from View_Qskzd";
            dg_sk.AutoGenerateColumns = false;
            //if (load_type == "jzzz" || load_type == "gzzz" || load_type == "skzz" || load_type == "ttzz")
            if (load_type == "skzz")
            {
                sql_s += "  and  id!='" + this.id + "'";
            }
            condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   yddj='" + yddj + "'" + sql_s + "   and  fjbh!=''   and main_sec='main'   order by fjbh";
            DS_Qsk = B_Common.GetList(select_s, condition);
            bS_sk.DataSource = DS_Qsk.Tables[0].DefaultView;
            dg_count_sk = DS_Qsk.Tables[0].Rows.Count;
        }
        public void refresh_tt()
        {
            select_s = "select * from Qttyd_mainrecord";
            dg_tt.AutoGenerateColumns = false;
            //if (load_type == "jzzz" || load_type == "gzzz" || load_type == "skzz" || load_type == "ttzz")
            if (load_type == "ttzz")
            {
                condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   yddj='" + common_file.common_yddj.yddj_dj + "'  and  id!='" + id + "'" + "    order by id ";
            }
            else
                if (load_type != "bt")
                {
                    condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   yddj='" + yddj + "'order by id ";
                }
            if (load_type == "bt")
            {
                condition = "id>=0 and  yydh='" + common_file.common_app.yydh + "' and   yddj='" + yddj + "'  and  id!='" + id + "'" + "   order by id ";
            }

            DS_Qtt = B_Common.GetList(select_s, condition);
            bS_tt.DataSource = DS_Qtt.Tables[0].DefaultView;
            dg_count_tt = DS_Qsk.Tables[0].Rows.Count;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_research_Click(object sender, EventArgs e)
        {
            if (tB_research.Visible == false)
            {
                tB_research.Visible = true;
                tB_research.Focus();
                b_exit.Left = 368;
                b_confirm.Left = 256;
                b_research.Left = 146;
            }
            else
            {
                tB_research.Visible = false;
                b_exit.Left = 319;
                b_confirm.Left = 181;
                b_research.Left = 45;
            }
        }

        private void tB_research_TextChanged(object sender, EventArgs e)
        {
            string sql_s_0 = " and (krxm like '%" + tB_research.Text.Trim() + "%' or fjbh like '%" + tB_research.Text.Trim() + "%')";
            refresh_sk(sql_s_0);
        }

        void click_sk()
        {
            common_file.common_app.get_czsj();

            switch (load_type)
            {
                case "gzzz"://挂帐--散客
                    Zz_Type = Szwgl.common_zw.zwzz_gz_sk;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;
                case "jzzz"://记帐--散客
                    Zz_Type = Szwgl.common_zw.zwzz_jz_sk;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;

                case "skzz"://在住--散客
                    Zz_Type = Szwgl.common_zw.zwzz_sk_sk;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;
                case "ttzz"://在住--散客
                    Zz_Type = Szwgl.common_zw.zwzz_tt_sk;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;
                case "sfz_zl_fj"://临时身份证信息转入当前客人
                    sfz_zl_fj(id);
                    break;
            }

            Cursor.Current = Cursors.Default;
        }
        private void b_confirm_Click(object sender, EventArgs e)
        {
            click_sk();

        }


        //转帐处理(挂、记、在住---转帐）
        private void jzOrgzOrZaiZToZz()
        {
            common_file.common_app.get_czsj();
            string url = common_file.common_app.service_url;
            //ZZ  指当前（在住帐务）的转帐
            if (load_type == "jzzz" || load_type == "gzzz" || load_type == "skzz" || load_type == "ttzz")
            {
                url += "Szwgl/Szwgl_app.asmx";
                //lsbh_old,lsbh_new,sk_tt,Zz_Type,yydh,czy,czy_bc,czsj,syzd,xxzs
                string[] args = new string[13];
                args[0] = lsbh_old;
                args[1] = jzbh_old;
                args[2] = lsbh_new;
                args[3] = sk_tt;
                args[4] = Zz_Type;
                args[5] = common_file.common_app.yydh;
                args[6] = common_file.common_app.czy;
                args[7] = common_file.common_app.czy_bc;
                args[8] = DateTime.Now.ToString();
                args[9] = common_file.common_app.syzd;
                args[10] = common_file.common_app.xxzs;
                args[11] = common_file.common_app.qymc;
                args[12] = common_file.common_app.czy_GUID;

                Hotel_app.Server.Szwgl.Szw_jzOrgzOrZaiZToZz Szw_jzOrgzOrZaiZToZz_services = new Hotel_app.Server.Szwgl.Szw_jzOrgzOrZaiZToZz();
                string result = Szw_jzOrgzOrZaiZToZz_services.GetjzOrgzOrZaizToZzResult(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_jzOrgzOrZaiZToZz", args);
                if (result!=null&&result== common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                }
                Cursor.Current = Cursors.Default;
            }
        }
        private void GetZzInfo()
        {
            common_file.common_app.get_czsj();

            // 记、挂--转帐
            if (Zz_Type == Szwgl.common_zw.zwzz_gz_tt || Zz_Type == Szwgl.common_zw.zwzz_jz_tt || Zz_Type == Szwgl.common_zw.zwzz_gz_sk || Zz_Type == Szwgl.common_zw.zwzz_jz_sk)
            {
                //帐务向团体转
                if (Zz_Type == Szwgl.common_zw.zwzz_gz_tt || Zz_Type == Szwgl.common_zw.zwzz_jz_tt)//向团体转
                {
                    if (dg_tt.Rows.Count > 0)
                    {
                        if (dg_tt.CurrentRow != null)
                        {
                            int i = dg_tt.CurrentRow.Index;
                            DataRowView dgr = dg_tt.CurrentRow.DataBoundItem as DataRowView;
                            i = DS_Qtt.Tables[0].Rows.IndexOf(dgr.Row);


                            if (i > -1 && i < dg_tt.Rows.Count)//当前行为内容行
                            {
                                int id_temp = Convert.ToInt32(DS_Qtt.Tables[0].Rows[i]["id"].ToString());
                                M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("Id=" + id_temp)[0];
                                lsbh_new = M_Qttyd_mainrecord.lsbh;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                //帐务向散客转
                if (Zz_Type == Szwgl.common_zw.zwzz_gz_sk || Zz_Type == Szwgl.common_zw.zwzz_jz_sk)//向散客转
                {
                    if (dg_sk.Rows.Count > 0)
                    {
                        if (dg_sk.CurrentRow != null)
                        {
                            int i = dg_sk.CurrentRow.Index;
                            DataRowView dgr = dg_sk.CurrentRow.DataBoundItem as DataRowView;
                            if (dgr != null)
                            {
                                i = DS_Qsk.Tables[0].Rows.IndexOf(dgr.Row);



                                if (i > -1 && i < dg_sk.Rows.Count)//当前行为内容行
                                {
                                    int id_temp = Convert.ToInt32(DS_Qsk.Tables[0].Rows[i]["id"].ToString());
                                    //DS_Qsk.Tables[0].Rows[i]["id"].ToString();
                                    M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id=" + id_temp)[0];
                                    lsbh_new = M_Qskyd_mainrecord.lsbh;
                                }
                            }
                        }
                        else
                        {
                            return;
                        }

                    }
                    else
                    {
                        return;
                    }
                }

                //注意这里传的是记挂的结帐主单ID
                M_Sjzzd = B_Sjzzd.GetModel(int.Parse(id));
                lsbh_old = M_Sjzzd.lsbh;
                jzbh_old = M_Sjzzd.jzbh;
                sk_tt = M_Sjzzd.sktt;

            }

            //在住---向团体转
            if (Zz_Type == Szwgl.common_zw.zwzz_sk_tt || Zz_Type == Szwgl.common_zw.zwzz_tt_tt || Zz_Type == Szwgl.common_zw.zwzz_tt_sk || Zz_Type == Szwgl.common_zw.zwzz_sk_sk)
            {

                if (Zz_Type == Szwgl.common_zw.zwzz_sk_tt || Zz_Type == Szwgl.common_zw.zwzz_tt_tt)
                {
                    if (dg_tt.Rows.Count > 0)
                    {
                        if (dg_tt.CurrentRow != null)
                        {
                            int i = dg_tt.CurrentRow.Index;
                            DataRowView dgr = dg_tt.CurrentRow.DataBoundItem as DataRowView;
                            if (dgr != null)
                            {
                                i = DS_Qtt.Tables[0].Rows.IndexOf(dgr.Row);


                                if (i > -1 && i < dg_tt.Rows.Count)//当前行为内容行
                                {
                                    int id_temp = Convert.ToInt32(DS_Qtt.Tables[0].Rows[i]["id"].ToString());
                                    M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("Id=" + id_temp)[0];
                                    lsbh_new = M_Qttyd_mainrecord.lsbh;
                                }
                            }

                            if (Zz_Type == Szwgl.common_zw.zwzz_sk_tt)
                            {
                                M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(id));
                                lsbh_old = M_Qskyd_mainrecord.lsbh;
                                sk_tt = M_Qskyd_mainrecord.sktt;
                            }
                            if (Zz_Type == Szwgl.common_zw.zwzz_tt_tt)
                            {
                                M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(id));
                                lsbh_old = M_Qttyd_mainrecord.lsbh;
                                sk_tt = M_Qttyd_mainrecord.sktt;
                            }
                        }
                        else
                        { return; }
                    }
                    else
                    {
                        return;
                    }
                }

                //在住---向散客转
                if (Zz_Type == Szwgl.common_zw.zwzz_tt_sk || Zz_Type == Szwgl.common_zw.zwzz_sk_sk)
                {
                    if (dg_sk.Rows.Count > 0)
                    {
                        if (dg_sk.CurrentRow != null)
                        {
                            int i = dg_sk.CurrentRow.Index;
                            DataRowView dgr = dg_sk.CurrentRow.DataBoundItem as DataRowView;
                            if (dgr != null)
                            {
                                i = DS_Qsk.Tables[0].Rows.IndexOf(dgr.Row);

                                if (i > -1 && i < dg_sk.Rows.Count)//当前行为内容行
                                {
                                    int id_temp = Convert.ToInt32(DS_Qsk.Tables[0].Rows[i]["id"].ToString());
                                    //DS_Qsk.Tables[0].Rows[i]["id"].ToString();
                                    M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id=" + id_temp)[0];
                                    lsbh_new = M_Qskyd_mainrecord.lsbh;
                                }
                            }
                            if (Zz_Type == Szwgl.common_zw.zwzz_sk_sk)
                            {
                                {
                                    M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(int.Parse(id));
                                    lsbh_old = M_Qskyd_mainrecord.lsbh;
                                    sk_tt = M_Qskyd_mainrecord.sktt;
                                }
                            }
                            if (Zz_Type == Szwgl.common_zw.zwzz_tt_sk)
                            {
                                M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(id));
                                lsbh_old = M_Qttyd_mainrecord.lsbh;
                                sk_tt = M_Qttyd_mainrecord.sktt;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }


                }
            }
            Cursor.Current = Cursors.Default;
        }


        private void dg_sk_DoubleClick(object sender, EventArgs e)
        {
            click_sk();
        }
        void click_tt()
        {
            common_file.common_app.get_czsj();

            switch (load_type)
            {
                case "lt":
                    DataSet DS_temp = B_Common.GetList("select * from View_Qskzd", "id='" + id + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        int j_000 = 0;
                        if (dg_tt.CurrentRow != null)
                        {
                            DataRowView dgr = dg_tt.CurrentRow.DataBoundItem as DataRowView;
                            if (dgr != null)
                            {
                                j_000 = DS_Qtt.Tables[0].Rows.IndexOf(dgr.Row);

                                if (dg_count_tt > 0 && dg_tt.CurrentRow.Index < dg_count_tt && DS_Qtt != null && DS_Qtt.Tables[0].Rows[j_000]["id"].ToString() != "")
                                {
                                    common_file.common_app.get_czsj();
                                    string url = common_file.common_app.service_url;
                                    url += "Qyddj/Qyddj_app.asmx";
                                    object[] args = new object[12];
                                    args[0] = common_file.common_app.yydh;
                                    args[1] = common_file.common_app.qymc;
                                    args[2] = "sk";
                                    args[3] = DS_temp.Tables[0].Rows[0]["lsbh"].ToString();
                                    args[4] = DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                                    args[5] = DS_Qtt.Tables[0].Rows[j_000]["ddbh"].ToString();
                                    args[6] = "lt";
                                    args[7] = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                                    args[8] = DS_Qtt.Tables[0].Rows[j_000]["sktt"].ToString();
                                    args[9] = common_file.common_app.czy;
                                    args[10] = DateTime.Now;
                                    args[11] = common_file.common_app.xxzs;

                                    Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1();
                                    string result = Qyddj_add_edit_delete_1_services.sktt_hz(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(),DateTime.Parse(args[10].ToString()), args[11].ToString());
                                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "sktt_hz", args);
                                    if (result== common_file.common_app.get_suc)
                                    {
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                                        this.Close();
                                    }
                                    else
                                    {
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                                    }
                                }
                            }
                        }
                    }
                    DS_temp.Dispose();
                    break;

                case "bt":


                    int k_000 = 0;
                    if (dg_tt.CurrentRow != null)
                    {
                        DataRowView dgr = dg_tt.CurrentRow.DataBoundItem as DataRowView;
                        if (dgr != null)
                        {
                            k_000 = DS_Qtt.Tables[0].Rows.IndexOf(dgr.Row);

                            if (dg_count_tt > 0 && dg_tt.CurrentRow.Index < dg_count_tt && DS_Qtt != null && DS_Qtt.Tables[0].Rows[k_000]["id"].ToString() != "")
                            {
                                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要并入当前" + DS_Qtt.Tables[0].Rows[k_000]["krxm"].ToString() + "这个" + DS_Qtt.Tables[0].Rows[k_000]["sktt"].ToString()+"？请注意，并入将不能撤回！") == true)
                                {

                                    DataSet DS_temp_1 = B_Common.GetList("select lsbh,ddbh from Qttyd_mainrecord","id='"+id+"'");
                                    if (DS_temp_1 != null && DS_temp_1.Tables[0].Rows.Count > 0)
                                    {

                                        common_file.common_app.get_czsj();
                                        string url = common_file.common_app.service_url;
                                        url += "Qyddj/Qyddj_app.asmx";
                                        //yydh,  qymc,  czy,  czsj,  lsbh_old,  ddbh_old,  lsbh_add,  ddbh_add,  xxzs
                                        object[] args = new object[9];
                                        args[0] = common_file.common_app.yydh;
                                        args[1] = common_file.common_app.qymc;
                                        args[2] = common_file.common_app.czy;
                                        args[3] = DateTime.Now;
                                        args[4] = DS_temp_1.Tables[0].Rows[0]["lsbh"].ToString();
                                        args[5] = DS_temp_1.Tables[0].Rows[0]["ddbh"].ToString();
                                        args[6] = DS_Qtt.Tables[0].Rows[k_000]["lsbh"].ToString();
                                        args[7] = DS_Qtt.Tables[0].Rows[k_000]["ddbh"].ToString();
                                        args[8] = common_file.common_app.xxzs;

                                        Hotel_app.Server.Qyddj.Q_tt_unit Q_tt_unit_services = new Hotel_app.Server.Qyddj.Q_tt_unit();
                                        string result = Q_tt_unit_services.tt_unit(args[0].ToString(), args[1].ToString(), args[2].ToString(), DateTime.Parse(args[3].ToString()), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString());
                                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "tt_unit", args);
                                        if (result.ToString() == common_file.common_app.get_suc)
                                        {
                                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                        else
                                        {
                                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                                        }

                                    }
                                    DS_temp_1.Clear();
                                    DS_temp_1.Dispose();


                                }

                            }
                        }
                    }

                    break;

                case "gzzz"://挂帐--团体
                    Zz_Type = Szwgl.common_zw.zwzz_gz_tt;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;
                case "jzzz"://记帐--团体
                    Zz_Type = Szwgl.common_zw.zwzz_jz_tt;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;
                case "skzz":
                    Zz_Type = Szwgl.common_zw.zwzz_sk_tt;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;
                case "ttzz":
                    Zz_Type = Szwgl.common_zw.zwzz_tt_tt;
                    GetZzInfo();
                    jzOrgzOrZaiZToZz();
                    break;
            }

            Cursor.Current = Cursors.Default;
        }





        private void b_confirm_0_Click(object sender, EventArgs e)
        {
            click_tt();
        }

        private void dg_tt_DoubleClick(object sender, EventArgs e)
        {
            click_tt();
        }

        private void b_exit_0_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sfz_zl_fj(string id)
        {
            common_file.common_app.get_czsj();
            if (dg_sk.CurrentRow != null)
            {
                int j_0000 = 0;
                DataRowView dgr = dg_sk.CurrentRow.DataBoundItem as DataRowView;
                j_0000 = DS_Qsk.Tables[0].Rows.IndexOf(dgr.Row);

                DataSet DS_temp = B_Common.GetList("select * from Q_sfz_temp", "id='" + id + "' and shcl=0");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count>0&&dg_sk.CurrentRow != null && dg_count_sk > 0 && dg_sk.CurrentRow.Index < dg_count_sk && DS_Qsk != null && DS_Qsk.Tables[0].Rows[j_0000]["id"].ToString() != "")
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定是否要把客人 " + DS_temp.Tables[0].Rows[0]["krxm"].ToString() + " 转入房间 " + DS_Qsk.Tables[0].Rows[dg_sk.CurrentRow.Index]["fjbh"].ToString() + "？") == true)
                    {
                        common_file.common_app.get_czsj();
                        string add_edit = "";
                        string main_sec = "";

                        if (DS_Qsk.Tables[0].Rows[j_0000]["zjhm"].ToString() == "")
                        {
                            add_edit = common_file.common_app.get_edit;
                            main_sec = common_file.common_app.main_sec_main;
                        }
                        else
                        {
                            //string s_0=" fjbh='" + DS_Qsk.Tables[0].Rows[dg_sk.CurrentRow.Index]["fjbh"].ToString() + "' and zjhm='" + DS_temp.Tables[0].Rows[0]["zjhm"].ToString() + "'";
                            DataSet DS_temp_2 = B_Common.GetList("select * from Qskyd_mainrecord", "zjhm='" + DS_temp.Tables[0].Rows[0]["zjhm"].ToString() + "' and (lsbh =(select lsbh from Qskyd_fjrb where fjbh='" + DS_Qsk.Tables[0].Rows[j_0000]["fjbh"].ToString() + "' and lsbh ='" + DS_Qsk.Tables[0].Rows[j_0000]["lsbh"].ToString() + "'))");
                            if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "房间 " + DS_Qsk.Tables[0].Rows[dg_sk.CurrentRow.Index]["fjbh"].ToString() + " 已经存在同证件号码的客人了！");
                            }
                            else
                            {
                                add_edit = common_file.common_app.get_add;
                                main_sec = common_file.common_app.main_sec_sec;
                            }


                        }
                        if (add_edit != "")
                        {
                            string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
                            common_file.common_app.get_czsj();
                            string[] args = new string[56];
                            args[0] = DS_Qsk.Tables[0].Rows[j_0000]["id"].ToString();
                            args[1] = common_file.common_app.yydh;
                            args[2] = common_file.common_app.qymc;
                            args[3] = DS_Qsk.Tables[0].Rows[j_0000]["lsbh"].ToString();
                            args[4] = DS_Qsk.Tables[0].Rows[j_0000]["ddbh"].ToString();
                            args[5] = "";
                            args[6] = "";
                            args[7] = DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                            args[8] = DS_temp.Tables[0].Rows[0]["krxm"].ToString();
                            args[9] = common_file.common_app.krgj_zg;
                            args[10] = DS_temp.Tables[0].Rows[0]["krmz"].ToString();
                            args[11] = common_file.common_app.yxzj_sfz;
                            args[12] = DS_temp.Tables[0].Rows[0]["zjhm"].ToString();
                            args[13] = DS_temp.Tables[0].Rows[0]["krxb"].ToString();
                            args[14] = DS_temp.Tables[0].Rows[0]["krsr"].ToString();
                            args[15] = DS_Qsk.Tables[0].Rows[j_0000]["krdh"].ToString();
                            args[16] = DS_Qsk.Tables[0].Rows[j_0000]["krsj"].ToString();
                            args[17] = DS_Qsk.Tables[0].Rows[j_0000]["krEmail"].ToString();
                            args[18] = DS_temp.Tables[0].Rows[0]["krdz"].ToString();
                            args[19] = ""; //籍贯
                            args[20] = DS_Qsk.Tables[0].Rows[j_0000]["krdw"].ToString();
                            args[21] = "";//职业
                            args[22] = DS_Qsk.Tables[0].Rows[j_0000]["cxmd"].ToString();
                            args[23] = "";//签证类型
                            args[24] = "";//签证号码
                            args[25] = common_file.common_app.cssj;
                            args[26] = common_file.common_app.cssj;
                            args[27] = common_file.common_app.cssj;
                            args[28] = DS_Qsk.Tables[0].Rows[j_0000]["lzka"].ToString();
                            args[29] = DS_Qsk.Tables[0].Rows[j_0000]["krly"].ToString();
                            args[30] = DS_Qsk.Tables[0].Rows[j_0000]["xyh"].ToString();
                            args[31] = DS_Qsk.Tables[0].Rows[j_0000]["xydw"].ToString();
                            args[32] = DS_Qsk.Tables[0].Rows[j_0000]["xsy"].ToString();
                            args[33] = DS_Qsk.Tables[0].Rows[j_0000]["ddrx"].ToString();
                            args[34] = DS_Qsk.Tables[0].Rows[j_0000]["ddwz"].ToString();
                            args[35] = DS_Qsk.Tables[0].Rows[j_0000]["zyzt"].ToString();
                            args[36] = DS_Qsk.Tables[0].Rows[j_0000]["krrx"].ToString();
                            args[37] = DS_Qsk.Tables[0].Rows[j_0000]["kr_children"].ToString();
                            args[38] = DS_Qsk.Tables[0].Rows[j_0000]["ddsj"].ToString();
                            args[39] = DS_Qsk.Tables[0].Rows[j_0000]["lzts"].ToString();
                            args[40] = DS_Qsk.Tables[0].Rows[j_0000]["lksj"].ToString();
                            args[41] = DS_Qsk.Tables[0].Rows[j_0000]["qtyq"].ToString();
                            args[42] = common_file.common_app.czy;
                            args[43] = DateTime.Now.ToString();
                            args[44] = common_file.common_app.chinese_add;
                            args[45] = DS_Qsk.Tables[0].Rows[j_0000]["sktt"].ToString();
                            args[46] = DS_Qsk.Tables[0].Rows[j_0000]["yddj"].ToString();
                            args[47] = main_sec;
                            args[48] = "";
                            args[49] = common_file.common_app.syzd;
                            args[50] = DS_Qsk.Tables[0].Rows[j_0000]["vip_type"].ToString();
                            args[51] = DS_Qsk.Tables[0].Rows[j_0000]["tsyq"].ToString();
                            args[52] = add_edit;
                            args[53] = common_file.common_app.xxzs;
                            args[54] = DS_Qsk.Tables[0].Rows[j_0000]["ddly"].ToString();
                            args[55] = "";//会员卡号

                            Hotel_app.Server.Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();
                            string result = Qyddj_add_edit_delete_services.Qskdj_add_edit_delete(args[0].ToString(), 
                                                args[1].ToString(), 
                                                args[2].ToString(), 
                                                args[3].ToString(), 
                                                args[4].ToString(), 
                                                args[5].ToString(), 
                                                args[6].ToString(), 
                                                args[7].ToString(), 
                                                args[8].ToString(), 
                                                args[9].ToString(), 
                                                args[10].ToString(), 
                                                args[11].ToString(), 
                                                args[12].ToString(), 
                                                args[13].ToString(), 
                                                args[14].ToString(), 
                                                args[15].ToString(), 
                                                args[16].ToString(), 
                                                args[17].ToString(), 
                                                args[18].ToString(), 
                                                args[19].ToString(), 
                                                args[20].ToString(), 
                                                args[21].ToString(), 
                                                args[22].ToString(), 
                                                args[23].ToString(), 
                                                args[24].ToString(), 
                                                args[25].ToString(), 
                                                args[26].ToString(), 
                                                args[27].ToString(), 
                                                args[28].ToString(), 
                                                args[29].ToString(),
                                                args[30].ToString(), 
                                                args[31].ToString(), 
                                                args[32].ToString(), 
                                                args[33].ToString(), 
                                                args[34].ToString(), 
                                                args[35].ToString(), 
                                                args[36].ToString(), 
                                                args[37].ToString(), 
                                                args[38].ToString(), 
                                                args[39].ToString(), 
                                                args[40].ToString(), 
                                                args[41].ToString(), 
                                                args[42].ToString(), 
                                                args[43].ToString(), 
                                                args[44].ToString(), 
                                                args[45].ToString(), 
                                                args[46].ToString(), 
                                                args[47].ToString(),
                                                args[48].ToString(), 
                                                args[49].ToString(), 
                                                args[50].ToString(), 
                                                args[51].ToString(), 
                                                args[52].ToString(), 
                                                args[53].ToString(), 
                                                args[54].ToString(),
                                                args[55].ToString()
                                                );


                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskdj_add_edit_delete", args);
                            common_file.common_app.get_czsj();
                            if (result!=null&&result== common_file.common_app.get_suc)
                            {
                                B_Common.ExecuteSql("update Q_sfz_temp set shcl=1,fjbh='" + DS_Qsk.Tables[0].Rows[j_0000]["fjbh"].ToString() + "' where id='" + id + "'");
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "转入成功");
                                Close();
                            }
                            else
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "转入失败");
                            }
                        }
                    }

                }
                DS_temp.Dispose();
            }
        }

        private void dg_tt_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            click_tt();
        }

        private void dg_sk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            click_sk();
        }
    }
}