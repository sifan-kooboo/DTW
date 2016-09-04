using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qskdj_fjrb : Form
    {
        public decimal yhbl = 1;
        public DateTime ddsj = DateTime.Now;
        public DateTime lksj = DateTime.Now;
        public string lsbh = "";
        public string Qskdj_fjrb_id = "";
        public string fjbh = "";
        public string yddj = common_file.common_yddj.yddj_dj;
        public string judge_add_edit = common_file.common_app.get_edit;
        //public string add_edit = common_file.common_app.get_add;
        public string url = common_file.common_app.service_url;
        public string yddj_type = common_file.common_app.yddj_type_personal;
        public string lsbh_new = "";//团体成员的临时编号
        public string krxm_temp = "";//排房时客人的临时姓名
        //public int id_temp = 0;//临时记录Qskyd_fjrb_id（修改房间类别表信息时用到）

        //缓存一个打开时的房型房间的信息
        public string old_fx = "";//打开时的房型信息
        public decimal old_fx_sl = 0;//打开时的房型的数量



        public Model.Qskyd_mainrecord M_qskyd_mainrecord_temp = new Hotel_app.Model.Qskyd_mainrecord();
        public BLL.Qskyd_mainrecord B_qskyd_mainrecord_temp = new Hotel_app.BLL.Qskyd_mainrecord();
        //团体还是个人（personal,group)

        //yddj ，type ,add_edit 修改或者新增
        public Qskdj_fjrb(string yddj, string type, string add_edit)
        {
            InitializeComponent();
            tB_fjrb.ReadOnly = true;
            tB_fjbh.ReadOnly = true;
            //tB_fjjg.ReadOnly = true;
            //tB_yh.ReadOnly = true;
            this.yddj = yddj;
            this.yddj_type = type;
            this.judge_add_edit = add_edit;
            if (type == common_file.common_app.yddj_type_personal)
            {
                btn_ydpf.Visible = false;

            }
            if (type == common_file.common_app.yddj_type_group)
            {
                tB_fjbh.Enabled = false;
                Btn_fjbh.Enabled = false;
                btn_ydpf.Visible = true;
                tB_jcje.Enabled = false;

            }
        }
        #region 自定义成员
        public static Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb;
        Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        Hotel_app.Model.Qttyd_mainrecord M_Qttyd_mainrecord;
        Hotel_app.BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();

        #endregion

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void get_gj(string fjrb)
        {
                        string krly_0 = ""; string xyh_0 = ""; DateTime ddsj_0 = DateTime.Parse(common_file.common_app.cssj); DateTime lksj_0 = DateTime.Parse(common_file.common_app.cssj);
                string hykh = ""; string hyrx = "";
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet DS_temp_0 = B_Common.GetList("select krly,xyh,ddsj,lksj,hykh,hyrx from Qskyd_mainrecord","lsbh='"+lsbh+"'");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    xyh_0 = DS_temp_0.Tables[0].Rows[0]["xyh"].ToString();
                    krly_0 = DS_temp_0.Tables[0].Rows[0]["krly"].ToString();
                    ddsj_0 = DateTime.Parse(DS_temp_0.Tables[0].Rows[0]["ddsj"].ToString());
                    lksj_0 = DateTime.Parse(DS_temp_0.Tables[0].Rows[0]["lksj"].ToString());
                    hykh = DS_temp_0.Tables[0].Rows[0]["hykh"].ToString();
                    hyrx = DS_temp_0.Tables[0].Rows[0]["hyrx"].ToString();
                }
                else 
                {
                    DS_temp_0 = B_Common.GetList("select krly,xyh,ddsj,lksj from Qttyd_mainrecord", "lsbh='" + lsbh + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        xyh_0 = DS_temp_0.Tables[0].Rows[0]["xyh"].ToString();
                        krly_0 = DS_temp_0.Tables[0].Rows[0]["krly"].ToString();
                        ddsj_0 = DateTime.Parse(DS_temp_0.Tables[0].Rows[0]["ddsj"].ToString());
                        lksj_0 = DateTime.Parse(DS_temp_0.Tables[0].Rows[0]["lksj"].ToString());
                    }
                }
                DS_temp_0.Clear();
                DS_temp_0.Dispose();




                tB_fjjg.Text = common_file.common_get_fjjg.get_fjjg(fjrb, krly_0, xyh_0, ddsj_0, lksj_0, hykh, hyrx);
        }

        private void B_fjlx_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Ffjzt.Ffjrb_select Ffjrb_select_new = new Hotel_app.Ffjzt.Ffjrb_select();
            Ffjrb_select_new.Left = this.Left + tB_fjrb.Left;
            Ffjrb_select_new.Top = this.Top + tB_fjrb.Top;
            if (Ffjrb_select_new.ShowDialog() == DialogResult.OK)
            {
                tB_fjrb.Text = Ffjrb_select_new.get_fjrb;
                tB_fjbh.Text = "";

                get_gj(Ffjrb_select_new.get_fjrb);


            }
            Ffjrb_select_new.Dispose();
            tB_fjrb.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void Btn_fjbh_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (yddj_type == common_file.common_app.yddj_type_personal)
            {
                Ffjzt.Ffjzt_select Ffjzt_select_new = new Hotel_app.Ffjzt.Ffjzt_select(tB_fjrb.Text.Trim(), this.ddsj, this.lksj, this.yddj);
                Ffjzt_select_new.Left = this.Left + tB_fjbh.Left;
                Ffjzt_select_new.Top = this.Top + tB_fjbh.Top;
                Ffjzt_select_new.yddj_type = yddj_type;
                if (Ffjzt_select_new.ShowDialog() == DialogResult.OK)
                {
                    string fjrb_temp = tB_fjrb.Text;
                    
                    tB_fjrb.Text = Ffjzt_select_new.get_fjrb;
                    tB_fjbh.Text = Ffjzt_select_new.get_fjbh;
                    if (tB_lzfs.Text.Trim() == "")
                    {
                        tB_lzfs.Text = "1";

                    }
                    if (fjrb_temp != tB_fjrb.Text && tB_fjrb.Text!="")
                    {
                        get_gj(tB_fjrb.Text);

                    }
                }

                Ffjzt_select_new.Dispose();
                tB_fjbh.Focus();
            }
            else
                if (yddj_type == common_file.common_app.yddj_type_group)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "团体、会议不能直接在此排房！");
                }
            Cursor.Current = Cursors.Default;
        }

        private void tB_fjjg_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void Qskdj_fjrb_Load(object sender, EventArgs e)
        {
            //这里缓存一下旧的房型房号
            old_fx_sl =decimal.Parse( tB_lzfs.Text.Trim());
            old_fx = tB_fjrb.Text.Trim();

            cB_fjbm.Items.Add(common_file.common_app.fjbm_bm);
            cB_fjbm.Items.Add(common_file.common_app.fjbm_bbm);
            cB_fjbm.Text = common_file.common_app.fjbm_bbm;
            cB_shqh.Items.Add(common_file.common_app.fy_qh);
            cB_shqh.Items.Add(common_file.common_app.fy_bqh);
            cB_shqh.Text = common_file.common_app.fy_bqh;
            if (this.yddj_type == common_file.common_app.yddj_type_group)
            {
                cB_shqh.Text = common_file.common_app.fy_qh;
            }
            if (Qskdj_fjrb_id != "")
            {
                M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(Qskdj_fjrb_id));
                {
                    if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        tB_fjrb.Text = M_Qskyd_fjrb.fjrb;
                        tB_lzfs.Text = M_Qskyd_fjrb.lzfs.ToString();
                        cB_shqh.Text = M_Qskyd_fjrb.shqh.ToString();
                        tB_fjjg.Text = M_Qskyd_fjrb.fjjg.ToString();
                        tB_yh.Text = M_Qskyd_fjrb.yh;
                        yhbl = M_Qskyd_fjrb.yhbl;
                        cB_fjbm.Text = M_Qskyd_fjrb.fjbm;
                        tB_bz.Text = M_Qskyd_fjrb.bz;
                        tB_jcje.Text = M_Qskyd_fjrb.jcje.ToString();
                    }
                    tB_fjbh.Text = fjbh;
                    this.lsbh = M_Qskyd_fjrb.lsbh;
                    old_fx_sl = M_Qskyd_fjrb.lzfs;
                    old_fx = M_Qskyd_fjrb.fjrb;
                }
            }
        }

        private bool judge_kyfs(string krxm_0, string fjbh_0, string lsbh_0)
        {
            float ylfs = 0; string fjrb_old = tB_fjrb.Text;
            if (judge_add_edit == common_file.common_app.get_edit)
            {
                Model.Qskyd_fjrb M_Qskyd_fjrb_temp = B_Qskyd_fjrb.GetModel(int.Parse(Qskdj_fjrb_id));
                ylfs = float.Parse(M_Qskyd_fjrb_temp.lzfs.ToString());
                fjrb_old = M_Qskyd_fjrb_temp.fjrb;
            }
            return common_file.common_used_fjzt.judge_kyfs(judge_add_edit, yddj, tB_lzfs.Text, ylfs, fjrb_old, tB_fjrb.Text, ddsj, lksj, krxm_0, fjbh_0, lsbh_0, "");

        }
        public void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            url = common_file.common_app.service_url;
            //更新Qskyd_fqrb

            //M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(Qskdj_fjrb_id));



            if (this.tB_lzfs.Text.Trim() == "" || decimal.Parse(this.tB_lzfs.Text.Trim()) < 0)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写入住房数!");
                tB_lzfs.Focus();
                return;
            }



            if (yddj_type == common_file.common_app.yddj_type_personal)
            {
                common_file.common_app.get_czsj();
                #region 处理散客的部分

                //登记的时候
                if (this.yddj == common_file.common_yddj.yddj_dj)
                {
                    if (tB_fjrb.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择房型!");
                        tB_fjrb.Focus();
                        return;
                    }
                    if (tB_fjbh.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择房号!");
                        tB_fjbh.Focus();
                        return;
                    }

                    if (tB_lzfs.Text.Trim() == "")
                    {

                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "登记状态下请将写入住房数不能为空!");
                        tB_lzfs.Focus();
                        tB_lzfs.SelectAll();
                        return;

                    }

                    else
                    {

                        int i_1 = 3;
                        if (M_Qskyd_fjrb == null)
                        {
                            i_1 = 3;

                        }
                        else
                        {
                            if (M_Qskyd_fjrb != null && (M_Qskyd_fjrb.lzfs == 0 && (decimal.Parse(tB_lzfs.Text)) == 0))
                            {
                                i_1 = 2;
                            }
                            else
                            {
                                i_1 = 3;
                            }
                        }
                        if(i_1 == 3)
                        {

                            if ( (decimal.Parse(tB_lzfs.Text) - 1) != 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "登记状态下请将写入住房数为1!");
                                tB_lzfs.Focus();
                                tB_lzfs.SelectAll();
                                return;
                            }

                        }

                    }

                    common_file.common_app.get_czsj();
                    M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(Qskdj_fjrb_id));
                    url += "Qyddj/Qyddj_app.asmx";
                    object[] args = new object[26];
                    args[0] = Qskdj_fjrb_id;
                    args[1] = common_file.common_app.yydh;
                    args[2] = common_file.common_app.qymc;
                    args[3] = M_Qskyd_fjrb.lsbh;
                    args[4] = M_Qskyd_fjrb.krxm;
                    args[5] = M_Qskyd_fjrb.sktt;
                    args[6] = M_Qskyd_fjrb.yddj;
                    args[7] = tB_fjrb.Text.Trim().Replace("'", "_");
                    args[8] = tB_fjbh.Text.Trim().Replace("'", "_");
                    args[9] = M_Qskyd_fjrb.ddsj;
                    args[10] = M_Qskyd_fjrb.lksj;
                    if (tB_lzfs.Text.Trim() == "")
                    {
                        args[11] = 0;
                    }
                    else
                        args[11] = Convert.ToDecimal(tB_lzfs.Text.Trim().Replace("'", "_"));
                    args[12] = cB_shqh.Text.Trim().Replace("'", "_");
                    args[13] = decimal .Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_fjjg.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    args[14] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_fjjg.Text.Trim().Replace("'", "_"))*double.Parse(yhbl.ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    args[15] = tB_yh.Text.Trim().Replace("'", "_");
                    args[16] = yhbl;
                    args[17] = tB_bz.Text.Trim().Replace("'", "_");
                    args[18] = common_file.common_app.czy;
                    args[19] = DateTime.Now;
                    args[20] = common_file.common_app.chinese_edit;
                    args[21] = M_Qskyd_fjrb.yddj;//有三种状态,一种预订、一种登记、一种预订转登记
                    args[22] = judge_add_edit;
                    args[23] = common_file.common_app.xxzs;
                    args[24] = cB_fjbm.Text.Trim().Replace("'", "_");
                    args[25] = 0;
                    if(tB_jcje.Text.Trim()!="")
                    args[25] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_jcje.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()); 
                    //先判断是否超排房

                    if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        if (M_Qskyd_fjrb.fjbh != "")
                        {
                            if (decimal.Parse(args[11].ToString()) > 1)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，已经排房的记录不能直接修改房数！");
                                return;
                            }

                        }
                    }


                    if (judge_kyfs(M_Qskyd_fjrb.krxm, tB_fjbh.Text, M_Qskyd_fjrb.lsbh) == true)
                    {

                        Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edd_delete_1 Qskyd_fjrb_add_edd_delete_1_services = new Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edd_delete_1();
                        string result = Qskyd_fjrb_add_edd_delete_1_services.Qskyd_fjrb_add_edit_delete_app_1(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), DateTime.Parse(args[9].ToString()),
                            DateTime.Parse(args[10].ToString()), Decimal.Parse(args[11].ToString()), args[12].ToString(), Decimal.Parse(args[13].ToString()), Decimal.Parse(args[14].ToString()),args[15].ToString(), Decimal.Parse(args[16].ToString()), args[17].ToString(), args[18].ToString(), DateTime.Parse(args[19].ToString()), args[20].ToString(), args[21].ToString(),
                            args[22].ToString(), args[23].ToString(), args[24].ToString(), Decimal.Parse(args[25].ToString()));
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_add_edit_delete_app", args);
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_add_edit_delete_app_1", args);
                        if (result!=null&&result.ToString() == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            this.DialogResult = DialogResult.OK;
                            common_file.common_form.Qskdj_new.lsbh = M_Qskyd_fjrb.lsbh;
                            common_file.common_form.Qskdj_new.refresh_app();
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
                        }
                    }

                }
                //预订
                if (this.yddj == common_file.common_yddj.yddj_yd)
                {


                    if (decimal.Parse(this.tB_lzfs.Text.Trim()) ==0)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写入住房数!");
                        tB_lzfs.Focus();
                        return;
                    }


                    common_file.common_app.get_czsj();
                    if (tB_fjrb.Text.Trim() == "")
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择房间类型！");
                        return;
                    }
                    //新增,要判断  这种类型的房间是否有都排完
                    //修改时，类型有改变，要判断改后类型是存在未排完的
                    if (B_Qskyd_fjrb.GetModelList("yydh='" + common_file.common_app.yydh + "'  and lsbh='" + lsbh + "'  and fjbh='' and id!='" + Qskdj_fjrb_id + "' and  fjrb='" + tB_fjrb.Text + "'").Count > 0)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "此种房型已经存在，不能再重新排同种房，如有需要增加请去修改数量！");
                        return;
                    }

                    //三种情况下判断是否发送短信:
                    //旧的房型为空,当前的不为空
                    //旧的不为空，当前的不等于旧的
                    //旧的不为空，当前的数量不等于旧的预定数量
                    bool dx_fs = false;//标注短信是否发送

                    //if (( (old_fx.Trim().Equals("") && !tB_fjrb.Text.Trim().Equals("")) || (!old_fx.Trim().Equals("") && !old_fx.Equals(tB_fjrb.Text.Trim())) || (!old_fx.Trim().Equals("")&&(old_fx.Equals(tB_fjrb.Text.Trim())&&!(old_fx_sl-decimal.Parse(tB_lzfs.Text.Trim())==0)))))
                    //{
                    //    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "房型房间信息有更改,是否要提示发送短信给客人？"))
                    //    {
                    //        if (judge_add_edit.Equals(common_file.common_app.get_edit) || judge_add_edit.Equals(common_file.common_app.get_add))//修改当前的
                    //        {
                    //            dx_fs = true;
                    //            //Common_Qyddj.hy_yd_dx_tx(lsbh, tB_lzfs.Text.Remove(tB_lzfs.Text.LastIndexOf('.')), tB_fjrb.Text, false, Qskdj_fjrb_id);
                    //        }
                    //    }
                    //}




                    common_file.common_app.get_czsj();
                    url += "Qyddj/Qyddj_app.asmx";
                    object[] args = new object[26];
                    args[0] = Qskdj_fjrb_id;
                    args[1] = common_file.common_app.yydh;
                    args[2] = common_file.common_app.qymc;
                    args[3] = this.lsbh;
                    args[7] = tB_fjrb.Text.Trim().Replace("'", "_");
                    args[8] = tB_fjbh.Text.Trim().Replace("'", "_");
                    if (tB_lzfs.Text.Trim() == "")
                    {
                        args[11] = 1;
                    }
                    else
                        args[11] = Convert.ToDecimal(tB_lzfs.Text.Trim().Replace("'", "_"));
                    args[12] = cB_shqh.Text.Trim().Replace("'", "_");
                    if (yhbl == 0) { yhbl = 1; }
                    args[13] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_fjjg.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    args[14] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_fjjg.Text.Trim().Replace("'", "_")) * double.Parse(yhbl.ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    args[15] = tB_yh.Text.Trim().Replace("'", "_");
                    args[16] = yhbl;
                    args[17] = tB_bz.Text.Trim().Replace("'", "_");
                    args[18] = common_file.common_app.czy;
                    args[19] = DateTime.Now;
                    args[20] = common_file.common_app.chinese_edit;
                    args[22] = judge_add_edit;
                    args[23] = common_file.common_app.xxzs;
                    args[24] = cB_fjbm.Text.Trim().Replace("'", "_");
                    args[25] = 0;
                    if (tB_jcje.Text.Trim() != "")
                        args[25] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_jcje.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString()); 
                    //由于这里在fjrb表里面的记录会被删除掉，所以当找不到时改用主单记录里面的信息
                    if (B_Qskyd_fjrb.GetModelList("lsbh='" + this.lsbh + "'").Count > 0)
                    {
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("lsbh='" + this.lsbh + "'")[0];
                        args[4] = M_Qskyd_fjrb.krxm;
                        args[5] = M_Qskyd_fjrb.sktt;
                        args[6] = M_Qskyd_fjrb.yddj;
                        args[9] = M_Qskyd_fjrb.ddsj;
                        args[10] = M_Qskyd_fjrb.lksj;
                        args[21] = M_Qskyd_fjrb.yddj;//有三种状态,一种预订、一种登记、一种预订转登记

                    }
                    //如果找不到当前临时编号在fjrb表里面对应的记录，直接找lsbh对应的主单记录
                    else
                    {
                        M_qskyd_mainrecord_temp = B_qskyd_mainrecord_temp.GetModelList("lsbh='" + this.lsbh + "'")[0];
                        args[4] = M_qskyd_mainrecord_temp.krxm;
                        args[5] = M_qskyd_mainrecord_temp.sktt;
                        args[6] = M_qskyd_mainrecord_temp.yddj;
                        args[9] = M_qskyd_mainrecord_temp.ddsj;
                        args[10] = M_qskyd_mainrecord_temp.lksj;
                        args[21] = M_qskyd_mainrecord_temp.yddj;//有三种状态,一种预订、一种登记、一种预订转登记
                    }

                    if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        if (Qskdj_fjrb_id != "")
                        {
                            M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(Qskdj_fjrb_id));
                            if (M_Qskyd_fjrb != null)
                            {
                                if (M_Qskyd_fjrb.fjbh != "")
                                {
                                    if (decimal.Parse(args[11].ToString()) > 1)
                                    {
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，已经排房的记录不能直接修改房数！");
                                        return;
                                    }

                                }
                            }
                        }
                    }



                    //先判断是否超排房
                    if (judge_kyfs(M_Qskyd_fjrb.krxm, tB_fjbh.Text, M_Qskyd_fjrb.lsbh) == true)
                    {
                        Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edd_delete_1 Qskyd_fjrb_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edd_delete_1();

                        string result = Qskyd_fjrb_add_edit_delete_services.Qskyd_fjrb_add_edit_delete_app_1(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(),DateTime.Parse( args[9].ToString()),
                            DateTime.Parse( args[10].ToString()),decimal.Parse( args[11].ToString()),args[12].ToString(), Decimal.Parse(args[13].ToString()), Decimal.Parse(args[14].ToString()),args[15].ToString(), Decimal.Parse(args[16].ToString()), args[17].ToString(),args[18].ToString(),DateTime.Parse(args[19].ToString()), args[20].ToString(), args[21].ToString(),
                             args[22].ToString(), args[23].ToString(), args[24].ToString(), Decimal.Parse(args[25].ToString()));



                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_add_edit_delete_app_1", args);
                        if (result.ToString() == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            this.DialogResult = DialogResult.OK;

                            //成功后，调用短信发送
                            if (dx_fs)//如果选择发送短信
                            {
                                BLL.Common B_common = new Hotel_app.BLL.Common();
                                DataSet ds_dx_zd = B_common.GetList(" select  *  from   View_Qskzd  ", " lsbh='" + lsbh + "'  and    yddj='" + common_file.common_yddj.yddj_yd + "'  and    krsj!=''    and   main_sec='" + common_file.common_app.main_sec_main + "'   ");
                                string phoneNo = ""; bool check_phone = false;
                                if (ds_dx_zd != null && ds_dx_zd.Tables[0].Rows.Count > 0)
                                {
                                    phoneNo = ds_dx_zd.Tables[0].Rows[0]["krsj"].ToString();
                                    check_phone = System.Text.RegularExpressions.Regex.IsMatch(phoneNo, @"^[1]+[3,4,5,6,8]+\d{9}");
                                    if (!check_phone)
                                    {
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前预订人的手机号不正确,请修正预订人的手机号系统才能即时发送短信提醒！");
                                    }
                                }



                                BLL.Common B_common00 = new Hotel_app.BLL.Common();
                                DataSet ds_dx = B_common00.GetList(" select * from  Qskyd_fjrb  ", "  id>=0  and    lsbh in (select lsbh from Qskyd_mainrecord  where lsbh='" + lsbh + "'  and  yddj='" + common_file.common_yddj.yddj_yd + "')  ");
                                if (ds_dx != null && ds_dx.Tables[0].Rows.Count > 0)
                                {
                                    StringBuilder sb = new StringBuilder();
                                    for (int i = 0; i < ds_dx.Tables[0].Rows.Count; i++)
                                    {
                                        if (ds_dx.Tables[0].Rows[i]["fjrb"].ToString().Length > 0)
                                        {
                                            if (sb.ToString().Length > 0)
                                            { sb.Append(","); }
                                            string lzfs_fs = ds_dx.Tables[0].Rows[i]["lzfs"].ToString();
                                            try
                                            {
                                                 lzfs_fs=lzfs_fs.Remove(lzfs_fs.LastIndexOf('.'));
                                            }
                                            catch
                                            {
                                                //lzfs_fs=lzfs_fs;
                                            }
                                            sb.Append(DateTime.Parse(ds_dx.Tables[0].Rows[i]["ddsj"].ToString()).ToShortDateString() + ds_dx.Tables[0].Rows[i]["fjrb"].ToString() + lzfs_fs + "间");
                                        }
                                    }
                                    if (!sb.ToString().Equals("") && check_phone)
                                    {
                                        //Hotel_app.Hhygl_app.Hhygl_app Hhygl_app_services_new = new Hotel_app.Server.Hhygl_app.Hhygl_app();
                                        //Hhygl_app_services_new.Url = common_file.common_app.service_url + "Hhygl/Hhygl_app.asmx";
                                        Hotel_app.Server.Hhygl.Hhygl_verifyCode Hhygl_verifyCode_services = new Hotel_app.Server.Hhygl.Hhygl_verifyCode();

                                        string ss = Hhygl_verifyCode_services.Hhygl_SendMsm(phoneNo, sb.ToString(), common_file.common_app.yydh, "", common_file.common_hyAction.hy_Action_ydxg, "", "", "", "", "", "", common_file.common_app.xxzs);
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "系统修改当前会员的预订单成功,并己经自动将房型及房数以短信告知客人！");
                                        //MessageBox.Show(sb.ToString());
                                    }

                                }

                            
                            }


                            common_file.common_form.Qskdj_new.lsbh = this.lsbh;
                            common_file.common_form.Qskdj_new.refresh_app();
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, result.ToString());
                        }
                    }
                }
                #endregion
            }

            if (yddj_type == common_file.common_app.yddj_type_group)
            {



                if (this.tB_lzfs.Text.Trim() == "")
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写入住房数!");
                    tB_lzfs.Focus();
                    return;
                }


                common_file.common_app.get_czsj();
                #region 处理团体的部分_初始房态（fjbh='')
                if (tB_fjbh.Text.Trim() == "")
                {

                    if (tB_fjrb.Text.Trim() == "")//是否有选房型
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择房型!");
                        tB_fjrb.Focus();
                        return;
                    }
                    if (this.tB_lzfs.Text.Trim() == "" || decimal.Parse(this.tB_lzfs.Text.Trim()) < 0)//是否有写入住房数
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请填写入住房数!");
                        tB_lzfs.Focus();
                        return;
                    }
                    //新增时要先判断（第一是否有空记录，第二步要判断是否有存在相同类别未排房的记录）
                    if (judge_add_edit == common_file.common_app.get_add)
                    {
                        if (B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'  and  fjbh='' and  fjrb=''").Count > 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "存在空记录，请先修改!");
                            return;
                        }
                        if (B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'  and fjbh=''  and   fjrb='" + this.tB_fjrb.Text.Trim() + "'").Count > 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "同种房类以经存在，请直接修改数量!");
                            return;
                        }
                    }
                    //修改时，判断，修改后的类型是否当前以经存在
                    if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        if (B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'  and fjbh=''  and   fjrb='" + this.tB_fjrb.Text.Trim() + "' and id!='" + Qskdj_fjrb_id + "'").Count > 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "修改的房间类型以经存在，请直接修改数量");
                            return;
                        }
                    }
                    common_file.common_app.get_czsj();
                    url += "Qyddj/Qyddj_app.asmx";
                    object[] args = new object[26];
                    args[0] = Qskdj_fjrb_id;
                    args[1] = common_file.common_app.yydh;
                    args[2] = common_file.common_app.qymc;
                    args[3] = this.lsbh;
                    args[4] = M_Qskyd_fjrb.krxm;
                    args[5] = M_Qskyd_fjrb.sktt;
                    args[6] = M_Qskyd_fjrb.yddj;
                    args[7] = tB_fjrb.Text.Trim().Replace("'", "_");
                    args[8] = "";
                    args[9] = M_Qskyd_fjrb.ddsj;
                    args[10] = M_Qskyd_fjrb.lksj;
                    if (tB_lzfs.Text.Trim() == "")
                    {
                        args[11] = 0;
                    }
                    else
                        args[11] = Convert.ToDecimal(tB_lzfs.Text.Trim().Replace("'", "_"));
                    args[12] = cB_shqh.Text.Trim().Replace("'", "_");
                    args[13] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_fjjg.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    args[14] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_fjjg.Text.Trim().Replace("'", "_")) * double.Parse(yhbl.ToString()), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    args[15] = tB_yh.Text.Trim().Replace("'", "_");
                    args[16] = yhbl;
                    args[17] = tB_bz.Text.Trim().Replace("'", "_");
                    args[18] = common_file.common_app.czy;
                    args[19] = DateTime.Now;
                    args[20] = common_file.common_app.chinese_edit;
                    args[21] = M_Qskyd_fjrb.yddj;//有三种状态,一种预订、一种登记、一种预订转登记
                    args[22] = judge_add_edit;
                    args[23] = common_file.common_app.xxzs;
                    args[24] = cB_fjbm.Text.Trim().Replace("'", "_");
                    args[25] = 0;
                    if (tB_jcje.Text.Trim() != "")
                        args[25] = decimal.Parse(common_file.common_sswl.Round_sswl(double.Parse(tB_jcje.Text.Trim().Replace("'", "_")), common_file.common_sswl.sswl_ws, common_file.common_sswl.selectMode_sel).ToString());
                    if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        if (M_Qskyd_fjrb.fjbh != "")
                        {
                            if (decimal.Parse(args[11].ToString()) > 1)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，已经排房的记录不能直接修改房数！");
                                return;
                            }

                        }
                    }
                    
                    
                    
                    //先判断是否超排房
                    if (judge_kyfs(args[4].ToString(), "", args[3].ToString()) == true)
                    {
                        Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete();

                        string result = Qskyd_fjrb_add_edit_delete_services.Qskyd_fjrb_add_edit_delete_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), DateTime.Parse(args[9].ToString()),
                            DateTime.Parse(args[10].ToString()), Decimal.Parse(args[11].ToString()),args[12].ToString(), Decimal.Parse(args[13].ToString()), Decimal.Parse(args[14].ToString()),args[15].ToString(),Decimal.Parse(args[16].ToString()), args[17].ToString(), args[18].ToString(),DateTime.Parse(args[19].ToString()), args[20].ToString(), args[21].ToString(),args[22].ToString(), args[23].ToString(), args[24].ToString(), Decimal.Parse(args[25].ToString()));
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_add_edit_delete_app", args);

                        if (result.ToString() == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                            this.DialogResult = DialogResult.OK;
                            common_file.common_form.Qttdj_new.lsbh = this.lsbh;
                            //common_file.common_form.Qttdj_new.add_edit = "";
                            common_file.common_form.Qttdj_new.RefreshApp();
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, result.ToString());
                        }
                    }
                }

                #endregion
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_yh_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xyh_select Xyh_select_new = new Hotel_app.Xxtsz.Xyh_select();
            Xyh_select_new.Left = this.Left + btn_yh.Left;
            Xyh_select_new.Top = this.Top + btn_yh.Top;
            if (Xyh_select_new.ShowDialog() == DialogResult.OK)
            {
                tB_yh.Text = Xyh_select_new.get_yh;
                yhbl = Convert.ToDecimal(Xyh_select_new.get_yhbl);
            }
            Xyh_select_new.Dispose();
            tB_yh.Focus();
            Cursor.Current = Cursors.Default;
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

        private void btn_ydpf_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();

            if (tB_fjrb.Text.Trim() == "" || (tB_fjrb.Text != "" && judge_add_edit != common_file.common_app.get_edit))
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先初始化房间类型再排房");
                return;
            }
            if (M_Qskyd_fjrb.fjrb != tB_fjrb.Text.Trim())
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先初始化房间类型再排房");
                return;
            }
            Ffjzt.Ffjzt_select Ffjzt_select_new = new Hotel_app.Ffjzt.Ffjzt_select(tB_fjrb.Text.Trim(), this.ddsj, this.lksj, this.yddj);
            Ffjzt_select_new.Left = this.Left + tB_fjbh.Left;
            Ffjzt_select_new.Top = this.Top + tB_fjbh.Top;
            Ffjzt_select_new.yddj_type = yddj_type;
            //给团体多间排房的参数赋值
            Ffjzt_select_new.tt_Qskdy_fjrb_id = this.Qskdj_fjrb_id;
            Ffjzt_select_new.tt_fjrb = tB_fjrb.Text.Trim();
            Ffjzt_select_new.tt_fjjg = tB_fjjg.Text.Trim();
            Ffjzt_select_new.tt_lsbh = this.lsbh;
            Ffjzt_select_new.tt_shqh = cB_shqh.Text.Trim();
            Ffjzt_select_new.tt_yh = tB_yh.Text.Trim();
            Ffjzt_select_new.tt_lzfs = tB_lzfs.Text.Trim();
            Ffjzt_select_new.tt_bz = tB_bz.Text.Trim();

            
            if (Ffjzt_select_new.ShowDialog() == DialogResult.OK)
            {
                if (Ffjzt_select_new.sh_ttpf != "tt")
                {
                    tB_fjrb.Text = Ffjzt_select_new.get_fjrb;
                    tB_fjbh.Text = Ffjzt_select_new.get_fjbh;
                }
                else 
                {
                    this.Close();
                    this.Dispose();
                }
            }
            Ffjzt_select_new.Close();
            Ffjzt_select_new.Dispose();
            Cursor.Current = Cursors.Default;
        }

        private void tB_lzfs_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void tB_jcje_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }

        private void tB_yh_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.return_KeyPress(sender, e);
        }
    }
}