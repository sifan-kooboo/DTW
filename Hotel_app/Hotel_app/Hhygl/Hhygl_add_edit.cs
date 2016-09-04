using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Hotel_app.Hhygl
{
    public partial class Hhygl_add_edit : Form
    {
        public string add_edit = common_file.common_app.get_add;
        public string hykh = "";
        public string hymm = common_file.common_hy.hymm;//会员密码
        public string hyrx = "";
        private string Hhygl_id = "";
        private int Hhygl_id_01 = 0;
        Model.Hhygl M_Hhygl = new Model.Hhygl();
        BLL.Hhygl B_Hhygl = new BLL.Hhygl();
        Model.Hhyjf_df M_Hhyjf_df = new Model.Hhyjf_df();
        BLL.Hhyjf_df B_Hhyjf_df = new BLL.Hhyjf_df();
        BLL.Hhyjf_xfjl B_hyjf_xfjl = new BLL.Hhyjf_xfjl();//积分记录
        public int dg_count = 0;//记录初期加载行数
        public string p_hykh = "";//主卡
        BLL.Common B_Common = new Hotel_app.BLL.Common();
        public Hhygl_add_edit()
        {
            InitializeComponent();
        }
        /// <param name="Qskyd_id_0">主单ID</param>
        /// <param name="yddj_flage">预订查询||登记查询</param>
        /// <param name="add_edit_flage">历史||修改</param>
        public void Hhygl_1(string Hhygl_id_0, string add_edit_flage)
        {
            Hhygl_id = Hhygl_id_0;
            //同时修改窗体的状态值
            add_edit = add_edit_flage;//修改
            b_AddCard.Visible = true;//增加主卡按钮
            if (add_edit == common_file.common_app.get_edit)
            {
                M_Hhygl = B_Hhygl.GetModel(int.Parse(Hhygl_id));
                hykh = M_Hhygl.hykh;
                //如果主卡不为空，哪么就隐藏主卡按钮
                if (M_Hhygl.parent_hykh != null && M_Hhygl.parent_hykh != "")
                {
                    b_AddCard.Visible = false;
                }
                else
                {
                    b_AddCard.Visible = true;
                }
                BindHyjf_df();     //邦定积分兑换记录
                //BindHylsrz();     //会员入住记录
                BindHYxfjl();//积分记录
                load_input_infor();//修改时加载相关信息
                p_hykh = M_Hhygl.parent_hykh == null ? "" : M_Hhygl.parent_hykh;
                tB_hykh_bz.ReadOnly = true;
                cB_hyrx.Enabled = false;
            }
            else
            {
                this.cB_hyrx.Text = common_file.common_hy.hyrx_yk;//银卡
                tB_hykh_bz.Enabled = true;
                tB_hykh_bz.ReadOnly = false;
            }
            FormText();
        }

        //加载信息时根据add_edit来设置窗体的Text
        public void FormText()
        {
            if (add_edit == common_file.common_app.get_edit)
            {
                common_file.common_hy.Hhygl_add_edit_new.Text = "会员修改";
                button1.Visible = false;
                tB_xsy.ReadOnly = true;
            }
            if (add_edit == common_file.common_app.get_add)
            {
                common_file.common_hy.Hhygl_add_edit_new.Text = "会员新增";
                button1.Visible = true;
                tB_xsy.ReadOnly = false;
            }
        }
        void BindHyjf_df()  //积分兑换记录
        {
            dg_dfjf.AutoGenerateColumns = false;
            DataSet DS_Hhyjf_df = B_Hhyjf_df.GetList("id>=0 and hykh='" + hykh + "'   order by id desc");
            bindingSource_jfdf.DataSource = DS_Hhyjf_df.Tables[0];
            dg_count = DS_Hhyjf_df.Tables[0].Rows.Count;
        }
        void BindHylsrz()//会员入住记录
        {
            string select_s = "select * from VIEW_Q_skyd_lskr";
            dg_lsrz.AutoGenerateColumns = false;
            string condition = "id>=0 and hykh='" + hykh + "'  order by czsj desc";
            DataSet DS_lskr = B_Common.GetList(select_s, condition);
            BS_lsrz.DataSource = DS_lskr.Tables[0];
            dg_count = DS_lskr.Tables[0].Rows.Count;
        }
        void BindHYxfjl()//积分记录
        {
            dg_xfjl.AutoGenerateColumns = false;
            DataSet DS_Hhyjf_xfjl = B_hyjf_xfjl.GetList("id>=0  and hykh='" + hykh + "'   order by id desc");
            BS_Jfxfjl.DataSource = DS_Hhyjf_xfjl.Tables[0];
            dg_count = DS_Hhyjf_xfjl.Tables[0].Rows.Count;
        }

        private void display_new_commonform_1(string judge_type_0, int left_0, int top_0, TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = left_0;
            X_common_one_new.Top = top_0;
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_yxzj_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xyxzj", tB_yxzj.Left, tB_yxzj.Top + 50, tB_yxzj);
        }

        private void B_gj_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xkrgj_select Xkrgj_select_new = new Hotel_app.Xxtsz.Xkrgj_select();
            Xkrgj_select_new.Left = tB_krgj.Left - 150;
            Xkrgj_select_new.Top = tB_krgj.Top + 50;
            if (Xkrgj_select_new.ShowDialog() == DialogResult.OK)
            {
                tB_krgj.Text = Xkrgj_select_new.get_krgj;
            }
            Xkrgj_select_new.Dispose();
            tB_krgj.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_krmz_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xkrmz", tB_krmz.Left - 100, tB_krmz.Top + 50, tB_krmz);
        }
        private void b_qzrx_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xqzrx", tB_qzrx.Left - 50, tB_qzrx.Top + 50, tB_qzrx);
        }
        private void b_Save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_hygl__xg", common_file.common_app.user_type) == false)
            { return; }
            if (add_edit == common_file.common_app.get_add || add_edit == common_file.common_app.get_edit)//新增
            {
                if (add_edit == common_file.common_app.get_edit && !tB_krsj.Text.Trim().Equals(""))
                {
                    //修改状态时，如果检测到不同，则提醒是否要更改
                    string  hykh_bz_temp=tB_hykh_bz.Text.Trim();
                    string krxm=tB_krxm.Text.Trim();
                    if (tB_krsj.Text.Trim() != tB_hykh_bz.Text.Trim())
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "当前客人手机号码与会员卡号不同，是否要把手机号码做为会员卡号？") == true)
                        {
                            tB_hykh_bz.Text = tB_krsj.Text;
                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "更换卡号", "卡号由:" + hykh_bz_temp + "更改为:" + tB_krsj.Text.Trim(), krxm.Replace("'", "-"), DateTime.Now);
                        }
                    }
                }

                if (get_judge_void_local() == true)//判断输入框是否为空
                {
                    common_file.common_app.get_czsj();
                    int judge_save = 3;//3保存，其余不保存
                    if (add_edit == common_file.common_app.get_add)
                    {
                        judge_save = common_file.common_app.get_judge_repeat("Hhygl", "hykh_bz", "会员卡号已经存在了", tB_hykh_bz.Text, add_edit, Hhygl_id);
                    }
                    if (judge_save == 3)
                    {
                        if (add_edit == common_file.common_app.get_edit)
                        {
                            Hhygl_id_01 = int.Parse(Hhygl_id);
                        }
                        int judge_save_01 = common_file.common_hy.RegisterCheck(tB_hykh_bz.Text, tB_zjhm.Text, tB_krsj.Text, Hhygl_id_01);
                        if (judge_save_01 > 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "手机号或证件号码已经存在了");
                        }
                        else
                        {
                            Save_hy();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
        private bool get_judge_void_local()
        {
            common_file.common_app.get_czsj();
            bool bl_temp = false;
            if (common_file.common_app.get_judge_void(tB_hykh_bz, "Hy_hykh_bz", "对不起，会员卡号不能为空！") == true)
                if (common_file.common_app.get_judge_void(tB_krsj, "Hy_krsj", "对不起，手机号不能为空！") == true)
                    if (common_file.common_app.get_judge_void(tB_krxm, "Hy_krxm", "对不起，会员姓名不能为空！") == true)
                        if (common_file.common_app.get_judge_void(tB_krgj, "Q_krgj", "对不起，国家地区不能为空！") == true)
                            if (common_file.common_app.get_judge_void(tB_yxzj, "Q_yxzj", "对不起，证件不能为空！") == true)
                                if (common_file.common_app.get_judge_void(tB_zjhm, "Hy_zjhm", "对不起，证件号码不能为空！") == true)
                                    if (common_file.common_app.get_judge_void(tB_krmz, "Q_krmz", "对不起，民族不能为空！") == true)
                                        if (common_file.common_app.get_judge_void(tB_krdh, "Q_krdh", "对不起，电话不能为空！") == true)
                                            if (common_file.common_app.get_judge_void(tB_krdz, "Hy_krdz", "对不起，地址为空！") == true)

                                                bl_temp = true;
            return bl_temp;
        }
        //加载输入框信息
        public void load_input_infor()
        {
            if (M_Hhygl != null)
            {
                #region 主要信息
                tB_hykh_bz.Text = M_Hhygl.hykh_bz;
                tB_krxm.Text = M_Hhygl.krxm;
                tB_yxzj.Text = M_Hhygl.yxzj;
                tB_krgj.Text = M_Hhygl.krgj;
                tB_zjhm.Text = M_Hhygl.zjhm;
                tB_krmz.Text = M_Hhygl.krmz;
                cB_krxb.Text = M_Hhygl.krxb;
                dT_krsr.Text = M_Hhygl.krsr.ToString();
                tB_krdh.Text = M_Hhygl.krdh;
                tB_krsj.Text = M_Hhygl.krsj;
                tB_krEmail.Text = M_Hhygl.krEmail;
                tB_krdz.Text = M_Hhygl.krdz;
                cB_hyrx.Text = M_Hhygl.hyrx;
                tB_hykh.Text = M_Hhygl.hykh;
                tB_xsy.Text = M_Hhygl.xsy;
                //读取主卡号
                if (M_Hhygl.parent_hykh != "" && M_Hhygl.parent_hykh != null)
                {
                    this.tB_parent_hykh.Text = M_Hhygl.parent_hykh;
                }
                else
                {
                    this.tB_parent_hykh.Text = "当前卡号为主卡";
                }
                pb_photo.ImageLocation = Application.StartupPath + "\\imgsfz\\noID.bmp";
                if (!tB_zjhm.Text.Trim().Equals(""))
                {
                    if (File.Exists(Application.StartupPath + "\\imgsfz\\" + tB_zjhm.Text.Trim() + ".bmp"))
                    {
                        pb_photo.ImageLocation = Application.StartupPath + "\\imgsfz\\" + tB_zjhm.Text.Trim() + ".bmp";
                    }
                }

                #endregion
                #region 附加信息
                tB_krdw.Text = M_Hhygl.krdw;
                tB_krzy.Text = M_Hhygl.krzy;
                tB_qzrx.Text = M_Hhygl.qzrx;
                tB_qzhm.Text = M_Hhygl.qzhm;
                dT_zjyxq.Text = M_Hhygl.zjyxq.ToString();
                dT_tlyxq.Text = M_Hhygl.tlyxq.ToString();
                dT_tjrq.Text = M_Hhygl.tjrq.ToString();
                tB_lzka.Text = M_Hhygl.lzka;
                #endregion
                #region 其它信息
                tB_hyjf.Text = M_Hhygl.hyjf.ToString();
                tB_bz.Text = M_Hhygl.bz;
                #endregion
            }
        }
        //保存后清空主要信息和附加信息
        public void clear_main_infor()
        {
            #region 主要信息
            pb_photo.ImageLocation = Application.StartupPath + "\\imgsfz\\noID.bmp";
            tB_hykh_bz.Text = "";
            tB_krxm.Text = "";
            tB_yxzj.Text = "身份证";
            tB_krgj.Text = "中国";
            tB_zjhm.Text = "";
            tB_krmz.Text = "汉族";
            cB_krxb.Text = "男";
            dT_krsr.Text = common_file.common_app.cssj;
            tB_krdh.Text = "";
            tB_krsj.Text = "";
            tB_krEmail.Text = "";
            tB_krdz.Text = "";
            tB_hyjf.Text = "0";
            tB_bz.Text = "";
            tB_hykh.Text = "";
            p_hykh = "";
            tB_xsy.Text = "";
            this.tB_parent_hykh.Text = "当前卡号为主卡";


            #endregion

            #region 附加信息

            tB_krdw.Text = "";
            tB_krzy.Text = "";

            tB_qzrx.Text = "";
            tB_qzhm.Text = "";
            dT_zjyxq.Text = "";
            dT_tlyxq.Text = "";
            dT_tjrq.Text = "";
            tB_lzka.Text = "";
            #endregion

        }
        private void Save_hy()
        {
            common_file.common_app.get_czsj();
            string stryydh = common_file.common_app.yydh;
            string strqymc = common_file.common_app.qymc;
            string url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
            //状态为空的时候(为新增记录),生成临时编号
            if (add_edit == common_file.common_app.get_add && tB_hykh_bz.Text.Trim() != "")
            {
                hykh = common_file.common_ddbh.ddbh("hy", "hydate", "hycounter", 6);
            }
            if (add_edit == common_file.common_app.get_edit && tB_hykh_bz.Text.Trim() != "")
            {
                hykh = M_Hhygl.hykh;
                hymm = M_Hhygl.hymm;//读取会员密码
                stryydh = M_Hhygl.yydh;
                strqymc = M_Hhygl.qymc;
            }
            string[] args = new string[35];
            args[0] = Hhygl_id.ToString();
            args[1] = stryydh;
            args[2] = strqymc;
            args[3] = hykh;
            args[4] = cB_hyrx.Text.Trim().Replace("'", "-");
            args[5] = tB_hykh_bz.Text.Trim().Replace("'", "-");
            args[6] = tB_krxm.Text.Trim().Replace("'", "-");
            args[7] = tB_krgj.Text.Trim().Replace("'", "-");
            args[8] = tB_krmz.Text.Trim().Replace("'", "-");
            args[9] = tB_yxzj.Text.Trim().Replace("'", "-");
            args[10] = tB_zjhm.Text.Trim().Replace("'", "-");
            args[11] = dT_krsr.Text.Trim().Replace("'", "-");
            args[12] = cB_krxb.Text.Trim().Replace("'", "-");
            args[13] = tB_krdh.Text.Trim().Replace("'", "-");
            args[14] = tB_krsj.Text.Trim().Replace("'", "-");
            args[15] = tB_krEmail.Text.Trim().Replace("'", "-");
            args[16] = tB_krdz.Text.Trim().Replace("'", "-");
            args[17] = tB_krzy.Text.Trim().Replace("'", "-");
            args[18] = tB_krdw.Text.Trim().Replace("'", "-");
            args[19] = tB_qzrx.Text.Trim().Replace("'", "-");
            args[20] = tB_qzhm.Text.Trim().Replace("'", "-");
            args[21] = dT_zjyxq.Text.Trim().Replace("'", "-");
            args[22] = dT_tlyxq.Text.Trim().Replace("'", "-");
            args[23] = dT_tjrq.Text.Trim().Replace("'", "-");
            args[24] = tB_lzka.Text.Trim().Replace("'", "-");
            args[25] = tB_bz.Text.Trim().Replace("'", "-");
            args[26] = tB_hyjf.Text.Trim().Replace("'", "-");
            if (add_edit == common_file.common_app.get_add)
            {
                args[27] = "false";
                args[28] = common_file.common_app.cssj;
            }
            else
            {
                args[27] = "true";
                args[28] = DateTime.Now.ToString();//DateTime.Now.ToShortDateString();
            }
            args[29] = p_hykh;//主卡
            args[30] = hymm;//密码
            args[31] = tB_xsy.Text.Trim().Replace("'", "-");
            args[32] = common_file.common_app.czy;
            args[33] = add_edit;
            args[34] = common_file.common_app.xxzs;

            string result = common_file_server.common_app.get_failure;
            Hotel_app.Server.Hhygl.Hhygl_add_edit Hhygl_add_edit_services = new Hotel_app.Server.Hhygl.Hhygl_add_edit();
            try
            {
                 result = Hhygl_add_edit_services.Hhygl_add_edit_delete_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(),
args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(),
args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(),
args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString(),
args[30].ToString(), args[31].ToString(), args[32].ToString(), args[33].ToString(), args[34].ToString());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Hhygl_add_edit_delete_app", args);
            if (result != null && result== common_file.common_app.get_suc)
            {
                if (add_edit == common_file.common_app.get_add)
                {
                    common_file.common_czjl.add_czjl(stryydh, strqymc, common_file.common_app.czy, "新增会员成功", "" + tB_hykh_bz.Text + "", "", DateTime.Now);
                    String s_ma_rem = "新增会员成功！";
                    DataSet ds_temp_09 = B_Common.GetList("select * from Qcounter", " 1=1  ");
                    if (ds_temp_09 != null && ds_temp_09.Tables[0].Rows.Count > 0)
                    {
                        if (bool.Parse(ds_temp_09.Tables[0].Rows[0]["Hhygl_qyqr"].ToString()) == true)
                        {
                            s_ma_rem = s_ma_rem + "目前会员还没验证，还不能正常使用，请及时发送验证码给客人进行验证！";
                        }
                    }
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, s_ma_rem);
                    add_edit = common_file.common_app.get_edit;//保存完后修改成修改状态
                    //并立即加载成当前的新增的会员信息
                    List<Model.Hhygl>   list_current =B_Hhygl.GetModelList("  id>=0  and   hykh_bz='" + tB_hykh_bz.Text.Trim() + "'");
                    if (list_current != null && list_current.Count > 0)
                    {
                        M_Hhygl = list_current[0];
                        Hhygl_id = M_Hhygl.id.ToString();
                    }
                    common_file.common_hy.Hhygl_browse_new.refresh_app();
                    return;
                    //clear_main_infor();//清空数据,如果要继续新增就要启用这个,注释掉状态的修改
                }
                if (add_edit == common_file.common_app.get_edit)
                {
                    common_file.common_czjl.add_czjl(stryydh, strqymc, common_file.common_app.czy, "修改会员成功", "" + tB_hykh_bz.Text + "", "", DateTime.Now);
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "修改成功.");
                    if (common_file.common_hy.Hhygl_browse_new != null)
                        common_file.common_hy.Hhygl_browse_new.refresh_app();
                }
                common_file.common_hy.Hhygl_browse_new.refresh_app();
                return;
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败.");
            }
        }
        private void SendHyDXtx(string phoneNo, string _hykh)
        {
            bool sendResult = false;
            
            Hotel_app.Server.Hhygl.Hhygl_verifyCode Hhygl_verifyCode_server = new Hotel_app.Server.Hhygl.Hhygl_verifyCode();
            if (Hhygl_verifyCode_server.Hhygl_SendMsm(phoneNo, "", common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_hyAction.hy_Action_HyNew, "", "", "", "", hykh, "", common_file.common_app.xxzs).Equals(common_file.common_app.get_suc))
            {
                sendResult = true;
            }
            if (sendResult)
            {
                common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "新增会员", "短信提醒", "新增会员,会员卡号为:" + hykh, DateTime.Now);
            }
        }
        private void b_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            common_file.common_hy.Hhygl_browse_new.move_record("last");
            common_file.common_hy.Hhygl_browse_new.open_record();
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            common_file.common_hy.Hhygl_browse_new.move_record("first");
            common_file.common_hy.Hhygl_browse_new.open_record();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            common_file.common_hy.Hhygl_browse_new.move_record("next");
            common_file.common_hy.Hhygl_browse_new.open_record();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            common_file.common_hy.Hhygl_browse_new.move_record("previous");
            common_file.common_hy.Hhygl_browse_new.open_record();
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            common_file.common_hy.Hhygl_browse_new.b_delete_hygl();
        }

        private void b_New_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_hygl_xz", common_file.common_app.user_type) == false)
            { return; }
            clear_main_infor();//清空数据
            Hhygl_1("", common_file.common_app.get_add);
        }
        private void b_hk_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_hygl__hk", common_file.common_app.user_type) == false)
            { return; }
            if (Hhygl_id != "" && hykh != "")
            {
                Hhygl.Hhygl_hyhk Hhygl_hyhk_new = new Hhygl_hyhk();
                Hhygl_hyhk_new.tB_hykh.Text = tB_hykh_bz.Text.Trim();
                Hhygl_hyhk_new.tB_krxm.Text = tB_krxm.Text.Trim();
                Hhygl_hyhk_new.hykh = hykh;
                Hhygl_hyhk_new.StartPosition = FormStartPosition.CenterScreen;
                Hhygl_hyhk_new.ShowDialog();
            }
        }
        private void b_sj_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_hygl__sj", common_file.common_app.user_type) == false)
            { return; }
            if (Hhygl_id != "" && hykh != "")
            {
                //int id = Convert.ToInt32(dg_hygl.Rows[i].Cells["id"].Value);
                Hhygl.Hhygl_hysj Hhygl_hysj_new = new Hhygl_hysj();
                Hhygl_hysj_new.StartPosition = FormStartPosition.CenterScreen;

                Hhygl_hysj_new.Hhygl_id = Hhygl_id;
                Hhygl_hysj_new.tB_hykh_bz.Text = tB_hykh_bz.Text.Trim();
                Hhygl_hysj_new.tB_krxm.Text = tB_krxm.Text.Trim();
                Hhygl_hysj_new.tB_hyrx.Text = cB_hyrx.Text.Trim();
                Hhygl_hysj_new.tB_hyjf.Text = tB_hyjf.Text.Trim();
                Hhygl_hysj_new.strhykh = hykh;
                Hhygl_hysj_new.ShowDialog();
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_jfdf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_hygl__jfdh", common_file.common_app.user_type) == false)
            { return; }
            if (Hhygl_id != "" && hykh != "")
            {
                Hhygl.Hhygl_jfdf Hhygl_jfdf_new = new Hhygl_jfdf();
                Hhygl_jfdf_new.StartPosition = FormStartPosition.CenterScreen;
                Hhygl_jfdf_new.hykh = hykh;
                Hhygl_jfdf_new.ShowDialog();
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_AddCard_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_hygl__zjzk", common_file.common_app.user_type) == false)
            { return; }
            if (Hhygl_id != "" && Hhygl_id != null)
            {
                clear_main_infor();//清空数据
                M_Hhygl = B_Hhygl.GetModel(int.Parse(Hhygl_id));
                if (M_Hhygl.parent_hykh != "" && M_Hhygl.parent_hykh != null)
                {
                    p_hykh = M_Hhygl.parent_hykh;
                }
                else
                {
                    p_hykh = M_Hhygl.hykh_bz;//读取主卡号

                }
                this.tB_parent_hykh.Text = p_hykh;
                add_edit = common_file.common_app.get_add;
                this.cB_hyrx.Text = common_file.common_hy.hyrx_yk;//银卡
                tB_hykh_bz.Enabled = true;
                FormText();
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择主卡。");
                common_file.common_hy.Form_hygl_browse_new();
            }
        }
        private void b_hy_Click(object sender, EventArgs e)
        {
            common_file.common_hy.Form_hygl_browse_new();
        }
        private void tB_zjhm_Leave(object sender, EventArgs e)
        {
            if (tB_yxzj.Text.Trim() == "身份证" && tB_zjhm.Text.Trim() != "")
            {
                string IDCardNo = "";
                string sr = ""; string xb = ""; string dz = ""; string jg = "";
                common_file.common_sfz.GetPersonInfo(tB_zjhm.Text.Trim(), out IDCardNo, out sr, out xb, out dz, out jg);
                tB_zjhm.Text = IDCardNo;
                if (dT_krsr.Value == DateTime.Parse("1800-01-01"))
                {
                    dT_krsr.Value = DateTime.Parse(sr);
                }
                if (cB_krxb.Text.Trim() != "男" && cB_krxb.Text.Trim() != "女")
                {
                    cB_krxb.Text = xb;
                }
                if (tB_krdz.Text.Trim() == "")
                {
                    tB_krdz.Text = dz;
                }
            }
        }

        private void b_sfz_Click(object sender, EventArgs e)
        {
            //Qyddj.Q_zjgl Q_zjgl_new = new Qyddj.Q_zjgl();
            //Q_zjgl_new.get_sfz_info_tb(ref tB_krxm, ref cB_krxb, ref tB_krmz, ref tB_krdz, ref tB_zjhm, ref dT_krsr, ref tB_krgj, ref tB_yxzj, true);
            common_file.CVRSDKReadCard cvrsdk = new Hotel_app.common_file.CVRSDKReadCard(ref tB_krxm, ref cB_krxb, ref tB_krmz, ref tB_krdz, ref tB_zjhm, ref dT_krsr, ref tB_krgj, ref tB_yxzj, ref pb_photo, true);

            if (tB_zjhm.Text.Trim() != "")
            {
                tB_zjhm.Focus();
            }
        }
        private void b_addjf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("b_addjf", common_file.common_app.user_type) == false)
            { return; }
            if (Hhygl_id != "" && hykh != "")
            {
                Hhygl.Hhygl_jf Hhygl_jf_new = new Hhygl_jf();
                Hhygl_jf_new.StartPosition = FormStartPosition.CenterScreen;
                Hhygl_jf_new.hykh = hykh;
                Hhygl_jf_new.tB_hykh.Text = tB_hykh_bz.Text;
                Hhygl_jf_new.tB_krxm.Text = tB_krxm.Text;
                Hhygl_jf_new.ShowDialog();
            }
            Cursor.Current = Cursors.Default;
        }

        private void B_xk_Click(object sender, EventArgs e)
        {
            if (tB_hykh_bz.Text.Trim() != "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要写把当前卡号写到卡里面，如果要请把会员卡放在读卡器上") == true)
                {
                    H_hygl_k H_hygl_k_NEW = new H_hygl_k();
                    H_hygl_k_NEW.write_hykh(tB_hykh_bz.Text.Trim());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("YH_user", tB_xsy.Left - 50, tB_xsy.Top + 50, tB_xsy);
        }
        private void b_hyqr_Click(object sender, EventArgs e)
        {
            //判断是否当前以经确认过
            if (add_edit.Equals(common_file.common_app.get_edit) && common_file.common_app.enable_checkMember && (M_Hhygl != null)&&(!M_Hhygl.shqr))
            {
                Hhygl_verify Frm_Hhygl_verify = new Hhygl_verify(tB_krsj.Text.Trim());
                Frm_Hhygl_verify.StartPosition = FormStartPosition.CenterScreen;
                if (Frm_Hhygl_verify.ShowDialog() == DialogResult.OK)
                {
                    //验证成功后，将会员确认改为true
                    if (M_Hhygl != null)
                    {
                        BLL.Common B_common_0 = new Hotel_app.BLL.Common();
                        int id_0 = M_Hhygl.id;
                        M_Hhygl.shqr = true;
                        if (B_common_0.ExecuteSql("update  Hhygl   set   shqr=1  where    id='" + id_0 + "'  ") > 0) ;
                        {
                            try
                            {
                             //Hotel_app.Hhygl_app.Hhygl_app services_Hhygl_app = new Hotel_app.Hhygl_app.Hhygl_app();
                             //services_Hhygl_app.Url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                Hotel_app.Server.Hhygl.Hhygl_verifyCode Hhygl_verifyCode_services = new Hotel_app.Server.Hhygl.Hhygl_verifyCode();
                                Hhygl_verifyCode_services.Hhygl_SendMsm(M_Hhygl.krsj, "", common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_hyAction.hy_Action_hyqr, "", "", "", "", M_Hhygl.hykh_bz, "", common_file.common_app.xxzs);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "恭喜，您的会员卡以经确认成功");
                            common_file.common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, "会员卡确认", M_Hhygl.hykh_bz, M_Hhygl.hykh_bz, DateTime.Now);
                            if (common_file.common_hy.Hhygl_browse_new != null)
                                common_file.common_hy.Hhygl_browse_new.refresh_app();
                            }
                            catch (Exception  ee)
                            {
                                MessageBox.Show(ee.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void tB_krsj_MouseLeave(object sender, EventArgs e)
        {
            //验证手机号是否正确
            if (add_edit.Equals(common_file.common_app.get_add)&&!tB_krsj.Text.Trim().Equals(""))
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tB_krsj.Text.Trim(), @"^[1]+[3,4,5,6,8]+\d{9}"))
                {
                    tB_hykh_bz.Text = tB_krsj.Text.Trim();
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "手机号输入错误,当前支持13*,14*,15*,16*,18*这些号码段的手机号,请检查当前的填写手机号及位数是否正确");
                }
            }
        }

        private void tabControl5_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;
            if (tc.SelectedIndex == 2)
            {
                common_file.common_app.get_czsj();
                BindHylsrz();
                Cursor.Current = Cursors.Default;
            }
        }

        private void dT_tlyxq_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }
    }
}