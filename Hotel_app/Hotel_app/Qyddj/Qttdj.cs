using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Qttdj : Form
    {
        public Qttdj()
        {
            InitializeComponent();
            initalApp();
        }

        #region Variables
        //固定值区
        public string czy = common_file.common_app.czy;
        public string jzbh = "";
        public string yddj = "";
        public string add_edit = "";
        public string Qttdj_id = "";
        public string lsbh = "";
        public string xyh = "";   //协议号
        public string ddbh = "";
        public string lsbh_temp = "";
        public string cznr = common_file.common_app.get_add;                   //用于数据库
        public string cznr_chinese = common_file.common_app.chinese_add;  //用于显示
        public Fmain FrmParent;
        public DataSet Ds_fjfx;
        public DataSet Ds_cy_detail;
        public int dg_count_cy = 0;

        public Hotel_app.Model.Qttyd_mainrecord M_Qttyd_mainrecord = null;
        public Hotel_app.BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
        public Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb;
        public Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        public Hotel_app.BLL.Common B_common = new Hotel_app.BLL.Common();
        Model.Qttyd_mainrecord_bak M_Qttyd_mainrecord_bak = null;

        #endregion


        /// <summary>
        /// 初始化数据
        /// </summary>
        void re_clear()
        {
            jzbh = "";
            lsbh = "";
            xyh = "";   //协议号
            ddbh = "";
            lsbh_temp = "";                  //用于数据库
            dg_count_cy = 0;
        }
        /// <summary>
        /// 历史记录
        /// </summary>
        bool his_remind()
        {
            bool result_0 = false;
            if (add_edit == common_file.common_app.get_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前处于历史查看状态，只能看不能操作！");
                result_0 = true;
            }
            return result_0;
        }


        public void set_remind_tb_color()
        {
            tB_krxm.ForeColor = Color.Black;
            tB_qtyq.ForeColor = Color.Black;
            tB_tsyq.ForeColor = Color.Black;

        }


        #region CommonFuction
        public void initalApp()
        {
            dg_fjrb.AutoGenerateColumns = false;
            dg_Qttdj_detail.AutoGenerateColumns = false;
            tB_czy.Text = common_file.common_app.czy;
            tB_czsj.Text = DateTime.Now.ToString();
            tB_yddj.ReadOnly = true;
            tB_zwye_0.ReadOnly = true;
            tB_czy.ReadOnly = true;
            tB_cznr.ReadOnly = true;
            tB_czsj.ReadOnly = true;


        }

        //dgv的加载或者刷新
        public void RefreshApp()
        {
            common_file.common_app.get_czsj();
            B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            B_common = new Hotel_app.BLL.Common();
            string temp_str = "SELECT dbo.Qskyd_mainrecord.id,dbo.Qskyd_mainrecord.yddj,dbo.Qskyd_fjrb.krxm, dbo.Qskyd_fjrb.sktt, dbo.Qskyd_fjrb.yddj,dbo.Qskyd_fjrb.fjrb, dbo.Qskyd_fjrb.fjbh, dbo.Qskyd_fjrb.shqh, dbo.Qskyd_fjrb.sjfjjg,dbo.Qskyd_fjrb.yh, dbo.Qskyd_mainrecord.zjhm, dbo.Qskyd_mainrecord.krsj,dbo.Qskyd_mainrecord.ddbh, dbo.Qskyd_mainrecord.lsbh FROM dbo.Qskyd_fjrb,dbo.Qskyd_mainrecord";
            Ds_fjfx = B_Qskyd_fjrb.GetList("ID>=0  and yydh='" + common_file.common_app.yydh + "'   and  lsbh='" + lsbh + "'  order by fjrb");
            Ds_cy_detail = B_common.GetList(temp_str, "dbo.Qskyd_fjrb.lsbh = dbo.Qskyd_mainrecord.lsbh  and Qskyd_mainrecord.ddbh='" + ddbh + "'  and  Qskyd_mainrecord.yydh='" + common_file.common_app.yydh + "'  and  Qskyd_mainrecord.main_sec='" + common_file.common_app.main_sec_main + "'");
            bindingSource_cy_Detail.DataSource = Ds_cy_detail.Tables[0];
            dg_count_cy = Ds_cy_detail.Tables[0].Rows.Count;
            bindingSource_fxfj.DataSource = Ds_fjfx.Tables[0];
            dg_Qttdj_detail.DataSource = bindingSource_cy_Detail;
            dg_fjrb.DataSource = bindingSource_fxfj;
            GetFxfj_tj();



        }

        public void loadInfo(string id_0, string yddj, string add_edit, Fmain frmparent)
        {
            set_remind_tb_color();
            this.Qttdj_id = id_0;
            this.yddj = yddj;
            this.add_edit = add_edit;
            SetFormText(this.yddj, this.add_edit);
            B_Qttyd_mainrecord = new Hotel_app.BLL.Qttyd_mainrecord();
            //加载修改
            if (Qttdj_id != "")
            {
                M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(Qttdj_id));
                M_Qskyd_fjrb = B_Qskyd_fjrb.GetModelList("lsbh='" + M_Qttyd_mainrecord.lsbh + "'")[0];
                Modify_Inital();
                lsbh = M_Qttyd_mainrecord.lsbh;  //生成房间房型
                ddbh = M_Qttyd_mainrecord.ddbh;//生成成员
                Common_Qyddj.Qttyd_remind(lsbh);








                // 





            }
            ////加载新增
            if (Qttdj_id == "")
            {
                add_inital();
                re_clear();
            }

            if (yddj == common_file.common_yddj.yddj_yd)
            {
                b_ydzdj.Visible = true;
                b_ydzdj.Left = 243; b_ydzdj.Top = 5;
                b_Save.Left = 290; b_Save.Top = 5;
                b_zwcl.Left = 335; b_zwcl.Top = 5;
            }
            else
            {
                b_ydzdj.Visible = false;
                b_Save.Left = 243; b_Save.Top = 5;
                b_zwcl.Left = 291; b_zwcl.Top = 5;


                //更新20120615,新增排房提醒(没有排完全就提醒其修改)
                //if (Ds_fjfx != null && Ds_fjfx.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < Ds_fjfx.Tables[0].Rows.Count; i++)
                //    {
                //        if (float.Parse(Ds_fjfx.Tables[0].Rows[i]["lzfs"].ToString()) - 1 > 0&&Ds_fjfx.Tables[0].Rows[i]["fjrb"].ToString().Trim() !="")
                //        {
                //            common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前存在没有排完房的记录！如果确认不再排房请把入住房数修改为0，否则将引起分析预计占用房数和预计总房费的出错！");

                //        }
                //    }

                //}





            }
            czjl("", add_edit);


        }

        private void LoadGridViews(string Qttyd_id)
        {
            //
            if (Qttyd_id == "")
            {
                dg_fjrb.DataSource = null;
                dg_Qttdj_detail.DataSource = null;
            }
            else
                if (Qttdj_id != "")
                {
                    RefreshApp();
                }
        }
        //打开历史记录
        public void open_his(string id_0, string add_edit_flage)
        {
            add_edit = add_edit_flage;

            if (yddj == common_file.common_yddj.yddj_yd)
            {
                b_ydzdj.Visible = true;
                b_ydzdj.Left = 253; b_ydzdj.Top = 2;
                b_Save.Left = 311; b_Save.Top = 2;
                b_zwcl.Left = 371; b_zwcl.Top = 2;
            }
            else
            {
                b_ydzdj.Visible = false;
                b_Save.Left = 253; b_Save.Top = 2;
                b_zwcl.Left = 311; b_zwcl.Top = 2;

            }


            if (id_0 != "")
            {




                BLL.Qttyd_mainrecord_bak B_Qttyd_mainrecord_bak = new Hotel_app.BLL.Qttyd_mainrecord_bak();
                M_Qttyd_mainrecord_bak = B_Qttyd_mainrecord_bak.GetModel(int.Parse(id_0));
                if (M_Qttyd_mainrecord_bak != null)
                {
                    #region 主要信息
                    jzbh = M_Qttyd_mainrecord_bak.jzbh;
                    ddbh = M_Qttyd_mainrecord_bak.ddbh;
                    lsbh = M_Qttyd_mainrecord_bak.lsbh;
                    tB_krxm.Text = M_Qttyd_mainrecord_bak.krxm;
                    tB_ttbh.Text = M_Qttyd_mainrecord_bak.krbh;
                    tB_ydrxm.Text = M_Qttyd_mainrecord_bak.ydrxm;
                    xyh = M_Qttyd_mainrecord_bak.xyh;
                    tB_krgj.Text = M_Qttyd_mainrecord_bak.krgj;
                    tB_krdh.Text = M_Qttyd_mainrecord_bak.krdh;
                    tB_krsj.Text = M_Qttyd_mainrecord_bak.krsj;
                    tB_krEmail.Text = M_Qttyd_mainrecord_bak.krEmail;
                    tB_krdz.Text = M_Qttyd_mainrecord_bak.krdz;
                    tB_krly.Text = M_Qttyd_mainrecord_bak.krly;
                    tB_xydw.Text = M_Qttyd_mainrecord_bak.xydw;
                    tB_xsy.Text = M_Qttyd_mainrecord_bak.xsy;
                    tB_yddj.Text = M_Qttyd_mainrecord_bak.yddj;
                    #endregion

                    #region 抵达时间
                    //tB_lzts.Text = M_Qttyd_mainrecord.lzts.ToString();
                    dT_ddsj_date.Text = Convert.ToDateTime(M_Qttyd_mainrecord_bak.ddsj).Date.ToString();
                    dT_ddsj_time.Text = Convert.ToDateTime(M_Qttyd_mainrecord_bak.ddsj).TimeOfDay.ToString();
                    dT_lksj_date.Text = Convert.ToDateTime(M_Qttyd_mainrecord_bak.lksj).Date.ToString();
                    dT_lksj_time.Text = Convert.ToDateTime(M_Qttyd_mainrecord_bak.lksj).TimeOfDay.ToString();
                    if (M_Qttyd_mainrecord_bak.ddrx != null)
                    {
                        cB_ddrx.Text = "";
                    }
                    else
                    {
                        cB_ddrx.Text = M_Qttyd_mainrecord_bak.ddrx;
                    }
                    tB_ddwz.Text = M_Qttyd_mainrecord_bak.ddwz;


                    tB_zwye_0.Text = "0";
                    DataSet DS_temp_0 = B_common.GetList("select xfje,fkje from Szwzd_bak", "lsbh='" + M_Qttyd_mainrecord_bak.lsbh + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        tB_zwye_0.Text = Convert.ToString(float.Parse(DS_temp_0.Tables[0].Rows[0]["fkje"].ToString()) - float.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString()));
                    }
                    DS_temp_0.Clear();
                    DS_temp_0.Dispose();


                    cB_ddly.Text = M_Qttyd_mainrecord_bak.ddly;
                    tB_yddj.Text = this.yddj;
                    #endregion

                    #region 其它要求
                    tB_qtyq.Text = M_Qttyd_mainrecord_bak.qtyq;
                    #endregion

                    #region 特殊要求
                    tB_tsyq.Text = M_Qttyd_mainrecord_bak.tsyq;

                    #endregion

                    #region 操作时间
                    tB_czy.Text = M_Qttyd_mainrecord_bak.czy;
                    tB_cznr.Text = M_Qttyd_mainrecord_bak.cznr;
                    tB_czsj.Text = M_Qttyd_mainrecord_bak.czsj.ToString();
                    #endregion
                    DataSet DS_temp_9 = B_common.GetList("select * from Qskyd_fjrb_bak", "lsbh='" + lsbh + "'");
                    bindingSource_fxfj.DataSource = DS_temp_9.Tables[0];

                    DS_temp_9 = B_common.GetList("select * from VIEW_Qskyd_bak", "ddbh='" + ddbh + "' and main_sec='" + common_file.common_app.main_sec_main + "'");
                    bindingSource_cy_Detail.DataSource = DS_temp_9.Tables[0];


                    //新增2012  06-28
                    czjl("", add_edit);

                    DS_temp_9.Dispose();


                }

            }

        }

        //修改初始化
        private void Modify_Inital()
        {
            if (M_Qttyd_mainrecord != null)
            {

                #region 主要信息
                ddbh = M_Qttyd_mainrecord.ddbh;
                lsbh = M_Qttyd_mainrecord.lsbh;
                tB_krxm.Text = M_Qttyd_mainrecord.krxm;
                tB_ttbh.Text = M_Qttyd_mainrecord.krbh;
                tB_ydrxm.Text = M_Qttyd_mainrecord.ydrxm;
                xyh = M_Qttyd_mainrecord.xyh;
                tB_krgj.Text = M_Qttyd_mainrecord.krgj;
                tB_krdh.Text = M_Qttyd_mainrecord.krdh;
                tB_krsj.Text = M_Qttyd_mainrecord.krsj;
                tB_krEmail.Text = M_Qttyd_mainrecord.krEmail;
                tB_krdz.Text = M_Qttyd_mainrecord.krdz;
                tB_krly.Text = M_Qttyd_mainrecord.krly;
                tB_xydw.Text = M_Qttyd_mainrecord.xydw;
                tB_xsy.Text = M_Qttyd_mainrecord.xsy;
                #endregion

                #region 抵达时间
                //tB_lzts.Text = M_Qttyd_mainrecord.lzts.ToString();
                dT_ddsj_date.Text = Convert.ToDateTime(M_Qttyd_mainrecord.ddsj).Date.ToString();
                dT_ddsj_time.Text = Convert.ToDateTime(M_Qttyd_mainrecord.ddsj).TimeOfDay.ToString();
                dT_lksj_date.Text = Convert.ToDateTime(M_Qttyd_mainrecord.lksj).Date.ToString();
                dT_lksj_time.Text = Convert.ToDateTime(M_Qttyd_mainrecord.lksj).TimeOfDay.ToString();
                if (M_Qttyd_mainrecord.ddrx != null)
                {
                    cB_ddrx.Text = "";
                }
                else
                {
                    cB_ddrx.Text = M_Qttyd_mainrecord.ddrx;
                }
                tB_ddwz.Text = M_Qttyd_mainrecord.ddwz;


                tB_zwye_0.Text = "0";
                DataSet DS_temp_0 = B_common.GetList("select xfje,fkje from Szwzd", "lsbh='" + M_Qttyd_mainrecord.lsbh + "'");
                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                {
                    tB_zwye_0.Text = Convert.ToString(float.Parse(DS_temp_0.Tables[0].Rows[0]["fkje"].ToString()) - float.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString()));
                }
                DS_temp_0.Clear();
                DS_temp_0.Dispose();


                cB_ddly.Text = M_Qttyd_mainrecord.ddly;
                tB_yddj.Text = this.yddj;
                #endregion

                #region 其它要求
                tB_qtyq.Text = M_Qttyd_mainrecord.qtyq;
                #endregion

                #region 特殊要求
                tB_tsyq.Text = M_Qttyd_mainrecord.tsyq;

                #endregion

                #region 操作时间
                tB_czy.Text = common_file.common_app.czy;
                tB_cznr.Text = common_file.common_app.chinese_edit;
                tB_czsj.Text = DateTime.Now.TimeOfDay.ToString();
                #endregion

                #region 操作时间

                #endregion
            }
        }

        //设置窗体的Text
        public void SetFormText(string yddj, string add_edit)
        {
            if (yddj == common_file.common_yddj.yddj_yd && add_edit == common_file.common_app.get_add)
            {
                common_file.common_form.Qttdj_new.Text = "新增团体预订";
            }
            if (yddj == common_file.common_yddj.yddj_dj && add_edit == common_file.common_app.get_add)
            {
                common_file.common_form.Qttdj_new.Text = "新增团体登记";
            }
            if (yddj == common_file.common_yddj.yddj_yd && add_edit == common_file.common_app.get_edit)
            {
                common_file.common_form.Qttdj_new.Text = "团体预订查询";
            }
            if (yddj == common_file.common_yddj.yddj_dj && add_edit == common_file.common_app.get_edit)
            {
                common_file.common_form.Qttdj_new.Text = "团体登记查询";
            }
            if (add_edit == common_file.common_app.get_his)
            {
                common_file.common_form.Qttdj_new.Text = "查看历史记录";
            }

        }

        //新增时清空TB的值
        public void add_inital()
        {
            set_remind_tb_color();
            tB_cznr.Text = common_file.common_app.chinese_add;
            common_file.common_app.get_czsj();
            common_file.common_ClearControlsValue.ClearControlsValue(p_mainInfo, new string[] { });
            xyh = "";
            tB_krgj.Text = common_file.common_app.krgj_zg;
            common_file.common_ClearControlsValue.ClearControlsValue(Panel_ddsj, new string[] { "dT_ddsj_time", "dT_lksj_time" });
            tB_tsyq.Text = "";
            tB_qtyq.Text = "";
            dT_ddsj_date.Value = DateTime.Now;
            dT_ddsj_time.Value = DateTime.Now;
            dT_lksj_date.Value = DateTime.Now.AddDays(1);
            dT_lksj_time.Value = DateTime.Now;
            //tB_lzts.Text = "0";
            cB_ddrx.Text = "";
            cB_ddly.Text = cB_ddly.Items[0].ToString();
            dg_Qttdj_detail.DataSource = null;
            dg_fjrb.DataSource = null;
        }

        #endregion
        //检查手机是否正确
        private void tB_krsj_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_addOtherCustomer_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                return;
            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_ydzdj", common_file.common_app.user_type) == false)
                    { return; }
                }
            }

            if (his_remind() == true)
            {
                return;
            }
            common_file.common_app.get_czsj();
            if (add_edit == common_file.common_app.get_edit && yddj == common_file.common_yddj.yddj_yd)//新增
            {
                Qyddj_ydzdj Qyddj_ydzdj_new = new Qyddj_ydzdj();
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                DataSet ds_temp = B_Common.GetList("select * from Qttyd_mainrecord", " lsbh='" + lsbh + "' and yddj='" + common_file.common_yddj.yddj_yd + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    common_file.common_app.get_czsj();
                    
　         
                    　　　　



                    if (Qyddj_ydzdj_new.ydzdj(M_Qttyd_mainrecord.lsbh, "", M_Qttyd_mainrecord.ddbh, "tt") == true)
                    {
                        yddj = common_file.common_yddj.yddj_dj;
                        loadInfo(Qttdj_id, yddj, common_file.common_app.get_edit, common_file.common_form.Fmain_new);
                        if (common_file.common_form.Qttdj_browse_new != null)
                        {
                            common_file.common_form.Qttdj_browse_new.loadInfo(yddj, common_file.common_form.Fmain_new);
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;

        }

        private void b_New_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_tt_dj_xz", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_xz", common_file.common_app.user_type) == false)
                    { return; }

                }
            }



            if (his_remind() == true)
            {
                return;
            }
            add_edit = common_file.common_app.get_add;
            int judge = 3;
            if (tB_yddj.Text.Trim() == "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "对不起，您之前的订单没有保存，是否确定要重新增加主单！") == true)
                {
                    judge = 2;
                }
                else
                {
                    return;
                }
            }
            judge = 2;
            if (judge == 2)
            {
                add_inital();
                if (add_edit == common_file.common_app.get_add)
                { czjl(" and  1=2  ", add_edit); }
            }

        }

        private void b_Amend_Click(object sender, EventArgs e)
        {

        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_tt_dj_save", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_save", common_file.common_app.user_type) == false)
                    { return; }

                }
            }




            if (his_remind() == true)
            {
                return;
            }
            common_file.common_app.get_czsj();
            if (add_edit == common_file.common_app.get_add || add_edit == common_file.common_app.get_edit)
            {
                if (get_judge_void_local(yddj) == true)//判断输入框是否为空
                {
                    string dt_former = dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Text;
                    string dt_later = dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Text;
                    if (common_file.common_app.CheckTime(dt_former, dt_later) == true)
                    {
                        common_file.common_app.get_czsj();
                        Save_mainrecord();
                    }
                }
            }
            if (add_edit == common_file.common_app.get_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，历史记录只用来查看！");
            }
            Cursor.Current = Cursors.Default;
        }

        private bool judge_kyfs(string krxm_0, string fjbh_0, string lsbh_0)
        {

            float ylfs = 0; float xzfs = 0;
            bool get_true = true;

            DateTime ddsj_app = DateTime.Parse(common_file.common_app.cssj);
            DateTime lksj_app = DateTime.Parse(common_file.common_app.cssj);

            DataSet DS_temp_1;
            DS_temp_1 = B_common.GetList("select sum(lzfs) as lzfs,fjrb from Qskyd_fjrb", "lsbh='" + lsbh_0 + "' and fjrb<>'' group by fjrb");
            for (int j_temp_1 = 0; j_temp_1 < DS_temp_1.Tables[0].Rows.Count; j_temp_1++)
            {

                //if (M_Qttyd_mainrecord.ddsj != DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) || M_Qttyd_mainrecord.lksj != DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()))
                //如果到达时间往前改就要判断前面的时间是否会与别人冲突

                if (DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) < M_Qttyd_mainrecord.ddsj)
                {
                    ylfs = 0; xzfs = float.Parse(DS_temp_1.Tables[0].Rows[j_temp_1]["lzfs"].ToString());
                    ddsj_app = DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString());
                    lksj_app = M_Qttyd_mainrecord.ddsj;
                    if (DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()) < M_Qttyd_mainrecord.ddsj)
                    { lksj_app = DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()); }
                    get_true = common_file.common_used_fjzt.judge_kyfs(add_edit, yddj, xzfs.ToString(), ylfs, DS_temp_1.Tables[0].Rows[j_temp_1]["fjrb"].ToString(), DS_temp_1.Tables[0].Rows[j_temp_1]["fjrb"].ToString(), ddsj_app, lksj_app, krxm_0, fjbh_0, lsbh_0, " 抵时调前");
                }
                if (get_true == true)
                {
                    if (DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()) > M_Qttyd_mainrecord.lksj)
                    {
                        ylfs = 0; xzfs = float.Parse(DS_temp_1.Tables[0].Rows[j_temp_1]["lzfs"].ToString());
                        ddsj_app = M_Qttyd_mainrecord.lksj;
                        if (DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) > M_Qttyd_mainrecord.lksj)
                        {
                            ddsj_app = DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString());
                        }
                        lksj_app = DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString());
                        get_true = common_file.common_used_fjzt.judge_kyfs(add_edit, yddj, xzfs.ToString(), ylfs, DS_temp_1.Tables[0].Rows[j_temp_1]["fjrb"].ToString(), DS_temp_1.Tables[0].Rows[j_temp_1]["fjrb"].ToString(), ddsj_app, lksj_app, krxm_0, fjbh_0, lsbh_0, " 离时调后");
                    }

                }


            }
            DS_temp_1.Dispose();

            return get_true;
        }



        private void Save_mainrecord()
        {
            common_file.common_app.get_czsj();
            string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";

            //状态为空的时候(为新增记录),生成临时编号
            if (add_edit == common_file.common_app.get_add && tB_yddj.Text.Trim() == "")
            {


                if (yddj == common_file.common_yddj.yddj_dj)
                {
                    lsbh = common_file.common_ddbh.ddbh("ttdj", "ttdjdate", "ttdjcounter", 6);
                    ddbh = common_file.common_ddbh.ddbh("ttdj", "ttdjdate", "ttdjcounter", 6);
                }
                else
                    if (yddj == common_file.common_yddj.yddj_yd)
                    {
                        lsbh = common_file.common_ddbh.ddbh("ttyd", "ttyddate", "ttydcounter", 6);
                        ddbh = common_file.common_ddbh.ddbh("ttyd", "ttyddate", "ttydcounter", 6);
                    }


            }
            //
            if (add_edit == common_file.common_app.get_edit && tB_yddj.Text.Trim() != "")
            {
                lsbh = M_Qttyd_mainrecord.lsbh;
                ddbh = M_Qttyd_mainrecord.ddbh;
            }
            string[] args = new string[34];
            args[0] = Qttdj_id.ToString();
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = lsbh;
            args[4] = ddbh;
            args[5] = tB_krxm.Text.Trim().Replace("'", "-");
            args[6] = tB_ttbh.Text.Trim().Replace("'", "-");
            args[7] = this.yddj;
            if (add_edit == common_file.common_app.get_add)
            {
                args[8] = common_file.common_sktt.sktt_tt;
            }
            else
            {
                args[8] = M_Qttyd_mainrecord.sktt;
            }
            args[9] = tB_krgj.Text.Trim().Replace("'", "-");
            args[10] = tB_krdz.Text.Trim().Replace("'", "-");
            args[11] = tB_krly.Text.Trim().Replace("'", "-");
            args[12] = xyh;
            args[13] = tB_xydw.Text.Trim().Replace("'", "-");
            args[14] = tB_xsy.Text.Trim().Replace("'", "-");
            args[15] = tB_krdh.Text.Trim().Replace("'", "-");
            args[16] = tB_krsj.Text.Trim().Replace("'", "-");
            args[17] = tB_krEmail.Text.Trim().Replace("'", "-");
            args[18] = tB_ydrxm.Text.Trim().Replace("'", "-");
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                args[19] = dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString();
            }
            else
                if (yddj == common_file.common_yddj.yddj_dj)
                {
                    if (add_edit == common_file.common_app.get_add)
                    {
                        args[19] = DateTime.Now.ToString();
                    }
                    else
                    {
                        args[19] = M_Qttyd_mainrecord.ddsj.ToString();
                    }
                }
            args[20] = "0";//入住天数
            //args[20] = tB_lzts.Text.Trim().Replace("'", "-");

            args[21] = dT_lksj_date.Value.ToShortDateString() + "  " + dT_lksj_time.Value.ToLongTimeString();

            args[22] = tB_qtyq.Text.Trim().Replace("'", "-");
            args[23] = cB_ddrx.Text;
            args[24] = tB_ddwz.Text.Trim().Replace("'", "-");

            args[25] = this.yddj;
            args[26] = common_file.common_app.czy;
            args[27] = common_file.common_app.chinese_add;

            args[28] = DateTime.Now.ToString();
            args[29] = common_file.common_app.syzd;
            args[30] = tB_tsyq.Text.Trim().Replace("'", "-");
            args[31] = this.add_edit;
            args[32] = common_file.common_app.xxzs;
            args[33] = cB_ddly.Text.Trim().Replace("'", "-");
            int i_temp_0 = 1;
            if (add_edit == common_file.common_app.get_edit)
            {
                //判断所排房间是否有冲突，再判断房数是否有超排
                if (M_Qttyd_mainrecord.ddsj != DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) || M_Qttyd_mainrecord.lksj != DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()))
                {
                    DataSet DS_temp_0 = B_common.GetList("select * from Qskyd_fjrb", "lsbh in (select lsbh from Qskyd_mainrecord where ddbh='" + M_Qttyd_mainrecord.ddbh + "' and fjbh<>'')");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        for (int j_temp = 0; j_temp < DS_temp_0.Tables[0].Rows.Count; j_temp++)
                        {
                            //主要要去除掉并单的情况
                            if (float.Parse(DS_temp_0.Tables[0].Rows[j_temp]["lzfs"].ToString()) > 0)
                            {
                                if (common_file.common_used_fjzt.get_dataset_usedfjzt(yddj, DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()), DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()), DS_temp_0.Tables[0].Rows[j_temp]["fjrb"].ToString(), DS_temp_0.Tables[0].Rows[j_temp]["fjbh"].ToString(), DS_temp_0.Tables[0].Rows[j_temp]["fjbh"].ToString(), DS_temp_0.Tables[0].Rows[j_temp]["id"].ToString(), common_file.common_app.is_contain_wx) == true)
                                { i_temp_0 = 5; }
                            }
                        }
                    }

                    if (i_temp_0 == 1)
                    {
                        if (judge_kyfs(M_Qttyd_mainrecord.krxm, M_Qttyd_mainrecord.sktt, M_Qttyd_mainrecord.lsbh) == false)
                        { i_temp_0 = 5; }
                    }
                    DS_temp_0.Dispose();
                }
            }
            if (i_temp_0 == 1)//用来做如果有续住，是否会与其他的房间起冲突，如果起冲突要提醒
            {
                Hotel_app.Server.Qyddj.Qttyd_add_edit_delete Qttyd_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qttyd_add_edit_delete();
                string result = Qttyd_add_edit_delete_services.Qttyd_add_edit_delete_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(),
               args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString(), args[30].ToString(), args[31].ToString(),
               args[32].ToString(), args[33].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qttyd_add_edit_delete_app", args);
                if (result== common_file.common_app.get_suc)
                {
                    if (add_edit == common_file.common_app.get_add)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "新增主单成功！");
                        tB_yddj.Text = yddj;
                        DataSet ds_temp = B_Qttyd_mainrecord.GetList("lsbh='" + lsbh + "'");
                        if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                        {

                            Qttdj_id = ds_temp.Tables[0].Rows[0]["id"].ToString();
                            loadInfo(Qttdj_id, yddj, add_edit, common_file.common_form.Fmain_new);
                            add_edit = common_file.common_app.get_edit;
                        }

                    }
                    else
                        if (add_edit == common_file.common_app.get_edit)
                        {
                            if (add_edit == common_file.common_app.get_edit)
                            {
                                if ((M_Qttyd_mainrecord.xyh == "" && xyh != "") || (M_Qttyd_mainrecord.xyh != "" && xyh == ""))
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "协议单位有发生变动，房价如有变动，请及时登录到房价调整界面进行调整！");
                                }
                            }

                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "修改成功.");
                            M_Qttyd_mainrecord = B_Qttyd_mainrecord.GetModel(int.Parse(Qttdj_id));
                        }
                    if (common_file.common_form.Qttdj_browse_new != null)
                        common_file.common_form.Qttdj_browse_new.refresh("");
                    RefreshApp();
                    return;
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败.");
                }



            }

        }

        private bool get_judge_void_local(string yddj_0)
        {
            common_file.common_app.get_czsj();
            bool bl_temp = false;
            if (yddj_0 == common_file.common_yddj.yddj_yd)
            {
                if (common_file.common_app.get_judge_void(tB_krxm, "Q_krxm", "对不起，团体名称不能为空！") == true)
                    if (common_file.common_app.get_judge_void(tB_krgj, "Q_krgj", "对不起，国家地区不能为空！") == true)
                        if (common_file.common_app.get_judge_void(tB_krdh, "Q_krdh", "对不起，联系电话不能为空！") == true)
                            if (common_file.common_app.get_judge_void(tB_krsj, "Q_krsj", "对不起，手机号码不能为空！") == true)
                                if (common_file.common_app.get_judge_void(tB_ydrxm, "Q_ydrxm", "对不起，预订人姓名不能为空") == true)
                                    if (common_file.common_app.get_judge_void(tB_krEmail, "Q_krEmail", "对不起，邮箱不能为空！") == true)
                                        if (common_file.common_app.get_judge_void(tB_krdz, "Q_krdz", "对不起，地址为空！") == true)
                                            if (common_file.common_app.get_judge_void(tB_krly, "Q_krly", "对不起，来源不能为空！") == true)
                                                if (common_file.common_app.get_judge_void(tB_xydw, "Q_xydw", "对不起，协议单位不能为空！") == true)
                                                    if (common_file.common_app.get_judge_void(tB_xsy, "Q_xsy", "对不起，销售人员不能为空！") == true)
                                                        bl_temp = true;

            }
            else
                if (yddj_0 == common_file.common_yddj.yddj_dj)
                {
                    if (common_file.common_app.get_judge_void(tB_krxm, "D_krxm", "对不起，团体名称不能为空！") == true)
                        if (common_file.common_app.get_judge_void(tB_krgj, "D_krgj", "对不起，国家地区不能为空！") == true)
                            if (common_file.common_app.get_judge_void(tB_krdh, "D_krdh", "对不起，联系电话不能为空！") == true)
                                if (common_file.common_app.get_judge_void(tB_krsj, "D_krsj", "对不起，手机号码不能为空！") == true)
                                    if (common_file.common_app.get_judge_void(tB_ydrxm, "D_ydrxm", "对不起，预订人姓名不能为空") == true)
                                        if (common_file.common_app.get_judge_void(tB_krEmail, "D_krEmail", "对不起，邮箱不能为空！") == true)
                                            if (common_file.common_app.get_judge_void(tB_krdz, "D_krdz", "对不起，地址为空！") == true)
                                                if (common_file.common_app.get_judge_void(tB_krly, "D_krly", "对不起，来源不能为空！") == true)
                                                    if (common_file.common_app.get_judge_void(tB_xydw, "D_xydw", "对不起，协议单位不能为空！") == true)
                                                        if (common_file.common_app.get_judge_void(tB_xsy, "D_xsy", "对不起，销售人员不能为空！") == true)
                                                            bl_temp = true;

                }
            return bl_temp;
        }

        private void B_gj_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Xxtsz.Xkrgj_select Xkrgj_select_new = new Hotel_app.Xxtsz.Xkrgj_select();
            Xkrgj_select_new.Left = tB_krgj.Left - 100;
            Xkrgj_select_new.Top = tB_krgj.Top + 50;
            if (Xkrgj_select_new.ShowDialog() == DialogResult.OK)
            {
                tB_krgj.Text = Xkrgj_select_new.get_krgj;
            }
            Xkrgj_select_new.Dispose();
            tB_krgj.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_krly_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xkrly", tB_krly.Left, tB_krly.Top + 150, tB_krly);
        }

        private void b_xydw_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yyxzx.Yxydw_select Yxydw_select_new = new Hotel_app.Yyxzx.Yxydw_select();
            Yxydw_select_new.Left = tB_xydw.Left - 70;
            Yxydw_select_new.Top = tB_xydw.Top + 50;
            if (Yxydw_select_new.ShowDialog() == DialogResult.OK)
            {
                tB_xydw.Text = Yxydw_select_new.get_xydw;
                xyh = Yxydw_select_new.get_xyh;
                tB_krly.Text = Yxydw_select_new.get_krly;
                tB_xsy.Text = Yxydw_select_new.get_xsy;
            }
            Yxydw_select_new.Dispose();
            tB_xydw.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void b_xsy_Click(object sender, EventArgs e)
        {
            if (tB_krly.Text.Trim().Equals(common_file.common_xydw.krly_xydw))
            {
            }
            else
            {
                string xsy_0 = tB_xsy.Text.Trim();
                display_new_commonform_1("Yxsy", tB_xsy.Left - 100, tB_xsy.Top + 150, tB_xsy);
                if (xsy_0 != "")
                {
                    tB_xsy.Text = xsy_0 + "|" + tB_xsy.Text;
                }
            }
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

        private void b_new_fjrb_Click(object sender, EventArgs e)
        {
            //if (yddj == common_file.common_yddj.yddj_dj)
            //{
            //{ return; }

            //}
            //else
            //{
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                if (common_file.common_roles.get_user_qx("B_tt_yd_xz_fl", common_file.common_app.user_type) == false)
                { return; }

            }
            //}


            if (his_remind() == true)
            {
                return;
            }
            if (tB_yddj.Text.Trim() != "")//以经预订或者登记
            {
                //先查询是否有空记录
                for (int i = 0; i < dg_fjrb.Rows.Count; i++)
                {
                    if (dg_fjrb.Rows[i].Cells["col_fjrb"].Value == null || (dg_fjrb.Rows[i].Cells["col_fjrb"].Value != null && dg_fjrb.Rows[i].Cells["col_fjrb"].Value.ToString() == ""))
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先修改空记录再增加");
                        return;
                    }
                }
                Hotel_app.Qyddj.Qskdj_fjrb Qskdj_fjrb_new = new Hotel_app.Qyddj.Qskdj_fjrb(this.yddj, common_file.common_app.yddj_type_group, common_file.common_app.get_add);
                Qskdj_fjrb_new.ddsj = M_Qttyd_mainrecord.ddsj;
                Qskdj_fjrb_new.lksj = M_Qttyd_mainrecord.lksj;
                Qskdj_fjrb_new.lsbh = M_Qttyd_mainrecord.lsbh;
                Qskdj_fjrb_new.Left = b_new_fjrb.Left + 150;
                Qskdj_fjrb_new.Top = b_new_fjrb.Top + 250;
                Qskdj_fjrb_new.judge_add_edit = common_file.common_app.get_add;
                Qskdj_fjrb_new.Qskdj_fjrb_id = dg_fjrb.Rows[0].Cells["id"].Value.ToString();
                Qskdj_fjrb_new.cB_shqh.Text = common_file.common_app.fy_qh;
                Qskdj_fjrb_new.ShowDialog();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "主单还没有保存,不能初始房间,请先保存主单");
            }
        }


        internal void Qttdj_add(string yddj, string add_edit, Fmain fmain)
        {
            this.yddj = yddj;
            this.FrmParent = fmain;
            this.add_edit = add_edit;

        }

        private void b_amend_fjrb_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_tt_dj_tz_fl", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_tz_fl", common_file.common_app.user_type) == false)
                    { return; }

                }
            }



            if (his_remind() == true)
            {
                return;
            }
            if (Ds_fjfx != null && Ds_fjfx.Tables[0].Rows.Count > 0)
            {
                if (dg_fjrb.CurrentRow.Index > -1 && dg_fjrb.CurrentRow.Index < Ds_fjfx.Tables[0].Rows.Count)
                {
                    if (dg_fjrb.CurrentRow != null)
                    {
                        int id = Convert.ToInt32(dg_fjrb.Rows[dg_fjrb.CurrentRow.Index].Cells["id"].Value);
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(id);
                        common_file.common_app.get_czsj();
                        Qyddj.Qskdj_fjrb Qskdj_fjrb_new = new Hotel_app.Qyddj.Qskdj_fjrb(this.yddj, common_file.common_app.yddj_type_group, common_file.common_app.get_edit);
                        Qskdj_fjrb_new.Qskdj_fjrb_id = id.ToString();
                        Qskdj_fjrb_new.ddsj = M_Qskyd_fjrb.ddsj;
                        Qskdj_fjrb_new.lksj = M_Qskyd_fjrb.lksj;
                        Qskdj_fjrb_new.lsbh = M_Qskyd_fjrb.lsbh;
                        Qskdj_fjrb_new.Left = b_new_fjrb.Left + 150;
                        Qskdj_fjrb_new.Top = b_new_fjrb.Top + 250;
                        Qskdj_fjrb_new.judge_add_edit = common_file.common_app.get_edit;
                        Qskdj_fjrb_new.ShowDialog();
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void b_Exit_Click(object sender, EventArgs e)
        {
            if (tB_yddj.Text == "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你的主单没有保存，确定要退出嘛？") == true)
                {
                    common_file.common_form.Qttdj_new.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        public void ClearText()
        {
            common_file.common_ClearControlsValue.ClearControlsValue(p_mainInfo, new string[] { });
            common_file.common_ClearControlsValue.ClearControlsValue(panel16, new string[] { });
            if (add_edit == common_file.common_app.get_add)
            {
                tB_yddj.Text = "";
                tB_zwye_0.Text = "0";
                tB_cznr.Text = common_file.common_app.chinese_add;
                tB_czy.Text = common_file.common_app.czy;
                tB_czsj.Text = common_file.common_app.czsj.ToString();
            }
            if (add_edit == common_file.common_app.get_edit)
            {
            }
        }

        private void tB_krdh_Leave(object sender, EventArgs e)
        {

        }

        private void tB_krsj_Leave(object sender, EventArgs e)
        {
            //if (!common_file.common_CheckPhoneNo.checkphoneNo(this.tB_krsj.Text.Trim()))
            //{
            //    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请认真填写手机号哥们~~");
            //}
        }

        private void tB_lzts_TextChanged(object sender, EventArgs e)
        {

        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (dg_fjrb.Rows.Count > 0 && dg_fjrb.Rows[0].Cells["id"].Value != null && dg_fjrb.Rows[0].Cells["id"].Value.ToString() != string.Empty)
            {
                string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
                if (dg_fjrb.CurrentRow.Index >= 0 || dg_fjrb.Rows.Count > 0)
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要删除所选的记录嘛？") == true)
                    {
                        string id = dg_fjrb.Rows[dg_fjrb.CurrentRow.Index].Cells["id"].Value.ToString();
                        M_Qskyd_fjrb = B_Qskyd_fjrb.GetModel(int.Parse(id));
                        if (B_Qskyd_fjrb.Delete(int.Parse(id)))//common_file.Common_commonFunction.Delete_Qskyd_fjrb(id, url) == common_file.common_app.get_suc)
                        {
                            dg_fjrb.Rows.Remove(dg_fjrb.CurrentRow);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除成功");
                        }
                    }
                }

                else
                {
                    //提示
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "你好,你没有选择任何信息");
                }
            }
        }

        private void dg_Qttdj_detail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (his_remind() == true)
            {
                return;
            }
            //双击成员行进入到散客登记那种介面
            //dg_count_cy = Ds_cy_detail.Tables[0].Rows.Count;
            if (dg_Qttdj_detail.CurrentRow != null)
            {
                int k_0 = 0;
                DataRowView dgr = dg_Qttdj_detail.CurrentRow.DataBoundItem as DataRowView;
                k_0 = Ds_cy_detail.Tables[0].Rows.IndexOf(dgr.Row);

                if (dg_count_cy > 0 && dg_Qttdj_detail.CurrentRow.Index < dg_count_cy && Ds_cy_detail.Tables[0].Rows[k_0]["id"].ToString() != "")
                {
                    //string id_0 = dg_Qttdj_detail.Rows[dg_ydpf.CurrentRow.Index].Cells["id_0"].Value.ToString();
                    common_file.common_form.Qskdj_new_open(Ds_cy_detail.Tables[0].Rows[k_0]["id"].ToString(), Ds_cy_detail.Tables[0].Rows[k_0]["yddj"].ToString(), common_file.common_app.get_edit, common_file.common_app.main_sec_main);

                    //tc_AddInfo.Refresh();

                }
            }


        }

        private void b_zwcl_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_tt_dj_zw", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_zw", common_file.common_app.user_type) == false)
                    { return; }

                }
            }


            if (his_remind() == true)
            {
                common_file.common_form.ShowFrm_Szwcl_new(M_Qttyd_mainrecord_bak.lsbh, "tt", common_file.common_app.czy, true);
            }

            else
            {
                if (this.lsbh.Trim() != "")//这里要判断
                {
                    common_file.common_app.get_czsj();
                    if (yddj == common_file.common_yddj.yddj_dj || yddj == common_file.common_yddj.yddj_yd)
                    {

                        //加这个权限是为了防止其它的不是前厅人员对电话费和杂费的导入
                        if (common_file.common_roles.get_user_qx("B_zfToZw", common_file.common_app.user_type,false) == false)
                        {
                        }
                        else
                        {

                            int i = 3;
                            string Notice = "";//显示的提示信息
                            string importType = "";
                            //检查是否有费用要导入
                            i = CheckOtherFee(ref Notice, ref importType);
                            if (i == 2)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "系统正在将" + Notice + "导入房费中...请稍等....!");
                                common_file.common_app.get_czsj();
                                string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";

                                object[] args = new object[12];
                                args[0] = "tt";
                                args[1] = "";
                                args[2] = common_file.common_app.yydh;
                                args[3] = common_file.common_app.qymc;
                                args[4] = this.lsbh;
                                args[5] = common_file.common_app.czy;
                                args[6] = common_file.common_app.czy_bc;
                                //string czsj, string syzd, string add_edit_delete, string xxzs
                                args[7] = DateTime.Now.ToString();
                                args[8] = common_file.common_app.syzd;
                                args[9] = common_file.common_app.get_add;
                                //xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, xfsl, czy_bc, czzt,
                                args[10] = common_file.common_app.xxzs;
                                args[11] = importType;

                                Hotel_app.Server.Szwgl.Szwmx Szwmx_services = new Hotel_app.Server.Szwgl.Szwmx();
                                string result = Szwmx_services.InsertOtherFeetoZw(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString());
                                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "InsertOtherFeetoSzwmx", args);
                                if (result != null && result== common_file.common_app.get_suc)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, Notice + "费用导入成功!");
                                }
                            }
                        }



                        common_file.common_form.ShowFrm_Szwcl_new(lsbh, "tt", common_file.common_app.czy_GUID, false);
                        Cursor.Current = Cursors.Default;
                    }
                }
            }


            //(传lsbh,sktt,这里还要注意传一个CZY,数据通过操作员来临时生成的

            //if (common_file.common_form.Szwcl_new == null || common_file.common_form.Szwcl_new.IsDisposed)
            //{
            //    common_file.common_app.get_czsj();
            //    common_file.common_form.Szwcl_new = new Hotel_app.Szwgl.Szwcl(lsbh, "tt");
            //    common_file.common_form.Szwcl_new.MdiParent = this.MdiParent;
            //    common_file.common_form.Szwcl_new.Show();
            //}
            //common_file.common_form.Szwcl_new.Activate();
            //common_file.common_form.Szwcl_new.lsbh_ttzd = this.lsbh;
            //common_file.common_form.Szwcl_new.BindData(this.lsbh, common_file.common_app.czy);
            //common_file.common_form.Szwcl_new.Inital_app(this.lsbh, "tt", common_file.common_app.czy);//团体


            Cursor.Current = Cursors.Default;
        }

        private void b_delete_Click_1(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_tt_yd_sc_fl", common_file.common_app.user_type) == false)
                    { return; }

                }
            }


            if (his_remind() == true)
            {
                return;
            }
            common_file.common_app.get_czsj();
            Qyddj.Qyddj_c Qyddj_c_new = new Qyddj_c();
            Qyddj_c_new.delete_fjrb(dg_fjrb, M_Qskyd_fjrb, B_Qskyd_fjrb);
            Cursor.Current = Cursors.Default;
        }

        private void b_ttzhy_Click(object sender, EventArgs e)
        {

            if (common_file.common_roles.get_user_qx("B_tt_yddj_tthy_zh", common_file.common_app.user_type) == false)
            { return; }


            if (his_remind() == true)
            {
                return;
            }
            if (add_edit == common_file.common_app.get_edit)
            {
                Qyddj.Qyddj_skczzd_hz Qyddj_skczzd_hz_new = new Qyddj_skczzd_hz("tt", M_Qttyd_mainrecord.lsbh, M_Qttyd_mainrecord.ddbh, M_Qttyd_mainrecord.krxm, M_Qttyd_mainrecord.sktt);
                Qyddj_skczzd_hz_new.Left = 180;
                Qyddj_skczzd_hz_new.Top = 150;
                Qyddj_skczzd_hz_new.ShowDialog();
            }
        }

        private void b_tsjy_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_tt_yddj_tsjy", common_file.common_app.user_type) == false)
            { return; }
            if (his_remind() == true)
            {
                return;
            }
            if (add_edit == common_file.common_app.get_edit)
            {
                string fjbh_0 = "";
                Qyddj.Qtsjy Qtsjy_new = new Qtsjy(common_file.common_app.get_add, "dw", M_Qttyd_mainrecord.lsbh, M_Qttyd_mainrecord.sktt, M_Qttyd_mainrecord.krxm, fjbh_0, M_Qttyd_mainrecord.krsj, "", xyh, M_Qttyd_mainrecord.xydw, "", " and lsbh='" + M_Qttyd_mainrecord.lsbh + "'");
                Qtsjy_new.Left = 150;
                Qtsjy_new.Top = 100;
                Qtsjy_new.ShowDialog();

            }

        }

        private void tc_AddInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_AddInfo.SelectedIndex == 1 || tc_AddInfo.SelectedIndex == 2)
            {
                tC_dlsj.Visible = false;
                tC_other.Visible = false;
                tC_fjrb.Visible = false;
                tc_AddInfo.Dock = DockStyle.Fill;
            }
            else
                if (tc_AddInfo.SelectedIndex == 0)
                {
                    tc_AddInfo.Dock = DockStyle.Top;
                    tC_dlsj.Visible = true;
                    tC_other.Visible = true;
                    tC_fjrb.Visible = true;
                }
            if (add_edit != common_file.common_app.get_add)
            {
                czjl("", add_edit);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (common_file.common_roles.get_user_qx("B_tt_yddj_fzyd", common_file.common_app.user_type) == false)
            { return; }


            if (his_remind() == true)
            {
                return;
            }
            if (add_edit == common_file.common_app.get_edit)
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要复制当前的信息到预订记录里？") == true)
                {
                    common_file.common_app.get_czsj();
                    string url = common_file.common_app.service_url;
                    string lsbh_new = common_file.common_ddbh.ddbh("ttyd", "ttyddate", "ttydcounter", 6);
                    string ddbh_new = common_file.common_ddbh.ddbh("ttyd", "ttyddate", "ttydcounter", 6);
                    url += "Qyddj/Qyddj_app.asmx";
                    object[] args = new object[10];
                    args[0] = M_Qttyd_mainrecord.yydh;
                    args[1] = M_Qttyd_mainrecord.qymc;
                    args[2] = "tt";
                    args[3] = M_Qttyd_mainrecord.lsbh;
                    args[4] = lsbh_new;
                    args[5] = ddbh_new;
                    args[6] = common_file.common_app.czy;
                    args[7] = DateTime.Now;
                    args[8] = "复制预订";
                    args[9] = common_file.common_app.xxzs;
                    Hotel_app.Server.Qyddj.Q_copy_yd Q_copy_yd_services = new Hotel_app.Server.Qyddj.Q_copy_yd();
                    string result = Q_copy_yd_services.copy_sk_yd(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), DateTime.Parse(args[7].ToString()), args[8].ToString(), args[9].ToString());
                    if (result == common_file.common_app.get_suc)
                    {
                        DataSet ds_temp_00 = B_common.GetList(" select * from Qttyd_mainrecord ", " id>=0  and  lsbh='" + lsbh_new + "'  and yydh='" + common_file.common_app.yydh + "'");
                        if (ds_temp_00 != null && ds_temp_00.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_form.Qttdj_new_open(ds_temp_00.Tables[0].Rows[0]["id"].ToString(), ds_temp_00.Tables[0].Rows[0]["yddj"].ToString(), common_file.common_app.get_edit, true);
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "复制成功！");
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "复制失败！");
                        }


                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "复制失败！");

                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void b_djb_print_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_tt_yddj_print_djb", common_file.common_app.user_type) == false)
            { return; }
            if (this.lsbh.Trim() != "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要打印登记表嘛?") == true)
                {
                    common_file.common_app.get_czsj();
                    common_file.common_PrintFrm common_PrintFrm_new = new Hotel_app.common_file.common_PrintFrm(lsbh, "tt", common_file.common_app.czy, ddbh);
                    //Q_skyd_print_djb Q_skyd_print_djb_new = new Q_skyd_print_djb(lsbh, "tt", common_file.common_app.czy, ddbh);
                    //Q_skyd_print_djb_new.czy = common_file.common_app.czy;
                    //Q_skyd_print_djb_new.Visible = false;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Qttdj_Load(object sender, EventArgs e)
        {


        }

        private void b_ttzzkrlb_print_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_tt_yddj_print_djb", common_file.common_app.user_type) == false)
            { return; }

            if (this.ddbh.Trim() != "" && this.lsbh.Trim() != "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "确定要打印客人列表?") == true)
                {
                    common_file.common_app.get_czsj();
                    Q_tt_krlb_0 Q_tt_krlb_0_new = new Q_tt_krlb_0();
                    DataSet ds_temp_0 = Q_tt_krlb_0_new.insert_Q_tt_temp_krlb(ddbh);
                    if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否要显示房价?") == true)
                        {
                            common_file.common_app.get_czsj();
                            Q_tt_krlb_print Q_tt_krlb_print_new = new Q_tt_krlb_print(lsbh, ddbh, ds_temp_0, tB_krxm.Text.Trim(), "true");
                            //Q_skyd_print_djb_new.Visible = false;
                        }
                        else
                        {
                            common_file.common_app.get_czsj();
                            Q_tt_krlb_print Q_tt_krlb_print_new = new Q_tt_krlb_print(lsbh, ddbh, ds_temp_0, tB_krxm.Text.Trim(), "false");
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }


        //20160618新增，删除多排的成员
        private void b_del_Click(object sender, EventArgs e)
        {

            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_ll_sc", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_ll_sc", common_file.common_app.user_type) == false)
                    { return; }

                }
            }
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            common_file.common_app.get_czsj();
            string[] id_arg = new string[50];
            int sl_id = 0;
            int judge_ky = 2;//2可用，3不可用
            string get_qxyy = "";
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds_temp_0 = B_Common.GetList("select * from Qcounter", "id>=0");

            for (int j = 0; j < dg_Qttdj_detail.Rows.Count; j++)
            {
                common_file.common_app.get_czsj();
                DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
                if (this.dg_Qttdj_detail.Rows[j].Cells[0].GetEditedFormattedValue(j, ss) != null && Convert.ToBoolean(this.dg_Qttdj_detail.Rows[j].Cells[0].GetEditedFormattedValue(j, ss)) == true)
                {
                    if (this.dg_Qttdj_detail.Rows[j].Cells["id_cy"].Value != null)
                    {

                        int j_000 = 0;
                        DataRowView dgr = dg_Qttdj_detail.Rows[j].DataBoundItem as DataRowView;
                        j_000 = Ds_cy_detail.Tables[0].Rows.IndexOf(dgr.Row);

                        judge_ky = 2;
                        if (j < 50)
                        {
                            ds_temp_0 = B_common.GetList("select id from Syjcz", "lsbh='" + Ds_cy_detail.Tables[0].Rows[j_000]["lsbh"].ToString() + "'");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人" + Ds_cy_detail.Tables[0].Rows[j_000]["krxm"].ToString() + "有产生预收款了，如果确实要删除请先退还预收款！");
                                judge_ky = 3;
                            }
                            if (judge_ky == 2)
                            {
                                ds_temp_0 = B_common.GetList("select id from Szwmx", "lsbh='" + Ds_cy_detail.Tables[0].Rows[j_000]["lsbh"].ToString() + "'");
                                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人" + Ds_cy_detail.Tables[0].Rows[j_000]["krxm"].ToString() + "有产生消费了，如果确实要删除请先转出相应消费！");
                                    judge_ky = 3;
                                }
                            }
                            if (judge_ky == 2)
                            {
                                //ds_temp_0 = B_common.GetList("select id from Szwmx", "lsbh='" + Ds_cy_detail.Tables[0].Rows[j_000]["lsbh"].ToString() + "'");
                                if (Ds_cy_detail.Tables[0].Rows[j_000]["yddj"].ToString() == common_file.common_yddj.yddj_dj)
                                {
                                    if (Ds_cy_detail.Tables[0].Rows[j_000]["yddj"].ToString() != yddj)
                                    {
                                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人是在" + Ds_cy_detail.Tables[0].Rows[j_000]["yddj"].ToString() + "状态，不能在" + yddj + "界面里删除！");
                                        judge_ky = 3;
                                    }
                                }
                            }
                            if (judge_ky == 2)
                            {
                                id_arg[j] = this.dg_Qttdj_detail.Rows[j].Cells["id_cy"].Value.ToString();
                            }
                        }
                        if (judge_ky == 2)
                        {
                            sl_id += 1;
                        }
                    }
                }
            }
            ds_temp_0.Dispose();

            if (id_arg.Length > 0 && sl_id <= 50)
            {
                if (sl_id > 0)
                {

                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要删除所选的主单记录嘛？") == true)
                    {
                        Qyddj.Q_bz_input Q_bz_input_new = new Q_bz_input();
                        Q_bz_input_new.Text = "请输入操作理由";
                        Q_bz_input_new.Left = 200;
                        Q_bz_input_new.Top = 150;
                        if (Q_bz_input_new.ShowDialog() == DialogResult.OK)
                        {
                            get_qxyy = Q_bz_input_new.get_bz;
                        }
                        Q_bz_input_new.Dispose();
                        common_file.common_app.get_czsj();
                        string url = common_file.common_app.service_url;
                        url += "Qyddj/Qyddj_app.asmx";
                        object[] args_1 = new object[8];
                        args_1[0] = id_arg;
                        args_1[1] = "sc";
                        args_1[2] = common_file.common_yddj.yddj_qx;
                        args_1[3] = get_qxyy;
                        args_1[4] = "";
                        args_1[5] = common_file.common_app.czy;
                        args_1[6] = DateTime.Now.ToString();
                        args_1[7] = common_file.common_app.xxzs;

                        Hotel_app.Server.Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();
                        string result_temp = Qyddj_add_edit_delete_services.delete_sk_multi(id_arg, args_1[1].ToString(), args_1[2].ToString(), args_1[3].ToString(), args_1[4].ToString(), args_1[5].ToString(), args_1[6].ToString(), args_1[7].ToString());
                        //object result_temp = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "delete_sk_multi", args_1);
                        if (result_temp != null && result_temp == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除记录成功!");
                            RefreshApp();
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除记录失败!");

                        }
                    }
                }


            }
            else
            {

                common_file.common_app.Message_box_show(common_file.common_app.message_title, "选择记录超过50条，请取消你超过的记录!");
            }
            Cursor.Current = Cursors.Default;
        }

        private void tB_krgj_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(sender, e);
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.return_KeyPress(sender, e);
        }

        public void czjl(string sql, string add_edit_delete_his)
        {
            string lsbh_czjl = "";
            DataSet ds_czjl_zd = null;
            DataSet ds_czjl_fxfj = null;
            if (add_edit_delete_his != common_file.common_app.get_his)
            {
                if (this.M_Qttyd_mainrecord != null)
                {
                    lsbh_czjl = M_Qttyd_mainrecord.lsbh;
                }
            }
            if (add_edit_delete_his == common_file.common_app.get_his)
            {
                if (M_Qttyd_mainrecord_bak != null)
                {
                    lsbh_czjl = M_Qttyd_mainrecord_bak.lsbh;
                }
            }
            ds_czjl_zd = B_common.GetList("select * from Qttyd_mainrecord_temp ", "ID>=0  and  yydh='" + common_file.common_app.yydh + "' and  lsbh='" + lsbh_czjl + "'" + sql + " order by czsj desc ");
            //if (ds_czjl_zd != null && ds_czjl_zd.Tables[0].Rows.Count > 0)
            //{

            dg_ttzd_czjl.AutoGenerateColumns = false;
            bindingSource_czjl_zd.DataSource = ds_czjl_zd.Tables[0].DefaultView;
            dg_ttzd_czjl.DataSource = bindingSource_czjl_zd;
            //}
            ds_czjl_fxfj = B_common.GetList(" select * from Qskyd_fjrb_temp ", "ID>=0  and  yydh='" + common_file.common_app.yydh + "' and  lsbh='" + lsbh_czjl + "'" + sql + "  order by czsj desc ");
            //if (ds_czjl_fxfj != null && ds_czjl_fxfj.Tables[0].Rows.Count > 0)
            //{

            dg_fxfj_czjl.AutoGenerateColumns = false;
            bindingSource_czjl_fxfj.DataSource = ds_czjl_fxfj.Tables[0].DefaultView;
            dg_fxfj_czjl.DataSource = bindingSource_czjl_fxfj;
            //}

        }

        private void tC_fjrb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (add_edit != common_file.common_app.get_add)
            {
                czjl("", add_edit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (his_remind() == true)
            {
                return;
            }
            common_file.common_app.get_czsj();
            if (add_edit == common_file.common_app.get_edit)//新增
            {
                Qyddj.Q_sk_tt_app Q_sk_tt_app_new = new Q_sk_tt_app(M_Qttyd_mainrecord.id.ToString(), M_Qttyd_mainrecord.yddj, "bt");
                Q_sk_tt_app_new.Left = 180;
                Q_sk_tt_app_new.Top = 150;
                if (Q_sk_tt_app_new.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }


            }



        }

        private void dT_ddsj_date_ValueChanged(object sender, EventArgs e)
        {
            dT_lksj_date.Value = dT_ddsj_date.Value.AddDays(1).Date;
        }

        public void GetFxfj_tj()
        {
            DataSet ds_fxfj_tj = null;
            dg_fxfj_tj.AutoGenerateColumns = false;
            StringBuilder sb = new StringBuilder();
            string cond = "";
            if (add_edit != common_file.common_app.get_his)
            {

                sb = new StringBuilder();
                sb.Append(" select fjrb,sum(lzfs)  as  lzfs  from Qskyd_fjrb ");
                //cond = "  ddbh='" + ddbh + "' group by fjrb,sjfjjg ";
                cond = "  (lzfs>=0 and( (lsbh in (select distinct lsbh from Qskyd_mainrecord  where   ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "')) or (lsbh in (select lsbh from Qttyd_mainrecord where ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "'))";
                cond = cond + " or (lsbh in (select distinct lsbh from Qskyd_mainrecord_bak  where   ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "'))  ) )   group by fjrb,sjfjjg";
            }
            if (add_edit == common_file.common_app.get_his)
            {
                sb = new StringBuilder();
                sb.Append(" select fjrb,sum(lzfs) as fs_Total from Qskyd_fjrb_bak");
                cond = "  (lzfs>=0 and ( (lsbh in (select distinct lsbh from Qskyd_mainrecord_bak  where   ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "')) or (lsbh in (select lsbh from Qttyd_mainrecord_bak where ddbh='" + ddbh + "' and yydh='" + common_file.common_app.yydh + "'))) )  group by fjrb,sjfjjg";
            }

            //ds_fxfj_tj = B_common.GetList(" select a.fjrb,pf_wp,pf_yp from (select fjrb,lzfs as pf_wp  from Qskyd_fjrb,Qttyd_mainrecord  where Qskyd_fjrb.lsbh=Qttyd_mainrecord.lsbh and Qttyd_mainrecord.lsbh='" + lsbh + "') as a,(select fjrb,count(fjbh) as pf_yp    from  Qskyd_fjrb,Qskyd_mainrecord where  Qskyd_fjrb.lsbh=Qskyd_mainrecord.lsbh and  Qskyd_mainrecord.ddbh='" + ddbh + "' group by fjrb ) as b  ", "  a.fjrb=b.fjrb  order by a.fjrb");
            ds_fxfj_tj = B_common.GetList(sb.ToString(), cond);
            dg_fxfj_tj.DataSource = ds_fxfj_tj.Tables[0].DefaultView;
        }

        private void b_setCyFF_Click(object sender, EventArgs e)
        {

            if (common_file.common_roles.get_user_qx("B_cyffzf", common_file.common_app.user_type) == false)
            { return; }
            if (add_edit != common_file.common_app.get_his)
            {
                DataSet ds_ttzd = B_common.GetList(" select  *  from  View_Qttzd", " id>=0 and yydh='" + common_file.common_app.yydh + "' and lsbh='" + this.lsbh + "'");
                if (ds_ttzd != null && ds_ttzd.Tables[0].Rows.Count > 0)
                {
                    Szwgl.common_zw.SetTTcyFF(ds_ttzd.Tables[0].Rows[0]["id"].ToString(), "tt");
                }
            }
        }

        private void b_exportToExcel_Click(object sender, EventArgs e)
        {
            if (this.ddbh.Trim() != "")
            {
                DataSet ds_0 = null;
                BLL.Common B_common = new Hotel_app.BLL.Common();
                ds_0 = B_common.GetList(" select * from View_Qskzd ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  ddbh='" + ddbh + "'");
                if (ds_0 != null && ds_0.Tables[0].Rows.Count > 0)
                {
                    common_file.common_DataSetToExcel.ExportMX(ds_0, "skdj_current", "团体成员详细内容导出");
                }
            }
        }





        private int CheckOtherFee(ref  string NoticeInfo, ref  string importType)
        {
            int i = 0;

            importType = "";
            //检查电话费
            DataSet ds_dhhy_00 = null;
            DataSet ds_dhhy_0 = B_common.GetList(" select distinct  lsbh  from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and fjbh!=''   and  shlz='1'  ) ");
            if (ds_dhhy_0 != null && ds_dhhy_0.Tables[0].Rows.Count > 0)
            {
                ds_dhhy_00 = B_common.GetList(" select * from Dh_jl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select  lsbh  from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ");
                {
                    if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                    {
                        i = 2;
                    }
                }
            }
            //不联房
            else
            {
                ds_dhhy_00 = B_common.GetList(" SELECT  *  from Dh_jl ", "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  lsbh='" + lsbh + "' ");
                if (ds_dhhy_00 != null && ds_dhhy_00.Tables[0].Rows.Count > 0)
                {
                    DataSet ds_00 = B_common.GetList(" select  * from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + lsbh + "'  and main_sec='" + common_file.common_app.main_sec_main + "'");
                    if (ds_00 != null)
                    {
                        i = 2;
                    }
                }
            }
            if (i == 2)
            {
                NoticeInfo += "电话费"; importType += "telFee";
                //i = 0;
            }


            DataSet ds_cy_fee_00 = null;
            //检查成员费用及团主单的费用
            DataSet ds_cy_fee = B_common.GetList(" select distinct  lsbh  from View_Qskzd  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     ddbh  in  (select  ddbh  from  View_Qttzd  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "') ");
            if (ds_cy_fee != null && ds_cy_fee.Tables[0].Rows.Count > 0)
            {
                ds_cy_fee_00 = B_common.GetList(" select * from S_cy_zl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select  lsbh  from  View_Qskzd  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and        ddbh  in  (select  ddbh  from  View_Qttzd  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "')  ) ");
                {
                    if (ds_cy_fee_00 != null && ds_cy_fee_00.Tables[0].Rows.Count > 0)
                    {
                        i = 2;
                    }
                }
            }
           // else//没有成员，检查团自己
            //{
                ds_cy_fee_00 = B_common.GetList(" SELECT  *  from S_cy_zl ", "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  lsbh='" + lsbh + "' ");
                if (ds_cy_fee_00 != null && ds_cy_fee_00.Tables[0].Rows.Count > 0)
                {
                     i = 2;
                }
           // }


            if (i == 2)
            {
                if (NoticeInfo.Trim() != "")
                {
                    NoticeInfo += "和客人餐饮消费"; importType += "|cyFee";
                }
                else
                {
                    NoticeInfo += "客人餐饮消费"; importType += "cyFee";
                }
            }
            return i;
        }
    }
}