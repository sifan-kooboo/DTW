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
    public partial class F_main_S8 : Form
    {
        string url = "";
        public F_main_S8()
        {
            InitializeComponent();
            url = common_file.common_app.url;
        }

        
        //预订数据下载
        private void download_ydxx_Click(object sender, EventArgs e)
        {
            Com.OrderHelper.DownLoadOrderFromSite();
        }

        #region  计时器部分
        /// <summary>
        /// 预订登记信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Ydxx_Tick(object sender, EventArgs e)
        {
            this.timer_Ydxx.Enabled = false;
            this.toolStripStatusLabel1.Text = "下载预定信息开启";
            string Msg=string.Empty;
            if (Com.CommFunc.TestRemoteServerStatus(ref Msg) == 1)
            {
                Com.OrderHelper.DownLoadOrderFromSite();  //从网站下载订单信息
                Com.OrderHelper.RefreshOrderStatus();           //根据门店的确认情况，更新网站上的订单信息
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
            Com.Common.Fmain_Instance = this;
            this.toolStripStatusLabel1.Text = "提示:当前没有下载预订数据";
            this.notifyIcon1.Visible = false;
            string msg = string.Empty;
            if (Com.CommFunc.TestRemoteServerStatus(ref msg) == 1)
            {
                common_file.common_app.AddMsg(listBox1, string.Format("连接服务器成功{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                {
                    this.txt_messageofWSconnectStatus.Text = common_file.common_app.qymc;
                    ////自动上传下载会员信息的计时器(一天）
                    //timer_UpLoad_Hhygl.Enabled = false;
                    //timer_UpLoad_Hhygl.Interval = 35 * 60 * 1000;
                    //timer_UpLoad_Hhygl.Enabled = true;
                    //下载预定信息
                    int timeInterval = int.Parse(common_file.Common.ReadXML("add", "timeInterval"));
                    timer_Ydxx.Interval =timeInterval*60 * 1000;
                    timer_Ydxx.Enabled = true;
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

        //向listBox中增加信息
        public  void AddMsg(string msgStr)
        {
            this.listBox1.Items.Add(msgStr);
        }
#endregion       

        private void M_Ts_AutoBegin_Click(object sender, EventArgs e)
        {

        }
    }
}