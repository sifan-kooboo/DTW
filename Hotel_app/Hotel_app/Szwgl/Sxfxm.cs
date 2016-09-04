using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Sxfxm : Form
    {

        public string sel_model = "xf";//两个一个是消费“xf”；另一个是房费配套消费“xyxf",一个是增加改单内容“xf_gd"
        public string gd_jzzd = "";//这个是配合sel_model=xf_gd来用的，其它的时候都用空
        public string gd_lsbh = "";//这个是配合sel_model=xf_gd来用的,这个是在住的改单,如果这个不为空,则gd_jzzd="";
        public string Xxfxr_id = "";
        public string sk_tt = "";
        public string Xxfxr_xrbh = "";//消费小类:bh|名称
        public string xftm = "";//商品条码
        public string xrbh = "";
        public string lsbh = "";
        public string Q_xy_xyxf_id = "";
        public string id_app = "";//生成帐务明细的标符码
        public string judge_add_edit = common_file.common_app.get_add;
        public DataSet ds_temp_xfmx;

        public string xfdr = "";
        public string xfxr = "";
        public string mxbh = "";

        public string xfmx = "";
        public decimal xfje = 0;
        public decimal jjje = 0;

        public string zwmx_czzt = common_file.common_yddj.yddj_dj;//在住，预订，记帐，挂帐

        Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Model.Qskyd_mainrecord();
        BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new BLL.Qskyd_mainrecord();
        Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        BLL.Qttyd_mainrecord B_M_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();

        Model.Qskyd_fjrb M_Qskyd_fjrb;
        Model.Xxfmx M_Xxfmx;
        BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
        public Sxfxm(string sel_model_0)
        {
            sel_model = sel_model_0;
            InitializeComponent();
            ini_compo(sel_model_0);
        }

        public void ini_compo(string sel_model_0)
        {

            if (sel_model_0 == "xf" || sel_model_0=="xf_gd")
            {
                l_xfbz.Visible = true;
                tB_xfbz.Visible = true;
                l_fyrx.Visible = false;
                cB_fyrx.Visible = false;
                l_sptm.Location = new Point(13, 15);
                l_xfrb.Location = new Point(13, 45);
                l_xfxm.Location = new Point(13, 75);
                l_xfsl.Location = new Point(13, 105);
                l_xfje.Location = new Point(13, 135);
                l_xfbz.Location = new Point(13, 165);
                tb_tm.Location = new Point(90, 10);
                tB_xfrb.Location = new Point(90, 40);
                tB_xfxm.Location = new Point(90, 70);
                tB_xfsl.Location = new Point(90, 100);
                tB_xfje.Location = new Point(90, 130);
                tB_xfbz.Location = new Point(90, 160);
                b_xslb.Location = new Point(224, 39);
                btn_xfmx_select.Location = new Point(224, 70);
            }
            else
                if (sel_model_0 == "xyxf")
                {
                    l_xfbz.Visible = false;
                    tB_xfbz.Visible = false;
                    
                    l_fyrx.Visible = true;
                    cB_fyrx.Visible = true;
                    l_sptm.Location = new Point(13,15);
                    l_fyrx.Location = new Point(13, 45);
                    l_xfrb.Location = new Point(13, 75);
                    l_xfxm.Location = new Point(13, 105);
                    l_xfsl.Location = new Point(13, 135);
                    l_xfje.Location = new Point(13, 165);
                    cB_fyrx.Location = new Point(90, 40);
                    tb_tm.Location = new Point(90,10);
                    tB_xfrb.Location = new Point(90, 70);
                    tB_xfxm.Location = new Point(90, 100);
                    tB_xfsl.Location = new Point(90, 130);
                    tB_xfje.Location = new Point(90, 160);
                    b_xslb.Location = new Point(224, 68);
                    btn_xfmx_select.Location = new Point(224, 99);

                }
        }

        public string get_xfdr(string xrbh_0)
        {
            string xfdr_0 = "";
            BLL.Xxfxr B_Xxfxr = new Hotel_app.BLL.Xxfxr();
            DataSet DS_temp = B_Xxfxr.GetList("xrbh='" + xrbh + "'");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                xfdr_0 = DS_temp.Tables[0].Rows[0]["xfdr"].ToString();
 
            }
            DS_temp.Dispose();
            return xfdr_0;
        
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            string ddsj = common_file.common_app.cssj;
            string lksj = common_file.common_app.cssj;
            if (tB_xfrb.Text.Trim() == "")
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择消费类别");
                return;
            }
            else
                if (((Maticsoft.Common.PageValidate.IsDecimal(tB_xfsl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_xfsl.Text.Trim())) == false))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                tB_xfsl.Focus();
                tB_xfsl.SelectAll();
            }
            else 
                    if (((Maticsoft.Common.PageValidate.IsDecimal(tB_xfje.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_xfje.Text.Trim())) == false))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                tB_xfje.Focus();
                tB_xfje.SelectAll();
            }
            else
            {

                if (sel_model == "xf")
                {
                    BLL.Common B_common = new Hotel_app.BLL.Common();
                    DataSet ds_0 = null;
                    //  czsj, syzd,add_edit_delete, xxzs,jjje
                    id_app = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);
                    string zd_id = "";
                    if (sk_tt == "sk")
                    {
                        ds_0 = B_common.GetList(" select * from View_Qskzd ", " id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + lsbh + "'   and    main_sec='" + common_file.common_app.main_sec_main + "'");
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                        {
                            zd_id = ds_0.Tables[0].Rows[0]["id"].ToString();
                            ddsj = ds_0.Tables[0].Rows[0]["ddsj"].ToString();
                            lksj = ds_0.Tables[0].Rows[0]["lksj"].ToString();
                            if (ds_0.Tables[0].Rows[0]["yddj"].ToString() == common_file.common_yddj.yddj_yd)
                            { zwmx_czzt = common_file.common_yddj.yddj_yd; }
                            if (ds_0.Tables[0].Rows[0]["yddj"].ToString() == common_file.common_yddj.yddj_dj)
                            { zwmx_czzt = common_file.common_yddj.yddj_dj; }
                        }
                    }
                    if (sk_tt == "tt")
                    {
                        ds_0 = B_common.GetList(" select * from View_Qttzd ", " id>=0  " + common_file.common_app.yydh_select + "  and lsbh='" + lsbh + "' ");
                        if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                        {
                            zd_id = ds_0.Tables[0].Rows[0]["id"].ToString();
                            ddsj = ds_0.Tables[0].Rows[0]["ddsj"].ToString();
                            lksj = ds_0.Tables[0].Rows[0]["lksj"].ToString();
                            if (ds_0.Tables[0].Rows[0]["yddj"].ToString() == common_file.common_yddj.yddj_yd)
                            {
                                zwmx_czzt = common_file.common_yddj.yddj_yd;
                            }
                            if (ds_0.Tables[0].Rows[0]["yddj"].ToString() == common_file.common_yddj.yddj_dj)
                            {
                                zwmx_czzt = common_file.common_yddj.yddj_dj;
                            }
                        }
                    }
                    string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                    object[] args = new object[30];
                    args[0] = zd_id;
                    args[1] = sk_tt;
                    args[2] = "";
                    if (sk_tt == "sk")
                    {
                        args[3] = common_file.common_app.yydh;
                        args[4] = common_file.common_app.qymc;
                    }
                    if (sk_tt == "tt")
                    {
                        args[3] = common_file.common_app.yydh;
                        args[4] = common_file.common_app.qymc;
                    }
                    args[5] = id_app;
                    //xfrq, xfsj, czy
                    args[6] = DateTime.Now.ToString("yyyy-MM-dd");
                    args[7] = DateTime.Now.ToString();
                    args[8] = common_file.common_app.czy;
                    //xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, xfsl, czy_bc, czzt,
                    args[9] = xfdr;//这里是找出节点的付款大类
                    args[10] = tB_xfrb.Text.Trim();//消费小类
                    args[11] = tB_xfxm.Text.Trim().Replace("'", "-");//消费明细
                    if (args[11].ToString() == "")
                    { args[11] = args[10]; }
                    if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0 && sk_tt == "sk" && tB_xfbz.Text.Trim().Replace("'", "-")=="")
                    { args[12] = ds_0.Tables[0].Rows[0]["fjbh"].ToString(); }
                    else
                    {
                        args[12] = tB_xfbz.Text.Trim().Replace("'", "-");
                    }
                    args[13] = tb_tm.Text.Trim().Replace("'", "-");//tB_xfbz.Text.Trim().Replace("'", "-");
                    args[14] = common_file.common_sswl.Round_sswl(double.Parse(tB_xfje.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                    args[15] = "";
                    args[16] = common_file.common_sswl.Round_sswl(double.Parse(tB_xfje.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString();
                    args[17] = tB_xfsl.Text.Trim().Replace("'", "-"); 
                    args[18] = common_file.common_app.czy_bc;
                    args[19] = zwmx_czzt;//这里要根据主单的yddj的类型(预订，在住，记帐，挂帐）
                    args[20] = DateTime.Now.ToString();
                    args[21] = common_file.common_app.syzd;
                    args[22] = common_file.common_app.get_add;
                    args[23] = common_file.common_app.xxzs;
                    args[24] = jjje.ToString();
                    args[25] = "";
                    args[26] = "";
                    args[27] = mxbh;
                    args[28] = ddsj;
                    args[29] = lksj;

                    Hotel_app.Server.Szwgl.Szwmx Szwmx_services = new Hotel_app.Server.Szwgl.Szwmx();
                    string result = Szwmx_services.Szwmx_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString());
                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Szwmx_add_edit", args);
                    if (result!=null&&result== common_file.common_app.get_suc)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "增加消费成功！");
                        xrbh = ""; xfdr = ""; xfje = 0; xfmx = ""; jjje = 0; mxbh = "";
                        tB_xfrb.Text = ""; tB_xfxm.Text = ""; tB_xfsl.Text = "1"; tB_xfje.Text = "0";
                        tB_xfbz.Text = ""; mxbh = ""; tb_tm.Text = ""; tb_tm.Focus();
                        if (judge_add_edit == common_file.common_app.get_add)
                        {
                            common_file.common_form.Szwcl_new.BindData(lsbh, common_file.common_app.czy_GUID);
                        }
                        else if (judge_add_edit == common_file.common_app.get_edit)
                        {
                            this.Close();
                        }

                    }
                    else
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                }
                else
                    if (sel_model == "xyxf")
                    {
                        if (cB_fyrx.Text.Trim() == "")
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择费用类型！");
                            return;
                        }
                        string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
                        object[] args = new object[16];
                        args[0] = Q_xy_xyxf_id;
                        args[1] = common_file.common_app.yydh;
                        args[2] = common_file.common_app.qymc;
                        args[3] = cB_fyrx.Text.Trim().Replace("'", "-");
                        args[4] = xfdr;
                        args[5] = tB_xfrb.Text.Trim().Replace("'", "-");
                        args[6] = tB_xfxm.Text.Trim().Replace("'", "-");
                        if (args[6].ToString() == "")
                        { args[6] = args[5]; }
                        args[7] =decimal.Parse(tB_xfsl.Text.Trim().Replace("'", "-"));
                        args[8] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_xfje.Text.Trim().Replace("'", "-")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                        args[9] = judge_add_edit;
                        args[10] = common_file.common_app.czy;
                        args[11] = DateTime.Now;
                        if (judge_add_edit == common_file.common_app.get_add)
                        {
                            args[12] = common_file.common_app.chinese_add;
                        }
                        else
                            if (judge_add_edit == common_file.common_app.get_edit)
                        {
                            args[12] = common_file.common_app.chinese_edit;
                        }
                        args[13] = common_file.common_app.xxzs;
                        args[14] = jjje;
                        args[15] = mxbh;

                        Hotel_app.Server.Qyddj.Q_ff_xyxf Q_ff_xyxf_services = new Hotel_app.Server.Qyddj.Q_ff_xyxf();
                        string result = Q_ff_xyxf_services.add_edit_delete_Q_ff_xyxf(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(),Decimal.Parse(args[7].ToString()), Decimal.Parse(args[8].ToString()), args[9].ToString(), args[10].ToString(),DateTime.Parse(args[11].ToString()), args[12].ToString(), args[13].ToString(),decimal.Parse(args[14].ToString()), args[15].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "add_edit_delete_Q_ff_xyxf", args);
                        if (result== common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            this.Close();
                            xrbh = ""; xfdr = ""; xfje = 0; xfmx = ""; jjje = 0;
                            

                        }
                        else
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                    }

/////////////////这里改单

                    else if (sel_model == "xf_gd")
                    {
                        BLL.Common B_common = new Hotel_app.BLL.Common();
                        DataSet ds_0 = null;
                        //  czsj, syzd,add_edit_delete, xxzs,jjje
                        id_app = common_file.common_ddbh.ddbh("xfmx", "lsbhdate", "lsbhcounter", 6);

                        if (gd_jzzd.Trim() != ""&&gd_lsbh.Trim()=="")
                        {
                            DataSet ds_1 = B_common.GetList(" SELECT * FROM Sjzzd ", " id>=0  and yydh='" + common_file.common_app.yydh + "' and jzbh='" + gd_jzzd + "' ");
                            string xfsj_gd = (DateTime.Parse(ds_1.Tables[0].Rows[0]["tfsj"].ToString()).AddDays(-1)).ToString();
                            string xfrq_gd = (DateTime.Parse(ds_1.Tables[0].Rows[0]["tfsj"].ToString()).AddDays(-1)).ToShortDateString();

                            if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(" insert into  Sjzmx_gd_temp (yydh, qymc,  id_app, jzbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfrb, xfdr, xfxm, xfbz, xfzy, jjje, yh, xfje, sjxfje, xfsl, czzt, czy_bc, tfsj, czsj, syzd, xyh, jzzt, fkfs, mxbh, zd_fkje, zd_xfje, zd_ddsj, zd_tfsj, zd_fjbh, zd_krxm_lz, zd_fjbh_lz, czy_temp, lsbh )");
                                sb.Append("  select  yydh,qymc,'" + id_app + "',jzbh,krxm,'',fjbh,sktt,'" + xfrq_gd + "','" + xfsj_gd + "',czy,'" + tB_xfrb.Text.Trim().Replace("'", "-") + "','" + xfdr + "','" + tB_xfxm.Text.Trim().Replace("'", "-") + "','" + tB_xfbz.Text.Trim().Replace("'", "-") + "','',0,'','" + tB_xfje.Text.Trim().Replace("'", "-") + "','" + tB_xfje.Text.Trim().Replace("'", "-") + "',1,czzt, '早班', tfsj, czsj, syzd, xyh, jzzt, '', '',fkje,xfje,ddsj,tfsj,fjbh,krxm_lz,fjbh_lz,'" + common_file.common_app.czy_GUID + "',lsbh  from  Sjzzd ");
                                sb.Append(" where jzbh='" + gd_jzzd + "' and yydh='" + common_file.common_app.yydh + "' ");
                                if (B_common.ExecuteSql(sb.ToString()) > 0)
                                {
                                    this.DialogResult = DialogResult.OK;
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "改单增加消费成功！");
                                    xrbh = ""; xfdr = ""; xfje = 0; xfmx = ""; jjje = 0;
                                    tB_xfrb.Text = ""; tB_xfxm.Text = ""; tB_xfsl.Text = "1"; tB_xfje.Text = "0";
                                    tB_xfbz.Text = ""; mxbh = "";
                                }
                            }
                        }
                        else if (gd_jzzd.Trim() == "" && gd_lsbh.Trim() != ""&&sk_tt.Trim()!="")
                        {

                                string xfsj_gd = DateTime.Now.ToString();
                                string xfrq_gd = DateTime.Now.ToString();
                                DataSet ds_1=null;
                            StringBuilder sb=null;
                                if (sk_tt == "sk")
                                {
                                    ds_1 = B_common.GetList(" SELECT * FROM View_Qskzd ", " id>=0  and yydh='" + common_file.common_app.yydh + "' and lsbh='" + gd_lsbh + "' and main_sec='" + common_file.common_app.main_sec_main + "' ");
                                }
                                if (sk_tt == "tt")
                                {
                                    ds_1 = B_common.GetList(" SELECT * FROM View_Qttzd ", " id>=0  and yydh='" + common_file.common_app.yydh + "' and lsbh='" + gd_lsbh + "'");
                                }
                                if (ds_1 != null && ds_1.Tables[0].Rows.Count > 0)
                                {
                                    if (sk_tt == "sk")
                                    {
                                        sb = new StringBuilder();
                                        sb.Append(" insert into  Sjzmx_gd_temp (yydh, qymc,  id_app, jzbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfrb, xfdr, xfxm, xfbz, xfzy, jjje, yh, xfje, sjxfje, xfsl, czzt, czy_bc, tfsj, czsj, syzd, xyh, jzzt, fkfs, mxbh, zd_fkje, zd_xfje, zd_ddsj, zd_tfsj, zd_fjbh, zd_krxm_lz, zd_fjbh_lz, czy_temp, lsbh )");
                                        sb.Append("  select  yydh,qymc,'" + id_app + "','',krxm,'',fjbh,sktt,'" + xfrq_gd + "','" + xfsj_gd + "','" + common_file.common_app.czy + "','" + tB_xfrb.Text.Trim().Replace("'", "-") + "','" + xfdr + "','" + tB_xfxm.Text.Trim().Replace("'", "-") + "','" + tB_xfbz.Text.Trim().Replace("'", "-") + "','',0,'','" + tB_xfje.Text.Trim().Replace("'", "-") + "','" + tB_xfje.Text.Trim().Replace("'", "-") + "',1,'', '早班','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', syzd, '', krxm, '', '',fkje,xfje,ddsj,'" + DateTime.Now.ToString() + "',fjbh,krxm,fjbh,'" + common_file.common_app.czy_GUID + "',lsbh  from  View_Qskzd ");
                                        sb.Append(" where lsbh='" + gd_lsbh + "' and yydh='" + common_file.common_app.yydh + "' and main_sec='"+common_file.common_app.main_sec_main+"' ");
                                    }
                                    if (sk_tt == "tt")
                                    {
                                         sb= new StringBuilder();
                                        sb.Append(" insert into  Sjzmx_gd_temp (yydh, qymc,  id_app, jzbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfrb, xfdr, xfxm, xfbz, xfzy, jjje, yh, xfje, sjxfje, xfsl, czzt, czy_bc, tfsj, czsj, syzd, xyh, jzzt, fkfs, mxbh, zd_fkje, zd_xfje, zd_ddsj, zd_tfsj, zd_fjbh, zd_krxm_lz, zd_fjbh_lz, czy_temp, lsbh )");
                                        sb.Append("  select  yydh,qymc,'" + id_app + "','',krxm,'','',sktt,'" + xfrq_gd + "','" + xfsj_gd + "','" + common_file.common_app.czy + "','" + tB_xfrb.Text.Trim().Replace("'", "-") + "','" + xfdr + "','" + tB_xfxm.Text.Trim().Replace("'", "-") + "','" + tB_xfbz.Text.Trim().Replace("'", "-") + "','',0,'','" + tB_xfje.Text.Trim().Replace("'", "-") + "','" + tB_xfje.Text.Trim().Replace("'", "-") + "',1,'', '早班','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "', syzd, '', krxm, '', '',fkje,xfje,ddsj,'" + DateTime.Now.ToString() + "','',krxm,'','" + common_file.common_app.czy_GUID + "',lsbh  from  View_Qttzd ");
                                        sb.Append(" where lsbh='" + gd_lsbh + "' and yydh='" + common_file.common_app.yydh + "' ");

                                    }
                                    if (B_common.ExecuteSql(sb.ToString()) > 0)
                                    {
                                        this.DialogResult = DialogResult.OK;
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "改单增加消费成功！");
                                        xrbh = ""; xfdr = ""; xfje = 0; xfmx = ""; jjje = 0;
                                        tB_xfrb.Text = ""; tB_xfxm.Text = ""; tB_xfsl.Text = "1"; tB_xfje.Text = "0";
                                        tB_xfbz.Text = ""; mxbh = "";
                                    }
                                }
 

                            if (sk_tt == "tt")
                            {
 
                            }
                        }
                        else
                        { common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有主单，无法进行改单操作！"); }
                        
                    }
                        /////改单结束
                    
            }

            Cursor.Current = Cursors.Default;

        }

        private void b_xfxr_Click(object sender, EventArgs e)
        {
            Szwgl.Sxfrb F_Sxfrb = new Sxfrb();
            F_Sxfrb.Location = new Point(common_file.common_app.x(), common_file.common_app.y());
            if (F_Sxfrb.ShowDialog() == DialogResult.OK)
            {
                Xxfxr_xrbh = F_Sxfrb.get_xfxm_bh;// 格式:bh|名称
                if (Xxfxr_xrbh.Trim() != "")//小类编号
                {
                    string[] info = Xxfxr_xrbh.Split('|');
                    xrbh = (info[0].Split(':'))[1];
                    xfdr=get_xfdr(xrbh);
                    tB_xfrb.Text = info[1];
                    tB_xfxm.Text = "";
                    tB_xfsl.Text = "1";
                    tB_xfje.Text = "0";
                    tB_xfbz.Text = "";
                    tB_xfxm.Focus();
                }
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btn_xfmx_select_Click(object sender, EventArgs e)
        {

            common_zw.display_new_commonform_1("Xxfmx",out xftm,out xrbh, out xfmx, btn_xfmx_select.Left, btn_xfmx_select.Top, xrbh);
            if (xrbh != "" && xfmx!="")
            {
                common_zw.Get_xf_info(xrbh, xfmx,out xftm, out xfdr, out xfxr,out mxbh, out xfje, out jjje, out xfmx);
                tb_tm.Text = xftm;
                tB_xfxm.Text = xfmx;
                tB_xfje.Text = xfje.ToString();
                tB_xfrb.Text = xfxr;
                tB_xfsl.Text = "1.0";
                tB_xfje.Text = ((xfje) * (Decimal.Parse(tB_xfsl.Text))).ToString();
                mxbh = mxbh;// M_Xxfmx.mxbh;
            }
        }



        private void Sxfxm_Load(object sender, EventArgs e)
        {
            cB_fyrx.Text = Szwgl.common_zw.fwrx_sjje;
            cB_fyrx.Items.Add(Szwgl.common_zw.fwrx_sjje);
            cB_fyrx.Items.Add(Szwgl.common_zw.fwrx_abl);
        }
        //离开文本框时计算金额
        private void tB_xfsl_MouseLeave(object sender, EventArgs e)
        {

        }

        private void tB_xfsl_Leave(object sender, EventArgs e)
        {
            if ((Maticsoft.Common.PageValidate.IsDecimal(tB_xfsl.Text.Trim()) || Maticsoft.Common.PageValidate.IsNumber(tB_xfsl.Text.Trim())) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的数量不是有效数值！");
                tB_xfsl.Focus();
                tB_xfsl.SelectAll();
                return;
            }
            tB_xfje.Text = ((xfje) * (Decimal.Parse(tB_xfsl.Text))).ToString();
        }

        private void tb_tm_KeyDown(object sender, KeyEventArgs e)
        {
            //e.Handled = true;
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_tm.Text.Trim() != "")
                {
                    BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
                    List<Model.Xxfmx> list0 = new List<Hotel_app.Model.Xxfmx>();
                    list0 = B_Xxfmx.GetModelList("  yydh='" + common_file.common_app.yydh + "'  and   xftm='" + tb_tm.Text.Trim().Replace("'", "-") + "'");
                    if (list0 != null && list0.Count > 0)
                    {
                        M_Xxfmx = list0[0];
                        tB_xfrb.Text = M_Xxfmx.xfxr;
                        tB_xfxm.Text = M_Xxfmx.xfmx;
                        tB_xfje.Text = M_Xxfmx.xfje.ToString();
                        xfje =Decimal.Parse( M_Xxfmx.xfje.ToString());
                        tB_xfsl.Focus();
                    }
                    else
                    {
                        tB_xfrb.Focus();
                    }
                }
                //e.Handled = false;
            }
        }

        private void tb_tm_TextChanged(object sender, EventArgs e)
        {
            if (tb_tm.Text.Trim() != "")
            {
                BLL.Xxfmx B_Xxfmx = new Hotel_app.BLL.Xxfmx();
                List<Model.Xxfmx> list0 = new List<Hotel_app.Model.Xxfmx>();
                list0 = B_Xxfmx.GetModelList("  yydh='" + common_file.common_app.yydh + "'  and   xftm='" + tb_tm.Text.Trim().Replace("'", "-") + "'");
                if (list0 != null && list0.Count > 0)
                {
                    M_Xxfmx = list0[0];
                    mxbh = M_Xxfmx.mxbh;
                    tB_xfrb.Text = M_Xxfmx.xfxr;
                    tB_xfxm.Text = M_Xxfmx.xfmx;
                    tB_xfje.Text = M_Xxfmx.xfje.ToString();
                    xfje = Decimal.Parse(M_Xxfmx.xfje.ToString());
                    tB_xfje.Text = (xfje * (decimal.Parse(tB_xfsl.Text.Trim()))).ToString();
                    tB_xfsl.Focus();
                }
            }
        }

        private void tB_xfsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void tB_xfsl_TextChanged(object sender, EventArgs e)
        {
            if (tB_xfsl.Text != "" && M_Xxfmx != null)
            {
                tB_xfje.Text = (xfje * (decimal.Parse(tB_xfsl.Text.Trim()))).ToString();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}