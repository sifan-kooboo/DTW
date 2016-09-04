using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Hotel_app.Szwgl
{
    public partial class Szwcz : Form
    {
        public string lsbh = "";
        public string sk_tt = "";
        public string yydj = "";
        public bool is_yj = false;//由Sjjzwll管理过来时，此值为true，表示以结的帐务
        public string jjzt_type = "";//结帐，记帐退房，挂帐退房,
        public string jjzt_type_temp = "";
        public bool pz_control = false;//记录是否有平帐
        public decimal sum = 0;
        public bool JZ_result = false;//结帐，记帐，挂账的结果（成功，则直接关闭Szwcl，不成功或者中途退出，则刷新Szwcl）；

        public string id = "0";//主单ID（团体或者散客)
        public string zz_loadType = "";//转帐介面打开的初始化类型

        public string xf = "";//消费大类不是付款的
        public string fk = "";//消费大类为付款的
        public DataSet ds_temp;
        public DataTable dt_temp;
        public string strSQL = "";
        public string url = "";

        public string openFrom = "";  //判断是从哪里打开的  Szw_Common指从这里调用,Sjjzwll指从这类这里打开的
        public string tfsj = "";//退房时间
        public string krxm = "";//客人姓名
        decimal xf_temp_1 = 0;
        decimal fk_temp_1 = 0;

        ////lsbh, jzbh, yydh, jjType, sk_tt, czy, czsj, syzd, czy_bc, fkje, xfje,xxzs
        /// <summary>
        /// 挂、记   转结时用的变量
        /// </summary>
        public string jzbh = "";
        public string lsbh_last = "";//挂账批结时用到


        public string fjbh = "";//撤销时用到

        public BLL.Szw_temp B_szw_temp = new Hotel_app.BLL.Szw_temp();
        public Hotel_app.BLL.Flfsz B_Flfsz = new Hotel_app.BLL.Flfsz();
        public Szwgl.SzwclHelper zwclHelper = new SzwclHelper();
        public BLL.Common B_common = new Hotel_app.BLL.Common();

        public BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        public Model.Qskyd_mainrecord M_Qskyd_mainrecord;
        public BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        public Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        //带BAK的都是用帐务浏览的时候去操作的
        public BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();
        public Model.Qskyd_mainrecord_bak M_Qskyd_mainrecord_bak;
        public BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();
        public Model.Qttyd_mainrecord_bak M_Qttyd_mainrecord_bak;

        public BLL.Sjzzd B_sjzzd = new Hotel_app.BLL.Sjzzd();
        public Model.Sjzzd M_Sjzzd;

        public SzwclHelper SzwclHelper_new = new SzwclHelper();

        public Szwcz()
        {
            InitializeComponent();
            resetBtnLocation();
        }

        public void InitalApp(string jjzt_type, string lsbh, string jzbh, string sk_tt, string openFrom)
        {
            this.jjzt_type = jjzt_type;//结帐类型（记帐分结，挂帐分结，部分算帐，记帐，挂帐，结帐....)
            this.lsbh = lsbh;
            this.jzbh = jzbh;
            this.sk_tt = sk_tt;
            this.openFrom = openFrom; //标示是从哪个窗体来调用此窗体的，起到辅助作用，助于控制哪些Buttom显示和隐藏
            SetCms();
            SetBtnText();
            BindData_zwmx(this.lsbh, this.jzbh, this.sk_tt, "");
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //显示该lsbh下的详细帐务（散客要考虑连房的情况,团体列出此lsbh对应的ddbh所有的帐务详细
        public void BindData_zwmx(string lsbh, string jzbh, string sk_tt, string sel_con)
        {
            dg_zwcz.AutoGenerateColumns = false;
            if (openFrom == "Szw_Common")
            {
                if (this.lsbh != "" && sk_tt == "sk")
                {
                    zwclHelper.GetZwmx(this.lsbh, "sk", common_file.common_app.czy_GUID, sel_con);
                    krxm = B_Qskyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'")[0].krxm;
                }
                if (this.lsbh != "" && sk_tt == "tt")
                {
                    zwclHelper.GetZwmx(this.lsbh, "tt", common_file.common_app.czy_GUID, sel_con);
                    krxm = B_Qttyd_mainrecord.GetModelList("id>=0  " + common_file.common_app.yydh_select + "  and  lsbh='" + lsbh + "'")[0].krxm;
                }
                ds_temp = B_szw_temp.GetList("id>=0  " + common_file.common_app.yydh_select + "   and  czy_temp='" + common_file.common_app.czy_GUID + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    //bs_zwcz.DataSource = ds_temp.Tables[0];
                    //dg_zwcz.DataSource = bs_zwcz;

                    //计算出消费和付款
                    //strSQL = "select  Sum(sjxfje)  as  sjxfje  from  Szw_temp  where xfdr!='" + common_file.common_app.fkdr + "' and lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'";//付款之外的就是消费金额（房费和其它)
                    strSQL = "select  Sum(sjxfje)  as  sjxfje  from  Szw_temp  where xfdr!='" + common_file.common_app.fkdr + "'  and  yydh='" + common_file.common_app.yydh + "' and czy_temp='" + common_file.common_app.czy_GUID + "'";//付款之外的就是消费金额（房费和其它)
                    object obj = DbHelperSQL.GetSingle(strSQL);
                    if (obj != null)
                    {
                        xf = DbHelperSQL.GetSingle(strSQL).ToString();
                    }
                    else
                    {
                        xf = "0"; //没有任何消费的时候
                    }
                    //strSQL = "select  Sum(sjxfje)  as  sjxfje  from  Szw_temp  where xfdr='" + common_file.common_app.fkdr + "' and lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'"; ;//付款的
                    strSQL = "select  Sum(sjxfje)  as  sjxfje  from  Szw_temp  where xfdr='" + common_file.common_app.fkdr + "'   and  yydh='" + common_file.common_app.yydh + "' and  czy_temp='" + common_file.common_app.czy_GUID + "'"; ;//付款的

                    obj = DbHelperSQL.GetSingle(strSQL);
                    if (obj != null)
                    {
                        fk = (-decimal.Parse(DbHelperSQL.GetSingle(strSQL).ToString())).ToString();
                    }
                    else
                    {
                        fk = "0";//没有预付款的时候
                    }
                }
                else
                {
                    xf = "0";
                    fk = "0";
                }
                tB_xf.Text = xf;
                //tB_fk.Text = Math.Abs(decimal.Parse(fk)).ToString();
                tB_fk.Text = fk;
            }
            if (openFrom == "Sjjzwll")//帐务浏览的处理部分
            {
                //绑定数据
                ds_temp = SzwclHelper_new.GetZwmx_zwll(lsbh, jzbh, jjzt_type);
                //计算出消费和付款
                GetConsume(ref xf, ref fk, ds_temp);

            }
            if (openFrom == "Sfjcz")//分结操作绑定的数据是id_app出现在szw_zz_fj_temp里Szwmx里面的记录
            {
                //绑定数据
                ds_temp = SzwclHelper_new.GetZwmx_fj(lsbh, jzbh, sk_tt, jjzt_type, common_file.common_app.czy_GUID, sel_con);
                GetConsume(ref xf, ref fk, ds_temp);
            }
            if (openFrom == "Szw_pljz")
            {
                ds_temp = B_common.GetList("select * from Szw_temp", "id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   czy_temp='" + common_file.common_app.czy_GUID + "'");
                GetConsume(ref xf, ref fk, ds_temp);
            }
            dg_zwcz.AutoGenerateColumns = false;

            bs_zwcz.DataSource = ds_temp.Tables[0];
            dg_zwcz.DataSource = bs_zwcz;
            if (dg_zwcz.Rows.Count > 0)
            {
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int m = 0; m < dg_zwcz.Rows.Count; m++)
                    {
                        DataRowView dgr = dg_zwcz.Rows[m].DataBoundItem as DataRowView;
                        int j = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);
                        if (ds_temp.Tables[0].Rows[j]["xfdr"].ToString() == common_file.common_app.fkdr)
                        {

                            dg_zwcz.Rows[m].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void b_pz_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcz_pz", common_file.common_app.user_type) == false)
            { return; }
            sum = 0;
            //注意，平帐的时候，先要判断是否有预授款
            for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
            {
                if (ds_temp.Tables[0].Rows[i]["fkfs"].ToString() == common_file.common_app.dj_ysq)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先退掉" + common_file.common_app.dj_ysq + "款项,再进行平账操作.");
                    return;
                }
            }
            for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
            {
                if (ds_temp.Tables[0].Rows[i]["sjxfje"] != null && ds_temp.Tables[0].Rows[i]["sjxfje"].ToString().Trim() != "")
                {
                    //注意：预授权也计算在此列中(注意，在结帐的时候会要求退订掉)
                    if (ds_temp.Tables[0].Rows[i]["xfxm"].ToString() == common_file.common_app.dj_ysk)
                    { sum += decimal.Parse(ds_temp.Tables[0].Rows[i]["sjxfje"].ToString()); }
                    else
                    {
                        sum += decimal.Parse(ds_temp.Tables[0].Rows[i]["sjxfje"].ToString());
                    }
                }
            }
            if (sum == 0)
            {
                pz_control = true;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "平帐成功");
                return;
            }
            else
            {
                Spzcz F_Spzcz = new Spzcz();
                //客人总欠款要根据当前gridview里面的数据进行统计得出

                F_Spzcz.lsbh = this.lsbh;
                F_Spzcz.sk_tt = this.sk_tt;
                F_Spzcz.krzqk = sum;
                F_Spzcz.jjType = this.jjzt_type;
                F_Spzcz.jzzt = jjzt_type;
                F_Spzcz.jzbh = jzbh;
                F_Spzcz.openfrom = this.openFrom;
                if (F_Spzcz.krzqk > 0)//付款数比消费数小
                {
                    F_Spzcz.krzfk = Math.Abs(F_Spzcz.krzqk);//客人总付款
                    F_Spzcz.krxsh = 0;//客人需收款
                }
                else
                {
                    F_Spzcz.krzfk = 0;
                    F_Spzcz.krxsh = Math.Abs(F_Spzcz.krzqk);
                }
                F_Spzcz.StartPosition = FormStartPosition.CenterScreen;
                if (F_Spzcz.ShowDialog(this) == DialogResult.OK)
                {
                    BindData_zwmx(lsbh, jzbh, sk_tt, "  and   xfxm!='" + common_file.common_app.dj_pzsk + "'");
                    pz_control = true;
                }
            }
        }

        private void b_sz_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcz_jz", common_file.common_app.user_type) == false)
            { return; }
            url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
            string s = common_file.common_app.get_failure;
            common_file.common_app.get_czsj();
            if (openFrom == "Szw_Common" || openFrom == "Sfjcz" || openFrom == "Szw_pljz")
            {
                common_file.common_app.get_czsj();
                //结帐前要先平帐
                if (b_sz.Text.Trim() == "结账")
                {
                    if (pz_control == true)//以经平帐,并且要结帐
                    {
                        common_file.common_app.get_czsj();
                        //更新于2012-03-21(防止平帐后再次结帐)
                        if (decimal.Parse(xf)-decimal.Parse(fk)==0)
                        {
                            if (openFrom == "Szw_Common")
                            {
                                common_file.common_app.get_czsj();
                                if (SzwclHelper_new.Fun_zw(lsbh, jjzt_type, sk_tt, krxm, common_file.common_app.czy) == common_file.common_app.get_suc)
                                {
                                    common_file.common_app.get_czsj();
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "结账成功");
                                    JZ_result = true;
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "结账失败");
                                }
                            }
                            if (openFrom == "Sfjcz")
                            {
                                common_file.common_app.get_czsj();
                                if (SzwclHelper_new.Fun_jzOrgzOrszToFj(lsbh, jjzt_type, sk_tt, DateTime.Now.ToString(), fk, xf, jzbh) == common_file.common_app.get_suc)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "分结成功");
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "分结失败");
                                }
                            }
                            if (openFrom == "Szw_pljz")
                            {
                                //按时间不传lsbh_last
                                // jzzt,lsbh_last,  jzType, yydh,  qymc,  czy,  syzd, czy_bc,  czsj,  xxzs
                                url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                                object[] args = new object[11];
                                args[0] = jjzt_type;  //临时用做JZZT
                                args[1] = lsbh_last;
                                args[2] = common_file.common_jzzt.czzt_gzzsz;
                                args[3] = common_file.common_app.yydh;
                                args[4] = common_file.common_app.qymc;
                                args[5] = common_file.common_app.czy;
                                args[6] = common_file.common_app.syzd;
                                args[7] = common_file.common_app.czy_bc;
                                args[8] = DateTime.Now.ToString();
                                args[9] = common_file.common_app.xxzs;
                                args[10] = common_file.common_app.czy_GUID;
                                Hotel_app.Server.Szwgl.Szw_gzpj Szw_gzpj_services = new Hotel_app.Server.Szwgl.Szw_gzpj();
                                string result = Szw_gzpj_services.Fun_gzpj(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_gzpj", args);
                                if (result != null && result== common_file.common_app.get_suc)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "批结成功");
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "批结失败");
                                }
                            }
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "账务未平,请先平帐");
                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "结账前请先平帐");
                        return;
                    }
                }
                if (b_sz.Text.Trim() == "挂账" || b_sz.Text.Trim() == "记账")
                {
                    common_file.common_app.get_czsj();
                    Sjzcz Frm_Sjzcz = new Sjzcz();
                    if (b_sz.Text.Trim() == "挂账")
                    {
                        Frm_Sjzcz.initalApp(common_file.common_jzzt.czzt_gz, this.lsbh, krxm, sk_tt, false,tB_xf.Text.Trim());
                    }
                    if (b_sz.Text.Trim() == "记账")
                    {
                        Frm_Sjzcz.initalApp(common_file.common_jzzt.czzt_jz, this.lsbh, krxm, sk_tt, false,tB_xf.Text.Trim());
                    }
                    Frm_Sjzcz.StartPosition = FormStartPosition.CenterScreen;
                    if (Frm_Sjzcz.ShowDialog() == DialogResult.OK)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "客人" + b_sz.Text + "成功");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            if (openFrom == "Sjjzwll")
            {
                if (b_sz.Text.Trim() == "结账")
                {
                    if (pz_control == true)//记帐转结帐，挂帐转结帐
                    {
                        common_file.common_app.get_czsj();
                        xf_temp_1 = 0;
                        fk_temp_1 = 0;
                        GetConsume(ref xf, ref fk, ds_temp);
                        if (xf_temp_1 + fk_temp_1 != 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "结账前请先平帐");
                            return;
                        }
                        //注意这里的jjzt_type的转换
                        if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                        {
                            jjzt_type_temp = common_file.common_jzzt.czzt_jzzsz;
                        }
                        if (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                        {
                            jjzt_type_temp = common_file.common_jzzt.czzt_gzzsz;
                        }
                        if (SzwclHelper_new.Fun_jzorgzToSz(lsbh, jzbh, jjzt_type_temp, sk_tt, DateTime.Now.ToString(), fk, xf) == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "结账成功");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "结账前请先平帐");
                        return;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_zwcz_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)//金额这一栏
            {
                for (int i = 0; i < ds_temp.Tables[0].Rows.Count; i++)
                {
                    if (ds_temp.Tables[0].Rows[i]["xfrb"].ToString() == common_file.common_app.dj_ysk && ds_temp.Tables[0].Rows[i]["xfxm"].ToString() == common_file.common_app.dj_ysk)
                    { dg_zwcz.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Red; }
                }
            }
        }

        private void b_fk_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcz_fk", common_file.common_app.user_type) == false)
            { return; }

            if (openFrom == "Sfjcz")//分结操作用押金调定(方法保留)
            {
                //先判断押金是够当前的金额
                decimal je_temp = decimal.Parse(tB_xf.Text.Trim());
                decimal yj_temp = common_zw.GetValue("sjxfje", "Syjcz", "  where  id>=0 and yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'");
                if (yj_temp < je_temp)//押金不足以抵扣
                {
                    //common_file.common_app.Message_box_show(common_file.common_app.message_title, "押金不足以抵扣当前的分结金额");
                    // return;
                }
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "押金抵扣功能还未实现");
                return;
            }
            else if (openFrom == "Sjjzwll")
            {
                Szwgl.Syjcz Frm_Syjcz = new Syjcz();
                Frm_Syjcz.sk_tt = this.sk_tt;
                Frm_Syjcz.lsbh = this.lsbh;
                Frm_Syjcz.jzbh = this.jzbh;
                Frm_Syjcz.openfrom = "Sjjzwll";
                Frm_Syjcz.jjType = this.jjzt_type;
                Frm_Syjcz.StartPosition = FormStartPosition.CenterScreen;
                if (Frm_Syjcz.ShowDialog() == DialogResult.OK)
                {
                    BindData_zwmx(lsbh, jzbh, sk_tt, "");
                }
            }
        }

        private void b_fenj_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (b_fenj.Text != "改单")
            {
                if (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                {
                    if (common_file.common_roles.get_user_qx("B_zwcz_gzfj", common_file.common_app.user_type) == false)
                    { return; }
                }
                if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                {
                    if (common_file.common_roles.get_user_qx("B_zwcz_jzfj", common_file.common_app.user_type) == false)
                    { return; }
                }

                //分结介面的初始化
                common_file.common_form.ShowFrm_Sfjcz_new(jjzt_type, lsbh, sk_tt, jzbh);
                this.Close();
            }
            else
            {
                //执行改单的部分操作
                common_file.common_app.get_czsj();
                if (common_file.common_roles.get_user_qx("B_Sjjzwll_gd", common_file.common_app.user_type) == false)
                { return; }
                Szw_gd Frm_Szw_gd_new = new Szw_gd(jzbh, lsbh,sk_tt,"zz");
                Frm_Szw_gd_new.StartPosition = FormStartPosition.CenterScreen;
                Frm_Szw_gd_new.ShowDialog();
                Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_zhuanz_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();

            if (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
            {
                if (common_file.common_roles.get_user_qx("B_zwcz_gzzz", common_file.common_app.user_type) == false)
                { return; }
            }
            if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
            {
                if (common_file.common_roles.get_user_qx("B_zwcz_jzzz", common_file.common_app.user_type) == false)
                { return; }
            }

            if (jjzt_type == common_file.common_jzzt.czzt_gzzjz)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "注意！！！原来已经是从挂账转过来，不允许再次转成入住,否则会出错！");
                return;
            }
            else
                if (jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "注意！！！原来已经是从记账转过来，不允许再次转成入住,否则会出错！");
                    return;
                }



            Zhuanzhang_Operate();
            Cursor.Current = Cursors.Default;
        }

        //转帐操作
        private void Zhuanzhang_Operate()
        {
            zz_loadType = "";
            DataSet ds_temp_0 = null;
            if (lsbh.Trim() != "" && jzbh.Trim() != "")
            {
                if (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                {
                    zz_loadType = "gzzz"; //挂帐转帐
                }
                if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                {
                    zz_loadType = "jzzz";//记帐转帐
                }
                //M_Sjzzd = B_sjzzd.GetModelList("id>=0  and yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'")[0];
                ds_temp_0 = B_common.GetList(" select * from Sjzzd  ", " id>=0  and   lsbh='" + lsbh + "'  and jzbh='" + jzbh + "'  and yydh='" + common_file.common_app.yydh + "'");
                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                {
                    Qyddj.Q_sk_tt_app Q_sk_tt_app_new = new Hotel_app.Qyddj.Q_sk_tt_app(ds_temp_0.Tables[0].Rows[0]["id"].ToString(), common_file.common_yddj.yddj_dj, zz_loadType);
                    Q_sk_tt_app_new.StartPosition = FormStartPosition.CenterScreen;
                    if (Q_sk_tt_app_new.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        //获取消费总数
        private void GetConsume(ref  string xf, ref string fk, DataSet ds)
        {
            bs_zwcz.DataSource = ds.Tables[0];
            dg_zwcz.DataSource = bs_zwcz;
            xf = "0";
            fk = "0";
            xf_temp_1 = 0;
            fk_temp_1 = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["xfdr"].ToString() != common_file.common_app.fkdr)
                {
                    //xf_temp_1 += decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    xf_temp_1 += decimal.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString());
                }
                if (ds.Tables[0].Rows[i]["xfdr"].ToString() == common_file.common_app.fkdr)
                {
                    //fk_temp_1 += decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    fk_temp_1 += decimal.Parse(ds.Tables[0].Rows[i]["sjxfje"].ToString());
                }
            }
            //xf = xf_temp_1.ToString();
            xf=(decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(xf_temp_1.ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString())).ToString();
            //fk = (Math.Abs(fk_temp_1)).ToString();
            fk = (-fk_temp_1).ToString();
            tB_fk.Text = fk;
            tB_xf.Text = xf;
        }

        private void Szwcz_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意，在关闭这个窗体的时候，同时关闭Szw_Common_check这个
            if (openFrom == "Szw_pljz" && this.DialogResult != DialogResult.OK)
            {
                //合并分结记录


            }
        }

        private void Szwcz_Load(object sender, EventArgs e)
        {
            //if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz || jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
            //{
            //    if (dg_zwcz.Rows.Count > 0)
            //    {
            //        for (int m = 0; m < dg_zwcz.Rows.Count; m++)
            //        {
            //            dg_zwcz.Rows[m].DefaultCellStyle.ForeColor = Color.Red;
            //        }
            //    }
            //}

            if (dg_zwcz.Rows.Count > 0)
            {
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int m = 0; m < dg_zwcz.Rows.Count; m++)
                    {
                        DataRowView dgr = dg_zwcz.Rows[m].DataBoundItem as DataRowView;
                        int j = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);
                        if (ds_temp.Tables[0].Rows[j]["xfdr"].ToString() == common_file.common_app.fkdr)
                        {

                            dg_zwcz.Rows[m].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }


        }

        //以下为右键菜单
        //复位所有按纽的位置
        private void resetBtnLocation()
        {
            this.b_sz.Location = new System.Drawing.Point(12, 338);
            this.b_fenj.Location = new System.Drawing.Point(12, 272);
            this.b_zhuanz.Location = new System.Drawing.Point(12, 14);
            this.b_fk.Location = new System.Drawing.Point(12, 142);
            this.b_chex.Location = new System.Drawing.Point(12, 399);
            this.b_print.Location = new System.Drawing.Point(12, 463);
            this.b_ww.Location = new System.Drawing.Point(12, 211);
            this.b_exit.Location = new System.Drawing.Point(12, 524);
            this.b_pz.Location = new System.Drawing.Point(12, 78);
            this.b_sz.Visible = true;
            b_fenj.Visible = true;
            b_zhuanz.Visible = true;
            b_fk.Visible = true;
            b_chex.Visible = true;
            b_print.Visible = true;
            b_exit.Visible = true;
            b_pz.Visible = true;
            b_sz.Visible = true;
        }

        //由jzzt_type来控制按纽的显示
        private void SetBtnText()
        {
            if (openFrom == "Szw_Common")
            {
                if (this.jjzt_type == common_file.common_jzzt.czzt_sz || this.jjzt_type == common_file.common_jzzt.czzt_bfsz || this.jjzt_type == common_file.common_jzzt.czzt_gz || this.jjzt_type == common_file.common_jzzt.czzt_jz)
                {
                    //sz  显示平帐，结帐，打印，退出
                    //b_fenj.Visible = false;
                    b_fenj.Visible = true;
                    b_fenj.Text = "改单";
                    b_zhuanz.Visible = false;
                    b_fk.Visible = false;
                    b_chex.Visible = false;
                    b_ww.Visible = false;
                    b_print.Visible = true;
                    b_exit.Visible = true;
                    b_pz.Visible = false;
                    b_sz.Visible = true;
                    if (this.jjzt_type == common_file.common_jzzt.czzt_sz || this.jjzt_type == common_file.common_jzzt.czzt_bfsz)
                    {
                        b_pz.Visible = true;
                        this.b_pz.Location = new System.Drawing.Point(12, 338);
                    }
                    this.b_sz.Location = new System.Drawing.Point(12, 401);
                    if (jjzt_type == common_file.common_jzzt.czzt_sz)
                    {
                        b_sz.Text = "结账";
                        //b_sz.Image = Image.FromFile(common_file.common_app.BtnBgImgFilePath("a-7.ICO"));
                    }
                    if (jjzt_type == common_file.common_jzzt.czzt_jz)
                    {
                        b_fenj.Location = new System.Drawing.Point(12, 335);
                        b_sz.Text = "记账";
                        //b_sz.Image = Image.FromFile(common_file.common_app.BtnBgImgFilePath("a-8.ICO"));
                    }
                    if (jjzt_type == common_file.common_jzzt.czzt_gz)
                    {
                        b_fenj.Location = new System.Drawing.Point(12, 335);
                        b_sz.Text = "挂账";
                        //b_sz.Image = Image.FromFile(common_file.common_app.BtnBgImgFilePath("a-9.ICO"));
                    }
                }
            }
            if (openFrom == "Sjjzwll")//从帐务浏览打开的
            {
                if (jjzt_type == common_file.common_jzzt.czzt_sz || jjzt_type == common_file.common_jzzt.czzt_bfsz || jjzt_type == common_file.common_jzzt.czzt_gzzsz || jjzt_type == common_file.common_jzzt.czzt_jzzsz || jjzt_type == common_file.common_jzzt.czzt_jzfj || jjzt_type == common_file.common_jzzt.czzt_gzfj)
                {
                    b_fenj.Visible = false;
                    b_zhuanz.Visible = false;
                    b_fk.Visible = false;
                    b_chex.Visible = true;
                    b_ww.Visible = true;
                    b_print.Visible = true;
                    b_exit.Visible = true;
                    b_pz.Visible = false;
                    b_sz.Visible = false;
                    this.b_pz.Location = new System.Drawing.Point(12, 338);
                    this.b_sz.Location = new System.Drawing.Point(12, 399);

                    b_ww.Location = new System.Drawing.Point(12, 338);
                }
                if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                {
                    b_fenj.Visible = true;
                    b_zhuanz.Visible = true;
                    b_fk.Visible = true;
                    b_chex.Visible = true;
                    b_ww.Visible = true;
                    b_print.Visible = true;
                    b_exit.Visible = true;
                    b_pz.Visible = true;
                    b_sz.Visible = true;
                }
            }
            if (openFrom == "Sfjcz")
            {
                b_fenj.Visible = false;
                b_zhuanz.Visible = false;
                b_fk.Visible = false;
                b_chex.Visible = false;
                b_ww.Visible = false;
                b_print.Visible = true;
                b_exit.Visible = true;
                b_pz.Visible = true;
                b_sz.Visible = true;
                this.b_pz.Location = new System.Drawing.Point(12, 338);
                this.b_sz.Location = new System.Drawing.Point(12, 399);
            }
            if (openFrom == "Szw_pljz")
            {
                b_pz.Visible = true;
                b_sz.Visible = true;
                b_print.Visible = true;
                b_zhuanz.Visible = false;
                b_fenj.Visible = false;
                b_fk.Visible = false;
                b_chex.Visible = false;
                b_ww.Visible = false;
                b_pz.Location = new System.Drawing.Point(12, 338);
                b_sz.Location = new System.Drawing.Point(12, 399);
            }
            if (openFrom == "gd")//如果是改单
            {

            }
        }

        //复位所有右键的功能
        private void SetCms()
        {
            foreach (ToolStripMenuItem tsmi in Cms_cbz.Items)
            {
                tsmi.Visible = false;
            }
            if (openFrom == "Szw_Common")
            {
                if (jzbh.Trim() == "")
                {
                    //Cms_cbz.Items["Tsmi_tuiding"].Visible = true;
                    //Cms_cbz.Items["Tsmi_chongZhang"].Visible = true;
                    //Cms_cbz.Items["Tsmi_buzhang"].Visible = true;
                    //Cms_cbz.Items["Tsmi_xiaozhang"].Visible = true;
                    // Cms_cbz.Items["Tsmi_tiaozheng"].Visible = true;
                }
            }
            if (openFrom == "Sjjzwll")
            {
                Cms_cbz.Items["Tsmi_tiaozheng"].Visible = true;
                Cms_cbz.Items["Tsmi_zwDetail"].Visible = true;
                if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_gzzjz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                {
                    Cms_cbz.Items["Tsmi_chongZhang"].Visible = true;
                    Cms_cbz.Items["Tsmi_buzhang"].Visible = true;
                    Cms_cbz.Items["Tsmi_xiaozhang"].Visible = true;
                    Cms_cbz.Items["Tsmi_tuiding"].Visible = true;
                    Cms_cbz.Items["Tsmi_changeType"].Visible = true;
                    if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                    { Cms_cbz.Items["Tsmi_changeType"].Text = "转成挂账"; }
                    if (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                    { Cms_cbz.Items["Tsmi_changeType"].Text = "转成记账"; }
                }
            }
            if (openFrom == "Sfjcz")
            {
                if (jzbh != "")
                {

                }
                else
                {

                }
            }
        }

        private void Tsmi_tuiding_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcz_yjcz_td", common_file.common_app.user_type) == false)
            { return; }

            if (dg_zwcz.CurrentRow.Index > -1 && dg_zwcz.CurrentRow.Index < ds_temp.Tables[0].Rows.Count)
            {

                int j_0 = 0;

                DataRowView dgr = dg_zwcz.CurrentRow.DataBoundItem as DataRowView;
                j_0 = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);


                string xfxm_temp_0 = ds_temp.Tables[0].Rows[j_0]["xfxm"].ToString();
                if (xfxm_temp_0 != common_file.common_app.dj_ysk)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此功能不能应用于此项");
                    return;
                }
                if (ds_temp.Tables[0].Rows[j_0]["jzbh"].ToString().Trim() != "")
                {
                    if (jjzt_type == common_file.common_jzzt.czzt_sz || jjzt_type == common_file.common_jzzt.czzt_bfsz || jjzt_type == common_file.common_jzzt.czzt_gzzsz || jjzt_type == common_file.common_jzzt.czzt_jzzsz || jjzt_type == common_file.common_jzzt.czzt_jzfj || jjzt_type == common_file.common_jzzt.czzt_gzfj)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "以结帐务,押金不能退订");
                        return;
                    }
                }
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要退订此款项嘛？") == true)
                {
                    object id_0 = DbHelperSQL.GetSingle("select  id  from Syjcz where id_app='" + ds_temp.Tables[0].Rows[j_0]["id_app"].ToString() + "' and yydh='" + common_file.common_app.yydh + "'");
                    if (id_0 != null)
                    {
                        if (common_cms.del_ysq(id_0.ToString()) == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "退订成功");
                            BindData_zwmx(lsbh, jzbh, sk_tt, "");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_chongZhang_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcz_congz", common_file.common_app.user_type) == false)
            { return; }

            if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
            {
                if (dg_zwcz.CurrentRow.Index > -1 && dg_zwcz.CurrentRow.Index < ds_temp.Tables[0].Rows.Count)
                {
                    int j_0 = 0;

                    DataRowView dgr = dg_zwcz.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);

                    string xfxm_temp_0 = ds_temp.Tables[0].Rows[j_0]["xfxm"].ToString();
                    string xfdr_temp_0 = ds_temp.Tables[0].Rows[j_0]["xfdr"].ToString();

                    if (xfxm_temp_0 != common_file.common_app.dj_ysk && xfxm_temp_0 != common_zw.dr_ff && xfdr_temp_0 != "系统导入")
                    {
                        string id_app_0 = ds_temp.Tables[0].Rows[j_0]["id_app"].ToString();
                        string jzbh_0 = ds_temp.Tables[0].Rows[j_0]["jzbh"].ToString();
                        SczOrbz Frm_sczorbz = new SczOrbz();
                        Frm_sczorbz.initalApp(id_app_0, jzbh_0, lsbh, common_zw.zwcl_congz);
                        Frm_sczorbz.StartPosition = FormStartPosition.CenterScreen;
                        if (Frm_sczorbz.ShowDialog() == DialogResult.OK)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "冲帐成功");
                            BindData_zwmx(lsbh, jzbh, sk_tt, "");
                            if (openFrom == "Sjjzwll")
                            {
                                //刷新Sjjzwll界面
                                common_file.common_form.Sjjzwll_new.load_refresh();
                            }
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_buzhang_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcz_buz", common_file.common_app.user_type) == false)
            { return; }
            if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
            {
                if (dg_zwcz.CurrentRow.Index > -1 && dg_zwcz.CurrentRow.Index < ds_temp.Tables[0].Rows.Count)
                {
                    int j_0 = 0;
                    DataRowView dgr = dg_zwcz.CurrentRow.DataBoundItem as DataRowView;
                    j_0 = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);


                    string xfxm_temp_0 = ds_temp.Tables[0].Rows[j_0]["xfxm"].ToString();
                    string xfdr_temp_0 = ds_temp.Tables[0].Rows[j_0]["xfdr"].ToString();

                    if (xfxm_temp_0 != common_file.common_app.dj_ysk && xfxm_temp_0 != common_zw.dr_ff && xfdr_temp_0 != "系统导入")
                    {
                        string id_app_0 = ds_temp.Tables[0].Rows[j_0]["id_app"].ToString();
                        string jzbh_0 = ds_temp.Tables[0].Rows[j_0]["jzbh"].ToString();
                        SczOrbz Frm_sczorbz = new SczOrbz();
                        Frm_sczorbz.initalApp(id_app_0, jzbh_0, lsbh, common_zw.zwcl_bz);
                        Frm_sczorbz.StartPosition = FormStartPosition.CenterScreen;
                        if (Frm_sczorbz.ShowDialog() == DialogResult.OK)
                        {
                            BindData_zwmx(lsbh, jzbh, sk_tt, "");
                            common_file.common_form.Sjjzwll_new.load_refresh();
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "补帐成功");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_xiaozhang_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcz_xiaoz", common_file.common_app.user_type) == false)
            { return; }
            if (dg_zwcz.CurrentRow.Index > -1 && dg_zwcz.CurrentRow.Index < ds_temp.Tables[0].Rows.Count)
            {
                int j_0 = 0;
                DataRowView dgr = dg_zwcz.CurrentRow.DataBoundItem as DataRowView;
                j_0 = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);


                string xfxm_temp_0 = ds_temp.Tables[0].Rows[j_0]["xfxm"].ToString();
                if (xfxm_temp_0 == common_file.common_app.dj_ysk)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "此功能不能应用于此项");
                    return;
                }
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "您是否真的要删除此笔账？") == true)
                {
                    string id_app_0 = ds_temp.Tables[0].Rows[j_0]["id_app"].ToString();
                    if (id_app_0 != null && id_app_0.Trim() != "")
                    {
                        string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                        object[] args = new object[30];
                        args[0] = "";
                        args[1] = "";
                        args[2] = "";
                        args[3] = common_file.common_app.yydh;
                        args[4] = common_file.common_app.qymc;
                        args[5] = id_app_0;
                        args[6] = DateTime.Now.ToString("yyyy-MM-dd");
                        args[7] = DateTime.Now.ToString();
                        args[8] = common_file.common_app.czy;
                        //xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, xfsl, czy_bc, czzt,
                        args[9] = "";//这里是找出节点的付款大类
                        args[10] = "";//消费小类
                        args[11] = "";//消费明细
                        args[12] = "";
                        args[13] = "";
                        args[14] = "";
                        args[15] = "";
                        args[16] = "";
                        args[17] = "";
                        args[18] = common_file.common_app.czy_bc;
                        args[19] = "";
                        args[20] = DateTime.Now.ToString();
                        args[21] = common_file.common_app.syzd;
                        args[22] = common_file.common_app.get_delete;
                        args[23] = common_file.common_app.xxzs;
                        args[24] = "";
                        args[25] = "";
                        args[26] = "";
                        args[27] = "";//0502新增一个MXBH
                        args[28] = "";
                        args[29] = "";

                        Hotel_app.Server.Szwgl.Szwmx Szwmx_services = new Hotel_app.Server.Szwgl.Szwmx();
                        string result = Szwmx_services.Szwmx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString());
                       // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Szwmx_add_edit", args);
                        if (result== common_file.common_app.get_suc)
                        {
                            BindData_zwmx(lsbh, jzbh, sk_tt, "");
                            common_file.common_form.Sjjzwll_new.load_refresh();
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "销账成功");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_tiaozheng_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcz_tz", common_file.common_app.user_type) == false)
            { return; }

            if (dg_zwcz.CurrentRow.Index > -1 && dg_zwcz.CurrentRow.Index < ds_temp.Tables[0].Rows.Count)
            {
                int j_0 = 0;
                DataRowView dgr = dg_zwcz.CurrentRow.DataBoundItem as DataRowView;
                j_0 = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);

                //20120816 换成预付款冲抵结账款时也可以调整付款方式
                //原来的条件为：ds_temp.Tables[0].Rows[j_0]["xfxm"].ToString() == common_file.common_app.dj_pzsk
                if (ds_temp.Tables[0].Rows[j_0]["xfdr"].ToString() == common_file.common_app.fkdr)
                {
                    string jzbh_0 = ds_temp.Tables[0].Rows[j_0]["jzbh"].ToString();
                    string id_app_0 = ds_temp.Tables[0].Rows[j_0]["id_app"].ToString();
                    Spzcz_tz Spzcz_tz_new = new Spzcz_tz();
                    Spzcz_tz_new.InitalApp(id_app_0, jzbh_0);
                    Spzcz_tz_new.StartPosition = FormStartPosition.CenterScreen;
                    if (Spzcz_tz_new.ShowDialog() == DialogResult.OK)
                    {
                        BindData_zwmx(lsbh, jzbh, sk_tt, "");
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Tsmi_changeType_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcz_jg_zh", common_file.common_app.user_type) == false)
            { return; }

            int i = 0;
            if (jzbh.Trim() != "" && (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz || jjzt_type == common_file.common_jzzt.czzt_jzzgz))
            {
                string ss_temp = "";

                if (jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "注意！！！原来已经是从挂账转过来，不允许再次转回去，否则账务会出错！");
                    return;
                }
                else 
                if (jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "注意！！！原来已经是从记账转过来，不允许再次转回去，否则账务会出错！");
                    return;
                }

                if (jjzt_type == common_file.common_jzzt.czzt_jz )
                {
                    ss_temp = "你真的要转成挂帐嘛？";
                }
                else
                    if (jjzt_type == common_file.common_jzzt.czzt_gz )
                    { ss_temp = "你真的要转成记帐嘛？"; }

                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, ss_temp) == true)
                {

                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title,"注意！！！此操作不能撤销，也不能转入当前的在住客人！！！建议先退出再确认一下是否是您要转的账，如果确实是您要转的请确认，否则取消再退出！") == true)
                    {
                        string jzzt = "";
                        if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                        {
                            Sjzcz Frm_Sjzcz = new Sjzcz();
                            Frm_Sjzcz.initalApp(common_file.common_jzzt.czzt_gz, lsbh, "", sk_tt, true,tB_xf.Text.Trim());
                            Frm_Sjzcz.StartPosition = FormStartPosition.CenterScreen;
                            if (Frm_Sjzcz.ShowDialog() == DialogResult.OK)
                            {
                                jzzt = Frm_Sjzcz.get_jzzt;
                                i = 1;
                            }
                            else
                            {
                                return;
                            }
                        }
                        if (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                        {
                            string info="";
                            if (common_zw.Check_jzed(tB_xf.Text.Trim(), out info))
                            { i = 1; }
                            else
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, info);
                                return;
                            }
                             
                        }
                        if (i == 1)
                        {
                            common_file.common_app.get_czsj();
                            //lsbh, qymc, yydh, jzzt, czy, syzd, czsj, jjType, xxzs
                            string url = common_file.common_app.service_url;
                            url += "Szwgl/Szwgl_app.asmx";
                            object[] args_1 = new object[10];
                            args_1[0] = lsbh;
                            args_1[1] = common_file.common_app.qymc;
                            args_1[2] = common_file.common_app.yydh;
                            args_1[3] = jzzt;
                            args_1[4] = common_file.common_app.czy;
                            args_1[5] = common_file.common_app.syzd;
                            args_1[6] = DateTime.Now.ToString();
                            args_1[7] = jjzt_type;
                            args_1[8] = common_file.common_app.xxzs;
                            args_1[9] = jzbh;

                            Hotel_app.Server.Szwgl.Szw_ChangZwType Szw_ChangZwType_services = new Hotel_app.Server.Szwgl.Szw_ChangZwType();
                            string result_temp = Szw_ChangZwType_services.Szw_GetChangZwType(args_1[0].ToString(), args_1[1].ToString(), args_1[2].ToString(), args_1[3].ToString(), args_1[4].ToString(), args_1[5].ToString(), args_1[6].ToString(), args_1[7].ToString(), args_1[8].ToString(), args_1[9].ToString());
                            //object result_temp = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_Szw_GetChangZwType", args_1);
                            if (result_temp != null && result_temp== common_file.common_app.get_suc)
                            {
                                string ss = "";
                                if (jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_jzzgz)
                                { ss = "挂帐转记帐成功"; }
                                if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
                                { ss = "记帐转挂帐成功"; }
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, ss);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void Tsmi_zwDetail_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcz_tfmx", common_file.common_app.user_type) == false)
            { return; }

            if (jjzt_type == common_file.common_jzzt.czzt_jz || jjzt_type == common_file.common_jzzt.czzt_gz || jjzt_type == common_file.common_jzzt.czzt_sz || jjzt_type == common_file.common_jzzt.czzt_gzfj || jjzt_type == common_file.common_jzzt.czzt_jzfj || jjzt_type == common_file.common_jzzt.czzt_gzzsz || jjzt_type == common_file.common_jzzt.czzt_jzzsz || jjzt_type == common_file.common_jzzt.czzt_jzzgz || jjzt_type == common_file.common_jzzt.czzt_gzzjz)
            {
                if (lsbh != "")
                {
                    Szw_tfInfo Frm_szw_tfInfo = new Szw_tfInfo();
                    Frm_szw_tfInfo.InitalApp(lsbh, sk_tt);
                    Frm_szw_tfInfo.StartPosition = FormStartPosition.CenterScreen;
                    Frm_szw_tfInfo.ShowDialog();
                }
            }
        }

        private void b_chex_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_zwcz_cx", common_file.common_app.user_type) == false)
            { return; }
            common_zw_cx zw_cx_new = new common_zw_cx();
            string outInfo = "";
            string s = common_file.common_app.get_failure;
            if (openFrom == "Sjjzwll")
            {
                DataSet ds_temp_00 = B_common.GetList(" select  *  from Sjzzd  ", " id>=0  and lsbh='" + lsbh + "'  and  jzbh='" + jzbh + "'  and  yydh='" + common_file.common_app.yydh + "' ");
                if (ds_temp_00 != null && ds_temp_00.Tables[0].Rows.Count > 0)
                {
                    bool shys = bool.Parse(ds_temp_00.Tables[0].Rows[0]["shys"].ToString());
                    if (shys)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "以经锁账,当前账务不能撤消！如果确实要进行撤销操作,请先解除锁账！");
                        return;
                    }
                }



                s = zw_cx_new.CheckCx(lsbh, jzbh, jjzt_type, sk_tt, fjbh, out outInfo);
                if (s == common_file.common_app.get_suc && outInfo.Trim() == "")
                {
                    bool flage = false;

                    if (DateTime.Parse(ds_temp_00.Tables[0].Rows[0]["tfsj"].ToString()).Date < DateTime.Now.Date)
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你正在取消的账务为:" + ds_temp_00.Tables[0].Rows[0]["tfsj"].ToString() + "\r\n 此账务不是当天的账务,请谨慎操作,继续操作请点击 是 ,否则就点击 否 ?") == true)
                        {
                            flage = true;
                        }
                    }
                    else
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "您真的要撤销这笔帐单嘛?") == true)
                        {
                            flage = true;
                        }

                    }
                    if (flage == true)
                    {
                        common_file.common_app.get_czsj();
                        //Szwgl_app.Szwgl_app Szwgl_app_new = new Hotel_app.Szwgl_app.Szwgl_app();
                        //Szwgl_app_new.Url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                        Hotel_app.Server.Szwgl.Szw_cx Szw_cx_services = new Hotel_app.Server.Szwgl.Szw_cx();
                        string ss = Szw_cx_services.Fun_zwcx(lsbh, jzbh, sk_tt, common_file.common_app.yydh, common_file.common_app.qymc, jjzt_type, common_file.common_app.czy, common_file.common_app.syzd, DateTime.Now.ToString(), common_file.common_app.xxzs, common_file.common_app.czy_GUID);

                        ////调用webservices
                        ////调用时要注意参数的匹配(lsbh,jzbh,lsbh_old)成组出现的
                        ////lsbh, jzbh,lsbh_old, sk_tt, shlz_temp, lzbh, yydh, qymc, czzt, czy, syzd, czsj, xxzs
                        //string url_temp = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                        //object[] args = new object[10];
                        //args[0] = lsbh;
                        //args[1] = jzbh;
                        //args[2] = sk_tt;
                        //args[3] = common_file.common_app.yydh;
                        //args[4] = common_file.common_app.qymc;
                        //args[5] = jjzt_type;
                        //args[6] = common_file.common_app.czy;
                        //args[7] = common_file.common_app.syzd;
                        //args[8] = DateTime.Now.ToString();
                        //args[9] = common_file.common_app.xxzs;

                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url_temp, "Fun_zw_cx", args);
                       // if (ss != null && ss.ToString() == common_file.common_app.get_suc)
                        if (ss != null && ss == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "撤销成功");
                            common_file.common_form.ShowFrm_Sjjzwll_new(jjzt_type);
                            if (openFrom != "Sjjzwll")
                            {
                                if (common_file.common_form.Szwcl_new != null)
                                {
                                    common_file.common_form.ShowFrm_Szwcl_new(lsbh, sk_tt, common_file.common_app.czy, false);
                                    common_file.common_form.Szwcl_new.CreateTree();
                                }
                            }
                            this.Close();
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "撤销失败");
                            return;
                        }
                    }
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "不能撤销，具体信息为:" + outInfo);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_print_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_zwcz_print", common_file.common_app.user_type) == false)
            { return; }
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要打印此账单嘛?") == true)
            {
                //Szw_print_jzd Szw_print_jzd_new;
                common_file.common_app.get_czsj();
                if (jzbh.Trim() == "")
                {
                    common_file.common_PrintFrm PrintFrm = new Hotel_app.common_file.common_PrintFrm(this.lsbh, tB_fk.Text, tB_xf.Text.Trim(), "Szw_temp", "jzd", sk_tt, "");
                    //Szw_print_jzd_new = new Szw_print_jzd(this.lsbh, tB_fk.Text, tB_xf.Text.Trim(), "Szw_temp", "jzd", sk_tt, ""); Szw_print_jzd_new.Visible = false;
                }
                if (jzbh.Trim() != "")
                {
                    common_file.common_PrintFrm PrintFrm = new Hotel_app.common_file.common_PrintFrm(this.lsbh, tB_fk.Text, tB_xf.Text.Trim(), "Sjzmx", "jzd", sk_tt, jzbh); 
                    //Szw_print_jzd_new = new Szw_print_jzd(this.lsbh, tB_fk.Text, tB_xf.Text.Trim(), "Sjzmx", "jzd", sk_tt, jzbh); Szw_print_jzd_new.Visible = false;
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_ww_Click(object sender, EventArgs e)
        {
            //先择语种的对话框
            //display_new_commonform_1("X_wy_lang_type",100,100,tb

            //原来更新对应的消费项目中对应的英文名称






        }

        private void dg_zwcz_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dg_zwcz.Rows.Count > 0)
            {
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    for (int m = 0; m < dg_zwcz.Rows.Count; m++)
                    {
                        DataRowView dgr = dg_zwcz.Rows[m].DataBoundItem as DataRowView;
                        int j = ds_temp.Tables[0].Rows.IndexOf(dgr.Row);
                        if (ds_temp.Tables[0].Rows[j]["xfdr"].ToString() == common_file.common_app.fkdr)
                        {

                            dg_zwcz.Rows[m].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void display_new_commonform_1(string judge_type_0, int left_0, int top_0, Button TB_ls)
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
    }
}