using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hotel_app.Qyddj
{
    public partial class Qskdj : Form
    {
        #region 自定义变量
        public string jzbh = "";
        public string ddbh = "";
        public string fjrb = "";
        public string fjbh = "";
        public string fjrb_pic = "";//如果从房态图那边传递过来,干净房/脏房时要传递这两个值，新增或新增完后要清除掉
        public string fjbh_pic = "";//如果从房态图那边传递过来,干净房/脏房时要传递这两个值，新增或新增完后要清除掉
        public string xyh = "";
        public string lsbh = "";
        public string hyrx = "";
        public string hykh = "";
        public string sktt = common_file.common_sktt.sktt_sk;
        public bool flage = false;//增加sec客户资料的时候会用到
        public int dg_count = 0;
        public int dg_count_lf = 0;
        public string ck_lskr_krxm_zjhm = "krxm";//用来弹出历史客人的提示框，并输入相应的条件
        //程序加载的时候要确定这个值(从主窗体加载时判断)
        public string yddj = "";// common_file.common_yddj.yddj_dj;
        public string add_edit = "";// common_file.common_app.get_add;
        private int Qskyd_id = -1;
        //private string add_edit_temp = "";

        public string cznr = common_file.common_app.chinese_add;
        public string main_sec = common_file.common_app.main_sec_main;
        public string yddj_rx = common_file.common_yddj.yddj_dj;
        public DateTime ddsj = DateTime.Now;

        public Hotel_app.Model.Qskyd_mainrecord M_Qskyd_mainrecord = new Hotel_app.Model.Qskyd_mainrecord();
        private Hotel_app.BLL.Qskyd_mainrecord B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
        private Hotel_app.BLL.Common B_common = new Hotel_app.BLL.Common();
        private Hotel_app.Model.Qskyd_fjrb M_Qskyd_fjrb = new Hotel_app.Model.Qskyd_fjrb();
        private Hotel_app.BLL.Qskyd_fjrb B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
        private Hotel_app.BLL.Flfsz B_Flfsz = new Hotel_app.BLL.Flfsz();
        private Hotel_app.Model.Qskyd_mainrecord_bak M_Qskyd_mainrecord_bak = null;
        /// <summary>
        /// 初始化默认值
        /// </summary>
        /// 

        //用于会员短信的缓存值
        string ddsj_temp = "";
        string lksj_temp = "";
        //用于调整
        Hotel_app.control_user.UC_room_pic_0　uc_modify=null;


        public void re_clear()
        {
            pb_photo.ImageLocation = Application.StartupPath + "\\imgsfz\\noID.bmp";
            jzbh = "";
            ddbh = "";
            fjrb = "";
            fjbh = "";
            fjrb_pic = "";//如果从房态图那边传递过来,干净房/脏房时要传递这两个值，新增或新增完后要清除掉
            fjbh_pic = "";//如果从房态图那边传递过来,干净房/脏房时要传递这两个值，新增或新增完后要清除掉
            xyh = "";
            lsbh = "";
            hyrx = "";
            hykh = "";
            sktt = common_file.common_sktt.sktt_sk;
            flage = false;//增加sec客户资料的时候会用到
            dg_count = 0;
            dg_count_lf = 0;
            ck_lskr_krxm_zjhm = "krxm";//用来弹出历史客人的提示框，并输入相应的条件
            //程序加载的时候要确定这个值(从主窗体加载时判断)
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
            tB_krrx.ForeColor = Color.Black;
            tB_krxm.ForeColor = Color.Black;
            tB_qtyq.ForeColor = Color.Black;
            tB_tsyq.ForeColor = Color.Black;

        }


        #endregion

        public Qskdj()
        {
            InitializeComponent();
            initializeLogInfo();
        }

        #region 方法



        /// <param name="Qskyd_id_0">主单ID</param>
        /// <param name="yddj_flage">预订查询||登记查询</param>
        /// <param name="add_edit_flage">历史||修改</param>
        public void Qskdj_1(int Qskyd_id_0, string yddj_flage, string add_edit_flage)
        {
            set_remind_tb_color();

            Qskyd_id = Qskyd_id_0;
            B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            this.M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(Qskyd_id);
            lsbh = M_Qskyd_mainrecord.lsbh;
            hyrx = M_Qskyd_mainrecord.hyrx;
            main_sec = M_Qskyd_mainrecord.main_sec;
            B_Qskyd_fjrb = new Hotel_app.BLL.Qskyd_fjrb();
            bindingSource_fxfj.DataSource = B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'");
            bindingSource_mainrecords.DataSource = B_Qskyd_mainrecord.GetModelList("lsbh='" + lsbh + "'and  yydh='" + common_file.common_app.yydh + "'");
            dg_count = B_Qskyd_mainrecord.GetModelList("lsbh='" + lsbh + "'and  yydh='" + common_file.common_app.yydh + "'").Count;
            //同时修改窗体的状态值
            add_edit = add_edit_flage;//修改
            yddj = yddj_flage;
            flage = false;
            FormText();
            tB_yddj.Text = yddj;
            if (yddj == common_file.common_yddj.yddj_dj)
            {

            }
            initializeapp_modify();
            SetControlEnable();
            ///提醒
            if (main_sec == common_file.common_app.main_sec_main)
            {
                Common_Qyddj.Qskyd_remind(M_Qskyd_mainrecord.lsbh);
            }
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                b_ydzdj.Visible = true;
            }
            else
            {
                b_ydzdj.Visible = false;
            }
            //    b_zwcl.Left =b_ydzdj.Left+b_ydzdj.Width+5;
            //    //b_zwcl.Left = 600;
            //}
            //else
            //{
            //    b_ydzdj.Visible = false;
            //    if (b_ydzdj.Visible)
            //   // b_zwcl.Left = 692;
            //    b_zwcl.Left = 660;
            //    b_del_other.Left = b_zwcl.Left+b_zwcl.Width +5;
            //}
            if (b_ydzdj.Visible)
            {
                b_zwcl.Left = b_ydzdj.Left + b_ydzdj.Width + 5;
            }
            else
            {
                b_zwcl.Left = b_djb_print.Left + b_ydzdj.Width + 5;
            }
            b_del_other.Left = b_zwcl.Left + b_zwcl.Width + 5;


            czjl_ls("", add_edit);

            ddsj_temp = M_Qskyd_mainrecord.ddsj.ToString();
            lksj_temp = M_Qskyd_mainrecord.lksj.ToString();

        }
        /// <summary>
        /// 从浏览界面新增主单记录
        /// </summary>
        /// <param name="yddj_flage">预订查询||登记查询</param>
        /// <param name="add_edit_flage">新增</param>
        public void Qskdj_2(string yddj_flage, string add_edit_flage)
        {
            re_clear();
            set_remind_tb_color();
            yddj = yddj_flage;
            add_edit = add_edit_flage;
            main_sec = common_file.common_app.main_sec_main;
            FormText();
            set_public_control(false);
            SetControlEnable();
            flage = false;
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                b_ydzdj.Visible = true;
               // b_zwcl.Left = 736;
                //b_zwcl.Left = 660;
            }
            else
            {
                b_ydzdj.Visible = false;
               // b_zwcl.Left = 692;
                //b_zwcl.Left = 660;
            }
            if (b_ydzdj.Visible)
            {
                b_zwcl.Left = b_ydzdj.Left + b_ydzdj.Width + 5;
            }
            else
            {
                b_zwcl.Left = b_djb_print.Left + b_djb_print.Width + 5;
            }
        }
        ////
        //读取历史记录
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_0"></param>
        /// <param name="lsbh_0"></param>
        /// <param name="add_edit_flage"></param>
        public void Qskdj_open_his(string id_0, string add_edit_flage)
        {
            add_edit = add_edit_flage;

            if (yddj == common_file.common_yddj.yddj_yd)
            {
                b_ydzdj.Visible = true;
                b_zwcl.Left = 736;
            }
            else
            {
                b_ydzdj.Visible = false;
                b_zwcl.Left = 692;
            }

            string lsbh_his = "";
            if (id_0 != "")
            {
                BLL.Qskyd_mainrecord_bak B_Qskyd_mainrecord_bak = new Hotel_app.BLL.Qskyd_mainrecord_bak();
                M_Qskyd_mainrecord_bak = new Hotel_app.Model.Qskyd_mainrecord_bak();
                M_Qskyd_mainrecord_bak = B_Qskyd_mainrecord_bak.GetModel(int.Parse(id_0));
                if (M_Qskyd_mainrecord_bak != null)
                {

                    #region 主要信息
                    jzbh = M_Qskyd_mainrecord_bak.jzbh;
                    lsbh_his = M_Qskyd_mainrecord_bak.lsbh;
                    tB_hykh_bz.Text = M_Qskyd_mainrecord_bak.hykh_bz;
                    hykh = M_Qskyd_mainrecord_bak.hykh;
                    hyrx = M_Qskyd_mainrecord_bak.hyrx;
                    tB_krxm.Text = M_Qskyd_mainrecord_bak.krxm;
                    tB_yxzj.Text = M_Qskyd_mainrecord_bak.yxzj;
                    tB_krgj.Text = M_Qskyd_mainrecord_bak.krgj;
                    tB_zjhm.Text = M_Qskyd_mainrecord_bak.zjhm;
                    tB_krmz.Text = M_Qskyd_mainrecord_bak.krmz;
                    cB_krxb.Text = M_Qskyd_mainrecord_bak.krxb;
                    dT_krsr.Text = M_Qskyd_mainrecord_bak.krsr.ToString();
                    tB_krdh.Text = M_Qskyd_mainrecord_bak.krdh;
                    tB_krsj.Text = M_Qskyd_mainrecord_bak.krsj;
                    tB_krEmail.Text = M_Qskyd_mainrecord_bak.krEmail;
                    tB_krdz.Text = M_Qskyd_mainrecord_bak.krdz;
                    tB_lsbh.Text = M_Qskyd_mainrecord_bak.lsbh;
                    tB_vip_type.Text = M_Qskyd_mainrecord_bak.vip_type;
                    sktt = M_Qskyd_mainrecord_bak.sktt;
                    yddj = M_Qskyd_mainrecord_bak.yddj;
                    main_sec = M_Qskyd_mainrecord_bak.main_sec;

                    #endregion

                    #region 附加信息
                    tB_krjg.Text = M_Qskyd_mainrecord_bak.krjg;
                    tB_krdw.Text = M_Qskyd_mainrecord_bak.krdw;
                    tB_krzy.Text = M_Qskyd_mainrecord_bak.krzy;
                    tB_cxmd.Text = M_Qskyd_mainrecord_bak.cxmd;
                    tB_qzrx.Text = M_Qskyd_mainrecord_bak.qzrx;
                    tB_qzhm.Text = M_Qskyd_mainrecord_bak.qzhm;
                    dT_zjyxq.Text = M_Qskyd_mainrecord_bak.zjyxq.ToString();
                    dT_tlyxq.Text = M_Qskyd_mainrecord_bak.tlyxq.ToString();
                    dT_tjrq.Text = M_Qskyd_mainrecord_bak.tjrq.ToString();
                    tB_lzka.Text = M_Qskyd_mainrecord_bak.lzka;
                    #endregion

                    #region 同来客人


                    #endregion

                    #region 协议销售
                    tB_krly.Text = M_Qskyd_mainrecord_bak.krly;
                    xyh = M_Qskyd_mainrecord_bak.xyh;
                    tB_xydw.Text = M_Qskyd_mainrecord_bak.xydw;
                    tB_xsy.Text = M_Qskyd_mainrecord_bak.xsy;
                    #endregion

                    #region 抵达位置
                    cB_ddrx.Text = M_Qskyd_mainrecord_bak.ddrx;
                    tB_ddwz.Text = M_Qskyd_mainrecord_bak.ddwz;
                    cB_ddly.Text = M_Qskyd_mainrecord_bak.ddly;
                    #endregion

                    #region 其它信息
                    tB_krrx.Text = M_Qskyd_mainrecord_bak.krrx;
                    tB_zwye_0.Text ="0";
                    DataSet DS_temp_0 = B_common.GetList("select xfje,fkje from Szwzd_bak","lsbh='"+M_Qskyd_mainrecord_bak.lsbh+"'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        tB_zwye_0.Text = Convert.ToString(float.Parse(DS_temp_0.Tables[0].Rows[0]["fkje"].ToString()) - float.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString()));
                    }
                    DS_temp_0.Clear();
                    DS_temp_0.Dispose();
                    tB_qtyq.Text = M_Qskyd_mainrecord_bak.qtyq;
                    #endregion

                    #region 特殊要求
                    tB_tsyq.Text = M_Qskyd_mainrecord_bak.tsyq;
                    #endregion

                    #region 操作时间
                    tB_czy.Text = M_Qskyd_mainrecord_bak.czy;
                    tB_cznr.Text = M_Qskyd_mainrecord_bak.cznr;
                    tB_czsj.Text = M_Qskyd_mainrecord_bak.czsj.ToString();
                    #endregion

                    #region 抵离时间
                    dT_ddsj_date.Text = Convert.ToDateTime(M_Qskyd_mainrecord_bak.ddsj).Date.ToString();
                    dT_ddsj_time.Text = Convert.ToDateTime(M_Qskyd_mainrecord_bak.ddsj).TimeOfDay.ToString();
                    //tB_lzts.Text = M_Qskyd_mainrecord.lzts.ToString();
                    dT_lksj_date.Text = Convert.ToDateTime(M_Qskyd_mainrecord_bak.lksj).Date.ToString();
                    dT_lksj_time.Text = Convert.ToDateTime(M_Qskyd_mainrecord_bak.lksj).TimeOfDay.ToString();
                    #endregion
                    DataSet DS_temp_9 = B_common.GetList("select * from Qskyd_fjrb_bak", "lsbh='" + lsbh_his + "'");
                    bindingSource_fxfj.DataSource = DS_temp_9.Tables[0];

                    DS_temp_9 = B_common.GetList("select * from Qskyd_mainrecord_bak", "lsbh='" + lsbh_his + "'");
                    bindingSource_mainrecords.DataSource = DS_temp_9.Tables[0];
                    DS_temp_9 = B_common.GetList("select * from Qskyd_fjrb_bak", "lsbh in(select lsbh from Flfsz_bak where lfbh in(select lfbh from Flfsz_bak where lsbh='" + lsbh_his + "')) ");
                    bindingSource_ydpf.DataSource = DS_temp_9.Tables[0];
                    czjl_ls("", add_edit);

                    DS_temp_9.Clear();
                    DS_temp_9.Dispose();
                }
            }

        }

        //登陆后公共信息
        public void initializeLogInfo()
        {
            tB_czy.Text = common_file.common_app.czy;
        }

        //修改时加载窗体信息
        public void initializeapp_modify()
        {
            tB_czy.Text = common_file.common_app.czy;
            dg_fjrb.AutoGenerateColumns = false;
            dg_fjrb.DataSource = null;
            dg_qskyd_mainRecord_OtherPerson.AutoGenerateColumns = false;
            dg_qskyd_mainRecord_OtherPerson.DataSource = null;
            tB_cznr.Text = common_file.common_app.chinese_edit;//设置操作内容
            //加载信息
            refresh_app();
            if (this.M_Qskyd_mainrecord != null && B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'").Count > 0)
            {
                load_input_infor();////加载输入框信息
            }
        }

        //加载输入框信息
        public void load_input_infor()
        {

            #region 主要信息
            tB_hykh_bz.Text = M_Qskyd_mainrecord.hykh_bz;
            hykh = M_Qskyd_mainrecord.hykh;
            hyrx = M_Qskyd_mainrecord.hyrx;
            tB_krxm.Text = M_Qskyd_mainrecord.krxm;
            tB_yxzj.Text = M_Qskyd_mainrecord.yxzj;
            tB_krgj.Text = M_Qskyd_mainrecord.krgj;
            tB_zjhm.Text = M_Qskyd_mainrecord.zjhm;
            tB_krmz.Text = M_Qskyd_mainrecord.krmz;
            cB_krxb.Text = M_Qskyd_mainrecord.krxb;
            dT_krsr.Text = M_Qskyd_mainrecord.krsr.ToString();
            tB_krdh.Text = M_Qskyd_mainrecord.krdh;
            tB_krsj.Text = M_Qskyd_mainrecord.krsj;
            tB_krEmail.Text = M_Qskyd_mainrecord.krEmail;
            tB_krdz.Text = M_Qskyd_mainrecord.krdz;
            tB_lsbh.Text = M_Qskyd_mainrecord.lsbh;
            tB_vip_type.Text = M_Qskyd_mainrecord.vip_type;
            sktt = M_Qskyd_mainrecord.sktt;
            yddj = M_Qskyd_mainrecord.yddj;
            main_sec = M_Qskyd_mainrecord.main_sec;
            pb_photo.ImageLocation = Application.StartupPath + "\\imgsfz\\noID.bmp";
            if (!M_Qskyd_mainrecord.zjhm.Trim().Equals(""))
            {
                if (File.Exists(Application.StartupPath + "\\imgsfz\\" + M_Qskyd_mainrecord.zjhm.Trim() + ".bmp"))
                {
                    pb_photo.ImageLocation = Application.StartupPath + "\\imgsfz\\" + M_Qskyd_mainrecord.zjhm.Trim() + ".bmp";
                }
            }

            #endregion

            #region 附加信息
            tB_krjg.Text = M_Qskyd_mainrecord.krjg;
            tB_krdw.Text = M_Qskyd_mainrecord.krdw;
            tB_krzy.Text = M_Qskyd_mainrecord.krzy;
            tB_cxmd.Text = M_Qskyd_mainrecord.cxmd;
            tB_qzrx.Text = M_Qskyd_mainrecord.qzrx;
            tB_qzhm.Text = M_Qskyd_mainrecord.qzhm;
            dT_zjyxq.Text = M_Qskyd_mainrecord.zjyxq.ToString();
            dT_tlyxq.Text = M_Qskyd_mainrecord.tlyxq.ToString();
            dT_tjrq.Text = M_Qskyd_mainrecord.tjrq.ToString();
            tB_lzka.Text = M_Qskyd_mainrecord.lzka;
            #endregion

            #region 同来客人


            #endregion

            #region 协议销售
            tB_krly.Text = M_Qskyd_mainrecord.krly;
            xyh = M_Qskyd_mainrecord.xyh;
            tB_xydw.Text = M_Qskyd_mainrecord.xydw;
            tB_xsy.Text = M_Qskyd_mainrecord.xsy;
            #endregion

            #region 抵达位置
            cB_ddrx.Text = M_Qskyd_mainrecord.ddrx;
            tB_ddwz.Text = M_Qskyd_mainrecord.ddwz;
            cB_ddly.Text = M_Qskyd_mainrecord.ddly;
            #endregion

            #region 其它信息
            tB_krrx.Text = M_Qskyd_mainrecord.krrx;

            tB_zwye_0.Text = "0";
            DataSet DS_temp_0 = B_common.GetList("select xfje,fkje from Szwzd", "lsbh='" + M_Qskyd_mainrecord.lsbh + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                tB_zwye_0.Text = Convert.ToString(float.Parse(DS_temp_0.Tables[0].Rows[0]["fkje"].ToString()) - float.Parse(DS_temp_0.Tables[0].Rows[0]["xfje"].ToString()));
            }
            DS_temp_0.Clear();
            DS_temp_0.Dispose();

            
            tB_qtyq.Text = M_Qskyd_mainrecord.qtyq;
            #endregion

            #region 特殊要求
            tB_tsyq.Text = M_Qskyd_mainrecord.tsyq;
            #endregion

            #region 操作时间
            tB_czy.Text = M_Qskyd_mainrecord.czy;
            tB_cznr.Text = M_Qskyd_mainrecord.cznr;
            tB_czsj.Text = M_Qskyd_mainrecord.czsj.ToString();
            #endregion

            #region 抵离时间
            dT_ddsj_date.Text = Convert.ToDateTime(M_Qskyd_mainrecord.ddsj).Date.ToString();
            dT_ddsj_time.Text = Convert.ToDateTime(M_Qskyd_mainrecord.ddsj).TimeOfDay.ToString();
            //tB_lzts.Text = M_Qskyd_mainrecord.lzts.ToString();
            dT_lksj_date.Text = Convert.ToDateTime(M_Qskyd_mainrecord.lksj).Date.ToString();
            dT_lksj_time.Text = Convert.ToDateTime(M_Qskyd_mainrecord.lksj).TimeOfDay.ToString();
            #endregion

            #region 房型房间
            dg_fjrb.DataSource = bindingSource_fxfj;
            dg_qskyd_mainRecord_OtherPerson.DataSource = bindingSource_mainrecords;
            #endregion

        }

        //保存后，清空所有control的值
        public void clearControlsValue()
        {
            set_remind_tb_color();
            tB_czy.Text = common_file.common_app.czy;
            dg_fjrb.AutoGenerateColumns = false;
            dg_fjrb.DataSource = null;
            dg_qskyd_mainRecord_OtherPerson.AutoGenerateColumns = false;
            dg_qskyd_mainRecord_OtherPerson.DataSource = null;
            //加载信息
            clear_main_infor();//清除主要信息和附加信息

            #region 协议销售
            tB_krly.Text = "";
            tB_xydw.Text = "";
            tB_xsy.Text = "";
            xyh = "";
            #endregion

            #region 抵达位置
            cB_ddrx.Text = "";
            tB_ddwz.Text = "";
            cB_ddly.Text = cB_ddly.Items[0].ToString();
            #endregion

            #region 其它信息
            tB_krrx.Text = common_file.common_app.krrx_pt;
            tB_zwye_0.Text = "0";
            tB_qtyq.Text = "";
            #endregion

            #region 特殊要求
            tB_tsyq.Text = "";
            #endregion

            #region 操作时间
            tB_czy.Text = common_file.common_app.czy;
            tB_cznr.Text = "";
            tB_czsj.Text = DateTime.Now.ToString();
            #endregion

            #region 抵离时间
            dT_ddsj_date.Text = "";
            dT_ddsj_time.Text = "";
            //tB_lzts.Text = "";
            dT_lksj_date.Text = "";
            dT_lksj_time.Text = "";
            #endregion

            #region 房型房间
            dg_fjrb.DataSource = null;
            //list_M_Qskyd_fjrb = null;
            dg_qskyd_mainRecord_OtherPerson.DataSource = null;
            //list_M_Qskyd_mainRecord_otherPersions = null;
            tB_yddj.Text = "";
            tB_yddj.ReadOnly = true;
            #endregion
        }


        public void clear_main_infor()
        {
            #region 主要信息
            tB_hykh_bz.Text = "";
            tB_krxm.Text = "";
            tB_yxzj.Text = common_file.common_app.yxzj_sfz;
            tB_krgj.Text = common_file.common_app.krgj_zg;
            tB_zjhm.Text = "";
            tB_krmz.Text = "";
            cB_krxb.Text = "";
            dT_krsr.Text = common_file.common_app.cssj;
            tB_krdh.Text = "";
            tB_krsj.Text = "";
            tB_krEmail.Text = "";
            tB_krdz.Text = "";
            if (main_sec == "main")
            {
                tB_lsbh.Text = "";
            }
            tB_vip_type.Text = "";
            #endregion

            #region 附加信息
            tB_krjg.Text = "";
            tB_krdw.Text = "";
            tB_krzy.Text = "";
            tB_cxmd.Text = "";
            tB_qzrx.Text = "";
            tB_qzhm.Text = "";
            dT_zjyxq.Text = DateTime.Now.ToString(); //common_file.common_app.cssj;
            dT_tlyxq.Text = DateTime.Now.ToString(); //common_file.common_app.cssj;
            dT_tjrq.Text = DateTime.Now.ToString(); //common_file.common_app.cssj;
            tB_lzka.Text = "";
            #endregion

        }
        //用于新增住客信息的时候
        public void clearMainInfoSetControlDisable()
        {
            clear_main_infor();//清除主要信息和附加信息
            set_public_control(true);//设置公共信息的可写
        }

        //设置公共信息的可读或可写
        public void set_public_control(bool flage_0)
        {
            //SetControlDisable(panel10,  flage_0);
            common_file.common_ClearControlsValue.SetControlDisable(panel10, new string[] { "tB_krly", "tB_xydw", "tB_xsy" }, flage_0);
            //common_file.common_ClearControlsValue.SetControlDisable(panel11, new string[] { }, flage_0);
            common_file.common_ClearControlsValue.SetControlDisable(panel15, new string[] { }, flage_0);
            common_file.common_ClearControlsValue.SetControlDisable(panel16, new string[] { "tB_krrx" }, flage_0);
            //common_file.common_ClearControlsValue.SetControlDisable(panel17, new string[] { }, flage_0);

        }

        //新增主单或者修改时设置控件状态
        public void SetControlEnable()
        {
            //tB_krly.ReadOnly = false;
            //tB_xsy.ReadOnly = false;

            cB_ddrx.Enabled = true;
            tB_ddwz.ReadOnly = false;

            //tB_krrx.ReadOnly = false;
            tB_zwye_0.ReadOnly = false;
            tB_qtyq.ReadOnly = false;

            dT_ddsj_date.Enabled = true;
            dT_ddsj_time.Enabled = true;
            dT_lksj_date.Enabled = true;
            dT_lksj_time.Enabled = true;

            //设置BTN为不可用
            b_krly.Enabled = true;
            b_xydw.Enabled = true;
            b_xsy.Enabled = true;
            b_krrx.Enabled = true;


        }

        //刷新
        public void refresh_app()
        {
            //通过主单的临时编号找到对应的lfbh然后找到：访lfbh下所有的lsbh，再通过所有的lsbh找到所有的fjrb记录
            //其中有fjbh的绑定到  预订排房，没有fjbh的绑定到房型房间
            common_file.common_app.get_czsj();
            dg_fjrb.DataSource = null;
            dg_ydpf.DataSource = null;
            GetDatasource(this.lsbh);
            dg_fjrb.DataSource = bindingSource_fxfj;
            dg_ydpf.DataSource = bindingSource_ydpf;
            B_Qskyd_mainrecord = new Hotel_app.BLL.Qskyd_mainrecord();
            dg_qskyd_mainRecord_OtherPerson.DataSource = B_Qskyd_mainrecord.GetModelList("ID>=0  and yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + lsbh + "'  order by id");
            dg_count = B_Qskyd_mainrecord.GetModelList("ID>=0  and yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + lsbh + "'  order by id").Count;
            lksj_temp = dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString();
            ddsj_temp = dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString();
        }

        //加载信息时根据 yddj和add_edit来设置窗体的Text
        public void FormText()
        {
            //先清空所有值
            clearControlsValue();
            //登记（增加）
            if (yddj == common_file.common_yddj.yddj_dj && add_edit == common_file.common_app.get_add)
            {
                common_file.common_form.Qskdj_new.Text = "散客登记";
                tB_cznr.Text = common_file.common_app.chinese_add;
                dT_ddsj_date.Text = DateTime.Now.Date.ToString();
                dT_lksj_date.Text = DateTime.Now.AddDays(1).Date.ToString();
            }
            //预订(增加）
            if (yddj == common_file.common_yddj.yddj_yd && add_edit == common_file.common_app.get_add)
            {
                common_file.common_form.Qskdj_new.Text = "散客预订";
                tB_cznr.Text = common_file.common_app.chinese_add;
                dT_ddsj_date.Text = DateTime.Now.Date.ToString();
                dT_lksj_date.Text = DateTime.Now.AddDays(1).Date.ToString();
            }
            //登记修改||预订修改
            if (add_edit == common_file.common_app.get_edit)
            {
                if (yddj == common_file.common_yddj.yddj_dj)
                {
                    common_file.common_form.Qskdj_new.Text = "散客登记查询";
                }
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    common_file.common_form.Qskdj_new.Text = "散客预订查询";
                }
                tB_cznr.Text = common_file.common_app.chinese_edit;
                initializeapp_modify();
            }
            //历史
            if (add_edit == common_file.common_app.get_his)
            {
                common_file.common_form.Qskdj_new.Text = "查看历史记录";
            }
            tB_czsj.Text = DateTime.Now.ToShortTimeString();
            dg_ydpf.DataSource = null;
        }


        private bool judge_kyfs(string krxm_0, string fjbh_0, string lsbh_0)
        {

            float ylfs = 0; float xzfs = 0;
            bool get_true = true;
            DateTime ddsj_app = DateTime.Parse(common_file.common_app.cssj);
            DateTime lksj_app = DateTime.Parse(common_file.common_app.cssj);

            //if (M_Qttyd_mainrecord.ddsj != DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) || M_Qttyd_mainrecord.lksj != DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()))
            //如果到达时间往前改就要判断前面的时间是否会与别人冲突

            DataSet DS_temp_1;
            DS_temp_1 = B_common.GetList("select sum(lzfs) as lzfs,fjrb from Qskyd_fjrb", "lsbh='" + lsbh_0 + "' and fjrb<>'' group by fjrb");
            for (int j_temp_1 = 0; j_temp_1 < DS_temp_1.Tables[0].Rows.Count; j_temp_1++)
            {
                //if (M_Qttyd_mainrecord.ddsj != DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) || M_Qttyd_mainrecord.lksj != DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()))
                //如果到达时间往前改就要判断前面的时间是否会与别人冲突
                if (DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) < M_Qskyd_mainrecord.ddsj)
                {
                    ylfs = 0; xzfs = float.Parse(DS_temp_1.Tables[0].Rows[j_temp_1]["lzfs"].ToString());
                    ddsj_app = DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString());
                    lksj_app = M_Qskyd_mainrecord.ddsj;
                    if (DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()) < M_Qskyd_mainrecord.ddsj)
                    { lksj_app = DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()); }
                    get_true = common_file.common_used_fjzt.judge_kyfs(add_edit, yddj, xzfs.ToString(), ylfs, DS_temp_1.Tables[0].Rows[j_temp_1]["fjrb"].ToString(), DS_temp_1.Tables[0].Rows[j_temp_1]["fjrb"].ToString(), ddsj_app, lksj_app, krxm_0, fjbh_0, lsbh_0, " 抵时调前");
                }
                if (get_true == true)
                {
                    if (DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()) > M_Qskyd_mainrecord.lksj)
                    {
                        ylfs = 0; xzfs = float.Parse(DS_temp_1.Tables[0].Rows[j_temp_1]["lzfs"].ToString());
                        ddsj_app = M_Qskyd_mainrecord.lksj;
                        if (DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) > M_Qskyd_mainrecord.lksj)
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

        public void set_save_value()
        {
            M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(Qskyd_id);
            if (M_Qskyd_mainrecord != null)
            {
                tB_krrx.Text = M_Qskyd_mainrecord.krrx;
                tB_krly.Text = M_Qskyd_mainrecord.krly;
                tB_czy.Text = common_file.common_app.czy;
                tB_yddj.ReadOnly = true;
                tB_yddj.BackColor = Color.LimeGreen;
                tB_cznr.ReadOnly = true;
                tB_cznr.BackColor = Color.LimeGreen;
                tB_czy.ReadOnly = true;
                tB_czy.BackColor = Color.LimeGreen;
                tB_czsj.ReadOnly = true;
                tB_czsj.BackColor = Color.LimeGreen;
            }
        }

        //保存主单
        private void SaveNew_mainrecord()
        {
            common_file.common_app.get_czsj();
            string url = common_file.common_app.service_url + "Qyddj/Qyddj_app.asmx";
            //mainPersion
            if (add_edit == common_file.common_app.get_add && tB_yddj.Text == "" && main_sec == common_file.common_app.main_sec_main)
            {
                if (yddj == common_file.common_yddj.yddj_dj)
                {
                    lsbh = common_file.common_ddbh.ddbh("skdj", "skdjdate", "skdjcounter", 6);
                    ddbh = common_file.common_ddbh.ddbh("skdj", "skdjdate", "skdjcounter", 6);
                }
                else
                    if (yddj == common_file.common_yddj.yddj_yd)
                    {
                        lsbh = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                        ddbh = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                    }
                add_edit = common_file.common_app.get_add;
            }
            //保存第二人的时候（新增的状态下增加第二人，修改时新增第二人）
            if (add_edit == common_file.common_app.get_add && tB_yddj.Text != "" && main_sec == common_file.common_app.main_sec_sec)
            {
                //再加一个判断名称是否有重复
                if (checkequal(lsbh, tB_krxm.Text.Trim(), tB_zjhm.Text.Trim()))
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请检查是否有重复输入相同的客人信息");
                    tc_AddInfo.SelectedIndex = 0;
                    tB_krxm.Focus();
                    return;
                }
                ddbh = M_Qskyd_mainrecord.ddbh;
                add_edit = common_file.common_app.get_add;

            }
            //编辑或者    是   新增后再交点击保存   新增第二人后保存状态下再保存  都为保存修改
            if (add_edit == common_file.common_app.get_edit)
            {
                add_edit = common_file.common_app.get_edit;
                Qskyd_id = M_Qskyd_mainrecord.id;
                lsbh = M_Qskyd_mainrecord.lsbh;
                ddbh = M_Qskyd_mainrecord.ddbh;
            }
            common_file.common_app.get_czsj();
            string[] args = new string[56];
            args[0] = Qskyd_id.ToString();
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = lsbh;
            args[4] = ddbh;
            args[5] = hykh;
            args[6] = hyrx;
            args[7] = tB_krxm.Text.Trim().Replace("'", "-");
            args[8] = tB_krxm.Text.Trim().Replace("'", "-");
            args[9] = tB_krgj.Text.Trim().Replace("'", "-");
            args[10] = tB_krmz.Text.Trim().Replace("'", "-");
            args[11] = tB_yxzj.Text.Trim().Replace("'", "-");
            args[12] = tB_zjhm.Text.Trim().Replace("'", "-");
            args[13] = cB_krxb.Text.Trim().Replace("'", "-");
            args[14] = dT_krsr.Value.ToShortDateString();
            args[15] = tB_krdh.Text.Trim().Replace("'", "-");
            args[16] = tB_krsj.Text.Trim().Replace("'", "-");
            args[17] = tB_krEmail.Text.Trim().Replace("'", "-");
            args[18] = tB_krdz.Text.Trim().Replace("'", "-");
            args[19] = tB_krjg.Text.Trim().Replace("'", "-");
            args[20] = tB_krdw.Text.Trim().Replace("'", "-");
            args[21] = tB_krzy.Text.Trim().Replace("'", "-");
            args[22] = tB_cxmd.Text.Trim().Replace("'", "-");
            args[23] = tB_qzrx.Text.Trim().Replace("'", "-");
            args[24] = tB_qzhm.Text.Trim().Replace("'", "-");
            args[25] = dT_zjyxq.Value.ToShortDateString();
            args[26] = dT_tlyxq.Value.ToShortDateString();
            args[27] = dT_tjrq.Value.ToShortDateString();
            args[28] = tB_lzka.Text.Trim().Replace("'", "-");
            args[29] = tB_krly.Text.Trim().Replace("'", "-");
            args[30] = xyh;
            args[31] = tB_xydw.Text.Trim().Replace("'", "-");
            args[32] = tB_xsy.Text.Trim().Replace("'", "-");
            args[33] = cB_ddrx.Text.Trim();
            args[34] = tB_ddwz.Text.Trim().Replace("'", "-");
            args[35] = yddj;
            args[36] = tB_krrx.Text.Trim().Replace("'", "-");
            if (tB_krrx.Text.Trim().Replace("'", "-") == "")
            {
                if (tB_zjhm.Text.Trim().Replace("'", "-") != "")
                {
                    DataSet DS_temp = B_common.GetList("select * from Qskyd_mainrecord_bak", "zjhm='" + tB_zjhm.Text.Trim().Replace("'", "-") + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {
                        args[36] = common_file.common_app.krrx_htk;
                    }
                    DS_temp.Dispose();
                }
            }
            //儿童37
            args[37] = "0";
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                args[38] = dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString();
            }
            else
                if (yddj == common_file.common_yddj.yddj_dj)
                {
                    if (add_edit == common_file.common_app.get_add)
                    {
                        args[38] = DateTime.Now.ToString();
                    }
                    else
                    {
                        args[38] = M_Qskyd_mainrecord.ddsj.ToString();
                    }
                }

            args[39] = "0";//入住天数
            args[40] = dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString();
            args[41] = tB_qtyq.Text.Trim().Replace("'", "-");
            args[42] = common_file.common_app.czy;// tB_czy.Text.Trim().Replace("'", "-");
            args[43] = DateTime.Now.ToString();
            args[44] = cznr;
            args[45] = sktt;
            args[46] = yddj;
            args[47] = main_sec;
            args[48] = yddj_rx;
            args[49] = common_file.common_app.syzd;
            args[50] = tB_vip_type.Text.Replace("'", "-");
            args[51] = tB_tsyq.Text.Trim().Replace("'", "-");
            args[52] = add_edit;
            args[53] = common_file.common_app.xxzs;
            args[54] = cB_ddly.Text.Trim().Replace("'", "-");
            args[55] = tB_hykh_bz.Text.Trim().Replace("'", "-");
            int i_temp_0 = 1;
            //用来判断从房态图传房类与房号时，判断是否会起冲突，如果起冲突要提醒
            if (add_edit == common_file.common_app.get_add && main_sec == common_file.common_app.main_sec_main)
            {
                if (fjrb_pic != "" && fjbh_pic != "")
                {
                    if (common_file.common_used_fjzt.judge_kyfs(add_edit, yddj, "1", 0, fjrb_pic, fjrb_pic, DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()), DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()), tB_krxm.Text, fjbh_pic, lsbh, " 从房态图开单判断") == false)
                    {
                        i_temp_0 = 5;
                    }
                    if (common_file.common_used_fjzt.get_dataset_usedfjzt(yddj, DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()), DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()), fjrb_pic, "", fjbh_pic, "", common_file.common_app.is_contain_wx) == true)
                    { i_temp_0 = 5; }
                }
            }
            //用来做如果有续住，是否会与其他的房间起冲突，如果起冲突要提醒
            if (i_temp_0 == 1 && add_edit == common_file.common_app.get_edit && main_sec == common_file.common_app.main_sec_main)
            {
                //判断时间上的变动是否会造成房间的超排.
                string fjbh_0 = "";
                DataSet DS_temp_2 = B_Qskyd_fjrb.GetList("lsbh='" + lsbh + "' and fjbh<>''");
                if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                {
                    fjbh_0 = DS_temp_2.Tables[0].Rows[0]["fjbh"].ToString();
                }
                if (judge_kyfs(M_Qskyd_mainrecord.krxm, fjbh_0, M_Qskyd_mainrecord.lsbh) == false)
                { i_temp_0 = 5; }
                if (i_temp_0 == 1)
                {
                    DS_temp_2 = B_Qskyd_fjrb.GetList("lsbh='" + lsbh + "' and fjbh<>''");
                    if (DS_temp_2 != null && DS_temp_2.Tables[0].Rows.Count > 0)
                    {
                        Model.Qskyd_fjrb M_Qskyd_fjrb_temp = new Hotel_app.Model.Qskyd_fjrb();
                        M_Qskyd_fjrb_temp = B_Qskyd_fjrb.GetModel(int.Parse(DS_temp_2.Tables[0].Rows[0]["id"].ToString()));
                        if (M_Qskyd_mainrecord.ddsj != DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()) || M_Qskyd_mainrecord.lksj != DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()))
                        {
                            if (M_Qskyd_fjrb_temp != null)
                                if (M_Qskyd_fjrb_temp.fjbh.ToString() != "")
                                {
                                    if (common_file.common_used_fjzt.get_dataset_usedfjzt(yddj, DateTime.Parse(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString()), DateTime.Parse(dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString()), M_Qskyd_fjrb_temp.fjrb, M_Qskyd_fjrb_temp.fjbh, M_Qskyd_fjrb_temp.fjbh, M_Qskyd_fjrb_temp.id.ToString(), common_file.common_app.is_contain_wx) == true)
                                    { i_temp_0 = 5; }
                                }
                        }
                    }
                }
                DS_temp_2.Dispose();
            }
            if (i_temp_0 == 1)//用来做如果有续住，是否会与其他的房间起冲突，如果起冲突要提醒
            {
                Hotel_app.Server.Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();
                string result=Qyddj_add_edit_delete_services.Qskdj_add_edit_delete(args[0].ToString(), 
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
                                  args[55].ToString());
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskdj_add_edit_delete", args);
                common_file.common_app.get_czsj();
                if (result!=null&&result== common_file.common_app.get_suc)
                {
                   
                    string lksj_now = dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString();
                    string ddsj_now=dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString();
                    //修改
                    if (add_edit == common_file.common_app.get_edit)
                    {
                        if ((M_Qskyd_mainrecord.hykh == "" && hykh != "") || (M_Qskyd_mainrecord.hykh != "" && hykh == ""))
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "会员有发生变动，房价如有变动，请及时登录到房价调整界面进行调整！");

                        }
                        else
                            if ((M_Qskyd_mainrecord.xyh == "" && xyh != "") || (M_Qskyd_mainrecord.xyh != "" && xyh == ""))
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "协议单位有发生变动，房价如有变动，请及时登录到房价调整界面进行调整！");
                            }

                        //修改完成后给ddsj_temp与lksj_Temp
                         lksj_temp = dT_lksj_date.Value.ToShortDateString() + " " + dT_lksj_time.Value.ToLongTimeString();
                         ddsj_temp = dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Value.ToLongTimeString();
                    }

                    //判断是保存新增主单
                    if ((add_edit == common_file.common_app.get_add && main_sec == common_file.common_app.main_sec_main && tB_yddj.Text.Trim() == ""))
                    {
                        if (fjrb_pic != "" && fjbh_pic != "")
                        {
                            DataSet ds_temp_0 = B_common.GetList("select * from Qskyd_fjrb", "lsbh='" + lsbh + "'");
                            if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                            {
                                M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModelList("lsbh='" + ds_temp_0.Tables[0].Rows[0]["lsbh"].ToString() + "'")[0];
                                open_Qskdj_fjrb(ds_temp_0.Tables[0].Rows[0]["id"].ToString(), "other");
                                ds_temp_0 = B_common.GetList("select * from Ffjzt", "fjbh='" + fjbh_pic + "'");
                                if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                                {
                                    if (ds_temp_0.Tables[0].Rows[0]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                                    {
                                        if (Ffjzt.common_form.Ffjzt_pic_big_new != null)
                                        {
                                            if (Ffjzt.common_form.Ffjzt_pic_big_new.UC_room_pic_0_select != null)
                                            {
                                                common_file.common_room_state.room_state(Ffjzt.common_form.Ffjzt_pic_big_new.UC_room_pic_0_select, ds_temp_0, 0);
                                            }
                                        }
                                    }
                                }
                            }
                            ds_temp_0.Dispose();
                            fjbh_pic = "";//如果有从房态图传值过来，到这边就要清空了
                            fjrb_pic = "";//如果有从房态图传值过来，到这边就要清空了
                        }

                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "新增主单成功！");
                        tB_yddj.Text = yddj;
                        tB_lsbh.Text = lsbh;
                        refresh_app();
                        if (add_edit == common_file.common_app.get_add)
                        {
                            DataSet DS_temp = B_common.GetList("select * from Qskyd_mainrecord", "lsbh='" + lsbh + "'");
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                Qskyd_id = int.Parse(DS_temp.Tables[0].Rows[0]["id"].ToString());
                                M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(Qskyd_id);
                                add_edit = common_file.common_app.get_edit;
                            }
                            DS_temp.Dispose();
                        }
                        //else
                        //if (add_edit == common_file.common_app.get_edit)
                        //{  }
                        set_save_value();
                        return;
                    }
                    //新增状态下新增同来人
                    if (add_edit == common_file.common_app.get_add && main_sec == common_file.common_app.main_sec_sec)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "新增同来客人信息成功！");

                        DataSet DS_temp = B_common.GetList("select id from Qskyd_mainrecord", "lsbh='" + lsbh + "' and krxm='" + tB_krxm.Text.Trim().Replace("'", "-") + "' and zjhm='" + tB_zjhm.Text.Trim().Replace("'", "-") + "'");
                        if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                        {
                            Qskyd_id = int.Parse(DS_temp.Tables[0].Rows[0]["id"].ToString());
                            //set_public_control(false);
                            common_file.common_form.Qskdj_new.Qskdj_1(Qskyd_id, yddj, common_file.common_app.get_edit);
                        }
                        DS_temp.Dispose();

                        add_edit = common_file.common_app.get_edit;
                        set_save_value();
                        return;
                    }
                    //修改状态下新增第二人
                    if (add_edit == common_file.common_app.get_edit && main_sec == common_file.common_app.main_sec_sec)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "修改同来客人信息成功！");
                        //clearMainInfoSetControlDisable();
                        //refresh_app();
                        add_edit = common_file.common_app.get_edit;
                        set_save_value();
                        return;
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "修改成功");
                        if (common_file.common_form.Qskdj_browse_new != null)
                        {
                            M_Qskyd_mainrecord = B_Qskyd_mainrecord.GetModel(Qskyd_id);
                            common_file.common_form.Qskdj_browse_new.refresh_app("");
                            add_edit = common_file.common_app.get_edit;
                        }
                        set_save_value();
                        refresh_app();//更新后刷新信息
                    }
                }
                else
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");
            }
        }

        private string  GetTitle()
        {
            string  temp000="";
            if(cB_krxb.Text.Equals("男"))
            {
                temp000="先生,";
            }
           if(cB_krxb.Text.Equals("女"))
            {
                temp000="女士,";
            }
             if(!cB_krxb.Text.Equals("女")&&!cB_krxb.Text.Equals("男"))
            {
                temp000="同志,";
            }
            return tB_krxm.Text.Trim() + temp000;
        }
        private bool checkequal(string lsbh, string p, string zjhm)
        {
            Hotel_app.BLL.Qskyd_mainrecord B_temp = new Hotel_app.BLL.Qskyd_mainrecord();
            if (B_temp.GetModelList("lsbh='" + lsbh + "'  and  krxm='" + p + "'  and  zjhm='" + zjhm + "'") != null && B_temp.GetModelList("lsbh='" + lsbh + "'  and  krxm='" + p + "'  and  zjhm='" + zjhm + "'").Count > 0)
                return true;
            else
            {
                return false;
            }
        }

        #endregion

        #region 按纽事件
        private void b_Save_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_save", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_save", common_file.common_app.user_type) == false)
                    { return; }
                }
            }
            if (his_remind() == true)
            {
                return;
            }
            common_file.common_app.get_czsj();

            if (add_edit == common_file.common_app.get_add || add_edit == common_file.common_app.get_edit)//新增
            {
                if (get_judge_void_local(yddj) == true)//判断输入框是否为空
                {
                    string dt_former = dT_ddsj_date.Text + "  " + dT_ddsj_time.Text;
                    string dt_later = dT_lksj_date.Text + "  " + dT_lksj_time.Text;
                    if (common_file.common_app.CheckTime(dt_former, dt_later) == true)
                    {
                        common_file.common_app.get_czsj();
                        SaveNew_mainrecord();
                    }
                }
            }
            if (add_edit == common_file.common_app.get_his)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，历史记录只用来查看！");
            }
            Cursor.Current = Cursors.Default;
        }
        private void b_Amend_Click(object sender, EventArgs e)
        {
        }
        private void b_new_fjrb_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                if (common_file.common_roles.get_user_qx("B_sk_yd_xz_fl", common_file.common_app.user_type) == false)
                { return; }
            }
            if (his_remind() == true)
            {
                return;
            }
            common_file.common_app.get_czsj();
            if (tB_yddj.Text.Trim() != "")
            {
                //先查询是否有空记录
                for (int i = 0; i < dg_fjrb.Rows.Count ; i++)
                {
                    if ((dg_fjrb.Rows[i].Cells["col_fjrb"].Value == string.Empty && dg_fjrb.Rows[i].Cells["col_fjbh"].Value == string.Empty) || (dg_fjrb.Rows[i].Cells["col_fjrb"].Value == "" && dg_fjrb.Rows[i].Cells["col_fjbh"].Value == ""))
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请先修改空记录再增加");
                        return;
                    }

                }
                //登记状态只能修改
                if (tB_yddj.Text == common_file.common_yddj.yddj_dj)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "客人己登记状态,不能增加,请直接增加主单");
                    return;
                }
                Qyddj.Qskdj_fjrb Qskdj_fjrb_new = new Hotel_app.Qyddj.Qskdj_fjrb(this.yddj, common_file.common_app.yddj_type_personal, common_file.common_app.get_add);
                Qskdj_fjrb_new.ddsj = M_Qskyd_mainrecord.ddsj;
                Qskdj_fjrb_new.lksj = M_Qskyd_mainrecord.lksj;
                Qskdj_fjrb_new.lsbh = tB_lsbh.Text.Trim();//新增和修改都用这个临时编号
                Qskdj_fjrb_new.judge_add_edit = common_file.common_app.get_add;
                Qskdj_fjrb_new.Left = b_new_fjrb.Left + 150;
                Qskdj_fjrb_new.Top = b_new_fjrb.Top + 250;
                Qskdj_fjrb_new.ShowDialog();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有主单,无法新增房间类型");
            }
        }
        private void b_New_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_xz", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_xz", common_file.common_app.user_type) == false)
                    { return; }

                }
            }


            if (his_remind() == true)
            {
                return;
            }
            if (fjrb_pic != "" || fjbh_pic != "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "对不起，您之前有从房态图选择" + fjrb_pic + "-" + fjbh_pic + "！确认要取消所选房间重新开单？") == false)
                {

                    return;

                }
                else
                {
                    fjbh_pic = "";//如果有从房态图传值过来，到这边就要清空了
                    fjrb_pic = "";//如果有从房态图传值过来，到这边就要清空了
                }
            }
            else { }
            int judge = 3;
            if (tB_yddj.Text.Trim() == "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "对不起，您之前的订单没有保存，是否确定要重新增加主单！") == true)
                {
                    judge = 2;
                }
            }
            judge = 2;
            if (judge == 2)
            {
                set_public_control(false);//设置公共控件成可写
                tB_cznr.Text = common_file.common_app.chinese_add;//设置操作内容
                clearControlsValue();
                Qskdj_2(yddj, common_file.common_app.get_add);
                if (add_edit == common_file.common_app.get_add)
                {
                    czjl_ls("  and  1=2  ", add_edit);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_0"></param>//房类的ID
        /// <param name="show_type"></param>有三种情况“ShowDialog”独占显示“Show”非独占显示“other”表示不显示
        public void open_Qskdj_fjrb(string id_0, string show_type)
        {
            Qyddj.Qskdj_fjrb Qskdj_fjrb_new = new Hotel_app.Qyddj.Qskdj_fjrb(this.yddj, common_file.common_app.yddj_type_personal, common_file.common_app.get_edit);
            Qskdj_fjrb_new.Qskdj_fjrb_id = id_0.ToString();
            Qskdj_fjrb_new.judge_add_edit = common_file.common_app.get_edit;

            BLL.Qskyd_fjrb B_temp = new Hotel_app.BLL.Qskyd_fjrb();
            Model.Qskyd_fjrb M_temp = B_temp.GetModel(int.Parse(id_0));
            //这里的时候要用数据库里面的时间（主单与fjrb的时候是同步的，可以任选一个传递,防止界面上有改过但是时间没保存，造成的房态不准)
            Qskdj_fjrb_new.ddsj = M_temp.ddsj;
            Qskdj_fjrb_new.lksj = M_temp.lksj;
            Qskdj_fjrb_new.fjbh = M_temp.fjbh;
            Qskdj_fjrb_new.lsbh = tB_lsbh.Text.Trim();
            Qskdj_fjrb_new.Left = b_new_fjrb.Left + 150;
            Qskdj_fjrb_new.Top = b_new_fjrb.Top + 250;
            if (show_type == "ShowDialog")
            {
                Qskdj_fjrb_new.ShowDialog();

            }
            else
                if (show_type == "Show")
                {
                    Qskdj_fjrb_new.Show();

                }
                else
                    if (show_type == "other")
                    {
                        Qskdj_fjrb_new.tB_fjbh.Text = fjbh_pic;
                        Qskdj_fjrb_new.tB_fjrb.Text = fjrb_pic;
                        Qskdj_fjrb_new.tB_lzfs.Text = "1";
                        Qskdj_fjrb_new.tB_fjjg.Text = common_file.common_get_fjjg.get_fjjg(fjrb_pic, M_Qskyd_mainrecord.krly, M_Qskyd_mainrecord.xyh, M_Qskyd_mainrecord.ddsj, M_Qskyd_mainrecord.lksj, M_Qskyd_mainrecord.hykh, M_Qskyd_mainrecord.hyrx);
                        object sender_0 = new object(); EventArgs e_0 = new EventArgs();
                        Qskdj_fjrb_new.b_save_Click(sender_0, e_0);
                    }

        }
        private void b_amend_fjrb_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_tz_fl", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_tz_fl", common_file.common_app.user_type) == false)
                    { return; }

                }
            }
            if (his_remind() == true)
            {
                return;
            }
            if (tB_yddj.Text.Trim() != "")
            {
                if (B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'") != null && B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'").Count > 0)
                {
                    if (dg_fjrb.CurrentRow.Index > -1 && dg_fjrb.CurrentRow.Index < B_Qskyd_fjrb.GetModelList("lsbh='" + lsbh + "'").Count)
                    {
                        string id = dg_fjrb.Rows[dg_fjrb.CurrentRow.Index].Cells["id"].Value.ToString();
                        common_file.common_app.get_czsj();

                        open_Qskdj_fjrb(id, "ShowDialog");


                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有主单,无法修改");
            }
        }
        private void Btn_addOtherCustomer_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_add_tlr", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_add_tlr", common_file.common_app.user_type) == false)
                    { return; }

                }
            }
            if (his_remind() == true)
            {
                return;
            }

            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (tB_yddj.Text.Trim() == common_file.common_yddj.yddj_dj)
                {
                    if (tB_lsbh.Text != "")
                    {
                        //设置成增加sec
                        main_sec = common_file.common_app.main_sec_sec;
                        add_edit = common_file.common_app.get_add;
                        tB_cznr.Text = common_file.common_app.chinese_add;//设置操作内容
                        //清空非公共信息
                        clearMainInfoSetControlDisable();
                    }
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有主单,无法新增第二位客人");
                }
            }
            else
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    common_file.common_app.Message_box_show("提示", "预订状态不允许增加第二位客人");
                }

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
        private void b_krly_Click(object sender, EventArgs e)
        {
            if (tB_xydw.Text.Trim() == "")
            {
                display_new_commonform_1("Xkrly", tB_krly.Left, tB_krly.Top + 150, tB_krly);
            }
        }
        private void b_krrx_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xkrrx", tB_krrx.Left, tB_krrx.Top + 200, tB_krrx);
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
        private void b_yxzj_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xyxzj", tB_yxzj.Left, tB_yxzj.Top + 50, tB_yxzj);
        }
        private void b_krmz_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xkrmz", tB_krmz.Left - 100, tB_krmz.Top + 50, tB_krmz);
        }
        private void b_qzrx_Click(object sender, EventArgs e)
        {
            display_new_commonform_1("Xqzrx", tB_qzrx.Left - 50, tB_qzrx.Top + 50, tB_qzrx);
        }
        private void b_xydw_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            Yyxzx.Yxydw_select Yxydw_select_new = new Hotel_app.Yyxzx.Yxydw_select();
            Yxydw_select_new.Left = tB_xydw.Left - 100;
            Yxydw_select_new.Top = tB_xydw.Top + 150;
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
        private void b_Exit_Click(object sender, EventArgs e)
        {
            if (tB_lsbh.Text == "")
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "对不起，您之前的主单没有保存，是否确定要退出！") == true)
                {
                    this.Close();
                }
            }
            else this.Close();


        }
        #endregion

        private bool get_judge_void_local(string yddj_0)
        {
            common_file.common_app.get_czsj();
            bool bl_temp = false;
            if (yddj_0 == common_file.common_yddj.yddj_yd)
            {

                if (common_file.common_app.get_judge_void(tB_krxm, "Q_krxm", "对不起，客人姓名不能为空！") == true)
                    if (common_file.common_app.get_judge_void(tB_krgj, "Q_krgj", "对不起，国家地区不能为空！") == true)
                        if (common_file.common_app.get_judge_void(tB_yxzj, "Q_yxzj", "对不起，证件不能为空！") == true)
                            if (common_file.common_app.get_judge_void(tB_zjhm, "Q_zjhm", "对不起，证件号码不能为空！") == true)
                                if (common_file.common_app.get_judge_void(tB_krmz, "Q_krmz", "对不起，民族不能为空！") == true)
                                    if (common_file.common_app.get_judge_void(tB_krdh, "Q_krdh", "对不起，电话不能为空！") == true)
                                        if (common_file.common_app.get_judge_void(tB_krsj, "Q_krsj", "对不起，手机不能为空！") == true)
                                            if (common_file.common_app.get_judge_void(tB_krEmail, "Q_krEmail", "对不起，邮箱不能为空！") == true)
                                                if (common_file.common_app.get_judge_void(tB_krdz, "Q_krdz", "对不起，地址为空！") == true)
                                                    if (common_file.common_app.get_judge_void(tB_krly, "Q_krly", "对不起，来源不能为空！") == true)
                                                        if (common_file.common_app.get_judge_void(tB_xydw, "Q_xydw", "对不起，协议单位不能为空！") == true)
                                                            if (common_file.common_app.get_judge_void(tB_xsy, "Q_xsy", "对不起，销售人员不能为空！") == true)
                                                                if (common_file.common_app.get_judge_void(tB_krrx, "Q_krrx", "对不起，客人类型不能为空！") == true)
                                                                    bl_temp = true;
            }
            else
                if (yddj_0 == common_file.common_yddj.yddj_dj)
                {
                    if (common_file.common_app.get_judge_void(tB_krxm, "D_krxm", "对不起，客人姓名不能为空！") == true)
                        if (common_file.common_app.get_judge_void(tB_krgj, "D_krgj", "对不起，国家地区不能为空！") == true)
                            if (common_file.common_app.get_judge_void(tB_yxzj, "D_yxzj", "对不起，证件不能为空！") == true)
                                if (common_file.common_app.get_judge_void(tB_zjhm, "D_zjhm", "对不起，证件号码不能为空！") == true)
                                    if (common_file.common_app.get_judge_void(tB_krmz, "D_krmz", "对不起，民族不能为空！") == true)
                                        if (common_file.common_app.get_judge_void(tB_krdh, "D_krdh", "对不起，电话不能为空！") == true)
                                            if (common_file.common_app.get_judge_void(tB_krsj, "D_krsj", "对不起，手机不能为空！") == true)
                                                if (common_file.common_app.get_judge_void(tB_krEmail, "D_krEmail", "对不起，邮箱不能为空！") == true)
                                                    if (common_file.common_app.get_judge_void(tB_krdz, "D_krdz", "对不起，地址为空！") == true)
                                                        if (common_file.common_app.get_judge_void(tB_krly, "D_krly", "对不起，来源不能为空！") == true)
                                                            if (common_file.common_app.get_judge_void(tB_xydw, "D_xydw", "对不起，协议单位不能为空！") == true)
                                                                if (common_file.common_app.get_judge_void(tB_xsy, "D_xsy", "对不起，销售人员不能为空！") == true)
                                                                    if (common_file.common_app.get_judge_void(tB_krrx, "D_krrx", "对不起，客人类型不能为空！") == true)
                                                                        bl_temp = true;
                }
            return bl_temp;

        }

        private void Qskdj_Load(object sender, EventArgs e)
        {
        }

        private void dg_qskyd_mainRecord_OtherPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (his_remind() == true)
            {
                return;
            }
            if (e.RowIndex > -1 && e.RowIndex < dg_count)
            {
                int id = Convert.ToInt32(dg_qskyd_mainRecord_OtherPerson.Rows[e.RowIndex].Cells["index"].Value);
                tB_cznr.Text = common_file.common_app.chinese_edit;//设置操作内容
                set_public_control(false);
                tB_yddj.ReadOnly = true;
                tB_yddj.BackColor = Color.LimeGreen;
                tB_cznr.ReadOnly = true;
                tB_cznr.BackColor = Color.LimeGreen;
                tB_czy.ReadOnly = true;
                tB_czy.BackColor = Color.LimeGreen;
                tB_czsj.ReadOnly = true;
                tB_czsj.BackColor = Color.LimeGreen;
                common_file.common_form.Qskdj_new.Qskdj_1(id, yddj, common_file.common_app.get_edit);
                tc_AddInfo.SelectedIndex = 0;
            }
            Cursor.Current = Cursors.Default;

        }

        private void tB_zjhm_Leave(object sender, EventArgs e)
        {
            if (tB_yxzj.Text.Trim() == common_file.common_app.yxzj_sfz && tB_zjhm.Text.Trim() != "" && tB_zjhm.Text.Trim().Length > 15)
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
                tB_krjg.Text = jg;
            }
            if (tB_yxzj.Text.Trim() !=common_file.common_app.yxzj_sfz&&tB_zjhm.Text.Trim() != "")
            {
                DataSet DS_temp = B_common.GetList("select id from VIEW_Q_skyd_lskr", "zjhm like '%" + tB_zjhm.Text.Trim() + "%'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (M_Qskyd_mainrecord.zjhm != tB_zjhm.Text.Trim().Replace("'", "-"))
                    {
                        Qyddj.Q_lskr_open Q_lskr_open_new = new Qyddj.Q_lskr_open(" and zjhm like '%" + tB_zjhm.Text.Trim() + "%'", this);
                        Q_lskr_open_new.Left = 80;
                        Q_lskr_open_new.Top = 100;
                        Q_lskr_open_new.ShowDialog();
                        //common_file.common_app.Message_box_show(common_file.common_app.message_title, "1233");
                    }
                    else
                    {
                        p_lskr.Left = tB_zjhm.Left + tB_zjhm.Width - p_lskr.Width;
                        p_lskr.Top = tB_zjhm.Top - 1;
                        p_lskr.Visible = true;
                        ck_lskr_krxm_zjhm = "zjhm";

                    }
                }
                DS_temp.Clear();
                DS_temp.Dispose();


            }


        }

        private void tB_lzts_Leave(object sender, EventArgs e)
        {
            //if (tB_lzts.Text.Trim() != "")
            //{
            //    try
            //    {
            //        double i = double.Parse(tB_lzts.Text.Trim());
            //        //读取DDSJ
            //        DateTime dt_ddsj = Convert.ToDateTime(dT_ddsj_date.Value.ToShortDateString() + " " + dT_ddsj_time.Text);
            //        DateTime dt_lksj = dt_ddsj.AddDays(i);
            //        dT_lksj_date.Text = dt_lksj.ToShortDateString();
            //        dT_lksj_time.Text = dt_lksj.TimeOfDay.ToString();
            //    }
            //    catch
            //    {
            //        common_file.common_app.Message_box_show(common_file.common_app.message_title, "请输入正确的天数（可以为小数)");
            //        tB_lzts.Text = "";
            //        tB_lzts.Focus();
            //    }
            //}
        }

        private void GetDatasource(string lsbh)
        {
            //string lfbh = "";
            DataSet ds_fxfj = new DataSet();
            DataSet ds_ydpf = new DataSet();
            BLL.Qskyd_fjrb B_Qskyd_fjrb_temp = new Hotel_app.BLL.Qskyd_fjrb();
            //无论是新增还是修改，房数>1的，都是共用主单的临时编号（fxfj显示)
            ds_fxfj = B_Qskyd_fjrb_temp.GetList("yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'");
            //得到当前lsbh对应的LFBH所对应所有有fjbh的记录
            if (GetModelBylsbh(lsbh) != null)
            {
                ds_ydpf = GetModelBylsbh(lsbh);
            }
            bindingSource_fxfj.DataSource = ds_fxfj.Tables[0];
            bindingSource_ydpf.DataSource = ds_ydpf.Tables[0];
            dg_count_lf = ds_ydpf.Tables[0].Rows.Count;
        }

        //通过lsbh获取fjrb表里面的模
        private DataSet GetModelBylsbh(string lsbh)
        {
            BLL.Common B_common = new Hotel_app.BLL.Common();
            return B_common.GetList("select * from  View_Qskzd   where lsbh in  (select lsbh  from Flfsz ", "lfbh=(select lfbh from Flfsz where lsbh='" + lsbh + "'))");
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            //登记不能删除
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                return;
            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_sc_fl", common_file.common_app.user_type) == false)
                    { return; }

                }
            }



            if (his_remind() == true)
            {
                return;
            }
            Qyddj.Qyddj_c Qyddj_c_new = new Qyddj_c();
            Qyddj_c_new.delete_fjrb(dg_fjrb, M_Qskyd_fjrb, B_Qskyd_fjrb);
        }

        private void b_zwcl_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_zw", common_file.common_app.user_type) == false)
                { return; }
            }
            if (yddj == common_file.common_yddj.yddj_yd)
            {
                if (common_file.common_roles.get_user_qx("B_sk_yd_zw", common_file.common_app.user_type) == false)
                { return; }

            }
            if (his_remind() == true)
            {
                common_file.common_form.ShowFrm_Szwcl_new(tB_lsbh.Text.Trim(), "sk", common_file.common_app.czy, true);
            }
            else
                if (this.lsbh.Trim() != "")//这里要判断
                {
                    common_file.common_app.get_czsj();
                    if (yddj == common_file.common_yddj.yddj_dj||yddj==common_file.common_yddj.yddj_yd)
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
                            //考虑联房(这一部分为导入电话费用部分)
                            i = CheckOtherFee(ref Notice, ref importType);
                            if (i == 2)
                            {
                                //string sk_tt,string is_addToSingle, string yydh, string qymc, string lsbh,string czy,string czy_bc, 
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "系统正在将" + Notice + "导入房费中...请稍等....!");
                                common_file.common_app.get_czsj();
                                string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
                                object[] args = new object[12];
                                args[0] = "sk";
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

                                 Hotel_app.Server.Szwgl.Szwmx   Szwmx_services=new Hotel_app.Server.Szwgl.Szwmx();
                                string result=Szwmx_services.InsertOtherFeetoZw(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(),
args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString());

                               // object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "InsertOtherFeetoSzwmx", args);
                                if (result != null && result.ToString() == common_file.common_app.get_suc)
                                {
                                    common_file.common_app.Message_box_show(common_file.common_app.message_title, Notice + "费用导入成功!");
                                }
                            }
                        }

                    }
                     common_file.common_form.ShowFrm_Szwcl_new(lsbh, "sk", common_file.common_app.czy_GUID, false);
                     Cursor.Current = Cursors.Default;
                    }
                    //if (yddj == common_file.common_yddj.yddj_yd)
                    //{
                    //    common_file.common_form.ShowFrm_Szwcl_new(lsbh, "sk", common_file.common_app.czy, false);
                    //    Cursor.Current = Cursors.Default;
                    //}
            Cursor.Current = Cursors.Default;
        }

        private void b_ydzdj_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                return;
            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_ydzdj", common_file.common_app.user_type) == false)
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
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要将预订的客人转成入住") == true)
                {
                    Qyddj_ydzdj Qyddj_ydzdj_new = new Qyddj_ydzdj();
                    BLL.Common B_Common = new Hotel_app.BLL.Common();
                    DataSet ds_temp = B_Common.GetList("select * from Qskyd_fjrb", " lsbh='" + lsbh + "' and fjrb<>'' and fjbh<>'' and yddj='" + common_file.common_yddj.yddj_yd + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        common_file.common_app.get_czsj();
                        if (Qyddj_ydzdj_new.ydzdj(M_Qskyd_mainrecord.lsbh, ds_temp.Tables[0].Rows[0]["fjbh"].ToString(), M_Qskyd_mainrecord.ddbh, "sk") == true)
                        {
                            yddj = common_file.common_yddj.yddj_dj;
                            Qskdj_1(Qskyd_id, yddj, common_file.common_app.get_edit);
                            if (common_file.common_form.Qskdj_browse_new != null)
                            {
                                common_file.common_form.Qskdj_browse_new.Qskdj_browse_1(yddj, common_file.common_form.Fmain_new, common_file.common_app.main_sec_main);
                            }

                        }
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前不能转入房间，是否还没有排房,请检查排房信息，再执行转入住操作");
                        //MessageBox.Show("当前不能转入房间，是否还没有排房,请检查排房信息，再执行转入住操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }

            }
            Cursor.Current = Cursors.Default;
        }

        private void b_skzcz_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_sk_yddj_scz_zh", common_file.common_app.user_type) == false)
            { return; }

            if (his_remind() == true)
            {
                return;
            }
            if (add_edit == common_file.common_app.get_edit)
            {
                Qyddj.Qyddj_skczzd_hz Qyddj_skczzd_hz_new = new Qyddj_skczzd_hz("sk", M_Qskyd_mainrecord.lsbh, M_Qskyd_mainrecord.ddbh, M_Qskyd_mainrecord.krxm, M_Qskyd_mainrecord.sktt);
                //Qyddj_skczzd_hz_new.Left = 180;
                //Qyddj_skczzd_hz_new.Top = 150;
                Qyddj_skczzd_hz_new.StartPosition = FormStartPosition.CenterScreen;
                if (Qyddj_skczzd_hz_new.ShowDialog()==DialogResult.OK)
                {
                    //长住
                    if (Qyddj_skczzd_hz_new.get_sktt.Equals(common_file.common_sktt.sktt_cz))
                    {
                        if (uc_modify != null && uc_modify.MP_roomno.Length > 0)
                        {
                            uc_modify.pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\house.ico";
                        }
                    }
                    //钟点
                    if (Qyddj_skczzd_hz_new.get_sktt.Equals(common_file.common_sktt.sktt_zd))
                    {
                        uc_modify.pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\c-4.ico";
                    }
                    //散客
                    if (Qyddj_skczzd_hz_new.get_sktt.Equals(common_file.common_sktt.sktt_sk))
                    {
                        uc_modify.pB_head.ImageLocation = Application.StartupPath + @"\image\NewsIco\a-1.ico";
                    }
 
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b_ct_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_sk_yddj_ct", common_file.common_app.user_type) == false)
            { return; }

            if (his_remind() == true)
            {
                return;
            }

            if (add_edit == common_file.common_app.get_edit)
            {

                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要将客人出团！") == true)
                {
                    if (M_Qskyd_mainrecord.sktt == common_file.common_sktt.sktt_tt || M_Qskyd_mainrecord.sktt == common_file.common_sktt.sktt_hy)
                    {
                        common_file.common_app.get_czsj();

                        string url = common_file.common_app.service_url;
                        url += "Qyddj/Qyddj_app.asmx";
                        object[] args = new object[12];
                        args[0] = common_file.common_app.yydh;
                        args[1] = common_file.common_app.qymc;
                        args[2] = "sk";
                        args[3] = M_Qskyd_mainrecord.lsbh;
                        args[4] = M_Qskyd_mainrecord.krxm;
                        args[5] = "";
                        args[6] = "ct";
                        args[7] = M_Qskyd_mainrecord.sktt;
                        args[8] = common_file.common_sktt.sktt_sk;
                        args[9] = common_file.common_app.czy;
                        args[10] = DateTime.Now;
                        args[11] = common_file.common_app.xxzs;

                        Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1();
                        string result = Qyddj_add_edit_delete_1_services.sktt_hz(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(),
args[8].ToString(), args[9].ToString(), DateTime.Parse(args[10].ToString()), args[11].ToString());
                        //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "sktt_hz", args);
                        if (result!=null&&result.ToString() == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作成功！");
                            Qskdj_1(Qskyd_id, yddj, common_file.common_app.get_edit);
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

                        }

                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "非成员客人不能出团！");

                    }
                }
            }
        }

        private void b_lt_Click(object sender, EventArgs e)
        {

            if (common_file.common_roles.get_user_qx("B_sk_yddj_rt", common_file.common_app.user_type) == false)
            { return; }


            if (his_remind() == true)
            {
                return;
            }
            if (add_edit == common_file.common_app.get_edit)
            {

                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确认要将客人入团！") == true)
                {
                    if (M_Qskyd_mainrecord.sktt == common_file.common_sktt.sktt_tt || M_Qskyd_mainrecord.sktt == common_file.common_sktt.sktt_hy)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "非单间客人不能入团！");
                    }
                    else
                    {
                        Qyddj.Q_sk_tt_app Q_sk_tt_app_new = new Q_sk_tt_app(M_Qskyd_mainrecord.id.ToString(), M_Qskyd_mainrecord.yddj, "lt");
                        Q_sk_tt_app_new.Left = 180;
                        Q_sk_tt_app_new.Top = 150;
                        Q_sk_tt_app_new.ShowDialog();
                    }
                }
            }
        }

        private void b_tsjy_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_sk_yddj_tsjy", common_file.common_app.user_type) == false)
            { return; }

            if (his_remind() == true)
            {
                return;
            }
            if (add_edit == common_file.common_app.get_edit)
            {
                string fjbh_0 = "";
                DataSet ds_temp = B_common.GetList("select * from Qskyd_fjrb", "lsbh='" + M_Qskyd_mainrecord.lsbh + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    fjbh_0 = ds_temp.Tables[0].Rows[0]["fjbh"].ToString();
                }
                Qyddj.Qtsjy Qtsjy_new = new Qtsjy(common_file.common_app.get_add, "sk", M_Qskyd_mainrecord.lsbh, M_Qskyd_mainrecord.sktt, M_Qskyd_mainrecord.krxm, fjbh_0, M_Qskyd_mainrecord.krsj, M_Qskyd_mainrecord.zjhm, xyh, M_Qskyd_mainrecord.xydw, M_Qskyd_mainrecord.hykh, " and lsbh='" + M_Qskyd_mainrecord.lsbh + "'");
                Qtsjy_new.Left = 150;
                Qtsjy_new.Top = 100;
                Qtsjy_new.ShowDialog();
                ds_temp.Dispose();

            }
        }

        private void b_krxh_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_sk_yddj_krxh", common_file.common_app.user_type) == false)
            { return; }

            if (his_remind() == true)
            {
                return;
            }

            if (add_edit == common_file.common_app.get_edit)
            {
                if (M_Qskyd_mainrecord.zjhm != "")
                {
                    Qyddj.Qkrxh Qkrxh_new = new Qkrxh("sk", common_file.common_app.get_add, M_Qskyd_mainrecord.krxm, M_Qskyd_mainrecord.krsj, M_Qskyd_mainrecord.hykh, M_Qskyd_mainrecord.zjhm);
                    Qkrxh_new.Left = 150;
                    Qkrxh_new.Top = 100;
                    Qkrxh_new.ShowDialog();
                }

            }
        }



        private void dg_ydpf_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (his_remind() == true)
            {
                return;
            }
            if (dg_count_lf > 0 && dg_ydpf.CurrentRow.Index < dg_count_lf && dg_ydpf.Rows[dg_ydpf.CurrentRow.Index].Cells["id_0"].Value.ToString() != "")
            {
                //string id_0 = dg_ydpf.Rows[dg_ydpf.CurrentRow.Index].Cells["id_0"].Value.ToString();
                common_file.common_form.Qskdj_new_open(dg_ydpf.Rows[dg_ydpf.CurrentRow.Index].Cells["id_0"].Value.ToString(), dg_ydpf.Rows[dg_ydpf.CurrentRow.Index].Cells["yddj_0"].Value.ToString(), common_file.common_app.get_edit, common_file.common_app.main_sec_main);
                tc_AddInfo.SelectTab(tc_AddInfo.TabPages[0]);
                //tc_AddInfo.TabPages[0].Show();
                //tc_AddInfo.Refresh();

            }
        }

        private void b_zczd_Click(object sender, EventArgs e)
        {
            if (yddj == common_file.common_yddj.yddj_dj)
            {
                if (common_file.common_roles.get_user_qx("B_sk_dj_zczd", common_file.common_app.user_type) == false)
                { return; }

            }
            else
            {
                if (yddj == common_file.common_yddj.yddj_yd)
                {
                    if (common_file.common_roles.get_user_qx("B_sk_yd_zczd", common_file.common_app.user_type) == false)
                    { return; }

                }
            }



            if (his_remind() == true)
            {
                return;
            }
            common_file.common_app.get_czsj();
            if (add_edit == common_file.common_app.get_edit)
            {
                if (yddj != common_file.common_yddj.yddj_dj)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，非登记状态不能设置！");
                }
                else
                {

                    if (main_sec == common_file.common_app.main_sec_main)
                    {
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，当前客人已经是主单客人了！");

                    }
                    else
                    {
                        if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "是否确定要生成独立的单子！") == true)
                        {
                            common_file.common_app.get_czsj();
                            string url = common_file.common_app.service_url;
                            url += "Qyddj/Qyddj_app.asmx";
                            object[] args = new object[5];
                            args[0] = M_Qskyd_mainrecord.id.ToString();
                            args[1] = M_Qskyd_mainrecord.lsbh.ToString();
                            args[2] = common_file.common_app.czy;
                            args[3] = DateTime.Now.ToString();
                            args[4] = common_file.common_app.xxzs;
                            Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete_1();
                            string result = Qyddj_add_edit_delete_1_services.New_skyd_dl_record(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString());
                            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "New_skyd_dl_record", args);
                            if (result.ToString() == common_file.common_app.get_suc)
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                                main_sec = common_file.common_app.main_sec_main;
                                Qskdj_1(Qskyd_id, yddj, common_file.common_app.get_edit);
                            }
                            else
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, result.ToString());
                            }
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void b_sfz_Click(object sender, EventArgs e)
        {
            if (his_remind() == true)
            {
                return;
            }

            Q_zjgl Q_zjgl_new = new Q_zjgl();

            //Q_zjgl_new.get_sfz_info_tb(ref tB_krxm, ref cB_krxb, ref tB_krmz, ref tB_krdz, ref tB_zjhm, ref dT_krsr, ref tB_krgj, ref tB_yxzj, true);
            common_file.CVRSDKReadCard cvrsdk = new Hotel_app.common_file.CVRSDKReadCard(ref tB_krxm, ref cB_krxb, ref tB_krmz, ref tB_krdz, ref tB_zjhm, ref dT_krsr, ref tB_krgj, ref tB_yxzj,ref pb_photo, true);
            if (tB_zjhm.Text.Trim() != "")
            {
                tB_krly.Focus();
            }
        }

        private void b_hy_Click(object sender, EventArgs e)
        {
            if (his_remind() == true)
            {
                return;
            }
            Hhygl.H_hygl_k H_hygl_k_new = new Hotel_app.Hhygl.H_hygl_k();
            H_hygl_k_new.add_hy_info("", true, ref tB_hykh_bz, ref  hyrx, ref hykh, ref  tB_krxm, ref  tB_krgj, ref  tB_yxzj, ref  tB_zjhm, ref  tB_krmz, ref  cB_krxb, ref  dT_krsr, ref  tB_krdh, ref  tB_krsj, ref  tB_krEmail, ref  tB_krdz, ref  tB_krzy, ref  tB_krdw, ref  tB_qzrx, ref  tB_qzhm, ref  dT_zjyxq, ref  dT_tlyxq, ref  dT_tjrq, ref  tB_lzka);
            if (hykh != "")
            {
                tB_krly.Text = common_file.common_app.krly_hy;
                tB_krly.Focus();
            }
        }

        private void tB_hykh_TextChanged(object sender, EventArgs e)
        {


        }

        private void tB_hykh_Leave(object sender, EventArgs e)
        {
            if (tB_hykh_bz.Text.Trim() != "")
            {
                Hhygl.H_hygl_k H_hygl_k_new = new Hotel_app.Hhygl.H_hygl_k();
                H_hygl_k_new.add_hy_info(tB_hykh_bz.Text.Trim().Replace("'", "-"), false, ref  tB_hykh_bz, ref  hyrx, ref hykh, ref  tB_krxm, ref  tB_krgj, ref  tB_yxzj, ref  tB_zjhm, ref  tB_krmz, ref  cB_krxb, ref  dT_krsr, ref  tB_krdh, ref  tB_krsj, ref  tB_krEmail, ref  tB_krdz, ref  tB_krzy, ref  tB_krdw, ref  tB_qzrx, ref  tB_qzhm, ref  dT_zjyxq, ref  dT_tlyxq, ref  dT_tjrq, ref  tB_lzka);
                if (hykh != "")
                {
                    tB_krly.Text = common_file.common_app.krly_hy;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p_lskr.Visible = false;
        }

        private void tB_krxm_Leave(object sender, EventArgs e)
        {
            if (tB_krxm.Text != "")
            {
                DataSet DS_temp = B_common.GetList("select id from VIEW_Q_skyd_lskr", "krxm like '%" + tB_krxm.Text.Trim() + "%'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (add_edit == common_file.common_app.get_add || (M_Qskyd_mainrecord.krxm != tB_krxm.Text.Trim().Replace("'", "-") && add_edit == common_file.common_app.get_edit))
                    {
                        Qyddj.Q_lskr_open Q_lskr_open_new = new Qyddj.Q_lskr_open(" and krxm like '%" + tB_krxm.Text.Trim() + "%' ", this);
                        Q_lskr_open_new.Left = 80;
                        Q_lskr_open_new.Top = 100;
                        Q_lskr_open_new.ShowDialog();
                        //common_file.common_app.Message_box_show(common_file.common_app.message_title, "1233");
                    }
                    else
                    {
                        p_lskr.Left = tB_krxm.Left + tB_krxm.Width - p_lskr.Width;
                        p_lskr.Top = tB_krxm.Top - 1;
                        p_lskr.Visible = true;
                        ck_lskr_krxm_zjhm = "krxm";

                    }
                }
                DS_temp.Clear();
                DS_temp.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ck_lskr_krxm_zjhm == "krxm")
            {
                tB_krxm_Leave(sender, e);

            }
            else
                if (ck_lskr_krxm_zjhm == "zjhm")
                {
                    tB_zjhm_Leave(sender, e);

                }
        }

        private void b_his_Click(object sender, EventArgs e)
        {

        }

        private void tc_AddInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_AddInfo.SelectedIndex == 3 || tc_AddInfo.SelectedIndex == 5||tc_AddInfo.SelectedIndex==4)
            {
                //tab_xs_dd.Visible = false;
                tab_bz.Visible = false;
                //tab_dd_lk.Visible = false;
                tab_fjrb.Visible = false;
                tc_AddInfo.Dock = DockStyle.Fill;
                //(dg_Qttdj_detail);
            }
            else
            {
                tc_AddInfo.Dock = DockStyle.Top;
                //tab_xs_dd.Visible = true;
                tab_bz.Visible = true;
                //tab_dd_lk.Visible = true;
                tab_fjrb.Visible = true;
            }
            if (add_edit != common_file.common_app.get_add)
            {
                czjl_ls("", add_edit);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_sk_yddj_fzyd", common_file.common_app.user_type) == false)
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
                    string lsbh_new = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                    string ddbh_new = common_file.common_ddbh.ddbh("skyd", "skyddate", "skydcounter", 6);
                    url += "Qyddj/Qyddj_app.asmx";
                    object[] args = new object[10];
                    args[0] = M_Qskyd_mainrecord.yydh;
                    args[1] = M_Qskyd_mainrecord.qymc;
                    args[2] = "sk";
                    args[3] = M_Qskyd_mainrecord.lsbh;
                    args[4] = lsbh_new;
                    args[5] = ddbh_new;
                    args[6] = common_file.common_app.czy;
                    args[7] = DateTime.Now;
                    args[8] = "复制预订";
                    args[9] = common_file.common_app.xxzs;

                    Hotel_app.Server.Qyddj.Q_copy_yd Q_copy_yd_services = new Hotel_app.Server.Qyddj.Q_copy_yd();
                    string result = Q_copy_yd_services.copy_sk_yd(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), DateTime.Parse(args[7].ToString()), args[8].ToString(), args[9].ToString());
                    //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "copy_sk_yd", args);
                    if (result== common_file.common_app.get_suc)
                    {
                        DataSet ds_temp_00 = B_common.GetList(" select * from Qskyd_mainrecord ", " id>=0  and  lsbh='" + lsbh_new + "'  and yydh='" + common_file.common_app.yydh + "'");
                        if (ds_temp_00 != null && ds_temp_00.Tables[0].Rows.Count > 0)
                        {
                            common_file.common_form.Qskdj_new_open(ds_temp_00.Tables[0].Rows[0]["id"].ToString(), ds_temp_00.Tables[0].Rows[0]["yddj"].ToString(), common_file.common_app.get_edit,common_file.common_app.main_sec_main);
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
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void b_djb_print_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_sk_yddj_print_djb", common_file.common_app.user_type) == false)
            { return; }
            if (this.lsbh.Trim() != "")
            {
                if(common_file.common_app.message_box_show_select(common_file.common_app.message_title,"您确认要打印登记表嘛？"))
                {
                    common_file.common_app.get_czsj();
                    common_file.common_PrintFrm common_PrintFrm_new = new Hotel_app.common_file.common_PrintFrm(this.lsbh, "sk", common_file.common_app.czy, "");

                //Q_skyd_print_djb Q_skyd_print_djb_new = new Q_skyd_print_djb(this.lsbh, "sk", common_file.common_app.czy, "");
                //Q_skyd_print_djb_new.czy = common_file.common_app.czy;
                //Q_skyd_print_djb_new.Visible = false;
                Cursor.Current = Cursors.Default;
                }
            }
        }



        private void keyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.return_KeyPress(sender, e);
        }

        private void tB_kr_children_KeyPress(object sender, KeyPressEventArgs e)
        {
            common_file.common_app.Num_KeyPress(sender, e);
        }


        //更新2012  06-28(操作记录移到此处)
        public void czjl_ls(string sql_0,string add_edit_delete_his)
        {
            string lsbh_czjl = "";
            DataSet  ds_czjl_zd=null;
            DataSet ds_czjl_fxfj = null;
            if (add_edit_delete_his != common_file.common_app.get_his)
            {
                if (this.M_Qskyd_mainrecord != null)
                {
                    lsbh_czjl = M_Qskyd_mainrecord.lsbh;
                }
            }
            if (add_edit_delete_his == common_file.common_app.get_his)
            {
                if (M_Qskyd_mainrecord_bak != null)
                {
                    lsbh_czjl = M_Qskyd_mainrecord_bak.lsbh;
                }
            }
            ds_czjl_zd = B_common.GetList("select * from Qskyd_mainrecord_temp ", "ID>=0  and  yydh='" + common_file.common_app.yydh + "' and  lsbh='" + lsbh_czjl + "' "+sql_0+"  order by czsj desc");
            //if (ds_czjl_zd != null && ds_czjl_zd.Tables[0].Rows.Count > 0)
            //{

            dg_skzd_czjl.AutoGenerateColumns = false;
            bindingSource_czjl_zd.DataSource = ds_czjl_zd.Tables[0].DefaultView;
            dg_skzd_czjl.DataSource = bindingSource_czjl_zd;
            //}
            ds_czjl_fxfj = B_common.GetList(" select * from Qskyd_fjrb_temp ", "ID>=0  and  yydh='" + common_file.common_app.yydh + "' and  lsbh='" + lsbh_czjl + "'"+sql_0+"  order by czsj desc");
            //if (ds_czjl_fxfj != null && ds_czjl_fxfj.Tables[0].Rows.Count > 0)
            //{

                dg_czjl_fxfj.AutoGenerateColumns = false;
                bindingSource_czjl_fxfj.DataSource = ds_czjl_fxfj.Tables[0].DefaultView;
                dg_czjl_fxfj.DataSource = bindingSource_czjl_fxfj;
            //}
        }

        private void tab_fjrb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (add_edit != common_file.common_app.get_add)
            {
                czjl_ls("", add_edit);
            }
            
        }

        //些函数用于进入账务时检查是否有其它费用需要导入的
        //返回2时说明有要导入的其它费用，否则返回0
        //noticeInfo是要导入前的提示文档
        private int CheckOtherFee(ref  string  NoticeInfo,ref  string importType)
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
            DataSet ds_cy_fee = B_common.GetList(" select distinct  lsbh  from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and fjbh!=''   and  shlz='1'  ) ");
            if (ds_cy_fee != null && ds_cy_fee.Tables[0].Rows.Count > 0)
            {
                ds_cy_fee_00 = B_common.GetList(" select * from S_cy_zl", "id>=0  and    yydh='" + common_file.common_app.yydh + "'  and  shsc=0   and  lsbh  in ( select  lsbh  from Flfsz  where   id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'  and  shlz='1'  )) ");
                {
                    if (ds_cy_fee_00 != null && ds_cy_fee_00.Tables[0].Rows.Count > 0)
                    {
                        i = 2;
                    }
                }
            }
            //不联房
            else
            {
                ds_cy_fee_00 = B_common.GetList(" SELECT  *  from S_cy_zl ", "id>=0 and  yydh='" + common_file.common_app.yydh + "'  and  shsc=0  and  lsbh='" + lsbh + "' ");
                if (ds_cy_fee_00 != null && ds_cy_fee_00.Tables[0].Rows.Count > 0)
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

        private void tB_krxm_Leave_1(object sender, EventArgs e)
        {
            if (tB_krxm.Text.Trim() != "")
            {
                DataSet DS_temp = B_common.GetList("select id from VIEW_Q_skyd_lskr", "krxm = '" + tB_krxm.Text.Trim() + "'");
                if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                {
                    if (M_Qskyd_mainrecord.krxm != tB_krxm.Text.Trim().Replace("'", "-"))
                    {
                        Qyddj.Q_lskr_open Q_lskr_open_new = new Qyddj.Q_lskr_open(" and krxm = '" + tB_krxm.Text.Trim() + "'", this);
                        Q_lskr_open_new.Left = 80;
                        Q_lskr_open_new.Top = 100;
                        Q_lskr_open_new.ShowDialog();
                        //common_file.common_app.Message_box_show(common_file.common_app.message_title, "1233");
                    }
                    else
                    {
                        p_lskr.Left = tB_krxm.Left + tB_krxm.Width - p_lskr.Width;
                        p_lskr.Top = tB_krxm.Top - 1;
                        p_lskr.Visible = true;
                        //ck_lskr_krxm_zjhm = "zjhm";

                    }
                }
                DS_temp.Clear();
                DS_temp.Dispose();
            }
        }

        private void b_del_other_Click(object sender, EventArgs e)
        {
            if (dg_qskyd_mainRecord_OtherPerson.CurrentRow != null)
            {
                int i = dg_qskyd_mainRecord_OtherPerson.CurrentRow.Index;
                string temp = dg_qskyd_mainRecord_OtherPerson.CurrentRow.Cells["mainOrSec"].Value.ToString();
                if (dg_qskyd_mainRecord_OtherPerson.CurrentRow.Cells["mainOrSec"].Value.ToString() == common_file.common_app.main_sec_sec && dg_qskyd_mainRecord_OtherPerson.CurrentRow.Cells["index"].Value.ToString() != "")
                {
                    if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要删除所选的客人信息嘛？") == true)
                    {
                        BLL.Common B_Common = new Hotel_app.BLL.Common();
                        if (B_Common.ExecuteSql(" delete from Qskyd_mainrecord  where id='" + dg_qskyd_mainRecord_OtherPerson.CurrentRow.Cells["index"].Value.ToString() + "'") > 0)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "删除住客信息成功！");
                            dg_qskyd_mainRecord_OtherPerson.AutoGenerateColumns = false;
                            dg_qskyd_mainRecord_OtherPerson.DataSource = B_Qskyd_mainrecord.GetModelList("ID>=0  and yydh='" + common_file.common_app.yydh + "'  and   lsbh='" + lsbh + "'  order by id");
                            return;

 
                        }
                    }
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "当前只能删除非主要客人的信息，无法删除主单客人信息！"); return;
                }
            }
        }

        private void Qskdj_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (common_file.common_form.Qskdj_browse_new != null)
            {
                if (common_file.common_form.Qskdj_browse_new.sel_condition.Trim() != "")
                {
                    if (common_file.common_form.Qskdj_browse_new.sel_condition.Trim() != "")
                    {
                        common_file.common_form.Qskdj_browse_new.refresh_app(common_file.common_form.Qskdj_browse_new.sel_condition);
                    }
 
                }
            }
        }

        private void dT_ddsj_date_ValueChanged(object sender, EventArgs e)
        {
            dT_lksj_date.Value = dT_ddsj_date.Value.AddDays(1).Date;
        }

        private void b_setTTcyFf_Click(object sender, EventArgs e)
        {
            if (common_file.common_roles.get_user_qx("B_cyffzf", common_file.common_app.user_type) == false)
            { return; }
            if (this.sktt == common_file.common_sktt.sktt_tt || this.sktt == common_file.common_sktt.sktt_hy)
            {
                if (Qskyd_id > 0)
                {
                    Szwgl.common_zw.SetTTcyFF(Qskyd_id.ToString(), "sk");
                }
                 
            }
        }
    }
}