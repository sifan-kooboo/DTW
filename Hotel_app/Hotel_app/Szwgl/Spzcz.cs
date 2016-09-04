using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Spzcz : Form
    {
        public Spzcz()
        {
            InitializeComponent();
        }
        public string lsbh = "";//临时编号
        public string sk_tt = "";//散客团体
        public decimal krzqk =0 ;//客人总欠款数
        public decimal krzfk = 0;//客人再付款
        public decimal krxsh = 0;//客人需收回
        public string id_app = "";
        public string jzzt = "";//挂帐批结的时候用到这个 
        public string jjType = "";//结帐，记帐转结帐，挂帐转结帐及   挂帐分结，记帐分结(现金）
        public string jzbh = "";
        public string openfrom = "";//Szw_Common指从这里调用,Sjjzwll指从这类这里打开的

        Model.Qskyd_fjrb M_Qskyd_fjrb;
        BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        Model.Qskyd_mainrecord M_Qskyd_mainrecord;
        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        BLL.Qttyd_mainrecord   B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();


        BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();
        BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();
        BLL.Qskyd_fjrb_bak B_Qskyd_fjrb_bak = new Hotel_app.BLL.Qskyd_fjrb_bak();

        Model.Qskyd_mainrecord_bak M_Qskyd_mainrecord_bak;
        Model.Qttyd_mainrecord_bak M_Qttyd_mainrecord_bak;
        Model.Qskyd_fjrb_bak M_Qskyd_fjrb_bak;
        BLL.Sjzmx B_sjzmx = new Hotel_app.BLL.Sjzmx();


        private void b_fkfs_Click(object sender, EventArgs e)
        {
            //display_new_commonform_1("Xfkfs", tB_fkfs.Left + 100, tB_fkfs.Top + 150, tB_fkfs);
            common_file.common_app.display_new_commonform_1("Xfkfs", tB_fkfs, common_file.common_app.dj_ysq);
        }

        //private void display_new_commonform_1(string judge_type_0, int left_0, int top_0, TextBox TB_ls)
        //{
        //    common_file.common_app.get_czsj();
        //    Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
        //    X_common_one_new.judge_type = judge_type_0;
        //    X_common_one_new.Left = common_file.common_app.x();
        //    X_common_one_new.Top = common_file.common_app.y();
        //    if (X_common_one_new.ShowDialog() == DialogResult.OK)
        //    {
        //        TB_ls.Text = X_common_one_new.get_value;
        //    }
        //    X_common_one_new.Dispose();
        //    TB_ls.Focus();
        //    Cursor.Current = Cursors.Default;
        //}

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (checkTbValue())
            {
                id_app = common_file.common_ddbh.ddbh("pzsk", "lsbhdate", "lsbhcounter", 6);//平帐收款

                string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                object[] args = new object[30];
                args[0] = "0";//Xxfxr_id
                args[1] = common_file.common_app.yydh;
                args[2] = common_file.common_app.qymc;
                args[3] = id_app;
                if ((openfrom == "Szw_Common") || (openfrom == "Sfjcz") || (openfrom == "Szw_pljz"))//部分算帐，记/挂分结都要生成新的jzbh
                {
                    args[4] = "";//初始jzbh为空
                }
                if ((openfrom == "Sjjzwll"))
                {
                    args[4] = jzbh; //B_sjzmx.GetModelList("id>=0  " + common_file.common_app.yydh_select + " and  lsbh='" + lsbh + "'")[0].jzbh;
                }
                if (openfrom == "Szw_pljz")
                { args[5] = common_file.common_ddbh.ddbh("gzpj", "lsbhdate", "lsbhcounter", 6);
                //args[5] = this.lsbh;
                args[6] = jzzt;
                args[7] = "";
                args[8] = "";
                args[9] = "";
                }
                else
                {
                    args[5] = this.lsbh;
                    args[6] = jzzt;
                    args[7] = "";
                    args[8] = "";
                    args[9] = "";
                }
                if ((openfrom == "Szw_Common") || (openfrom == "Sfjcz" && jjType == common_file.common_jzzt.czzt_bfsz))//部分算帐才会在主单里面找
                {
                    if (sk_tt == "sk")
                    {
                        M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + this.lsbh + "'")[0];
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + this.lsbh + "'")[0];
                        args[6] = M_Qskyd_mainrecord.krxm;
                        args[7] = M_Qskyd_fjrb.fjrb;
                        args[8] = M_Qskyd_fjrb.fjbh;
                        args[9] = M_Qskyd_mainrecord.sktt;

                    }
                    if (sk_tt == "tt")
                    {
                        M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + this.lsbh + "'")[0];
                        args[6] = M_Qttyd_mainrecord.krxm;
                        args[7] = "";
                        args[8] = "";
                        args[9] = M_Qttyd_mainrecord.sktt;
                    }
                }
                //是从帐务浏览打开或者分结操作中的记/挂帐分结
                else if (openfrom == "Sjjzwll" || (openfrom == "Sfjcz" && (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_jz)))//是从帐务浏览打开的
                {
                    if (sk_tt == "sk")
                    {
                        BLL.Common B_common = new Hotel_app.BLL.Common();
                        DataSet ds_00 = B_common.GetList("select * from Sjzzd ", "id>=0  " + common_file.common_app.yydh_select + " and jzbh='" + jzbh + "'");
                        if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                        {

                            //M_Qskyd_mainrecord_bak = B_Qskyd_mainrecord_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + this.lsbh + "'")[0];
                            //M_Qskyd_fjrb_bak = B_Qskyd_fjrb_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + this.lsbh + "'")[0];
                            args[6] = ds_00.Tables[0].Rows[0]["krxm"].ToString();
                            args[7] = "";
                            args[8] = ds_00.Tables[0].Rows[0]["fjbh"].ToString();
                            args[9] = ds_00.Tables[0].Rows[0]["sktt"].ToString();
                        }

                    }
                    if (sk_tt == "tt")
                    {

                        //M_Qttyd_mainrecord_bak = B_Qttyd_mainrecord_bak.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + this.lsbh + "'")[0];
                        BLL.Common B_common = new Hotel_app.BLL.Common();
                        DataSet ds_00 = B_common.GetList("select * from Sjzzd ", "id>=0  " + common_file.common_app.yydh_select + " and jzbh='" + jzbh + "'");
                        if (ds_00 != null)
                        {
                            args[6] = ds_00.Tables[0].Rows[0]["krxm"].ToString();
                            args[7] = "";
                            args[8] = "";
                            args[9] = ds_00.Tables[0].Rows[0]["sktt"].ToString();
                        }
                        else
                        {
                            args[6] = "";
                            args[7] = "";
                            args[8] = "";
                            args[9] = "";
                        }
                    }
                }
                //xfrq,xfsj,czy,xfdr,xfrb,xfxm,xfbz,xfzy
                args[10] = DateTime.Now.ToString("yyyy-MM-dd");
                args[11] = DateTime.Now.ToString();
                args[12] = common_file.common_app.czy;
                args[13] = common_file.common_app.fkdr;//这里是找出节点的付款大类
                args[14] = common_file.common_app.dj_pzsk;
                args[15] = common_file.common_app.dj_pzsk;
                args[16] = "平帐时,客户再付款为:" + tB_krzfk.Text.Trim() + ";客户最后收回:" + tB_krxsh.Text.Trim();//摘要描述平帐时的操作 
                args[17] = common_file.common_app.dj_pzsk;
                //xfje,yh,sjxfje,xfsl,czy_bc,czzt,czsj,syzd,add,xxzs 
                if (krzqk > 0)
                {
                    args[18] = "-" + krzqk.ToString().Trim().Replace("'", "-");
                    args[20] = "-" + krzqk.ToString().Trim().Replace("'", "-");
                }
                if (krzqk < 0)
                {
                    args[18] = Math.Abs(krzqk).ToString().Trim().Replace("'", "-");
                    args[20] = Math.Abs(krzqk).ToString().Trim().Replace("'", "-");
                }
                args[19] = "";
                args[21] = "1";
                args[22] = common_file.common_app.czy_bc;
                if (openfrom == "Sjjzwll")
                {
                    string czzt_Temp = (jjType == common_file.common_jzzt.czzt_gz) ? common_file.common_jzzt.czzt_gzzsz : common_file.common_jzzt.czzt_jzzsz;
                    args[23] = czzt_Temp;
                }
                if (openfrom == "Sfjcz" && (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_jz || jjType == common_file.common_jzzt.czzt_bfsz))
                {
                    string czzt_temp = "";
                    if (jjType == common_file.common_jzzt.czzt_gz || jjType == common_file.common_jzzt.czzt_gzfj)
                    {
                        czzt_temp = (jjType == common_file.common_jzzt.czzt_gz) ? jjType = common_file.common_jzzt.czzt_gzfj : jjType = common_file.common_jzzt.czzt_jzfj;
                    }
                    else
                    {
                        czzt_temp = common_file.common_jzzt.czzt_bfsz;
                    }
                    args[23] = czzt_temp;
                }
                else if (openfrom == "Szw_Common")
                {
                    args[23] = jjType;//挂，记，结 直接用(当结帐时要更改相应记录的状态）
                }
                else if (openfrom == "Szw_pljz")
                {
                    args[23] = common_file.common_jzzt.czzt_gzzsz;
                }
                //czsj, syzd, is_visible, add_edit_delete, xxzs,jjje
                //args[24] = common_file.common_app.xxzs,fkfs
                args[24] = DateTime.Now.ToString();
                args[25] = common_file.common_app.syzd;
                args[26] = common_file.common_app.get_add;
                args[27] = common_file.common_app.xxzs;
                args[28] = tB_fkfs.Text.Trim();
                args[29] = common_file.common_app.czy_GUID;

                Hotel_app.Server.Szwgl.Szw_jzOrgzOrSZ  Szw_jzOrgzOrSZ_services=new Hotel_app.Server.Szwgl.Szw_jzOrgzOrSZ();

                string result = Szw_jzOrgzOrSZ_services.Sjzmx_pz(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(),
               args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_PZ", args);
                if (result != null && result== common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "平帐成功");
                    this.DialogResult = DialogResult.OK;
                    //common_file.common_form.Szwcz_new.pz_control = true;//成功后，可以结帐
                    this.Close();
                }
            }
            Cursor.Current = Cursors.Default;
        }


        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Spzcz_Load(object sender, EventArgs e)
        {
            tB_krzqk.Text =this.krzqk.ToString();
            tB_krzfk.Text = this.krzfk.ToString();
            tB_krxsh.Text = this.krxsh.ToString();
        }

        private bool checkTbValue()
        {
            if (((Maticsoft.Common.PageValidate.IsDecimalSign(tB_krzqk.Text.Trim())) || (Maticsoft.Common.PageValidate.IsNumberSign(tB_krzqk.Text.Trim()))) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的金额不是有效数字！");
                tB_krzqk.Focus();
                return   false;
            }
            if (((Maticsoft.Common.PageValidate.IsDecimalSign(tB_krzfk.Text.Trim())) || (Maticsoft.Common.PageValidate.IsNumberSign(tB_krzfk.Text.Trim()))) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的金额不是有效数字！");
                tB_krzfk.Focus(); return false;
            }
            if (((Maticsoft.Common.PageValidate.IsDecimalSign(tB_krxsh.Text.Trim())) || (Maticsoft.Common.PageValidate.IsNumberSign(tB_krxsh.Text.Trim()))) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的金额不是有效数字！");
                tB_krxsh.Focus(); return false;
            }

            if (decimal.Parse(tB_krzqk.Text.Trim()).Equals(decimal.Parse("0")))//如果消费==付款
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "平帐成功");
                common_file.common_form.Szwcz_new.pz_control = true;//成功后，可以结帐
                return true;
            }
            if (tB_fkfs.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择付款方式");
                tB_fkfs.Focus();
                return false;
            }
            return true;
        }

        private void tB_krzfk_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }
    }
}