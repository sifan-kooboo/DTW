using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace Hotel_app.Szwgl
{
    public partial class Syjcz : Form
    {
        public Syjcz()
        {
            InitializeComponent();
            initalApp();
        }
        public string lsbh = "";//确定是哪个付款
        public string jzbh = "";//确定是哪个付款

        public string sk_tt = "";//确定是团体交押金还是散客交的押金
        public string yddj = "";
        public string czy = "";
        public string Syjcz_id = "";
        public string id_app = "";//帐务明细标识码
        public string judge_add_edit = common_file.common_app.get_add;
        BLL.Xfkfs B_Xfkfs = new Hotel_app.BLL.Xfkfs();

        public string openfrom = "";//由哪个打开的Szwcl或者Sjjzwll
        public string jjType = "";//记，挂帐交押金时会用到

        Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Model.Qskyd_mainrecord();
        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new BLL.Qskyd_mainrecord();
        Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        BLL.Qttyd_mainrecord B_M_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        Model.Qskyd_fjrb M_Qskyd_fjrb;
        BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();

        Model.Qskyd_fjrb_bak M_Qskyd_fjrb_bak;
        Model.Qskyd_mainrecord_bak M_Qskyd_mainrecord_bak;
        Model.Qttyd_mainrecord_bak M_Qttyd_mainrecord_bak;
        BLL.Qskyd_fjrb_bak B_Qskyd_fjrb_bak = new Hotel_app.BLL.Qskyd_fjrb_bak();
        BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();
        BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();
        public void initalApp()
        {
        }

        private void b_yxzj_Click(object sender, EventArgs e)
        {
            if (openfrom == "Sjjzwll")
            {
                common_file.common_app.display_new_commonform_1("Xfkfs", tB_fkfs, common_file.common_app.dj_ysq);
            }
            else
            {
                common_file.common_app.display_new_commonform_1("Xfkfs", tB_fkfs, "");
            }
            tB_fkzy.Text = tB_fkfs.Text;
        }
        private void display_new_commonform_1(string judge_type_0, int left_0, int top_0, TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = common_file.common_app.x();
            X_common_one_new.Top = common_file.common_app.y();
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (tB_fkfs.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择付款方式");
                return;
            }
            else if (tB_xfje.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写付款金额");
                return;
            }
                //既不是数字也不是decimal
            else if (((Maticsoft.Common.PageValidate.IsDecimal(tB_xfje.Text.Trim())) || (Maticsoft.Common.PageValidate.IsNumber(tB_xfje.Text.Trim()))) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的金额不是有效数字！");
                tB_xfje.Focus();
            }
            else
            {
                id_app = common_file.common_ddbh.ddbh("yjcz", "lsbhdate", "lsbhcounter", 6);

                //id, yydh, qymc, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, fkfs, xfje, sjxfje, czy_bc, syzd, add_edit_delete, xxzs
                string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                object[] args = new object[26];
                args[0] = Syjcz_id;
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] = id_app;
                if (openfrom == "Szwcl")//结记挂帐之前
                {
                    args[4] = "";//结帐前jzbh为空
                }
                else
                {
                    //string jzbh_temp = DbHelperSQL.GetSingle("SELECT Jzbh  from  Sjzzd where lsbh='" + lsbh + "'").ToString();
                    args[4] = jzbh;
                }
                args[5] = lsbh;
                if (openfrom == "Szwcl")
                {
                    if (sk_tt == "sk")
                    {
                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>=0 " + common_file.common_app.yydh_select + " and lsbh='" + lsbh + "'")[0];
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("id>=0 " + common_file.common_app.yydh_select + " and Lsbh='" + lsbh + "'")[0];
                        args[6] = M_Qskyd_mainrecord.krxm;
                        args[7] = M_Qskyd_fjrb.fjrb;
                        args[8] = M_Qskyd_fjrb.fjbh;
                        args[9] = M_Qskyd_mainrecord.sktt;
                    }
                    else if (sk_tt == "tt")
                    {
                        M_Qttyd_mainrecord = B_M_Qttyd_mainrecord.GetModelList("id>=0 " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'")[0];
                        args[6] = M_Qttyd_mainrecord.krxm;
                        args[7] = "";
                        args[8] = "";
                        args[9] = M_Qttyd_mainrecord.sktt;
                    }
                }
                else
                {
                    if (sk_tt == "sk")
                    {
                        List<Model.Qskyd_mainrecord_bak> list = new List<Hotel_app.Model.Qskyd_mainrecord_bak>();
                        list = B_Qskyd_mainrecord_bak.GetModelList("id>=0 " + common_file.common_app.yydh_select + " and lsbh='" + lsbh + "'");
                        if (list.Count > 0)
                        {
                            M_Qskyd_mainrecord_bak = list[0];
                            M_Qskyd_fjrb_bak = B_Qskyd_fjrb_bak.GetModelList("id>=0 " + common_file.common_app.yydh_select + " and Lsbh='" + lsbh + "'")[0];
                            args[6] = M_Qskyd_mainrecord_bak.krxm;
                            args[7] = M_Qskyd_fjrb_bak.fjrb;
                            if (M_Qskyd_fjrb_bak.fjbh != null)
                            { args[8] = M_Qskyd_fjrb_bak.fjbh; }
                            else
                            {
                                args[8] = "";
                            }
                            args[9] = M_Qskyd_mainrecord_bak.sktt;
                        }
                        else
                        {
                            args[6] = "";
                            args[7] = "";
                            args[8] = "";

                        }
                    }
                    else if (sk_tt == "tt")
                    {
                        List<Model.Qttyd_mainrecord_bak> list = new List<Hotel_app.Model.Qttyd_mainrecord_bak>();
                        list = B_Qttyd_mainrecord_bak.GetModelList("id>=0 " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'");
                        if (list.Count > 0)
                        {
                            M_Qttyd_mainrecord_bak = list[0];
                            args[6] = M_Qttyd_mainrecord_bak.krxm;
                        }
                        else
                        {
                            args[6] = "";
                        }
                        args[7] = "";
                        args[8] = "";
                        if (list.Count > 0)
                        {
                            args[9] = M_Qttyd_mainrecord_bak.sktt;
                        }
                        else
                        {
                            args[9] = common_file.common_sktt.sktt_tt;
                        }
                    }
                }
                args[10] = DateTime.Now.ToString("yyyy-MM-dd");
                args[11] = DateTime.Now.ToString();
                args[12] = common_file.common_app.czy;
                args[13] = common_file.common_app.fkdr;
                args[14] = common_file.common_app.dj_ysk;
                args[15] = tB_xfxm.Text.Trim().Replace("'", "-");
                args[16] = tB_bz.Text.Trim().Replace("'", "-");
                args[17] = tB_fkzy.Text.Trim().Replace("'", "-");
                args[18] = tB_fkfs.Text.Trim().Replace("'", "-");
                args[19] = tB_xfje.Text.Trim().Replace("'", "-");
                args[20] = tB_xfje.Text.Trim().Replace("'", "-");
                args[21] = common_file.common_app.czy_bc;
                args[22] = common_file.common_app.syzd;
                args[23] = judge_add_edit;
                args[24] = common_file.common_app.xxzs;
                args[25] = DateTime.Now.ToString();

                Hotel_app.Server.Szwgl.Syjcz Syjcz_new = new Hotel_app.Server.Szwgl.Syjcz();
                string result = Syjcz_new.Syjcz_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString());
               // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Syjcz_add_edit", args);
                if (result== common_file.common_app.get_suc)
                {
                    this.DialogResult = DialogResult.OK;
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Syjcz_Load(object sender, EventArgs e)
        {
            tB_xfxm.Text = common_file.common_app.dj_ysk;
        }
    }
}