using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Maticsoft.Common;


namespace jdgl_res_head_app
{
    public partial class F_main : Form
    {
        string url = "";
        string qymc = "";
        string Local_lsbh = "";
        //用于接收执行存储过程后的值（通用变量）
        int temp_result = 0;
        //用于错误日志
        string errorInfo = "";
        //用于标识错误出现位置
        string postion = "";
        public static bool StateSc =true;//是否开始传输
        Login lg = new Login();

        public F_main()
        {
            InitializeComponent();
            this.url = url = common_file.common_app.url;
        }

        private void f_clock_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();//关闭应用程序 
        }

        //配置文件
        private void x_configgl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                Xxtsz.X_Config xconfig = new jdgl_res_head_app.Xxtsz.X_Config();
                xconfig.StartPosition = FormStartPosition.CenterParent;
                xconfig.ShowDialog();
            }
        }

        private void serviceline_Click(object sender, EventArgs e)
        {
            TestRemoteServerStatus();
        }

        #region  初始设置
        //初始企业信息(web_qyxx)
        private void M_Csqyxx_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                common_file.Common_qyxx.CS_qyxx();
            }
        }

        //初始协议单位 ------->Xxydw
        private void Ts_start_Yxydw_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                //记住如果大的数据不能下
                common_file.Common_Yxydw.M_Ts_start_Yxydw();
                //DbHelperSQL.ExecuteSql("delete from Yxydw where yydh<>'" + common_file.common_app.yydh + "'");
                //协议单位自动上传下载程序
            }
        }

        //初始会员房价
        private void Ts_start_Hhyfj_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                common_file.Common_Hhyfj.Cs_Hhyfj();
            }
        }
        
        //初始房间Ffjrb同时初始ffjzt表(web_fjrb)
        private void Ts_fjrb_Click(object sender, EventArgs e)
        {
            common_file.Common_fjrb.M_Ts_Ffjrb();
        }

        private void 上传房间状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common_file.Common_Ffjzt.M_UpLoad_Ffjzt_new();
        }
        #endregion

        #region  会员Functions
        //会员信息上传
        private void Ts_start_hygl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                Hhygl_UpLoad();
            }
        }
      
        #region     上传会员信息

        //上传会员信息
        private void Hhygl_UpLoad()
        {
            int rowssum = 0;
            BLL.Hhygl B_Hhygl = new BLL.Hhygl();
            string yydh = common_file.Common.Getqyxx(1);//读取营业代号

            DataSet DS_Hhygl = B_Hhygl.GetList(200," ID>=0 and yydh='" + yydh + "'  and shqr=1 and shsc=0","id");
            string cssjtime =common_file.Common_hygl.GetScsj();
            string jstime = DateTime.Now.ToString();
            DataSet DS_HhyglUp = B_Hhygl.GetList(300," shxg=1  and shqr=1 and xgsj>='"+cssjtime+"'","id");
            try
            {
                if ((DS_Hhygl != null && DS_Hhygl.Tables[0].Rows.Count > 0) || (DS_HhyglUp != null && DS_HhyglUp.Tables[0].Rows.Count > 0))
                {
                    if (DS_Hhygl != null && DS_Hhygl.Tables[0].Rows.Count > 0)
                    {
                        rowssum = common_file.Common_hygl.UpLoad_hygl(DS_Hhygl);
                        common_file.Common.AddMsg(DS_Hhygl, "上传会员信息");
                    }
                    if (DS_HhyglUp != null && DS_HhyglUp.Tables[0].Rows.Count > 0)
                    {
                        rowssum = common_file.Common_hygl.UpLoad_hygl(DS_HhyglUp);
                        common_file.Common.AddMsg(DS_HhyglUp, "上传会员信息");
                    }
                    //common_file.common_app.AddMsg(listBox1, string.Format("向服务器发送会员信息文件已完成{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    ts_lable_txt.Text = "没有相关数据要上传";
                    //common_file.common_app.AddMsg(listBox1, string.Format("向服务器发送会员信息没有相关数据要上传{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }
            catch (Exception ee)
            {
                #region 些段更新于2011-10-25（写日志功能)
                //开始写日志
                errorInfo = ee.Message.ToString();
                postion = "上传会员信息时出错";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                #endregion
            }
            finally
            {
                DS_Hhygl.Dispose();
                DS_HhyglUp.Dispose();
            }
        }



        //上传积分兑换
        private void Hhyjf_df_UpLoad()
        {
            try
            {
                int rowssum = 0;
                BLL.Hhyjf_df B_Hhyjfdf = new BLL.Hhyjf_df();
                string yydh = common_file.Common.Getqyxx(1);//读取营业代号
                DataSet DS_Hhyjfdf = B_Hhyjfdf.GetList(200," ID>=0 and yydh='" + yydh + "' and shsc=0","id");

                if ((B_Hhyjfdf != null && DS_Hhyjfdf.Tables[0].Rows.Count > 0))
                {

                    rowssum = common_file.Common_hygl.UpLoad_hyjfdf(DS_Hhyjfdf);
                    common_file.Common.AddMsg(DS_Hhyjfdf, "上传会员积分兑换");

                    ts_lable_txt.Text = "会员积分兑换上传成功" + rowssum + "条记录";
                    //common_file.common_app.AddMsg(listBox1, string.Format("向服务器上传会员积分兑换上传成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    ts_lable_txt.Text = "没有相关数据要上传";
                    //common_file.common_app.AddMsg(listBox1, string.Format("向服务器上传会员积分兑换没有相关数据要上传{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                DS_Hhyjfdf.Dispose();

            }
            catch (Exception ee)
            {
                #region 些段更新于2011-10-25（写日志功能)
                //开始写日志
                errorInfo = ee.Message.ToString();
                postion = "上传积分兑换时出错";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                #endregion
            }
        }


        //上传积分消费记录
        private void Hhyjf_xfjl_UpLoad()
        {
            try
            {
                int rowssum = 0;
                BLL.Hhyjf_xfjl B_Hhyjf_xfjl = new BLL.Hhyjf_xfjl();
                string yydh = common_file.Common.Getqyxx(1);//读取营业代号

                DataSet DS_Hhyjf_xfjl = B_Hhyjf_xfjl.GetList(200," ID>=0 and yydh='" + yydh + "' and shsc=0","id");
                if ((DS_Hhyjf_xfjl != null && DS_Hhyjf_xfjl.Tables[0].Rows.Count > 0))
                {
                    rowssum = common_file.Common_hygl.UpLoad_hyjf_xfjl(DS_Hhyjf_xfjl);
                    common_file.Common.AddMsg(DS_Hhyjf_xfjl, "上传会员积分消费");
                    ts_lable_txt.Text = "会员积分消费记录上传成功" + rowssum + "";
                    //common_file.common_app.AddMsg(listBox1, string.Format("向服务器发送会员积分消费记录上传成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    ts_lable_txt.Text = "没有相关数据要上传";
                    //common_file.common_app.AddMsg(listBox1, string.Format("向服务器发送会员积分消费记录没有相关数据要上传{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                DS_Hhyjf_xfjl.Dispose();
            }
            catch (Exception ee)
            {
                #region 些段更新于2011-10-25（写日志功能)
                errorInfo = ee.Message.ToString();
                postion = "上传积分消费记录时出错";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                #endregion
            }
        }
        #endregion

        #region   下载会员信息，积分兑换,积分消费记录
        private void DownLoad_Hhyjf_df()
        {
            try
            {
                common_file.Common_hygl.DownLoad_hyjf_df();
            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "下载会员积分兑换时出错");
            }
        }
        public void DownLoad_Hygl()
        {
            try
            {
                common_file.Common_hygl.DownLoad_Hygl();
            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "下载会员信息时出错");
            }
        }


        //下载积分消费记录
        public void DownLoad_Hygljf_xfjl()
        {
            try
            {
                common_file.Common_hygl.DownLoad_hyjf_xfjl();

            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "下载会员信息时出错");
            }
        }
        



        //下载积分奖品
        public void DownLoad_Hygljf_jp()
        {
            try
            {
                common_file.Common_hygl.DownLoad_hyjf_jp();
            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "下载会员信息时出错");
            }
        }
        private void DL_hygl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                DownLoad_Hygl();
            }
        }


        private void UpLoad_hyjfdf_Click(object sender, EventArgs e)
        {
            Hhyjf_df_UpLoad();
        }

        private void UpLoad_hyjf_xfjl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                Hhyjf_xfjl_UpLoad();
            }
        }

        private void DownLoad_hyjf_df_Click(object sender, EventArgs e)
        {
            DownLoad_Hhyjf_df();
        }

        private void M_DownLoad_hyjfxfjl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                DownLoad_Hygljf_xfjl();
            }
        }


        private void M_Download_hyjf_jp_Click(object sender, EventArgs e)
        {
            DownLoad_Hygljf_jp();
        }

        #endregion

        //自动上传会员信息
        void ScHygl()
        {
            if (TestRemoteServerStatus() == 1)
            {
                ts_lable_txt.Text = "会员信息上传开始.....";
                Hhygl_UpLoad(); //上传会员信息
                Hhyjf_df_UpLoad(); //上传积分兑换
                Hhyjf_xfjl_UpLoad();//上传积分消费
                string jstime = DateTime.Now.ToString();
                common_file.Common_hygl.Update_Hhy_scxzsj(jstime);//上传完后修改本地的上传时候，使修改过的会员信息不会重复上传

                ts_lable_txt.Text = "下载会员信息开始";
                DownLoad_Hygl();//下载会员信息
                DownLoad_Hhyjf_df();//下载会员兑换
                DownLoad_Hygljf_xfjl();//下载积分消费记录
                ts_lable_txt.Text = "会员信息交流结束";
                common_file.common_app.AddMsg(listBox1, string.Format("上传下载会员信息成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
 
        }
        #endregion

        #region  数据交流        
        private void UpLoad_Qskydfjrb()
        {
            ts_lable_txt.Text = "上传房间类别和维修开始";
            int Upsum = common_file.Common_Qskyd_fjrb.UpLoad_Qskyd_fjrb();
            if (Upsum > 0)
            {
                ts_lable_txt.Text = "成功上传" + Upsum.ToString() + "条记录";  
            }
            ts_lable_txt.Text = "上传房间类别和维修结束";
        }
        //自动上传房间类别和维修房
        private void timer_AuTo_UpLoad_Qskydfjrb_Tick(object sender, EventArgs e)
        {
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
            if (TestRemoteServerStatus() == 1)
            {
                UpLoad_Qskydfjrb();//上传房间
                common_file.common_app.AddMsg(listBox1, string.Format("上传房间类别和维修房成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                common_file.Common.WriteLog("远程Webservices连接不上,请检查配置信息", "上传房间类别和维修房");
            }
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = true;
        }
        //会员信息交流
        private void M_AutoHygl_Click(object sender, EventArgs e)
        {
            ScHygl();
        }
        //预定信息交流
        private void download_ydxx_Click(object sender, EventArgs e)
        {
            UPdownload_Ydxx();
        }
        private void UpLoad_Qskyd_fjrb_Click(object sender, EventArgs e)
        {
            UpLoad_Qskydfjrb();
        }
        public void UPdownload_Ydxx()
        {
            if (TestRemoteServerStatus() == 1)
            {
                int Upsum = common_file.Common_yddj.Download_orderFrom400();
                common_file.Common_yddj.InsertToQttyd_ydzxqr();//上传门店确定后的信息
                common_file.Common_yddj.InsertToQttyd_ydzlzmx(); //上传门店确定后转登记的明细
                common_file.common_app.AddMsg(listBox1, string.Format("预定下载上传信息成功" + Upsum.ToString() + "条记录{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                if (Upsum > 0)
                {
                    ts_lable_txt.Text = "成功下载" + Upsum.ToString() + "条记录";

                }
                else
                {
                    ts_lable_txt.Text = "当前没有要下载的数据";
                }
            }
            else
            {
                common_file.Common.WriteLog("远程Webservices连接不上,请检查配置信息", "上传下载预订信息");
            }
 
        }

        public void UPdownload_Ydxx_test()
        {
            if (TestRemoteServerStatus() == 1)
            {
                int Upsum = common_file.Common_yddj.Download_orderFrom400_test();
                common_file.common_app.AddMsg(listBox1, string.Format("预定下载上传信息成功" + Upsum.ToString() + "条记录{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                if (Upsum > 0)
                {
                    ts_lable_txt.Text = "成功下载" + Upsum.ToString() + "条记录";

                }
                else
                {
                    ts_lable_txt.Text = "当前没有要下载的数据";
                }
            }
            else
            {
                common_file.Common.WriteLog("远程Webservices连接不上,请检查配置信息", "上传下载预订信息");
            }

        }
        #endregion

        #region 报表上传
        //上传消费明细
        private void B_SsyxmfxUploand_Click(object sender, EventArgs e)
        {
            common_file.Common_Ssyxmfx.Cs_Ssyxmfx();
            common_file.Common_Ssyxmfx.Cs_Ssyxfmx_cz();
            common_file.Common_Ssyxmfx.Cs_Ssyxfmx_xsy();
            //同时也要上传Bszhrbbfl
            common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();

        }
        //综合日报表上传
        private void BBzhrbb_uploand_Click(object sender, EventArgs e)
        {
            common_file.Common_BSzhrbb.BSzhrbb_uploand();
        }
        //报表分录上传
        private void Bszhrbb_uploand_Click(object sender, EventArgs e)
        {
            common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();
        }
        #endregion

        #region  计时器部分
        private void timer_UpLoad_Hhygl_Tick(object sender, EventArgs e)
        {
            this.timer_UpLoad_Hhygl.Enabled = false;
            this.toolStripStatusLabel1.Text = "注意，自动上传会员信息以经开启";
            if (TestRemoteServerStatus() == 1)
            {
                ScHygl();
            }
            else
            {
                txt_messageofWSconnectStatus.Text = "远程Webservices连接不上,请检查配置信息";
                common_file.Common.WriteLog("远程Webservices连接不上,请检查配置信息", "上传下载会员信息");
            }
            this.toolStripStatusLabel1.Text = "自动上传开启成功";
            this.timer_UpLoad_Hhygl.Enabled = true;
        }
        private void timer_SsyxfmxUpload_Tick(object sender, EventArgs e)
        {
            this.timer_SsyxfmxUpload.Enabled = false;
            if (TestRemoteServerStatus() == 1)
            {
                ts_lable_txt.Text = "上传消费名细开始";
                common_file.Common_Ssyxmfx.Cs_Ssyxmfx();
                common_file.Common_Ssyxmfx.Cs_Ssyxfmx_cz();
                common_file.Common_Ssyxmfx.Cs_Ssyxfmx_xsy();
                common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();
                common_file.common_app.AddMsg(listBox1, string.Format("上传消费名细成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                ts_lable_txt.Text = "上传消费名细结束";

            }
            timer_SsyxfmxUpload.Enabled = true;

        }
        /// <summary>
        /// 综合日报表，历史客人晚上4点上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Bb_Tick(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            int intHour = CurrentTime.Hour;
            int intMinute = CurrentTime.Minute;
            int intSecond = CurrentTime.Second;

            if (intHour == 5 && intMinute <= 59)//如果现在时间等于晚上4点
            {
                this.timer_Bb.Enabled = false;
                common_file.Common_BSzhrbb.BSzhrbb_uploand();//上传综合日报表
                //common_file.Common_hygl.Update_hygljf();
                common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();//上传分录
                //上传下载历史客人
                common_file.Common_lskr.UpLoad_lskr();
                common_file.Common_lskr.Download_lskr();
                common_file.common_app.AddMsg(listBox1, string.Format("上传下载历史客人与综合日报表成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                this.timer_Bb.Enabled = true;
            }
            else
            {
                //判断协议单位是否要上传下载
                if (common_file.common_app.xydwsc == "0")
                {
                    common_file.Common_Yxydw.Upload_Yxydw();//上传协议单位
                }
                if (common_file.common_app.xydwxz == "0")
                {
                    common_file.Common_Yxydw.Download_Yxydw();//下载协议单位
                    common_file.Common_Yxydw.DownLoad_Yxydw_fjrb();//下载协议价2012-11-02
                    common_file.common_app.AddMsg(listBox1, string.Format("上传下载单位成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }

        }
        /// <summary>
        /// 协议单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_AutoQxydw_Click(object sender, EventArgs e)
        {
            try
            {
                if (common_file.common_app.xydwsc == "0")
                {
                    common_file.Common_Yxydw.Upload_Yxydw();//上传协议单位
                }
                if (common_file.common_app.xydwxz == "0")
                {
                    common_file.Common_Yxydw.Download_Yxydw();//下载协议单位
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "上传下载协议单位没有开启");

                }

            }
            catch (Exception ea)
            {
                common_file.Common.WriteLog(ea.Message, "上传下载协议单位时出错");
            }

        }
        /// <summary>
        /// 预订登记信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Ydxx_Tick(object sender, EventArgs e)
        {
            this.timer_Ydxx.Enabled = false;
            this.toolStripStatusLabel1.Text = "下载预定信息开启";
            if (TestRemoteServerStatus() == 1)
            {
                UPdownload_Ydxx();//下载预订中心信息
                UpLoad_Qskydfjrb();//上传Qskyd_fjrb和other维修房表，分析房态用2012-10-26修改预计中心人员用
                common_file.Common_Ffjzt.M_UpLoad_Ffjzt_new();//2012-09-19新加的时实更新网上房态
            }
            else
            {
                common_file.Common.WriteLog("远程Webservices连接不上,请检查配置信息", "下载预定信息");
                txt_messageofWSconnectStatus.Text = "远程Webservices连接不上,请检查配置信息";
            }
            this.toolStripStatusLabel1.Text = "下载预定信息结束";
            this.timer_Ydxx.Enabled = true;
        }
        #endregion

        #region   窗体事件
        private void F_main_Load(object sender, EventArgs e)
        {
            common_file.common_sjtb.SetDate();//同步时间
            common_file.Common.Fmain_Instance = this;
            this.toolStripStatusLabel1.Text = "提示:当前没有上传数据";
            this.notifyIcon1.Visible = false;
            if (TestRemoteServerStatus() == 1)
            {
                common_file.common_app.AddMsg(listBox1, string.Format("连接服务器成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                if (StateSc)
                {
                    this.txt_messageofWSconnectStatus.Text = common_file.common_app.qymc;
                    //自动上传下载会员信息的计时器(一天）
                    timer_UpLoad_Hhygl.Enabled = false;
                    timer_UpLoad_Hhygl.Interval = 35 * 60 * 1000;
                    timer_UpLoad_Hhygl.Enabled = true;


                    //自动上传Qskyd_fjrb和other维修房表，分析房态表（5分钟）
                    timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
                    timer_AuTo_UpLoad_Qskydfjrb.Interval = 6 * 60 * 1000;
                    timer_AuTo_UpLoad_Qskydfjrb.Enabled = true;


                    //上传消费明细
                    timer_SsyxfmxUpload.Enabled = false;
                    timer_SsyxfmxUpload.Interval = 20 * 60 * 1000;
                    timer_SsyxfmxUpload.Enabled = true;


                    //综合日报表和分录表，历史客人, //协议单位自动上传下载程序
                    timer_Bb.Enabled = false;
                    timer_Bb.Interval = 40 * 60 * 1000;
                    timer_Bb.Enabled = true;


                    //下载预定信息
                    timer_Ydxx.Enabled = false;
                    timer_Ydxx.Interval = 4 * 60 * 1000;
                    timer_Ydxx.Enabled = true;
                }
                else
                {
                    toolStripStatusLabel1.Text = "传输关闭";
                }
            }
            else
            {
                Xxtsz.X_Config xconfig = new jdgl_res_head_app.Xxtsz.X_Config();
                xconfig.StartPosition = FormStartPosition.CenterParent;
                xconfig.ShowDialog();
                common_file.Common.WriteLog("远程Webservices连接不上,请检查配置信息", "程序初始时");
            }
        }

        //关闭上传程序
        private void M_Ts_AutoClose_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "注意,自动上传关闭";
            timer_UpLoad_Hhygl.Enabled = false;
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
            timer_SsyxfmxUpload.Enabled = false;
            timer_Bb.Enabled = false;
            StateSc = false;
        }
        //开始自动传输程序
        private void M_Ts_AutoBegin_Click(object sender, EventArgs e)
        {
            StateSc = true;
            this.toolStripStatusLabel1.Text = "注意,自动上传开启成功";
        }

        //关闭上传程序
        private void M_closecopy_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "注意,自动上传关闭";
            timer_UpLoad_Hhygl.Enabled = false;
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
            timer_SsyxfmxUpload.Enabled = false;
            timer_Bb.Enabled = false;
            StateSc = false;
        }

        //用于测试WEBservice是否正常,正常的时候返回值为1
        private int TestRemoteServerStatus()
        {
            string url = common_file.Common.ReadXML("add", "url") + "/Xxtsz/Xxtsz_app.asmx";
            int status = -1;
            try
            {
                object temp = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "HelloServer", null);
                if (temp.ToString() == "1")
                {
                    ts_lable_txt.Text = "恭喜,远程服务器连接成功";
                    status = Convert.ToInt32(temp.ToString());
                }
                else
                {
                    errorInfo = "远程服务器连接出错";
                    postion = "远程服务器连接出错";
                    txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                }
            }
            catch (Exception RemoteException)
            {
                errorInfo = RemoteException.Message.ToString();
                postion = "远程服务器连接出错";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                //MessageBox.Show(RemoteException.Message.ToString());
            }
            return status;
        }
        //最小化事件
        private void F_main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }
        //双击通告栏双击事件
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Close();
            this.Dispose();
            Application.Exit();

        }

        //历史客人交流
        private void M_Autolskr_Click(object sender, EventArgs e)
        {
            common_file.Common_lskr.UpLoad_lskr();
            common_file.Common_lskr.Download_lskr();

        }

        //向listBox中增加信息
        public  void AddMsg(string msgStr)
        {
            this.listBox1.Items.Add(msgStr);
        }

        private void Tm_xzxyj_Click(object sender, EventArgs e)
        {
            common_file.Common_Yxydw.DownLoad_Yxydw_fjrb();
        }
        private void xztest_Click(object sender, EventArgs e)
        {
            UPdownload_Ydxx_test();
        }
#endregion       
    }
}